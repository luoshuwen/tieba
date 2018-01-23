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


public partial class card : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //设置Repeater的数据源并绑定
            //Repeater1.DataSource = SqlHelper.ExecuteAdapter("select * from Table_card");
            if (Session["id"] == null || Session["id"].ToString() == "11")//当前是游客
            {
                Session["id"] = "11";
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                Button1.Enabled = false;
                TextBox1.Text = "发表内容请注册或登录！";
                TextBox2.Text = "发表内容请注册或登录！";

            }
            else
            {
                Button2.Enabled = false;
                Button3.Enabled = false;
                Button4.Enabled = true;
            }
            labelusername.Text = SqlHelper.ExecuteScalar("select username from Table_user where userid=" + Session["id"].ToString()).ToString();
            Repeater1.DataSource = pds();
            Repeater1.DataBind();
            //unamel = Convert.ToInt32(Request.QueryString["id"]);
            //labelusername.Text = SqlHelper.ExecuteScalar("select username from Table_user where userid='" + unamel.ToString() + "'").ToString();
            //Session["id"].ToString();
        }
    }

    private PagedDataSource pds()
    {
        DataSet ds = SqlHelper.link("select * from Table_card order by cardtitleid desc");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables[0].DefaultView;
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
        return pds;
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {//判断当前项是页脚模板
            int n = pds().PageCount;//将分页总数赋给变量n
            int i = pds().CurrentPageIndex;//将当前分页码赋给i

            Label Label1 = (Label)e.Item.FindControl("Label1");
            Label1.Text = n.ToString();
            //找到lblpc这个Label，将总页码赋给他

            Label Label2 = (Label)e.Item.FindControl("Label2");
            Label2.Text = Convert.ToString(pds().CurrentPageIndex + 1);
            //找到lblp这个Label，将当前页码赋给他，但是注意，因为页码从0开始，这里要直观的话就得加1

            HyperLink hlfir = (HyperLink)e.Item.FindControl("hlfir");

            hlfir.NavigateUrl = "?page=0";
            HyperLink hlla = (HyperLink)e.Item.FindControl("hlla");
            hlla.NavigateUrl = "?page=" + Convert.ToInt32(n - 1);
            //找到表示最前页和末页的Label，为他们的NavigateUrl属性赋为第0页和最大页码减1
            HyperLink hlp = (HyperLink)e.Item.FindControl("hlp");
            HyperLink hln = (HyperLink)e.Item.FindControl("hln");
            //找到表示上页和下页这两个控件
            if (i <= 0)
            {//如果当前页已经是第0页
                hlp.Enabled = false;
                hlfir.Enabled = false;
                hln.Enabled = true;
            }
            else
            {
                //Response.Redirect("card.aspx?id=" + unamel.ToString());
                hlp.NavigateUrl = "?page=" + Convert.ToInt32(i - 1);
            }
            if (i > n - 2)
            {//如果当前项已经是最末页
                hln.Enabled = false;
                hlla.Enabled = false;
                hlp.Enabled = true;
            }
            else
            {
                //Response.Redirect("card.aspx?id=" + unamel.ToString());
                hln.NavigateUrl = "?page=" + Convert.ToInt32(i + 1);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            int uid = Convert.ToInt32(SqlHelper.ExecuteScalar("SELECT userid FROM Table_user WHERE username='" + labelusername.Text + "' "));
            DateTime dt = DateTime.Now;
            int i = SqlHelper.ExecuteNonQuery("INSERT INTO Table_card (carduserid,cardusername,cardfloormax,cardtitle,cardcontent,cardtime)VALUES(" + uid.ToString() + ",'" + labelusername.Text + "',1,'" + TextBox1.Text + "','" + TextBox2.Text + "','"+dt.ToString()+"')");
            string tid = SqlHelper.ExecuteScalar("select cardtitleid from Table_card where cardtime='"+dt.ToString()+"'").ToString();
            int j = SqlHelper.ExecuteNonQuery("insert into Table_floor (floortitleid,floorid,flooruserid,floorusername,floorcontent)values(" + tid.ToString() + ",1," + uid.ToString() + ",'" + labelusername.Text + "','" + TextBox2.Text + "')");
            Response.Redirect("~/card.aspx");
        }
        else
        {
            Label5.ForeColor = Color.DarkRed;
            Label5.Text = "发表内容不能为空！";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login1.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login1.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["id"] = "11";
        Response.Redirect("~/card.aspx");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text != "")
        {
            Session["id5"] = DropDownList1.SelectedIndex.ToString();
            Session["id4"] = TextBox3.Text;
            Response.Redirect("~/find.aspx");
        }
    }

   
}