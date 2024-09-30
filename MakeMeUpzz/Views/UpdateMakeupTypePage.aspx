<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupTypePage.aspx.cs" Inherits="MakeMeUpzz.Views.UpdateMakeupTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="UpdateMakeupTypeView" runat="server">
    <h1>-- Update Makeup Type Page --</h1>
    <h2><%=Request.QueryString["id"]%></h2>
    <hr />
    <div>
        <asp:Label ID="MakeupTypeNameLbl" runat="server" Text="Makeup Type Name"></asp:Label>
        <asp:TextBox ID="MakeupTypeNameTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="UpdateMakeupTypeBtn" runat="server" Text="Update" OnClick="UpdateMakeupTypeBtn_Click"/>
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text=" " ForeColor="Red"></asp:Label>
    </div>
</div>

</asp:Content>
