using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Calendar : System.Web.UI.Page
{
    public string controlToEdit;
    public string isPostBack;

    public Calendar()
    {
        LoadComplete += new EventHandler(Page_LoadComplete);
    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            controlToEdit = Request.QueryString["controlID"];
            Session.Add("controlToEdit", controlToEdit);
            isPostBack = Request.QueryString["isPostBack"];
            Session.Add("isPostBack", isPostBack);

            // Cast first day of the week from web.config file.  Set it to the calendar
            //Cal.FirstDayOfWeek = (System.Web.UI.WebControls.FirstDayOfWeek)Convert.ToInt32(ConfigurationManager.AppSettings["FirstDayOfWeek"]);

            // Select the Correct date for Calendar from query string
            // If fails, pick the current date on Calendar
            try
            {
                Cal.SelectedDate = Cal.VisibleDate = Convert.ToDateTime(lblDate.Text);
            }
            catch
            {
                Cal.SelectedDate = Cal.VisibleDate = DateTime.Today;
            }
            // Fills in correct values for the dropdown menus
            FillCalendarChoices();
            SelectCorrectValues();
        }
        else
        {
            if (Session["controlToEdit"] != null)
                controlToEdit = (string)Session["controlToEdit"];
            if (Session["isPostBack"] != null)
                isPostBack = (string)Session["isPostBack"];
        }
    }
    void Page_LoadComplete(object sender, System.EventArgs e)
    {
        OKButton.OnClientClick = "javascript:window.opener.SetControlValue('" + this.controlToEdit + "','" + lblDate.Text + "','" + this.isPostBack + "');";
    }

    protected void FillCalendarChoices()
    {
        DateTime thisdate = (DateTime.Now).AddYears(5);

        // Fills in month values
        for (int x = 0; x < 12; x++)
        {
            // Loops through 12 months of the year and fills in each month value
            ListItem li = new ListItem(thisdate.ToString("MMMM"), thisdate.Month.ToString());
            MonthSelect.Items.Add(li);
            //to add next next month name to the monthselect drop downlist control like aug then sept and so on....
            thisdate = thisdate.AddMonths(1);
        }

        // Fills in year values and change y value to other years if necessary
        for (int y = 2000; y <= thisdate.Year; y++)
        {
            YearSelect.Items.Add(y.ToString());
        }
    }

    protected void SelectCorrectValues()
    {
        lblDate.Text = Cal.SelectedDate.ToShortDateString();

        datechosen.Value = lblDate.Text;

        MonthSelect.SelectedIndex = MonthSelect.Items.IndexOf(MonthSelect.Items.FindByValue(Cal.SelectedDate.Month.ToString()));

        YearSelect.SelectedIndex = YearSelect.Items.IndexOf(YearSelect.Items.FindByValue(Cal.SelectedDate.Year.ToString()));

    }

    protected void Cal_SelectionChanged(object sender, System.EventArgs e)
    {
        Cal.VisibleDate = Cal.SelectedDate;
        SelectCorrectValues();
    }

    protected void MonthSelect_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Cal.SelectedDate = Cal.VisibleDate
            = new DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value),
                           Convert.ToInt32(MonthSelect.SelectedItem.Value), 1); ;
        SelectCorrectValues();
    }

    protected void YearSelect_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Cal.SelectedDate = Cal.VisibleDate
            = new DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value),
                           Convert.ToInt32(MonthSelect.SelectedItem.Value), 1); ;
        SelectCorrectValues();
    }
}
