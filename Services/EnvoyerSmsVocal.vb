Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Text

Public Class EnvoyerSmsVocal
    Private Const Url As String = "http://api.voicepartner.fr/v1/tts/send"

    Public Shared Async Function SendSmsVocalAsync() As Task
        Using client As New HttpClient()
            ' Remplacez ces valeurs par les vôtres
            Dim apiKey As String = "YOUR_API_KEY"
            Dim phoneNumbers As String = "06XXXXXXXX"
            Dim text As String = "Mon premier test"
            ' ... autres paramètres si nécessaire

            Dim data = New With {
                .apiKey = apiKey,
                .phoneNumbers = phoneNumbers,
                .text = text
            }

            Dim jsonContent = JsonConvert.SerializeObject(data)
            Using content As New StringContent(jsonContent, Encoding.UTF8, "application/json")
                Try
                    Dim response = Await client.PostAsync(Url, content)
                    Dim responseContent = Await response.Content.ReadAsStringAsync()

                    If response.IsSuccessStatusCode Then
                        Console.WriteLine(responseContent)
                    Else
                        Console.WriteLine($"Erreur lors de la requête: {response.StatusCode}")
                        Console.WriteLine($"Contenu: {responseContent}")
                    End If
                Catch ex As Exception
                    Console.WriteLine($"Exception: {ex.Message}")
                End Try
            End Using
        End Using
    End Function
End Class
