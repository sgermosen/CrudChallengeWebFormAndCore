using FormApp.Extensions;
using FormApp.Services;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace FormApp.Features.Permissions
{
    public partial class Index : System.Web.UI.Page
    {

        private readonly IDataService _dataService;

        public Index(IDataService dataService)
        {
            _dataService = dataService;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["PermissionId"] = 0;
            FillGrid();
        }

        protected void FillGrid()
        {
            var permissions = _dataService.GetPermissions().OrderByDescending(x => x.Id).ToList();

            DataTable dt = permissions.ToDataTable();
            if (dt.Rows.Count != 0 && Convert.ToInt32(dt.Rows[0][0].ToString()) != 0)
            {
                //if (permissions != null)
                //{ 
                //DataTable dtWithJson = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Newtonsoft.Json.JsonConvert.SerializeObject(permissions)); //it have problems with navigation properties
                //var dtWithFast = new DataTable();
                //using (var reader = ObjectReader.Create(permissions))
                //{
                //    dtWithFast.Load(reader);
                //} 
                //var dtClasic = new DataTable();
                //dtClasic = permissions.ToDataTable(); 
                //gv.DataSource = dtWithJson;
                gv.DataSource = dt;
                //   gv.DataSource = dtClasic;
                //  gv.DataSource = dtWithFast; //The items are sorted in a undetermined way
                gv.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gv.DataSource = dt;
                gv.DataBind();
                int columncount = gv.Rows[0].Cells.Count;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No data found";
            }

        }
        static int selectedId;

        protected void gv_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[6].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('are you sure to delete the item: " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            selectedId = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Text.ToString());
            var permissions = _dataService.GetPermissions();
            var permissionDb = permissions.Find(x => x.Id == selectedId);
            permissions.Remove(permissionDb);
            Session["Permissions"] = permissions;
            FillGrid();
        }


        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedId = Convert.ToInt32(gv.SelectedRow.Cells[0].Text.ToString());
            GoToDetails();
        }

        private void GoToDetails()
        {
            Response.Redirect($"~/Features/Permissions/Details.aspx?permissionId={selectedId}");
        }





    }
}