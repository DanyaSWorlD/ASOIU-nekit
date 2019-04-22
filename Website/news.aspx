<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Website.news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .div-content div {
            box-shadow: 0 0 4px 1px #0009;
            background: #dedede;
            border-radius: 3px;
        }

            .div-content div h1 {
                padding: 5px;
                color: blue;
                background: #b9b9b9;
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
