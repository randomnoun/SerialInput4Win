<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSerialInput4Win
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSerialInput4Win))
        Me.chkEnabled = New System.Windows.Forms.CheckBox
        Me.cmbPort = New System.Windows.Forms.ComboBox
        Me.cmbBaud = New System.Windows.Forms.ComboBox
        Me.cmbDataBits = New System.Windows.Forms.ComboBox
        Me.cmbParity = New System.Windows.Forms.ComboBox
        Me.cmbFlowControl = New System.Windows.Forms.ComboBox
        Me.lblPort = New System.Windows.Forms.Label
        Me.lblBaud = New System.Windows.Forms.Label
        Me.lblDataBits = New System.Windows.Forms.Label
        Me.lblParity = New System.Windows.Forms.Label
        Me.lblFlowControl = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.cmbStopBits = New System.Windows.Forms.ComboBox
        Me.lblStopBits = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTestInput = New System.Windows.Forms.TextBox
        Me.lblVersion = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(13, 13)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(177, 17)
        Me.chkEnabled.TabIndex = 0
        Me.chkEnabled.Text = "&Enable Serial Input for Windows"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'cmbPort
        '
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(141, 41)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(121, 21)
        Me.cmbPort.TabIndex = 2
        '
        'cmbBaud
        '
        Me.cmbBaud.FormattingEnabled = True
        Me.cmbBaud.Location = New System.Drawing.Point(141, 69)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(121, 21)
        Me.cmbBaud.TabIndex = 4
        '
        'cmbDataBits
        '
        Me.cmbDataBits.FormattingEnabled = True
        Me.cmbDataBits.Location = New System.Drawing.Point(141, 97)
        Me.cmbDataBits.Name = "cmbDataBits"
        Me.cmbDataBits.Size = New System.Drawing.Size(121, 21)
        Me.cmbDataBits.TabIndex = 6
        '
        'cmbParity
        '
        Me.cmbParity.FormattingEnabled = True
        Me.cmbParity.Location = New System.Drawing.Point(141, 152)
        Me.cmbParity.Name = "cmbParity"
        Me.cmbParity.Size = New System.Drawing.Size(121, 21)
        Me.cmbParity.TabIndex = 10
        '
        'cmbFlowControl
        '
        Me.cmbFlowControl.FormattingEnabled = True
        Me.cmbFlowControl.Location = New System.Drawing.Point(141, 180)
        Me.cmbFlowControl.Name = "cmbFlowControl"
        Me.cmbFlowControl.Size = New System.Drawing.Size(121, 21)
        Me.cmbFlowControl.TabIndex = 12
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(31, 44)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(55, 13)
        Me.lblPort.TabIndex = 1
        Me.lblPort.Text = "COM &port:"
        '
        'lblBaud
        '
        Me.lblBaud.AutoSize = True
        Me.lblBaud.Location = New System.Drawing.Point(31, 72)
        Me.lblBaud.Name = "lblBaud"
        Me.lblBaud.Size = New System.Drawing.Size(82, 13)
        Me.lblBaud.TabIndex = 3
        Me.lblBaud.Text = "&Baud (bits/sec):"
        '
        'lblDataBits
        '
        Me.lblDataBits.AutoSize = True
        Me.lblDataBits.Location = New System.Drawing.Point(31, 100)
        Me.lblDataBits.Name = "lblDataBits"
        Me.lblDataBits.Size = New System.Drawing.Size(52, 13)
        Me.lblDataBits.TabIndex = 5
        Me.lblDataBits.Text = "&Data bits:"
        '
        'lblParity
        '
        Me.lblParity.AutoSize = True
        Me.lblParity.Location = New System.Drawing.Point(31, 155)
        Me.lblParity.Name = "lblParity"
        Me.lblParity.Size = New System.Drawing.Size(36, 13)
        Me.lblParity.TabIndex = 9
        Me.lblParity.Text = "Pa&rity:"
        '
        'lblFlowControl
        '
        Me.lblFlowControl.AutoSize = True
        Me.lblFlowControl.Location = New System.Drawing.Point(31, 183)
        Me.lblFlowControl.Name = "lblFlowControl"
        Me.lblFlowControl.Size = New System.Drawing.Size(67, 13)
        Me.lblFlowControl.TabIndex = 11
        Me.lblFlowControl.Text = "&Flow control:"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(187, 301)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(106, 301)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 14
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmbStopBits
        '
        Me.cmbStopBits.FormattingEnabled = True
        Me.cmbStopBits.Location = New System.Drawing.Point(141, 125)
        Me.cmbStopBits.Name = "cmbStopBits"
        Me.cmbStopBits.Size = New System.Drawing.Size(121, 21)
        Me.cmbStopBits.TabIndex = 8
        '
        'lblStopBits
        '
        Me.lblStopBits.AutoSize = True
        Me.lblStopBits.Location = New System.Drawing.Point(31, 128)
        Me.lblStopBits.Name = "lblStopBits"
        Me.lblStopBits.Size = New System.Drawing.Size(51, 13)
        Me.lblStopBits.TabIndex = 7
        Me.lblStopBits.Text = "&Stop bits:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTestInput)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 215)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 75)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test input"
        '
        'txtTestInput
        '
        Me.txtTestInput.BackColor = System.Drawing.SystemColors.Control
        Me.txtTestInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTestInput.Location = New System.Drawing.Point(5, 18)
        Me.txtTestInput.MaximumSize = New System.Drawing.Size(215, 50)
        Me.txtTestInput.MinimumSize = New System.Drawing.Size(215, 50)
        Me.txtTestInput.Multiline = True
        Me.txtTestInput.Name = "txtTestInput"
        Me.txtTestInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTestInput.Size = New System.Drawing.Size(215, 50)
        Me.txtTestInput.TabIndex = 0
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(213, 13)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(49, 13)
        Me.lblVersion.TabIndex = 17
        Me.lblVersion.Text = "ver 0.0.1"
        '
        'frmSerialInput4Win
        '
        Me.AcceptButton = Me.cmdApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(283, 336)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblStopBits)
        Me.Controls.Add(Me.cmbStopBits)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblFlowControl)
        Me.Controls.Add(Me.lblParity)
        Me.Controls.Add(Me.lblDataBits)
        Me.Controls.Add(Me.lblBaud)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.cmbFlowControl)
        Me.Controls.Add(Me.cmbParity)
        Me.Controls.Add(Me.cmbDataBits)
        Me.Controls.Add(Me.cmbBaud)
        Me.Controls.Add(Me.cmbPort)
        Me.Controls.Add(Me.chkEnabled)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSerialInput4Win"
        Me.Text = "Serial Input for Windows"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataBits As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFlowControl As System.Windows.Forms.ComboBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents lblBaud As System.Windows.Forms.Label
    Friend WithEvents lblDataBits As System.Windows.Forms.Label
    Friend WithEvents lblParity As System.Windows.Forms.Label
    Friend WithEvents lblFlowControl As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmbStopBits As System.Windows.Forms.ComboBox
    Friend WithEvents lblStopBits As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTestInput As System.Windows.Forms.TextBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label

End Class
