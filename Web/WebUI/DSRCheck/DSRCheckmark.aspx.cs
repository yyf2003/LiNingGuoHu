using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;
using dotnetCHARTING;

public partial class WebUI_DSRCheck_DSRCheckmark : System.Web.UI.Page
{
   protected StringBuilder Bigtable = new StringBuilder();
    protected string resultstr = string.Empty,UserID=string.Empty;
    protected int checkshopnum = 0, shouldcheck = 0;
    string deptname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
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
            string strarea = "";
            if (!string.IsNullOrEmpty(deptname))
                strarea += string.Format(" department='{0}' ", deptname);

            //加载供应商

            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("");
            for (int i = 0; i < list.Count; i++)
            {
                ListItem item = new ListItem(list[i].SupplierName, list[i].SupplierID.ToString());
                this.ddl_supplier.Items.Add(item);
            }

            

            //加载所有的 POP发起ID
            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                DDL_POPID.Items.Add(item);
            }
            //加载DSR人员
            DataTable typedt = new LN.BLL.UserInfo().GetNameByType("DSR");
            for (int i = 0; i < typedt.Rows.Count; i++)
            {
                ListItem item = new ListItem(typedt.Rows[i][1].ToString(),typedt.Rows[i][0].ToString());
                txt_DsrName.Items.Add(item);
            }

            // 根据登录人ID得到所属省区 并加载相应市

            DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                DDL_Area.Text = userdt.Rows[0][0].ToString();
                DDL_department.Text = userdt.Rows[0][2].ToString(); ;
                DDL_department.Enabled = false;
                DDL_Area.Enabled = false;
                IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
                foreach (LN.Model.ProvinceData pmodel in prolist)
                {
                    DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                }
                string GetSuplierID = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + DDL_Area.Text + "'");
                if (GetSuplierID != "")
                {
                    ddl_supplier.Text = GetSuplierID;
                    ddl_supplier.Enabled = false;
                }
            }
            else
            {
                if (deptdt.Rows.Count > 0)
                {
                    //DDL_department.Text = deptname;
                    //DDL_department.Enabled = false;
                    DDL_department.DataSource = deptdt;
                    DDL_department.DataTextField = "department";
                    DDL_department.DataValueField = "department";
                    DDL_department.DataBind();
                    //加载区域
                    IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(string.Format(" department='{0}'", DDL_department.SelectedValue));
                    foreach (LN.Model.AreaData model in arealist)
                    {
                        ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                        DDL_Area.Items.Add(item);
                    }
                }
            }

            string supplierID = "0";//如果是VM进来 供应商ID 为 0 
            IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
            if (supplierBody != null)
            {
                supplierID = supplierBody[0].ToString();
                ddl_supplier.Text = supplierID;

                ddl_supplier.Enabled = false;
            }
            if (supplierID != "0")
            {
                DataTable sdt = new LN.BLL.SupplierAssignRecord().GetSupplierArea(int.Parse(supplierID));
                DDL_Area.Items.Clear();
                DDL_Area.Items.Add(new ListItem("请选择省","0"));
                for (int i = 0; i < sdt.Rows.Count; i++)
                {
                    DDL_Area.Items.Add(new ListItem(sdt.Rows[i][0].ToString(), sdt.Rows[i][1].ToString()));
                }
                
            }
            
        }
    }
    protected void Btn_search_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("supplerID", ddl_supplier.Text);
        ht.Add("beginDate",txt_btime.Text.Trim());
        ht.Add("endDate",txt_endtime.Text.Trim());
        ht.Add("POPID",DDL_POPID.Text);
        ht.Add("areaID",DDL_Area.Text);
        ht.Add("provinceID", Request.Form["DDL_Province"].ToString());
        ht.Add("cityID", Request.Form["DDL_city"].ToString());
        ht.Add("checkname", txt_DsrName.Text.Trim());
        ht.Add("boolstall",DDL_stall.Text);
        ht.Add("department",DDL_department.Text);
        DataSet ds = new LN.BLL.DSRExamData().GetResultlist(ht);//得到检查所分析的数据  其中返回的数据为某个DSR 检查了多少家
        DataTable dt1 = ds.Tables[0];
        DataTable dt2 = ds.Tables[1];
        DataTable dt3=ds.Tables[2];
        ////画图
        getDrawProImage(dt2);
        getDrawItemImage(dt2, dt1);
        /////////////
        checkshopnum = int.Parse(dt3.Rows[0][0].ToString());
        Bigtable.Append("<table class='table' style=' margin-left:5%'");
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            Bigtable.Append("<tr>");
            Bigtable.Append("<td valign='middle' align='center'>" + dt2.Rows[i][0].ToString() + "</td><td>" + GetSubtable(dt1, dt2.Rows[i][0].ToString()) + "</td><td valign='middle' align='center'>" + ((float)dt2.Rows[i][1]).ToString("##0.00") + "%</td>");
            Bigtable.Append("</tr>");
        }
        Bigtable.Append("</table>");
        shouldcheck = new LN.DAL.Base_set().GetBase_value("DSRCheckShop");//应该检查的店铺
        if (txt_DsrName.Text != "0")
        {
            resultstr = txt_DsrName.SelectedItem.Text + "应检查" + shouldcheck.ToString() + "家店铺,实际检查&nbsp;&nbsp;&nbsp;&nbsp;<a href='OneDsrCheckshop.aspx?POPID="+DDL_POPID.Text+"&checkuser="+txt_DsrName.Text+"&checkname="+Server.HtmlEncode(txt_DsrName.SelectedItem.Text)+"'>" + checkshopnum.ToString() + "</a>&nbsp;&nbsp;&nbsp;&nbsp;加店铺，检查了" + (decimal)checkshopnum * 100 / (decimal)shouldcheck + "%";
        }
    }

    public string GetSubtable(DataTable dt, string Dsrtype)
    {
        StringBuilder strtable = new StringBuilder();
        strtable.Append("<table style='width:100%'>");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Dsrtype.Equals(dt.Rows[i][0].ToString()))
            {
                strtable.Append("<tr>");
                strtable.Append("<td style='width:300px'>" + dt.Rows[i][1].ToString() + "</td><td>" + ((float)dt.Rows[i][2]).ToString("##0.00") + "%</td>");
                strtable.Append("</tr>");
            }
        }
        strtable.Append("</table>");
        
        return strtable.ToString();
    }
    /// <summary>
    /// 画出柱状图
    /// </summary>
    /// <param name="prodt"></param>
    /// <param name="itemdt"></param>
    public void getDrawProImage(DataTable prodt)
    {
        Chart1.Title = "检查项目柱形图";
        Chart1.XAxis.Label.Text = "检查项目";
        Chart1.YAxis.Label.Text = "百分比";
        Chart1.TempDirectory = "ChartImage";
        Chart1.FileManager.FileName = "proImage";
        Chart1.Width = 600;
        Chart1.Height = 300;
        Chart1.Type = ChartType.Combo;
        Chart1.Debug = false;
        Chart1.Mentor = false; 
        //chart.Series.Type = this.Type;//生成对比的线型图时不适用
        Chart1.DefaultSeries.Type = "Column"; //统一使用默认的序列图类型属性
  
        SeriesCollection SC = new SeriesCollection();

        for (int i = 0; i < prodt.Rows.Count; i++)
        {
            Series s = new Series();
            s.Name = prodt.Rows[i][0].ToString() + prodt.Rows[i][1].ToString();
            Element e = new Element();
            e.Name = prodt.Rows[i][0].ToString();
            e.YValue = double.Parse(prodt.Rows[i][1].ToString());
            s.Elements.Add(e);

            SC.Add(s);

        }
        //SC[0].DefaultElement.Color = Color.FromArgb(49, 255, 49);

        //Chart1.Series.Name = this.SeriesName;
        Chart1.SeriesCollection.Add(SC);
        Chart1.DefaultSeries.DefaultElement.ShowValue = true;
       // Chart1.ShadingEffect = true;
        Chart1.Use3D =false;
        Chart1.Series.DefaultElement.ShowValue = true;
    }

    public void getDrawItemImage(DataTable prodt, DataTable itemdt)
    {
        Chart2.Title = "每项细则柱形图";
        Chart2.XAxis.Label.Text = "细则";
        Chart2.TempDirectory = "ChartImage";
        Chart2.FileManager.FileName = "itemImage";
        Chart2.Width = 1400;
        Chart2.Height = 600;
        Chart2.Type = ChartType.Combo;
        
        Chart2.Debug = false;
        Chart2.DefaultSeries.Type = "Column"; //统一使用默认的序列图类型属性
        Chart2.Mentor = false;
        Chart2.XAxis.StaticColumnWidth = 30;
        SeriesCollection SC = new SeriesCollection();
        //for (int i = 0; i < prodt.Rows.Count; i++)
        //{
        Random myR = new Random();
            for (int y = 0; y < itemdt.Rows.Count; y++)
            {
                Series s = new Series();
                s.Name = itemdt.Rows[y][0].ToString() + itemdt.Rows[y][1].ToString();
                Element e = new Element();
                //e.Name = itemdt.Rows[y][1].ToString() + "(" + itemdt.Rows[y][2].ToString() + ")";
                e.Name = "(" + itemdt.Rows[y][2].ToString() + ")"+y;
                e.YValue = double.Parse(itemdt.Rows[y][2].ToString());
                
                s.Elements.Add(e);
                SC.Add(s);
            }
          
        //}
        Chart2.SeriesCollection.Add(SC);
        Chart2.DefaultSeries.DefaultElement.ShowValue = true;
        //Chart2.ShadingEffect = true;
        Chart2.Use3D = false;
        Chart2.Series.DefaultElement.ShowValue = true;
    }
}
