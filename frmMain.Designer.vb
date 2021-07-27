<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuScanXellIP = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdvanceGUI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnWriteNand = New System.Windows.Forms.Button()
        Me.btnFlashRGH = New System.Windows.Forms.Button()
        Me.btnBuildImage = New System.Windows.Forms.Button()
        Me.btnWriteECC = New System.Windows.Forms.Button()
        Me.btnCreateECC = New System.Windows.Forms.Button()
        Me.btn4GBrw = New System.Windows.Forms.Button()
        Me.btnDumpNand = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboNandProVer = New System.Windows.Forms.ComboBox()
        Me.txtConsoleDetected = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFlashConfig = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSaveCPUkey = New System.Windows.Forms.Button()
        Me.txtConsoleSelected = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.radLPT = New System.Windows.Forms.RadioButton()
        Me.radUSB = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCPUkey = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCompareNands = New System.Windows.Forms.Button()
        Me.btnBrowseAdditional = New System.Windows.Forms.Button()
        Me.btnBrowseSource = New System.Windows.Forms.Button()
        Me.txtNandAdditional = New System.Windows.Forms.TextBox()
        Me.txtNandSource = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabcntrlBottom = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnCheckUpdateVersions = New System.Windows.Forms.Button()
        Me.cf0offset = New System.Windows.Forms.TextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.cf1offset = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.slots = New System.Windows.Forms.TextBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.cf1_pairingbox = New System.Windows.Forms.TextBox()
        Me.cf0_pairingbox = New System.Windows.Forms.TextBox()
        Me.cbb_pairingbox = New System.Windows.Forms.TextBox()
        Me.cba_pairingbox = New System.Windows.Forms.TextBox()
        Me.cf1_ldvbox = New System.Windows.Forms.TextBox()
        Me.cf0_ldvbox = New System.Windows.Forms.TextBox()
        Me.cbb_ldvbox = New System.Windows.Forms.TextBox()
        Me.cba_ldvbox = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbb_ldvlbl = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cba_ldvlbl = New System.Windows.Forms.Label()
        Me.cg1 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cf1 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ce = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cg0 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cf0 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cd = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cb_b = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cb_a = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCheckKV = New System.Windows.Forms.Button()
        Me.fcrtreq = New System.Windows.Forms.RichTextBox()
        Me.label44 = New System.Windows.Forms.Label()
        Me.label45 = New System.Windows.Forms.Label()
        Me.currosig = New System.Windows.Forms.TextBox()
        Me.label46 = New System.Windows.Forms.Label()
        Me.currmfr = New System.Windows.Forms.TextBox()
        Me.label47 = New System.Windows.Forms.Label()
        Me.currcid = New System.Windows.Forms.TextBox()
        Me.currdvdkey = New System.Windows.Forms.TextBox()
        Me.label48 = New System.Windows.Forms.Label()
        Me.currregion = New System.Windows.Forms.TextBox()
        Me.label49 = New System.Windows.Forms.Label()
        Me.currserial = New System.Windows.Forms.TextBox()
        Me.label50 = New System.Windows.Forms.Label()
        Me.radRGH = New System.Windows.Forms.RadioButton()
        Me.radRGH2 = New System.Windows.Forms.RadioButton()
        Me.pgBar = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnClearLogWindow = New System.Windows.Forms.Button()
        Me.btnNandDebugLog = New System.Windows.Forms.Button()
        Me.btnDetectMB = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSimpleNandFlasher = New System.Windows.Forms.Button()
        Me.txt1BLkey = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboDashVersions = New System.Windows.Forms.ComboBox()
        Me.radJtag = New System.Windows.Forms.RadioButton()
        Me.radGlitch = New System.Windows.Forms.RadioButton()
        Me.radRetail = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnOfflineFuse = New System.Windows.Forms.Button()
        Me.btnGetCPUkey = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnMonitorCOM = New System.Windows.Forms.Button()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.bgworkerCompareNands = New System.ComponentModel.BackgroundWorker()
        Me.bgworkerGetKey = New System.ComponentModel.BackgroundWorker()
        Me.tmrRestartGetKey = New System.Windows.Forms.Timer(Me.components)
        Me.bgworkerCreateECC = New System.ComponentModel.BackgroundWorker()
        Me.bgworkerWriteECC = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabcntrlBottom.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit, Me.ToolsToolStripMenuItem, Me.mnuScanXellIP, Me.mnuAdvanceGUI})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(985, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(37, 20)
        Me.mnuExit.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'mnuScanXellIP
        '
        Me.mnuScanXellIP.Name = "mnuScanXellIP"
        Me.mnuScanXellIP.Size = New System.Drawing.Size(74, 20)
        Me.mnuScanXellIP.Text = "Scan Xell IP"
        '
        'mnuAdvanceGUI
        '
        Me.mnuAdvanceGUI.Name = "mnuAdvanceGUI"
        Me.mnuAdvanceGUI.Size = New System.Drawing.Size(61, 20)
        Me.mnuAdvanceGUI.Text = "Advance"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnWriteNand)
        Me.GroupBox1.Controls.Add(Me.btnFlashRGH)
        Me.GroupBox1.Controls.Add(Me.btnBuildImage)
        Me.GroupBox1.Controls.Add(Me.btnWriteECC)
        Me.GroupBox1.Controls.Add(Me.btnCreateECC)
        Me.GroupBox1.Controls.Add(Me.btn4GBrw)
        Me.GroupBox1.Controls.Add(Me.btnDumpNand)
        Me.GroupBox1.Location = New System.Drawing.Point(487, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(81, 456)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Functions"
        '
        'btnWriteNand
        '
        Me.btnWriteNand.Location = New System.Drawing.Point(15, 392)
        Me.btnWriteNand.Name = "btnWriteNand"
        Me.btnWriteNand.Size = New System.Drawing.Size(50, 44)
        Me.btnWriteNand.TabIndex = 6
        Me.btnWriteNand.Text = "Write Nand"
        Me.btnWriteNand.UseVisualStyleBackColor = True
        '
        'btnFlashRGH
        '
        Me.btnFlashRGH.Location = New System.Drawing.Point(15, 332)
        Me.btnFlashRGH.Name = "btnFlashRGH"
        Me.btnFlashRGH.Size = New System.Drawing.Size(50, 44)
        Me.btnFlashRGH.TabIndex = 5
        Me.btnFlashRGH.Text = "Flash RGH"
        Me.btnFlashRGH.UseVisualStyleBackColor = True
        '
        'btnBuildImage
        '
        Me.btnBuildImage.Location = New System.Drawing.Point(15, 272)
        Me.btnBuildImage.Name = "btnBuildImage"
        Me.btnBuildImage.Size = New System.Drawing.Size(50, 44)
        Me.btnBuildImage.TabIndex = 4
        Me.btnBuildImage.Text = "Build Image"
        Me.btnBuildImage.UseVisualStyleBackColor = True
        '
        'btnWriteECC
        '
        Me.btnWriteECC.Location = New System.Drawing.Point(15, 212)
        Me.btnWriteECC.Name = "btnWriteECC"
        Me.btnWriteECC.Size = New System.Drawing.Size(50, 44)
        Me.btnWriteECC.TabIndex = 3
        Me.btnWriteECC.Text = "Write ECC"
        Me.btnWriteECC.UseVisualStyleBackColor = True
        '
        'btnCreateECC
        '
        Me.btnCreateECC.Location = New System.Drawing.Point(15, 152)
        Me.btnCreateECC.Name = "btnCreateECC"
        Me.btnCreateECC.Size = New System.Drawing.Size(50, 44)
        Me.btnCreateECC.TabIndex = 2
        Me.btnCreateECC.Text = "Create ECC"
        Me.btnCreateECC.UseVisualStyleBackColor = True
        '
        'btn4GBrw
        '
        Me.btn4GBrw.Location = New System.Drawing.Point(15, 92)
        Me.btn4GBrw.Name = "btn4GBrw"
        Me.btn4GBrw.Size = New System.Drawing.Size(50, 44)
        Me.btn4GBrw.TabIndex = 1
        Me.btn4GBrw.Text = "4GB R/W"
        Me.btn4GBrw.UseVisualStyleBackColor = True
        '
        'btnDumpNand
        '
        Me.btnDumpNand.Location = New System.Drawing.Point(15, 32)
        Me.btnDumpNand.Name = "btnDumpNand"
        Me.btnDumpNand.Size = New System.Drawing.Size(50, 44)
        Me.btnDumpNand.TabIndex = 0
        Me.btnDumpNand.Text = "Dump Nand"
        Me.btnDumpNand.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboNandProVer)
        Me.GroupBox2.Controls.Add(Me.txtConsoleDetected)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtFlashConfig)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnSaveCPUkey)
        Me.GroupBox2.Controls.Add(Me.txtConsoleSelected)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.radLPT)
        Me.GroupBox2.Controls.Add(Me.radUSB)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCPUkey)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnCompareNands)
        Me.GroupBox2.Controls.Add(Me.btnBrowseAdditional)
        Me.GroupBox2.Controls.Add(Me.btnBrowseSource)
        Me.GroupBox2.Controls.Add(Me.txtNandAdditional)
        Me.GroupBox2.Controls.Add(Me.txtNandSource)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(460, 190)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "NandPro"
        '
        'cboNandProVer
        '
        Me.cboNandProVer.AutoCompleteCustomSource.AddRange(New String() {"2.0b", "2.0e", "3.0a"})
        Me.cboNandProVer.BackColor = System.Drawing.SystemColors.Control
        Me.cboNandProVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNandProVer.FormattingEnabled = True
        Me.cboNandProVer.Items.AddRange(New Object() {"2.0b", "2.0e", "3.0a"})
        Me.cboNandProVer.Location = New System.Drawing.Point(303, 115)
        Me.cboNandProVer.Name = "cboNandProVer"
        Me.cboNandProVer.Size = New System.Drawing.Size(53, 21)
        Me.cboNandProVer.TabIndex = 40
        '
        'txtConsoleDetected
        '
        Me.txtConsoleDetected.Location = New System.Drawing.Point(102, 164)
        Me.txtConsoleDetected.Name = "txtConsoleDetected"
        Me.txtConsoleDetected.ReadOnly = True
        Me.txtConsoleDetected.Size = New System.Drawing.Size(110, 20)
        Me.txtConsoleDetected.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Console Detected :"
        '
        'txtFlashConfig
        '
        Me.txtFlashConfig.Location = New System.Drawing.Point(303, 142)
        Me.txtFlashConfig.Name = "txtFlashConfig"
        Me.txtFlashConfig.ReadOnly = True
        Me.txtFlashConfig.Size = New System.Drawing.Size(92, 20)
        Me.txtFlashConfig.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(227, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Flash Config :"
        '
        'btnSaveCPUkey
        '
        Me.btnSaveCPUkey.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveCPUkey.Location = New System.Drawing.Point(329, 86)
        Me.btnSaveCPUkey.Name = "btnSaveCPUkey"
        Me.btnSaveCPUkey.Size = New System.Drawing.Size(40, 20)
        Me.btnSaveCPUkey.TabIndex = 16
        Me.btnSaveCPUkey.Text = "Save"
        Me.btnSaveCPUkey.UseVisualStyleBackColor = True
        '
        'txtConsoleSelected
        '
        Me.txtConsoleSelected.Location = New System.Drawing.Point(102, 138)
        Me.txtConsoleSelected.Name = "txtConsoleSelected"
        Me.txtConsoleSelected.ReadOnly = True
        Me.txtConsoleSelected.Size = New System.Drawing.Size(110, 20)
        Me.txtConsoleSelected.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Console Selected :"
        '
        'radLPT
        '
        Me.radLPT.AutoSize = True
        Me.radLPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLPT.Location = New System.Drawing.Point(131, 113)
        Me.radLPT.Name = "radLPT"
        Me.radLPT.Size = New System.Drawing.Size(42, 16)
        Me.radLPT.TabIndex = 12
        Me.radLPT.Text = "LPT"
        Me.radLPT.UseVisualStyleBackColor = True
        '
        'radUSB
        '
        Me.radUSB.AutoSize = True
        Me.radUSB.Checked = True
        Me.radUSB.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radUSB.Location = New System.Drawing.Point(80, 112)
        Me.radUSB.Name = "radUSB"
        Me.radUSB.Size = New System.Drawing.Size(45, 16)
        Me.radUSB.TabIndex = 11
        Me.radUSB.TabStop = True
        Me.radUSB.Text = "USB"
        Me.radUSB.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(227, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "NandPro Ver :"
        '
        'txtCPUkey
        '
        Me.txtCPUkey.Location = New System.Drawing.Point(75, 86)
        Me.txtCPUkey.Name = "txtCPUkey"
        Me.txtCPUkey.Size = New System.Drawing.Size(249, 20)
        Me.txtCPUkey.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "CPU Key :"
        '
        'btnCompareNands
        '
        Me.btnCompareNands.ForeColor = System.Drawing.Color.Maroon
        Me.btnCompareNands.Location = New System.Drawing.Point(387, 20)
        Me.btnCompareNands.Name = "btnCompareNands"
        Me.btnCompareNands.Size = New System.Drawing.Size(59, 54)
        Me.btnCompareNands.TabIndex = 6
        Me.btnCompareNands.Text = "Compare Nands"
        Me.btnCompareNands.UseVisualStyleBackColor = True
        '
        'btnBrowseAdditional
        '
        Me.btnBrowseAdditional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseAdditional.Location = New System.Drawing.Point(329, 54)
        Me.btnBrowseAdditional.Name = "btnBrowseAdditional"
        Me.btnBrowseAdditional.Size = New System.Drawing.Size(40, 20)
        Me.btnBrowseAdditional.TabIndex = 5
        Me.btnBrowseAdditional.Text = "..."
        Me.btnBrowseAdditional.UseVisualStyleBackColor = True
        '
        'btnBrowseSource
        '
        Me.btnBrowseSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseSource.Location = New System.Drawing.Point(329, 20)
        Me.btnBrowseSource.Name = "btnBrowseSource"
        Me.btnBrowseSource.Size = New System.Drawing.Size(40, 20)
        Me.btnBrowseSource.TabIndex = 4
        Me.btnBrowseSource.Text = "..."
        Me.btnBrowseSource.UseVisualStyleBackColor = True
        '
        'txtNandAdditional
        '
        Me.txtNandAdditional.Location = New System.Drawing.Point(75, 52)
        Me.txtNandAdditional.Name = "txtNandAdditional"
        Me.txtNandAdditional.ReadOnly = True
        Me.txtNandAdditional.Size = New System.Drawing.Size(249, 20)
        Me.txtNandAdditional.TabIndex = 3
        '
        'txtNandSource
        '
        Me.txtNandSource.Location = New System.Drawing.Point(75, 18)
        Me.txtNandSource.Name = "txtNandSource"
        Me.txtNandSource.ReadOnly = True
        Me.txtNandSource.Size = New System.Drawing.Size(249, 20)
        Me.txtNandSource.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Additional :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source :"
        '
        'tabcntrlBottom
        '
        Me.tabcntrlBottom.Controls.Add(Me.TabPage1)
        Me.tabcntrlBottom.Controls.Add(Me.TabPage2)
        Me.tabcntrlBottom.Location = New System.Drawing.Point(574, 249)
        Me.tabcntrlBottom.Name = "tabcntrlBottom"
        Me.tabcntrlBottom.SelectedIndex = 0
        Me.tabcntrlBottom.Size = New System.Drawing.Size(399, 253)
        Me.tabcntrlBottom.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnCheckUpdateVersions)
        Me.TabPage1.Controls.Add(Me.cf0offset)
        Me.TabPage1.Controls.Add(Me.label17)
        Me.TabPage1.Controls.Add(Me.cf1offset)
        Me.TabPage1.Controls.Add(Me.label16)
        Me.TabPage1.Controls.Add(Me.slots)
        Me.TabPage1.Controls.Add(Me.label15)
        Me.TabPage1.Controls.Add(Me.cf1_pairingbox)
        Me.TabPage1.Controls.Add(Me.cf0_pairingbox)
        Me.TabPage1.Controls.Add(Me.cbb_pairingbox)
        Me.TabPage1.Controls.Add(Me.cba_pairingbox)
        Me.TabPage1.Controls.Add(Me.cf1_ldvbox)
        Me.TabPage1.Controls.Add(Me.cf0_ldvbox)
        Me.TabPage1.Controls.Add(Me.cbb_ldvbox)
        Me.TabPage1.Controls.Add(Me.cba_ldvbox)
        Me.TabPage1.Controls.Add(Me.label14)
        Me.TabPage1.Controls.Add(Me.label12)
        Me.TabPage1.Controls.Add(Me.label13)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.cbb_ldvlbl)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.cba_ldvlbl)
        Me.TabPage1.Controls.Add(Me.cg1)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.cf1)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.ce)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.cg0)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.cf0)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.cd)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.cb_b)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.cb_a)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(391, 227)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nand Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnCheckUpdateVersions
        '
        Me.btnCheckUpdateVersions.Location = New System.Drawing.Point(319, 11)
        Me.btnCheckUpdateVersions.Name = "btnCheckUpdateVersions"
        Me.btnCheckUpdateVersions.Size = New System.Drawing.Size(51, 49)
        Me.btnCheckUpdateVersions.TabIndex = 112
        Me.btnCheckUpdateVersions.Text = "Re-init"
        Me.btnCheckUpdateVersions.UseVisualStyleBackColor = True
        '
        'cf0offset
        '
        Me.cf0offset.Location = New System.Drawing.Point(256, 167)
        Me.cf0offset.Name = "cf0offset"
        Me.cf0offset.ReadOnly = True
        Me.cf0offset.Size = New System.Drawing.Size(73, 20)
        Me.cf0offset.TabIndex = 111
        Me.cf0offset.Text = "N/A"
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(160, 196)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(90, 13)
        Me.label17.TabIndex = 110
        Me.label17.Text = "CF Offset (Slot 1):"
        '
        'cf1offset
        '
        Me.cf1offset.Location = New System.Drawing.Point(256, 193)
        Me.cf1offset.Name = "cf1offset"
        Me.cf1offset.ReadOnly = True
        Me.cf1offset.Size = New System.Drawing.Size(73, 20)
        Me.cf1offset.TabIndex = 109
        Me.cf1offset.Text = "N/A"
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(160, 170)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(90, 13)
        Me.label16.TabIndex = 108
        Me.label16.Text = "CF Offset (Slot 0):"
        '
        'slots
        '
        Me.slots.Location = New System.Drawing.Point(81, 193)
        Me.slots.Name = "slots"
        Me.slots.ReadOnly = True
        Me.slots.Size = New System.Drawing.Size(36, 20)
        Me.slots.TabIndex = 107
        Me.slots.Text = "N/A"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(11, 196)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(64, 13)
        Me.label15.TabIndex = 106
        Me.label15.Text = "Patch Slots:"
        '
        'cf1_pairingbox
        '
        Me.cf1_pairingbox.Location = New System.Drawing.Point(307, 141)
        Me.cf1_pairingbox.Name = "cf1_pairingbox"
        Me.cf1_pairingbox.ReadOnly = True
        Me.cf1_pairingbox.Size = New System.Drawing.Size(73, 20)
        Me.cf1_pairingbox.TabIndex = 103
        Me.cf1_pairingbox.Text = "N/A"
        Me.cf1_pairingbox.Visible = False
        '
        'cf0_pairingbox
        '
        Me.cf0_pairingbox.Location = New System.Drawing.Point(307, 92)
        Me.cf0_pairingbox.Name = "cf0_pairingbox"
        Me.cf0_pairingbox.ReadOnly = True
        Me.cf0_pairingbox.Size = New System.Drawing.Size(73, 20)
        Me.cf0_pairingbox.TabIndex = 102
        Me.cf0_pairingbox.Text = "N/A"
        Me.cf0_pairingbox.Visible = False
        '
        'cbb_pairingbox
        '
        Me.cbb_pairingbox.Location = New System.Drawing.Point(307, 37)
        Me.cbb_pairingbox.Name = "cbb_pairingbox"
        Me.cbb_pairingbox.ReadOnly = True
        Me.cbb_pairingbox.Size = New System.Drawing.Size(73, 20)
        Me.cbb_pairingbox.TabIndex = 105
        Me.cbb_pairingbox.Text = "N/A"
        Me.cbb_pairingbox.Visible = False
        '
        'cba_pairingbox
        '
        Me.cba_pairingbox.Location = New System.Drawing.Point(307, 11)
        Me.cba_pairingbox.Name = "cba_pairingbox"
        Me.cba_pairingbox.ReadOnly = True
        Me.cba_pairingbox.Size = New System.Drawing.Size(73, 20)
        Me.cba_pairingbox.TabIndex = 104
        Me.cba_pairingbox.Text = "N/A"
        Me.cba_pairingbox.Visible = False
        '
        'cf1_ldvbox
        '
        Me.cf1_ldvbox.Location = New System.Drawing.Point(197, 141)
        Me.cf1_ldvbox.Name = "cf1_ldvbox"
        Me.cf1_ldvbox.ReadOnly = True
        Me.cf1_ldvbox.Size = New System.Drawing.Size(32, 20)
        Me.cf1_ldvbox.TabIndex = 101
        Me.cf1_ldvbox.Text = "N/A"
        '
        'cf0_ldvbox
        '
        Me.cf0_ldvbox.Location = New System.Drawing.Point(197, 89)
        Me.cf0_ldvbox.Name = "cf0_ldvbox"
        Me.cf0_ldvbox.ReadOnly = True
        Me.cf0_ldvbox.Size = New System.Drawing.Size(32, 20)
        Me.cf0_ldvbox.TabIndex = 100
        Me.cf0_ldvbox.Text = "N/A"
        '
        'cbb_ldvbox
        '
        Me.cbb_ldvbox.Location = New System.Drawing.Point(197, 37)
        Me.cbb_ldvbox.Name = "cbb_ldvbox"
        Me.cbb_ldvbox.ReadOnly = True
        Me.cbb_ldvbox.Size = New System.Drawing.Size(32, 20)
        Me.cbb_ldvbox.TabIndex = 99
        Me.cbb_ldvbox.Text = "N/A"
        '
        'cba_ldvbox
        '
        Me.cba_ldvbox.Location = New System.Drawing.Point(197, 11)
        Me.cba_ldvbox.Name = "cba_ldvbox"
        Me.cba_ldvbox.ReadOnly = True
        Me.cba_ldvbox.Size = New System.Drawing.Size(32, 20)
        Me.cba_ldvbox.TabIndex = 98
        Me.cba_ldvbox.Text = "N/A"
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(235, 144)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(66, 13)
        Me.label14.TabIndex = 96
        Me.label14.Text = "Pairing data:"
        Me.label14.Visible = False
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(160, 144)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(31, 13)
        Me.label12.TabIndex = 97
        Me.label12.Text = "LDV:"
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(235, 95)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(66, 13)
        Me.label13.TabIndex = 94
        Me.label13.Text = "Pairing data:"
        Me.label13.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(160, 92)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 13)
        Me.Label18.TabIndex = 95
        Me.Label18.Text = "LDV:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(235, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 13)
        Me.Label19.TabIndex = 93
        Me.Label19.Text = "Pairing data:"
        Me.Label19.Visible = False
        '
        'cbb_ldvlbl
        '
        Me.cbb_ldvlbl.AutoSize = True
        Me.cbb_ldvlbl.Location = New System.Drawing.Point(160, 40)
        Me.cbb_ldvlbl.Name = "cbb_ldvlbl"
        Me.cbb_ldvlbl.Size = New System.Drawing.Size(31, 13)
        Me.cbb_ldvlbl.TabIndex = 92
        Me.cbb_ldvlbl.Text = "LDV:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(235, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 13)
        Me.Label20.TabIndex = 90
        Me.Label20.Text = "Pairing data:"
        Me.Label20.Visible = False
        '
        'cba_ldvlbl
        '
        Me.cba_ldvlbl.AutoSize = True
        Me.cba_ldvlbl.Location = New System.Drawing.Point(160, 14)
        Me.cba_ldvlbl.Name = "cba_ldvlbl"
        Me.cba_ldvlbl.Size = New System.Drawing.Size(31, 13)
        Me.cba_ldvlbl.TabIndex = 91
        Me.cba_ldvlbl.Text = "LDV:"
        '
        'cg1
        '
        Me.cg1.Location = New System.Drawing.Point(81, 167)
        Me.cg1.Name = "cg1"
        Me.cg1.ReadOnly = True
        Me.cg1.Size = New System.Drawing.Size(73, 20)
        Me.cg1.TabIndex = 89
        Me.cg1.Text = "N/A"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 170)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 88
        Me.Label21.Text = "CG (Slot 1):"
        '
        'cf1
        '
        Me.cf1.Location = New System.Drawing.Point(81, 141)
        Me.cf1.Name = "cf1"
        Me.cf1.ReadOnly = True
        Me.cf1.Size = New System.Drawing.Size(73, 20)
        Me.cf1.TabIndex = 87
        Me.cf1.Text = "N/A"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 144)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 13)
        Me.Label22.TabIndex = 86
        Me.Label22.Text = "CF (Slot 1):"
        '
        'ce
        '
        Me.ce.Location = New System.Drawing.Point(197, 63)
        Me.ce.Name = "ce"
        Me.ce.ReadOnly = True
        Me.ce.Size = New System.Drawing.Size(73, 20)
        Me.ce.TabIndex = 85
        Me.ce.Text = "N/A"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(167, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(24, 13)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "CE:"
        '
        'cg0
        '
        Me.cg0.Location = New System.Drawing.Point(81, 115)
        Me.cg0.Name = "cg0"
        Me.cg0.ReadOnly = True
        Me.cg0.Size = New System.Drawing.Size(73, 20)
        Me.cg0.TabIndex = 83
        Me.cg0.Text = "N/A"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(14, 118)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 82
        Me.Label24.Text = "CG (Slot 0):"
        '
        'cf0
        '
        Me.cf0.Location = New System.Drawing.Point(81, 89)
        Me.cf0.Name = "cf0"
        Me.cf0.ReadOnly = True
        Me.cf0.Size = New System.Drawing.Size(73, 20)
        Me.cf0.TabIndex = 81
        Me.cf0.Text = "N/A"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 92)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 13)
        Me.Label25.TabIndex = 80
        Me.Label25.Text = "CF (Slot 0):"
        '
        'cd
        '
        Me.cd.Location = New System.Drawing.Point(81, 63)
        Me.cd.Name = "cd"
        Me.cd.ReadOnly = True
        Me.cd.Size = New System.Drawing.Size(73, 20)
        Me.cd.TabIndex = 79
        Me.cd.Text = "N/A"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(50, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(25, 13)
        Me.Label26.TabIndex = 78
        Me.Label26.Text = "CD:"
        '
        'cb_b
        '
        Me.cb_b.Location = New System.Drawing.Point(81, 37)
        Me.cb_b.Name = "cb_b"
        Me.cb_b.ReadOnly = True
        Me.cb_b.Size = New System.Drawing.Size(73, 20)
        Me.cb_b.TabIndex = 77
        Me.cb_b.Text = "N/A"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 40)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 13)
        Me.Label27.TabIndex = 76
        Me.Label27.Text = "CB (CB_B):"
        '
        'cb_a
        '
        Me.cb_a.Location = New System.Drawing.Point(81, 11)
        Me.cb_a.Name = "cb_a"
        Me.cb_a.ReadOnly = True
        Me.cb_a.Size = New System.Drawing.Size(73, 20)
        Me.cb_a.TabIndex = 75
        Me.cb_a.Text = "N/A"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(15, 14)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 13)
        Me.Label28.TabIndex = 74
        Me.Label28.Text = "CB (CB_A):"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnCheckKV)
        Me.TabPage2.Controls.Add(Me.fcrtreq)
        Me.TabPage2.Controls.Add(Me.label44)
        Me.TabPage2.Controls.Add(Me.label45)
        Me.TabPage2.Controls.Add(Me.currosig)
        Me.TabPage2.Controls.Add(Me.label46)
        Me.TabPage2.Controls.Add(Me.currmfr)
        Me.TabPage2.Controls.Add(Me.label47)
        Me.TabPage2.Controls.Add(Me.currcid)
        Me.TabPage2.Controls.Add(Me.currdvdkey)
        Me.TabPage2.Controls.Add(Me.label48)
        Me.TabPage2.Controls.Add(Me.currregion)
        Me.TabPage2.Controls.Add(Me.label49)
        Me.TabPage2.Controls.Add(Me.currserial)
        Me.TabPage2.Controls.Add(Me.label50)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(391, 227)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "KV Info"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCheckKV
        '
        Me.btnCheckKV.Location = New System.Drawing.Point(223, 165)
        Me.btnCheckKV.Name = "btnCheckKV"
        Me.btnCheckKV.Size = New System.Drawing.Size(116, 46)
        Me.btnCheckKV.TabIndex = 43
        Me.btnCheckKV.Text = "Re-init"
        Me.btnCheckKV.UseVisualStyleBackColor = True
        '
        'fcrtreq
        '
        Me.fcrtreq.Location = New System.Drawing.Point(284, 52)
        Me.fcrtreq.Name = "fcrtreq"
        Me.fcrtreq.ReadOnly = True
        Me.fcrtreq.Size = New System.Drawing.Size(51, 20)
        Me.fcrtreq.TabIndex = 42
        Me.fcrtreq.Text = ""
        '
        'label44
        '
        Me.label44.AutoSize = True
        Me.label44.Location = New System.Drawing.Point(180, 55)
        Me.label44.Name = "label44"
        Me.label44.Size = New System.Drawing.Size(100, 13)
        Me.label44.TabIndex = 41
        Me.label44.Text = "Requires FCRT.bin:"
        '
        'label45
        '
        Me.label45.AutoSize = True
        Me.label45.Location = New System.Drawing.Point(27, 134)
        Me.label45.Name = "label45"
        Me.label45.Size = New System.Drawing.Size(62, 13)
        Me.label45.TabIndex = 40
        Me.label45.Text = "DVD OSIG:"
        '
        'currosig
        '
        Me.currosig.Location = New System.Drawing.Point(95, 131)
        Me.currosig.Name = "currosig"
        Me.currosig.ReadOnly = True
        Me.currosig.Size = New System.Drawing.Size(221, 20)
        Me.currosig.TabIndex = 39
        '
        'label46
        '
        Me.label46.AutoSize = True
        Me.label46.Location = New System.Drawing.Point(33, 55)
        Me.label46.Name = "label46"
        Me.label46.Size = New System.Drawing.Size(59, 13)
        Me.label46.TabIndex = 38
        Me.label46.Text = "MFR-Date:"
        '
        'currmfr
        '
        Me.currmfr.Location = New System.Drawing.Point(95, 52)
        Me.currmfr.Name = "currmfr"
        Me.currmfr.ReadOnly = True
        Me.currmfr.Size = New System.Drawing.Size(51, 20)
        Me.currmfr.TabIndex = 37
        '
        'label47
        '
        Me.label47.AutoSize = True
        Me.label47.Location = New System.Drawing.Point(184, 29)
        Me.label47.Name = "label47"
        Me.label47.Size = New System.Drawing.Size(62, 13)
        Me.label47.TabIndex = 36
        Me.label47.Text = "Console ID:"
        '
        'currcid
        '
        Me.currcid.Location = New System.Drawing.Point(252, 26)
        Me.currcid.Name = "currcid"
        Me.currcid.ReadOnly = True
        Me.currcid.Size = New System.Drawing.Size(83, 20)
        Me.currcid.TabIndex = 35
        '
        'currdvdkey
        '
        Me.currdvdkey.Location = New System.Drawing.Point(95, 105)
        Me.currdvdkey.Name = "currdvdkey"
        Me.currdvdkey.ReadOnly = True
        Me.currdvdkey.Size = New System.Drawing.Size(221, 20)
        Me.currdvdkey.TabIndex = 34
        '
        'label48
        '
        Me.label48.AutoSize = True
        Me.label48.Location = New System.Drawing.Point(38, 108)
        Me.label48.Name = "label48"
        Me.label48.Size = New System.Drawing.Size(51, 13)
        Me.label48.TabIndex = 33
        Me.label48.Text = "DVDKey:"
        '
        'currregion
        '
        Me.currregion.Location = New System.Drawing.Point(95, 79)
        Me.currregion.Name = "currregion"
        Me.currregion.ReadOnly = True
        Me.currregion.Size = New System.Drawing.Size(158, 20)
        Me.currregion.TabIndex = 32
        '
        'label49
        '
        Me.label49.AutoSize = True
        Me.label49.Location = New System.Drawing.Point(4, 82)
        Me.label49.Name = "label49"
        Me.label49.Size = New System.Drawing.Size(85, 13)
        Me.label49.TabIndex = 31
        Me.label49.Text = "Console Region:"
        '
        'currserial
        '
        Me.currserial.Location = New System.Drawing.Point(95, 26)
        Me.currserial.Name = "currserial"
        Me.currserial.ReadOnly = True
        Me.currserial.Size = New System.Drawing.Size(83, 20)
        Me.currserial.TabIndex = 30
        '
        'label50
        '
        Me.label50.AutoSize = True
        Me.label50.Location = New System.Drawing.Point(13, 29)
        Me.label50.Name = "label50"
        Me.label50.Size = New System.Drawing.Size(76, 13)
        Me.label50.TabIndex = 29
        Me.label50.Text = "Serial Number:"
        '
        'radRGH
        '
        Me.radRGH.AutoSize = True
        Me.radRGH.Checked = True
        Me.radRGH.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radRGH.Location = New System.Drawing.Point(181, 25)
        Me.radRGH.Name = "radRGH"
        Me.radRGH.Size = New System.Drawing.Size(73, 16)
        Me.radRGH.TabIndex = 21
        Me.radRGH.TabStop = True
        Me.radRGH.Text = "RGH ECC"
        Me.radRGH.UseVisualStyleBackColor = True
        '
        'radRGH2
        '
        Me.radRGH2.AutoSize = True
        Me.radRGH2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radRGH2.Location = New System.Drawing.Point(258, 25)
        Me.radRGH2.Name = "radRGH2"
        Me.radRGH2.Size = New System.Drawing.Size(85, 16)
        Me.radRGH2.TabIndex = 22
        Me.radRGH2.Text = "RGH 2  ECC"
        Me.radRGH2.UseVisualStyleBackColor = True
        '
        'pgBar
        '
        Me.pgBar.Location = New System.Drawing.Point(118, 249)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(354, 24)
        Me.pgBar.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 254)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Progress Status :"
        '
        'rtbLog
        '
        Me.rtbLog.BackColor = System.Drawing.Color.Black
        Me.rtbLog.ForeColor = System.Drawing.Color.White
        Me.rtbLog.Location = New System.Drawing.Point(12, 320)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(459, 182)
        Me.rtbLog.TabIndex = 6
        Me.rtbLog.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Events Log"
        '
        'btnClearLogWindow
        '
        Me.btnClearLogWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearLogWindow.Location = New System.Drawing.Point(183, 294)
        Me.btnClearLogWindow.Name = "btnClearLogWindow"
        Me.btnClearLogWindow.Size = New System.Drawing.Size(92, 20)
        Me.btnClearLogWindow.TabIndex = 8
        Me.btnClearLogWindow.Text = "Clear Log Window"
        Me.btnClearLogWindow.UseVisualStyleBackColor = True
        '
        'btnNandDebugLog
        '
        Me.btnNandDebugLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNandDebugLog.Location = New System.Drawing.Point(281, 294)
        Me.btnNandDebugLog.Name = "btnNandDebugLog"
        Me.btnNandDebugLog.Size = New System.Drawing.Size(92, 20)
        Me.btnNandDebugLog.TabIndex = 9
        Me.btnNandDebugLog.Text = "Nand Debug Log"
        Me.btnNandDebugLog.UseVisualStyleBackColor = True
        '
        'btnDetectMB
        '
        Me.btnDetectMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetectMB.Location = New System.Drawing.Point(379, 294)
        Me.btnDetectMB.Name = "btnDetectMB"
        Me.btnDetectMB.Size = New System.Drawing.Size(92, 20)
        Me.btnDetectMB.TabIndex = 10
        Me.btnDetectMB.Text = "Detect M/B"
        Me.btnDetectMB.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.btnSimpleNandFlasher)
        Me.GroupBox3.Controls.Add(Me.txt1BLkey)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.radRGH2)
        Me.GroupBox3.Controls.Add(Me.radRGH)
        Me.GroupBox3.Controls.Add(Me.cboDashVersions)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(574, 46)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(394, 117)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "XeBuild"
        '
        'btnSimpleNandFlasher
        '
        Me.btnSimpleNandFlasher.Location = New System.Drawing.Point(217, 52)
        Me.btnSimpleNandFlasher.Name = "btnSimpleNandFlasher"
        Me.btnSimpleNandFlasher.Size = New System.Drawing.Size(126, 23)
        Me.btnSimpleNandFlasher.TabIndex = 25
        Me.btnSimpleNandFlasher.Text = "Simple Nand Flasher"
        Me.btnSimpleNandFlasher.UseVisualStyleBackColor = True
        '
        'txt1BLkey
        '
        Me.txt1BLkey.Location = New System.Drawing.Point(79, 83)
        Me.txt1BLkey.Name = "txt1BLkey"
        Me.txt1BLkey.Size = New System.Drawing.Size(264, 20)
        Me.txt1BLkey.TabIndex = 24
        Me.txt1BLkey.Text = "DD88AD0C9ED669E7B56794FB68563EFA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "1BLKey :"
        '
        'cboDashVersions
        '
        Me.cboDashVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDashVersions.FormattingEnabled = True
        Me.cboDashVersions.Items.AddRange(New Object() {"7371", "9199", "12611", "12625", "13146", "13599", "13604", "14699", "14717", "14717", "14719", "15574", "16197", "16202", "16203"})
        Me.cboDashVersions.Location = New System.Drawing.Point(79, 22)
        Me.cboDashVersions.Name = "cboDashVersions"
        Me.cboDashVersions.Size = New System.Drawing.Size(79, 21)
        Me.cboDashVersions.TabIndex = 4
        '
        'radJtag
        '
        Me.radJtag.AutoSize = True
        Me.radJtag.ForeColor = System.Drawing.Color.Maroon
        Me.radJtag.Location = New System.Drawing.Point(131, 12)
        Me.radJtag.Name = "radJtag"
        Me.radJtag.Size = New System.Drawing.Size(45, 17)
        Me.radJtag.TabIndex = 3
        Me.radJtag.Text = "Jtag"
        Me.radJtag.UseVisualStyleBackColor = True
        '
        'radGlitch
        '
        Me.radGlitch.AutoSize = True
        Me.radGlitch.ForeColor = System.Drawing.Color.Maroon
        Me.radGlitch.Location = New System.Drawing.Point(73, 12)
        Me.radGlitch.Name = "radGlitch"
        Me.radGlitch.Size = New System.Drawing.Size(52, 17)
        Me.radGlitch.TabIndex = 2
        Me.radGlitch.Text = "Glitch"
        Me.radGlitch.UseVisualStyleBackColor = True
        '
        'radRetail
        '
        Me.radRetail.AutoSize = True
        Me.radRetail.Checked = True
        Me.radRetail.ForeColor = System.Drawing.Color.Maroon
        Me.radRetail.Location = New System.Drawing.Point(15, 12)
        Me.radRetail.Name = "radRetail"
        Me.radRetail.Size = New System.Drawing.Size(52, 17)
        Me.radRetail.TabIndex = 1
        Me.radRetail.TabStop = True
        Me.radRetail.Text = "Retail"
        Me.radRetail.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Dash Ver :"
        '
        'btnOfflineFuse
        '
        Me.btnOfflineFuse.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOfflineFuse.Location = New System.Drawing.Point(200, 15)
        Me.btnOfflineFuse.Name = "btnOfflineFuse"
        Me.btnOfflineFuse.Size = New System.Drawing.Size(103, 27)
        Me.btnOfflineFuse.TabIndex = 13
        Me.btnOfflineFuse.Text = "Offline FUSE Text"
        Me.btnOfflineFuse.UseVisualStyleBackColor = True
        '
        'btnGetCPUkey
        '
        Me.btnGetCPUkey.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetCPUkey.Location = New System.Drawing.Point(200, 45)
        Me.btnGetCPUkey.Name = "btnGetCPUkey"
        Me.btnGetCPUkey.Size = New System.Drawing.Size(103, 27)
        Me.btnGetCPUkey.TabIndex = 12
        Me.btnGetCPUkey.Text = "Get CPU Key"
        Me.btnGetCPUkey.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnMonitorCOM)
        Me.GroupBox4.Controls.Add(Me.txtIP)
        Me.GroupBox4.Controls.Add(Me.btnOfflineFuse)
        Me.GroupBox4.Controls.Add(Me.btnGetCPUkey)
        Me.GroupBox4.Location = New System.Drawing.Point(574, 165)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(394, 83)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "XBOX IP"
        '
        'btnMonitorCOM
        '
        Me.btnMonitorCOM.Location = New System.Drawing.Point(315, 15)
        Me.btnMonitorCOM.Name = "btnMonitorCOM"
        Me.btnMonitorCOM.Size = New System.Drawing.Size(59, 57)
        Me.btnMonitorCOM.TabIndex = 15
        Me.btnMonitorCOM.Text = "Monitor Com"
        Me.btnMonitorCOM.UseVisualStyleBackColor = True
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(15, 32)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(143, 20)
        Me.txtIP.TabIndex = 14
        Me.txtIP.Text = "192.168.0."
        '
        'bgworkerCompareNands
        '
        '
        'bgworkerGetKey
        '
        Me.bgworkerGetKey.WorkerSupportsCancellation = True
        '
        'tmrRestartGetKey
        '
        Me.tmrRestartGetKey.Interval = 2000
        '
        'bgworkerCreateECC
        '
        Me.bgworkerCreateECC.WorkerReportsProgress = True
        '
        'bgworkerWriteECC
        '
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.radGlitch)
        Me.GroupBox5.Controls.Add(Me.radRetail)
        Me.GroupBox5.Controls.Add(Me.radJtag)
        Me.GroupBox5.Location = New System.Drawing.Point(18, 45)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(188, 33)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Type"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 515)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnDetectMB)
        Me.Controls.Add(Me.btnNandDebugLog)
        Me.Controls.Add(Me.btnClearLogWindow)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.pgBar)
        Me.Controls.Add(Me.tabcntrlBottom)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "x360RGH v3"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabcntrlBottom.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuScanXellIP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdvanceGUI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWriteNand As System.Windows.Forms.Button
    Friend WithEvents btnFlashRGH As System.Windows.Forms.Button
    Friend WithEvents btnBuildImage As System.Windows.Forms.Button
    Friend WithEvents btnWriteECC As System.Windows.Forms.Button
    Friend WithEvents btnCreateECC As System.Windows.Forms.Button
    Friend WithEvents btn4GBrw As System.Windows.Forms.Button
    Friend WithEvents btnDumpNand As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCPUkey As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCompareNands As System.Windows.Forms.Button
    Friend WithEvents btnBrowseAdditional As System.Windows.Forms.Button
    Friend WithEvents btnBrowseSource As System.Windows.Forms.Button
    Friend WithEvents txtNandAdditional As System.Windows.Forms.TextBox
    Friend WithEvents txtNandSource As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConsoleDetected As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFlashConfig As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSaveCPUkey As System.Windows.Forms.Button
    Friend WithEvents txtConsoleSelected As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents radLPT As System.Windows.Forms.RadioButton
    Friend WithEvents radUSB As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tabcntrlBottom As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents radRGH As System.Windows.Forms.RadioButton
    Friend WithEvents radRGH2 As System.Windows.Forms.RadioButton
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rtbLog As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnClearLogWindow As System.Windows.Forms.Button
    Friend WithEvents btnNandDebugLog As System.Windows.Forms.Button
    Friend WithEvents btnDetectMB As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt1BLkey As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboDashVersions As System.Windows.Forms.ComboBox
    Friend WithEvents radJtag As System.Windows.Forms.RadioButton
    Friend WithEvents radGlitch As System.Windows.Forms.RadioButton
    Friend WithEvents radRetail As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnOfflineFuse As System.Windows.Forms.Button
    Friend WithEvents btnGetCPUkey As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMonitorCOM As System.Windows.Forms.Button
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents btnSimpleNandFlasher As System.Windows.Forms.Button
    Friend WithEvents bgworkerCompareNands As System.ComponentModel.BackgroundWorker
    Friend WithEvents cboNandProVer As System.Windows.Forms.ComboBox
    Friend WithEvents bgworkerGetKey As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrRestartGetKey As System.Windows.Forms.Timer
    Friend WithEvents bgworkerCreateECC As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgworkerWriteECC As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnCheckUpdateVersions As System.Windows.Forms.Button
    Private WithEvents cf0offset As System.Windows.Forms.TextBox
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents cf1offset As System.Windows.Forms.TextBox
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents slots As System.Windows.Forms.TextBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents cf1_pairingbox As System.Windows.Forms.TextBox
    Private WithEvents cf0_pairingbox As System.Windows.Forms.TextBox
    Private WithEvents cbb_pairingbox As System.Windows.Forms.TextBox
    Private WithEvents cba_pairingbox As System.Windows.Forms.TextBox
    Private WithEvents cf1_ldvbox As System.Windows.Forms.TextBox
    Private WithEvents cf0_ldvbox As System.Windows.Forms.TextBox
    Private WithEvents cbb_ldvbox As System.Windows.Forms.TextBox
    Private WithEvents cba_ldvbox As System.Windows.Forms.TextBox
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents cbb_ldvlbl As System.Windows.Forms.Label
    Private WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents cba_ldvlbl As System.Windows.Forms.Label
    Private WithEvents cg1 As System.Windows.Forms.TextBox
    Private WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents cf1 As System.Windows.Forms.TextBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Private WithEvents ce As System.Windows.Forms.TextBox
    Private WithEvents Label23 As System.Windows.Forms.Label
    Private WithEvents cg0 As System.Windows.Forms.TextBox
    Private WithEvents Label24 As System.Windows.Forms.Label
    Private WithEvents cf0 As System.Windows.Forms.TextBox
    Private WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents cd As System.Windows.Forms.TextBox
    Private WithEvents Label26 As System.Windows.Forms.Label
    Private WithEvents cb_b As System.Windows.Forms.TextBox
    Private WithEvents Label27 As System.Windows.Forms.Label
    Private WithEvents cb_a As System.Windows.Forms.TextBox
    Private WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnCheckKV As System.Windows.Forms.Button
    Public WithEvents fcrtreq As System.Windows.Forms.RichTextBox
    Public WithEvents label44 As System.Windows.Forms.Label
    Public WithEvents label45 As System.Windows.Forms.Label
    Public WithEvents currosig As System.Windows.Forms.TextBox
    Public WithEvents label46 As System.Windows.Forms.Label
    Public WithEvents currmfr As System.Windows.Forms.TextBox
    Public WithEvents label47 As System.Windows.Forms.Label
    Public WithEvents currcid As System.Windows.Forms.TextBox
    Public WithEvents currdvdkey As System.Windows.Forms.TextBox
    Public WithEvents label48 As System.Windows.Forms.Label
    Public WithEvents currregion As System.Windows.Forms.TextBox
    Public WithEvents label49 As System.Windows.Forms.Label
    Public WithEvents currserial As System.Windows.Forms.TextBox
    Public WithEvents label50 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox

End Class
