<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Class.aspx.cs" Inherits="_Class" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>
    Class
    </td>
    <td>
        <asp:TextBox ID="txt_class" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="btn_submit" runat="server" Text="Submit" 
            onclick="btn_submit_Click" />
    </td>
    </tr>
    </table>
    <table>
    <tr>
    <td>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="code" PageSize="5">
        <Columns>
        <asp:BoundField HeaderText="Class" DataField="aclass" />
        </Columns>
        </asp:GridView>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
