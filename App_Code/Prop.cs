using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Prop
/// </summary>
public class Prop
{
    public Prop()
    { }
    public int UserID
    {
        get
        {
            if (HttpContext.Current.Session["UserID"] == null) HttpContext.Current.Session["UserID"] = "0";
            return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        }
        set { HttpContext.Current.Session["UserID"] = value; }
    }
    public string UserName
    {
        get
        {
            if (HttpContext.Current.Session["UserName"] == null) HttpContext.Current.Session["UserName"] = "";
            return UserName = HttpContext.Current.Session["UserName"].ToString();
        }
        set { UserName = value; }
    }
}