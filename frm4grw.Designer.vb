<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm4grw
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCoronaDumpX = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.btnFlash = New System.Windows.Forms.Button()
        Me.btnDump = New System.Windows.Forms.Button()
        Me.cboList = New System.Windows.Forms.ComboBox()
        Me.opts = New System.Windows.Forms.GroupBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.chkIncFixed = New System.Windows.Forms.CheckBox()
        Me.groupSize = New System.Windows.Forms.GroupBox()
        Me.radFull = New System.Windows.Forms.RadioButton()
        Me.radSysOnly = New System.Windows.Forms.RadioButton()
        Me.pgBar = New System.Windows.Forms.ProgressBar()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.bgworkerDumper = New System.ComponentModel.BackgroundWorker()
        Me.Flasher = New System.ComponentModel.BackgroundWorker()
        Me.opts.SuspendLayout()
        Me.groupSize.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Nand Reads"
        '
        'cboCoronaDumpX
        '
        Me.cboCoronaDumpX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoronaDumpX.FormattingEnabled = True
        Me.cboCoronaDumpX.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboCoronaDumpX.Location = New System.Drawing.Point(119, 148)
        Me.cboCoronaDumpX.Name = "cboCoronaDumpX"
        Me.cboCoronaDumpX.Size = New System.Drawing.Size(65, 21)
        Me.cboCoronaDumpX.TabIndex = 23
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblStatus.Location = New System.Drawing.Point(21, 328)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblStatus.TabIndex = 22
        Me.lblStatus.Text = "Label1"
        '
        'btnAbort
        '
        Me.btnAbort.Location = New System.Drawing.Point(24, 262)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(371, 41)
        Me.btnAbort.TabIndex = 21
        Me.btnAbort.Text = "Abort Operation"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'btnFlash
        '
        Me.btnFlash.Location = New System.Drawing.Point(235, 176)
        Me.btnFlash.Name = "btnFlash"
        Me.btnFlash.Size = New System.Drawing.Size(160, 41)
        Me.btnFlash.TabIndex = 20
        Me.btnFlash.Text = "Flash"
        Me.btnFlash.UseVisualStyleBackColor = True
        '
        'btnDump
        '
        Me.btnDump.Location = New System.Drawing.Point(24, 176)
        Me.btnDump.Name = "btnDump"
        Me.btnDump.Size = New System.Drawing.Size(160, 41)
        Me.btnDump.TabIndex = 19
        Me.btnDump.Text = "Dump"
        Me.btnDump.UseVisualStyleBackColor = True
        '
        'cboList
        '
        Me.cboList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboList.FormattingEnabled = True
        Me.cboList.Location = New System.Drawing.Point(24, 121)
        Me.cboList.Name = "cboList"
        Me.cboList.Size = New System.Drawing.Size(371, 21)
        Me.cboList.TabIndex = 18
        '
        'opts
        '
        Me.opts.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.opts.Controls.Add(Me.btnUpdate)
        Me.opts.Controls.Add(Me.chkIncFixed)
        Me.opts.Location = New System.Drawing.Point(223, 12)
        Me.opts.Name = "opts"
        Me.opts.Size = New System.Drawing.Size(172, 76)
        Me.opts.TabIndex = 17
        Me.opts.TabStop = False
        Me.opts.Text = "Device Options"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(11, 44)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(131, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update Device List"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'chkIncFixed
        '
        Me.chkIncFixed.AutoSize = True
        Me.chkIncFixed.Location = New System.Drawing.Point(11, 21)
        Me.chkIncFixed.Name = "chkIncFixed"
        Me.chkIncFixed.Size = New System.Drawing.Size(131, 17)
        Me.chkIncFixed.TabIndex = 0
        Me.chkIncFixed.Text = "Include Fixed Devices"
        Me.chkIncFixed.UseVisualStyleBackColor = True
        '
        'groupSize
        '
        Me.groupSize.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.groupSize.Controls.Add(Me.radFull)
        Me.groupSize.Controls.Add(Me.radSysOnly)
        Me.groupSize.Location = New System.Drawing.Point(24, 12)
        Me.groupSize.Name = "groupSize"
        Me.groupSize.Size = New System.Drawing.Size(180, 76)
        Me.groupSize.TabIndex = 16
        Me.groupSize.TabStop = False
        Me.groupSize.Text = "Dump Size"
        '
        'radFull
        '
        Me.radFull.AutoSize = True
        Me.radFull.Location = New System.Drawing.Point(9, 43)
        Me.radFull.Name = "radFull"
        Me.radFull.Size = New System.Drawing.Size(111, 17)
        Me.radFull.TabIndex = 1
        Me.radFull.TabStop = True
        Me.radFull.Text = "Full Dump (3.5GB)"
        Me.radFull.UseVisualStyleBackColor = True
        '
        'radSysOnly
        '
        Me.radSysOnly.AutoSize = True
        Me.radSysOnly.Checked = True
        Me.radSysOnly.Location = New System.Drawing.Point(9, 20)
        Me.radSysOnly.Name = "radSysOnly"
        Me.radSysOnly.Size = New System.Drawing.Size(120, 17)
        Me.radSysOnly.TabIndex = 0
        Me.radSysOnly.TabStop = True
        Me.radSysOnly.Text = "System Only (48MB)"
        Me.radSysOnly.UseVisualStyleBackColor = True
        '
        'pgBar
        '
        Me.pgBar.Location = New System.Drawing.Point(24, 233)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(371, 23)
        Me.pgBar.TabIndex = 25
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'bgworkerDumper
        '
        Me.bgworkerDumper.WorkerReportsProgress = True
        '
        'Flasher
        '
        Me.Flasher.WorkerReportsProgress = True
        '
        'frm4grw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 351)
        Me.Controls.Add(Me.pgBar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboCoronaDumpX)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnFlash)
        Me.Controls.Add(Me.btnDump)
        Me.Controls.Add(Me.cboList)
        Me.Controls.Add(Me.opts)
        Me.Controls.Add(Me.groupSize)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm4grw"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "4G Read/Write"
        Me.opts.ResumeLayout(False)
        Me.opts.PerformLayout()
        Me.groupSize.ResumeLayout(False)
        Me.groupSize.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCoronaDumpX As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnAbort As System.Windows.Forms.Button
    Friend WithEvents btnFlash As System.Windows.Forms.Button
    Friend WithEvents btnDump As System.Windows.Forms.Button
    Friend WithEvents cboList As System.Windows.Forms.ComboBox
    Friend WithEvents opts As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents chkIncFixed As System.Windows.Forms.CheckBox
    Friend WithEvents groupSize As System.Windows.Forms.GroupBox
    Friend WithEvents radFull As System.Windows.Forms.RadioButton
    Friend WithEvents radSysOnly As System.Windows.Forms.RadioButton
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents bgworkerDumper As System.ComponentModel.BackgroundWorker
    Friend WithEvents Flasher As System.ComponentModel.BackgroundWorker
End Class
