Public Class frmBuildImage
   
    Dim sw As New Stopwatch

    Private Sub nandok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nandok.Click
        Dim selectedConsole As String = String.Empty
        Dim selectedNandProdEXE As String = String.Empty
        Dim strFilePathOne As String = String.Empty

        selectedNandProdEXE = frmMain.selectedNandProdEXE
        strFilePathOne = frmMain.txtNandSource.Text

        If My.Computer.FileSystem.FileExists(APP_PATH & "\nandpro\" & selectedNandProdEXE) Then

            If strFilePathOne.Trim.Length = 0 Then
                playAlertSound("")
                MsgBox("You Must Select Nand First..")
            Else


                '-noenter -t retail -c trinity -d data -f 15574 -b DD88AD0C9ED669E7B56794FB68563EFA -p 344DB0E45F81D5F6DAE66260D9746019   output.bin

                Dim strCommandLine As String = "-noenter -t "

                '~~~ type
                If frmMain.radGlitch.Checked Then
                    strCommandLine &= "glitch"
                ElseIf frmMain.radJtag.Checked Then
                    strCommandLine &= "jtag"
                ElseIf frmMain.radRetail.Checked Then
                    strCommandLine &= "retail"
                End If

                strCommandLine &= " -c "


                If Xenon.Checked Then
                    selectedConsole = "Xenon"
                    strCommandLine &= "xenon"
                ElseIf Zephry.Checked Then
                    selectedConsole = "Zephry"
                    strCommandLine &= "zephyr"
                ElseIf Falcon.Checked Then
                    selectedConsole = "Falcon"
                    strCommandLine &= "falcon"
                ElseIf Opus.Checked Then
                    selectedConsole = "Opus"
                    strCommandLine &= "opus"    ' X doubt
                ElseIf Jasper16.Checked Then
                    selectedConsole = "Jasper 16"
                    strCommandLine &= "jasper"
                ElseIf Trinity.Checked Then
                    selectedConsole = "Trinity"
                    strCommandLine &= "trinity"
                ElseIf Trinity.Checked Then
                    selectedConsole = "Corona"
                    strCommandLine &= "corona"
                ElseIf BigBlock64.Checked Then
                    selectedConsole = "Big Block 64"
                    strCommandLine &= "bigblock64"  'X doubt
                ElseIf Jasper256.Checked Then
                    selectedConsole = "Jasper 256"
                    strCommandLine &= "jasper256"
                ElseIf Jasper512.Checked Then
                    selectedConsole = "Jasper 512"
                    strCommandLine &= "jasper512"
                End If

                Dim strSMCline As String = ""

                If frmMain.radRetail.Checked And frmMain.radRGH.Checked Then
                    strSMCline = " -o patchsmc"
                End If

                strCommandLine &= String.Format(" -d data -f {0} -b {1} -p {2}{3} output.bin", frmMain.cboDashVersions.SelectedItem.ToString, frmMain.txt1BLkey.Text.Trim, frmMain.txtCPUkey.Text.Trim, strSMCline)

                frmMain.txtConsoleSelected.Text = selectedConsole

                frmMain.setLoadingProgressBar()

                sw.Start()
                BackgroundWorker1.RunWorkerAsync(New Object() {selectedConsole, selectedNandProdEXE, strFilePathOne, strCommandLine})


                Me.Hide()
                End If
        Else
                playAlertSound("PROBLEM")
                MsgBox("Nandpro File Not Found.")
        End If

    End Sub

    Private Sub cancelbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelbtn.Click
        Me.Close()
    End Sub

    '-noenter -t glitch -c falcon -d data -f 16197 -b DD88AD0C9ED669E7B56794FB68563EFA -p 0CA7AFF1247D1E2B3B02B66535E4CD2E output.bin
    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        worker.ReportProgress(0, "Entered into separate thread..")
        Dim objs() As Object = DirectCast(e.Argument, Object())

        Dim selectedConsole As String = objs(0)
        Dim selectedNandProdEXE As String = objs(1)
        Dim strFilePathOne As String = objs(2)
        Dim strCommandLine As String = objs(3)

        'worker.ReportProgress(0, selectedConsole & vbNewLine & selectedNandProdEXE & vbNewLine & strFilePathOne & vbNewLine & strCommandLine)

        Dim procBuildImage As New Process

        procBuildImage.StartInfo.UseShellExecute = False
        procBuildImage.StartInfo.RedirectStandardOutput = True
        procBuildImage.StartInfo.RedirectStandardError = True
        procBuildImage.StartInfo.CreateNoWindow = True
        'procBuildImage.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        procBuildImage.StartInfo.WorkingDirectory = APP_PATH & "\" 'nandpro"
        'procBuildImage.StartInfo.FileName = "xeBuild" 'selectedNandProdEXE
        procBuildImage.StartInfo.FileName = APP_PATH & "\xeBuild.exe" ' & strCommandLine
        procBuildImage.StartInfo.Arguments = strCommandLine
        worker.ReportProgress(0, vbNewLine & "Building Image... APPPath:" & APP_PATH)
        worker.ReportProgress(0, vbNewLine & vbNewLine & strCommandLine & vbNewLine)
        procBuildImage.Start()

        Dim strErrorProcess As String = _
           Replace(procBuildImage.StandardError.ReadToEnd(), _
                   Chr(13) & Chr(13), Chr(13))
        worker.ReportProgress(0, "ERROR: " & strErrorProcess)

        procBuildImage.WaitForExit()

        Dim strOutputProcess As String = _
           Replace(procBuildImage.StandardOutput.ReadToEnd(), _
                   Chr(13) & Chr(13), Chr(13))

        worker.ReportProgress(0, strOutputProcess)
        worker.ReportProgress(0, vbNewLine & "It is about to finish building..!" & vbNewLine)
        System.Threading.Thread.Sleep(2000)



        'Dim eccwrite As New Process
        'eccwrite.StartInfo.UseShellExecute = False
        'eccwrite.StartInfo.RedirectStandardOutput = True
        'eccwrite.StartInfo.RedirectStandardError = True

        'eccwrite.StartInfo.CreateNoWindow = True
        'eccwrite.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
        'eccwrite.StartInfo.FileName = APP_PATH & "\nandpro\" & selectedNandProdEXE
        'eccwrite.StartInfo.Arguments = gUSBrLPT & ": +w16 image_00000000.ecc "
        'eccwrite.Start()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        frmMain.rtbLog.Text &= DirectCast(e.UserState, String)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        sw.Stop()
        frmMain.rtbLog.Text &= vbNewLine & String.Format("Finished building the image...! Time taken: {0} mins, {1} secs, {2} millisecs", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds)
        sw.Reset()
        playAlertSound("COMPLETE")
        frmMain.setLoadingProgressBar(False)
        Me.Close()
    End Sub
End Class