using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public class PageConrols
{
    public PageConrols() { }
    public string sName = "";
    public string id = "";
    public string sTypeOfControl = "";
    public TextBox objTextBox;
    public DropDownList objDropDown;
    public CheckBox objCheckbx;

}

public class MasterFormControl
{
    SqlCommand objSqlCommand = new SqlCommand();
    public static DataTable dtmain;
    Common cs = new Common();
    List<PageConrols> lstPageControls = new List<PageConrols>();
    public int iTop, iLeft, iHorizontalSpace, iVerticalSpace;
    public MasterFormControl()
    {

    }

    #region Set values to dtmain
    public void SetDBParameter(string Table)
    {
        string sql = "Select * from " + Table;
        DataTable dt = cs.executeSqlQry(sql);
        dtmain = dt;

    }

    public void SetDBParameter_GetByParameter(string Table, string criteria, string keyword)
    {
        string sql = "Select * from " + Table + " where " + criteria + " = '" + keyword + "'";
        DataTable dt = cs.executeSqlQry(sql);
        dtmain = dt;
    }
    #endregion

    public void createForm(Panel objPanel, string xml, int tableID, string tablePrimaryKey)
    {
        try
        {
            objPanel.Controls.Clear();
            DataSet ds = new DataSet();
            ds.ReadXml(HttpContext.Current.Server.MapPath("xml/" + xml));
            int fieldID;
            string displayName, TableField, ileft, itop, width, boxtype;
            string BoxValue;
            string validationflag;
            for (int i = 0; i < ds.Tables["Field"].Rows.Count; i++)
            {
                validationflag = "";
                fieldID = int.Parse(ds.Tables["Field"].Rows[i]["Field_ID"].ToString());
                DataRow[] rowValues = ds.Tables["Values"].Select("Field_Id=" + fieldID);
                displayName = rowValues[0]["Name"].ToString();
                TableField = rowValues[0]["TableField"].ToString();
                validationflag = rowValues[0]["validationflag"].ToString();
                DataRow[] rowDesign = ds.Tables["design"].Select("Field_Id=" + fieldID);
                ileft = rowDesign[0]["left"].ToString();
                itop = rowDesign[0]["top"].ToString();
                width = rowDesign[0]["width"].ToString();
                if (dtmain.Rows.Count > 0)  //changed by lalit
                {
                    string expression = tablePrimaryKey + "=" + tableID.ToString();
                    DataRow[] selRow = dtmain.Select(expression);
                    BoxValue = selRow[0][TableField].ToString();
                    //BoxValue = dtmain.Rows[0][tablePrimaryKey].ToString();
                }
                else
                {
                    BoxValue = "";
                }

                boxtype = rowDesign[0]["type"].ToString();
                string star = "No";

                //* Apply star mark to Required Field *//
                if (validationflag == "Yes")
                {
                    DataRow[] Validationstar = ds.Tables["Validation"].Select("Field_Id=" + fieldID);
                    string requiredstar = Validationstar[0]["required"].ToString();
                    if (requiredstar == "Yes")
                    {
                        star = "Yes";
                    }

                }

                //* Create Controls *//

                if (boxtype == "DropDown")
                {
                    DataRow[] rowOptions = ds.Tables["options"].Select("Field_Id=" + fieldID);
                    createDD(objPanel, displayName, TableField, itop, ileft, width, rowOptions, BoxValue, star);

                }
                if (boxtype == "DropDownAuto")  //added by lalit when dropdown Auto binded
                {
                    //get data form datasource
                    DataRow[] rowOptions = ds.Tables["options"].Select("Field_Id=" + fieldID);
                    string tablename = rowOptions[0]["opt1"].ToString();
                    string ddvalue = rowOptions[0]["opt2"].ToString();
                    string ddtext = rowOptions[0]["opt3"].ToString();
                    DataTable dtAutovalue = cs.executeSqlQry("select " + ddvalue+","+ddtext + " from " + tablename);
                    createAutoDD(ref objPanel, displayName, TableField, itop, ileft, width, dtAutovalue, BoxValue, star);
                }
                if (boxtype == "MultiTextField")
                {
                    createMultiTxtBx(objPanel, displayName, TableField, itop, ileft, width, BoxValue, star);
                }
                if (boxtype == "TextBox")
                {
                    createSimpleTxtBx(objPanel, displayName, TableField, itop, ileft, width, BoxValue, star);
                }
                if (boxtype == "CheckBox")
                {
                    createCheckBx(objPanel, displayName, TableField, itop, ileft, width, BoxValue, star);
                }

                if (boxtype == "DateField")
                {
                    createDateBx(objPanel, displayName, TableField, itop, ileft, width, BoxValue, star);
                }

                //* Apply Validation *//
                if (validationflag == "Yes")
                {
                    DataRow[] drValidation = ds.Tables["Validation"].Select("Field_Id=" + fieldID);
                    string requiredField = drValidation[0]["required"].ToString();
                    if (requiredField == "Yes")
                    {
                        addValidation(objPanel, TableField);


                    }
                    string emailField = drValidation[0]["email"].ToString();
                    if (emailField == "Yes")
                    {
                        addEmailValidation(objPanel, TableField);
                    }

                    string numberField = drValidation[0]["number"].ToString();
                    if (numberField == "Yes")
                    {
                        addNumberValidation(objPanel, TableField);
                    }

                }

            }
        }
        catch (Exception ex) { }


    }

