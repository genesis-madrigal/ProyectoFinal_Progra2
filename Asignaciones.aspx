<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="ProyectoFinal_Progra2.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container text-center">
    <h1 class="display-3"> Mantenimiento de Asignaciones </h1>
        <p class="display-3"> &nbsp;</p>
        <div class="d-flex justify-content-center">
            <br />
            <asp:GridView ID="gvAsignaciones" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="AsignacionID" HeaderText="ID de la Asignación" SortExpression="AsignacionID" />
                    <asp:BoundField DataField="ReparacionID" HeaderText="ID de la Reparación" SortExpression="ReparacionID" />
                    <asp:BoundField DataField="TecnicoID" HeaderText="ID del Técnico" SortExpression="TecnicoID" />
                    <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha de Asignación" SortExpression="FechaAsignacion" />
                </Columns>
            </asp:GridView>

            <br />
            <br />

            <br />
       </div>

            <p> 
            <asp:Label ID="lblAsignacionID" class="lead" runat="server" Text="ID de la Asignación:"></asp:Label>
        </p> 
        <asp:TextBox ID="txtAsignacionID"  class="round form-control" runat="server"></asp:TextBox>
        <br />
           <p> 
            <asp:Label ID="lblReparacionID" class="lead" runat="server" Text="ID de Reparación:"></asp:Label>
        </p> 
        <asp:DropDownList ID="ddlReparacion"  class="round form-control" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
         <br />  
            <p> 
            <asp:Label ID="lblTecnicoID" class="lead" runat="server" Text="ID del Técnico:"></asp:Label>
        </p> 
        <asp:DropDownList ID="ddlTecnicos"  class="round form-control" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
        <br />       
         

         
        <br /> 

        <asp:Button ID="btnAgregar" class="btn btn-outline-dark" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnConsultar" class="btn btn-outline-dark" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
        <asp:Button ID="btnModificar" class="btn btn-outline-dark" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" class="btn btn-outline-dark" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

        <br />
 
  </div> 
</asp:Content>
