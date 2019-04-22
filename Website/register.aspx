<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Website.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 39%;
        }
        .auto-style2 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Регистрация</h1>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <label>Введите имя</label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Обязательное поле!" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>Введите e-mail</label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Введите действительный e-mail" ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>Введите пароль</label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="156px" TextMode="Password"></asp:TextBox>
            </td>
            <td></td>

        </tr>
        <tr>
            <td>
                <label>Повторите пароль</label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="156px" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="* Пароли не совпадают" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ForeColor="Red"></asp:CompareValidator>
            </td>

        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Зарегестрироваться!" OnClick="Button1_Click" />
</asp:Content>
