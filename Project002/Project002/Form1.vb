Imports System.Drawing

Public Class Form1

    'Graphic variables

    Dim G As Graphics
    Dim BckGrdG As Graphics
    Dim BckBuf As Bitmap
    Dim rec As Rectangle

    'View port variables
    Dim tileSize As Integer = 50
    Dim HEIGHT As Integer = 550
    Dim WIDTH As Integer = 650

    'FPS
    Dim tSec As Integer = TimeOfDay.Second
    Dim numTics As Integer = 0
    Dim maxTics As Integer = 0

    'Map variables
    Dim Map(100, 100, 10) As Integer
    Dim MapX As Integer = 20
    Dim MapY As Integer = 20

    'Track if game is running 
    Dim isRunning As Boolean = True

    'Mouse locations
    Dim mouseX As Integer
    Dim mouseY As Integer
    Dim mMapX As Integer
    Dim mMapY As Integer

    'Paint Brush
    Dim PaintBrush As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()

        'Initialize graphic objects

        G = Me.CreateGraphics
        BckBuf = New Bitmap(WIDTH, HEIGHT)

        StartGameLoop()

    End Sub

    Private Sub StartGameLoop()

        Do While isRunning = True
            'Keep application responsive
            Application.DoEvents()

            '1) check user input
            '2) checking AI
            '3) updating object data (positions,status, etc..)
            '4) checking triggers and conditions

            '5) draw graphics
            DrawGraphics()

            '6) playing sound effects/music

            'Update Tick Counter
            TicCounter()

        Loop

    End Sub

    Private Sub DrawGraphics()
        'fill backbuffer
        'draw tiles
        For x As Integer = 0 To 9
            For y As Integer = 0 To 9

                rec = New Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)

                Select Case Map(MapX + x, MapY + y, 0)
                    Case 0 'Normal
                        G.FillRectangle(Brushes.BurlyWood, rec)
                    Case 1 'Red
                        G.FillRectangle(Brushes.Red, rec)
                    Case 2 'blue
                        G.FillRectangle(Brushes.Blue, rec)
                End Select

                G.DrawRectangle(Pens.Black, rec)

            Next
        Next

        'draw final layers
        'guys, menus, etc.
        G.FillRectangle(Brushes.Red, 10 * tileSize, 4 * tileSize, tileSize, tileSize)
        G.FillRectangle(Brushes.Blue, 10 * tileSize, 6 * tileSize, tileSize, tileSize)

        G.DrawRectangle(Pens.Red, mouseX * tileSize, mouseY * tileSize, tileSize, tileSize)

        G.DrawString("Ticks: " & numTics & vbCrLf &
                     "TPS: " & maxTics & vbCrLf &
                     "Mouse x: " & mouseX & vbCrLf &
                     "Mouse y: " & mouseY & vbCrLf &
                     "Mouse MapX: " & mMapX & vbCrLf &
                     "Mouse MapY: " & mMapY & vbCrLf &
                     "", Me.Font, Brushes.Black, 500, 0)

        'copy backbuffer to graphics object
        G = Graphics.FromImage(BckBuf)

        'draw backbuffer to screen
        BckGrdG = Me.CreateGraphics
        BckGrdG.DrawImage(BckBuf, 0, 0, WIDTH, HEIGHT)

        ' fix overdraw
        G.Clear(Color.Wheat)

    End Sub

    'TPS
    Private Sub TicCounter()

        If tSec = TimeOfDay.Second And isRunning = True Then
            numTics += 1

        Else
            maxTics = numTics
            numTics = 0
            tSec = TimeOfDay.Second
        End If

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        mouseX = Math.Floor(e.X / tileSize)
        mouseY = Math.Floor(e.Y / tileSize)

        mMapX = MapX + mouseX
        mMapY = MapY + mouseY
    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        MsgBox("You attacked" & mMapX & ":" & mMapY)

        If mouseX = 10 And mouseY = 4 Then
            PaintBrush = 1
        ElseIf mouseX = 10 And mouseY = 6 Then
            PaintBrush = 2
        End If

        Select Case PaintBrush
            Case 0
            Case 1 'Red
                Map(mMapX, mMapY, 0) = 1
            Case 2 'Blue
                Map(mMapX, mMapY, 0) = 2
        End Select

    End Sub
End Class
