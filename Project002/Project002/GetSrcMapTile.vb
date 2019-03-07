Module GetSrcMapTile

    'getting image source for map tiles
    Public Sub getSrcRect(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)

        Select Case Parachute.Map(x, y, 0)
            Case 0 'grass
                DrawingGraphics.srec = New Rectangle(0, 0, Parachute.tileSize, Parachute.tileSize)
            Case 1 'wall
                DrawingGraphics.srec = New Rectangle(50, 50, Parachute.tileSize, Parachute.tileSize)
            Case 2 'left edge
                DrawingGraphics.srec = New Rectangle(50, 0, Parachute.tileSize, Parachute.tileSize)
                Parachute.Map(x, y, 1) = 1
            Case 3 'right edge
                DrawingGraphics.srec = New Rectangle(0, 50, Parachute.tileSize, Parachute.tileSize)
                Parachute.Map(x, y, 1) = 1
            Case 4 'middle
                DrawingGraphics.srec = New Rectangle(100, 0, Parachute.tileSize, Parachute.tileSize)
        End Select

    End Sub

    Public Sub getChar()

        DrawingGraphics.srec = New Rectangle(0, 0, Parachute.tileSize, Parachute.tileSize)

    End Sub

End Module
