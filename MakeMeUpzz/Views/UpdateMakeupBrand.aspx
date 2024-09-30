<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupBrand.aspx.cs" Inherits="MakeMeUpzz.Views.UpdateMakeupBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server">
        <h1>
            Update Makeup Brand
        </h1>
        <h2><%=Request.QueryString["id"]%></h2>
        </div>
     <div>
         <asp:Label ID="Label1" runat="server" Text="Name :"></asp:Label>
         <asp:TextBox ID="updatembnametb" runat="server"></asp:TextBox>
     </div>
     <div>
         <asp:Label ID="Label2" runat="server" Text="Rating :"></asp:Label>
         <asp:TextBox ID="updatembratetb" runat="server"></asp:TextBox>
     </div>
     <div>
         <asp:Button ID="backto" runat="server" Text="Back" OnClick="backto_Click"/>
         <asp:Button ID="updatebtn" runat="server" Text="Update" OnClick="updatebtn_Click1" />
     </div>
     <asp:Label ID="errorMsgLabel" runat="server" ForeColor="Red"></asp:Label>
   
</asp:Content>