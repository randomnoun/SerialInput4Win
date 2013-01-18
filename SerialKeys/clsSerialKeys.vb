Imports System.IO.Ports
Imports System.Text

' based on code downloaded from 
' http://stackoverflow.com/questions/329865/creating-a-serial-port-in-code-in-vb-net
' by knoxg on 2013-01-18

Public Delegate Sub DataReceivedHandler(ByVal data As String)

Public Class clsSerialKeys

    ' Public Delegate Sub StringSubPointer(ByVal Buffer As String)

    Dim WithEvents comPort As New SerialPort ' can hopefully reassign portNames

    Public Event DataRecieved As DataReceivedHandler

    'Private Sub Receiver(ByVal sender As Object, _
    '    ByVal e As SerialDataReceivedEventArgs) Handles COMPort.DataReceived
    '    Me.BeginInvoke(New StringSubPointer(AddressOf Display), COMPort.ReadLine)
    'End Sub

    'Private Sub Display(ByVal Buffer As String)
    '    strReceived.AppendText(Buffer)
    'End Sub

    Public Sub Connect(ByVal strPortName As String, ByVal intBaud As Integer, _
        ByVal parity As Parity, ByVal intDataBits As Integer, _
        ByVal stopBits As StopBits, ByVal handshake As Handshake)

        Disconnect()
        ' comPort = New SerialPort
        comPort.PortName = strPortName
        comPort.BaudRate = intBaud
        comPort.Parity = parity
        comPort.DataBits = intDataBits
        comPort.StopBits = stopBits
        comPort.Handshake = handshake
        Try
            ' comPort = My.Computer.Ports.OpenSerialPort("COM5", 9600)
            comPort.Open()
        Catch
        End Try

    End Sub

    Public Function IsOpen() As Boolean
        If comPort IsNot Nothing Then Return comPort.IsOpen
        Return False
    End Function

    Public Sub Disconnect()
        If comPort IsNot Nothing AndAlso comPort.IsOpen Then
            comPort.Close()
        End If
    End Sub

    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles comPort.DataReceived
        Dim str As String = ""
        Dim bytesRead As Integer
        If e.EventType = SerialData.Chars Then
            Do
                Dim bytecount As Integer = comPort.BytesToRead
                If bytecount = 0 Then
                    Exit Do
                End If
                Dim byteBuffer(bytecount) As Byte
                bytesRead = comPort.Read(byteBuffer, 0, bytecount)
                str = str & System.Text.Encoding.ASCII.GetString(byteBuffer, 0, bytesRead)
            Loop
        End If
        RaiseEvent DataRecieved(str)
    End Sub

End Class
