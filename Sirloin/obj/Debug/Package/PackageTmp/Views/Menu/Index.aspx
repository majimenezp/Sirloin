<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<link href="<%=ResolveClientUrl("~/css/smoothness/jquery-ui-1.8.9.custom.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveClientUrl("~/Scripts/jquery-ui-1.8.9.custom.min.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/jquery.jstree.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/MenuEditor.js")%>" type="text/javascript"></script>    
    <script  language ="javascript" type ="text/javascript">
        var currentUrl = '<%=ResolveClientUrl("~/Menu/") %>';
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Menu hierachie</h2>
    <div class="left">
    <div id="menutree" class="menutree"></div>
    </div>
    <div class="right">
    <div id="pageslist" class="pageslist">
    </div>
    </div>


</asp:Content>
