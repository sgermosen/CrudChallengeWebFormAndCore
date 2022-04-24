using FormApp.Models;
using FormApp.Services;
using System;

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
                var permissionIdSession = _dataService.GetSelectedPermissionId();

                if (permissionIdRoute == 0 || permissionIdSession == 0 || permissionIdSession != permissionIdRoute)
                    Server.Transfer($"~/{nameof(NoFoundPage)}.aspx");
                else
                {
                    var permissionTypes = _dataService.GetPermissionTypes();

                    foreach (var item in permissionTypes)
                    {
                        ddlPermissionType.Items.Add(item.Description);
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
            var permissionId = _dataService.GetSelectedPermissionId();

            var model = new PermissionSave
            {
                EmployeeLastname = txtEmployeeLastname.Text,
                EmployeeName = txtEmployeeName.Text,
                DateFromView = Request.Form[calPermissionDate.UniqueID],
                PermissionTypeId = ddlPermissionType.SelectedIndex,
                PermissionId = permissionId
            };

            if (_dataService.UpdatePermission(permissionId, model)) 
                Response.Redirect($"~/Features/Permissions/Details.aspx?permissionId={permissionId}");
        }
    }
}