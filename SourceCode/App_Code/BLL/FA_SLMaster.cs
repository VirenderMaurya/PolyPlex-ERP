using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_SLMaster
/// </summary>
public class FA_SLMaster
{

    #region Private variable
    int _autoid;
    string _generalledgercode;
    int _subsidiaryledgercode;
    string _sldescription;
    string _defaultprofitcenter;
    bool _active;
    #endregion

    #region public Properties

    public int AutoId
    {
        get { return _autoid; }
        set { _autoid = value; }
    }
    public string GeneralLedgerCode
    {
        get { return _generalledgercode; }
        set { _generalledgercode = value; }
    }
    public int SubSidiaryLedgerCode
    {
        get { return _subsidiaryledgercode; }
        set { _subsidiaryledgercode = value; }
    }
    public string Description
    {
        get { return _sldescription; }
        set { _sldescription = value; }
    }
    public string DefaultProfitCenter
    {
        get { return _defaultprofitcenter; }
        set { _defaultprofitcenter = value; }
    }
    public bool Active
    {
        get { return _active; }
        set { _active = value; }
    }
    #endregion

    public BLLCollection<FA_SLMaster> GetSLCodeList()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetSLCodeList();
    }

    public FA_SLMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public BLLCollection<FA_SLMaster> GetSL_ByGLCode(string glcode)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetSLA_ByGLCode(glcode);
    }

}