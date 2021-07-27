Imports System
Imports System.IO
Imports System.Windows.Forms

Namespace DGXapp
    Class NandOP
        Dim misc As New Misc

        Public Shared userdata As Byte() = New Byte(-1) {}, sparedata As Byte() = New Byte(-1) {}
        Private Sub readsplit(ByVal source As String, ByVal pages As Integer)
            Using br As New BinaryReader(File.Open(source, FileMode.Open, FileAccess.Read))
                Dim size As Integer = ((512 + 16) * pages), filelen As Integer = CInt(br.BaseStream.Length), i As Integer, j As Integer, useroffset As Integer = 0, spareoffset As Integer = 0
                userdata = New Byte(512 * pages - 1) {}
                sparedata = New Byte(16 * pages - 1) {}
                If filelen >= size Then
                    For j = 0 To pages - 1
                        For i = 0 To 511
                            userdata(useroffset) = br.ReadByte()
                            useroffset += 1
                        Next
                        For i = 0 To 15
                            sparedata(spareoffset) = br.ReadByte()
                            spareoffset += 1
                        Next
                    Next
                End If
            End Using
        End Sub
        Private Function getpages(ByVal source As String) As Integer
            Dim fi As New FileInfo(source)
            If fi.Length = 17301504 Then
                Return (&H400 * 32)
            ElseIf (fi.Length = 69206016) OrElse (fi.Length = 276824064) OrElse (fi.Length = 553648128) Then
                Return (&H1000 * 32)
            Else
                Dim res As DialogResult = MessageBox.Show("ERROR: Can't determine if it's big or small block nand, do you want to continue anyways? (this is a sign that your nand is not properly dumped)", "ERROR - unable to determine dump size", MessageBoxButtons.YesNo, MessageBoxIcon.[Error])
                If res = DialogResult.Yes Then
                    Return CInt(fi.Length / (512 + 16)) * 32
                Else
                    Return 0
                End If
            End If
        End Function
        Public Function getbootloaderversions(ByVal source As String) As Integer()
            Dim pages As Integer = getpages(source)
            If pages <> 0 Then
                readsplit(source, pages)
                Dim ret As Integer() = New Integer(10) {}
                Dim pos As Integer = &H8000
                If userdata.Length > pos Then
                    If (userdata(pos) = &H43) AndAlso (userdata(pos + 1) = &H42) Then
                        ret(0) = Misc.swap16(BitConverter.ToUInt16(userdata, pos + &H2))
                        Dim size As Integer = CInt(misc.swap32(BitConverter.ToUInt32(userdata, pos + &HC)))
                        pos = pos + size
                        While userdata(pos) = &H43
                            If pos + &HD < userdata.Length Then
                                Select Case userdata(pos + 1)
                                    Case &H42
                                        ret(1) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H2))
                                        Exit Select
                                    Case &H44
                                        ret(2) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H2))
                                        Exit Select
                                    Case &H45
                                        ret(3) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H2))
                                        Exit Select
                                    Case Else
                                        pos = userdata.Length - 1
                                        Exit Select
                                End Select
                                If pos <> userdata.Length - 1 Then
                                    size = CInt(misc.swap32(BitConverter.ToUInt32(userdata, pos + &HC)))
                                    pos = pos + size
                                End If
                            End If
                        End While
                        pos = CInt(misc.swap32(BitConverter.ToUInt32(userdata, &H64)))
                        ret(8) = pos
                        Dim patchcount As Integer = misc.swap16(BitConverter.ToUInt16(userdata, &H68))
                        ret(9) = patchcount
                        size = CInt(misc.swap32(BitConverter.ToUInt32(userdata, &H70)))
                        If size = &H0 Then
                            Dim fi As New FileInfo(source)
                            If fi.Length < 17301505 Then
                                size = &H10000
                            Else
                                size = &H20000
                            End If
                        End If
                        If (patchcount > 0) AndAlso (size > 0) AndAlso (pos > 0) Then
                            If (userdata(pos) = &H43) AndAlso (userdata(pos + 1) = &H46) Then
                                ret(4) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H2))
                                If patchcount > 1 Then
                                    If (userdata(pos + &H10000) = &H43) AndAlso (userdata(pos + &H10001) = &H46) Then
                                        ret(6) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H10002))
                                        ret(10) = &H10000
                                    ElseIf (userdata(pos + &H20000) = &H43) AndAlso (userdata(pos + &H20001) = &H46) Then
                                        ret(6) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H20002))
                                        ret(10) = &H20000
                                    End If
                                End If
                                pos = pos + CInt(misc.swap32(BitConverter.ToUInt32(userdata, pos + &HC)))
                                If (userdata(pos) = &H43) AndAlso (userdata(pos + 1) = &H47) Then
                                    ret(5) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H2))
                                    If patchcount > 1 Then
                                        If (userdata(pos + &H10000) = &H43) AndAlso (userdata(pos + &H10001) = &H47) Then
                                            ret(7) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H10002))
                                        ElseIf (userdata(pos + &H20000) = &H43) AndAlso (userdata(pos + &H20001) = &H47) Then
                                            ret(7) = misc.swap16(BitConverter.ToUInt16(userdata, pos + &H20002))
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        ret(0) = 0
                    End If
                End If
                Return ret
            Else
                Return New Integer(7) {}
            End If
        End Function
        Public Function getcbversion(ByVal source As String) As Integer
            Dim ret As Integer() = getbootloaderversions(source)
            Return ret(0)
        End Function
        Public Sub savesmc(ByVal saveloc As String, ByVal smcdata As Byte())
            save(saveloc + "\smc.bin", smcdata)
        End Sub
        Public Sub savekv(ByVal saveloc As String, ByVal kvdata As Byte())
            save(saveloc + "\kv.bin", kvdata)
        End Sub
        Public Sub saveconfig(ByVal saveloc As String, ByVal configdata As Byte())
            save(saveloc + "\smc_config.bin", configdata)
        End Sub
        Public Sub getkv_smc(ByVal source As String)
            readsplit(source, 64)
            Dim hd As Integer = 0, ed As Integer = 0
            '#Region "SMC"
            Dim smcstart As UInteger = misc.swap32(BitConverter.ToUInt32(userdata, &H7C))
            Dim smcsize As UInteger = misc.swap32(BitConverter.ToUInt32(userdata, &H78))
            Dim smcsizeint As Integer = Convert.ToInt32(smcsize)
            frmMain.encsmc = New Byte(smcsizeint - 1) {}
            hd = Convert.ToInt32(smcstart)
            For ed = 0 To smcsizeint - 1
                frmMain.encsmc(ed) = userdata(hd)
                hd += 1
            Next
            '#End Region
            '#Region "Keyvault"
            frmMain.enckv = New Byte(16383) {}
            hd = &H4000
            For ed = 0 To 16383
                frmMain.enckv(ed) = userdata(hd)
                hd += 1
            Next
            '#End Region
        End Sub
        Public Function dump_conf(ByVal source As String) As Byte()
            Dim pages As Integer = getpages(source), i As Integer, j As Integer
            If pages = (&H400 * 32) Then
                j = &HF7C000
            Else
                j = &H3BE0000
            End If
            If pages <> 0 Then
                readsplit(source, pages)
                Dim smc_config As Byte() = New Byte(1023) {}
                For i = 0 To smc_config.Length - 1
                    smc_config(i) = userdata(j)
                    j += 1
                Next
                Return smc_config
            Else
                Return Nothing
            End If
        End Function
        Public Function get_fcrt(ByVal source As String) As Byte()
            Dim i As Integer = 0, pages As Integer = getpages(source)
            Dim offset As UInteger = 0, length As UInteger = 0
            If pages <> 0 Then
                readsplit(source, pages)
                Dim ret As Byte() = New Byte(-1) {}
                '#Region "Reading FCRT.bin"
                For i = 0 To userdata.Length - 1
                    If userdata(i) = &H66 Then
                        If (userdata(i + 1) = &H63) AndAlso (userdata(i + 2) = &H72) AndAlso (userdata(i + 3) = &H74) AndAlso (userdata(i + 4) = &H2E) AndAlso (userdata(i + 5) = &H62) AndAlso (userdata(i + 6) = &H69) AndAlso (userdata(i + 7) = &H6E) Then
                            offset = CUInt(misc.swap16(BitConverter.ToUInt16(userdata, i + 22)) * &H4000)
                            length = misc.swap32(BitConverter.ToUInt32(userdata, i + 24))
                            ret = New Byte(length - 1) {}
                            For j As Integer = 0 To length - 1
                                ret(j) = userdata(offset)
                                offset += 1
                            Next
                            i = userdata.Length
                        End If
                    End If
                Next
                '#End Region
                Return ret
            Else
                Return Nothing
            End If
        End Function
        Private Sub save(ByVal file__1 As String, ByVal data As Byte())
            Directory.CreateDirectory(Path.GetDirectoryName(file__1))
            If File.Exists(file__1) Then
                File.Delete(file__1)
            End If
            File.WriteAllBytes(file__1, data)
        End Sub
        Private Function getbootloader(ByVal pos As Integer, ByVal size As Integer) As Byte()
            Dim data As Byte() = New Byte(size - 1) {}
            Array.Copy(userdata, pos, data, 0, size)
            Return data
        End Function
        Public Function getcf(ByVal source As String, ByVal pos As Integer) As Byte()
            Dim data As Byte() = New Byte(-1) {}
            If userdata.Length > pos Then
                Dim size As Integer = CInt(misc.swap32(BitConverter.ToUInt32(userdata, pos + &HC)))
                If userdata.Length > (pos + size) Then
                    If (userdata(pos) = &H43) AndAlso (userdata(pos + 1) = &H46) Then
                        data = getbootloader(pos, size)
                    End If
                End If
            End If
            Return data
        End Function
        Public Function getcba(ByVal source As String) As Byte()
            Dim data As Byte() = New Byte(-1) {}
            Dim pages As Integer = getpages(source)
            If pages <> 0 Then
                readsplit(source, pages)
                Dim pos As Integer = &H8000
                If userdata.Length > pos Then
                    Dim size As Integer = CInt(misc.swap32(BitConverter.ToUInt32(userdata, pos + &HC)))
                    If userdata.Length > (pos + size) Then
                        If (userdata(pos) = &H43) AndAlso (userdata(pos + 1) = &H42) Then
                            data = getbootloader(pos, size)
                        End If
                    End If
                End If
            End If
            Return data
        End Function
        Public Function getcbb(ByVal source As String, ByVal pos As Integer) As Byte()
            Dim data As Byte() = New Byte(-1) {}
            If userdata.Length > pos Then
                Dim size As Integer = CInt(misc.swap32(BitConverter.ToUInt32(userdata, pos + &HC)))
                If userdata.Length > (pos + size) Then
                    If (userdata(pos) = &H43) AndAlso (userdata(pos + 1) = &H42) Then
                        data = getbootloader(pos, size)
                    End If
                End If
            End If
            Return data
        End Function
        Public Function getcf_offsets(ByVal source As String) As Integer()
            Dim ret As Integer() = New Integer(1) {}
            Dim pages As Integer = getpages(source)
            If pages <> 0 Then
                readsplit(source, pages)
                Dim pos As Integer = CInt(misc.swap32(BitConverter.ToUInt32(userdata, &H64)))
                If userdata.Length > (pos) Then
                    If (userdata(pos) = &H43) AndAlso (userdata(pos + 1) = &H46) Then
                        ret(0) = pos
                        If (userdata(pos + &H10000) = &H43) AndAlso (userdata(pos + &H10001) = &H46) Then
                            ret(1) = pos + &H10000
                        End If
                        If (userdata(pos + &H20000) = &H43) AndAlso (userdata(pos + &H20001) = &H46) Then
                            ret(1) = pos + &H20000
                        End If
                    End If
                End If
            End If
            Return ret
        End Function
    End Class
End Namespace

