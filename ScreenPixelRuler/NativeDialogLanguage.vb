Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Public Class NativeDialogHandler
    Private Delegate Function HookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Delegate Function EnumChildProc(ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As Boolean
    Private Const WH_CALLWNDPROCRET As Integer = 12
    Private Const WM_DESTROY As Integer = &H2
    Private Const WM_INITDIALOG As Integer = &H110
    Private Const WM_TIMER As Integer = &H113
    Private Const WM_USER As Integer = &H400
    Private Const DM_GETDEFID As Integer = WM_USER + 0
    Private Const Button_OK As Integer = 1
    Private Const Button_Cancel As Integer = 2
    Private Const Button_Abort As Integer = 3
    Private Const Button_Retry As Integer = 4
    Private Const Button_Ignore As Integer = 5
    Private Const Button_Yes As Integer = 6
    Private Const Button_No As Integer = 7
    Private Const Button_DefineCustomColours = 719
    Private Const Button_AddtoCustomColours = 712
    Private Const Label_BasicColours = 65535
    Private Const Label_CustomColours = 65535
    Private Const Label_Red = 726
    Private Const Label_Green = 727
    Private Const Label_Blue = 728
    Private Const Label_Colour = 730
    Private Const Label_Solid = 731

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As HookProc, ByVal hInstance As IntPtr, ByVal threadId As Integer) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function UnhookWindowsHookEx(ByVal idHook As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function CallNextHookEx(ByVal idHook As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="GetWindowTextLengthW", CharSet:=CharSet.Unicode)>
    Private Shared Function GetWindowTextLength(ByVal hWnd As IntPtr) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="GetWindowTextW", CharSet:=CharSet.Unicode)>
    Private Shared Function GetWindowText(ByVal hWnd As IntPtr, ByVal text As StringBuilder, ByVal maxLength As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function EndDialog(ByVal hDlg As IntPtr, ByVal nResult As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function EnumChildWindows(ByVal hWndParent As IntPtr, ByVal lpEnumFunc As EnumChildProc, ByVal lParam As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll", EntryPoint:="GetClassNameW", CharSet:=CharSet.Unicode)>
    Private Shared Function GetClassName(ByVal hWnd As IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetDlgCtrlID(ByVal hwndCtl As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetDlgItem(ByVal hDlg As IntPtr, ByVal nIDDlgItem As Integer) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="SetWindowTextW", CharSet:=CharSet.Unicode)>
    Private Shared Function SetWindowText(ByVal hWnd As IntPtr, ByVal lpString As String) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CWPRETSTRUCT
        Public lResult As IntPtr
        Public lParam As IntPtr
        Public wParam As IntPtr
        Public message As UInteger
        Public hwnd As IntPtr
    End Structure

    Private Shared hookaProc As HookProc
    Private Shared enumProc As EnumChildProc
    <ThreadStatic>
    Private Shared hHook As IntPtr
    <ThreadStatic>
    Private Shared nButton As Integer
    Public Shared OK As String = "&OK"
    Public Shared Cancel As String = "&Cancel"
    Public Shared Abort As String = "&Abort"
    Public Shared Retry As String = "&Retry"
    Public Shared Ignore As String = "&Ignore"
    Public Shared Yes As String = "&Yes"
    Public Shared No As String = "&No"
    Public Shared DefineCustomColours = "Define Custo&m Colours >>"
    Public Shared AddToCustomColours = "&Add to Custom Colours"
    Public Shared Red = "&Red"
    Public Shared Green = "&Green"
    Public Shared Blue = "Bl&ue"
    Public Shared Colour = "Colour"

    Shared Sub New()
        hookaProc = New HookProc(AddressOf MessageBoxHookProc)
        enumProc = New EnumChildProc(AddressOf MessageBoxEnumProc)
        hHook = IntPtr.Zero
    End Sub

    Public Shared Sub Register()
        If hHook <> IntPtr.Zero Then Throw New NotSupportedException("One hook per thread allowed.")
        hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, hookaProc, IntPtr.Zero, AppDomain.GetCurrentThreadId())
    End Sub

    Public Shared Sub Unregister()
        If hHook <> IntPtr.Zero Then
            UnhookWindowsHookEx(hHook)
            hHook = IntPtr.Zero
        End If
    End Sub

    Private Shared Function MessageBoxHookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        If nCode < 0 Then Return CallNextHookEx(hHook, nCode, wParam, lParam)
        Dim msg As CWPRETSTRUCT = CType(Marshal.PtrToStructure(lParam, GetType(CWPRETSTRUCT)), CWPRETSTRUCT)
        Dim hook As IntPtr = hHook

        If msg.message = WM_INITDIALOG Then
            Dim nLength As Integer = GetWindowTextLength(msg.hwnd)
            Dim className As StringBuilder = New StringBuilder(10)
            GetClassName(msg.hwnd, className, className.Capacity)

            If className.ToString() = "#32770" Then
                nButton = 0
                EnumChildWindows(msg.hwnd, enumProc, IntPtr.Zero)

                If nButton = 1 Then
                    Dim hButton As IntPtr = GetDlgItem(msg.hwnd, Button_Cancel)
                    If hButton <> IntPtr.Zero Then SetWindowText(hButton, OK)
                End If
            End If
        End If

        Return CallNextHookEx(hook, nCode, wParam, lParam)
    End Function

    Private Shared Function MessageBoxEnumProc(ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As Boolean
        Dim className As StringBuilder = New StringBuilder(10)
        GetClassName(hWnd, className, className.Capacity)

        If className.ToString() = "Button" Then
            Dim ctlId As Integer = GetDlgCtrlID(hWnd)

            Select Case ctlId
                Case Button_OK
                    SetWindowText(hWnd, OK)
                Case Button_Cancel
                    SetWindowText(hWnd, Cancel)
                Case Button_Abort
                    SetWindowText(hWnd, Abort)
                Case Button_Retry
                    SetWindowText(hWnd, Retry)
                Case Button_Ignore
                    SetWindowText(hWnd, Ignore)
                Case Button_Yes
                    SetWindowText(hWnd, Yes)
                Case Button_No
                    SetWindowText(hWnd, No)
                Case Button_AddtoCustomColours
                    SetWindowText(hWnd, AddToCustomColours)
                Case Button_DefineCustomColours
                    SetWindowText(hWnd, DefineCustomColours)
            End Select

            nButton += 1
        End If
        If className.ToString() = "Static" Then
            Dim ctlId As Integer = GetDlgCtrlID(hWnd)

            Select Case ctlId
                Case Label_Red
                    SetWindowText(hWnd, Red)
                Case Label_Green
                    SetWindowText(hWnd, Green)
                Case Label_Blue
                    SetWindowText(hWnd, Blue)
                Case Label_BasicColours
                    SetWindowText(hWnd, "")
                Case Label_Colour
                    SetWindowText(hWnd, Colour)
                Case Label_Solid
                    SetWindowText(hWnd, "")
            End Select
        End If

        Return True
    End Function
End Class
