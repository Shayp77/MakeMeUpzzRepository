﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="MakeMeUpzz.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Profile Page</h1>
    <div>

    <h1>Update your details</h1>

        <div>
            <asp:Label ID="usernameLabel" runat="server" Text="Username: " />
            <asp:TextBox ID="usernameRegister" runat="server" Placeholder="Type your username"/>
        </div>
         <div>
            <asp:Label ID="emailLabel" runat="server" Text="Email: " />
            <asp:TextBox ID="emailRegister" runat="server" Placeholder="Type your email"/>
        </div>
         <div>
            <asp:RadioButton ID="male" runat="server" Text="male" GroupName="gender"/>
            <asp:RadioButton ID="female" runat="server" Text="female" GroupName="gender"/>
        </div>
        <div>
            <asp:Calendar ID="dobCalendar" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Button ID="UpdateButton" runat="server" Text="Submit" OnClick="UpdateButton_Click" />
        </div>

        <div>
            <asp:Label ID="updateerror" runat="server" Text=""></asp:Label>
        </div>
</div>  

    <div>
        <h1>Update Password</h1>
         <div>
     <asp:Label ID="passwordLabel" runat="server" Text="Password: " />
     <asp:TextBox ID="passwordRegister" runat="server" Placeholder="Old Password" TextMode="Password" />
 </div>
 <div>
     <asp:Label ID="newpassword" runat="server" Text="New Password: " />
     <asp:TextBox ID="newpasswordrupdate" runat="server" Placeholder="New Password" TextMode="Password" />
 </div>
        <div>
            <asp:Button ID="updatepassword" runat="server" Text="Update" OnClick="updatepassword_Click" />
        </div>
        <div>
            <asp:Label ID="passerr" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
