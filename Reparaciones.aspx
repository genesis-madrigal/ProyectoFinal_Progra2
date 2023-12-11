<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Reparaciones.aspx.cs" Inherits="ProyectoFinal_Progra2.Reparaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container text-center"> 
           
       <h1 class="display-3"> &nbsp;</h1>
           <h1 class="display-3"> Mantenimiento de Reparaciones </h1>
           <p class="display-3"> &nbsp;</p>

       <div class="d-flex justify-content-center">
            <br />
            <br />
            <asp:GridView ID="gvReparaciones" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="ReparacionID" HeaderText="ID de la Reparación" SortExpression="ReparacionID" />
                    <asp:BoundField DataField="EquipoID" HeaderText="ID del Equipo" SortExpression="EquipoID" />
                    <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de la Solicitud" SortExpression="FechaSolicitud" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                </Columns>
            </asp:GridView>

            <br />

            <br />

            <br />
       </div>

            <p> 
                &nbsp;</p>
           <p> 
               &nbsp;</p>
           <p> 
            <asp:Label ID="lblReparacionID" class="lead" runat="server" Text="ID de la Reparación:"></asp:Label>
        </p> 
        <asp:TextBox ID="txtReparacionID"  class="round form-control" runat="server"></asp:TextBox>
        <br />
           <p> 
            <asp:Label ID="lblEquipoID" class="lead" runat="server" Text="ID del Equipo:"></asp:Label>
        </p> 
           <p> 
          <asp:TextBox ID="txtEquipoID"  class="round form-control" runat="server"></asp:TextBox>
         <br />  

            <p> 
            <asp:Label ID="lblEstado" class="lead" runat="server" Text="Estado:"></asp:Label>
        </p> 
        <asp:DropDownList ID="ddlEstado"  class="round form-control" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
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
