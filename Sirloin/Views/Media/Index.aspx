<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<Sirloin.Models.MediaModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <table>
        <tr>
            <th>
                Commands
            </th>
            <th>
                File name
            </th>
            <th>
                Type
            </th>
            <th>
                Preview
            </th>
        </tr>
        <% foreach (var item in Model.MediaFiles)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %>
                |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
                |
                <%= Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%=Html.Encode(item.FileName) %>
            </td>
            <td>
                <%=Html.Encode(item.Extension) %>
            </td>
            <td>
                <img  alt='<%=Html.Encode(item.FileName) %>' src ='<%=ResolveClientUrl(item.ThumbNailUrl) %>'/>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
