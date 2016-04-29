<%@ Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CacheControl.About" %>

<%@ OutputCache Duration="216000" VaryByParam="none" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Description page.</h3>
    <p class="text-danger"><i>This page caches for 1 hour</i></p>
</asp:Content>
