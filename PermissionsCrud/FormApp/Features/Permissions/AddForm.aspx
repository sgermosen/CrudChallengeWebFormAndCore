<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddForm.aspx.cs" Inherits="FormApp.Features.Permissions.AddForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="form-group">
            <h1>Permission Edit</h1>
            <div class="col-md-12 ">
                <div class="col-md-12">
                    <div class="col-md-3">Employee Name :</div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-3">Employee Lastname :</div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtEmployeeLastname" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-3">Permission Type: </div>
                    <div class="col-md-3">
                         <asp:DropDownList ID="ddlPermissionType" runat="server" CssClass="form-control">  
                           <%-- <asp:ListItem Text="Select City" Value="select" Selected="True"></asp:ListItem>  
                            <asp:ListItem Text="Bangalore" Value="Bangalore"></asp:ListItem>  
                            <asp:ListItem Text="Mysore" Value="Mysore"></asp:ListItem>  
                            <asp:ListItem Text="Hubli" Value="hubli"></asp:ListItem> --%> 
                        </asp:DropDownList>  
                     </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-3">Permission Date</div>
                    <div class="col-md-3">
                      <asp:TextBox ID="calPermissionDate" runat="server"  CssClass="form-control" ></asp:TextBox>


                    </div>
                </div>
                 <asp:Label ID="LabelAction" runat="server"></asp:Label><br />  
                <div class="col-md-12">
                    <div class="col-md-3">
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-default" />
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

        <!-- Bootstrap -->
<script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
<!-- Bootstrap -->
<!-- Bootstrap DatePicker -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
<!-- Bootstrap DatePicker -->
<script type="text/javascript">
    $(function () {
        $('[id*=calPermissionDate]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd/mm/yyyy",
            language: "tr"
        });
    });
</script>
</asp:Content>
