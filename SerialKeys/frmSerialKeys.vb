Imports System
Imports System.IO.Ports
Imports System.Reflection

' TODO those incredibly syntactically verbose .NET comments

Public Class frmSerialKeys

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr

    Dim WithEvents serialKeys As clsSerialKeys
    Dim sendInputWrapper As New clsSendInputWrapper

    Dim strBuffer As String = ""
    Dim boolWasOpen As Boolean = False

    Private Sub serialKeysDataReceivedHandler(ByVal strText As String) Handles serialKeys.DataRecieved
        If Me.Handle = GetForegroundWindow Then
            strBuffer = strBuffer & strText
            txtTestInput.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            txtTestInput.Text = strBuffer
            txtTestInput.Focus()
            txtTestInput.SelectionStart = txtTestInput.Text.Length
            txtTestInput.SelectionLength = 0
            txtTestInput.ScrollToCaret()
        Else
            ' add to input buffer
            ' this probably belongs in the clsSerialKeys class
            If sendInputWrapper.SendKeys(strText) Then
                ' sent OK
            Else
                ' probably log this instead
                MsgBox("Could not send text '" & strText & "'")
            End If
        End If
    End Sub

    Private Sub frmSerialKeys_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        serialKeys = New clsSerialKeys()

        subSetInitialComboValues()
        subSetFromCommandLineArgs()

        txtTestInput.Text = "Set connection settings and hit apply to see test input"
        txtTestInput.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Italic)
        subSetEnabled()

        If chkEnabled.Checked Then
            cmdApply_Click(Me, Nothing)
        End If

    End Sub

    Private Sub subSetInitialComboValues()

        Dim strPorts As String() = SerialPort.GetPortNames()
        Dim strPort As String
        For Each strPort In strPorts
            cmbPort.Items.Add(strPort)
        Next strPort

        cmbParity.Items.Add(Parity.None.ToString())
        cmbParity.Items.Add(Parity.Even.ToString())
        cmbParity.Items.Add(Parity.Odd.ToString())
        cmbParity.Items.Add(Parity.Mark.ToString())
        cmbParity.Items.Add(Parity.Space.ToString())
        cmbParity.SelectedIndex = 0

        cmbDataBits.Items.Add(8)
        cmbDataBits.Items.Add(7)
        cmbDataBits.Items.Add(6)
        cmbDataBits.Items.Add(5)
        cmbDataBits.SelectedIndex = 0

        ' cmbStopBits.Items.Add(StopBits.None.ToString()) ' illegal value
        cmbStopBits.Items.Add(StopBits.One.ToString())
        cmbStopBits.Items.Add(StopBits.OnePointFive.ToString())
        cmbStopBits.Items.Add(StopBits.Two.ToString())
        cmbStopBits.SelectedIndex = 0

        cmbFlowControl.Items.Add(Handshake.None.ToString())
        cmbFlowControl.Items.Add(Handshake.RequestToSendXOnXOff.ToString())
        cmbFlowControl.Items.Add(Handshake.RequestToSend.ToString())
        cmbFlowControl.Items.Add(Handshake.XOnXOff.ToString())
        cmbFlowControl.SelectedIndex = 0
    End Sub

    Private Sub subSetFromCommandLineArgs()
        Dim strArgs() As String, intCount As Integer
        Dim boolSet As Boolean = False
        strArgs = System.Environment.GetCommandLineArgs
        ' TODO set to local vars first, then to form
        ' (to ensure correct ordering)
        ' TODO intCount checking on last arg
        For intCount = 1 To UBound(strArgs)  ' 0th arg is filename
            Select Case strArgs(intCount).ToLower
                Case "-port", "-p"
                    intCount = intCount + 1
                    cmbPort.SelectedItem = strArgs(intCount)
                    cmbPort_SelectedIndexChanged(Me, Nothing)
                    boolSet = True
                Case "-baud", "-b"
                    intCount = intCount + 1
                    cmbBaud.SelectedItem = strArgs(intCount)
                    boolSet = True
                Case "-data", "-d"
                    intCount = intCount + 1
                    cmbDataBits.SelectedItem = strArgs(intCount)
                    boolSet = True
                Case "-stop", "-s"
                    intCount = intCount + 1
                    cmbStopBits.SelectedItem = strArgs(intCount)
                    boolSet = True
                Case "-parity", "-r"
                    intCount = intCount + 1
                    cmbParity.SelectedItem = strArgs(intCount)
                    boolSet = True
                Case "-flowcontrol", "-flow", "-f"
                    intCount = intCount + 1
                    cmbFlowControl.SelectedItem = strArgs(intCount)
                    boolSet = True
                Case Else
                    ' some error message
            End Select
        Next intCount

        If boolSet Then chkEnabled.Checked = True

    End Sub

    Private Sub chkEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnabled.CheckedChanged
        subSetEnabled()
    End Sub

    Private Sub subSetEnabled()
        cmbPort.Enabled = chkEnabled.Checked
        cmbBaud.Enabled = chkEnabled.Checked And cmbPort.SelectedItem IsNot Nothing
        cmbDataBits.Enabled = chkEnabled.Checked And cmbPort.SelectedItem IsNot Nothing
        cmbStopBits.Enabled = chkEnabled.Checked And cmbPort.SelectedItem IsNot Nothing
        cmbParity.Enabled = chkEnabled.Checked And cmbPort.SelectedItem IsNot Nothing
        cmbFlowControl.Enabled = chkEnabled.Checked And cmbPort.SelectedItem IsNot Nothing
        'cmdTestInput.Enabled = chkEnabled.Checked And cmbPort.SelectedItem IsNot Nothing
    End Sub


    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        ' MsgBox("Applying settings...")
        Dim strError As String
        serialKeys.Disconnect()
        If cmbPort.Enabled And cmbPort.SelectedItem IsNot Nothing Then
            strError = ""
            If cmbPort.SelectedItem Is Nothing Then strError = "You must select a port"
            If cmbBaud.SelectedItem Is Nothing Then strError = "You must select a baud"
            If cmbParity.SelectedItem Is Nothing Then strError = "You must select a parity"
            If cmbDataBits.SelectedItem Is Nothing Then strError = "You must select number of data bits"
            If cmbStopBits.SelectedItem Is Nothing Then strError = "You must select number of stop bits"
            If cmbFlowControl.SelectedItem Is Nothing Then strError = "You must select a flow control"

            If strError <> "" Then
                MsgBox(strError, MsgBoxStyle.Information, "Please check settings")
                Exit Sub
            End If


            boolWasOpen = True
            serialKeys.Connect(cmbPort.SelectedItem, _
              Integer.Parse(cmbBaud.SelectedItem), _
              CType([Enum].Parse(GetType(Parity), cmbParity.SelectedItem), Parity), _
              Integer.Parse(cmbDataBits.SelectedItem), _
              CType([Enum].Parse(GetType(StopBits), cmbStopBits.SelectedItem), StopBits), _
              CType([Enum].Parse(GetType(Handshake), cmbFlowControl.SelectedItem), Handshake))
            MsgBox("SerialKeys listening on " & cmbPort.SelectedItem)

            txtTestInput.Text = "Waiting for input..."
            txtTestInput.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Italic)

        Else
            ' could retain buffer, but this is probably what the user wants
            boolWasOpen = False
            strBuffer = ""
            MsgBox("SerialKeys disabled")

            txtTestInput.Text = "Set connection settings and hit apply to see test input"
            txtTestInput.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Italic)
        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Application.Exit()

    End Sub

    ' no longer used
    Private Sub cmdTestInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' TODO: open up a separate window with text appearing as it's received

        If Not boolWasOpen Then
            MsgBox("You must click Apply to set connection settings before input can be tested")
        Else
            Dim strText As String = strBuffer
            strBuffer = ""
            MsgBox("Input received since last test: '" & strText & "'")
        End If
    End Sub

    Private Sub frmSerialKeys_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If serialKeys.IsOpen Then serialKeys.Disconnect()
    End Sub

    Private Sub cmbPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPort.SelectedIndexChanged
        If cmbPort.SelectedItem Is Nothing Then
            Exit Sub
        End If

        ' update baud rates
        ' via http://stackoverflow.com/questions/1165692/how-to-programatically-find-all-available-baudrates-in-c-sharp-serialport-class
        Dim objPort As SerialPort
        Dim p As Object
        Dim strPortName As String
        Dim bv As Int32

        strPortName = cmbPort.SelectedItem
        objPort = New SerialPort(strPortName)
        Try
            objPort.Open()
        Catch ex As System.IO.IOException
            MsgBox("There was an error opening the port: " & ex.Message)
            cmbPort.SelectedItem = Nothing
            subSetEnabled()
            Exit Sub
        Catch ex As System.UnauthorizedAccessException
            MsgBox("Cannot open port: " & ex.Message)
            cmbPort.SelectedItem = Nothing
            subSetEnabled()
            Exit Sub
        Catch ex As Exception
            MsgBox("Cannot open port: (" & ex.GetType().ToString() & ") " & ex.Message)
            cmbPort.SelectedItem = Nothing
            subSetEnabled()
            Exit Sub
        End Try

        subSetEnabled()

        'Message = "The port 'COM1' does not exist."
        'Source = "System"
        p = objPort.BaseStream.GetType().GetField("commProp", BindingFlags.Instance Or BindingFlags.NonPublic).GetValue(objPort.BaseStream)
        bv = p.GetType().GetField("dwSettableBaud", BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public).GetValue(p)
        objPort.Close()

        ' from http://msdn.microsoft.com/en-us/library/aa363189%28VS.85%29.aspx
        cmbBaud.Items.Clear()
        Dim intSelected As Integer = 0
        If (bv And &H1 > 0) Then cmbBaud.Items.Add("75")
        If (bv And &H2 > 0) Then cmbBaud.Items.Add("110")
        If (bv And &H4 > 0) Then cmbBaud.Items.Add("134.5") ' ?
        If (bv And &H8 > 0) Then cmbBaud.Items.Add("150")
        If (bv And &H10 > 0) Then cmbBaud.Items.Add("300")
        If (bv And &H20 > 0) Then cmbBaud.Items.Add("600")
        If (bv And &H40 > 0) Then cmbBaud.Items.Add("1200")
        If (bv And &H80 > 0) Then cmbBaud.Items.Add("1800")
        If (bv And &H100 > 0) Then cmbBaud.Items.Add("2400")
        If (bv And &H200 > 0) Then cmbBaud.Items.Add("4800")
        If (bv And &H400 > 0) Then cmbBaud.Items.Add("7200")
        If (bv And &H800 > 0) Then cmbBaud.Items.Add("9600") : intSelected = cmbBaud.Items.Count - 1 ' default to this
        If (bv And &H1000 > 0) Then cmbBaud.Items.Add("14400")
        If (bv And &H2000 > 0) Then cmbBaud.Items.Add("19200")
        If (bv And &H4000 > 0) Then cmbBaud.Items.Add("38400")
        If (bv And &H8000 > 0) Then cmbBaud.Items.Add("56000")
        If (bv And &H40000 > 0) Then cmbBaud.Items.Add("57600")
        If (bv And &H20000 > 0) Then cmbBaud.Items.Add("115200")
        If (bv And &H10000 > 0) Then cmbBaud.Items.Add("128000")
        cmbBaud.SelectedIndex = intSelected
    End Sub
End Class
