Public Class wInicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'SE CARGA INFORMACION DE LOS SENSORES
            Me.CagarInfoSensores()
        End If
    End Sub
#Region "PROPIEDADES"
    'ENUMERACION PARA EL CONTROL DE SENSORES DE METEOROLOGIA
    Public Enum EnmSensor
        VelViento = 1
        Temperatura = 2
    End Enum
#End Region
#Region "PROTEGIDO"
    Protected Sub ibtnRefrescar_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnRefrescar.Click
        'SE CARGA INFORMACION DE LOS SENSORES
        Me.CagarInfoSensores()
    End Sub
    Protected Sub btnActual_Click(sender As Object, e As EventArgs) Handles btnActual.Click
        Me.pnlActual.Visible = True
        Me.pnlHistorico.Visible = False

        'SE CARGA INFORMACION DE LOS SENSORES
        Me.CagarInfoSensores()
    End Sub
    Protected Sub btnHistorico_Click(sender As Object, e As EventArgs) Handles btnHistorico.Click
        Me.pnlActual.Visible = False
        Me.pnlHistorico.Visible = True

        Me.CargarHistorico()
    End Sub
#End Region
#Region "PRIVADO"
    Private Function CargarInfoMeteoXTipoSensor(ByVal parIdTipoSensor As EnmSensor) As wLaboratorioInfor2.SrvUno.DatosMeteorologicosDTO
        Dim objDatos As New SrvUno.MeteorologiaWSClient
        Dim varStrResult As New wLaboratorioInfor2.SrvUno.DatosMeteorologicosDTO
        Try

            varStrResult = objDatos.cargarValorSensorXIdSensor(parIdTipoSensor)
        Catch ex As System.ServiceModel.EndpointNotFoundException

            'MessageBox.Show("Error de comunicación con el servidor: " & ex.Message)
        Catch ex As System.Exception
            '
        Finally
            If objDatos.State = ServiceModel.CommunicationState.Opened Then
                objDatos.Close()
            End If
        End Try
        Return varStrResult
    End Function
    Private Function CargarHistoricoXSensor(ByVal parIdTipoSensor As EnmSensor) As wLaboratorioInfor2.srvUno.DatosMeteorologicosDTO()
        Dim objDatos As New srvUno.MeteorologiaWSClient
        Dim varStrResult() As wLaboratorioInfor2.srvUno.DatosMeteorologicosDTO
        Try

            varStrResult = objDatos.cargarValorHistoricoXIdSensor(parIdTipoSensor)
        Catch ex As System.ServiceModel.EndpointNotFoundException

            'MessageBox.Show("Error de comunicación con el servidor: " & ex.Message)
        Catch ex As System.Exception
            '
        Finally
            If objDatos.State = ServiceModel.CommunicationState.Opened Then
                objDatos.Close()
            End If
        End Try
        Return varStrResult
    End Function
    Private Sub CagarInfoSensores()
        Dim objDatosMeteo As New wLaboratorioInfor2.SrvUno.DatosMeteorologicosDTO

        objDatosMeteo = Me.CargarInfoMeteoXTipoSensor(1)

        Me.lblEstacion.Text = objDatosMeteo.estacion
        Me.lblFecha.Text = objDatosMeteo.fecha
        Me.lblLatitud.Text = objDatosMeteo.latitud
        Me.lblLongitud.Text = objDatosMeteo.longitud
        Me.lblVelViento.Text = objDatosMeteo.dato

        objDatosMeteo = Me.CargarInfoMeteoXTipoSensor(EnmSensor.Temperatura)

        Me.lblTemperatura.Text = objDatosMeteo.dato
    End Sub
    Private Sub CargarHistorico()
        Dim lstResultados() As wLaboratorioInfor2.srvUno.DatosMeteorologicosDTO

        Dim tblTmpVelViento As New Data.DataTable
        Dim tblTmpVelVientoRow As DataRow = tblTmpVelViento.NewRow()

        Dim tblTmpTemperatura As New Data.DataTable
        Dim tblTmpTemperaturaRow As DataRow = tblTmpTemperatura.NewRow()

        tblTmpVelViento.Columns.Add("tmpEstacion", GetType(Integer))
        tblTmpVelViento.Columns.Add("tmpFecha", GetType(Date))
        tblTmpVelViento.Columns.Add("tmpLatitud", GetType(Integer))
        tblTmpVelViento.Columns.Add("tmpLongitud", GetType(Integer))
        tblTmpVelViento.Columns.Add("tmpDato", GetType(Double))

        lstResultados = Me.CargarHistoricoXSensor(EnmSensor.VelViento)

        For Each itemViento As wLaboratorioInfor2.srvUno.DatosMeteorologicosDTO In lstResultados
            tblTmpVelVientoRow("tmpEstacion") = itemViento.estacion
            tblTmpVelVientoRow("tmpFecha") = itemViento.fecha
            tblTmpVelVientoRow("tmpLatitud") = itemViento.latitud
            tblTmpVelVientoRow("tmpLongitud") = itemViento.longitud
            tblTmpVelVientoRow("tmpDato") = itemViento.dato

            tblTmpVelViento.Rows.Add(tblTmpVelVientoRow)
        Next

        tblTmpTemperatura.Columns.Add("tmpEstacion", GetType(Integer))
        tblTmpTemperatura.Columns.Add("tmpFecha", GetType(Date))
        tblTmpTemperatura.Columns.Add("tmpLatitud", GetType(Integer))
        tblTmpTemperatura.Columns.Add("tmpLongitud", GetType(Integer))
        tblTmpTemperatura.Columns.Add("tmpDato", GetType(Double))


        lstResultados = Me.CargarHistoricoXSensor(EnmSensor.Temperatura)

        For Each itemViento As wLaboratorioInfor2.srvUno.DatosMeteorologicosDTO In lstResultados
            tblTmpTemperaturaRow("tmpEstacion") = itemViento.estacion
            tblTmpTemperaturaRow("tmpFecha") = itemViento.fecha
            tblTmpTemperaturaRow("tmpLatitud") = itemViento.latitud
            tblTmpTemperaturaRow("tmpLongitud") = itemViento.longitud
            tblTmpTemperaturaRow("tmpDato") = itemViento.dato

            tblTmpTemperatura.Rows.Add(tblTmpTemperaturaRow)
        Next


        Me.gvHistVelViento.DataSource = tblTmpVelViento
        Me.gvHistTemperatura.DataSource = tblTmpTemperatura

        Me.gvHistTemperatura.DataBind()
        Me.gvHistVelViento.DataBind()

    End Sub
#End Region
End Class