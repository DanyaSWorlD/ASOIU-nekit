<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Website._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }

        .style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Список спецтехники:</h1>
    <div>
        <table class="style1">
            <tr>
                <th class="auto-style1">Фильтр по режиссеру</th>
                <th class="auto-style1">Фильтр по студии</th>
                <th class="auto-style1">Фильтр по названию</th>
                <th class="auto-style1">Фильтр по стране</th>
                <th class="auto-style1">Фильтр по количеству серий</th>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnTextChanged="DropDownList1_TextChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td>
                    <div>
                        от
                        <asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                        до
                        <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button runat="server" Text="Сброс фильтров" OnClick="Unnamed1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="MainSource" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnRowCommand="GridView1_RowCommand">
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="Название" HeaderText="Название" SortExpression="Название" ReadOnly="True" />
            <asp:BoundField DataField="Страна" HeaderText="Страна" SortExpression="Страна" ReadOnly="True" />
            <asp:BoundField DataField="Сюжет" HeaderText="Сюжет" SortExpression="Сюжет" ReadOnly="True" />
            <asp:BoundField DataField="Дата_выхода" HeaderText="Дата_выхода" SortExpression="Дата_выхода" ReadOnly="True" />
            <asp:BoundField DataField="Количество_серий" HeaderText="Количество_серий" SortExpression="Количество_серий" ReadOnly="True" />
            <asp:BoundField DataField="Режиссер" HeaderText="Режиссер" SortExpression="Режиссер" ReadOnly="True" />
            <asp:BoundField DataField="Студия" HeaderText="Студия" SortExpression="Студия" ReadOnly="True" />
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" CssClass="style1" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="MainSource" runat="server" SelectMethod="Фильмы" TypeName="Website._default"></asp:ObjectDataSource>
</asp:Content>
