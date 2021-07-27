Imports System
Imports System.Security.Cryptography
Imports System.Windows.Forms

Namespace DGXapp

    Class crypto
        Dim misc As New Misc
        Private Sub RC4(ByRef bytes As [Byte](), ByVal key As [Byte]())
            Dim s As [Byte]() = New [Byte](255) {}, k As [Byte]() = New [Byte](255) {}
            Dim temp As [Byte]
            Dim i As Integer, j As Integer
            For i = 0 To 255
                s(i) = CType(i, [Byte])
                k(i) = key(i Mod key.GetLength(0))
            Next
            j = 0
            For i = 0 To 255
                j = (j + s(i) + k(i)) Mod 256
                temp = s(i)
                s(i) = s(j)
                s(j) = temp
            Next
            i = InlineAssignHelper(j, 0)
            For x As Integer = 0 To bytes.GetLength(0) - 1
                i = (i + 1) Mod 256
                j = (j + s(i)) Mod 256
                temp = s(i)
                s(i) = s(j)
                s(j) = temp
                Dim t As Integer = (CInt(s(i)) + CInt(s(j))) Mod 256
                bytes(x) = bytes(x) Xor s(t)
            Next
        End Sub
        Public Function DecryptSMC(ByVal encdata As Byte()) As Byte()
            Dim decdata As Byte() = New Byte(encdata.Length - 1) {}
            Dim key As Byte() = New Byte() {&H42, &H75, &H4E, &H79}
            For i As Integer = 0 To encdata.Length - 1
                Dim byteChar As Integer = encdata(i)
                Dim [mod] As Integer = byteChar * &HFB
                decdata(i) = Convert.ToByte(byteChar Xor (key(i And 3) And &HFF))
                key((i + 1) And 3) += CByte([mod])
                key((i + 2) And 3) += Convert.ToByte([mod] >> 8)
            Next
            Return decdata
        End Function
        Public Function DecryptKV(ByVal encdata As Byte(), ByVal cpukey As String) As Byte()
            Dim key As Byte() = misc.cpukeytoarray(cpukey)
            Dim tmp As Byte() = New Byte(encdata.Length - 17) {}
            Dim header As Byte() = New Byte(15) {}
            Array.Copy(encdata, &H0, header, &H0, &H10)
            Buffer.BlockCopy(encdata, &H10, tmp, &H0, tmp.Length)
            key = New HMACSHA1(key, False).ComputeHash(header)
            Array.Resize(key, &H10)
            RC4(tmp, key)
            Dim decdata As Byte() = New Byte(encdata.Length - 1) {}
            Array.Copy(header, decdata, header.Length)
            Buffer.BlockCopy(tmp, &H0, decdata, header.Length, tmp.Length)
            Return decdata
        End Function
        Public Function DecryptCB(ByVal encdata As Byte(), ByVal inkey As Byte(), ByVal cba As Byte()) As Byte()
            Dim [error] As Boolean = False
            Dim type As UInt16 = 0
            If cba IsNot Nothing Then
                type = misc.swap16(BitConverter.ToUInt16(cba, 6))
            Else
                type = misc.swap16(BitConverter.ToUInt16(encdata, 6))
                If (type = &H800) OrElse (type = &H1800) Then
                    type = 0
                End If
            End If
            Dim header As Byte() = New Byte(15) {}
            Array.Copy(encdata, &H10, header, &H0, &H10)
            Dim decdata As Byte() = New Byte(encdata.Length - 1) {}
            Array.Copy(encdata, decdata, &H10)
            Dim key As Byte() = New Byte(-1) {}
            If type = 0 Then
                key = New HMACSHA1(inkey).ComputeHash(header)
            ElseIf (type = &H800) AndAlso (cba IsNot Nothing) Then
                Array.Resize(header, &H20)
                Array.Copy(inkey, &H0, header, &H10, &H10)
                Dim cbakey As Byte() = New Byte(15) {}
                Array.Copy(cba, &H10, cbakey, &H0, &H10)
                key = New HMACSHA1(cbakey).ComputeHash(header)
            ElseIf (type = &H1800) AndAlso (cba IsNot Nothing) Then
                header = New Byte(47) {}
                Array.Copy(encdata, &H10, header, &H0, &H10)
                Array.Copy(inkey, &H0, header, &H10, &H10)
                Array.Copy(cba, &H0, header, &H20, &H6)
                Array.Copy(cba, &H8, header, &H20 + &H8, &H8)
                Dim cbakey As Byte() = New Byte(15) {}
                Array.Copy(cba, &H10, cbakey, &H0, &H10)
                key = New HMACSHA1(cbakey).ComputeHash(header)
            Else
                [error] = True
                MessageBox.Show("ERROR: Unkown crypto type! (0x" + type.ToString("X4") + ") or cba data is missing (major bug)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
            If Not [error] Then
                Array.Resize(key, &H10)
                Array.Copy(key, &H0, decdata, &H10, &H10)
                Dim decrypted As Byte() = New Byte(encdata.Length - 33) {}
                Buffer.BlockCopy(encdata, &H20, decrypted, &H0, decrypted.Length)
                RC4(decrypted, key)
                Buffer.BlockCopy(decrypted, &H0, decdata, &H20, decrypted.Length)
                Return decdata
            Else
                Return New Byte(-1) {}
            End If
        End Function
        Public Function DecryptCB(ByVal encdata As Byte(), ByVal key As Byte()) As Byte()
            Return DecryptCB(encdata, key, Nothing)
        End Function
        Public Function DecryptCF(ByVal encdata As Byte(), ByVal inkey As Byte()) As Byte()
            Dim header As Byte() = New Byte(15) {}
            Array.Copy(encdata, &H20, header, &H0, &H10)
            Dim key As Byte() = New HMACSHA1(inkey).ComputeHash(header)
            Array.Resize(key, &H10)
            Dim decdata As Byte() = New Byte(encdata.Length - 1) {}
            Buffer.BlockCopy(encdata, &H0, decdata, &H0, &H20)
            Array.Copy(key, &H0, decdata, &H20, key.Length)
            Dim decrypted As Byte() = New Byte(encdata.Length - 49) {}
            Buffer.BlockCopy(encdata, &H30, decrypted, &H0, decrypted.Length)
            RC4(decrypted, key)
            Buffer.BlockCopy(decrypted, &H0, decdata, &H30, decrypted.Length)
            Return decdata
        End Function
        Public Function kvcheck(ByVal data As Byte(), ByVal key As String) As Boolean
            Dim ret As Boolean = True
            Dim header As Byte() = New Byte(15) {}, tmp As Byte() = New Byte(&H4002 - 17) {}
            Array.Copy(data, &H0, header, &H0, &H10)
            Array.Copy(data, &H10, tmp, &H0, &H4000 - &H10)
            tmp(&H3FF0) = &H7
            tmp(&H3FF1) = &H12
            Dim checkdata As Byte() = New HMACSHA1(misc.cpukeytoarray(key), False).ComputeHash(tmp)
            Array.Resize(checkdata, &H10)
            For i As Integer = 0 To checkdata.Length - 1
                If checkdata(i) <> header(i) Then
                    ret = False
                End If
            Next
            Return ret
        End Function
        Public Function blcheck(ByRef data As Byte(), ByVal offset As Integer, ByVal length As Integer) As Boolean
            Dim ret As Boolean = True
            For i As Integer = 0 To length - 1
                If data(offset + i) <> &H0 Then
                    ret = False
                End If
            Next
            Return ret
        End Function
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace

