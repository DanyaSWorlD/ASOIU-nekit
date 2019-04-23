<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Website.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .style1 {
            text-align: center
        }
    </style>
    Фильмы:<asp:Button runat="server" Text="Добавить фильм" OnClick="Unnamed1_Click"/>
    <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="GridView5_RowCancelingEdit" OnRowDeleting="GridView5_RowDeleting" OnRowEditing="GridView5_RowEditing" OnRowUpdating="GridView5_RowUpdating">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="Название" HeaderText="Название" SortExpression="Название" />
            <asp:BoundField DataField="Сюжет" HeaderText="Сюжет" SortExpression="Сюжет" />
            <asp:BoundField DataField="Дата_выхода" HeaderText="Дата_выхода" SortExpression="Дата_выхода" />
            <asp:BoundField DataField="Страна" HeaderText="Страна" SortExpression="Страна" />
            <asp:BoundField DataField="Количество_серий" HeaderText="Количество_серий" SortExpression="Количество_серий" />
            <asp:BoundField DataField="Режиссер" HeaderText="Режиссер" SortExpression="Режиссер" />
            <asp:BoundField DataField="Студия" HeaderText="Студия" SortExpression="Студия" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Website.Фильмы" DeleteMethod="УдалитьФильм" SelectMethod="Фильмы" TypeName="Website.DB" UpdateMethod="ОбновитьФильм"></asp:ObjectDataSource>
    Актеры:<asp:Button ID="Button1" runat="server" Text="Добавить актера" OnClick="Button1_Click" />&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ModelsDataSource" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" ClientIDMode="Static" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnRowDeleting="GridView1_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            <asp:BoundField DataField="Фамилия" HeaderText="Фамилия" SortExpression="Фамилия" />
            <asp:BoundField DataField="Имя" HeaderText="Имя" SortExpression="Имя" />
            <asp:BoundField DataField="Страна" HeaderText="Страна" SortExpression="Страна" />
            <asp:BoundField DataField="Год" HeaderText="Год" SortExpression="Год" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" CssClass="style1" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ModelsDataSource" runat="server" DataObjectTypeName="Website.Актеры" DeleteMethod="УдалитьАктера" SelectMethod="Актеры" TypeName="Website.admin" UpdateMethod="ОбновитьАктера"></asp:ObjectDataSource>
    <br />


    Студии:
    <asp:Button ID="Button2" runat="server" Text="Добавить студию" OnClick="Button2_Click" />
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="RidesDataSource" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnRowDeleting="GridView2_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Название" HeaderText="Название" SortExpression="Название" />
            <asp:BoundField DataField="Страна" HeaderText="Страна" SortExpression="Страна" />
            <asp:BoundField DataField="Адрес" HeaderText="Адрес" SortExpression="Адрес" />
            <asp:BoundField DataField="Телефон" HeaderText="Телефон" SortExpression="Телефон" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" CssClass="style1" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <br />
    <asp:ObjectDataSource ID="RidesDataSource" runat="server" SelectMethod="Студии" TypeName="Website.admin" DataObjectTypeName="Website.Студии" DeleteMethod="УдалитьСтудию" UpdateMethod="ОбновитьСтудию"></asp:ObjectDataSource>
    Режиссеры:
    <asp:Button ID="Button3" runat="server" Text="Добавить режиссера" OnClick="Button3_Click" />
    <br />
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" AllowPaging="True" DataSourceID="РежиссерыDataSource" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnRowDeleting="GridView3_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Фамилия" HeaderText="Фамилия" SortExpression="Фамилия" />
            <asp:BoundField DataField="Имя" HeaderText="Имя" SortExpression="Имя" />
            <asp:BoundField DataField="Страна" HeaderText="Страна" SortExpression="Страна" />
            <asp:BoundField DataField="Информация" HeaderText="Информация" SortExpression="Информация" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" CssClass="style1" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:ObjectDataSource ID="РежиссерыDataSource" runat="server" DataObjectTypeName="Website.Режиссеры" DeleteMethod="УдалитьРежиссера" SelectMethod="Режиссеры" TypeName="Website.admin" UpdateMethod="ОбновитьРежиссера"></asp:ObjectDataSource>
    <br />
    Персонажи:
    <asp:Button ID="Button4" runat="server" Text="Добавить персонажа" OnClick="Button4_Click" />
    <br />
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="GridView4_RowCancelingEdit" OnRowEditing="GridView4_RowEditing" OnRowUpdating="GridView4_RowUpdating" AllowPaging="True" DataSourceID="Персонажи" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnRowDeleting="GridView4_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Фамилия" HeaderText="Фамилия" SortExpression="Фамилия" />
            <asp:BoundField DataField="Имя" HeaderText="Имя" SortExpression="Имя" />
            <asp:CheckBoxField DataField="Злодей" HeaderText="Злодей" SortExpression="Злодей" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" CssClass="style1" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ПерсонажиDataSource" runat="server" DataObjectTypeName="Website.Персонажи" DeleteMethod="ОбновитьПерсонажа" SelectMethod="Персонажи" TypeName="Website.admin" UpdateMethod="ОбновитьПерсонажа"></asp:ObjectDataSource>
    <br />
</asp:Content>
