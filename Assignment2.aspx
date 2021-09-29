<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignment2.aspx.cs" Inherits="WebApplication2.Assignment2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" DataKeyNames="Empid" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
               ShowFooter="true" EmptyDataText="No Records Found" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
                <Columns>
                    <asp:TemplateField HeaderText="Emp Name">
                        <ItemTemplate>
                            <asp:Label ID="lblEname" runat="server" Text='<%# Eval("EmpName")%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox id="txtEditEname" runat="server" PlaceHolder="Enter Emp Name" 
                                Text='<%# Eval("EmpName") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                              <asp:TextBox id="txtEname" runat="server" PlaceHolder="Enter Emp Name"  />
                        </FooterTemplate>
                    </asp:TemplateField>                
                    <asp:TemplateField HeaderText="Salary">
                        <ItemTemplate>
                            <asp:Label ID="lblSalary" runat="server" Text='<%# Eval("Salary")%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox id="txtEditSalary" runat="server" PlaceHolder="Enter Salary" 
                                Text='<%# Eval("Salary") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                              <asp:TextBox id="txtSalary" runat="server" PlaceHolder="Enter Salary"  />
                        </FooterTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" ToolTip="Edit" />
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" ToolTip="Delete" />
                            </ItemTemplate>
                        <EditItemTemplate>
                              <asp:LinkButton runat="server" ID="btnUpdate" Text="Update" CommandName="Update" ToolTip="Update" />
                            <asp:LinkButton runat="server" ID="btnCancel" Text="Cancel" CommandName="Cancel" ToolTip="Cancel" />                      
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAdd"  CommandName="AddNew" runat="server" Text="Add Record" />
                        </FooterTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
