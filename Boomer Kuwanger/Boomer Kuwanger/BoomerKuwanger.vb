Imports System.IO
Imports Boomer_Kuwanger.ProjectClasses
Imports Boomer_Kuwanger.BoomerangAndDummy

Public Class BoomerKuwanger

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img, ImgDum As CImage

    Dim SpriteMapBoomerKuwanger As CImage
    Dim SpriteMaskBoomerKuwanger As CImage

    Dim SpriteMapDumDum As CImage
    Dim SpriteMaskDumDum As CImage

    'should we use boolean to decide horn?
    Dim Horn As Boolean = True ' if the BoomerKuwanger Hornless the value will be False 


    Dim BoomKWIntro, BoomKWStand, BoomKWDash, BoomKWTeleport, BoomKWStagger, BoomKWThrowBoom, BoomKWDeadLift As CArrFrame
    Dim BoomKWStandHornless, BoomKWTeleportHornless, BoomKWStaggerHornless As CArrFrame ' trial

    Dim theBoomerang1, theBoomerang2 As CArrFrame

    Dim DumStand, DumMove, DumStagger, DumShootProjectile, DumDeadlifted As CArrFrame

    Dim MainChar As CCharacter
    Dim theBoomerangObject As BKBoomerang

    Dim DumDum As DumChar
    Dim theProjectile As DumProjectile

    Dim listCharForBK As New List(Of CCharacter)
    Dim listCharForDum As New List(Of CCharacter)


    Dim boolThrowOrTeleport As Boolean = False
    ' Public EndPoint As Point



    Private Sub BoomerKuwanger_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Background Assignation
        Bg = New CImage
        Bg.OpenImage("D:\Campus\PresUniv\Sems5\Computer Graphics and Algorithms\Boomer Kuwanger[Final PA]\AssetSpritesBG\boomerKuwangerStage01.bmp")

        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)

        SpriteMapBoomerKuwanger = New CImage
        SpriteMapBoomerKuwanger.OpenImage("D:\Campus\PresUniv\Sems5\Computer Graphics and Algorithms\Boomer Kuwanger[Final PA]\AssetSpritesBG\boomerKuwangerSprite02.bmp")
        SpriteMapBoomerKuwanger.CreateMask(SpriteMaskBoomerKuwanger)

        SpriteMapDumDum = New CImage
        SpriteMapDumDum.OpenImage("D:\Campus\PresUniv\Sems5\Computer Graphics and Algorithms\Boomer Kuwanger[Final PA]\AssetSpritesBG\Dummy02.bmp")
        SpriteMapDumDum.CreateMask(SpriteMaskDumDum)

        'Initialize Sprites BoomerKuwanger
        BoomKWIntro = New CArrFrame
        'Movement.Insert(CtrX, CtrY, L, T, R, B, DURATION)
        BoomKWIntro.Insert(34, 39, 7, 7, 60, 67, 2)
        BoomKWIntro.Insert(90, 39, 64, 7, 117, 67, 2)
        BoomKWIntro.Insert(154, 37, 122, 7, 182, 67, 1)
        BoomKWIntro.Insert(223, 36, 192, 6, 251, 64, 1)
        BoomKWIntro.Insert(288, 36, 255, 7, 315, 64, 3)
        BoomKWIntro.Insert(349, 36, 320, 4, 385, 63, 5)

        BoomKWStand = New CArrFrame
        BoomKWStand.Insert(34, 39, 7, 7, 60, 67, 2)
        BoomKWStand.Insert(90, 39, 64, 7, 117, 67, 3)

        BoomKWDash = New CArrFrame
        BoomKWDash.Insert(33, 107, 8, 73, 60, 134, 2)
        BoomKWDash.Insert(95, 107, 66, 75, 124, 134, 1)

        BoomKWTeleport = New CArrFrame
        BoomKWTeleport.Insert(34, 39, 7, 7, 60, 67, 1)
        BoomKWTeleport.Insert(0, 0, 0, 0, 0, 0, 1)
        BoomKWTeleport.Insert(411, 174, 381, 145, 439, 201, 3)

        BoomKWStagger = New CArrFrame
        BoomKWStagger.Insert(415, 109, 387, 76, 439, 134, 2)
        BoomKWStagger.Insert(0, 0, 0, 0, 0, 0, 1)
        BoomKWStagger.Insert(415, 109, 387, 76, 439, 134, 1)

        BoomKWDeadLift = New CArrFrame
        BoomKWDeadLift.Insert(37, 177, 9, 146, 66, 202, 1)
        BoomKWDeadLift.Insert(104, 176, 70, 146, 132, 203, 1)
        BoomKWDeadLift.Insert(173, 174, 136, 146, 197, 202, 1)
        BoomKWDeadLift.Insert(228, 176, 201, 142, 257, 202, 2)
        BoomKWDeadLift.Insert(286, 176, 262, 142, 312, 202, 2)

        BoomKWThrowBoom = New CArrFrame
        BoomKWThrowBoom.Insert(34, 347, 4, 308, 59, 374, 3)
        BoomKWThrowBoom.Insert(90, 347, 63, 308, 135, 374, 1)
        BoomKWThrowBoom.Insert(170, 347, 139, 308, 199, 373, 1)
        BoomKWThrowBoom.Insert(234, 346, 203, 308, 262, 373, 2)

        'BKHornless

        BoomKWStandHornless = New CArrFrame
        BoomKWStandHornless.Insert(30, 265, 5, 240, 56, 291, 2)
        BoomKWStandHornless.Insert(83, 265, 60, 240, 110, 291, 3)

        MainChar = New CCharacter
        ReDim MainChar.ArrSprites(7)

        MainChar.ArrSprites(0) = BoomKWIntro
        MainChar.ArrSprites(1) = BoomKWStand
        MainChar.ArrSprites(2) = BoomKWDash
        MainChar.ArrSprites(3) = BoomKWTeleport
        MainChar.ArrSprites(4) = BoomKWStagger
        MainChar.ArrSprites(5) = BoomKWDeadLift
        MainChar.ArrSprites(6) = BoomKWThrowBoom

        'BKHornless
        MainChar.ArrSprites(7) = BoomKWStandHornless



        'Initalize Boomerang

        theBoomerang1 = New CArrFrame
        theBoomerang1.Insert(83, 407, 72, 395, 91, 417, 1)
        '  theBoomerang1.Insert(106, 409, 95, 395, 113, 417, 2)

        theBoomerang2 = New CArrFrame
        theBoomerang2.Insert(97, 408, 95, 395, 113, 417, 2)
        '  theBoomerang2.Insert(76, 413, 72, 395, 91, 417, 1)


        'Initialize Sprites DumDum
        DumStand = New CArrFrame
        DumStand.Insert(40, 47, 16, 20, 62, 69, 1)
        DumStand.Insert(90, 48, 68, 20, 113, 69, 1)
        DumStand.Insert(138, 47, 118, 20, 163, 69, 1)
        DumStand.Insert(188, 47, 167, 20, 245, 69, 1)
        'Movement.Insert(CtrX, CtrY, L, T, R, B, DURATION)


        DumDum = New DumChar
        ReDim DumDum.ArrSprites(4)
        DumDum.ArrSprites(0) = DumStand

        'spawn point boomerKuwanger
        MainChar.PosX = 419
        MainChar.PosY = 371

        MainChar.Vx = 0
        MainChar.Vy = 0

        MainChar.FDir = FaceDir.Left
        MainChar.State(StateBoomerKuwanger.Intro, 0)

        'spawn point DumDum
        DumDum.PosX = 54
        DumDum.PosY = 376

        DumDum.Vx = 0
        DumDum.Vy = 0

        DumDum.FDir = FaceDir.Right
        DumDum.State(StateDummy.Stand, 0)



        bmp = New Bitmap(Img.Width, Img.Height)

        'added
        ' DisplayImgDum()

        listCharForBK.Add(MainChar)


        DisplayImg()
        ResizeImg()


        gameTimer.Enabled = True
    End Sub


    'Procedurees
    '.. 
    '.
    Sub DisplayImg()
        'display bg and sprite on picturebox
        Dim i, j As Integer
        PutSprite(MainChar)

        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                bmp.SetPixel(i, j, Img.Elmt(i, j))
            Next
        Next

        picBox.Refresh()

        picBox.Image = bmp
        picBox.Width = bmp.Width
        picBox.Height = bmp.Height
        picBox.Top = 0
        picBox.Left = 0
        'Me.Width = PictureBox1.Width + 30
        'Me.Height = PictureBox1.Height + 100

    End Sub

    'added
    Sub DisplayImgDum()
        'display bg and sprite on picturebox
        Dim i, j As Integer
        PutSpriteDum(DumDum)

        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                bmp.SetPixel(i, j, Img.Elmt(i, j))
            Next
        Next

        picBox.Refresh()

        picBox.Image = bmp
        picBox.Width = bmp.Width
        picBox.Height = bmp.Height
        picBox.Top = 0
        picBox.Left = 0
    End Sub

    'added
    Sub PutSpriteDum(ByVal c As DumChar)

        Dim i, j As Integer
        'set background
        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                Img.Elmt(i, j) = Bg1.Elmt(i, j)
            Next
        Next

        Dim EF As CElmtFrame = c.ArrSprites(c.IdxArrSprites).Elmt(c.FrameIdx)
        Dim spritewidth = EF.Right - EF.Left
        Dim spriteheight = EF.Bottom - EF.Top


        If c.FDir = FaceDir.Left Then
            Dim spriteleft As Integer = c.PosX - EF.CtrPoint.x + EF.Left
            Dim spritetop As Integer = c.PosY - EF.CtrPoint.y + EF.Top
            'set mask
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMaskDumDum.Elmt(EF.Left + i, EF.Top + j))
                Next
            Next

            'set sprite
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMapDumDum.Elmt(EF.Left + i, EF.Top + j))
                Next
            Next
        Else 'facing right
            Dim spriteleft = c.PosX + EF.CtrPoint.x - EF.Right
            Dim spritetop = c.PosY - EF.CtrPoint.y + EF.Top
            'set mask
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMaskDumDum.Elmt(EF.Right - i, EF.Top + j))
                Next
            Next

            'set sprite
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMapDumDum.Elmt(EF.Right - i, EF.Top + j))
                Next
            Next

        End If

    End Sub

    Sub ResizeImg()
        Dim w, h As Integer

        w = picBox.Width
        h = picBox.Height

        Me.ClientSize = New Size(w, h)

    End Sub

    Sub PutSprite(ByVal c As CCharacter)

        Dim cc As CCharacter
        Dim i, j As Integer
        'set background
        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                Img.Elmt(i, j) = Bg.Elmt(i, j)
            Next
        Next


        For Each cc In listCharForBK
            Dim EF As CElmtFrame = cc.ArrSprites(cc.IdxArrSprites).Elmt(cc.FrameIdx)
            Dim spritewidth = EF.Right - EF.Left
            Dim spriteheight = EF.Bottom - EF.Top
            If cc.FDir = FaceDir.Left Then
                Dim spriteleft As Integer = cc.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMaskBoomerKuwanger.Elmt(EF.Left + i, EF.Top + j))
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMapBoomerKuwanger.Elmt(EF.Left + i, EF.Top + j))
                    Next
                Next
            Else 'facing right
                Dim spriteleft = cc.PosX + EF.CtrPoint.x - EF.Right
                Dim spritetop = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMaskBoomerKuwanger.Elmt(EF.Right - i, EF.Top + j))
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMapBoomerKuwanger.Elmt(EF.Right - i, EF.Top + j))
                    Next
                Next

            End If

        Next

    End Sub

    Private Sub gameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick

        Dim CC As CCharacter

        picBox.Refresh()

        For Each CC In listCharForBK
            CC.Update()
        Next

        If MainChar.CurrState = StateBoomerKuwanger.ThrowBoomerang Then
            ThrowBoomerang(1)
            theBoomerangObject.endPointBoomerangOrTeleport.x = MainChar.endPointBoomerangOrTeleport.x
            theBoomerangObject.endPointBoomerangOrTeleport.y = MainChar.endPointBoomerangOrTeleport.y
            theBoomerangObject.BoomerangLine()
        End If

        If MainChar.CurrState = StateBoomerKuwanger.StandHornless Then
            If theBoomerangObject.Destroy = True Then
                MainChar.HornIndicator = True
                MainChar.State(StateBoomerKuwanger.Stand, 1)
            End If
        End If





        Dim ListcharTEMP As New List(Of CCharacter)

        For Each CC In listCharForBK
            If Not CC.Destroy Then
                ListcharTEMP.Add(CC)
            End If
        Next

        '' tempBoom = listCharForBK(0)
        'If listCharForBK(0).PosX = EndPoint.X Or listCharForBK(0).PosY = EndPoint.Y Then
        '    listCharForBK(0).Destroy = True
        'End If

        listCharForBK = ListcharTEMP

        DisplayImg()

    End Sub

    Private Sub BoomerKuwanger_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Left Then
            MainChar.movementBool = True
            MainChar.FDir = FaceDir.Left
        ElseIf e.KeyCode = Keys.Right Then
            MainChar.movementBool = True
            MainChar.FDir = FaceDir.Right
            'ElseIf e.KeyCode = Keys.Q Then
            '    MainChar.State(StateBoomerKuwanger.ThrowBoomerang, 6)
        ElseIf e.KeyCode = Keys.W Then
            MainChar.State(StateBoomerKuwanger.DeadLift, 5)
        ElseIf e.KeyCode = Keys.E Then
            MainChar.State(StateBoomerKuwanger.Stagger, 4)
        ElseIf e.KeyCode = Keys.R Then
            MainChar.State(StateBoomerKuwanger.Teleport, 3)
        End If


        If e.KeyCode = Keys.NumPad1 Then
            'throw
            boolThrowOrTeleport = True
            MsgBox("Throw Boomerang State")
        ElseIf e.KeyCode = Keys.NumPad2 Then
            'teleport
            MsgBox("Teleport")
            boolThrowOrTeleport = False
        End If
        'MainChar.State(StateBoomerKuwanger.Stand, 1)
    End Sub

    Sub ThrowBoomerang(boom As Integer)
        Dim bom As BKBoomerang

        bom = New BKBoomerang
        If MainChar.FDir = FaceDir.Left Then
            bom.PosX = MainChar.PosX - 20
            bom.FDir = FaceDir.Left
        Else
            bom.PosX = MainChar.PosX + 20
            bom.FDir = FaceDir.Right
        End If

        bom.PosY = MainChar.PosY - 3

        bom.Vx = 0
        bom.Vy = 0
        bom.CurrState = StateBKBoomerang.Create

        ReDim bom.ArrSprites(1)

        If boom = 1 Then
            bom.ArrSprites(0) = theBoomerang1
            bom.ArrSprites(1) = theBoomerang1
        End If
        theBoomerangObject = bom




        ' theBoomerangObject.BoomerangLine()


        listCharForBK.Add(bom)
    End Sub


    Private Sub picBox_MouseClick(sender As Object, e As MouseEventArgs) Handles picBox.MouseClick
        'Dim tempBoom As New CCharacter
        MainChar.endPointBoomerangOrTeleport.x = e.X
        MainChar.endPointBoomerangOrTeleport.y = e.Y

        'theBoomerangObject.endPointBoomerangOrTeleport.x = e.X
        'theBoomerangObject.endPointBoomerangOrTeleport.y = e.Y


        If MainChar.PosX <= e.X Then
            MainChar.FDir = FaceDir.Right
        ElseIf MainChar.PosX >= e.X Then
            MainChar.FDir = FaceDir.Left
        End If

        If boolThrowOrTeleport = False Then
            'teleport
            MainChar.State(StateBoomerKuwanger.Teleport, 3)

        ElseIf boolThrowOrTeleport = True Then
            'throw
            MainChar.State(StateBoomerKuwanger.ThrowBoomerang, 6)

        End If


        'tempBoom = listCharForBK(0)




        'If tempBoom.PosX = e.X Or tempBoom.PosY = e.Y Then
        '    tempBoom.Destroy = True
        'End If

        'If theBoomerangObject.PosX = e.X And theBoomerangObject.PosY = e.Y Then
        '    theBoomerangObject.Destroy = True
        'End If
    End Sub
End Class
