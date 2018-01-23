using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["id2"] = Request.QueryString["id"].ToString();
        int ctid = Convert.ToInt32(SqlHelper.ExecuteScalar("select cardnumber from Table_card where cardtitleid="+Session["id2"].ToString()));
        int i = SqlHelper.ExecuteNonQuery("update Table_card set cardnumber ="+(ctid+1).ToString()+" where cardtitleid="+Session["id2"].ToString());
        Response.Redirect("~/floor.aspx");
    }
}