<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPscan
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
        Me.timeout = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.statustxt = New System.Windows.Forms.TextBox()
        Me.getipbtn = New System.Windows.Forms.Button()
        Me.baseipbox = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.startscanbtn = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.toip = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.fromip = New System.Windows.Forms.TextBox()
        Me.progbar = New System.Windows.Forms.ProgressBar()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'timeout
        '
        Me.timeout.Location = New System.Drawing.Point(86, 101)
        Me.timeout.MaxLength = 4
        Me.timeout.Name = "timeout"
        Me.timeout.Size = New System.Drawing.Size(65, 20)
        Me.timeout.TabIndex = 26
        Me.timeout.Text = "200"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(8, 104)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(72, 13)
        Me.label4.TabIndex = 27
        Me.label4.Text = "Ping Timeout:"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.statustxt)
        Me.groupBox2.Location = New System.Drawing.Point(11, 157)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(278, 48)
        Me.groupBox2.TabIndex = 25
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Status"
        '
        'statustxt
        '
        Me.statustxt.Location = New System.Drawing.Point(6, 19)
        Me.statustxt.Name = "statustxt"
        Me.statustxt.ReadOnly = True
        Me.statustxt.Size = New System.Drawing.Size(266, 20)
        Me.statustxt.TabIndex = 0
        '
        'getipbtn
        '
        Me.getipbtn.Location = New System.Drawing.Point(160, 71)
        Me.getipbtn.Name = "getipbtn"
        Me.getipbtn.Size = New System.Drawing.Size(130, 23)
        Me.getipbtn.TabIndex = 23
        Me.getipbtn.Text = "Get base IP"
        Me.getipbtn.UseVisualStyleBackColor = True
        '
        'baseipbox
        '
        Me.baseipbox.Location = New System.Drawing.Point(61, 73)
        Me.baseipbox.MaxLength = 12
        Me.baseipbox.Name = "baseipbox"
        Me.baseipbox.Size = New System.Drawing.Size(90, 20)
        Me.baseipbox.TabIndex = 22
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(8, 76)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(47, 13)
        Me.label3.TabIndex = 24
        Me.label3.Text = "Base IP:"
        '
        'startscanbtn
        '
        Me.startscanbtn.Location = New System.Drawing.Point(160, 99)
        Me.startscanbtn.Name = "startscanbtn"
        Me.startscanbtn.Size = New System.Drawing.Size(130, 23)
        Me.startscanbtn.TabIndex = 21
        Me.startscanbtn.Text = "Start scanning for Xell"
        Me.startscanbtn.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.toip)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.fromip)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(278, 53)
        Me.groupBox1.TabIndex = 20
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Scan Range"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(145, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(47, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Scan to:"
        '
        'toip
        '
        Me.toip.Location = New System.Drawing.Point(198, 19)
        Me.toip.MaxLength = 3
        Me.toip.Name = "toip"
        Me.toip.Size = New System.Drawing.Size(63, 20)
        Me.toip.TabIndex = 3
        Me.toip.Text = "100"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Scan from:"
        '
        'fromip
        '
        Me.fromip.Location = New System.Drawing.Point(76, 19)
        Me.fromip.MaxLength = 3
        Me.fromip.Name = "fromip"
        Me.fromip.Size = New System.Drawing.Size(63, 20)
        Me.fromip.TabIndex = 1
        Me.fromip.Text = "10"
        '
        'progbar
        '
        Me.progbar.Location = New System.Drawing.Point(12, 128)
        Me.progbar.Name = "progbar"
        Me.progbar.Size = New System.Drawing.Size(277, 23)
        Me.progbar.TabIndex = 28
        '
        'frmIPscan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 213)
        Me.Controls.Add(Me.progbar)
        Me.Controls.Add(Me.timeout)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.getipbtn)
        Me.Controls.Add(Me.baseipbox)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.startscanbtn)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIPscan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IP Scan"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents timeout As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents statustxt As System.Windows.Forms.TextBox
    Private WithEvents getipbtn As System.Windows.Forms.Button
    Public WithEvents baseipbox As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents startscanbtn As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents toip As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents fromip As System.Windows.Forms.TextBox
    Friend WithEvents progbar As System.Windows.Forms.ProgressBar
End Class
