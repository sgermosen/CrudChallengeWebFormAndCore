using FormApp.Models;
using FormApp.Services;
using System;

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
                var permissionTypes = _dataService.GetPermissionTypes();
                if (permissionTypes.IsSuccess)
                {
                    foreach (var item in permissionTypes.Value)
                    {
                        ddlPermissionType.Items.Add(item.Description);
                    }
                }
                else
                {
                    //TODO: Handler Error
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
            var model = new PermissionSave
            {
                EmployeeLastname = txtEmployeeLastname.Text,
                EmployeeName = txtEmployeeName.Text,
                DateFromView = Request.Form[calPermissionDate.UniqueID],
                PermissionTypeId = ddlPermissionType.SelectedIndex
            };
            var request = _dataService.CreatePermission(model);
            if (request.IsSuccess)
                Server.Transfer($"~/Features/Permissions/{nameof(Index)}.aspx");
            else
            {
                //TODO: Handler Error
            }


        }
    }
}