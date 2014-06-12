<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wInicio.aspx.vb" Inherits="wLaboratorioInfor2.wInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .clima {
            background-image: url('images/clima.jpg');
            background-repeat: repeat-x;
        }
        input[type="submit"], input[type="button"] {
    padding: 5px 15px 5px 15px;
    border-style: none;
    border-width: 1px;
    color: #FFF;
    background-color: #55A9DF;
    border-radius: 5px;
    -webkit-border-radius: 5px;
    -moz-border-radius: 5px;
    font-family: Arial, Helvetica, sans-serif;
    font-size: 14pt;
    font-weight: bold;
    margin-right: 0px;
}
    </style>
</head>
<body style="background-image: url('Images/clima.jpg'); background-repeat: repeat;">
    <form id="form1" runat="server">
        <div style="vertical-align: middle; margin-top: 10%">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="upnlMeteo" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td>

                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="50px" ForeColor="White" Text="METEOROLOGÍA.com"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnActual" runat="server" Text="Actual" />
                                <asp:Button ID="btnHistorico" runat="server" Text="Histórico" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Panel ID="pnlActual" runat="server">
                                    <table style="background-color: #333333; font-family: 'century Gothic'; font-size: 20px; color: #FFFFFF; opacity:0.7;filter:alpha(opacity=70); padding: 70px">
                                    <tr>
                                        <td>
                                            <table style=" opacity:1;filter:alpha(opacity=100);">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label4" runat="server" Text="Estación" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblEstacion" runat="server" Text="-"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label6" runat="server" Text="Fecha" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblFecha" runat="server" Text="-"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label8" runat="server" Text="Latitud" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblLatitud" runat="server" Text="-"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label10" runat="server" Text="Longitud" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblLongitud" runat="server" Text="-"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label2" runat="server" Text="Velocidad del Viento" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblVelViento" runat="server" Text="-"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label3" runat="server" Text="Temperatura" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblTemperatura" runat="server" Text="-"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlHistorico" runat="server">
                                    <table align="center"  style="background-color: #333333; font-family: 'century Gothic'; font-size: 20px; color: #FFFFFF; opacity:0.7;filter:alpha(opacity=70); padding: 70px">
                                        <tr>
                                            <td align="center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text="Histórico Velocidad del Viento" Font-Bold="True" ForeColor="#3399FF"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvHistVelViento" runat="server" AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:BoundField DataField="tmpEstacion" HeaderText="Estacion" />
                                                                    <asp:BoundField DataField="tmpFecha" HeaderText="Fecha Lectura" />
                                                                    <asp:BoundField DataField="tmpLatitud" HeaderText="Latitud" />
                                                                    <asp:BoundField DataField="tmpLongitud" HeaderText="Longitud" />
                                                                    <asp:BoundField DataField="tmpDato" HeaderText="Valor" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                             <td align="center">
                                                 <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text="Histórico Temperatura" Font-Bold="True" ForeColor="#0099FF"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvHistTemperatura" runat="server" AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:BoundField DataField="tmpEstacion" HeaderText="Estacion" />
                                                                    <asp:BoundField DataField="tmpFecha" HeaderText="Fecha Lectura" />
                                                                    <asp:BoundField DataField="tmpLatitud" HeaderText="Latitud" />
                                                                    <asp:BoundField DataField="tmpLongitud" HeaderText="Longitud" />
                                                                    <asp:BoundField DataField="tmpDato" HeaderText="Valor" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="ibtnRefrescar" runat="server" ImageUrl="~/Images/ibtnRefresh.png" ToolTip="Refrescar" Height="60px" Width="66px" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
