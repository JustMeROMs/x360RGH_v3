Imports System
Imports System.IO
Imports System.Text.RegularExpressions


Public Class CPUkey
    Public Function readfusefile(ByVal file As String) As String()
        Dim ret As String() = New String(1) {}
        Dim val As String = "", cfldv As String = ""
        Dim ldval As Integer = 0
        Dim key1 As Int64 = 0, key2 As Int64 = 0, key3 As Int64 = 0, key4 As Int64 = 0
        Using sr As New StreamReader(file)
            While val IsNot Nothing
                val = sr.ReadLine()
                If val IsNot Nothing Then
                    If val.StartsWith("fuseset 03:") Then
                        key1 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber)
                    ElseIf val.StartsWith("fuseset 04:") Then
                        key2 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber)
                    ElseIf val.StartsWith("fuseset 05:") Then
                        key3 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber)
                    ElseIf val.StartsWith("fuseset 06:") Then
                        key4 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber)
                    ElseIf val.StartsWith("fuseset 07:") Then
                        cfldv = val.Remove(0, 11)
                        cfldv = Regex.Replace(cfldv, " ", "")
                    ElseIf val.StartsWith("fuseset 08:") Then
                        cfldv += val.Remove(0, 11)
                        cfldv = Regex.Replace(cfldv, " ", "")
                        For Each c As Char In cfldv
                            If c.ToString().Equals("f", StringComparison.CurrentCultureIgnoreCase) Then
                                ldval += 1
                            End If
                        Next
                    End If
                End If
            End While
            sr.Close()
        End Using
        If (key1 <> 0) AndAlso (key2 <> 0) AndAlso (key3 <> 0) AndAlso (key4 <> 0) Then
            ret(0) = (key1 Or key2).ToString("X16") + (key3 Or key4).ToString("X16")
            ret(1) = ldval.ToString()
        Else
            ret(0) = ""
            ret(1) = ""
        End If
        Return ret
    End Function
    Public Function readkeyfile(ByVal file As String) As String
        Dim ret As String = ""
        Using sr As New StreamReader(file)
            ret = sr.ReadLine()
            ret = ret.Trim()
            If (ret.IndexOf("cpukey", StringComparison.OrdinalIgnoreCase) >= 0) AndAlso (ret.Length > 38) Then
                ret = ret.Substring(ret.Length - 32, 32)
            End If
            sr.Close()
        End Using
        Return ret
    End Function
End Class


