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
    <h1>Список фильмов:</h1>
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
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox></td>
                <td>
                    <div>
                        от
                        <asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                        до
                        <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button runat="server" Text="Сброс фильтров" OnClick="Unnamed1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="MainSource" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="add" Text="Добавить в корзину" />
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="Название" HeaderText="Название" SortExpression="Название" ReadOnly="True" />
            <asp:BoundField DataField="Страна" HeaderText="Страна" SortExpression="Страна" ReadOnly="True" />
            <asp:BoundField DataField="Сюжет" HeaderText="Сюжет" SortExpression="Сюжет" ReadOnly="True" />
            <asp:BoundField DataField="Дата_выхода" HeaderText="Дата_выхода" SortExpression="Дата_выхода" ReadOnly="True" />
            <asp:BoundField DataField="Количество_серий" HeaderText="Количество_серий" SortExpression="Количество_серий" ReadOnly="True" />
            <asp:BoundField DataField="Режиссер" HeaderText="Режиссер" SortExpression="Режиссер" ReadOnly="True" />
            <asp:BoundField DataField="Студия" HeaderText="Студия" SortExpression="Студия" ReadOnly="True" />
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" CssClass="style1" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:ObjectDataSource ID="MainSource" runat="server" SelectMethod="Фильмы" TypeName="Website._default"></asp:ObjectDataSource>
    <table>
        <td>
            Актеры
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="АктерыDataSource">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="Фамилия" HeaderText="Фамилия" SortExpression="Фамилия" />
                    <asp:BoundField DataField="Имя" HeaderText="Имя" SortExpression="Имя" />
                    <asp:BoundField DataField="Страна" HeaderText="Страна" SortExpression="Страна" />
                    <asp:BoundField DataField="Год" HeaderText="Год" SortExpression="Год" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="АктерыDataSource" runat="server" SelectMethod="Актеры" TypeName="Website._default"></asp:ObjectDataSource>
        </td>
        <td>
            Персонажи
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ПерсонажиDataSource">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="Фамилия" HeaderText="Фамилия" SortExpression="Фамилия" />
                    <asp:BoundField DataField="Имя" HeaderText="Имя" SortExpression="Имя" />
                    <asp:CheckBoxField DataField="Злодей" HeaderText="Злодей" SortExpression="Злодей" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ПерсонажиDataSource" runat="server" SelectMethod="Персонажи" TypeName="Website._default"></asp:ObjectDataSource>
        </td>
    </table>
</asp:Content>
