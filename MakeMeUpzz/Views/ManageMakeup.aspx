<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="MakeMeUpzz.Views.ManageMakeup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>-- Manage Makeup Page --</h1>
        <hr />

        <h2>Makeups Table</h2>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID"  />
                    <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                    <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                    <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />

                    <asp:BoundField DataField="MakeupType.MakeupTypeID" HeaderText="Type" SortExpression="MakeupTypeID" />
                    <asp:BoundField DataField="MakeupBrand.MakeupBrandID" HeaderText="Brand ID" SortExpression="MakeupBrandID" />

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <h2>Types Table</h2>
        <div>
            <asp:GridView ID="Type" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDeleting="Type_RowDeleting" OnRowEditing="UpdateType">
                <Columns>
                    <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
                    <asp:BoundField DataField="MakeupTypeName" HeaderText="Name" SortExpression="MakeupTypeName" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <h2>Brands Table</h2>
        <div>
            <asp:GridView ID="Brand" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDeleting="Brand_RowDeleting" OnRowEditing="UpdateBrand">
                <Columns>
                    <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
                    <asp:BoundField DataField="MakeupBrandName" HeaderText="Name" SortExpression="MakeupBrandName" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div>
            <asp:Button ID="InsertMakeup" runat="server" Text="Insert Makeup" onclick="InsertMakeup_Click"/>
        </div>

        <div>
            <asp:Button ID="InsertMakeupType" runat="server" Text="Insert Makeup Type" onclick="InsertMakeupType_Click"/>
        </div>

        <div>
            <asp:Button ID="InsertMakeupBrand" runat="server" Text="Insert Makeup Brand" onclick="InsertMakeupBrand_Click"/>
        </div>
    </form>
</body>
</html>
