using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for Log
/// </summary>
public class Log : System.Web.UI.Page
{
    static Log obj = null;
    Common_mst objCommon_mst = new Common_mst();
    // Thats why its importatnt to use Construcotr as Private
    private Log()
    {

    }
    static public Log GetLog()
    {
        if (obj == null)
        {
            obj = new Log();
        }
        return obj;
    }
    public void LogInformation(string log)
    {
       EventLog.WriteEntry("PolyplexERP-Finance", log);
    }
    public void LogError(string log)
    {
       EventLog.WriteEntry("PolyplexERP-Finance", log, EventLogEntryType.Error);
    }


    #region DateFormat
    private string _DateFormat = "MM/dd/yyyy";
    private IFormatProvider _FormatProvider = new System.Globalization.CultureInfo("en-US", true);
    public IFormatProvider FormatProvider
    {
        get { return _FormatProvider; }
    }

    public string DateFormat
    {
        get { return _DateFormat; }
    }
    #endregion


    #region Fill Financial Year
    public void FillFinancialYear(TextBox txtPiYear)
    {
        try
        {
            DataTable dt = new DataTable();
            string OrganizationId = ConfigurationManager.AppSettings["OrganizationId"].ToString();
            dt = objCommon_mst.Get_FinancialYear(OrganizationId);
            if(dt.Rows.Count>0)
            {
                if (Convert.ToInt32(dt.Rows[0]["FinancialStartMonth"].ToString()) > 1)
                {
                    string EndFinancialYear = dt.Rows[0]["FinancialEndYear"].ToString().Substring(2);
                    txtPiYear.Text = (dt.Rows[0]["FinancialStartYear"].ToString() + "-" + EndFinancialYear);                   
                }
                else
                {
                    txtPiYear.Text = dt.Rows[0]["FinancialStartYear"].ToString();                    
                }
            }            
        }
        catch (Exception ex) { }
    }
    #endregion

    #region  Fill Page Header
    public static void PageHeading(System.Web.UI.Page p,string headingtext)
    {
      Label lbl_PageHeader = (Label)p.Master.FindControl("lbl_PageHeader");
      lbl_PageHeader.Text = headingtext;
    }
    #endregion

  
}