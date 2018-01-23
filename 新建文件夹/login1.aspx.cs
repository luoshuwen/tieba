using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Drawing;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)//注册
    {
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            SqlDataReader sdr= SqlHelper.cmdexecutereader("SELECT username FROM Table_user WHERE username ='"+TextBox1.Text+"'");
            if (sdr.HasRows)
            {
                Label3.ForeColor = Color.DarkRed;
                Label3.Text = "用户名无效！";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                DateTime dt = DateTime.Now;
                int i = SqlHelper.ExecuteNonQuery("INSERT INTO Table_user (username,userpassword,usertime)VALUES('"+TextBox1.Text+"','"+TextBox2.Text+"','"+dt.ToString()+"')");
                string uid = SqlHelper.ExecuteScalar("select userid from Table_user where usertime='"+dt.ToString()+"'").ToString();
                Session["id"] = uid.ToString();
                Response.Redirect("~/card.aspx");
            }
        }
        else
        {
            Label3.ForeColor = Color.DarkRed;
            Label3.Text = "输入内容不能为空！";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            string upw = SqlHelper.ExecuteScalar("SELECT userpassword FROM Table_user WHERE username='" + TextBox1.Text + "'").ToString();
            if (upw == TextBox2.Text.Trim())
            {
                Label3.ForeColor = Color.DarkRed;
                Label3.Text = "登陆成功！";
                int uidd = Convert.ToInt32(SqlHelper.ExecuteScalar("select userid from Table_user where username='" + TextBox1.Text.Trim() + "'"));
                //Response.Redirect("card.aspx?m=3&id=" + uidd.ToString());
                Session["id"] = uidd.ToString();
                Response.Redirect("~/card.aspx");
            }
            else
            {
                Label3.ForeColor = Color.DarkRed;
                Label3.Text = "密码和用户名不匹配！";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }
        else
        {
            Label3.ForeColor = Color.DarkRed;
            Label3.Text = "输入内容不能为空！";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}