﻿Imports System.Drawing

Public Class Parachute

    'View port variables
    Public tileSize As Integer = 50
    Public HEIGHT As Integer = 800
    Public WIDTH As Integer = 800

    'Map variables
    Public Map(100, 100, 10) As Integer
    Public MapX As Integer = 20
    Public MapY As Integer = 20

    'Track if game is running 
    Public isRunning As Boolean = True

    'Mouse locations/movement
    Public mouseX As Integer
    Public mouseY As Integer
    Public mMapX As Integer
    Public mMapY As Integer

    'Terrain Detection Collision
    Public guyX As Decimal = (MapX + 5) * tileSize
    Public guyY As Decimal = (MapY + 8) * tileSize

    'Paint Brush
    Dim PaintBrush As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()

        'Initialize graphic objects before setting values
        G = Me.CreateGraphics
        BckBuf = New Bitmap(WIDTH, HEIGHT)
        bmpTile = New Bitmap(GFX.pbGFX.Image)
        Character.bmpChar = New Bitmap(GFX.pbChar.Image)

        LoadMap()

        GameLoop.StartGameLoop()

    End Sub

    'Mouse movement
    Private Sub Parachute_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        mouseX = Math.Floor(e.X / tileSize)
        mouseY = Math.Floor(e.Y / tileSize)

        mMapX = MapX + mouseX
        mMapY = MapY + mouseY

    End Sub

    'Mouse Click events
    Private Sub Parachute_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick

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

    'Terain Collision
    Public Function isBlocked(ByVal dir As Short) As Boolean

        Select Case dir
            Case 0 'West
                If Map(Math.Ceiling(guyX / tileSize) - 1, (guyY / tileSize), 1) = 1 Then
                    Return True
                End If
            Case 1 'East
                If Map(Math.Floor(guyX / tileSize) + 1, (guyY / tileSize), 1) = 1 Then
                    Return True
                End If
        End Select

        Return False

    End Function

    'Loading Map
    Private Sub LoadMap()
        'Wall
        For x As Integer = 20 To 29
            Map(x, 29, 0) = 1
        Next
        'Middle
        For x As Integer = 21 To 28
            Map(x, 28, 0) = 4
        Next
        'Left edge
        Map(20, 28, 0) = 2
        'Right edge
        Map(29, 28, 0) = 3

    End Sub

End Class
