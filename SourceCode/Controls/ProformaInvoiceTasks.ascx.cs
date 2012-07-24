﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_HomePageTasksSales : System.Web.UI.UserControl
{
    Common cs = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            try
            {
                Response.Redirect("../SessionExpired.aspx", false);
            }
            catch { }
        }
        gvProformaInvoice.DataBind();
        gvPI.DataSource = getGenericPI();
        gvPI.DataBind();    

    }

    protected DataTable getGenericPI()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("TotalNo");
        dt.Columns.Add("Amount");
        try
        {
            DataRow rowlastday = dt.NewRow();
            string sql = "select COUNT(PerformaInvoiceID) from Sal_Glb_PerformaInvoiceHeader_Tran where PIDate <'" + DateTime.Now.Date + "' and PIDate>'" + (DateTime.Now.Date.AddDays(-1)) + "'";
            DataTable dtlastday = cs.executeSqlQry(sql);
            if (dtlastday.Rows.Count > 0)
            {
                rowlastday["TotalNo"] = dtlastday.Rows[0][0].ToString();
            }

            rowlastday["Amount"] = "NA";
            dt.Rows.Add(rowlastday);


            DataRow rowlastweek = dt.NewRow();
            sql = "select COUNT(PerformaInvoiceID) from Sal_Glb_PerformaInvoiceHeader_Tran where PIDate <'" + DateTime.Now.Date + "' and PIDate>'" + (DateTime.Now.Date.AddDays(-7)) + "'";
            DataTable dtlastweek = cs.executeSqlQry(sql);
            if (dtlastweek.Rows.Count > 0)
            {
                rowlastweek["TotalNo"] = dtlastweek.Rows[0][0].ToString();
            }

            rowlastweek["Amount"] = "NA";
            dt.Rows.Add(rowlastweek);


            DataRow rowlastmtd = dt.NewRow();
            sql = "select COUNT(PerformaInvoiceID) from Sal_Glb_PerformaInvoiceHeader_Tran where PIDate <'" + DateTime.Now.Date + "' and PIDate>'" + (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)) + "'";
            DataTable dtlastmtd = cs.executeSqlQry(sql);
            if (dtlastmtd.Rows.Count > 0)
            {
                rowlastmtd["TotalNo"] = dtlastmtd.Rows[0][0].ToString();
            }

            rowlastmtd["Amount"] = "NA";
            dt.Rows.Add(rowlastmtd);

            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    

    
   
}