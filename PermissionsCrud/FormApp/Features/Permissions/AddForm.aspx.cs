using Domain.Entities;
using FormApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FormApp.Features.Permissions
{
    public partial class AddForm : System.Web.UI.Page
    {
        private readonly IDataService _dataService;

        public AddForm(IDataService dataService)
        {
            _dataService = dataService;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var permissionTypes = _dataService.GetPermissionTypess();

                foreach (var item in permissionTypes)
                {
                    ddlPermissionType.Items.Add(item.Description);
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var selectedId = Convert.ToInt32(Request.QueryString["permissionId"]);
            Response.Redirect($"~/Features/Permissions/Details.aspx?permissionId={selectedId}");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var permissions = _dataService.GetPermissions();
            var newId = permissions.Count + 1;
            string dateFromView = Request.Form[calPermissionDate.UniqueID];
            DateTime permissionDate;
            bool temp = DateTime.TryParseExact(dateFromView, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out permissionDate);
            var permissionTypeId = ddlPermissionType.SelectedIndex + 1;
            var permissionDb = new Permission
            {
                Id = newId,
                EmployeeLastname = txtEmployeeLastname.Text,
                EmployeeName = txtEmployeeName.Text,
                PermissionDate = permissionDate,
                PermissionTypeId = permissionTypeId,
                PermissionType = ((List<PermissionType>)Session["PermissionTypes"]).Find(x => x.Id == permissionTypeId)
            };

            permissions.Add(permissionDb);
            Session["Permissions"] = permissions;
            Session["PermissionId"] = 0;
            Server.Transfer($"~/Features/Permissions/{nameof(Index)}.aspx");
        }
    }
}