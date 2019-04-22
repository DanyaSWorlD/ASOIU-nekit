<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="lk.aspx.cs" Inherits="Website.lk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="32pt" ForeColor="Black"></asp:Label><br />
    <asp:Button ID="Button1" runat="server" Text="Выход" OnClick="Button1_Click" /><br />
    <asp:Label ID="Label2" runat="server" Text="Редактирование личных данных" Font-Size="16pt" ForeColor="Black"></asp:Label><br />
    <form method="post">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                   <label>Измените имя</label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server" Width="156px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Обязательное поле!" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Измените e-mail</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="156px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Введите действительный e-mail" ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Измените пароль</label>
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
                    <asp:TextBox ID="TextBox4" runat="server" Width="156px" TextMode="Password" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="* Пароли не совпадают" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ForeColor="Red"></asp:CompareValidator>
                </td>

            </tr>
        </table>
        <asp:Button ID="Button2" runat="server" Text="Редактировать!" />
    </form>

</asp:Content>
