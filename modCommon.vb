Module modCommon
    Public APP_PATH As String '= Application.StartupPath & "\x360rgh"
    Public gPlaySound As Boolean = True
    Public gUSBrLPT As String = "usb"

    Public Sub playAlertSound(Optional ByVal strSound As String = "ALERT")
        If gPlaySound Then
            Select Case strSound
                Case "ALERT"
                    My.Computer.Audio.Play(My.Resources.attention, AudioPlayMode.Background)
                Case "COMPLETE"
                    My.Computer.Audio.Play(My.Resources.complete, AudioPlayMode.Background)
                Case "PROBLEM"
                    My.Computer.Audio.Play(My.Resources.problem, AudioPlayMode.Background)
            End Select
        End If
    End Sub


    Public Class clsComboItem
        Public cname As String
        Public cvalue As String

        Public Property Value() As String
            Get
                Return Me.cvalue
            End Get
            Set(ByVal value As String)
                Me.cvalue = value
            End Set
        End Property


        Public Sub New(ByVal name As String, ByVal value As String)
            cname = name
            cvalue = value
        End Sub

        Public Overrides Function ToString() As String
            Return cname
        End Function
    End Class


End Module
