using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;

/// <summary>
/// Summary description for DynControl
/// </summary>
public class DynControl
{
    Panel oPanel;
    static DataTable dtmain = new DataTable();
    Common cs = new Common();
    int itop = 80;
    int ileft = 400;
    int iHorizontalSpace = 30;
    int iVerticalSpace = 30;

    public DynControl()
    {

    }

    public void SetDBParameter(string Table, int row)
    {
        string sql = "Select * from " + Table;
        //DataSet ds = new DataSet();
        DataTable dt = cs.executeSqlQry(sql);
        //.ReadXml(HttpContext.Current.Server.MapPath("XMLFile1.xml"));
        dtmain = dt;
        //dtSQL = ds.Tables[0];
        //GetDBColumn();
        //GetRecordCount();
        //HttpContext.Current.Cache["dtSQL"] = dtSQL;
        //HttpContext.Current.Cache["objColumn"] = objColumnName;
    }
    public void CreateForm(ref Panel objPanel, int iFlag)
    {
        oPanel = null;
        oPanel = objPanel;
        DisplayRecord(iFlag);

    }

    public DataTable getMainTable()
    {
        return dtmain;
    }

    public void DisplayRecord(int iFlag)
    {


        foreach (DataColumn col in dtmain.Columns)
        {
            oPanel.Controls.Add(AddLabel("lbl_" + col.ColumnName, col.ColumnName, itop.ToString() + "px", ileft.ToString() + "px"));
            oPanel.Controls.Add(AddTextBox("txt_" + dtmain.Rows[iFlag][col.ColumnName].ToString(), dtmain.Rows[iFlag][col.ColumnName].ToString(), itop.ToString() + "px", (iHorizontalSpace + ileft).ToString() + "px"));
            itop = itop + iVerticalSpace;
        }

    }



    public Label AddLabel(string id, string name, string sTop, string sLeft)
    {
        Label l = new Label();
        l.Text = name;
        l.ID = id;
        l.Style["POSITION"] = "";
        l.Style["LEFT"] = sLeft;
        l.Style["TOP"] = sTop;
        return l;
    }
    public TextBox AddTextBox(string id, string name, string sTop, string sLeft)
    {
        TextBox t = new TextBox();
        t.Text = name;
        t.ID = id;
        t.Style["POSITION"] = "";
        t.Style["LEFT"] = sLeft;
        t.Style["TOP"] = sTop;
        return t;

    }

    public void CreateEmptyForm(ref Panel objPanel)
    {
        oPanel = null;
        oPanel = objPanel;
        DisplayEmptyForm();

    }

    public void DisplayEmptyForm()
    {

        foreach (DataColumn col in dtmain.Columns)
        {
            oPanel.Controls.Add(AddLabel("lbl_" + col.ColumnName, col.ColumnName, itop.ToString() + "px", ileft.ToString() + "px"));
            oPanel.Controls.Add(AddTextBox("txt_" + dtmain.Rows[0][col.ColumnName].ToString(), "", itop.ToString() + "px", (iHorizontalSpace + ileft).ToString() + "px"));
            itop = itop + iVerticalSpace;
        }

    }

    public void SaveRecord(string TableName)
    {
        try
        {
            string sql = "Insert into " + TableName + "(";
            foreach (DataColumn col in dtmain.Columns)

                sql += col.ColumnName + ",";


            if (sql.EndsWith(","))

                sql = sql.Substring(0, sql.Length - 1);
            sql += ") values ('";

            foreach (DataColumn col in dtmain.Columns)
            {
            }

        }
        catch (Exception ex)
        {
        }
    }

    public void CreateMenu(ref Panel objPanel, string submenu, string header)
    {
        try
        {
            oPanel = null;
            oPanel = objPanel;
            oPanel.Controls.Add(AddMenuLink("lnk_" + header + "_" + submenu, submenu, itop.ToString() + "px", ileft.ToString() + "px"));
            oPanel.Controls.Add(new LiteralControl("<br />"));
            oPanel.Controls.Add(new LiteralControl("<br />"));
            itop = itop + iVerticalSpace;
        }
        catch (Exception ex)
        {
        }
    }

    public void CreatesubMenu(ref Panel objPanel, string url, string submenu, string link)
    {
        try
        {



            oPanel = null;
            oPanel = objPanel;
            oPanel.Controls.Add(AddHyperLink(url, submenu, link, itop.ToString() + "px", ileft.ToString() + "px"));
            oPanel.Controls.Add(new LiteralControl("<br />"));
            oPanel.Controls.Add(new LiteralControl("<br />"));
            itop = itop + iVerticalSpace;


        }
        catch (Exception ex)
        {
        }
    }


    public LinkButton AddLinkButton(string id, string name, string sTop, string sLeft)
    {
        LinkButton l = new LinkButton();
        l.Text = name;
        l.ID = id;
        l.Style["text-decoration"] = "None";
        //l.OnClientClick = "highlight();";
       

        l.ForeColor = System.Drawing.ColorTranslator.FromHtml("#222D5A");
        
        return l;



    }

    public HyperLink AddHyperLink(string url, string submenu, string link, string sTop, string sLeft)
    {
        HyperLink h = new HyperLink();
        h.Text = link;
        h.ID = "lnk_" + submenu + "_" + link;
        h.Style["text-decoration"] = "None";
        h.ForeColor = System.Drawing.Color.Black;
        if (url == "")
        {
            h.NavigateUrl = "#";
        }
        else
        {
            if (link=="Invoice" || link == "Sales Order" || link == "Proforma Invoice")
            {
                h.NavigateUrl = "JavaScript:newPopuplarge('" + url + "');";

            }
            else
            {
                h.NavigateUrl = "JavaScript:newPopup('" + url + "');";
            }
        }
        return h;




    }

    public HyperLink AddMenuLink(string Id, string name, string sTop, string sLeft)
    {
        HyperLink h = new HyperLink();
        h.Text = name;
        h.ID = Id;
        h.Style["text-decoration"] = "None";
        h.ForeColor = System.Drawing.ColorTranslator.FromHtml("#222D5A");
        h.Attributes.Add("OnClick", "JavaScript:highlight('"+name+"');");
        h.Style["cursor"] = "pointer";
        return h;
    }












}