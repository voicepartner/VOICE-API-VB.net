Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class RenommerFichierAudio
    Private ReadOnly _url As String = "https://api.voicepartner.fr/v1/audio-file/rename"
    Private ReadOnly _apiKey As String = "YOUR_API_KEY"
    Private ReadOnly _tokenAudio As String = "YOUR_TOKEN_AUDIO"
    Private ReadOnly _filename As String = "YOUR_FILE_NAME"

    Public Async Function RenameAudioFile() As Task
        Dim httpClient As New HttpClient()

        Dim data As New With {
            .apiKey = _apiKey,
            .tokenAudio = _tokenAudio,
            .filename = _filename
        }

        Dim jsonContent As String = JsonConvert.SerializeObject(data)
        Using content As New StringContent(jsonContent, Encoding.UTF8, "application/json")
            Try
                Dim response As HttpResponseMessage = Await httpClient.PostAsync(_url, content)
                If response.IsSuccessStatusCode Then
                    Dim responseContent As String = Await response.Content.ReadAsStringAsync()
                    Console.WriteLine(responseContent)
                Else
                    Console.WriteLine("Error: " & response.StatusCode)
                End If
            Catch ex As Exception
                Console.WriteLine("Erreur lors de la requête: " & ex.Message)
            End Try
        End Using
    End Function

End Class
