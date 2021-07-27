
Imports System
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Net.Sockets
Imports System.Windows.Forms
Imports System.Net.NetworkInformation



Public Class frmIPscan
    'Inherits Form
    Private cfgfile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Swizzy\xeBuild\ipscan.cfg"
    'Public Shared pbar As ProgressBarEx
    Public Shared status As TextBox
    Private Delegate Sub SetProgCallback(ByVal progress As Integer)
    Private Delegate Sub SetTextCallback(ByVal text As String())
    Private Delegate Sub SetStatCallback(ByVal status As String)
    Private testing As Thread
    Private success As Boolean = False, abort As Boolean = False
    Private baseip As String = "", currentip As String = ""
    Private startip As Integer = 0, limit As Integer = 0, prog As Integer = 0, i As Integer = 0, pinglimit As Integer = 200
    'Public Sub New()
    '    InitializeComponent()
    '    pbar = progbar
    '    status = statustxt
    'End Sub
    Private Sub setprog(ByVal progress As Integer)
        Try
            If progbar.InvokeRequired Then
                Dim d As New SetProgCallback(AddressOf setprog)
                progbar.Invoke(d, New Object() {progress})
            Else
                progbar.Value = progress
            End If
        Catch
            progbar.Value = progbar.Maximum
            progbar.ForeColor = System.Drawing.Color.Red
        End Try
    End Sub
    Private Sub settext(ByVal text As String())
        If frmMain.txtCPUkey.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf settext)
            frmMain.txtCPUkey.Invoke(d, New Object() {text})
            'ElseIf Main.mright.cfldv.InvokeRequired Then
            '    Dim d As New SetTextCallback(settext)
            '    Main.mright.cfldv.Invoke(d, New Object() {text})
        Else
            frmMain.txtCPUkey.Text = text(0)
            ' Main.mright.cfldv.Text = text(1)
        End If
    End Sub
    Private Sub setstatus(ByVal text As String)
        If statustxt.InvokeRequired Then
            Dim d As New SetStatCallback(AddressOf setstatus)
            statustxt.Invoke(d, New Object() {text})
        Else
            statustxt.Text = text
        End If
    End Sub
    Private Sub downloadfuse(ByVal ip As String)
        If Not IO.Directory.Exists(APP_PATH & "\temp") Then IO.Directory.CreateDirectory(APP_PATH & "\temp")
        Using client As New WebClient()
            Try
                setstatus("Trying to download fuse from: " & ip)
                client.DownloadFile("http://" & ip & "/FUSE", APP_PATH & "\files\temp\FUSE.txt")
                i = limit
                prog = limit - startip - 1
                success = True
                setstatus("Success! Found Xell on IP: " & ip)
            Catch
                success = False
            End Try

            If File.Exists(APP_PATH & "\temp\FUSE.txt") Then
                Dim cc As New CPUkey

                Dim ret As String() = cc.readfusefile(APP_PATH & "\temp\FUSE.txt")
                settext(ret)
                If Not String.IsNullOrEmpty(frmMain.txtNandSource.Text) Then
                    Try
                        File.Copy(APP_PATH & "\temp\FUSE.txt", Path.GetDirectoryName(frmMain.txtNandSource.Text) & "\FUSE.txt")
                    Catch
                        MessageBox.Show("ERROR: Unable to backup FUSE.txt to your source directory!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Try
                End If
            End If
        End Using
    End Sub
    Private Sub testiprange()
        Dim i As Integer
        prog = 0
        i = startip
        For i = startip To limit - 1
            If (abort) OrElse (success) Then
                i = limit
            End If
            Dim iptext As String = baseip & i.ToString()

            If iptext <> currentip Then
                Dim ipcheck As IPAddress = Nothing
                If IPAddress.TryParse(iptext, ipcheck) Then
                    If ipcheck.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                        Dim pinger As New Ping()
                        AddHandler pinger.PingCompleted, AddressOf PingRequestCompleted

                        setstatus("Pinging: " & ipcheck.ToString)
                        pinger.SendAsync(ipcheck, pinglimit)
                        'If pinger.Send(ipcheck, pinglimit).Status = IPStatus.Success Then
                        'downloadfuse(ipcheck.ToString())

                        'If Not String.IsNullOrEmpty(Form1.txtCPUkey.Text) Then
                        'If Main.statc.ecc.Checked Then
                        '    Main.statc.glitch.Checked = True
                        'End If
                        'If File.Exists(Main.statc.source.Text) Then
                        '    Main.mright.kvcheck_Click(Nothing, Nothing)
                        'End If
                        'End If

                        'End If
                    End If
                End If
            End If
            prog += 1
            setprog(prog)
        Next
        
    End Sub

    Private Sub PingRequestCompleted(ByVal sender As Object, ByVal e As Net.NetworkInformation.PingCompletedEventArgs)
        If e.Reply.Status = IPStatus.Success Then
            downloadfuse(e.UserState.ToString)
        End If

        If Not success Then
            setstatus("Unable to find Xell! Check your settings!")
        End If
    End Sub


    Private Sub setbaseip()
        Debug.Print("Start")
        Dim i As Integer
        Dim host As String = Dns.GetHostName()
        Dim localIPs As IPAddress() = Dns.GetHostAddresses(host)
        Dim ipfull As String = ""
        Dim ipsplit As String() = New String(2) {}
        For i = 0 To localIPs.Length - 1
            If Dns.GetHostEntry(host).AddressList(i).AddressFamily = AddressFamily.InterNetwork Then
                ipfull = Dns.GetHostEntry(host).AddressList(i).ToString()
                i = localIPs.Length
            End If
        Next
        Debug.Print(ipfull)
        Debug.Print("End")
        ipsplit = ipfull.Split(".".ToCharArray())
        baseipbox.Text = ipsplit(0) & "." & ipsplit(1) & "." & ipsplit(2) & "."
        currentip = ipfull
    End Sub


    Private Sub frmIPscan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        If testing IsNot Nothing Then
            If testing.IsAlive Then
                abort = True
                While testing.IsAlive
                    Application.DoEvents()
                    Thread.Sleep(100)
                End While
            End If
        End If
        If File.Exists(cfgfile) Then
            File.Delete(cfgfile)
        End If
        Directory.CreateDirectory(Path.GetDirectoryName(cfgfile))
        Using sw As New StreamWriter(File.Open(cfgfile, FileMode.CreateNew))
            sw.WriteLine("rangestart=" + fromip.Text)
            sw.WriteLine("rangeend=" + toip.Text)
            sw.WriteLine("baseip=" + baseipbox.Text)
            sw.WriteLine("timeout=" + timeout.Text)
        End Using
        e.Cancel = False
    End Sub

    
    Private Sub frmIPscan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setbaseip()
        If File.Exists(cfgfile) Then
            Dim cfg As String() = File.ReadAllLines(cfgfile)
            For Each s As String In cfg
                If Not String.IsNullOrEmpty(s) Then
                    If s.Trim().StartsWith("rangestart", StringComparison.CurrentCultureIgnoreCase) Then
                        fromip.Text = s.Substring(11).Trim()
                    ElseIf s.Trim().StartsWith("rangeend", StringComparison.CurrentCultureIgnoreCase) Then
                        toip.Text = s.Substring(9).Trim()
                    ElseIf s.Trim().StartsWith("baseip", StringComparison.CurrentCultureIgnoreCase) Then
                        baseipbox.Text = s.Substring(7).Trim()
                    ElseIf s.Trim().StartsWith("timeout", StringComparison.CurrentCultureIgnoreCase) Then
                        timeout.Text = s.Substring(8).Trim()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub startscanbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startscanbtn.Click
        Try
            success = False
            abort = False
            startip = Integer.Parse(fromip.Text)
            limit = Integer.Parse(toip.Text)
            baseip = baseipbox.Text
            Dim pingmax As Integer = Integer.Parse(timeout.Text)
            If pingmax > 100 Then
                pinglimit = pingmax
            Else
                pinglimit = 100
            End If
            If startip < limit Then
                If (startip < 254) AndAlso (startip >= 0) AndAlso (limit > 1) AndAlso (limit <= 255) Then
                    Dim testip As IPAddress = IPAddress.None
                    If IPAddress.TryParse(baseip & "0", testip) Then
                        progbar.Maximum = limit - startip
                        prog = 0
                        testing = New Thread(New ThreadStart(AddressOf testiprange))
                        testing.Start()
                        While testing.IsAlive
                            Application.DoEvents()
                            Thread.Sleep(100)
                        End While
                    Else
                        MessageBox.Show("ERROR: Base IP is not a valid IP adress!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End If
                Else
                    MessageBox.Show("ERROR: The IP Range you've specified is out of range! IP's must be within 0 - 255" & vbLf & "Scan From cannot be higher then 254" & vbLf & "Scan to cannot be lower then 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End If
            Else
                MessageBox.Show("ERROR: This scanner can only scan forwards, not backwards! make sure that scan from is higher then scan to!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        Catch
            MessageBox.Show("ERROR: Please check your input! Something went horribly wrong here...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try


    End Sub
End Class


