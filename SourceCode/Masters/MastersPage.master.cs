using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            form1.DefaultButton = btn_search.ClientID;
        }
        if (Session["UserID"] == null)
        {
            try
            {
                Response.Redirect("../SessionExpired.aspx", false);
            }
            catch { }
        }
    }
}
