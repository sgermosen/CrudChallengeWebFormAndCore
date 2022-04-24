<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FormApp.Features.Permissions.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

    <div class="row">
        <div class="form-group">
            <h1>Permission Details</h1>
        <div class="col-md-12 ">
            <div class="col-md-12">
                <div class="col-md-3">Id :</div>
                <div class="col-md-3">
                    <asp:Label ID="lblId" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-3">Employee Name :</div>
                <div class="col-md-3">
                    <asp:Label ID="lblEmployeeName" runat="server" CssClass="form-control" ></asp:Label>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-3">Employee Lastname :</div>
                <div class="col-md-3">
                    <asp:Label ID="lblEmployeeLastname" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-3">Permission Description: </div>
                <div class="col-md-3">
                    <asp:Label ID="lblPermissionDescription" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-3">Permission Date</div>
                <div class="col-md-3">
                    <asp:Label ID="lblPermissionDate" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>

            <div class="col-md-12">
                <div class="col-md-3">
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click"   Text="Go Back To Permissions" CssClass="btn btn-default" />
                    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click"  Text="Edit" CssClass="btn btn-warning" />
                </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
