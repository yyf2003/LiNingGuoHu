using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using dotnetCHARTING;
public partial class WebUI_DSRCheck_EveryAreaCheckShopCount : System.Web.UI.Page
{
    string deptname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;
        string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名

        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        //if (deptdt.Rows.Count > 0)
        //{
        //    deptname = deptdt.Rows[0]["department"].ToString();
        //}
        if (!Page.IsPostBack)
        {

            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_department.Items.Add(item);
            }
            string strareaBydept = "";
            if (deptdt.Rows.Count > 0)
            {
                DDL_department.DataSource = deptdt;
                DDL_department.DataTextField = "department";
                DDL_department.DataValueField = "department";
                DDL_department.DataBind();

                strareaBydept += string.Format(" department='{0}' ", DDL_department.SelectedValue);
                //DDL_department.Text = deptname;
                //DDL_department.Enabled = false;
            }
            // 根据登录人ID得到所属省区 并加载相应市
            string strArea = "";
            DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                strArea = " areaid= " + userdt.Rows[0][0].ToString();
                DDL_department.Text = userdt.Rows[0][2].ToString();
                DDL_department.Enabled = false;
            }
            strArea = strareaBydept == "" ? strArea : strareaBydept;
            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strArea);
            foreach (LN.Model.AreaData model in arealist)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                CBlist_Area.Items.Add(item);
            }
            if (userdt.Rows.Count > 0)
            {
                CBlist_Area.Items[0].Selected = true;
                CBlist_Area.Enabled = false;
            }
            //加载所有的 POP发起ID
            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                DDL_POPID.Items.Add(item);
            }

        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {
        StringBuilder strWhere = new StringBuilder();
        if (DDL_POPID.Text != "0")
        {
            strWhere.Append(string.Format(" and POPID='{0}'", DDL_POPID.Text));
        }
        if (txt_btime.Text != "")
        {
            strWhere.Append(string.Format(" and CheckDate >='{0}'", txt_btime.Text.Trim()));
        }
        if (txt_endtime.Text != "")
        {
            strWhere.Append(string.Format(" and CheckDate <='{0}'", txt_endtime.Text));
        }
        string arealist = "";
        for (int i = 0; i < CBlist_Area.Items.Count; i++)
        {
            if (CBlist_Area.Items[i].Selected)
            {
                arealist += CBlist_Area.Items[i].Value + ",";
            }
        }
        if (arealist.Length > 0)
        {
            arealist = arealist.Remove(arealist.Length - 1);
            strWhere.Append(string.Format(" and b.areaid in ({0})", arealist));
        }



        DataSet ds = new LN.BLL.DSRExamData().EveryAreaCheckShopCount(strWhere.ToString());
        this.GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

        GridView2.DataSource = ds.Tables[1];
        GridView2.DataBind();

        GridView3.DataSource = ds.Tables[2];
        GridView3.DataBind();
        DrawReport(ds.Tables[2]);//画柱状图
    }

    private void DrawReport(DataTable dt)
    {
        Chart1.Title = "检查项目柱形图";
        Chart1.XAxis.Label.Text = "检查项目";
        Chart1.YAxis.Label.Text = "百分比";
        Chart1.TempDirectory = "ChartImage";
        Chart1.FileManager.FileName = "TypeImage";
        Chart1.Width = 800;
        Chart1.Height = 300;
        Chart1.Type = ChartType.Combo;
        Chart1.Debug = false;
        Chart1.Mentor = false;
        //chart.Series.Type = this.Type;//生成对比的线型图时不适用
        Chart1.DefaultSeries.Type = "Column"; //统一使用默认的序列图类型属性

        SeriesCollection SC = new SeriesCollection();

        for (int i = 1; i < dt.Columns.Count; i++)
        {
            Series s = new Series();
            s.Name = dt.Columns[i].ColumnName;
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                Element e = new Element();
                e.Name = dt.Rows[m][0].ToString();

                e.YValue = double.Parse(dt.Rows[m][i].ToString());
                s.Elements.Add(e);
            }

            




            SC.Add(s);

        }
        //Random myR = new Random();
        //    for (int a = 1; a < 6; a++)
        //    {
        //        Series s = new Series();
        //        s.Name = "Series " + a.ToString();s
        //        for (int b = 1; b < 3; b++)
        //        {
        //            Element e = new Element();
        //            e.Name = "Element " + b.ToString();
        //            e.YValue = myR.Next(50);
        //            s.Elements.Add(e);
        //        }
        //        SC.Add(s);
        //    }
        //SC[0].DefaultElement.Color = Color.FromArgb(49, 255, 49);

        //Chart1.Series.Name = this.SeriesName;
        Chart1.SeriesCollection.Add(SC);
        Chart1.DefaultSeries.DefaultElement.ShowValue = false;
        // Chart1.ShadingEffect = true;
        Chart1.Use3D = false;
        Chart1.Series.DefaultElement.ShowValue = true;
    }
    protected void DDL_department_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strArea = "";
        if (DDL_department.Text != "0")
            strArea = " department= '" + DDL_department.Text + "'";

        CBlist_Area.Items.Clear();
        //加载区域
        IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strArea);
        foreach (LN.Model.AreaData model in arealist)
        {
            ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
            CBlist_Area.Items.Add(item);
        }
    }
}
