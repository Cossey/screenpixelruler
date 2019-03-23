
Imports System.Drawing.Drawing2D

Public Class RulerForm


    Dim HorizontalSpacing = 10
    Dim VerticalSpacing = 20

    Private FreezeCursorPos = False
    Private CursorLastPos = 0
    Private FlipDirection = False

    Private LastPos = 0
    Private MaxWidth = 3020
    Private MaxHeight = 1021

    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private IsFormDragged = False

    'Draws the Current Cursor Position
    Sub PaintCursorPosition(ByVal g As Graphics, FlipDirection As Boolean)
        Dim p As Point = Me.PointToClient(MousePosition)
        Dim Pos = 0

        If IsHorzontal() Then
            Pos = p.X
            If FreezeCursorPos Then Pos = CursorLastPos
            g.DrawLine(New Pen(Color.White, 1), Pos, Me.Height, Pos, 0)

            Dim centerFormat As New StringFormat()
            centerFormat.Alignment = StringAlignment.Center
            centerFormat.LineAlignment = StringAlignment.Center
            Dim textSize = g.MeasureString((Pos - HorizontalSpacing).ToString, New Font("Courier New", 9))
            If FlipDirection Then
                g.FillRectangle(New SolidBrush(Color.White), Pos - (textSize.Width / 2), 22, textSize.Width, 14)
                g.DrawString((Pos - HorizontalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.Black), New Rectangle(Pos - 20, 22, 40, 15), centerFormat)
            Else
                g.FillRectangle(New SolidBrush(Color.White), Pos - (textSize.Width / 2), 4, textSize.Width, 14)
                g.DrawString((Pos - HorizontalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.Black), New Rectangle(Pos - 20, 3, 40, 15), centerFormat)
            End If


        Else
            Pos = p.Y
            If FreezeCursorPos Then Pos = CursorLastPos
            g.DrawLine(New Pen(Color.White, 1), Me.Width, Pos, 0, Pos)


            Dim textSize = g.MeasureString((Pos - VerticalSpacing).ToString, New Font("Courier New", 9))
            If FlipDirection Then
                Dim leftFormat As New StringFormat()
                leftFormat.Alignment = StringAlignment.Near
                leftFormat.LineAlignment = StringAlignment.Near
                g.FillRectangle(New SolidBrush(Color.White), 1, Pos - 14, textSize.Width - 3, 13)
                g.DrawString((Pos - VerticalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.Black), New Rectangle(0, Pos - 15, 40, 15), leftFormat)

            Else
                Dim rightFormat As New StringFormat()
                rightFormat.Alignment = StringAlignment.Far
                rightFormat.LineAlignment = StringAlignment.Far
                g.FillRectangle(New SolidBrush(Color.White), Me.Width - textSize.Width + 1, Pos - 14, textSize.Width - 2, 13)
                g.DrawString((Pos - VerticalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.Black), New Rectangle(0, Pos - 15, 40, 15), rightFormat)

            End If


        End If

        CursorLastPos = Pos
    End Sub

    'Draws the Pixel Ruler
    Sub PaintInPixels(ByVal g As Graphics, FlipDirection As Boolean)
        Dim MaxHeight = Me.Height
        Dim MaxWidth = Me.Width

        'Dim OffsetSpace = 0
        If IsHorzontal() Then
            Dim FixOffsetSpace = HorizontalSpacing
            If HorizontalSpacing >= 20 Then
                FixOffsetSpace = 0
            End If
            Dim centerFormat As New StringFormat()
            centerFormat.Alignment = StringAlignment.Center
            centerFormat.LineAlignment = StringAlignment.Center
            If FlipDirection Then
                For I As Integer = HorizontalSpacing To (Me.Width - HorizontalSpacing) Step 2
                    Dim P As Pen = New Pen(Color.Black, 1)
                    Dim High As Integer = 10
                    If I Mod 20 = FixOffsetSpace Then High = 15
                    If I Mod 100 = HorizontalSpacing And (I - HorizontalSpacing) <> 0 Then
                        High = 20
                        g.DrawString((I - HorizontalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.White), New Rectangle(I - 20, 22, 40, 15), centerFormat)
                    End If
                    If I = HorizontalSpacing Then
                        P = New Pen(Color.White)
                        High = MaxHeight
                    End If

                    g.DrawLine(P, I, High, I, 0)
                Next I
            Else

                For I As Integer = HorizontalSpacing To (Me.Width - HorizontalSpacing) Step 2 '2529 Step 2
                    Dim P As Pen = New Pen(Color.Black, 1)
                    Dim High As Integer = 10
                    If I Mod 20 = HorizontalSpacing Then High = 15
                    If I Mod 100 = HorizontalSpacing And (I - HorizontalSpacing) <> 0 Then
                        High = 20
                        g.DrawString((I - HorizontalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.White), New Rectangle(I - 20, 3, 40, 15), centerFormat)
                    End If
                    If I = HorizontalSpacing Then
                        P = New Pen(Color.White)
                        High = MaxHeight
                    End If

                    g.DrawLine(P, I, MaxHeight - High, I, MaxHeight)
                Next I
            End If
        Else
            Dim FixOffsetSpace = VerticalSpacing
            If VerticalSpacing >= 20 Then
                FixOffsetSpace = 0
            End If


            If FlipDirection Then
                Dim leftFormat As New StringFormat()
                leftFormat.Alignment = StringAlignment.Near
                leftFormat.LineAlignment = StringAlignment.Near

                For I As Integer = VerticalSpacing To (Me.Height - VerticalSpacing) Step 2
                    Dim P As Pen = New Pen(Color.Black, 1)
                    Dim Wide As Integer = 10
                    If I Mod 20 = FixOffsetSpace Then Wide = 15
                    If I Mod 100 = VerticalSpacing And (I - VerticalSpacing) <> 0 Then
                        Wide = MaxWidth
                        g.DrawString((I - VerticalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.White), New Rectangle(0, I - 15, 40, 15), leftFormat)
                    End If
                    If I = VerticalSpacing Then
                        P = New Pen(Color.White)
                        Wide = MaxWidth
                    End If

                    g.DrawLine(P, MaxWidth - Wide, I, MaxWidth, I)
                Next I
            Else
                Dim rightFormat As New StringFormat()
                rightFormat.Alignment = StringAlignment.Far
                rightFormat.LineAlignment = StringAlignment.Far
                For I As Integer = VerticalSpacing To (Me.Height - VerticalSpacing) Step 2
                    Dim P As Pen = New Pen(Color.Black, 1)
                    Dim Wide As Integer = 10
                    If I Mod 20 = FixOffsetSpace Then Wide = 15
                    If I Mod 100 = VerticalSpacing And (I - VerticalSpacing) <> 0 Then
                        Wide = MaxWidth
                        g.DrawString((I - VerticalSpacing).ToString, New Font("Courier New", 9), New SolidBrush(Color.White), New Rectangle(0, I - 15, 40, 15), rightFormat)
                    End If
                    If I = VerticalSpacing Then
                        P = New Pen(Color.White)
                        Wide = MaxWidth
                    End If

                    g.DrawLine(P, Wide, I, 0, I)
                Next I
            End If
        End If

    End Sub

    'Draws the Background
    Sub PaintBackground(ByVal g As Graphics)
        Dim lgm As LinearGradientMode = LinearGradientMode.Horizontal
        If IsHorzontal() Then lgm = LinearGradientMode.Vertical
        Using br As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width, Me.Height), Color.FromArgb(145, 212, 255), Color.FromArgb(0, 130, 254), lgm)
            g.FillRectangle(br, 0, 0, Me.Width, Me.Height)
        End Using
    End Sub

    'Render the Ruler
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        PaintBackground(e.Graphics)
        PaintInPixels(e.Graphics, FlipDirection)
        PaintCursorPosition(e.Graphics, FlipDirection)
    End Sub

    Protected Function IsHorzontal() As Boolean
        Return Me.Width > Me.Height
    End Function

    'Update Ruler Size and Cursor Position
    Private Sub tmrPosition_Tick(sender As Object, e As EventArgs) Handles tmrPosition.Tick
        Dim p As Point = Me.PointToClient(MousePosition)

        If IsHorzontal() Then
            Dim XPos = p.X
            If FreezeCursorPos Then XPos = CursorLastPos
            If XPos >= 620 And XPos < MaxWidth Then
                If Me.Width <> XPos + 20 Then
                    Me.Width = XPos + 20
                    Me.MinimumSize = New Size((XPos + 20), Me.MinimumSize.Height)
                    Me.MaximumSize = New Size((XPos + 20), Me.MinimumSize.Height)
                End If
            ElseIf XPos >= MaxWidth Then
                Me.Width = (MaxWidth + 19)
                Me.MinimumSize = New Size((MaxWidth + 19), Me.MinimumSize.Height)
                Me.MaximumSize = New Size((MaxWidth + 19), Me.MinimumSize.Height)

            Else
                Me.Width = 639
                Me.MinimumSize = New Size(639, Me.MinimumSize.Height)
                Me.MaximumSize = New Size(639, Me.MinimumSize.Height)
            End If

        Else 'Vertical Ruler
            Dim YPos = p.Y
            If FreezeCursorPos Then YPos = CursorLastPos
            If YPos >= 421 And YPos < MaxHeight Then
                If Me.Height <> YPos + 20 Then
                    Me.Height = YPos + 20
                    Me.MinimumSize = New Size(Me.MinimumSize.Width, (YPos + 20))
                    Me.MaximumSize = New Size(Me.MinimumSize.Width, (YPos + 20))
                End If
            ElseIf YPos >= MaxHeight Then
                Me.Height = (MaxHeight + 19)
                Me.MinimumSize = New Size(Me.MinimumSize.Width, (MaxHeight + 19))
                Me.MaximumSize = New Size(Me.MinimumSize.Width, (MaxHeight + 19))

            Else
                Me.Height = 440
                Me.MinimumSize = New Size(Me.MinimumSize.Width, 440)
                Me.MaximumSize = New Size(Me.MinimumSize.Width, 440)
            End If

        End If
        Me.Invalidate()

    End Sub

    Protected Sub PositionRuler(hPos As Integer, vPos As Integer)
        If IsHorzontal() Then
            Me.Left = vPos - 10
        Else
            Me.Top = hPos - 20
        End If
    End Sub

    Protected Sub CopySizeToClipboard()
        Dim p As Point = Me.PointToClient(MousePosition)
        If IsHorzontal() Then
            Clipboard.SetText((p.X - HorizontalSpacing))
        Else
            Clipboard.SetText((p.Y - VerticalSpacing))
        End If
    End Sub

    'Process Shortcuts
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.S) Then PositionRuler(MousePosition.X, MousePosition.Y)
        If keyData = (Keys.Control Or Keys.F) Then FreezeCursorPos = Not FreezeCursorPos
        If keyData = (Keys.Control Or Keys.X) Then Application.Exit()
        If keyData = (Keys.Control Or Keys.R) Then Rotate()
        If keyData = (Keys.Control Or Keys.D) Then FlipDirection = Not FlipDirection
        If keyData = (Keys.Control Or Keys.E) Then PositionRuler(0, 0)
        If keyData = (Keys.Control Or Keys.C) Then CopySizeToClipboard()

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Rotate Ruler 90 degrees
    Private Sub Rotate()
        Dim Pos
        If IsHorzontal() Then
            Pos = New Size(40, 440)
            CursorLastPos += VerticalSpacing
            CursorLastPos -= HorizontalSpacing
        Else
            Pos = New Size(639, 40)
            CursorLastPos -= VerticalSpacing
            CursorLastPos += HorizontalSpacing
        End If

        If Me.Top < 0 Then Me.Top = 0
        If Me.Left < 0 Then Me.Left = 0

        Me.Size = Pos
        Me.MinimumSize = Pos
        Me.MaximumSize = Pos

        Me.Invalidate()

    End Sub



    'Ruler click
    Private Sub Ruler_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            If Not IsFormDragged Then
                Rotate()
            End If
            IsFormDragged = False
            IsFormBeingDragged = False
        ElseIf e.Button = MouseButtons.Middle Then
            FlipDirection = Not FlipDirection
        ElseIf e.Button = MouseButtons.Right Then
            'Application.Exit()
            RulerMenu.Show(Me, e.Location)
        End If
    End Sub

    'Ruler Dragging
    Private Sub Ruler_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If

    End Sub

    Private Sub Ruler_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If IsFormBeingDragged Then
            IsFormDragged = True
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If

    End Sub

    Private Sub MenuExit_Click(sender As Object, e As EventArgs) Handles MenuExit.Click
        Application.Exit()
    End Sub

    Private Sub MenuAbout_Click(sender As Object, e As EventArgs) Handles MenuAbout.Click
        'Freeze Cursor Pos and Turn Off TopMost to workaround issue
        'where Ruler steals focus or ends up on top of the form
        Dim LastFreezeCursorPos = FreezeCursorPos
        FreezeCursorPos = True
        TopMost = False
        AboutForm.ShowDialog()
        FreezeCursorPos = LastFreezeCursorPos
        TopMost = True
    End Sub

    Private Sub MenuOptions_Click(sender As Object, e As EventArgs) Handles MenuOptions.Click
        'Freeze Cursor Pos and Turn Off TopMost to workaround issue
        'where Ruler steals focus or ends up on top of the form
        Dim LastFreezeCursorPos = FreezeCursorPos
        FreezeCursorPos = True
        TopMost = False
        OptionsForm.ShowDialog()
        FreezeCursorPos = LastFreezeCursorPos
        TopMost = True
    End Sub

End Class
