using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_VoucherType
/// </summary>
public class FA_VoucherType
{
    #region Private Filed
    private string _VoucherType;
    private int _Id;
    #endregion

    #region Public Filed
    public string VoucherType
    {
        get { return _VoucherType; }
        set { _VoucherType = value; }
    }
    public int Id
    {
        get { return _Id; }
        set {_Id = value; }
    }
    #endregion

    public FA_VoucherType()
    {
        
    }
    public BLLCollection<FA_VoucherType> Get_VoucherType()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_VoucherType();
    }


    
}