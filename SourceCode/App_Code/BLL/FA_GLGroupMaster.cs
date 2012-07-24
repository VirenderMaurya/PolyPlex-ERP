using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_GLGroupMaster
/// </summary>
public class FA_GLGroupMaster
{
    #region private variables
    private int _glgroupcode;
    private string _glgroupname;
    #endregion

    #region Public Properties
    public int GLGroupCode
    {
        get { return _glgroupcode; }
        set { _glgroupcode = value; }
    }
    public string GLGroupName
    {
        get { return _glgroupname; }
        set { _glgroupname = value; }
    }
    #endregion

    public FA_GLGroupMaster GetGLGroupName_ById(int GlGroupid)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetGLGroupName_ById(GlGroupid);
    }
    public FA_GLGroupMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}