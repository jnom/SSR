using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string userLogin(string pUserName, string vPassword)
    {
        string vResult = "";
        DataAccess Ds = new DataAccess();
        Prop ObjProp = new Prop();
        DataTable dtUserInfo = new DataTable();
        dtUserInfo = Ds.ExecuteDR("select UserID from User_Master where UserName='" + pUserName.Trim() + "' and Password = '" + vPassword + "' ");
        if (dtUserInfo.Rows.Count > 0)
        {
            ObjProp.UserID = Convert.ToInt32(dtUserInfo.Rows[0]["UserID"]);
            ObjProp.UserName = dtUserInfo.Rows[0]["UserName"].ToString();
        }
        return vResult;
    }

}
