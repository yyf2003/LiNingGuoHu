using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

public partial class WebUI_POPLanuch_POPLaunchTwo : System.Web.UI.Page
{
    protected string POPID = "";
    List<string> strsql = new List<string>();//存放生产的sql语句

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }

        POPID = Request.QueryString["popid"].ToString();
        ////////////////////////

        ////////////////////////////////////
        if (!Page.IsPostBack)
        {
            GetProductType();       //获取全部产品大类以及系列
        }

    }

    /// <summary>
    /// 获取全部产品大类以及系列
    /// </summary>
    private void GetProductType()
    {
        StringBuilder strcheck = new StringBuilder();
        IList<LN.Model.ProductLineType> typelist = new LN.BLL.ProductLineType().GetList(" isDelete=1");
        IList<LN.Model.ProductLineData> linelist = null;
        StringBuilder strtype = null;
        foreach (LN.Model.ProductLineType typemodel in typelist)
        {
            strtype = new StringBuilder();
            strtype.Append("<div class='divstype'><input type='checkbox' name='typename' onclick='TypeChoose(" + typemodel.ProductTypeID + ",this)' id='type_" + typemodel.ProductTypeID + "'/>" + typemodel.ProductTypeName + "</div>");
            linelist = new LN.BLL.ProductLineData().GetList(" TypeID='" + typemodel.ProductTypeID.ToString() + "'");
            strtype.Append("<div id='line_" + typemodel.ProductTypeID + "' style='width:100%'>");
            foreach (LN.Model.ProductLineData linemodel in linelist)
            {

                strtype.Append("<div  style='width:15%; float:left'><input  type='checkbox' id='a_" + linemodel.TypeID + "' value='" + linemodel.ProductLineID + "' name='linename'/> " + linemodel.ProductLine + "</div>");
            }
            strtype.Append("</div>");
            strcheck.Append(strtype.ToString());
        }
        L_proline.Text = strcheck.ToString();//加载所有的故事包类型和相应的故事包
    }

    //上传图片 支持大文件上传
    public void Uploadfile()
    {
        string fpath = Server.MapPath("../../UpLoad/UpLoadfiles/Upimgraw/" + POPID);//判断上传的文件夹是否存在 不存在则创建
        if (!Directory.Exists(fpath))
            Directory.CreateDirectory(fpath);

        LN.Model.POPImageData imgmodel = null;
        HttpFileCollection Files = HttpContext.Current.Request.Files;
        for (int i = 0; i < Files.Count; i++)
        {
            HttpPostedFile postedFile = Files[i];

            //上传原图
            if (postedFile != null)
            {
                string fileAllName = postedFile.FileName;
                if (!string.IsNullOrEmpty(fileAllName))
                {


                    imgmodel = new LN.Model.POPImageData();
                    string filename = fileAllName.Substring(fileAllName.LastIndexOf("\\") + 1);
                    string fileExname = System.IO.Path.GetExtension(filename);
                    string filepath = fpath + "\\" + filename;
                    postedFile.SaveAs(filepath);

                    //生产缩略图进行上传
                    bool type = false;
                    if (fileExname.CompareTo("jpg") > 0)
                    {
                        type = true;
                    }
                    string imageName = zipPhoto.SendToSmallImage(postedFile.InputStream, "../../UpLoad/UpLoadfiles/Upimgreduce/" + POPID, 250, 200, "", type);
                    string smallPath = "../../UpLoad/UpLoadfiles/Upimgreduce/" + POPID + "/" + imageName;

                    string strProductLine = Request.Form["linename"].ToString();
                    if (!string.IsNullOrEmpty(strProductLine))
                    {
                        string[] arrPList = strProductLine.Split(',');
                        foreach (string pLine in arrPList)
                        {
                            imgmodel.POPID = POPID;
                            imgmodel.ProductLine = pLine;
                            imgmodel.ImageUrl = "../../UpLoad/UpLoadfiles/Upimgraw/" + POPID + "/" + filename;// +fileExname;
                            imgmodel.SmallImageUrl = smallPath;
                            imgmodel.UploadDate = DateTime.Now.ToString("yyyy-MM-dd 24HH-mm-ss");
                            int intBegin = filepath.LastIndexOf("\\");
                            int intEnd = filepath.LastIndexOf(".");
                            imgmodel.ImageLevel = filepath.Substring(intBegin + 1, intEnd - intBegin - 1);
                            imgmodel.ShopLevelID = 0;
                            imgmodel.POPScaleData = "0";
                            imgmodel.ImageDesc = "";

                            new LN.BLL.POPImageData().Add(imgmodel);
                        }
                    }
                }
            }
        }
        LN.BLL.POPLaunch bll = new LN.BLL.POPLaunch();
        int intsteps = bll.getsetps(POPID);//得到此pop已经完成第几步了
        if (intsteps != 0 && intsteps < 3)
        {
            bll.Updatesteps(3, POPID);
        }

    }

    protected void Btn_next_Click(object sender, EventArgs e)
    {

        Uploadfile();//上传图片 

        Response.Redirect("POPImgSet.aspx?POPID=" + POPID);


    }


    //protected void DDL_ProductType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = new LN.BLL.ProductLineData().GetPOPproductLineByTypeID(POPID, int.Parse(DDL_ProductType.Text));
    //    DDL_productline.Items.Clear();
    //    ListItem oneitem = new ListItem("请选择产品大类", "0");
    //    DDL_productline.Items.Add(oneitem);
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        ListItem item = new ListItem(dt.Rows[i]["ProductLine"].ToString(), dt.Rows[i]["ProductLineID"].ToString());
    //        DDL_productline.Items.Add(item);
    //    }
    //}
    //protected void DDL_productline_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    IList<LN.Model.POPImageData> modellist = new LN.BLL.POPImageData().GetList("POPID='" + POPID + "' and productline=" + DDL_productline.Text);
    //    this.Repeater1.DataSource = modellist;
    //    Repeater1.DataBind();
    //}

    protected string GetShopPro(string id)
    {
        string _return = String.Empty;
        if (id != "")
        {

            List<LN.Model.POPSeat> list = new LN.BLL.POPSeat().GetList(string.Format(" SeatID in ({0})", id));
            foreach (LN.Model.POPSeat model in list)
            {
                _return += model.seat + "-";
            }
        }
        return _return.TrimEnd(new char[] { '-' });
    }
}
