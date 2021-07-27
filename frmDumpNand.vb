
Public Class frmDumpNand

    Dim count As Integer
    Dim selectedConsole As String
    Dim selectedNandProdEXE As String

    Dim sw As New Stopwatch

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Form2.Show()
    End Sub

    Private Sub cancelbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelbtn.Click
        Close()
    End Sub


    ' how many reads output to textbox
    Private Sub nandok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nandok.Click
        If My.Computer.FileSystem.FileExists(APP_PATH & "\nandpro\" & selectedNandProdEXE) Then

            count = Integer.Parse(ComboBox1.SelectedItem)
            'Form1.TextBoxcount.Text = count.ToString
            'Form1.ResultsRichTextBox.Text &= vbNewLine & String.Format("You have selected to read nand {0}x....", count.ToString)

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
            ElseIf BigBlock64.Checked Then
                selectedConsole = "Corona"
            ElseIf BigBlock64.Checked Then
                selectedConsole = "Big Block 64"
            ElseIf Jasper256.Checked Then
                selectedConsole = "Jasper 256"
            ElseIf Jasper512.Checked Then
                selectedConsole = "Jasper 512"
            End If

            frmMain.txtConsoleSelected.Text = selectedConsole

            'Form1.ShowLoadingBar()
            frmMain.setLoadingProgressBar()

            If IO.File.Exists(APP_PATH & "\nandpro\nand1.bin") Then
                'Form1.ResultsRichTextBox.Text &= vbNewLine & "nand1.bin file already exists!"
                If MessageBox.Show("nand1.bin file already exists! Do you want to continue overwriting it ?", "Nand exists!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    sw.Start()
                    BackgroundWorker1.RunWorkerAsync()
                    Me.Hide()
                Else
                    'Form1.ResultsRichTextBox.Text &= vbNewLine & "Aborted Nand Read operation by user"
                    MessageBox.Show("Aborted Nand Read operation by user", "Aborted!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Form1.ShowLoadingBar(False)
                    frmMain.setLoadingProgressBar(False)
                    Me.Close()
                End If
            Else
                sw.Start()
                BackgroundWorker1.RunWorkerAsync()
                Me.Hide()
            End If

        Else
            'playAlertSound("PROBLEM")
            MsgBox("Nandpro File Not Found.")
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        Dim i As Integer
        For i = 1 To count

            Dim smallblock As New Process

            smallblock.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            smallblock.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
            smallblock.StartInfo.FileName = selectedNandProdEXE
            smallblock.StartInfo.Arguments = gUSBrLPT & ": -r16 nand" + i.ToString() + ".bin"

            smallblock.Start()

            If selectedConsole = "Xenon" Then
                worker.ReportProgress(0, vbNewLine & "Reading Xenon Nand" & i.ToString())
                smallblock.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
            ElseIf selectedConsole = "Zephry" Then
                worker.ReportProgress(0, vbNewLine & "Reading Zephyr Nand" & i.ToString())
                smallblock.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
            ElseIf selectedConsole = "Falcon" Then
                worker.ReportProgress(0, vbNewLine & "Reading Falcon Nand" & i.ToString())
                smallblock.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
            ElseIf selectedConsole = "Opus" Then
                worker.ReportProgress(0, vbNewLine & "Reading Opus Nand" & i.ToString())
                smallblock.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
            ElseIf selectedConsole = "Jasper 16" Then
                worker.ReportProgress(0, vbNewLine & "Reading Jasper 16 Nand" & i.ToString())
                smallblock.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
            ElseIf selectedConsole = "Trinity" Then
                worker.ReportProgress(0, vbNewLine & "Reading Trinity Nand" & i.ToString())
                smallblock.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
            ElseIf selectedConsole = "Corona" Then
                worker.ReportProgress(0, vbNewLine & "Reading Corona Nand" & i.ToString())
                smallblock.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
            ElseIf selectedConsole = "Big Block 64" Then
                Dim BigBlock64 As New Process
                BigBlock64.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                BigBlock64.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
                BigBlock64.StartInfo.FileName = selectedNandProdEXE
                BigBlock64.StartInfo.Arguments = gUSBrLPT & ": -r64 nand" + i.ToString() + ".bin"
                worker.ReportProgress(0, vbNewLine & "Reading Big Block 64 Nand" + i.ToString())
                BigBlock64.Start()

                BigBlock64.WaitForExit()

                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)

            ElseIf selectedConsole = "Jasper 256" Then
                Dim Jasper256 As New Process
                Jasper256.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                Jasper256.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
                Jasper256.StartInfo.FileName = selectedNandProdEXE
                Jasper256.StartInfo.Arguments = gUSBrLPT & ": -r256 nand" + i.ToString() + ".bin"
                worker.ReportProgress(0, vbNewLine & "Reading Jasper 256 Nand" + i.ToString())


                Jasper256.Start()


                Jasper256.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)

            ElseIf selectedConsole = "Jasper 512" Then
                Dim Jasper512 As New Process
                Jasper512.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
                Jasper512.StartInfo.FileName = selectedNandProdEXE
                Jasper512.StartInfo.Arguments = gUSBrLPT & ": -r512 nand" + i.ToString() + ".bin"
                worker.ReportProgress(0, vbNewLine & "Reading Jasper 512 Nand" + i.ToString())

                Jasper512.Start()

                Jasper512.WaitForExit()
                worker.ReportProgress(0, vbNewLine & "Nandpro ended..." & vbNewLine)
                System.Threading.Thread.Sleep(2000)

            End If

        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        'Form1.ResultsRichTextBox.Text &= DirectCast(e.UserState, String)

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        sw.Stop()
        'Form1.ResultsRichTextBox.Text &= vbNewLine & String.Format("Finished reading...! Time taken: {0} mins, {1} secs, {2} millisecs", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds)
        MessageBox.Show(String.Format("Finished reading...! Time taken: {0} mins, {1} secs, {2} millisecs", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds))
        sw.Reset()
        'playAlertSound("COMPLETE")
        frmMain.setLoadingProgressBar(False)

        '~~~ Check if it is 2 times loading. Then do comparison..!
        If Integer.Parse(ComboBox1.SelectedItem) = 2 Then
            frmMain.compareAfter2Reads()
        End If

        Me.Close()
    End Sub


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedNandProdEXE = frmMain.selectedNandProdEXE
        ComboBox1.SelectedIndex = 1
    End Sub
End Class