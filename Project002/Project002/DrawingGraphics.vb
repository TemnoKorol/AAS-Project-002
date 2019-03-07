Module DrawingGraphics

    'Graphic variables
    Public G As Graphics
    Public BckGrdG As Graphics
    Public BckBuf As Bitmap
    Public bmpTile As Bitmap
    Public srec As Rectangle
    Public drec As Rectangle

    Public Sub DrawGraphics()
        'fill backbuffer
        'draw tiles
        For x As Integer = -1 To 15
            For y As Integer = -1 To 9

                GetSrcMapTile.getSrcRect(Parachute.MapX + x, Parachute.MapY + y, Parachute.tileSize, Parachute.tileSize)

                drec = New Rectangle((x * Parachute.tileSize) + Character.xPos, (y * Parachute.tileSize) + Character.yPos, Parachute.tileSize, Parachute.tileSize)

                G.DrawImage(bmpTile, drec, srec, GraphicsUnit.Pixel)

            Next
        Next

        'draw final layers

        'guys, menus, etc.
        GetSrcMapTile.getChar()
        Character.bmpChar.MakeTransparent(Color.White)
        G.DrawImage(Character.bmpChar, 5 * Parachute.tileSize, 8 * Parachute.tileSize, srec, GraphicsUnit.Pixel)

        'Parachute.G.FillRectangle(Brushes.Red, 10 * Parachute.tileSize, 4 * Parachute.tileSize, Parachute.tileSize, Parachute.tileSize)
        'Parachute.G.FillRectangle(Brushes.Blue, 10 * Parachute.tileSize, 6 * Parachute.tileSize, Parachute.tileSize, Parachute.tileSize)

        G.DrawRectangle(Pens.Purple, Parachute.mouseX * Parachute.tileSize, Parachute.mouseY * Parachute.tileSize, Parachute.tileSize, Parachute.tileSize)

        G.DrawString("Ticks: " & TicCount.numTics & vbCrLf &
                     "TPS: " & TicCount.maxTics & vbCrLf &
                     "Mouse x: " & Parachute.mouseX & vbCrLf &
                     "Mouse y: " & Parachute.mouseY & vbCrLf &
                     "Mouse MapX: " & Parachute.mMapX & vbCrLf &
                     "Mouse MapY: " & Parachute.mMapY & vbCrLf &
                     "", Parachute.Font, Brushes.Black, 500, 0)

        'copy backbuffer to graphics object
        G = Graphics.FromImage(BckBuf)

        'draw backbuffer to screen
        BckGrdG = Parachute.CreateGraphics
        BckGrdG.DrawImage(BckBuf, 0, 0, Parachute.WIDTH, Parachute.HEIGHT)

        ' fix overdraw
        G.Clear(Color.Wheat)

    End Sub

End Module
