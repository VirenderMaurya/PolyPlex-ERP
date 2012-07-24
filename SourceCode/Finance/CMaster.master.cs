using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMaster : System.Web.UI.MasterPage
{
    public bool IsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                form2.DefaultButton = btn_search.ClientID;
            }
            if (Session["UserID"] == null)
            {
                try
                {
                    Response.Redirect("../SessionExpired.aspx", false);
                }
                catch { }
            }
            if (IsAdd == false)
            {
                btn_save.Visible = false;
                btn_cancel.Visible = false;
                btn_nxt.Visible = true;
                btn_pre.Visible = true;
                btn_update.Visible = false;
            }            
        }
    }
    protected void btn_Add_Click(object sender, EventArgs e)
    {
        btn_nxt.Visible = false;
        btn_pre.Visible = false;
        btn_save.Visible = true;
        btn_cancel.Visible = true;
        btn_update.Visible = false;
        IsAdd = true;
    }
    protected void btn_pre_Click(object sender, EventArgs e)
    {
        

    }
    protected void btn_nxt_Click(object sender, EventArgs e)
    {
       
    }


    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        btn_cancel.Visible = false;
        btn_save.Visible = false;
        btn_nxt.Visible = true;
        btn_pre.Visible = true;
        btn_Add.Visible = true;
        btn_update.Visible = false;
        IsAdd = false;
    }






    protected void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        btn_nxt.Visible = false;
        btn_pre.Visible = false;
        btn_save.Visible = false;
        btn_cancel.Visible = true;
        btn_Add.Visible = false;
        btn_update.Visible = true;

    }
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        btn_nxt.Visible = true;
        btn_pre.Visible = true;
        btn_save.Visible = false;
        btn_cancel.Visible = false;
        btn_Add.Visible = true;
        btn_update.Visible = false;

    }
    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {
        btn_nxt.Visible = true;
        btn_pre.Visible = true;
        btn_save.Visible = false;
        btn_cancel.Visible = false;
        btn_Add.Visible = true;

    }
}
