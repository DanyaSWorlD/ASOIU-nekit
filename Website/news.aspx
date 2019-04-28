<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Website.news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            .div-content div {
                background: #dedede;
                border-radius: 3px;
                border: 1px solid #7e7c9e;
                margin-bottom: 45px;
            }

            .div-content div h1 {
                padding: 5px;
                color: #7e7c9e;
                background: #fff;
            }

            .div-content div p {
                margin: 5px;
                padding-bottom: 16px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" runat="server" class="div-content"></div>
</asp:Content>
