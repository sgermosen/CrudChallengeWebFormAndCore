using FormApp.Services;
using System;

namespace FormApp.Features.Permissions
{
    public partial class Details : System.Web.UI.Page
    {
        private readonly IDataService _dataService;

        public Details(IDataService dataService)
        {
            _dataService = dataService;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var permissionId = Convert.ToInt32(Request.QueryString["permissionId"]);
            Session["PermissionId"] = permissionId;
            if (permissionId == 0)
                Server.Transfer($"~/{nameof(NoFoundPage)}.aspx");
            else
            {
                var request = _dataService.GetPermission(permissionId);
                if (request.IsSuccess)
                {
                    var permission = request.Value;
                    if (permission.Id != 0)
                    {
                        lblId.Text = permission.Id.ToString();
                        lblEmployeeName.Text = permission.EmployeeName;
                        lblEmployeeLastname.Text = permission.EmployeeLastname;
                        lblPermissionDescription.Text = permission.PermissionDescription;
                        lblPermissionDate.Text = permission.PermissionDate.ToString("dd/MM/yyyy");
                    }
                }
                else
                {
                    //TODO: Handler Error
                }

            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["PermissionId"] = 0;
            Server.Transfer($"~/Features/Permissions/{nameof(Index)}.aspx");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var permissionId = Convert.ToInt32(Request.QueryString["permissionId"]);
            Session["PermissionId"] = permissionId;
            Response.Redirect($"~/Features/Permissions/EditForm.aspx?permissionId={permissionId}");
        }

    }
}