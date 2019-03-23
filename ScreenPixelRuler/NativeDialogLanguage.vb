Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Public Class MessageBoxManager
        Private Delegate Function HookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        Private Delegate Function EnumChildProc(ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As Boolean
        Private Const WH_CALLWNDPROCRET As Integer = 12
        Private Const WM_DESTROY As Integer = &H2
        Private Const WM_INITDIALOG As Integer = &H110
        Private Const WM_TIMER As Integer = &H113
        Private Const WM_USER As Integer = &H400
        Private Const DM_GETDEFID As Integer = WM_USER + 0
        Private Const MBOK As Integer = 1
        Private Const MBCancel As Integer = 2
        Private Const MBAbort As Integer = 3
        Private Const MBRetry As Integer = 4
        Private Const MBIgnore As Integer = 5
        Private Const MBYes As Integer = 6
        Private Const MBNo As Integer = 7
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
                        Dim hButton As IntPtr = GetDlgItem(msg.hwnd, MBCancel)
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
                    Case MBOK
                        SetWindowText(hWnd, OK)
                    Case MBCancel
                        SetWindowText(hWnd, Cancel)
                    Case MBAbort
                        SetWindowText(hWnd, Abort)
                    Case MBRetry
                        SetWindowText(hWnd, Retry)
                    Case MBIgnore
                        SetWindowText(hWnd, Ignore)
                    Case MBYes
                        SetWindowText(hWnd, Yes)
                    Case MBNo
                        SetWindowText(hWnd, No)
                End Select

                nButton += 1
            End If

            Return True
        End Function
    End Class
