<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddRide.aspx.cs" Inherits="Website.AddRide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }

        .auto-style3 {
            height: 23px;
            width: 115px;
        }

        .auto-style7 {
            width: 115px;
            height: 29px;
        }

        .auto-style8 {
            height: 29px;
        }
        .auto-style9 {
            width: 296px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="auto-style3">Начало:</td>
            <td class="auto-style2">
                <input type="text" runat="server" readonly="readonly" name="Date" id="Date" class="auto-style9" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Date" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Cтатус:</td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Сохранить" OnClick="Button1_Click" />
    <a href="admin.aspx">Отмена</a>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTypes" TypeName="Website.AddModel"></asp:ObjectDataSource>
</asp:Content>
