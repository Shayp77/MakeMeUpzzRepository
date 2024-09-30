<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactioonHandler.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Transaction Handler</h1>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="thgv" runat="server" AutoGenerateColumns="false" OnRowEditing="thgv_RowEditing">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" SortExpression="TransactionID"></asp:BoundField>
                    <asp:BoundField DataField="UserID" HeaderText="User Id" SortExpression="UserID"></asp:BoundField>
                    <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                    <asp:CommandField ShowCancelButton="False" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Handle?"></asp:CommandField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
