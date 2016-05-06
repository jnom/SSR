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
    public Auth userLogin(UserDetails UserDetails)
    {
        DataAccess Ds = new DataAccess();
        DataTable dtUserInfo = new DataTable();
        Auth auth = new Auth();
        dtUserInfo = Ds.ExecuteDR("select UserID,UserName from User_Master where UserName='" + UserDetails.userName + "' and Password = '" + UserDetails.password + "' ");
        if (dtUserInfo.Rows.Count > 0)
        {
            auth.userID = dtUserInfo.Rows[0]["UserID"].ToString();
            auth.userName = dtUserInfo.Rows[0]["UserName"].ToString();
        }
        return auth;
    }
    [WebMethod]
    public int saveGrnHeader(saveGrn objGrn)
    {

        return 0;
    }

}
