Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text
Imports System.Threading.Tasks

Module Module1

    Private client As New HttpClient()
    Private Const apiKey As String = "YOUR_API_KEY"

    Sub Main()
        ' Initialisation du client HttpClient (par exemple, définir des en-têtes communs)
        client.BaseAddress = New Uri("https://api.voicepartner.fr/v1/")
        client.DefaultRequestHeaders.Accept.Clear()
        client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

        ' Exécuter les appels API de manière asynchrone
        MainAsync().GetAwaiter().GetResult()
        Console.ReadLine()
    End Sub

    Async Function MainAsync() As Task
        Await GetUserDetails()
        Await GetAudios()
        'Await RenameAudioFile()
        Await CancelCampaign()
        Await SendVoiceMessage()
    End Function

    Private Async Function GetUserDetails() As Task
        Dim url As String = $"me/v9W2BiAxN-zbsCC-1b9jWE7k-5FgkMm"

        Try
            Dim response As HttpResponseMessage = Await client.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Console.WriteLine("User Details: " & responseString)
            Else
                Console.WriteLine("Error: " & response.ReasonPhrase)
            End If
        Catch ex As Exception
            Console.WriteLine("Exception: " & ex.Message)
        End Try
    End Function

    Private Async Function GetAudios() As Task
        Dim url As String = $"audios/v9W2BiAxN-zbsCC-1b9jWE7k-5FgkMm"

        Try
            Dim response As HttpResponseMessage = Await client.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Console.WriteLine("Audios: " & responseString)
            Else
                Console.WriteLine("Error: " & response.ReasonPhrase)
            End If
        Catch ex As Exception
            Console.WriteLine("Exception: " & ex.Message)
        End Try
    End Function

    'Private Async Function RenameAudioFile() As Task
    '    Dim url As String = "audio-file/rename"
    '    Dim data As New With {
    '        .apiKey = "v9W2BiAxN-zbsCC-1b9jWE7k-5FgkMm",
    '        .tokenAudio = "47614d3f87748af08bc7aba17beaee0d",
    '        .filename = "Nomdufichier"
    '    }

    '    Try
    '        Dim jsonData As String = JsonConvert.SerializeObject(data)
    '        Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

    '        Dim response As HttpResponseMessage = Await client.PostAsync(url, content)
    '        If response.IsSuccessStatusCode Then
    '            Dim responseString As String = Await response.Content.ReadAsStringAsync()
    '            Console.WriteLine("Rename Audio File: " & responseString)
    '        Else
    '            Console.WriteLine("Error: " & response.ReasonPhrase)
    '        End If
    '    Catch ex As Exception
    '        Console.WriteLine("Exception: " & ex.Message)
    '    End Try
    'End Function

    Private Async Function CancelCampaign() As Task
        Dim campaignId As String = "CAMPAIGN_ID"
        Dim url As String = $"campaign/cancel/{apiKey}/{campaignId}"

        Try
            Dim response As HttpResponseMessage = Await client.DeleteAsync(url)
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Console.WriteLine("Cancel Campaign: " & responseString)
            Else
                Console.WriteLine("Error: " & response.ReasonPhrase)
            End If
        Catch ex As Exception
            Console.WriteLine("Exception: " & ex.Message)
        End Try
    End Function

    Private Async Function SendVoiceMessage() As Task
        Dim url As String = "tts/send"
        Dim data As New With {
            .apiKey = "v9W2BiAxN-zbsCC-1b9jWE7k-5FgkMm",
            .phoneNumbers = "0651923982",
            .text = "Mon premier test"
        }

        Try
            Dim jsonData As String = JsonConvert.SerializeObject(data)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Console.WriteLine("Send Voice Message: " & responseString)
            Else
                Console.WriteLine("Error: " & response.ReasonPhrase)
            End If
        Catch ex As Exception
            Console.WriteLine("Exception: " & ex.Message)
        End Try
    End Function

End Module
