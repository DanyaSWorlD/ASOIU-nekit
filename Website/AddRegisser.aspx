﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddRegisser.aspx.cs" Inherits="Website.AddRide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Фамилия:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Имя:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Страна:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Информация:</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Сохранить" OnClick="Button1_Click" />
    <a href="admin.aspx">Отмена</a>
</asp:Content>
