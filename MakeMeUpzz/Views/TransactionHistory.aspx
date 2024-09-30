<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>-- Transaction History --</h1>
        <hr />

        <div>
            <asp:GridView ID="HeaderUser" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="TransactionDetailsButton" runat="server" Text="Transaction Details" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' OnClick="TransactionDetailsButton_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div>
            <asp:GridView ID="HeaderAdmin" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="TransactionDetailsButton" runat="server" Text="Transaction Details" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' OnClick="TransactionDetailsButton_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


    </form>
</body>
</html>
