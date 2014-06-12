' NOTE: You can use the "Rename" command on the context menu to change the class name "wServicio1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select wServicio1.svc or wServicio1.svc.vb at the Solution Explorer and start debugging.
Public Class SrvUno
    Implements ISrvUno


    Public Function GetFechaSever() As Date Implements ISrvUno.GetFechaSever
        Return Date.Now
    End Function

    Public Function Calcular(ByVal parOperadorUno As Double, ByVal parOperadorDos As Double) As Double Implements ISrvUno.Calcular
        'Dim objIPDatos As New srvIPDatos.IsrvIPDatosClient
        'Dim varUrlRtnl As String = ""
        'Try
        '    varUrlRtnl = objIPDatos.CargarURLGeneracionTarea(parIdClaCab, Me.GetStrSender())
        'Catch ex As System.ServiceModel.EndpointNotFoundException
        '    pBooCnn = False
        '    MessageBox.Show("Error de comunicación con el servidor: " & ex.Message)
        '    '''Catch ex As System.Exception
        '    ''' Me.lblMensaje.Text = String.Format("Error generando URL : Error:{0}", ex.Message)
        'Finally
        '    If objIPDatos.State = ServiceModel.CommunicationState.Opened Then
        '        objIPDatos.Close()
        '    End If
        'End Try
        'Return varUrlRtnl
        Return 0
    End Function

    Public Function ConvertToFahrenheits(ByVal parValor As Double) As Double Implements ISrvUno.ConvertToFahrenheits
        Return 0
    End Function
    Public Function ConvertToCelsius(ByVal parValor As Double) As Double Implements ISrvUno.ConvertToCelsius
        Return 0
    End Function
    Public Function CargarValorSensorXIdSensor(ByVal parIdTipoSensor As Integer) As String Implements ISrvUno.CargarValorSensorXIdSensor
        Dim rn As New Random

        If (parIdTipoSensor = 1) Then
            Return rn.Next(1, 50).ToString() & " K/h"
        ElseIf (parIdTipoSensor = 2) Then
            Return rn.Next(1, 40).ToString() & " ºC"
        Else
            Return "-"
        End If
    End Function
End Class
