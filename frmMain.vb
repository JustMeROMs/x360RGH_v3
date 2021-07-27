Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Text
Imports System.ComponentModel

Public Class frmMain
    Dim bolIsComparingAfter2Reads As Boolean = False '~~~ set if the comparing is done after two reads!
    Dim procComMonitor As Process

    Dim objNand As New DGXapp.NandOP
    Dim objCrypt As New DGXapp.crypto
    Dim objMisc As New DGXapp.Misc

    ' For KeyVault
    Public Shared smc As Byte() = New Byte(-1) {}, kv As Byte() = New Byte(-1) {}, encsmc As Byte() = New Byte(-1) {}, enckv As Byte() = New Byte(-1) {}

    Dim intRepeatCount As Integer = 0
    Public selectedNandProdEXE As String
    Dim strPathToFile As String

    Dim strCB_A As String = String.Empty '~~~ passed as reference to get the CB(CB_A) value

    '~~~ For setting and unsetting the main ProgressBar
    Public Sub setLoadingProgressBar(Optional ByVal bolShowIt = True)
        If bolShowIt = True Then
            Me.pgBar.Style = ProgressBarStyle.Marquee
        Else
            Me.pgBar.Style = ProgressBarStyle.Blocks
        End If
    End Sub

    Private Sub autoLoadKVNandinfo() Handles txtNandSource.TextChanged, txtCPUkey.TextChanged
        If txtNandSource.Text.Trim.Length > 0 AndAlso txtCPUkey.Text.Trim.Length > 0 Then
            btnCheckUpdateVersions.PerformClick()
            btnCheckKV.PerformClick()
        End If
    End Sub

    Private Sub btnBrowseSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseSource.Click
        'TextBox2.Clear()
        'TextBox3.Clear()
        'TextBox4.Clear()
        'TextBox5.Clear()

        setLoadingProgressBar()

        Me.txtNandSource.Text = Me.SelectFile("Binary Files (*.bin)|*.bin")
        If String.IsNullOrEmpty(Me.txtNandSource.Text) Then
            setLoadingProgressBar(False)
            Return
        Else
            Me.rtbLog.Text &= vbNewLine & "Intializing Nand.."

            Dim temp As String = getConsoleName(txtNandSource.Text, strCB_A)
            If temp = "error" Then
                Me.rtbLog.Text &= vbNewLine & "Unknown nand file !"
                MessageBox.Show("Sorry, the file seems to be not in the appropriate format! Please select nand files only!", "Unknown Nand", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                setLoadingProgressBar(False)
                Return
            End If
            'TextBox2.Text = temp
            If temp = "RGH 1.0" Then
                radRGH.Checked = True
            Else
                radRGH2.Checked = True
            End If
            'TextBox4.Text = getMBType()
            'TextBox5.Text = getJasperMem(Me.FilePathOneTextBox.Text)

            'btnCheckKV.PerformClick()
            'btnCheckUpdateVersions.PerformClick()

            setLoadingProgressBar(False)
        End If
    End Sub

    Private Function getConsoleName(ByVal strFile As String, ByRef strCB As String) As String
        Try

            Dim strName As String = String.Empty
            Const intSeek As Integer = &H8402
            Dim br As New BinaryReader(System.IO.File.Open(strFile, FileMode.Open))
            br.BaseStream.Seek(intSeek, SeekOrigin.Begin)
            Dim bytRead() As Byte = br.ReadBytes(2)

            Dim tmpByte As Byte
            tmpByte = bytRead(0)
            bytRead(0) = bytRead(1)
            bytRead(1) = tmpByte

            Dim intConsoleValue As UInt16
            intConsoleValue = BitConverter.ToUInt16(bytRead, 0)
            strCB = intConsoleValue.ToString

            Select Case intConsoleValue
                Case 1923, 1940, 4578, 4579, 5771, 6750, 6751, 7375, 9230
                    strName = "RGH 1.0"
                Case 4577, 5772, 6752, 9188, 13121, 4575, 5773, 6753, 13180
                    strName = "RGH 2.0"

            End Select
            br.Close()
            Return strName
        Catch ex As Exception
            Return "error"
        End Try


    End Function

    Private Function SelectFile(Optional ByVal strFilter As String = "All Files(*.*)|*.*", Optional ByVal strMsg As String = "Please select the nand file first!", Optional ByVal strTitle As String = "Nand file ?") As String
        Dim theOpenFileDialog As New OpenFileDialog
        theOpenFileDialog.Filter = strFilter
        If theOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim theFilePath As String = theOpenFileDialog.FileName
            If IO.File.Exists(theFilePath) Then
                Return theFilePath
            End If
        End If
        playAlertSound()
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return ""
    End Function

    Private Sub btnBrowseAdditional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseAdditional.Click
        setLoadingProgressBar()

        Me.txtNandAdditional.Text = Me.SelectFile("Binary Files (*.bin)|*.bin")
        If String.IsNullOrEmpty(Me.txtNandAdditional.Text) Then
            setLoadingProgressBar(False)
            Return
        Else
            Me.rtbLog.Text &= vbNewLine & "Intializing additional Nand...."
            setLoadingProgressBar(False)
        End If
    End Sub

    '--------------------------------------- COMPARE NANDS -------------------------------------
#Region "Compare Nands"
    '~~~ Button to compare the two nands!
    Private Sub btnCompareNands_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompareNands.Click

        If String.IsNullOrEmpty(Me.txtNandSource.Text) OrElse String.IsNullOrEmpty(Me.txtNandAdditional.Text) Then
            playAlertSound()
            MessageBox.Show("Please select two nand files first!", "Nand files ?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            setLoadingProgressBar()
            Me.rtbLog.Text &= vbNewLine & "Comparing files...."
            Dim strTemp As String = Me.txtNandSource.Text.Trim & "*" & Me.txtNandAdditional.Text.Trim
            bgworkerCompareNands.RunWorkerAsync(strTemp)

        End If
    End Sub


    Private Sub bgworkerCompareNands_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgworkerCompareNands.DoWork
        Dim strstr As String = DirectCast(e.Argument, String)
        Dim strTemp As String() = strstr.Split("*"c)
        Dim filePathOne As String = strTemp(0)
        Dim filePathTwo As String = strTemp(1)

        Dim fileOneByte As Integer
        Dim fileTwoByte As Integer

        Dim fileOneStream As FileStream
        Dim fileTwoStream As FileStream

        ' If user has selected the same file as file one and file two....
        If filePathOne = filePathTwo Then
            ' Files are the same.
            e.Result = "1" 'vbNewLine & "Files are the same; File one is file two."
        Else

            ' Open a FileStream for each file.
            fileOneStream = New FileStream(filePathOne, FileMode.Open)
            fileTwoStream = New FileStream(filePathTwo, FileMode.Open)

            ' If the files are not the same length...
            If (fileOneStream.Length <> fileTwoStream.Length) Then
                fileOneStream.Close()
                fileTwoStream.Close()
                ' File's are not equal.
                'My.Computer.Audio.Play(My.Resources.attention, AudioPlayMode.Background)
                playAlertSound()
                e.Result = "2" 'vbNewLine & "Files are not the same length; They are not equal."

            Else

                Dim areFilesEqual As Boolean = True

                ' Loop through bytes in the files until
                '  a byte in file one <> a byte in file two
                ' OR
                '  end of the file one is reached.
                Do
                    ' Read one byte from each file.
                    fileOneByte = fileOneStream.ReadByte()
                    fileTwoByte = fileTwoStream.ReadByte()

                    If fileOneByte <> fileTwoByte Then
                        ' Files are not equal; byte in file one <> byte in file two.
                        'My.Computer.Audio.Play(My.Resources.attention, AudioPlayMode.Background)
                        'Me.ResultsRichTextBox.Text &= vbNewLine & "Files are not equal; Contents are different."
                        areFilesEqual = False
                        Exit Do
                    End If

                Loop While (fileOneByte <> -1)

                ' Close the FileStreams.
                fileOneStream.Close()
                fileTwoStream.Close()

                If areFilesEqual Then
                    playAlertSound("COMPLETE")
                    e.Result = "3" 'vbNewLine & "Files are equal; Contents are same."
                Else
                    playAlertSound()
                    e.Result = "4" 'vbNewLine & "Files are not equal; Contents are different."
                End If

            End If
        End If


    End Sub

    Private Sub bgworkerCompareNands_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgworkerCompareNands.RunWorkerCompleted
        setLoadingProgressBar(False)
        Dim strTemp As String = DirectCast(e.Result, String)
        If strTemp = "1" Then
            rtbLog.Text &= vbNewLine & vbNewLine & "Files are the same; File one is file two."
        ElseIf strTemp = "2" Then
            rtbLog.Text &= vbNewLine & vbNewLine & "Files are not the same length; They are not equal."
        ElseIf strTemp = "3" Then
            rtbLog.Text &= vbNewLine & vbNewLine & "Files are equal; Contents are same."
        ElseIf strTemp = "4" Then
            rtbLog.Text &= vbNewLine & vbNewLine & "Files are not equal; Contents are different."
        End If


        If bolIsComparingAfter2Reads Then
            bolIsComparingAfter2Reads = False
            If strTemp = "2" Or strTemp = "4" Then
                rtbLog.Text &= "The nands are not the same! Maybe it's corrupted."
                If MessageBox.Show("The nands are not the same! Maybe it's corrupted. Do you want to read it again ?", "Read again?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                    frmDumpNand.ComboBox1.SelectedIndex = 1
                    frmDumpNand.Show()
                End If
            End If
        End If
    End Sub

#End Region
    '--------------------------------------- /COMPARE NANDS -------------------------------------

    Private Sub btnClearLogWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLogWindow.Click
        rtbLog.Clear()
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
    End Sub

    Private Sub btnNandDebugLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNandDebugLog.Click
        If My.Computer.FileSystem.FileExists(APP_PATH & "\nandpro\DebugLog.txt") Then
            Dim objreader As New System.IO.StreamReader(strPathToFile)
            rtbLog.Text &= vbNewLine & objreader.ReadToEnd
            objreader.Close()
        Else
            playAlertSound("PROBLEM")
            MessageBox.Show("Debug log file missing from nandpro folder!", "Debug Log ?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        APP_PATH = Application.StartupPath & "\x360rgh"
        strPathToFile = APP_PATH & "\nandpro\DebugLog.txt"
        cboNandProVer.SelectedIndex = 0
    End Sub

    Private Sub btnDetectMB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetectMB.Click
        'clearConsoleTextBoxes()
        If deviceDetected() Then
            Threading.Thread.Sleep(1000)
            getFlashConfig()
            txtConsoleDetected.Text = detectMBType()
            rtbLog.Text &= vbNewLine & "Motherboard Type: " & txtConsoleDetected.Text
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub

    Private Function detectMBType() As String
        Dim strName As String = String.Empty
        Const intSeek As Integer = &H8402
        Dim br As New BinaryReader(System.IO.File.Open(APP_PATH & "\nandpro\detect.bin", FileMode.Open))
        br.BaseStream.Seek(intSeek, SeekOrigin.Begin)
        Dim bytRead() As Byte = br.ReadBytes(2)
        br = Nothing 'br.Dispose()
        Dim tmpByte As Byte
        tmpByte = bytRead(0)
        bytRead(0) = bytRead(1)
        bytRead(1) = tmpByte

        Dim intConsoleValue As UInt16
        intConsoleValue = BitConverter.ToUInt16(bytRead, 0)
        Return getMBType(intConsoleValue)
    End Function

    Private Function getMBType(Optional ByVal intVal As Integer = -1) As String
        'If intVal = -1 Then
        '    intVal = Integer.Parse(TextBox3.Text)
        'End If

        Select Case intVal
            Case 1888, 1902, 1903, 1920, 1921, 1923, 1940, 7375
                Return "Xenon"
            Case 4558, 4571, 4575, 4577, 4578, 4579, 4580
                Return "Zephyr"
            Case 5761, 4766, 5770, 5771, 5772, 5773
                Return "Falcon / Opus"
            Case 6712, 6723, 6750, 6751, 6753
                Return "Jasper"
            Case 9188, 9230
                Return "Trinity"
            Case 13121, 13180
                Return "Corona"
        End Select
        Return ""
    End Function

    Public Function deviceDetected() As Boolean
        Try
            If My.Computer.FileSystem.FileExists(APP_PATH & "\nandpro\" & selectedNandProdEXE) Then
                Dim detectnand1block As New Process

                detectnand1block.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
                detectnand1block.StartInfo.FileName = selectedNandProdEXE '"nandpro"
                detectnand1block.StartInfo.Arguments = gUSBrLPT & ": -r16 Detect.bin 0 3"
                ' Hide cmd command prompt window
                detectnand1block.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                detectnand1block.Start()

                detectnand1block.WaitForExit()

                Dim strTemp As String = System.IO.File.ReadAllText(strPathToFile)
                rtbLog.Text &= vbNewLine & strTemp
                If strTemp.Contains("No device found") Then
                    playAlertSound()
                    rtbLog.Text &= vbNewLine & "Please check your connections and programmer & Try Again!"
                    Return False
                Else
                    Return True
                End If

            Else
                playAlertSound("PROBLEM")
                MessageBox.Show("Nandpro file not found.!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Catch ee As Exception
            rtbLog.Text &= vbNewLine & "Could not continue because: " & ee.Message
            Return False
        End Try
    End Function

    Private Sub cboNandProVer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNandProVer.SelectedIndexChanged
        Select Case cboNandProVer.SelectedItem.ToString
            Case "2.0e"
                selectedNandProdEXE = "nandpro.exe"
            Case "2.0b"
                selectedNandProdEXE = "nandpro20b.exe"
            Case "3.0a"
                selectedNandProdEXE = "nandpro30a.exe"
                MessageBox.Show("NandPro3.0a currently does not have support for Corona16MB, if you have a Corona xbox360 Then use NandPro2.0b", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Select
    End Sub

    Private Sub getFlashConfig()

        Dim strContent As String = System.IO.File.ReadAllText(strPathToFile)    '~~~ read the contents of the file
        Dim regex As Regex = New Regex("Config:(.*)\b")
        Dim match As Match = regex.Match(strContent)
        If match.Success Then   '~~~ if a match is found..
            txtFlashConfig.Text = match.Value.Split(":")(1).Trim    '~~~ ...display the corresponding value belonging to that FlashConfig value, in the textbox
        End If
    End Sub

    Private Sub btnOfflineFuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOfflineFuse.Click
        startFetchingKey(True)
    End Sub

    Private Sub btnGetCPUkey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCPUkey.Click
        Dim m As Match = Regex.Match(txtIP.Text, "\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")
        If m.Success Then
            startFetchingKey()
        Else
            playAlertSound()
            MessageBox.Show("Please enter a valid IP address", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub startFetchingKey(Optional ByVal bolOffline As Boolean = False)

        ' this section parse the txt file for cpu key

        '~~~ When button is clicked..


        txtCPUkey.Text = ""    '~~~ set key textbox to nothing

        Dim strAddress As String
        If bolOffline = False Then
            Me.rtbLog.Text &= vbNewLine & " Launching xell browser to get your cpu key"
            '~~~ creating the url using the IP address

            strAddress = "http://" & txtIP.Text & "/FUSE"
            setLoadingProgressBar()

            If bgworkerGetKey.IsBusy Then
                bgworkerGetKey.CancelAsync()
            End If
            bgworkerGetKey.RunWorkerAsync(strAddress)
        Else
            Me.rtbLog.Text &= vbNewLine & " Reading fuse file offline to get your cpu key"
            strAddress = Me.SelectFile("Fuse File (*.txt)|*.txt", "Please select a fuse file!", "Fuse file ?")
            If String.IsNullOrEmpty(strAddress) Then

                Me.rtbLog.Text &= vbNewLine & " Decrypting failed because fuse file was not selected!"
            Else
                setLoadingProgressBar()

                If bgworkerGetKey.IsBusy Then
                    bgworkerGetKey.CancelAsync()
                End If
                bgworkerGetKey.RunWorkerAsync(strAddress)
            End If

        End If
    End Sub

    Private Sub bgworkerGetKey_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgworkerGetKey.DoWork
        Dim strAddress As String = DirectCast(e.Argument, String)

        Try
            Dim strFile As String
            Dim strLines() As String
            If strAddress.StartsWith("http") Then
                '~~~ Reading the contents from the file...
                Dim objNewRequest As WebRequest = HttpWebRequest.Create(strAddress)
                Dim objResponse As WebResponse = objNewRequest.GetResponse

                Using objStream As New IO.StreamReader(objResponse.GetResponseStream())
                    strFile = objStream.ReadToEnd() '~~~ strFile will contain the file content
                End Using

            Else
                strFile = System.IO.File.ReadAllText(strAddress)
                Debug.Print(strFile)
            End If

            strLines = strFile.Split(vbLf)  '~~~ split the content into lines

            Dim intCount As Integer = 0
            For Each strLine As String In strLines
                If strLine.StartsWith("fuse") Then
                    intCount += 1
                End If
            Next

            If intCount <> 12 Then
                e.Result = "XXX"
            Else


                Dim fuse1 As Int64, fuse2 As Int64, fuse3 As Int64, fuse4 As Int64  '~~~ declare the variables

                '~~~ loop through each of the lines
                For Each strLine As String In strLines
                    '~~~ 03,04,05 & 06's values are extracted and assigned to variables
                    If strLine.StartsWith("fuseset 03:") Then
                        fuse1 = Int64.Parse(strLine.Remove(0, 11), Globalization.NumberStyles.HexNumber)
                    ElseIf strLine.StartsWith("fuseset 04:") Then
                        fuse2 = Int64.Parse(strLine.Remove(0, 11), Globalization.NumberStyles.HexNumber)
                    ElseIf strLine.StartsWith("fuseset 05:") Then
                        fuse3 = Int64.Parse(strLine.Remove(0, 11), Globalization.NumberStyles.HexNumber)
                    ElseIf strLine.StartsWith("fuseset 06:") Then
                        fuse4 = Int64.Parse(strLine.Remove(0, 11), Globalization.NumberStyles.HexNumber)
                    End If
                Next

                '~~~ ORing the each pair of values and appended as a string
                Dim strResult As String = (fuse1 Or fuse2).ToString("X16") & (fuse3 Or fuse4).ToString("X16")

                '~~~ Display it

                e.Result = strResult
            End If
        Catch ee As WebException
            e.Result = "error"
            e.Cancel = True
        End Try
    End Sub

    Private Sub bgworkerGetKey_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgworkerGetKey.RunWorkerCompleted
        setLoadingProgressBar(False)

        If e.Cancelled = True Then
            playAlertSound()
            Me.rtbLog.Text &= vbNewLine & "ERROR: Connection Failed!"
            If intRepeatCount < 2 Then
                intRepeatCount += 1
                rtbLog.Text &= vbNewLine & "Xell not found" & vbNewLine & "Retrying in 2 seconds.."
                tmrRestartGetKey.Start()
            Else
                rtbLog.Text &= vbNewLine & "Failed to find Xell in all " & (intRepeatCount + 1).ToString & " attempts! Please try again later after verifying your network connection!"
            End If

        Else
            Dim strOutput As String = DirectCast(e.Result, String)
            If strOutput = "XXX" Then
                Me.rtbLog.Text &= vbNewLine & "Incorrect fuse file!"
                MessageBox.Show("Fuse file that you have selected is of incorrect format!", "Incorrect Fuse File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCPUkey.Text = ""
            Else
                Me.rtbLog.Text &= vbNewLine & "Successfully generated the CPU key"
                txtCPUkey.Text = DirectCast(e.Result, String)
            End If
        End If

    End Sub

    Private Sub btn4GBrw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4GBrw.Click
        frm4grw.Show()
    End Sub

    Private Sub btnMonitorCOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitorCOM.Click
        Dim fi As IO.FileInfo = New IO.FileInfo(APP_PATH & "\temp\common.exe")

        If Not Directory.Exists(APP_PATH & "\temp") Then
            Directory.CreateDirectory(APP_PATH & "\temp")
        End If

        If (Not fi.Exists) OrElse (fi.Length = 0) Then
            Dim fromexe As IO.Stream = Reflection.Assembly.GetEntryAssembly.GetManifestResourceStream(String.Format("{0}.{1}", "X360RGHV3", "common.exe"))
            SaveStreamToFile(fromexe, APP_PATH & "\temp\common.exe")
        End If



        If procComMonitor Is Nothing Then
            procComMonitor = New Process
            procComMonitor.StartInfo.FileName = APP_PATH & "\temp\common.exe"
            procComMonitor.Start()
        Else
            If Not procComMonitor.HasExited Then
                MessageBox.Show("Com Monitor is already running!", "Already running!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                procComMonitor = New Process
                procComMonitor.StartInfo.FileName = APP_PATH & "\temp\common.exe"
                procComMonitor.Start()
            End If
        End If

    End Sub


#Region "KV Info"

    Private Sub btnCheckKV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckKV.Click

        If txtNandSource.Text.Trim.Length = 0 Then
            MessageBox.Show("Please select a nand first!", "Nand?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        currserial.Text = ""
        currmfr.Text = ""
        currosig.Text = ""
        currdvdkey.Text = ""
        currcid.Text = ""
        currregion.Text = ""
        objNand.getkv_smc(txtNandSource.Text)
        frmMain.kv = objCrypt.DecryptKV(frmMain.enckv, txtCPUkey.Text)
        If (Not objCrypt.kvcheck(frmMain.kv, txtCPUkey.Text)) Then

            MessageBox.Show("ERROR: Unable to decrypt kv! etheir it's corrupt or the CPUKey you supplied is incorrect!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            fcrtreq.Font = New Font(fcrtreq.Font, FontStyle.Regular)
            fcrtreq.ForeColor = Color.Black
            fcrtreq.Text = "UNK"
            currcid.Text = "ERROR"
            currdvdkey.Text = "ERROR"
            currmfr.Text = "ERROR"
            currosig.Text = "ERROR"
            currregion.Text = "ERROR"
            currserial.Text = "ERROR"

        Else

            Dim kvinf As String() = getkvinfo()
            currserial.Text = kvinf(0)
            currregion.Text = kvinf(1)
            currdvdkey.Text = kvinf(2)
            currcid.Text = kvinf(3)
            currmfr.Text = kvinf(4)
            currosig.Text = kvinf(5)
            fcrtreq.Text = kvinf(6)
            If objMisc.swap16(BitConverter.ToUInt16(frmMain.kv, &H1C)) = &HF0 Then
                fcrtreq.ForeColor = Color.Red
            Else
                fcrtreq.ForeColor = Color.Green
            End If
            fcrtreq.Font = New Font(fcrtreq.Font, FontStyle.Bold)

        End If

    End Sub

    Public Function getkvinfo() As String()
        Dim objNand As New DGXapp.NandOP
        Dim objCrypt As New DGXapp.crypto
        Dim objMisc As New DGXapp.Misc

        Dim ret As String() = New String(6) {}
        Dim serialbytes As Byte() = New Byte(15) {}
        Dim mfrbytes As Byte() = New Byte(7) {}
        Dim osigbytes As Byte() = New Byte(27) {}
        Dim t As Integer = 0
        For i As Integer = 0 To frmMain.kv.Length - 1
            '#Region "Serial"
            If (i > 175) AndAlso (i < 192) Then
                serialbytes(t) = frmMain.kv(i)
                t += 1
                If i = 191 Then
                    ret(0) = Encoding.ASCII.GetString(serialbytes)
                    t = 0
                End If
                '#End Region
                '#Region "Region"
            ElseIf (i > 199) AndAlso (i < 202) Then
                If t = 0 Then
                    ret(1) = "0x"
                    ret(1) += frmMain.kv(i).ToString("X2")
                Else
                    ret(1) += frmMain.kv(i).ToString("X2")
                    ret(1) = objMisc.translateregion(ret(1)) + " (" + ret(1) + ")"
                End If
                t += 1
                If t = 201 Then
                    t = 0
                End If
                '#End Region
                '#Region "DVDKey"
            ElseIf (i > 255) AndAlso (i < 272) Then
                If t = 0 Then
                    ret(2) = frmMain.kv(i).ToString("X2")
                Else
                    ret(2) += frmMain.kv(i).ToString("X2")
                End If
                t += 1
                If i = 271 Then
                    t = 0
                End If
                '#End Region
                '#Region "Console ID"
            ElseIf (i > 2505) AndAlso (i < 2511) Then
                If t = 0 Then
                    ret(3) = frmMain.kv(i).ToString("X2")
                Else
                    ret(3) += frmMain.kv(i).ToString("X2")
                End If
                t += 1
                If i = 2510 Then
                    t = 0
                End If
                '#End Region
                '#Region "MFR-Date"
            ElseIf (i > 2531) AndAlso (i < 2540) Then
                mfrbytes(t) = frmMain.kv(i)
                t += 1
                If i = 2539 Then
                    If Regex.IsMatch(Encoding.ASCII.GetString(mfrbytes), "^[0-9]{2}-[0-9]{2}-[0-9]{2}$") Then
                        Dim splitdate As String() = Encoding.ASCII.GetString(mfrbytes).Split("-"c)
                        ret(4) = splitdate(1) + "-" + splitdate(0) + "-" + splitdate(2)
                    End If
                    t = 0
                End If
                '#End Region
                '#Region "OSIG String"
            ElseIf (i > 3217) AndAlso (i < 3246) Then
                osigbytes(t) = frmMain.kv(i)
                t += 1
                If i = 3245 Then
                    ret(5) = Encoding.ASCII.GetString(osigbytes)
                    t = 0
                    i = frmMain.kv.Length
                End If
                '#End Region
            End If
        Next
        ret(6) = (objMisc.swap16(BitConverter.ToUInt16(frmMain.kv, &H1C)) = &HF0).ToString()
        For i As Integer = 0 To ret.Length - 1
            Try
                ret(i) = ret(i).Substring(0, ret(i).IndexOf(vbNullChar))
            Catch
            End Try
            If ret(i) IsNot Nothing Then
                ret(i) = ret(i).Trim()
            End If
        Next
        Return ret
    End Function

#End Region


#Region "nand_info tab"
    Private Sub btnCheckUpdateVersions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckUpdateVersions.Click
        If txtNandSource.Text.Trim.Length = 0 Then Return

        txt1BLkey.Text = txt1BLkey.Text.Trim

        cb_a.Text = "N/A"
        cba_ldvbox.Text = "N/A"
        cba_pairingbox.Text = "N/A"
        cb_b.Text = "N/A"
        cbb_ldvbox.Text = "N/A"
        cbb_pairingbox.Text = "N/A"
        cd.Text = "N/A"
        ce.Text = "N/A"
        cf0.Text = "N/A"
        cf0_ldvbox.Text = "N/A"
        cf0_pairingbox.Text = "N/A"
        cf0offset.Text = "N/A"
        cf1.Text = "N/A"
        cf1_ldvbox.Text = "N/A"
        cf1_pairingbox.Text = "N/A"
        cf1offset.Text = "N/A"
        slots.Text = "N/A"
        If File.Exists(txtNandSource.Text) Then
            Dim file__1 As String = txtNandSource.Text
            Dim ret As Integer() = objNand.getbootloaderversions(file__1)
            If ret(0) > 1 Then
                cb_a.Text = ret(0).ToString()
            Else
                cb_a.Text = "N/A"
            End If
            If ret(1) > 1 Then
                cb_b.Text = ret(1).ToString()
            Else
                cb_b.Text = "N/A"
            End If
            If ret(2) > 1 Then
                cd.Text = ret(2).ToString()
            Else
                cd.Text = "N/A"
            End If
            If ret(3) > 1 Then
                ce.Text = ret(3).ToString()
            Else
                ce.Text = "N/A"
            End If
            If ret(4) > 1 Then
                cf0.Text = ret(4).ToString()
            Else
                cf0.Text = "N/A"
            End If
            If ret(5) > 1 Then
                cg0.Text = ret(5).ToString()
            Else
                cg0.Text = "N/A"
            End If
            If ret(6) > 1 Then
                cf1.Text = ret(6).ToString()
            Else
                cf1.Text = "N/A"
            End If
            If ret(7) > 1 Then
                cg1.Text = ret(7).ToString()
            Else
                cg1.Text = "N/A"
            End If
            If ret(8) > 0 Then
                cf0offset.Text = "0x" + ret(8).ToString("X")
            Else
                cf0offset.Text = "N/A"
            End If
            If ret(9) > 0 Then
                slots.Text = ret(9).ToString()
            Else
                slots.Text = "N/A"
            End If
            If ret(10) > 0 Then
                cf1offset.Text = "0x" + (ret(8) + ret(10)).ToString("X")
            Else
                cf1offset.Text = "N/A"
            End If
            '#Region "CB/CB_B LDV and Pairing"
            '#Region "CB LDV/Pairing"
            If (ret(0) > 1) AndAlso (ret(1) = 0) Then
                Dim data As Byte() = objNand.getcba(file__1)
                data = objCrypt.DecryptCB(data, objMisc.cpukeytoarray(txt1BLkey.Text), Nothing)
                If objCrypt.blcheck(data, &H270, &H120) Then
                    cba_pairingbox.Text = "0x" + data(&H22).ToString("X2")
                    cba_pairingbox.Text += data(&H21).ToString("X2")
                    cba_pairingbox.Text += data(&H20).ToString("X2")
                    cba_ldvbox.Text = CInt(data(&H23)).ToString()
                    cbb_ldvbox.Text = ""
                    cbb_pairingbox.Text = ""
                Else
                    cba_ldvbox.Text = "N/A"
                    cba_pairingbox.Text = "N/A"
                    cbb_ldvbox.Text = "N/A"
                    cbb_pairingbox.Text = "N/A"
                End If
                '#End Region
                '#Region "CB_B LDV/Pairing"
            ElseIf ret(1) > 1 Then
                If txtCPUkey.Text.Length = 32 Then
                    Dim data_a As Byte() = objNand.getcba(file__1)
                    data_a = objCrypt.DecryptCB(data_a, objMisc.cpukeytoarray(txt1BLkey.Text), Nothing)
                    If objCrypt.blcheck(data_a, &H270, &H120) Then
                        Dim data As Byte() = objNand.getcbb(file__1, &H8000 + data_a.Length)
                        data = objCrypt.DecryptCB(data, objMisc.cpukeytoarray(txtCPUkey.Text), data_a)
                        If objCrypt.blcheck(data, &H270, &H120) Then
                            cbb_pairingbox.Text = "0x" + data(&H22).ToString("X2")
                            cbb_pairingbox.Text += data(&H21).ToString("X2")
                            cbb_pairingbox.Text += data(&H20).ToString("X2")
                            cbb_ldvbox.Text = CInt(data(&H23)).ToString()
                            cba_ldvbox.Text = ""
                            cba_pairingbox.Text = ""
                        Else
                            cba_ldvbox.Text = "N/A"
                            cba_pairingbox.Text = "N/A"
                            cbb_ldvbox.Text = "N/A"
                            cbb_pairingbox.Text = "N/A"
                        End If
                    Else
                        cba_ldvbox.Text = "N/A"
                        cba_pairingbox.Text = "N/A"
                        cbb_ldvbox.Text = "N/A"
                        cbb_pairingbox.Text = "N/A"
                    End If
                Else
                    cba_ldvbox.Text = "N/A"
                    cba_pairingbox.Text = "N/A"
                    cbb_ldvbox.Text = "N/A"
                    cbb_pairingbox.Text = "N/A"
                End If
            End If
            '#End Region
            '#End Region
            '#Region "CF Slot 0 and Slot 1 LDV and Pairing"
            If ret(4) > 1 Then
                '#Region "CF Slot 0 LDV/Pairing"
                Dim data As Byte() = objNand.getcf(file__1, ret(8))
                If data.Length > 1 Then
                    data = objCrypt.DecryptCF(data, objMisc.cpukeytoarray(txt1BLkey.Text))
                    If objCrypt.blcheck(data, &H1F0, &H20) Then
                        cf0_pairingbox.Text = "0x" + data(&H21E).ToString("X2")
                        cf0_pairingbox.Text += data(&H21D).ToString("X2")
                        cf0_pairingbox.Text += data(&H21C).ToString("X2")
                        cf0_ldvbox.Text = CInt(data(&H21F)).ToString()
                        cf1_pairingbox.Text = ""
                        cf1_ldvbox.Text = ""
                    Else
                        cf0_pairingbox.Text = "N/A"
                        cf0_ldvbox.Text = "N/A"
                        cf1_ldvbox.Text = "N/A"
                        cf1_pairingbox.Text = "N/A"
                    End If
                Else
                    cf0_pairingbox.Text = "N/A"
                    cf0_ldvbox.Text = "N/A"
                    cf1_ldvbox.Text = "N/A"
                    cf1_pairingbox.Text = "N/A"
                End If
                '#End Region
                '#Region "CF Slot 1 LDV/Pairing"
                If ret(6) > 1 Then
                    data = objNand.getcf(file__1, ret(8) + ret(10))
                    If data.Length > 1 Then
                        data = objCrypt.DecryptCF(data, objMisc.cpukeytoarray(txt1BLkey.Text))
                        If objCrypt.blcheck(data, &H1F0, &H20) Then
                            cf1_pairingbox.Text = "0x" + data(&H21E).ToString("X2")
                            cf1_pairingbox.Text += data(&H21D).ToString("X2")
                            cf1_pairingbox.Text += data(&H21C).ToString("X2")
                            cf1_ldvbox.Text = CInt(data(&H21F)).ToString()
                        Else
                            cf1_ldvbox.Text = "N/A"
                            cf1_pairingbox.Text = "N/A"
                        End If
                    Else
                        cf1_ldvbox.Text = "N/A"
                        cf1_pairingbox.Text = "N/A"
                    End If
                Else
                    cf1_ldvbox.Text = "N/A"
                    cf1_pairingbox.Text = "N/A"
                    '#End Region
                End If
            End If
            '#End Region

            '~~~~ Motherboard Info
            'Main.nand.getkv_smc(file__1)
            'Main.smc = Main.crypt.DecryptSMC(Main.encsmc)
            'mobo.Text = Main.test.cbtranslate(ret(0), file__1)
            'smct.Text = Main.test.smctype(Main.smc)
            'Main.nand.savesmc(Main.dir + "\files\temp\", Main.smc)
            'Dim patches As String() = Main.test.patchcheck(Main.dir + "\files\temp\smc.bin")
            'tms.Text = patches(1)
            'tdi.Text = patches(2)
            'If String.IsNullOrEmpty(patches(3)) Then
            '    smcv.Text = "N/A"
            'Else
            '    smcv.Text = patches(3)
            'End If

        Else
            MessageBox.Show("ERROR: Can't check versions since the file you've selected don't exist!", "ERROR - File don't exist", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If


    End Sub
#End Region

    Private Sub btnWriteNand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteNand.Click
        If deviceDetected() Then
            frmWriteNand.Show()
        Else
            playAlertSound("")
            rtbLog.Text &= vbNewLine & "Write Nand failed !"

        End If
    End Sub

#Region "CreateECC"
    Private Sub btnCreateECC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateECC.Click

        If txtNandSource.Text.Trim.Length = 0 Then
            playAlertSound()
            MessageBox.Show("Please selected the nand file first!", "Nand file ?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Dim FileToCopy As String
        Dim NewCopy As String

        'FileToCopy =  APP_PATH & "\nandpro\nand1.bin"
        FileToCopy = txtNandSource.Text.Trim
        NewCopy = APP_PATH & "\xell\nand1.bin"

        '~~~ Check whether the original file exists...
        If Not System.IO.File.Exists(FileToCopy) Then
            playAlertSound()
            rtbLog.Text &= vbLf & "Original nand file missing you must copy over."
            Exit Sub
        Else    '~~~ ...if exists

            If System.IO.File.Exists(NewCopy) Then
                System.IO.File.Delete(NewCopy)
            End If

            If Not System.IO.Directory.Exists(APP_PATH & "\xell\") Then
                playAlertSound("PROBLEM")
                MessageBox.Show("Output directory not found !", "Directory Not Found!")
                Exit Sub
            End If
            System.IO.File.Copy(FileToCopy, NewCopy) '~~~ if file exists in "xell"

            rtbLog.Text &= vbLf & "Nandpro... Nand to ecc directory successfully copied."

        End If


        rtbLog.Text &= vbLf & "Original nand found to process ecc"
        rtbLog.Text &= vbLf & "Please wait for a few moments while the ecc is being created."
        rtbLog.Update()

        setLoadingProgressBar()

        bgworkerCreateECC.RunWorkerAsync(radRGH.Checked)

    End Sub


    Private Sub bgworkerCreateECC_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgworkerCreateECC.DoWork
        '~~~ starting our process
        Dim eccbuild As New Process
        Dim strOutputProcess As String = String.Empty
        Dim worker As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        Dim isRadChecked As Boolean = DirectCast(e.Argument, Boolean)
        ' output to text window

        eccbuild.StartInfo.UseShellExecute = False
        eccbuild.StartInfo.RedirectStandardOutput = True
        eccbuild.StartInfo.RedirectStandardError = True
        Try
            eccbuild.StartInfo.CreateNoWindow = True

            eccbuild.StartInfo.WorkingDirectory = APP_PATH & "\xell"
            eccbuild.StartInfo.FileName = APP_PATH & "\xell\python"
            Dim param As String = "build" '"build.py nand1.bin "
            If strCB_A = "9230" Then
                param &= ".py nand1.bin "

                worker.ReportProgress(50, "Using build.py for RGH ...")
            Else

                If isRadChecked Then
                    param &= ".py nand1.bin "
                    'eccbuild.StartInfo.Arguments = "build.py nand1.bin "
                    'If (...) Then
                    '    eccbuild.StartInfo.Arguments += " "
                    'End If
                    'eccbuild.StartInfo.Arguments += "CD xell-gggggg.bin"
                    worker.ReportProgress(50, "Using build.py for RGH ...")
                Else
                    'eccbuild.StartInfo.Arguments = "build2.py nand1.bin CD xell-gggggg.bin"
                    param &= "2.py nand1.bin "
                    worker.ReportProgress(50, "Using build2.py for RGH 2 ...")
                End If
            End If
            Select Case strCB_A
                Case "6751"
                    'param &= "cb\\cb_6750.bin "
                    param &= "..\\common\\cb_6750.bin "
                Case "9230"
                    'param &= "cb\\cba_9188.bin cb\\cbb_9188.bin cb\\cbb_9230.bin "
                    param &= "..\\common\\cba_9188.bin cb\\cbb_9188.bin cb\\cbb_9230.bin "

                Case "1940", "1932"
                    If MessageBox.Show("Do you want to use CB 7375 instead of your current one ? (you have 1940). It may be faster to glitch using 7375 rather than " & strCB_A & "...", "Use CB 7375 instead ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'param &= "cb\\cba_7375.bin "
                        param &= "..\\common\\cba_7375.bin "
                    End If
            End Select
            If strCB_A = "6751" Then
                'param &= "cd\\CDjasper xell-gggggg.bin"
                param &= "..\\common\\CDjasper xell-gggggg.bin"
            ElseIf isRadChecked Then
                'param &= "cd\\CD xell-gggggg.bin"
                param &= "..\\common\\CD xell-gggggg.bin"
            Else
                'param &= "cd\\CD2 xell-gggggg.bin"
                param &= "..\\common\\CD2 xell-gggggg.bin"
            End If
            'build2.py nand1.bin cb\\cba_9188.bin cb\\cbb_9188.bin cb\\cbb_9230.bin cd\\CD2 xell-gggggg.bin
            eccbuild.StartInfo.Arguments = param

            eccbuild.Start()
            strOutputProcess = _
            Replace(eccbuild.StandardOutput.ReadToEnd(), _
                    Chr(13) & Chr(13), Chr(13))

            eccbuild.WaitForExit()
            worker.ReportProgress(100, strOutputProcess)
        Catch ex As Win32Exception


            worker.ReportProgress(0, ex.Message + ". Error Detected.")

        End Try
    End Sub

    Private Sub bgworkerCreateECC_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgworkerCreateECC.ProgressChanged
        Dim strOut As String = DirectCast(e.UserState, String)
        rtbLog.Text &= strOut
    End Sub

    Private Sub bgworkerCreateECC_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgworkerCreateECC.RunWorkerCompleted
        rtbLog.Text &= "Finished createing the ecc file!"
        setLoadingProgressBar(False)
    End Sub

#End Region

#Region "WriteECC"
    Private Sub btnWriteECC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteECC.Click
        If Not deviceDetected() Then
            rtbLog.Text &= vbNewLine & "Write ECC Failed!"
            Exit Sub
        End If
        System.Threading.Thread.Sleep(2000)
        'ecc copy from xell to nandpro

        Dim FileToCopy As String
        Dim NewCopy As String

        FileToCopy = APP_PATH & "\xell\output\image_00000000.ecc"
        NewCopy = APP_PATH & "\nandpro\image_00000000.ecc"

        If Not IO.File.Exists(FileToCopy) Then
            playAlertSound()
            MessageBox.Show("image_00000000.ecc file was not found!", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            rtbLog.Text &= vbNewLine & "Write ECC failed because of missing file: image_00000000.ecc"
            Exit Sub
        End If

        rtbLog.Text &= vbNewLine & "Copying image.."
        If IO.File.Exists(NewCopy) Then IO.File.Delete(NewCopy)
        System.IO.File.Copy(FileToCopy, NewCopy)

        If My.Computer.FileSystem.FileExists(NewCopy) Then
            rtbLog.Text &= vbNewLine & "Writing ecc back to Xbox360... Please wait for a few moments..."
            'else

            'ecc write

            setLoadingProgressBar()
            bgworkerWriteECC.RunWorkerAsync()
        Else
            rtbLog.Text &= vbNewLine & "Writing failed because of the absence of nandpro\image_00000000.ecc file..."
        End If
    End Sub


    Private Sub bgworkerWriteECC_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgworkerWriteECC.DoWork

        Dim eccwrite As New Process
        eccwrite.StartInfo.UseShellExecute = False
        eccwrite.StartInfo.RedirectStandardOutput = True
        eccwrite.StartInfo.RedirectStandardError = True

        eccwrite.StartInfo.CreateNoWindow = True
        eccwrite.StartInfo.WorkingDirectory = APP_PATH & "\nandpro"
        eccwrite.StartInfo.FileName = APP_PATH & "\nandpro\" & selectedNandProdEXE
        eccwrite.StartInfo.Arguments = gUSBrLPT & ": +w16 image_00000000.ecc "
        eccwrite.Start()
        Dim strOutputProcess As String = _
            Replace(eccwrite.StandardOutput.ReadToEnd(), _
                    Chr(13) & Chr(13), Chr(13))
        eccwrite.WaitForExit()
        e.Result = strOutputProcess
    End Sub

    Private Sub bgworkerWriteECC_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgworkerWriteECC.RunWorkerCompleted

        rtbLog.Text &= vbNewLine & DirectCast(e.Result, String)

        setLoadingProgressBar(False)

        rtbLog.Text &= vbNewLine & "Write modified ecc back to Xbox360" & vbNewLine & "Finished writing ECC to Xbox360!"
    End Sub
#End Region

    Private Sub btnDumpNand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDumpNand.Click
        txtFlashConfig.Clear()
        'txtMBtype.Clear()

        If Not deviceDetected() Then
            'ResultsRichTextBox.Text &= vbNewLine & "Read Nand failed !"
            MessageBox.Show("Read Nand failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        getFlashConfig()
        'txtName.Text = detectMBType()
        'ResultsRichTextBox.Text &= vbNewLine & "Motherboard Type: " & txtName.Text

        frmDumpNand.Show()
    End Sub

    Private Sub mnuScanXellIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuScanXellIP.Click
        frmIPscan.ShowDialog()
    End Sub

    Private Sub mnuAdvanceGUI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdvanceGUI.Click
        If System.IO.File.Exists(APP_PATH & "\xebuild\xeBuild GUI 2.0.exe") Then
            Process.Start(APP_PATH & "\xebuild\xeBuild GUI 2.0.exe")

        Else

            MessageBox.Show("Advance Build GUI was not found!", "Failed to load !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub tabcntrlBottom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabcntrlBottom.SelectedIndexChanged
        If tabcntrlBottom.SelectedIndex = 0 Then
            btnCheckUpdateVersions.PerformClick()
        End If
    End Sub


    Private Sub SaveStreamToFile(ByVal p_stream As IO.Stream, ByVal p_fileName As String)
        Dim l_streamWriter As System.IO.FileStream = System.IO.File.Create(p_fileName)

        Try
            Dim l_bytes(65536) As Byte
            Dim l_offset As Integer = 0
            Dim l_readBytes As Integer

            Do
                l_readBytes = p_stream.Read(l_bytes, 0, 65536)
                l_streamWriter.Write(l_bytes, 0, l_readBytes)

                l_offset += l_readBytes

            Loop While (l_readBytes > 0)
            'Debug.WriteLine("Num Of bytes Read: " + l_offset.ToString)

        Catch ex As Exception
            'log error
        Finally
            p_stream.Close()
            l_streamWriter.Close()
        End Try
    End Sub

    Private Sub rtbLog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbLog.TextChanged
        rtbLog.SelectionStart = rtbLog.TextLength
        rtbLog.ScrollToCaret()
    End Sub

    '~~~ compare nands after two nand reads are performed!
    Public Sub compareAfter2Reads()
        rtbLog.Text = "Comparing nands that was read in the two reads..."
        bolIsComparingAfter2Reads = True

        txtNandSource.Text = APP_PATH & "\nandpro\nand1.bin"
        txtNandAdditional.Text = APP_PATH & "\nandpro\nand2.bin"

        btnCompareNands.PerformClick()
    End Sub

    Private Sub btnBuildImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildImage.Click
        If txt1BLkey.Text.Trim.Length = 0 Then
            MessageBox.Show("1BL Key is a required field!", "Value missing!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt1BLkey.Focus()
        ElseIf txtCPUkey.Text.Trim.Length = 0 Then
            MessageBox.Show("CPY key is a required field!", "CPU key missing!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCPUkey.Focus()
        ElseIf cboDashVersions.SelectedIndex < 0 Then
            MessageBox.Show("Please select an appropriate dash version!", "Dash Version?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboDashVersions.Focus()
        Else

            frmBuildImage.Show()
        End If

    End Sub
End Class
