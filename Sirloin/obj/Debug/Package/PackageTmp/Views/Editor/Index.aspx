<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.Master" Inherits="System.Web.Mvc.ViewPage<Sirloin.Models.EditorModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
      <table class="contentTable">
        <tr>
            <th ></th>
            <th>
               Page Id
            </th>
            <th>
                Title
            </th>
            <th>
                Description
            </th>
            <th>
            Published
            </th>
            <th>
                Creation date
            </th>
            <th>
                Last modification date
            </th>
        </tr>

    <% foreach (var item in Model.PagesList ) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new {  id=item.PageID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id = item.PageID })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id = item.PageID })%>
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
                <%=Html.CheckBoxFor(model=>item.Published) %>
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
