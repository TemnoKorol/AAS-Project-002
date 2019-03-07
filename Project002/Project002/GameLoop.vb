Module GameLoop

    Public Sub StartGameLoop()

        Do While Parachute.isRunning = True

            'Keep application responsive
            Application.DoEvents()

            '1) check user input
            Character.setMoveDir()
            Character.moveChar(Character.moveDir)
            '2) checking AI
            '3) updating object data (positions,status, etc..)
            '4) checking triggers and conditions

            '5) draw graphics
            DrawingGraphics.DrawGraphics()

            '6) playing sound effects/music

            'Update Tick Counter
            TicCount.TicCounter()

        Loop

    End Sub

End Module
