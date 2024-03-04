Imports System.IO
Imports Boomer_Kuwanger.ProjectClasses
Imports System.Math

Public Class BoomerangAndDummy

    'added
    Public Class BKBoomerang
        Inherits CCharacter

        Public CurrState As StateBKBoomerang

        Public Sub State(state As StateBKBoomerang, idxspr As Integer)
            CurrState = state
            IdxArrSprites = idxspr
            CurrFrame = 0
            FrameIdx = 0

        End Sub


        Public gradient, x1, y1, x2, y2 As Double

        Public Sub BoomerangLine()
            x1 = PosX
            y1 = PosY

            x2 = endPointBoomerangOrTeleport.x
            y2 = endPointBoomerangOrTeleport.y

            gradient = (y2 - y1) / (x2 - x1)

            'If PosY >= endPointBoomerangOrTeleport.y Then
            '    gradient *= -1
            'ElseIf PosY < endPointBoomerangOrTeleport.y Then
            '    Abs(gradient)
            'End If


        End Sub





        Public Overrides Sub Update()

            Select Case CurrState
                Case StateBKBoomerang.Create
                    If FrameIdx = 0 And CurrFrame = 0 Then
                        State(StateBKBoomerang.Move, 1)
                    End If
                Case StateBKBoomerang.Move
                    GetNextFrame()
                    Vx = 5
                    Vy = 5
                    If FDir = FaceDir.Left Then
                        PosX -= 1
                        'PosX -= Vx
                        '  gradient -= Vy
                        'PosX *= Vx
                        ' PosY += 3
                        PosY -= gradient

                    Else
                        PosX += 1
                        'PosX += Vx
                        ' gradient += Vy
                        ' PosY -= 3
                        PosY += gradient

                    End If


                    '  PosY += gradient

                    Round(PosY)



                    If FDir = FaceDir.Left And PosX <= endPointBoomerangOrTeleport.x Then
                        Destroy = True
                        ' State(StateBoomerKuwanger.Stand, 1)
                    ElseIf FDir = FaceDir.Right And PosX >= endPointBoomerangOrTeleport.x Then
                        Destroy = True

                    End If

                Case StateBKBoomerang.Destroy


            End Select
        End Sub

    End Class

    'added 
    Public Class DumProjectile
        Inherits CCharacter

        Public CurrState As StateDumProjectile

        Public Sub State(state As StateDumProjectile, idxspr As Integer)
            CurrState = state
            IdxArrSprites = idxspr
            CurrFrame = 0
            FrameIdx = 0

        End Sub

        Public Overrides Sub Update()
            Select Case CurrState
                Case StateDumProjectile.Create

                Case StateDumProjectile.Move

                Case StateDumProjectile.Destroy


            End Select
        End Sub

    End Class

End Class
