<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ReporteGeneral.aspx.cs" Inherits="ProyectoFinal_Progra2.ReporteGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center"> 
           
       <h1 class="display-3"> &nbsp;</h1>
           <h1 class="display-3"> Reporte de Información General </h1>
           <p class="display-3"> &nbsp;</p>

       <div class="d-flex justify-content-center">
            <br />
            <br />
            <asp:GridView ID="gvReporte" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="ID Usuario" HeaderText="ID de la Reparación" SortExpression="ID Usuario" />
                    <asp:BoundField DataField="Telefono" HeaderText="Télefono" SortExpression="Telefono" />
                    <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                    <asp:BoundField DataField="ID Equipo" HeaderText="ID del Equipo" SortExpression="ID Equipo" />
                    <asp:BoundField DataField="Detalle reparacion" HeaderText="Detalle Reparación" SortExpression="Detalle reparacion" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    <asp:BoundField DataField="Fecha Inicio" HeaderText="Fecha Inicio" SortExpression="Fecha Inicio" />
                    <asp:BoundField DataField="Fecha Fin" HeaderText="Fecha Fin" SortExpression="Fecha Fin" />
                    <asp:BoundField DataField="ID Tecnico" HeaderText="ID del Técnico" SortExpression="ID Tecnico" />
                    <asp:BoundField DataField="ID Reparacion" HeaderText="ID de la Reparación" SortExpression="ID Reparacion" />
                    <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de la Solicitud" SortExpression="FechaSolicitud" />
                </Columns>
            </asp:GridView>

            <br />

            <br />

            <br />
       </div>

            <p>  
                &nbsp;</p>
        <p>  
            <asp:Label ID="lblTecnicoID" class="lead" runat="server" Text="ID del Técnico:"></asp:Label>
             </p>
             <p>  
             <asp:DropDownList ID="ddlTecnicos"  class="round form-control" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
            </p>

       <asp:Button ID="btnConsultar" class="btn btn-outline-dark" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
       <asp:Button ID="btnLimpiar" class="btn btn-outline-dark" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />

        

</asp:Content>
 