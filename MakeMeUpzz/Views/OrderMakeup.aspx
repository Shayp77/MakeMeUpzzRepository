<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderMakeup.aspx.cs" Inherits="MakeMeUpzz.Views.OrderMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="MakeUpGV" AutoGenerateColumns="false" runat="server" OnRowCommand="MakeUpGV_RowCommand" DataKeyNames="MakeupID">
    <Columns>
        <asp:BoundField DataField="MakeupID" HeaderText="MakeUpID" SortExpression="MakeupID"></asp:BoundField>
        <asp:BoundField DataField="MakeupName" HeaderText="MakeupName" SortExpression="MakeupName"></asp:BoundField>
        <asp:BoundField DataField="MakeupPrice" HeaderText="MakeupPrice" SortExpression="MakeupPrice"></asp:BoundField>
        <asp:BoundField DataField="MakeupWeight" HeaderText="MakeupWeight" SortExpression="MakeupWeight"></asp:BoundField>
        <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="MakeUpType" SortExpression="MakeupType.MakeupTypeName"></asp:BoundField>
        <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="MakeupBrands" SortExpression="MakeupBrand.MakeupBrandName"></asp:BoundField>
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:TextBox ID="QuantityTextBox" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnOrder" runat="server" Text="Order" CommandName="Order" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" />

    <asp:Button ID="cleartransaction" runat="server" Text="Clear carts" OnClick="cleartransaction_Click" />
</asp:Content>
