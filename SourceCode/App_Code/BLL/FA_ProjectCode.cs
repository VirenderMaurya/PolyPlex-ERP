using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_ProjectCode
/// </summary>
public class FA_ProjectCode
{
    #region private variables
    private int _projectcode;
    private string _projectname;
    #endregion

    #region Public Properties
    public int ProjectCode
    {
        get { return _projectcode; }
        set { _projectcode = value; }
    }
    public string ProjectName
    {
        get { return _projectname; }
        set { _projectname = value; }
    }
    #endregion

    public BLLCollection<FA_ProjectCode> GetProjectCode()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetProjectCode();
    }


    public FA_ProjectCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}