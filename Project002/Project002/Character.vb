Public Class Character

    'Character Variables
    Public Shared bmpChar As Bitmap
    Public Shared xPos As Integer = 0
    Public Shared yPos As Integer = 0
    Dim moveSpd As Integer = 5
    Public Shared moveDir As Short = 0
    Public Shared LastDir As Short = 2


    Public Shared Sub moveChar(ByVal dir As Short)

        Select Case dir
            Case 1

                If Parachute.isBlocked(0) = False Then

                    xPos += moveSpd
                    Parachute.guyX = (Parachute.guyX - moveSpd)

                    If xPos >= Parachute.tileSize Then
                        xPos = 0
                        Parachute.MapX -= 1
                    End If

                End If

            Case 2
                If Parachute.isBlocked(1) = False Then

                    xPos -= moveSpd
                    Parachute.guyX = (Parachute.guyX + moveSpd)

                    If xPos <= Parachute.tileSize * -1 Then
                        xPos = 0
                        Parachute.MapX += 1
                    End If
                End If
        End Select

    End Sub

    Public Shared Sub setMoveDir()
        If GetKeyState(Keys.A) = True Then moveDir = 1
        If GetKeyState(Keys.D) = True Then moveDir = 2

        If GetKeyState(Keys.A) = False And
           GetKeyState(Keys.D) = False Then

            moveDir = 0

        End If

        If moveDir <> 0 Then LastDir = moveDir

    End Sub

    'Key detection
    Dim keyPushed As Short = 0

    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Integer) As Short

    Public Function GetKeyState(ByVal key1 As Integer) As Boolean

        Dim s As Short

        s = GetAsyncKeyState(key1)

        If s = 0 Then Return False
        Return True

    End Function
End Class