    public int getPositionID(int iFlag, string tablePrimaryKey)
    {
        try
        {
            int cid = int.Parse(dtmain.Rows[iFlag][tablePrimaryKey].ToString());
            return cid;
        }
        catch (Exception ex) { return 0; }
    }

    public ListItem[] fillSearchDropDown(string ModuleFormID)
    {
        string sql = "Select options,Value from View_SearchCriteria where ModuleFormID='" + ModuleFormID + "'";
        DataTable dt = cs.executeSqlQry(sql);
        ListItem[] items = new ListItem[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            items[i] = new ListItem(dt.Rows[i]["options"].ToString(), dt.Rows[i]["Value"].ToString());
        }

        return items;
    }

    public void addEmailValidation(Panel objPanel, string textbxID)
    {
        RegularExpressionValidator myValidator = new RegularExpressionValidator();
        myValidator.ControlToValidate = textbxID;
        myValidator.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        myValidator.Display = ValidatorDisplay.None;
        myValidator.ID = "rev_" + textbxID;
        myValidator.ErrorMessage = "Incorrect Email Id.";
        //myValidator.ValidationGroup = "aa";
        AjaxControlToolkit.ValidatorCalloutExtender vce = new AjaxControlToolkit.ValidatorCalloutExtender();
        vce.Enabled = true;
        vce.ID = "vce_" + myValidator.ID;
        vce.TargetControlID = myValidator.ID;

        vce.CssClass = "customCalloutStyle";

        objPanel.Controls.Add(myValidator);
        objPanel.Controls.Add(vce);

    }

    public void addNumberValidation(Panel objPanel, string textbxID)
    {
        RegularExpressionValidator myValidator = new RegularExpressionValidator();
        myValidator.ControlToValidate = textbxID;
        myValidator.ValidationExpression = @"\d+";
        myValidator.Display = ValidatorDisplay.None;
        myValidator.ID = "rev_n_" + textbxID;
        myValidator.ErrorMessage = "Only digits(0-9) are allowed.";
        //myValidator.ValidationGroup = "aa";
        AjaxControlToolkit.ValidatorCalloutExtender vce = new AjaxControlToolkit.ValidatorCalloutExtender();
        vce.Enabled = true;
        vce.ID = "vce_" + myValidator.ID;
        vce.TargetControlID = myValidator.ID;

        vce.CssClass = "customCalloutStyle";
        objPanel.Controls.Add(myValidator);
        objPanel.Controls.Add(vce);

    }

    public void addValidation(Panel objPanel, string textbxID)
    {
        RequiredFieldValidator myValidator = new RequiredFieldValidator();
        myValidator.ControlToValidate = textbxID;
        myValidator.Display = ValidatorDisplay.None;
        myValidator.ID = "rfv_" + textbxID;
        myValidator.ErrorMessage = "Mandatory Field.";
        myValidator.ValidationGroup = "aa";
        AjaxControlToolkit.ValidatorCalloutExtender vce = new AjaxControlToolkit.ValidatorCalloutExtender();
        vce.Enabled = true;
        vce.ID = "vce_" + myValidator.ID;
        vce.TargetControlID = myValidator.ID;

        vce.CssClass = "customCalloutStyle";
        objPanel.Controls.Add(myValidator);
        objPanel.Controls.Add(vce);

    }

