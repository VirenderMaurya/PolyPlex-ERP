﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PolyplexMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Session["UserID"] == null)
        {
            try
            {
                Response.Redirect("../Default.aspx", false);
            }
            catch { }
        }
    }
}
