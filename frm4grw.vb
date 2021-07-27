Imports Microsoft.Win32.SafeHandles
Imports System.Reflection
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.ComponentModel

'Imports System.Security.Principal
'---------------------- above for nandMMC

Public Class frm4grw

    '----------------------------------- nandMMC
    Private _busy As Boolean
    Private _dev As String, _file As String
    Private _size As ULong
    Private _incfixed As Boolean, _abort As Boolean

    Dim sw As Stopwatch = New Stopwatch()
    '------------------------------------- End nandMMC

    Private Sub frm4grw_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboCoronaDumpX.SelectedIndex = 1
    End Sub


    '--------------------------------------------------------- MAIN CODE FOR nandMMC (18-9-2012)

    Public Sub ShowLoadingBar(Optional ByVal showit As Boolean = True)
        If showit Then
            pgBar.Style = ProgressBarStyle.Marquee
        Else
            pgBar.Style = ProgressBarStyle.Blocks
        End If
    End Sub

    <DllImport("Kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function CreateFile(ByVal fileName As String, <MarshalAs(UnmanagedType.U4)> ByVal fileAccess As FileAccess, <MarshalAs(UnmanagedType.U4)> ByVal fileShare As FileShare, ByVal securityAttributes As IntPtr, <MarshalAs(UnmanagedType.U4)> ByVal creationDisposition As FileMode, ByVal flags As Integer, _
    ByVal template As IntPtr) As SafeFileHandle
    End Function

    Private Function CheckMagic(ByRef data As Byte()) As Boolean
        Return (data(0) = &HFF AndAlso data(1) = &H4F)
    End Function

    Private Sub Enabledump()
        If _busy Then
            Return
        End If
        btnDump.Enabled = (_size > 0 AndAlso cboList.SelectedIndex <> -1)
        btnFlash.Enabled = Not cboList.Items.Count = 0
    End Sub

    Private Shared Function GetSizeReadable(ByVal i As ULong) As String
        Dim readable As Double
        Dim suffix As String
        If i >= &H10000000000L Then
            ' Terabyte
            suffix = "TB"
            readable = i >> 30
        ElseIf i >= &H40000000 Then
            ' Gigabyte
            suffix = "GB"
            readable = i >> 20
        ElseIf i >= &H100000 Then
            ' Megabyte
            suffix = "MB"
            readable = i >> 10
        ElseIf i >= &H400 Then
            ' Kilobyte
            suffix = "KB"
            readable = i
        Else
            ' Byte
            Return i.ToString("0 B")
        End If
        readable = readable / 1024
        Return readable.ToString("0.## ") + suffix
    End Function

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        _abort = True
    End Sub

    Private Sub startBGworker()
        _busy = True
        'lblStatus.Text = "Populating Device list..."
        frmMain.rtbLog.Text &= vbNewLine & "Populating device list..."
        ShowLoadingBar()
        btnUpdate.Enabled = False
        btnDump.Enabled = False
        btnFlash.Enabled = False
        btnAbort.Enabled = True
        cboList.Items.Clear()
        sw.Start()
        bgWorker.RunWorkerAsync()
    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        Dim temp As New List(Of clsComboItem)
        Dim drives As DriveInfo() = DriveInfo.GetDrives()
        For Each drive As DriveInfo In drives
            Select Case drive.DriveType
                Case DriveType.Removable
                    temp.Add(New clsComboItem(String.Format("{0} [Removable]", drive.Name), drive.Name.Substring(0, 1)))
                    Exit Select

                Case DriveType.Fixed
                    If _incfixed Then
                        temp.Add(New clsComboItem(String.Format("{0} [Non-Removable]", drive.Name), drive.Name.Substring(0, 1)))
                    End If
                    Exit Select
            End Select
        Next
        e.Result = temp
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted

        Dim temp As List(Of clsComboItem) = DirectCast(e.Result, List(Of clsComboItem))
        cboList.Items.AddRange(temp.ToArray)

        btnUpdate.Enabled = True
        btnAbort.Enabled = False
        ShowLoadingBar(False)
        'lblStatus.Text = "Devicelist populated! Waiting for further instructions..."
        frmMain.rtbLog.Text &= vbNewLine & "Devicelist populated! Waiting for further instructions..."
        _busy = False
        Enabledump()
    End Sub

    Private Sub CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radSysOnly.CheckedChanged, radFull.CheckedChanged
        If radSysOnly.Checked Then
            _size = &H300000
        Else
            _size = &HE0400000UI
        End If

        Enabledump()

    End Sub

    Private Sub cboList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboList.SelectedIndexChanged
        Enabledump()
    End Sub

    Private Sub btnDump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDump.Click
        If _busy Then
            Return
        End If
        'If sfd.ShowDialog() <> DialogResult.OK Then
        '    Return
        'End If
        If cboList.SelectedIndex = -1 Then
            frmMain.rtbLog.Text &= vbNewLine & "Please select the device from the list!"
            MessageBox.Show("Please select the device from the list!")
            Return
        End If
        groupSize.Enabled = False
        _file = APP_PATH & "\4gnand\nand1.bin" 'sfd.FileName
        _dev = DirectCast(cboList.SelectedItem, clsComboItem).Value
        ShowLoadingBar()
        sw.Reset()
        sw.Start()
        Dim intX As Integer = Integer.Parse(cboCoronaDumpX.SelectedItem.ToString)
        bgworkerDumper.RunWorkerAsync(intX)
    End Sub

    Private Sub bgworkerDumper_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgworkerDumper.DoWork
        Dim worker As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        Dim intX As Integer = DirectCast(e.Argument, Integer)

        For i As Integer = 1 To intX
            _file &= i.ToString & ".bin"


            Dim handle = GetStarted()
            Dim fs = New FileStream(handle, FileAccess.Read)
            Dim offset As ULong = 0
            Try
                Using binaryWriter = New BinaryWriter(IO.File.Open(_file, FileMode.OpenOrCreate))
                    While offset < _size
                        If _abort Then
                            Exit While
                        End If
                        Dim buff = New Byte(32767) {}
                        fs.Read(buff, 0, 32768)
                        If offset = 0 Then
                            If Not CheckMagic(buff) Then
                                _abort = True
                                worker.ReportProgress(0, "Magic bytes are wrong, your NAND is either corrupt or you selected wrong device!")
                                Exit While
                            End If
                        End If
                        binaryWriter.Write(buff)
                        offset += 32768
                        worker.ReportProgress(50, String.Format("Dumping NAND {0} of {1} dumped ({2:F2}%)", GetSizeReadable(offset), GetSizeReadable(_size), CDbl(offset) / _size * 100.0))

                    End While
                    fs.Close()
                    binaryWriter.Close()
                End Using
            Catch ex As Exception
                worker.ReportProgress(0, "ERROR:" & ex.ToString)
                _abort = True
            End Try
            If _abort Then
                Try
                    IO.File.Delete(_file)
                Catch
                End Try
            End If
        Next
        ' e.Result = offset
    End Sub

    Private Sub bgworkerDumper_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgworkerDumper.ProgressChanged
        Dim temp As String = DirectCast(e.UserState, String)
        If e.ProgressPercentage = 0 Then
            MessageBox.Show(temp, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        'lblStatus.Text = temp
        frmMain.rtbLog.Text &= vbNewLine & temp
    End Sub

    Private Sub bgworkerDumper_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgworkerDumper.RunWorkerCompleted
        ' Dim offset As ULong = DirectCast(e.Result, ULong)
        ShowLoadingBar(False)
        btnDump.Enabled = True
        btnUpdate.Enabled = True
        btnAbort.Enabled = False
        sw.Stop()
        frmMain.rtbLog.Text &= vbNewLine & If(_abort, "Dump Aborted!", String.Format("Successfully dumped the file(s)! It took {1} Minutes {2} Seconds and {3} Milliseconds", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds)) ' GetSizeReadable(offset),
        _abort = False
        _busy = False
        groupSize.Enabled = True
    End Sub

    Private Sub btnFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlash.Click
        If _busy Then
            Return
        End If
        If Not frmMain.deviceDetected() Then
            MessageBox.Show("Please connect the device !")
            Return
        End If
        If ofd.ShowDialog() <> DialogResult.OK Then
            Return
        End If
        If cboList.SelectedIndex = -1 Then
            MessageBox.Show("Please select the device from the list!")
            Return
        End If

        groupSize.Enabled = False
        _file = ofd.FileName
        _dev = DirectCast(cboList.SelectedItem, clsComboItem).Value
        ShowLoadingBar()
        sw.Reset()
        sw.Start()
        Flasher.RunWorkerAsync()
    End Sub


    Private Sub Flasher_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Flasher.DoWork
        Dim worker As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        _busy = True

        Dim handle = GetStarted()
        Dim fs = New FileStream(handle, FileAccess.ReadWrite)
        Dim offset As ULong = 0
        Try
            Dim fi = New FileInfo(_file)
            Using binaryReader = New BinaryReader(IO.File.Open(fi.FullName, FileMode.OpenOrCreate))
                Dim tsize = CULng(fi.Length)
                While offset < tsize
                    If _abort Then
                        Exit While
                    End If
                    Dim buff = binaryReader.ReadBytes(32768)
                    If offset = 0 Then
                        If Not CheckMagic(buff) Then
                            _abort = True
                            worker.ReportProgress(0, "Magic bytes are wrong, your NAND is either corrupt or you selected wrong device!")
                            Exit While
                        End If
                    End If
                    fs.Write(buff, 0, 32768)
                    offset += 32768
                    worker.ReportProgress(50, String.Format("Flashing NAND {0} of {1} written ({2:F2}%)", GetSizeReadable(offset), GetSizeReadable(tsize), CDbl(offset) / tsize * 100.0))
                End While
                fs.Close()
                binaryReader.Close()
            End Using

        Catch ex As Exception
            worker.ReportProgress(0, "ERROR:" & ex.ToString)
            _abort = True
        End Try

        e.Result = offset

    End Sub

    Private Sub Flasher_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Flasher.ProgressChanged
        Dim temp As String = DirectCast(e.UserState, String)
        If e.ProgressPercentage = 0 Then
            MessageBox.Show(temp, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        'lblStatus.Text = temp
        frmMain.rtbLog.Text &= vbNewLine & temp
    End Sub

    Private Sub Flasher_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Flasher.RunWorkerCompleted
        Dim offset As ULong = DirectCast(e.Result, ULong)
        ShowLoadingBar(False)
        btnDump.Enabled = True
        btnUpdate.Enabled = True
        btnAbort.Enabled = False
        sw.Stop()
        frmMain.rtbLog.Text &= vbNewLine & If(_abort, "Flash Aborted!", String.Format("Successfully wrote {0}! It took {1} Minutes {2} Seconds and {3} Milliseconds", GetSizeReadable(offset), sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds))
        _busy = False
    End Sub

    Private Function GetStarted() As SafeFileHandle

        Dim handle = CreateFile(String.Format("\\.\{0}:", _dev.ToUpper()), FileAccess.ReadWrite, FileShare.ReadWrite Or FileShare.Delete, IntPtr.Zero, FileMode.Open, 0, _
         IntPtr.Zero)
        If handle.IsInvalid Then
            Throw New IOException("Unable to access drive. Win32 Error Code " + Marshal.GetLastWin32Error())
        End If
        Return handle
    End Function

    Private Sub chkIncFixed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncFixed.CheckedChanged
        _incfixed = chkIncFixed.Checked
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If Not bgWorker.IsBusy Then
            startBGworker()
        End If

    End Sub

End Class