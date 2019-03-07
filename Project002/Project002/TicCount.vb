Module TicCount

    'TPS variables
    Public tSec As Integer = TimeOfDay.Second
    Public numTics As Integer = 0
    Public maxTics As Integer = 0

    'Tic per second 
    Public Sub TicCounter()

        If tSec = TimeOfDay.Second And Parachute.isRunning = True Then

            numTics += 1

        Else

            maxTics = numTics
            numTics = 0
            tSec = TimeOfDay.Second

        End If

    End Sub

End Module
