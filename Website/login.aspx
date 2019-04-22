<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Website.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cnttable {
            width: 300px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table class="cnttable">
            <tr>
                <td>Логин</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="174px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Пароль</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="174px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:button runat="server" text="Регистрация" OnClick="Unnamed1_Click" />
                </td>
                <td>
                    <asp:button id="Button5" runat="server" text="Вход" OnClick="Button5_Click" Width="185px" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="Label2" runat="server" Text="Пароль введен неверно!" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>
