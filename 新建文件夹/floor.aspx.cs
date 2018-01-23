using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;


public partial class floor : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //设置Repeater的数据源并绑定
            //Repeater1.DataSource = SqlHelper.ExecuteAdapter("select * from Table_card");
            if (Session["id"].ToString() == "11")//游客
            {
                TextBox2.Enabled = false;
                Button1.Enabled = false;
                Button7.Enabled = false;
                FileUpload1.Enabled = false;
                TextBox2.Text = "发表内容请注册或登录！";
            }
            else
            {
                Button4.Enabled = true;
                Button2.Enabled = false;
                Button3.Enabled = false;
            }
            if (Session["id2"] == null)
            {
                Session["id2"] = Request.QueryString["id"].ToString();
            }
            labelusername.Text = SqlHelper.ExecuteScalar("select username from Table_user where userid=" + Session["id"].ToString()).ToString();
            Labeltitle.Text = SqlHelper.ExecuteScalar("select cardtitle from Table_card where cardtitleid=" + Session["id2"].ToString()).ToString();
            Repeater1.DataSource = pds();
            Repeater1.DataBind();
            //unamel = Convert.ToInt32(Request.QueryString["id"]);
            //labelusername.Text = SqlHelper.ExecuteScalar("select username from Table_user where userid='" + unamel.ToString() + "'").ToString();
            
        }
        
    }
   
    private PagedDataSource pds()
    {
        //string connstring = ConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
        //SqlConnection con = new SqlConnection(connstring);
        //SqlDataAdapter sda = new SqlDataAdapter("select * from Table_card", con);

        DataSet ds = SqlHelper.link("select * from Table_floor where floortitleid=" + Session["id2"].ToString());
        //sda.Fill(ds);

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = ds.Tables[0].DefaultView;

        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
        return pds;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        Repeater Repeater1 = (Repeater)Page.FindControl("Repeater1");
        Repeater Repeater2 = (Repeater)Repeater1.FindControl("Repeater2");
       ((TextBox)Repeater2.Controls[Repeater2.Controls.Count - 1].FindControl("TextBox1")).Visible = true;
        ((Button)Repeater2.Controls[Repeater2.Controls.Count - 1].FindControl("Button6")).Visible=true;
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "btn7")
        {
            Repeater rpt1 = (Repeater)Page.FindControl("Repeater1");
            Repeater rpt2 = (Repeater)rpt1.FindControl("Repeater2");
            TextBox tb1 = ((TextBox)rpt1.FindControl("TextBox1"));
            Button btn6 = ((Button)rpt1.FindControl("Button6"));
            if (tb1.Visible != true)
            { tb1.Visible = true; }
            else
            { tb1.Visible = false; }
            if (btn6.Visible != true)
            { btn6.Visible = true; }
            else
            { btn6.Visible = false; }
        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "btn5")
        {
            if (Session["id"].ToString() == "11" || Session["id"].ToString() == null)
            {
                Response.Redirect("~/login1.aspx");
            }
            else
            {
                TextBox tb1 = ((TextBox)e.Item.FindControl("TextBox1"));
                Button btn6 = ((Button)e.Item.FindControl("Button6"));
                if (tb1.Visible != true)
                { tb1.Visible = true; }
                else
                { tb1.Visible = false; }
                if (btn6.Visible != true)
                { btn6.Visible = true; }
                else
                { btn6.Visible = false; }
            }
        }
        if (e.CommandName == "btn6")
        {
            TextBox tb1 = ((TextBox)e.Item.FindControl("TextBox1"));
            if (tb1.Text == "")
            { tb1.Text = "请输入内容！";}
            else
            {
                HiddenField hidd = (HiddenField)e.Item.FindControl("HiddenField1");
                string id = hidd.Value.ToString();
                int rid = Convert.ToInt32(SqlHelper.ExecuteScalar("select reid from Table_re where retitleid=" + Session["id2"].ToString() + " and refloorid=" + id));
                string run = SqlHelper.ExecuteScalar("select username from Table_user where userid="+Session["id"].ToString()).ToString();
                DateTime dt = DateTime.Now;
                int i=SqlHelper.ExecuteNonQuery("insert into Table_re (retitleid,refloorid,reid,recontent,reuserid,reusername,retime)values("+Session["id2"].ToString()+","+id+","+(rid+1).ToString()+",'"+tb1.Text+"',"+Session["id"].ToString()+",'"+run+"','"+dt.ToString()+"') ");
                Response.Redirect(Request.Url.ToString());
            }
        }
        
    }
    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        //Button btn5 = (Button)e.Item.FindControl("Button5");
        
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
            //Response.Redirect("card.aspx?id=" + unamel.ToString());
            hlfir.NavigateUrl = "?page=0";
            HyperLink hlla = (HyperLink)e.Item.FindControl("hlla");
            //Response.Redirect("card.aspx?id=" + unamel.ToString());
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

        if (e.Item.ItemType == ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
        {
            HiddenField hidd = (HiddenField)e.Item.FindControl("HiddenField1");
            string id = hidd.Value.ToString();
            Repeater Repeater2 = (Repeater)e.Item.FindControl("Repeater2");
            string k = Session["id2"].ToString();
            Repeater2.DataSource = SqlHelper.ExecuteAdapter("select * from Table_re where retitleid="+Session["id2"].ToString()+" and refloorid="+id);
            Repeater2.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "" ||Image1.ImageUrl!=null)
        {
           /* if (Image1.ImageUrl != null)
            {

                int flrid = Convert.ToInt32(SqlHelper.ExecuteScalar("select cardfloormax from Table_card where cardtitleid=" + Session["id2"].ToString()));
                int mid = SqlHelper.ExecuteNonQuery("insert into Table_pic (pictitleid,picfloorid,picpath)values(" + Session["id2"].ToString() + "," + flrid.ToString() + ",'" + Image1.ImageUrl + "')");
            }*/
            int uid = Convert.ToInt32(SqlHelper.ExecuteScalar("SELECT carduserid FROM Table_card WHERE cardtitleid=" + Session["id2"].ToString()));
                string uname = SqlHelper.ExecuteScalar("SELECT cardusername FROM Table_card WHERE cardtitleid=" + Session["id2"].ToString()).ToString();
                int mfrid = Convert.ToInt32(SqlHelper.ExecuteScalar("select cardfloormax from Table_card where cardtitleid=" + Session["id2"].ToString()));
                if (Image1.ImageUrl == null)
                {
                    int i = SqlHelper.ExecuteNonQuery("INSERT INTO Table_floor (floortitleid,floorid,flooruserid,floorusername,floorcontent)VALUES(" + Session["id2"].ToString() + "," + (mfrid + 1).ToString() + "," + uid.ToString() + ",'" + uname + "','" + TextBox2.Text + "')");
                }
                else
                {
                    int i = SqlHelper.ExecuteNonQuery("INSERT INTO Table_floor (floortitleid,floorid,flooruserid,floorusername,floorcontent,floorpic)VALUES(" + Session["id2"].ToString() + "," + (mfrid + 1).ToString() + "," + uid.ToString() + ",'" + uname + "','" + TextBox2.Text + "','"+Image1.ImageUrl+"')");

                }
                int j = SqlHelper.ExecuteNonQuery("update Table_card set cardfloormax =" + (mfrid + 1).ToString() + " where cardtitleid=" + Session["id2"].ToString());
                Response.Redirect(Request.Url.ToString());
                
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

    protected void Button7_Click(object sender, EventArgs e)
    {
        /*string severpath = Server.MapPath("UpLoad");
        if (!System.IO.Directory.Exists(severpath))
        { System.IO.Directory.CreateDirectory(severpath); }
        if (FileUpload1.HasFile)
        {
            int filesize = FileUpload1.PostedFile.ContentLength / 1024 / 1024;
            if (filesize > 8)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('只允许上传不大于8m的图片！');", true);
                return;
            }
            else
            {
                FileUpload1.SaveAs(severpath+"\\"+FileUpload1.FileName);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('上传成功！');", true);
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请选择文件！');", true);
            return;
        }*/

        if (FileUpload1.PostedFile.FileName != "")
        {
            string filepath = FileUpload1.PostedFile.FileName;
            string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            string fileEx = filepath.Substring(filepath.LastIndexOf(".") + 1);
            string serverpath = Server.MapPath("File/") + filename;
            if (fileEx == "jpg" || fileEx == "bmp" || fileEx == "gif")
            {
                FileUpload1.PostedFile.SaveAs(serverpath);
                Image1.ImageUrl = "File/" + filename;
            }
            else
            {
                Label10.Text = "上传的图片扩展名错误！";
            }
        }
    }
    protected void Button8_Click1(object sender, EventArgs e)
    {
        if (TextBox3.Text != "")
        {
            Session["id5"] = DropDownList1.SelectedIndex.ToString();
            Session["id4"] = TextBox3.Text;
            Response.Redirect("~/find.aspx");
        }
    }
}



