using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for FA_GLMaster
/// </summary>
public class FA_GLMaster
{
    #region Private variable
    int _autoid;
    int _generalledgercode;
    string _groupcode;
    string _description;
    string _defaultprofitcenter;
    bool _subglflag;
    string _bsmaingroup;
    string _doagroupcode;
    bool _employeecode;
    bool _active;
    #endregion

    #region public Properties
    public int AutoId
    {
        get { return _autoid; }
        set { _autoid = value; }
    }
    public int GeneralLedgerCode
    {
        get { return _generalledgercode; }
        set { _generalledgercode = value; }
    }
    public string GroupCode
    {
        get{return _groupcode;}
        set { _groupcode = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string DefaultProfitCenter
    {
        get { return _defaultprofitcenter; }
        set { _defaultprofitcenter = value; }
    }
    public bool Subglflag
    {
        get { return _subglflag; }
        set { _subglflag = value; }
    }
    public string DOAGroupCode
    {
        get { return _doagroupcode; }
        set { _doagroupcode = value; }
    }
    public bool EmployeeCode
    {
        get { return _employeecode; }
        set { _employeecode = value; }
    }
    public bool Active
    {
        get { return _active; }
        set { _active = value; }
    }
    #endregion

    public BLLCollection<FA_GLMaster> GetGLCodeList()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetGLCodeList();
    }
    //public BLLCollection<FA_GLMaster> GetGLCode_By_GLGroupName(string groupname)
    //{
    //    SqlDataProvider sda = new SqlDataProvider();
    //    return sda.GetGLCodeList_ByGLGroupName(groupname);
    //}
    public FA_GLMaster GetGLCode_ById(int Glcode)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetGLCode_ById(Glcode);
    }



    public FA_GLMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetGLCode_By_GLGroupName(string glgroupname)
    {
        SqlCommand objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_FA_GetGLByGLGroupName";
        objSqlCommand.Parameters.AddWithValue("@glgroupname", glgroupname);
        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }
    public DataTable GetGLCode_By_GLGroupName_ByGlcode(string glgroupname,string glcode)
    {
        SqlCommand objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_FA_GetGLByGLGroupName_Glcode";
        objSqlCommand.Parameters.AddWithValue("@glgroupname", glgroupname);
        objSqlCommand.Parameters.AddWithValue("@glcode", glcode);
        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }
    
}