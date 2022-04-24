<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FormApp.Features.Permissions.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
   
   
            <div class="row">  
    <h1>Permissions</h1>

               <a runat="server" href="~/Features/Permissions/AddForm" class="btn btn-primary"> + Add New Permission</a>
                <br />
                <br />
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" 
                    class="table table-bordered table-condensed table-responsive table-hover table-striped "
                    DataKeyNames="id" 
                    OnPageIndexChanging="gv_PageIndexChanging"  
                    OnRowDeleting="gv_RowDeleting" 
                    OnRowDataBound="gv_OnRowDataBound"
                    >  
                    <Columns>  
                        <asp:BoundField DataField="Id" HeaderText="ID" />  
                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" />  
                        <asp:BoundField DataField="EmployeeLastname" HeaderText="Last Name" />  
                        <asp:BoundField DataField="PermissionDate" HeaderText="Date" />  
                        <asp:BoundField DataField="PermissionDescription" HeaderText="Permission Type"  />  
                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Features/Permissions/Details.aspx?permissionId={0}"
                            Text="Details" ControlStyle-CssClass="btn btn-info" /> 
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" ButtonType="Button"   />  
                    </Columns>  
                     
                </asp:GridView>  
            </div>   
 
 
    <script>
        $(document).ready(function () {
            $('.table').DataTable({
                select: true,
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
        });
    </script>
</asp:Content>



