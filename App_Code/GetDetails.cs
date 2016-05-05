using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for GetDetails
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class GetDetails : System.Web.Services.WebService
{

    public GetDetails()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<UserDetails> UserLogin(UserDetails pObj)
    {
        List<UserDetails> vRetu = new List<UserDetails>();
        DataAccess Ds = new DataAccess();
        DataTable dtUserInfo = new DataTable();
        //dtUserInfo = Ds.ExecuteDR("select UserID from User_Master where UserName='" + pObj.UserName + "' and Password = '" + pObj.Password + "' ");
        //if (dtUserInfo.Rows.Count > 0)
        //{
        //    vRetu.Add(new UserDetails
        //    {
        //        UserID = dtUserInfo.Rows[0]["UserID"].ToString(),
        //        UserName = dtUserInfo.Rows[0]["UserName"].ToString()
        //    });
        //}

        //JavaScriptSerializer js = new JavaScriptSerializer();
        //Context.Response.Write(js.Serialize(_li)); 
        return vRetu;
    }

}
