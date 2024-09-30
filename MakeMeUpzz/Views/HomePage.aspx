<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MakeMeUpzz.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>HomePage</h1>
<asp:Label ID="Welcomelabel" runat="server" Text=""></asp:Label>
<br />
<asp:Label ID="usercountlabel" runat="server" Text=""></asp:Label>
    <asp:GridView ID="UserData" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"></asp:BoundField>
            <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" SortExpression="UserEmail"></asp:BoundField>
            <asp:BoundField DataField="UserDOB" HeaderText="UserDOB" SortExpression="UserDOB"></asp:BoundField>
            <asp:BoundField DataField="UserGender" HeaderText="UserGender" SortExpression="UserGender"></asp:BoundField>
            <asp:BoundField DataField="UserRole" HeaderText="UserRole" SortExpression="UserRole"></asp:BoundField>
            <asp:BoundField DataField="UserPassword" HeaderText="UserPassword" SortExpression="UserPassword"></asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
