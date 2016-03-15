<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Studant Deatils.aspx.cs"
    Inherits="Studant_Deatils" %>

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
                <td colspan="2">
                    <h1>
                        Studant Deatils
                    </h1>
                </td>
            </tr>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                </td>
                <tr>
                    <td>
                        Class
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_class" runat="server" DataTextField="class" DataValueField="intglcode"
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Section
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_section" runat="server" DataTextField="section" DataValueField="intglcode"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                    </td>
                </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        PageSize="5" DataKeyNames="code" OnRowEditing="GridView1_RowEditing">
                        <Columns>
                           
                            <asp:BoundField HeaderText="FirstName" DataField="firstname" />
                            <asp:BoundField HeaderText="LastName" DataField="lastname" />
                            <asp:BoundField HeaderText="UserName" DataField="username" />
                            <asp:BoundField HeaderText="Password" DataField="password" />
                            <asp:BoundField HeaderText="Class_id" DataField="class_id" />
                            <asp:BoundField HeaderText="Section_id" DataField="section_id" />
                            <asp:BoundField HeaderText="MobilNo" DataField="mobileno" />
                            <asp:BoundField HeaderText="EmailID" DataField="emailid" />
                             <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Link" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Edit" OnClick="LinkButton1_Click" CommandArgument='<%#Eval("code") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                     
                </td>
            </tr>
        </table>
            <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        PageSize="5" DataKeyNames="code" OnRowEditing="GridView1_RowEditing">
                        <Columns>
                           
                            <asp:BoundField HeaderText="FirstName" DataField="firstname" />
                            <asp:BoundField HeaderText="LastName" DataField="lastname" />
                            <asp:BoundField HeaderText="UserName" DataField="username" />
                            <asp:BoundField HeaderText="Password" DataField="password" />
                            <asp:BoundField HeaderText="Class_id" DataField="class_id" />
                            <asp:BoundField HeaderText="Section_id" DataField="section_id" />
                            <asp:BoundField HeaderText="MobilNo" DataField="mobileno" />
                            <asp:BoundField HeaderText="EmailID" DataField="emailid" />
                             <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Link" />
                         
                        </Columns>
                    </asp:GridView>

                     
                </td>
            </tr>
        </table>



    </div>
    </form>
</body>
</html>
