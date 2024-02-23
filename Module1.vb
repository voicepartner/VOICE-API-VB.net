' Inside Module1
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text
Imports System.Threading.Tasks

Module Module1

    Private client As New HttpClient()
    Private Const apiKey As String = "YOUR_API_KEY"

    Sub Main()

        client.BaseAddress = New Uri("https://api.voicepartner.fr/v1/")
        client.DefaultRequestHeaders.Accept.Clear()
        client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))


        MainAsync().GetAwaiter().GetResult()

        DeposerMessageVocal.SendCampaignAsync().GetAwaiter().GetResult()

        EnvoyerSmsVocal.SendSmsVocalAsync().GetAwaiter().GetResult()

        Console.ReadLine()

    End Sub

    Async Function MainAsync() As Task
        Dim listeFichierAudio As New ListeFichierAudio()
        Await listeFichierAudio.GetAudios(client, apiKey)

        Dim renamer As New RenommerFichierAudio()
        Await renamer.RenameAudioFile()

        Dim mySupprimeEnvoiDiffere As New SupprimeEnvoiDiffere()
        mySupprimeEnvoiDiffere.CancelCampaignAsync().Wait()
        Console.ReadLine()
    End Function

End Module

