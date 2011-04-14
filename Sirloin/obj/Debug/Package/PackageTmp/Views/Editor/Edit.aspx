<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<Sirloin.Models.EditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <script src="<%=ResolveClientUrl("~/tinymce/jquery.tinymce.js")%>" type="text/javascript"></script>
    <script language ="javascript" type ="text/javascript">
        var tmscript_url = '<%=ResolveClientUrl("~/tinymce/tiny_mce.js")%>';
        var tmsitecss = '<%=ResolveClientUrl("~/Content/Site.css")%>';
    </script>
    <script src="<%=ResolveClientUrl("~/scripts/Editor.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <fieldset>
        <%=Html.HiddenFor(model=>model.PagetoEdit.PageID) %>
        <%=Html.HiddenFor(model=>model.PagetoEdit.CreationDate)%>
        <%=Html.HiddenFor(model=>model.PagetoEdit.LastModifiedDate)%>
        <%=Html.HiddenFor(model=>model.PagetoEdit.Published) %>
        <legend>Page information</legend>
        <div class="editor-label">
            <%= Html.Label("Page short id:")%>
        </div>
        <div class="editor-field">
            <%=Html.TextBoxFor(model => model.PagetoEdit.ShortID, new { @class = "textEditPage" })%>
        </div>
         <div class="editor-label">
            <%= Html.Label("Page Tittle:")%>
        </div>
        <div class="editor-field">
            <%=Html.TextBoxFor(model => model.PagetoEdit.Title, new { @class = "textEditPage" })%>
        </div>
        <div class="editor-label">
            <%= Html.Label("Page description:")%>
        </div>
        <div class="editor-field">        
            <%=Html.TextAreaFor(model => model.PagetoEdit.Description, new { @class = "textAreaEditPage" })%>
        </div>
        <div class="editor-label">
            <%= Html.Label("Page content:")%>
        </div>
        <div class="editor-field">
            <%=Html.TextAreaFor(model => model.PagetoEdit.PageContent, new { @class="tinymce"})%>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
