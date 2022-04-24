using FormApp.Models;
using FormApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FormApp.Features.Permissions
{
    public partial class EditForm : System.Web.UI.Page
    {
        private readonly IDataService _dataService;

        public EditForm(IDataService dataService)
        {
            _dataService = dataService;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var permissionIdRoute = Convert.ToInt32(Request.QueryString["permissionId"]);
                var permissionIdSession = Convert.ToInt32(Session["PermissionId"]);

                if (permissionIdRoute == 0 || permissionIdSession == 0 || permissionIdSession != permissionIdRoute)
                    Server.Transfer($"~/{nameof(NoFoundPage)}.aspx");
                else
                {
                    var permissionTypes = _dataService.GetPermissionTypess();

                    foreach (var item in permissionTypes)
                    {
                        ddlPermissionType.Items.Add( item.Description);
                    }
                    var permission = _dataService.GetPermission(permissionIdSession);
                    if (permission.Id != 0)
                    {
                        txtEmployeeName.Text = permission.EmployeeName;
                        txtEmployeeLastname.Text = permission.EmployeeLastname;
                        
                        calPermissionDate.Text = permission.PermissionDate.ToString("dd/MM/yyyy");
                        ddlPermissionType.SelectedIndex = (permission.PermissionTypeId - 1);

                    }
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
            var permissionId = Convert.ToInt32(Session["PermissionId"]);
            var permissions = _dataService.GetPermissions();
            var permissionDb = permissions.Find(x => x.Id == permissionId);
            if (permissionDb != null)
            {
                permissions.Remove(permissionDb);
                //permissionDb.PermissionDate = ManageDate(txtPermissionDate.Text);
                permissionDb.EmployeeLastname = txtEmployeeLastname.Text;
                permissionDb.EmployeeName = txtEmployeeName.Text;
                string dateFromView = Request.Form[calPermissionDate.UniqueID];
                DateTime permissionDate;
                bool temp = DateTime.TryParseExact(dateFromView, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out permissionDate);
                permissionDb.PermissionDate = permissionDate;
                  permissionDb.PermissionTypeId = ddlPermissionType.SelectedIndex + 1;
                permissionDb.PermissionType =  ((List<PermissionType>)Session["PermissionTypes"]).Find(x=> x.Id == permissionDb.PermissionTypeId) ;

                permissions.Add(permissionDb);
                Session["Permissions"] = permissions;
            }

            Response.Redirect($"~/Features/Permissions/Details.aspx?permissionId={permissionId}");
        }
    }
}