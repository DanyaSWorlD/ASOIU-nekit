<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddHero.aspx.cs" Inherits="Website.AddContract" %>

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

        .auto-style4 {
            width: 115px;
        }

        .auto-style5 {
            width: 115px;
            height: 25px;
        }

        .auto-style6 {
            height: 25px;
        }

        .auto-style7 {
            width: 115px;
            height: 29px;
        }

        .auto-style8 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="auto-style3">Фамилия:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Имя:</td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Злодей:</td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Text=" "/>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Сохранить" OnClick="Button1_Click" />
    <a href="admin.aspx">Отмена</a>
</asp:Content>
