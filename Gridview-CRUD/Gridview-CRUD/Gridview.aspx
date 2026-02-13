<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gridview.aspx.cs" Inherits="Gridview_CRUD.Gridview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student CRUD</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background: #f4f6f9;
        }

        .container {
            width: 500px;
            margin: 50px auto;
            background: #ffffff;
            padding: 25px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .row {
            margin-bottom: 15px;
        }

        label {
            display: inline-block;
            width: 100px;
            font-weight: bold;
        }

        input[type=text], select {
            width: 250px;
            padding: 6px;
            border-radius: 4px;
            border: 1px solid #ccc;
        }

        .btn {
            background: #007bff;
            color: white;
            padding: 8px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn:hover {
            background: #0056b3;
        }

        .grid {
            margin-top: 20px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">

            <h2>Student CRUD</h2>

            <div class="row">
                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" 
                    runat="server" 
                    ControlToValidate="txtName" 
                    ErrorMessage="Required" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>

            <div class="row">
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a valid email address" ForeColor="Red" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"> </asp:RegularExpressionValidator>
            </div>

            <div class="row">
                <asp:Label ID="lblCourse" runat="server" Text="Course:"></asp:Label>
                <asp:DropDownList ID="ddlCourse" runat="server">
                    <asp:ListItem Text="-- Select Course --" Value="0"></asp:ListItem>
                    <asp:ListItem>BCA</asp:ListItem>
                    <asp:ListItem>MCA</asp:ListItem>
                    <asp:ListItem>BTech</asp:ListItem>
                    <asp:ListItem>MTech</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="row">
                <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label>
                <asp:TextBox ID="txtAge" runat="server">
                </asp:TextBox><asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" MinimumValue="1" MaximumValue="100" Type="Integer" ErrorMessage="Age must be between 1 and 100" ForeColor="Red"> </asp:RangeValidator>
            </div>

            <div class="row">
                <asp:Button ID="btnSubmit" runat="server" 
                    Text="Submit" CssClass="btn" 
                    OnClick="btnSubmit_Click" />
            </div>

            <div class="grid">
                <asp:GridView ID="gvStudent" runat="server"
                    HeaderStyle-BackColor="#007bff"
                    HeaderStyle-ForeColor="White"
                    BorderColor="#ddd"
                    AutoGenerateColumns="false"
                    DataKeyNames="StudentId"
                    BorderWidth="1px"
                    OnRowEditing="gvStudent_RowEditing"
                    OnRowCancelingEdit="gvStudent_RowCancelingEdit"
                    OnRowUpdating="gvStudent_RowUpdating"
                    OnRowDeleting="gvStudent_RowDeleting" OnRowDataBound="gvStudent_RowDataBound" >
                    <Columns>
                            <asp:BoundField DataField="StudentId" HeaderText="ID" ReadOnly="true" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Course" HeaderText="Course" />
                            <asp:BoundField DataField="Age" HeaderText="Age" />
                            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"  CausesValidation="false"/>
                    </Columns>
                   </asp:GridView>
            </div>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

        </div>
    </form>
</body>
</html>