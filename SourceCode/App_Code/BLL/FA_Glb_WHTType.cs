using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_Glb_WHTType
/// </summary>
public class FA_Glb_WHTType
{

    #region private
    private string _id;
    private string _whttype;
    #endregion

    #region public properties
    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string WhtType
    {
        get { return _whttype; }
        set { _whttype = value; }
    }
    #endregion
    public FA_Glb_WHTType()
	{
	}
    public BLLCollection<FA_Glb_WHTType> GetAllWhtType()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetAllWHTType();
    }

}