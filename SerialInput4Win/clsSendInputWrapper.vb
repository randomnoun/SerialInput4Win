Imports System.Runtime.InteropServices

' based on code downloaded from
' http://social.msdn.microsoft.com/Forums/eu/vblanguage/thread/41d58def-87cb-41e5-93a4-2ad7d1fb7e0b
' by knoxg on 2013-01-18


Public Class clsSendInputWrapper

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr

    ' wrap the Windows SendInput API

    Private Const VK_H As Short = 72
    Private Const VK_E As Short = 69
    Private Const VK_L As Short = 76
    Private Const VK_O As Short = 79

    Private Const KEYEVENTF_KEYUP As Integer = &H2
    Private Const INPUT_MOUSE As Integer = 0
    Private Const INPUT_KEYBOARD As Integer = 1
    Private Const INPUT_HARDWARE As Integer = 2

    Private Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Private Structure KEYBDINPUT
        Public wVk As Short
        Public wScan As Short
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Private Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    <StructLayout(LayoutKind.Explicit)> _
    Private Structure INPUT
        <FieldOffset(0)> _
        Public type As Integer
        <FieldOffset(4)> _
        Public mi As MOUSEINPUT
        <FieldOffset(4)> _
        Public ki As KEYBDINPUT
        <FieldOffset(4)> _
        Public hi As HARDWAREINPUT
    End Structure

    Private Declare Function SendInput Lib "user32" (ByVal nInputs As Integer, ByVal pInputs() As INPUT, ByVal cbSize As Integer) As Integer
    Private Declare Function AttachThreadInput Lib "user32" (ByVal idAttach As IntPtr, ByVal idAttachTo As IntPtr, ByVal fAttach As Boolean) As Boolean
    Private Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As IntPtr, ByVal lpwdProcessId As IntPtr) As IntPtr
    Private Declare Function GetCurrentThreadId Lib "kernel32" () As IntPtr

    Private Sub SendKey(ByVal bKey As Short)
        Dim GInput(1) As INPUT

        ' press the key
        GInput(0).type = INPUT_KEYBOARD
        GInput(0).ki.wVk = bKey
        GInput(0).ki.dwFlags = 0

        ' release the key
        GInput(1).type = INPUT_KEYBOARD
        GInput(1).ki.wVk = bKey
        GInput(1).ki.dwFlags = KEYEVENTF_KEYUP

        SendInput(2, GInput, Marshal.SizeOf(GetType(INPUT)))

    End Sub

    ' send keys to the current process' message queue
    Public Function SendKeys(ByVal strText As String) As Boolean
        Dim hwnd As IntPtr = GetForegroundWindow()

        Dim threadId As IntPtr = GetWindowThreadProcessId(hwnd, IntPtr.Zero)
        If threadId <> IntPtr.Zero Then
            If AttachThreadInput(GetCurrentThreadId(), threadId, True) Then
                Dim ch As String
                Dim i As Integer
                Dim k As Keys

                'SendKey(VK_H)
                'SendKey(VK_E)
                'SendKey(VK_L)
                'SendKey(VK_L)
                'SendKey(VK_O)

                Dim kc As KeysConverter = New KeysConverter()
                For i = 0 To strText.Length - 1
                    ch = strText.Substring(i, 1)
                    Try
                        If ch = "," Then
                            SendKey(Keys.Oemcomma)
                        ElseIf ch = " " Then
                            SendKey(Keys.Space)
                        Else
                            ' k = CType(kc.ConvertFromString(ch), Keys) ' doesn't handle commas
                            ' k = kc.getKey(ch)
                            k = kc.ConvertFrom(ch)
                            SendKey(k)
                        End If
                    Catch e As Exception
                        ' forget about the rest
                        AttachThreadInput(GetCurrentThreadId(), threadId, False)
                        MsgBox(e.GetType.ToString() & ": " & e.Message)
                        Return False
                    End Try
                Next

                AttachThreadInput(GetCurrentThreadId(), threadId, False)
                Return True
            End If
        End If
        Return False
    End Function

    '    Sub Main()
    '        Dim notepad As Process = Process.Start("notepad.exe")
    '        If notepad.WaitForInputIdle() Then
    '
    '           Dim hNotePad As IntPtr = notepad.MainWindowHandle
    '           Dim hNoteThread As IntPtr = GetWindowThreadProcessId(hNotePad, IntPtr.Zero)
    '
    '            If hNoteThread <> IntPtr.Zero Then
    '                If AttachThreadInput(GetCurrentThreadId(), hNoteThread, True) Then
    '                    SendKey(VK_H)
    '                    SendKey(VK_E)
    '                    SendKey(VK_L)
    '                    SendKey(VK_L)
    '                    SendKey(VK_O)
    '
    '                AttachThreadInput(GetCurrentThreadId(), hNotePad, False)
    '            End If
    '        End If
    '    End If
    'End Sub

End Class
