using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_SubProjectmst
/// </summary>
public class FA_SubProjectmst
{

    #region private variables
    private int _subprojectcode;
    private string _subprojectname;
    #endregion

    #region public properties
    public int SubProjectCode
    {
        get { return _subprojectcode; }
        set { _subprojectcode = value; }
    }
    public string SubProjectName
    {
        get { return _subprojectname; }
        set { _subprojectname = value; }
    }
    #endregion

    public BLLCollection<FA_SubProjectmst> GetSubProject()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetSubProject();
    }
    public BLLCollection<FA_SubProjectmst> GetSubProject_ByProjectId(int Projectid)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetSubProject_ByProjectId(Projectid);
    }

    public FA_SubProjectmst()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}