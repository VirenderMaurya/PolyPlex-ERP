using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FA_VendorMaster
/// </summary>
public class FA_VendorMaster
{
    #region private fields
    string _fivendorcode;
	string _mmfivendor;
	int _oldfivendorCode;
	string _vendorgroup;
	bool _typecompany;
	string _vendorname;
	string _vendoraddress;
	string _postalcode;
	string _city;
    string _country;
	string _region;
	int _telephoneno;
	int _telephoneextn;
	int _faxno;
	int _faxextn;
	string _companyemailaddress1;
	string _companyemailaddress2;
	string _contactpersonone;
	int _contactpersononecontactno;
	string _contactpersontwo;
    int _contactpersontwocontactno;
	string _paymentterm;
	string _incoterm;
	string _ordcurrency;
	string _itexid;
	string _nearestseaport;
	string _nearestairport;
	string _vatinpercentage;
	string _debitglcode;
    bool _active;
    #endregion

    #region Public fields
    public string FIVendorCode
    {
        get { return _fivendorcode; }
        set { _fivendorcode = value; }
    }
    public string MMFIVendor
    {
        get{return _mmfivendor;} set{_mmfivendor=value;}
    }
    public int OldFIVendorCode
    {
        get {return _oldfivendorCode;} set{ _oldfivendorCode=value;}
    }
    public string VendorGroup
    {
        get { return _vendorgroup;} set{_vendorgroup=value;}
    }
    public bool TypeCompany
    {
        get{return _typecompany;} set{_typecompany=value;}
    }
	public string VendorName
    {
        get { return _vendorname;}  set{_vendorname=value;}
    }
	public string VendorAddress
    {
      get{return _vendoraddress;} set{_vendoraddress=value;}
    }
    public string PostalCode
    {
        get{return _postalcode;} set{_postalcode=value;}
    }
	public string City
    {
        get{return _city;} set{_city=value;}
    }
    public string Country
    {
        get{return _country;} set{_country=value;}
    }
	public string Region
    {
        get{return _region;} set{_region=value;}
    }
	public int Telephone
    {
        get{return _telephoneno;} set{_telephoneno=value;}
    }
	public int TelephoneExtn
    {
        get{return _telephoneextn;} set{_telephoneextn=value;}
    }
	public int FaxNo
    {
        get{return _faxno;} set{_faxno=value;}
    }
    public int FaxNoExtn
    {
        get{return _faxextn;} set{_faxextn=value;}
    }
	public string CompanyEmailAddress1
    {
        get{return _companyemailaddress1;} set{_companyemailaddress1=value;}
    }
    public string CompanyEmailAddress2
    {
        get{return _companyemailaddress2;} set{_companyemailaddress2=value;}
    }
	public string ContactPersonOne
    {
        get{return _contactpersonone;} set{_contactpersonone=value;}
    }
    public int ContactPersonOneContactNo
    {
        get{return _contactpersononecontactno;} set{_contactpersononecontactno=value;}
    }
    public string ContactPersonTwo
    {
        get{return _contactpersontwo;} set{_contactpersontwo=value;}
    }
	public int ContactPersonTwoContactNo
    {
        get{return _contactpersontwocontactno;} set{_contactpersontwocontactno=value;}
    }
	public string PaymentTerm
    {
        get{return _paymentterm;} set{_paymentterm=value;}
    }
	public string IncoTerm
    {
        get{return _incoterm;} set{_incoterm=value;}
    }
    public string ORDCurrency
    {
        get{return _ordcurrency;} set{_incoterm=value;}
    }
    public string ITexID
    {
        get{return _itexid;} set{_itexid=value;}
    }
    public string NearestSeaPort
    {
        get{return _nearestseaport;} set{_nearestseaport=value;}
    }
    public string NearestAirPort
    {
        get{return _nearestairport;} set{_nearestairport=value;}
    }
    public string VATInPercentage
    {
        get{return _vatinpercentage;} set{_vatinpercentage=value;}
    }
    public string DebitGLCode
    {
        get{return _debitglcode;} set{_debitglcode=value;}
    }
	public bool Active
    {
        get{return _active;} set{_active=value;}
    }
    #endregion
    
    public FA_VendorMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public BLLCollection<FA_VendorMaster> GetVendorList_ByVendorCode(string vendercode)
    {
        SqlDataProvider sda=new SqlDataProvider();
        return (BLLCollection<FA_VendorMaster>)sda.GetVendorList_ByVendorCode(vendercode);
    }
    public BLLCollection<FA_VendorMaster> GetVendorList_ByVendorName(string vendername)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return (BLLCollection<FA_VendorMaster>)sda.GetVendorList_ByVendorName(vendername);
    }
    public string GetVendorName_By_VendorCode(string vcode)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.GetVendorName_By_VendorCode(vcode);
    }
}