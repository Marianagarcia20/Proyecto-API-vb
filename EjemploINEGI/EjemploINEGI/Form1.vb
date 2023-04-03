Imports System.IO
Imports Newtonsoft.Json
Imports System.Net

Public Class Form1
    Private Async Sub PbxConsulta_Click(sender As Object, e As EventArgs) Handles PbxConsulta.Click
        Dim respuesta As String
        Try
            respuesta = Await Datos()
            DataGridView1.DataSource = JsonConvert.DeserializeObject(Of DatosEstablecimiento())(respuesta)
        Catch ex As WebException
            MessageBox.Show("Ocurrio un error en el servidor, vuelva a intentarlo.")
        End Try
    End Sub

    Async Function Datos() As Task(Of String)
        Dim url As String
        url = "https://www.inegi.org.mx/app/api/denue/v1/consulta/buscar/comercio/21.85717833,-102.28487238/295/aeb1ead1-ec6f-441e-92cd-28678fe6a3ba"
        Dim request As WebRequest = WebRequest.Create(url)
        Dim response As WebResponse = request.GetResponse()
        Dim Sr As StreamReader = New StreamReader(response.GetResponseStream())
        Return Await Sr.ReadToEndAsync()
    End Function
End Class
