<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuildImage
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
        Me.cancelbtn = New System.Windows.Forms.Button()
        Me.nandok = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.BigBlock64 = New System.Windows.Forms.RadioButton()
        Me.Trinity = New System.Windows.Forms.RadioButton()
        Me.Jasper512 = New System.Windows.Forms.RadioButton()
        Me.Jasper256 = New System.Windows.Forms.RadioButton()
        Me.Jasper16 = New System.Windows.Forms.RadioButton()
        Me.Opus = New System.Windows.Forms.RadioButton()
        Me.Falcon = New System.Windows.Forms.RadioButton()
        Me.Zephry = New System.Windows.Forms.RadioButton()
        Me.Xenon = New System.Windows.Forms.RadioButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'cancelbtn
        '
        Me.cancelbtn.Location = New System.Drawing.Point(117, 262)
        Me.cancelbtn.Name = "cancelbtn"
        Me.cancelbtn.Size = New System.Drawing.Size(69, 31)
        Me.cancelbtn.TabIndex = 42
        Me.cancelbtn.Text = "Cancel"
        Me.cancelbtn.UseVisualStyleBackColor = True
        '
        'nandok
        '
        Me.nandok.Location = New System.Drawing.Point(12, 262)
        Me.nandok.Name = "nandok"
        Me.nandok.Size = New System.Drawing.Size(69, 31)
        Me.nandok.TabIndex = 41
        Me.nandok.Text = "O.k"
        Me.nandok.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(153, 9)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(33, 15)
        Me.LinkLabel1.TabIndex = 40
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Help"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 196)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(59, 17)
        Me.RadioButton1.TabIndex = 39
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Corona"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'BigBlock64
        '
        Me.BigBlock64.AutoSize = True
        Me.BigBlock64.Location = New System.Drawing.Point(12, 219)
        Me.BigBlock64.Name = "BigBlock64"
        Me.BigBlock64.Size = New System.Drawing.Size(99, 17)
        Me.BigBlock64.TabIndex = 38
        Me.BigBlock64.TabStop = True
        Me.BigBlock64.Text = "Big Block 64mb"
        Me.BigBlock64.UseVisualStyleBackColor = True
        '
        'Trinity
        '
        Me.Trinity.AutoSize = True
        Me.Trinity.Location = New System.Drawing.Point(12, 173)
        Me.Trinity.Name = "Trinity"
        Me.Trinity.Size = New System.Drawing.Size(53, 17)
        Me.Trinity.TabIndex = 37
        Me.Trinity.TabStop = True
        Me.Trinity.Text = "Trinity"
        Me.Trinity.UseVisualStyleBackColor = True
        '
        'Jasper512
        '
        Me.Jasper512.AutoSize = True
        Me.Jasper512.Location = New System.Drawing.Point(12, 150)
        Me.Jasper512.Name = "Jasper512"
        Me.Jasper512.Size = New System.Drawing.Size(91, 17)
        Me.Jasper512.TabIndex = 36
        Me.Jasper512.TabStop = True
        Me.Jasper512.Text = "Jasper 512mb"
        Me.Jasper512.UseVisualStyleBackColor = True
        '
        'Jasper256
        '
        Me.Jasper256.AutoSize = True
        Me.Jasper256.Location = New System.Drawing.Point(12, 127)
        Me.Jasper256.Name = "Jasper256"
        Me.Jasper256.Size = New System.Drawing.Size(91, 17)
        Me.Jasper256.TabIndex = 35
        Me.Jasper256.TabStop = True
        Me.Jasper256.Text = "Jasper 256mb"
        Me.Jasper256.UseVisualStyleBackColor = True
        '
        'Jasper16
        '
        Me.Jasper16.AutoSize = True
        Me.Jasper16.Location = New System.Drawing.Point(12, 104)
        Me.Jasper16.Name = "Jasper16"
        Me.Jasper16.Size = New System.Drawing.Size(85, 17)
        Me.Jasper16.TabIndex = 34
        Me.Jasper16.TabStop = True
        Me.Jasper16.Text = "Jasper 16mb"
        Me.Jasper16.UseVisualStyleBackColor = True
        '
        'Opus
        '
        Me.Opus.AutoSize = True
        Me.Opus.Location = New System.Drawing.Point(12, 81)
        Me.Opus.Name = "Opus"
        Me.Opus.Size = New System.Drawing.Size(50, 17)
        Me.Opus.TabIndex = 33
        Me.Opus.TabStop = True
        Me.Opus.Text = "Opus"
        Me.Opus.UseVisualStyleBackColor = True
        '
        'Falcon
        '
        Me.Falcon.AutoSize = True
        Me.Falcon.Location = New System.Drawing.Point(12, 58)
        Me.Falcon.Name = "Falcon"
        Me.Falcon.Size = New System.Drawing.Size(57, 17)
        Me.Falcon.TabIndex = 32
        Me.Falcon.TabStop = True
        Me.Falcon.Text = "Falcon"
        Me.Falcon.UseVisualStyleBackColor = True
        '
        'Zephry
        '
        Me.Zephry.AutoSize = True
        Me.Zephry.Location = New System.Drawing.Point(12, 35)
        Me.Zephry.Name = "Zephry"
        Me.Zephry.Size = New System.Drawing.Size(58, 17)
        Me.Zephry.TabIndex = 31
        Me.Zephry.TabStop = True
        Me.Zephry.Text = "Zephry"
        Me.Zephry.UseVisualStyleBackColor = True
        '
        'Xenon
        '
        Me.Xenon.AutoSize = True
        Me.Xenon.Location = New System.Drawing.Point(12, 12)
        Me.Xenon.Name = "Xenon"
        Me.Xenon.Size = New System.Drawing.Size(56, 17)
        Me.Xenon.TabIndex = 30
        Me.Xenon.TabStop = True
        Me.Xenon.Text = "Xenon"
        Me.Xenon.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'frmBuildImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(208, 301)
        Me.Controls.Add(Me.cancelbtn)
        Me.Controls.Add(Me.nandok)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.BigBlock64)
        Me.Controls.Add(Me.Trinity)
        Me.Controls.Add(Me.Jasper512)
        Me.Controls.Add(Me.Jasper256)
        Me.Controls.Add(Me.Jasper16)
        Me.Controls.Add(Me.Opus)
        Me.Controls.Add(Me.Falcon)
        Me.Controls.Add(Me.Zephry)
        Me.Controls.Add(Me.Xenon)
        Me.Name = "frmBuildImage"
        Me.Text = "frmBuildImage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cancelbtn As System.Windows.Forms.Button
    Friend WithEvents nandok As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents BigBlock64 As System.Windows.Forms.RadioButton
    Friend WithEvents Trinity As System.Windows.Forms.RadioButton
    Friend WithEvents Jasper512 As System.Windows.Forms.RadioButton
    Friend WithEvents Jasper256 As System.Windows.Forms.RadioButton
    Friend WithEvents Jasper16 As System.Windows.Forms.RadioButton
    Friend WithEvents Opus As System.Windows.Forms.RadioButton
    Friend WithEvents Falcon As System.Windows.Forms.RadioButton
    Friend WithEvents Zephry As System.Windows.Forms.RadioButton
    Friend WithEvents Xenon As System.Windows.Forms.RadioButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
