﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BoomerKuwanger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.gameTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picBox
        '
        Me.picBox.Location = New System.Drawing.Point(94, 93)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(93, 87)
        Me.picBox.TabIndex = 0
        Me.picBox.TabStop = False
        '
        'gameTimer
        '
        '
        'BoomerKuwanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 418)
        Me.Controls.Add(Me.picBox)
        Me.Name = "BoomerKuwanger"
        Me.Text = "BoomerKuwanger"
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picBox As PictureBox
    Friend WithEvents gameTimer As Timer
End Class
