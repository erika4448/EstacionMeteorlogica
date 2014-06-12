Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IwServicio1" in both code and config file together.
<ServiceContract()>
Public Interface ISrvUno

    <OperationContract()>
    Function GetFechaSever() As Date

    <OperationContract()>
    Function Calcular(ByVal parOperadorUno As Double, ByVal parOperadorDos As Double) As Double

    <OperationContract()>
    Function ConvertToFahrenheits(ByVal parValor As Double) As Double

    <OperationContract()>
    Function ConvertToCelsius(ByVal parValor As Double) As Double

    <OperationContract()>
    Function CargarValorSensorXIdSensor(ByVal parIdTipoSensor As Integer) As String
End Interface
