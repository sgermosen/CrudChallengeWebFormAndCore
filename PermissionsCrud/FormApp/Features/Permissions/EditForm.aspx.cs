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
                var request = _dataService.GetSelectedPermissionId();
                if (request.IsSuccess)
                {
                    var permissionIdSession = request.Value;

                    if (permissionIdRoute == 0 || permissionIdSession == 0 || permissionIdSession != permissionIdRoute)
                        Server.Transfer($"~/{nameof(NoFoundPage)}.aspx");
                    else
                    { 
                        var requestTypes = _dataService.GetPermissionTypes();
                        if (requestTypes.IsSuccess)
                        {
                            var permissionTypes = requestTypes.Value;

                            foreach (var item in permissionTypes)
                            {
                                ddlPermissionType.Items.Add(item.Description);
                            }
                            var requestPermission = _dataService.GetPermission(permissionIdSession);
                            if (requestPermission.IsSuccess)
                            {
                                var permission = requestPermission.Value;
                                if (permission.Id != 0)
                                {
                                    txtEmployeeName.Text = permission.EmployeeName;
                                    txtEmployeeLastname.Text = permission.EmployeeLastname;

                                    calPermissionDate.Text = permission.PermissionDate.ToString("dd/MM/yyyy");
                                    ddlPermissionType.SelectedIndex = (permission.PermissionTypeId - 1);
                                }
                                else
                                {
                                    //TODO: Handle error
                                }
                            }
                            else
                            {
                                //TODO: Handle error
                            }
                        }
                        else
                        {
                            //TODO: Handle error
                        } 
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
            var permissionId =  Convert.ToInt32(Request.QueryString["permissionId"]);

            var model = new PermissionSave
            {
                EmployeeLastname = txtEmployeeLastname.Text,
                EmployeeName = txtEmployeeName.Text,
                DateFromView = Request.Form[calPermissionDate.UniqueID],
                PermissionTypeId = ddlPermissionType.SelectedIndex,
                PermissionId = permissionId
            };
            var request = _dataService.UpdatePermission(permissionId, model);
            if (request.IsSuccess)
                Response.Redirect($"~/Features/Permissions/Details.aspx?permissionId={permissionId}");
            else
            {
                //TODO: Handler Error
            }
        }
    }
}