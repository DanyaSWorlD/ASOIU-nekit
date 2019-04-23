<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddFilm.aspx.cs" Inherits="Website.AddFilm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 58px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Название:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Сюжет:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Дата выхода:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Страна:</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" ErrorMessage="*Обязательное поле"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Количество серий:</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Width="300px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*число не верно" ValidationExpression="[0-9]+" ControlToValidate="TextBox5"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Режиссер:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Имя" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Режиссеры" TypeName="Website.DB"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Студия:</td>
            <td class="auto-style2">
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Название" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="Студии" TypeName="Website.DB"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
            </td>

            <td>
                <asp:CheckBoxList ID="CheckBoxList2" runat="server"></asp:CheckBoxList>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" />
</asp:Content>
