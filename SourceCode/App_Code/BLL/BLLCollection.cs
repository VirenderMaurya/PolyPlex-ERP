using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLCollection
/// </summary>
public class BLLCollection<T>:CollectionBase 
{


    public T this[int index]
    {
        get { return (T)List[index]; }
        set { List[index] = value; }
    } 
        
    public int Add(T value)
    {
        return (List.Add(value));
    }
    public int IndexOf(T value)
    {
        return (List.IndexOf(value));
    }
    public void Insert(int index, T value)
    {
        List.Insert(index, value);
    }
    public void Remove(T value)
    {
        List.Remove(value);
    }
    public bool Contains(T value)
    {
        return (List.Contains(value));
    }
    protected void OnInsert(int index, object value)
    {
     if(! object.ReferenceEquals(value.GetType(),typeof(T)))
     {
         throw new ArgumentException("value must be of type BLL.", "value"); 
     }
  
    }
    protected void OnRemove(int index, object value)
    {
        if (!object.ReferenceEquals(value.GetType(), typeof(T)))
        {
            throw new ArgumentException("value must be of type BLL.", "value");
        }  
    }

    protected  void OnSet(int index, object oldValue, object newValue)
    {
       
        if(! object.ReferenceEquals(newValue.GetType(),typeof(T)))
        {
            throw new ArgumentException("newValue must be of type BLL.", "newValue"); 
        }
    }

    protected  void OnValidate(object value)
    {
        if ((!object.ReferenceEquals(value.GetType(), typeof(T))))
        {
            throw new ArgumentException("value must be of type BLL.");
        }
    } 







	public BLLCollection()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
