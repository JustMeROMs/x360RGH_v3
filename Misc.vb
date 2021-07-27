Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Namespace DGXapp
    Class Misc
        Public Function checkxmlempty(ByVal input As String, ByVal xml As Boolean) As String
            If input IsNot Nothing Then
                If input.Equals("none", StringComparison.CurrentCultureIgnoreCase) Then
                    Return ""
                ElseIf String.IsNullOrEmpty(input) AndAlso (xml) Then
                    Return "none"
                Else
                    Return input
                End If
            Else
                Return ""
            End If
        End Function
        Public Function getmd5(ByVal file__1 As String) As String
            If File.Exists(file__1) Then
                Dim fs As New FileStream(file__1, FileMode.Open, FileAccess.Read)
                Dim md5check As MD5 = New MD5CryptoServiceProvider()
                Dim retval As Byte() = md5check.ComputeHash(fs)
                fs.Close()
                Dim sb As New StringBuilder()
                For Each b As Byte In retval
                    sb.Append(b.ToString("X2"))
                Next
                Return sb.ToString()
            Else
                System.Windows.Forms.MessageBox.Show("ERROR: File doesn't exist! cannot check MD5 of a file that don't exist!", "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.[Error])
                Return "error"
            End If
        End Function
        Public Function swap16(ByVal input As UInt16) As UInt16
            Return Convert.ToUInt16(((&HFF00 And input) >> 8) Or ((&HFF And input) << 8))

        End Function
        Public Function swap32(ByVal input As UInt32) As UInt32
            Return (input And &HFFUI) << 24 Or (input And &HFF00UI) << 8 Or (input And &HFF0000UI) >> 8 Or (input And &HFF000000UI) >> 24
        End Function
        Public Function cpukeytoarray(ByVal cpukey As String) As Byte()
            Dim ret As Byte() = New Byte(cpukey.Length / 2 - 1) {}
            For i As Integer = 0 To cpukey.Length - 1 Step 2
                ret(i / 2) = Byte.Parse(cpukey.Substring(i, 2), System.Globalization.NumberStyles.HexNumber)
            Next
            Return ret
        End Function
        Public Function translateregion(ByVal source As String) As String
            Select Case source
                Case ""
                    Return ""
                Case Nothing
                    Return ""
                Case "0x02FE"
                    Return "PAL/Europe"
                Case "PAL/Europe"
                    Return "0x02FE"
                Case "0x0201"
                    Return "PAL/Australia"
                Case "PAL/Australia"
                    Return "0x0201"
                Case "0x00FF"
                    Return "NTSC/USA"
                Case "NTSC/USA"
                    Return "0x00FF"
                Case "0x01FE"
                    Return "NTSC/Japan"
                Case "NTSC/Japan"
                    Return "0x01FE"
                Case "0x01FC"
                    Return "NTSC/Korea"
                Case "NTSC/Korea"
                    Return "0x01FC"
                Case "0x0101"
                    Return "NTSC/Hong Kong"
                Case "NTSC/Hong Kong"
                    Return "0x0101"
                Case "0x7FFF"
                    Return "Devkit"
                Case "Devkit"
                    Return "0x7FFF"
                Case Else
                    Return "Unkown"
            End Select
        End Function
        Public Function translatedvd(ByVal source As Byte) As String
            Select Case source
                Case 1
                    Return "1 (North America)"
                Case 2
                    Return "2 (Europe)"
                Case 3
                    Return "3 (South East Asia)"
                Case 4
                    Return "4 (Australia)"
                Case 5
                    Return "5 (Russia/South Asia)"
                Case 6
                    Return "6 (China)"
                Case 7
                    Return "7 (Unkown)"
                Case 8
                    Return "8 (Aircrafts etc.)"
                Case Else
                    Return "unkown"
            End Select
        End Function
    End Class
End Namespace


