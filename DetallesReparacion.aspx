<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="DetallesReparacion.aspx.cs" Inherits="ProyectoFinal_Progra2.DetallesReparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container text-center">
    <h1 class="display-3"> Mantenimiento de Detalles </h1>
        <p class="display-3"> &nbsp;</p>

       <div class="d-flex justify-content-center">
            <br />
            <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="DetalleID" HeaderText="ID de los detalles" SortExpression="DetalleID" />
                    <asp:BoundField DataField="ReparacionID" HeaderText="ID de la Reparación" SortExpression="ReparacionID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                    <asp:BoundField DataField="Tecnico" HeaderText="Nombre del Técnico" SortExpression="Tecnico" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Asignación" SortExpression="FechaInicio" />
                    <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Finalización" SortExpression="FechaFin" />
                </Columns>
            </asp:GridView>
      </div>

            <br />
         <p>
           <asp:Label ID="lblDetalleID" class="lead" runat="server" Text="ID del detalle:"></asp:Label>
        </p> 
        <asp:TextBox ID="txtDetalleID"  class="round form-control" runat="server"></asp:TextBox>
           <p>            
          <asp:Label ID="lblReparacionID" class="lead" runat="server" Text="ID de la Reparación:"></asp:Label>
        </p> 
        <asp:DropDownList ID="ddlReparaciones"  class="round form-control" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
         <p> 
       <asp:Label ID="lblDescripcion" class="lead" runat="server" Text="Descripción:"></asp:Label>
        </p> 
        <asp:TextBox ID="txtDescripcion"  class="round form-control" runat="server"></asp:TextBox>
           <p> 
            <asp:Label ID="lblFechaFin" class="lead" runat="server" Text="Fecha de finalización de la reparación:"></asp:Label>
        </p> 
        <asp:TextBox ID="txtFechaFin"  type="date" class="round form-control" runat="server"></asp:TextBox>
         <br />  

        <br />  

            <br />

        <asp:Button ID="btnAgregar" class="btn btn-outline-dark" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnConsultar" class="btn btn-outline-dark" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
        <asp:Button ID="btnModificar" class="btn btn-outline-dark" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" class="btn btn-outline-dark" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <br />

         
       </div>

</asp:Content>
