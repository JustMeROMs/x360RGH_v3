Public Class frmWriteNand
    Dim selectedConsole As String
    Dim selectedNandProdEXE As String
    Dim strFilePathOne As String

    Dim sw As New Stopwatch

    Private Sub cancelbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelbtn.Click
        Close()
    End Sub

    Private Sub nandok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nandok.Click

        If My.Computer.FileSystem.FileExists(APP_PATH & "\nandpro\" & selectedNandProdEXE) Then

            If strFilePathOne.Trim.Length = 0 Then
                playAlertSound("")
                MsgBox("You Must Select Nand First..")
            Else


                If Xenon.Checked Then
                    selectedConsole = "Xenon"
                ElseIf Zephry.Checked Then
                    selectedConsole = "Zephry"
                ElseIf Falcon.Checked Then
                    selectedConsole = "Falcon"
                ElseIf Opus.Checked Then
                    selectedConsole = "Opus"
                ElseIf Jasper16.Checked Then
                    selectedConsole = "Jasper 16"
                ElseIf Trinity.Checked Then
                    selectedConsole = "Trinity"
                ElseIf Trinity.Checked Then
                    selectedConsole = "Corona"
                ElseIf BigBlock64.Checked Then
                    selectedConsole = "Big Block 64"
                ElseIf Jasper256.Checked Then
                    selectedConsole = "Jasper 256"
                ElseIf Jasper512.Checked Then
                    selectedConsole = "Jasper 512"
                End If

                frmMain.txtConsoleSelected.Text = selectedConsole

                frmMain.setLoadingProgressBar()

                sw.Start()
                BackgroundWorker1.RunWorkerAsync()


                Me.Hide()
            End If
        Else
            playAlertSound("PROBLEM")
            MsgBox("Nandpro File Not Found.")
        End If


    End Sub


    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        selectedNandProdEXE = frmMain.selectedNandProdEXE
        strFilePathOne = frmMain.txtNandSource.Text
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        Dim smallblock As New Process

        smallblock.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

        smallblock.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
        smallblock.StartInfo.FileName = selectedNandProdEXE
        smallblock.StartInfo.Arguments = gUSBrLPT & ": -w16 " & strFilePathOne

        smallblock.Start()

        If selectedConsole = "Xenon" Then
            worker.ReportProgress(0, vbNewLine & "Writing Xenon Nand")
            smallblock.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro Ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
        ElseIf selectedConsole = "Zephry" Then
            worker.ReportProgress(0, vbNewLine & "Writing Zephyr Nand")
            smallblock.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
        ElseIf selectedConsole = "Falcon" Then
            worker.ReportProgress(0, vbNewLine & "Writing Falcon Nand")
            smallblock.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
        ElseIf selectedConsole = "Opus" Then
            worker.ReportProgress(0, vbNewLine & "Writing Opus Nand")
            smallblock.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
        ElseIf selectedConsole = "Jasper 16" Then
            worker.ReportProgress(0, vbNewLine & "Writing Jasper 16 Nand")
            smallblock.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
        ElseIf selectedConsole = "Trinity" Then
            worker.ReportProgress(0, vbNewLine & "Writing Trinity Nand")
            smallblock.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
        ElseIf selectedConsole = "Trinity" Then
            worker.ReportProgress(0, vbNewLine & "Writing Corona Nand")
            smallblock.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
        ElseIf selectedConsole = "Big Block 64" Then
            Dim BigBlock64 As New Process
            BigBlock64.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            BigBlock64.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
            BigBlock64.StartInfo.FileName = selectedNandProdEXE
            BigBlock64.StartInfo.Arguments = gUSBrLPT & ": +r64 " & strFilePathOne
            worker.ReportProgress(0, vbNewLine & "Writing Big Block 64 Nand")
            BigBlock64.Start()

            BigBlock64.WaitForExit()

            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)

        ElseIf selectedConsole = "Jasper 256" Then
            Dim Jasper256 As New Process
            Jasper256.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Jasper256.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
            Jasper256.StartInfo.FileName = selectedNandProdEXE
            Jasper256.StartInfo.Arguments = gUSBrLPT & ": +64 " & strFilePathOne
            worker.ReportProgress(0, vbNewLine & "Writing Jasper 256 Nand")


            Jasper256.Start()


            Jasper256.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)

        ElseIf selectedConsole = "Jasper 512" Then
            Dim Jasper512 As New Process
            Jasper512.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
            Jasper512.StartInfo.FileName = selectedNandProdEXE
            Jasper512.StartInfo.Arguments = gUSBrLPT & ": +w64 nand1.bin"
            worker.ReportProgress(0, vbNewLine & "Writing Jasper 512 Nand")

            Jasper512.Start()

            Jasper512.WaitForExit()
            worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
            System.Threading.Thread.Sleep(2000)

        End If

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        frmMain.rtbLog.Text &= DirectCast(e.UserState, String)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        sw.Stop()
        frmMain.rtbLog.Text &= vbNewLine & String.Format("Finished writing...! Time taken: {0} mins, {1} secs, {2} millisecs", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds)
        sw.Reset()
        playAlertSound("COMPLETE")
        frmMain.setLoadingProgressBar(False)
        Me.Close()
    End Sub
End Class
