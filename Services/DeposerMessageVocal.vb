Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class DeposerMessageVocal
    Private Const ApiUrl As String = "https://api.voicepartner.fr/v1/campaign/send"
    Private Const ApiKey As String = "YOUR_API_KEY"
    Private Const TokenAudio As String = "YOUR_TOKEN_AUDIO"
    Private Const EmailForNotification As String = "your@mail.com"
    Private Const PhoneNumbers As String = "06XXXXXXXX"

    Public Shared Async Function SendCampaignAsync() As Task
        Using client As New HttpClient()
            Dim payload = New With {
                .apiKey = ApiKey,
                .tokenAudio = TokenAudio,
                .emailForNotification = EmailForNotification,
                .phoneNumbers = PhoneNumbers
            }
            Dim content = New StringContent(JsonConvert.SerializeObject(payload), Text.Encoding.UTF8, "application/json")

            Try
                Dim response = Await client.PostAsync(ApiUrl, content)
                If response.IsSuccessStatusCode Then
                    Dim responseContent = Await response.Content.ReadAsStringAsync()
                    ' Handle success
                    Console.WriteLine(responseContent)
                Else
                    ' Handle failure
                    Console.WriteLine($"Error: {response.StatusCode}")
                End If
            Catch ex As Exception
                ' Handle error
                Console.WriteLine($"Exception: {ex.Message}")
            End Try
        End Using
    End Function
End Class
