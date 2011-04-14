<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<Sirloin.Models.ControlPanelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Control Panel</h2>

    <a href ='<%=ResolveClientUrl("~/Editor/") %>'> View the page list</a>
    <a href='<%=ResolveClientUrl("~/Editor/Edit/0")%>'> Create a new page</a>
    <a href='<%=ResolveClientUrl("~/Media/")%>'> Media gallery</a>

</asp:Content>
