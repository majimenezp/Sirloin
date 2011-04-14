<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Sirloin.Domain.Page>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index1</h2>

    <table>
        <tr>
            <th></th>
            <th>
                PageID
            </th>
            <th>
                ShortID
            </th>
            <th>
                Title
            </th>
            <th>
                Description
            </th>
            <th>
                PageContent
            </th>
            <th>
                CreationDate
            </th>
            <th>
                LastModifiedDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%= Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.PageID) %>
            </td>
            <td>
                <%= Html.Encode(item.ShortID) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%= Html.Encode(item.PageContent) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.CreationDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.LastModifiedDate)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

