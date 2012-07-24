using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


public partial class Finance_transaction_Default : System.Web.UI.Page
{
    FA_PredefinedEntries objpredef = new FA_PredefinedEntries();
    BLLCollection<FA_PredefinedEntries> colpredefined = new BLLCollection<FA_PredefinedEntries>();
   
    protected void Page_Load(object sender, EventArgs e)
    {

       if (!Page.IsPostBack)
        {
            colpredefined = objpredef.Get_PredefinedAllRecords("EntryNo", "1");
            gdvsearchlist.DataSource = colpredefined;
            gdvsearchlist.DataBind();
        }
    }
     
  
    protected void gdvsearchlist_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            foreach (GridViewRow oldrow in gdvsearchlist.Rows)
            {
                ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                oldrow.BackColor = Color.White;
            }
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            ImageButton img = (ImageButton)row.FindControl("ImageButton1");
            img.ImageUrl = "~/Images/chkbxcheck.png";
            row.BackColor = Color.LightSlateGray;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime startdate = Convert.ToDateTime(TxtStartDate.Text);
        DateTime endate = Convert.ToDateTime(TxtEndDate.Text);
        TimeSpan t = endate - startdate;
        int month = t.Days;
     
      
  

    }
    protected void gdvsearchlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvsearchlist.PageIndex = e.NewPageIndex;
        colpredefined = objpredef.Get_PredefinedAllRecords("EntryNo", "1");
        gdvsearchlist.DataSource = colpredefined;
        gdvsearchlist.DataBind();
    }
}