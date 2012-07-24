using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_CostCentermaster
/// </summary>
public class FA_CostCentermaster
{
    #region private variable
    private int _costcentercode;
    private string _costcentername;
    private int _id;
    #endregion

    #region public properties
    
    public int CostCenterCode
    {
        get { return _costcentercode; }
        set { _costcentercode = value; }
    }
    public string CostCenterName
    {
        get { return _costcentername; }
        set { _costcentername = value; }
    }
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    #endregion

    public BLLCollection<FA_CostCentermaster> GetCostCenter()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetCostCenter();
    } 


    public FA_CostCentermaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}