    public string getXMLFieldsforSearch(string xml)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("xml/" + xml));
        int fieldID;
        string returnValue = "";
        for (int i = 0; i < ds.Tables["Field"].Rows.Count; i++)
        {
            fieldID = int.Parse(ds.Tables["Field"].Rows[i]["Field_ID"].ToString());
            DataRow[] rowValues = ds.Tables["Values"].Select("Field_Id=" + fieldID);
            returnValue = returnValue + rowValues[0]["TableField"].ToString();
            returnValue = returnValue + ",";
        }
        if (returnValue.EndsWith(","))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;

    }

    public DataTable searchResults(string xml, string table, string searchCriteria, string keywords, string tableid)
    {
        string sql = "select " + tableid + " , " + getXMLFieldsforSearch(xml) + " from " + table + " where " + searchCriteria + " like '%" + keywords + "%'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public void createDD(Panel objPanel, string labelValue, string ddid, string top, string left, string iwidth, DataRow[] options, string bxval, string star)
    {

        objPanel.Controls.Add(AddLabel("lbl_" + ddid, labelValue, top + "px", left + "px", star));
        left = (int.Parse(left) + 160).ToString();
        objPanel.Controls.Add(AddDropDownList(ddid, top + "px", left + "px", iwidth, options, bxval));


    }

    public void createAutoDD(ref Panel objPanel, string labelValue, string ddid, string top, string left, string iwidth, DataTable options, string bxval, string star)
    {
        objPanel.Controls.Add(AddLabel("lbl_" + ddid, labelValue, top + "px", left + "px", star));
        left = (int.Parse(left) + 160).ToString();
        objPanel.Controls.Add(AddAutoBindDropDownList(ddid, top + "px", left + "px", iwidth, options, bxval));
    }
    public void createMultiTxtBx(Panel objPanel, string labelValue, string txtid, string top, string left, string iwidth, string value, string star)
    {

        objPanel.Controls.Add(AddLabel("lbl_" + txtid, labelValue, top + "px", left + "px", star));
        left = (int.Parse(left) + 160).ToString();
        objPanel.Controls.Add(AddMultiTextBox(txtid, value, top + "px", left + "px", iwidth));
    }

    public void createSimpleTxtBx(Panel objPanel, string labelValue, string txtid, string top, string left, string iwidth, string value, string star)
    {
        objPanel.Controls.Add(AddLabel("lbl_" + txtid, labelValue, top + "px", left + "px", star));
        left = (int.Parse(left) + 160).ToString();
        objPanel.Controls.Add(AddTextBox(txtid, value, top + "px", left + "px", iwidth));

    }
    public void createCheckBx(Panel objPanel, string labelValue, string Checkid, string top, string left, string iwidth, string value, string star)
    {
        objPanel.Controls.Add(AddLabel("lbl_" + Checkid, labelValue, top + "px", left + "px", star));
        left = (int.Parse(left) + 160).ToString();
        objPanel.Controls.Add(AddCheckBox(Checkid, value, top + "px", left + "px", iwidth));

    }

    public void createDateBx(Panel objPanel, string labelValue, string txtid, string top, string left, string iwidth, string value, string star)
    {
        objPanel.Controls.Add(AddLabel("lbl_" + txtid, labelValue, top + "px", left + "px", star));
        left = (int.Parse(left) + 160).ToString();
        objPanel.Controls.Add(AddDateBox(txtid, value, top + "px", left + "px", iwidth, objPanel));

    }

    public Label AddLabel(string id, string name, string sTop, string sLeft, string star)
    {
        Label l = new Label();
        l.Text = name;
        l.ID = id;
        l.Style["POSITION"] = "absolute";
        l.Style["LEFT"] = sLeft;
        l.Style["TOP"] = sTop;
        if (star == "Yes")
        {
            l.Text = l.Text + "<font color='Red'>&nbsp;*</font>";
        }
        return l;
    }

    public TextBox AddTextBox(string id, string display, string sTop, string sLeft, string width)
    {
        TextBox t = new TextBox();
        t.Text = display;
        t.ID = id;
        t.Width = int.Parse(width);
        t.Style["POSITION"] = "absolute";
        t.Style["LEFT"] = sLeft;
        t.Style["TOP"] = sTop;
        PageConrols obj = new PageConrols();
        obj.sName = display;
        obj.id = id;
        obj.sTypeOfControl = "TextBox";
        obj.objTextBox = t;
        lstPageControls.Add(obj);

        return t;

    }

    public TextBox AddDateBox(string id, string display, string sTop, string sLeft, string width, Panel objPanel)
    {
        TextBox t = new TextBox();
        t.Text = display;
        t.ID = id;
        t.Width = int.Parse(width);
        t.Style["POSITION"] = "absolute";
        t.Style["LEFT"] = sLeft;
        t.Style["TOP"] = sTop;
        PageConrols obj = new PageConrols();
        obj.sName = display;
        obj.id = id;
        obj.sTypeOfControl = "TextBox";
        obj.objTextBox = t;
        lstPageControls.Add(obj);
        addCalender(t.ID, objPanel);
        return t;

    }

    public void addCalender(string txtid, Panel oPanel)
    {
        AjaxControlToolkit.CalendarExtender ce = new AjaxControlToolkit.CalendarExtender();
        ce.TargetControlID = txtid;
        ce.Format = "dd/MMM/yyyy";
        oPanel.Controls.Add(ce);
    }

    public TextBox AddMultiTextBox(string id, string display, string sTop, string sLeft, string width)
    {
        TextBox t = new TextBox();
        t.Text = display;
        t.ID = id;
        t.Width = int.Parse(width);
        t.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
        t.Style["POSITION"] = "absolute";
        t.Style["LEFT"] = sLeft;
        t.Style["TOP"] = sTop;
        PageConrols obj = new PageConrols();
        obj.sName = display;
        obj.id = id;
        obj.sTypeOfControl = "MultiTextField";
        obj.objTextBox = t;
        lstPageControls.Add(obj);
        return t;

    }

    public DropDownList AddDropDownList(string id, string sTop, string sLeft, string width, DataRow[] options, string boxValue)
    {
        DropDownList ddl = new DropDownList();
        ddl.ID = id;
        ddl.Style["POSITION"] = "absolute";
        ddl.Style["LEFT"] = sLeft;
        ddl.Width = int.Parse(width);
        ddl.Style["TOP"] = sTop;
        ddl.Items.Add(new ListItem("--Select--", ""));
        if (options[0].Table.Columns.Count > 0)
        {
            for (int i = 0; i < options[0].Table.Columns.Count - 1; i++)
            {
                string item = options[0][i].ToString();
                if (item != "")
                {
                    ddl.Items.Add(item);
                }
            }


        }
        ddl.SelectedValue = boxValue;
        PageConrols obj = new PageConrols();
        obj.sName = boxValue;
        obj.id = id;
        obj.sTypeOfControl = "DropDown";
        obj.objDropDown = ddl;
        lstPageControls.Add(obj);
        return ddl;

    }

    public DropDownList AddAutoBindDropDownList(string id, string sTop, string sLeft, string width, DataTable options, string boxValue)
    {

        DropDownList ddl = new DropDownList();
        ddl.ID = id;
        ddl.Style["POSITION"] = "absolute";
        ddl.Style["LEFT"] = sLeft;
        ddl.Width = int.Parse(width);
        ddl.Style["TOP"] = sTop;
        ddl.Items.Add(new ListItem("--Select--", ""));
        if (options.Rows.Count > 0)
        {
            for (int i = 0; i < options.Rows.Count; i++)
           {
               ddl.Items.Add(new ListItem(options.Rows[i][1].ToString(),options.Rows[i][0].ToString()));
           }
        }
        ddl.SelectedValue = boxValue.Trim();
        PageConrols obj = new PageConrols();
        obj.sName = boxValue;
        obj.id = id;
        obj.sTypeOfControl = "DropDown";
        obj.objDropDown = ddl;
        lstPageControls.Add(obj);
        return ddl;
    }
    public CheckBox AddCheckBox(string id, string display, string sTop, string sLeft, string width)
    {
        CheckBox t = new CheckBox();
        if (display == "True")
            t.Checked = true;
        else
            t.Checked = false;

        t.ID = id;
        t.Style["POSITION"] = "absolute";
        t.Style["LEFT"] = sLeft;
        t.Style["TOP"] = sTop;
        PageConrols obj = new PageConrols();
        obj.sName = display;
        obj.id = id;
        obj.sTypeOfControl = "CheckBox";
        obj.objCheckbx = t;
        lstPageControls.Add(obj);

        return t;

    }
    public int[] increaseRow(int r)
    {
        int[] a = new int[2];
        int length = dtmain.Rows.Count;
        if (r < length - 1)
        {
            a[0] = r + 1;
            a[1] = 1;
            return a;
        }
        else
        {
            a[0] = r;
            a[1] = 0;
            return a;
        }
    }


    public int[] decreaseRow(int row)
    {
        int[] a = new int[2];
        if (row > 0)
        {
            a[0] = row - 1;
            a[1] = 1;
            return a;
        }
        else
        {
            a[0] = 0;
            a[1] = 0;
            return a;
        }
    }

    public void createEmptyForm()
    {
        for (int i = 0; i < lstPageControls.Count(); i++)
        {
            if (lstPageControls[i].sTypeOfControl == "TextBox" || lstPageControls[i].sTypeOfControl == "MultiTextField")
            {
                lstPageControls[i].objTextBox.Text = "";
            }

            if (lstPageControls[i].sTypeOfControl == "DropDown")
            {
                lstPageControls[i].objDropDown.SelectedValue = "";
            }

            if (lstPageControls[i].sTypeOfControl == "CheckBox")
            {
                lstPageControls[i].objCheckbx.Checked = false;
            }
        }
    }

    public bool saveRecords(string tablename)
    {
        string sTableField = "";
        string sFieldValues = "'";
        for (int i = 0; i < lstPageControls.Count(); i++)
        {
            sTableField = sTableField + lstPageControls[i].id + ",";
            if (lstPageControls[i].sTypeOfControl == "TextBox" || lstPageControls[i].sTypeOfControl == "MultiTextField")
            {
                sFieldValues = sFieldValues + lstPageControls[i].objTextBox.Text + "','";
            }

            if (lstPageControls[i].sTypeOfControl == "DropDown")
            {
                sFieldValues = sFieldValues + lstPageControls[i].objDropDown.SelectedItem.Value + "','";
            }
            if (lstPageControls[i].sTypeOfControl == "CheckBox")
            {
                sFieldValues = sFieldValues + lstPageControls[i].objCheckbx.Checked + "','";
            }
        }




        if (sTableField.EndsWith(","))
        {
            sTableField = sTableField.Substring(0, sTableField.Length - 1);
        }

        if (sFieldValues.EndsWith(",'"))
        {
            sFieldValues = sFieldValues.Substring(0, sFieldValues.Length - 2);
        }

        return cs.executeSPmastrCommon(tablename, sTableField, sFieldValues);


    }

    public bool updateRecords(string tablename, string conditions, string conditionvalue)
    {
        string sql = "";

        for (int i = 0; i < lstPageControls.Count(); i++)
        {



            if (lstPageControls[i].sTypeOfControl == "TextBox" || lstPageControls[i].sTypeOfControl == "MultiTextField")
            {
                sql = sql + lstPageControls[i].id + "='";
                sql = sql + lstPageControls[i].objTextBox.Text + "',";
            }

            if (lstPageControls[i].sTypeOfControl == "DropDown")
            {
                sql = sql + lstPageControls[i].id + "='";
                sql = sql + lstPageControls[i].objDropDown.SelectedItem.Value + "',";

            }
            if (lstPageControls[i].sTypeOfControl == "CheckBox")
            {
                sql = sql + lstPageControls[i].id + "='";
                sql = sql + lstPageControls[i].objCheckbx.Checked + "',";

            }
        }
        if (sql.EndsWith(","))
        {
            sql = sql.Substring(0, sql.Length - 1);
        }

        conditions = conditions + "=" + conditionvalue;
        return cs.updatemastrCommon(tablename, sql, conditions);

    }

    public string getUserType(string usercode)
    {
        try
        {
            string sql = "select LocationCode from View_User_Login_Location_Master where UserCode='" + usercode;
            DataTable dt = cs.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["LocationCode"].ToString();
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public string getNewKey(string primarykeyCol, string tablename)
    {
        int pri = 0;
        try
        {

            string sql = "select MAX(" + primarykeyCol + ") from " + tablename;
            DataTable dt = cs.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                pri = int.Parse(dt.Rows[0][0].ToString());
                pri = pri + 1;
            }

            else
            {
                pri = 100;
            }
        }
        catch (Exception ex)
        {
            pri = 100;
        }

        return pri.ToString();

    }

    public string[] getUserRights(string Userid, string moduleformID)
    {
        try
        {
            string[] rights = { "1", "0", "0" };
            string sql = "SELECT [Read],[Write],[Modify] FROM Com_Role_Mst where UserId='" + Userid + "' and ModuleFormID='" + moduleformID + "'";
            DataTable dt = cs.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                rights[0] = dt.Rows[0]["Read"].ToString();
                rights[1] = dt.Rows[0]["Write"].ToString();
                rights[2] = dt.Rows[0]["Modify"].ToString();
                return rights;
            }
            else
            {
                return rights;

            }
        }
        catch (Exception ex)
        {
            string[] err = { "1", "0", "0" };
            return err;
        }
    }

    public bool RecordExists(string tablename, string codeField, string txtbxValue)
    {
       
            string sql = "select * from " + tablename + " where "+codeField+"='"+txtbxValue+"'";
            DataTable dt = cs.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
     
    }

    public DataTable Get_SearchCriteria(string ModuleFormID)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_search_criteria";
        objSqlCommand.Parameters.AddWithValue("@ModuleFormID", ModuleFormID);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }  

}