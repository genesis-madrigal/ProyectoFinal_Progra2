<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="SystemUsers.aspx.cs" Inherits="ProyectoFinal_Progra2.SystemUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
    <h1 class="display-3"> Mantenimiento de Usuarios del Sistema </h1>
    <p> &nbsp;</p>
    <p> &nbsp;</p>

<div class="d-flex justify-content-center">
    <asp:GridView ID="gvSystemUsers" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
        
        <Columns>
                    <asp:BoundField DataField="LogInUser" HeaderText="Log in del usuario" SortExpression="LogInUser" />
                    <asp:BoundField DataField="Clave" HeaderText="Clave" SortExpression="Clave" />
          </Columns>
    </asp:GridView>
</div>


</asp:Content>
