using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using Bestcomy.Web.Controls.Upload;
public partial class WebUI_POPLanuch_POPLaunchOne : System.Web.UI.Page
{
    protected string POPID = "", LanuchUserID = "";
    private string _uploadID = string.Empty;
    public string UploadID
    {
        get
        {
            return this._uploadID;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        LanuchUserID = Request.Cookies["UserID"].Value;
        //string lastEndDate = new LN.BLL.POPLaunch().GetLastEndDate();
        //if (lastEndDate.Length > 0)
        //{
        //    Response.Write("<div style='font-size:18px;color:#c86000'>上一期POP结束时间为"+lastEndDate+"，还不能发起POP</font>");
        //    Response.End();
        //}
       
        string addmonth = System.Configuration.ConfigurationManager.AppSettings["POPcycle"].ToString();//在web.config中配置的POP的周期
        if (!Page.IsPostBack)
        {
            POPID = DateTime.Now.ToString("yyyyMMddhhmmss");
            this.txt_POPID.Text = POPID;
            StringBuilder strcheck = new StringBuilder();
            IList<LN.Model.ProductLineType> typelist = new LN.BLL.ProductLineType().GetList(" isDelete=1");
            IList<LN.Model.ProductLineData> linelist = null;
            StringBuilder strtype = null;
            foreach (LN.Model.ProductLineType typemodel in typelist)
            {
                strtype = new StringBuilder();
                strtype.Append("<div class='divstype'><input type='checkbox' name='typename' onclick='TypeChoose(" + typemodel.ProductTypeID + ",this)' id='type_" + typemodel.ProductTypeID + "'/>" + typemodel.ProductTypeName + "</div>");
                linelist = new LN.BLL.ProductLineData().GetList(" TypeID='" + typemodel.ProductTypeID.ToString() + "'");
                strtype.Append("<div id='line_"+typemodel.ProductTypeID+"' style='width:100%'>");
                foreach (LN.Model.ProductLineData  linemodel in linelist)
                {

                    strtype.Append("<div  style='width:15%; float:left'><input  type='checkbox' id='a_" + linemodel.TypeID + "' value='" + linemodel.ProductLineID + "' name='linename'/> " + linemodel.ProductLine + "</div>");
                }
                strtype.Append("</div>");
                strcheck.Append(strtype.ToString());
            }
            L_proline.Text = strcheck.ToString();//加载所有的故事包类型和相应的故事包
            this.txt_btime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txt_etime.Text = DateTime.Parse(txt_btime.Text).AddMonths(int.Parse(addmonth)).ToString("yyyy-MM-dd");
         }
         AspnetUpload upldr = new AspnetUpload();
         upldr.RegisterProgressBar();
         this._uploadID = upldr.get_UploadID();
         this.Btn_popOne.Attributes.Add("onclick", "return  showProgressBar();" + ClientScript.GetPostBackEventReference(Btn_popOne, string.Empty) + ";");
         Page.ClientScript.RegisterClientScriptInclude("prototype", "../../js/prototype-1.3.1.js");
         Page.ClientScript.RegisterClientScriptInclude("dom-drag", "../../js/dom-drag.js");

    }
    protected void Btn_popOne_Click(object sender, EventArgs e)
    {
        LN.Model.POPLaunch model = new LN.Model.POPLaunch();
        model.POPID = this.txt_POPID.Text;
        model.POPTitle = txt_poptitle.Text.Trim();
        model.OrganigerID = int.Parse(LanuchUserID);
        model.OrganigerName = "";
        model.BeginDate = DateTime.Parse(txt_btime.Text.Trim());
        model.EndDate = DateTime.Parse(txt_etime.Text.Trim());
        model.LaunchDesc = txt_remarks.Text;
        model.ProductLineDatas = Request.Form["linename"].ToString();
        model.steps = 2;
        model.BoolPrice = int.Parse(DDL_price.Text);
        string savefilepath = "";

        Bestcomy.Web.Controls.Upload.UploadFile FileUP = AspnetUpload.GetUploadFile("File1");
        if (FileUP!=null)
        {
            string fpath = Server.MapPath("../../UpLoad/UpLoadfiles/PPt");//判断上传的文件夹是否存在 不存在则创建
            if (!Directory.Exists(fpath))
                Directory.CreateDirectory(fpath);
            string filename = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            string ex = System.IO.Path.GetExtension(FileUP.get_FileName()).ToLower();
            try
            {
                FileUP.SaveAs(Server.MapPath("../../UpLoad/UpLoadfiles/PPt/") + filename + ex);
                savefilepath = "../../UpLoad/UpLoadfiles/PPt/" + filename + ex;
            }
            catch (Exception)
            {

                throw;
            }


        }
        model.UploadFileUrl = savefilepath;
        try
        {
            LN.BLL.POPLaunch bll = new LN.BLL.POPLaunch();
            bll.Add(model);
            if (model.BoolPrice == 0)
                bll.SetPOPprice(model.POPID, LanuchUserID);//如果不需要报价则将上一期报价复制到这一期。   //莫华金(2011.12.21)：sql语句有误，执行时提示“列名 'POPMaterial' 无效。”，sql语句为 “insert into popprice select  '20111221111914',supplierid,POPMaterial,POPprice,1,'','1','2011/12/21 11:20:36','1' from POPMaterialPrice”
            
            Response.Redirect("POPLaunchTwo.aspx?POPID=" + this.txt_POPID.Text.Trim());
        }
        catch (Exception)
        {

            throw;
        }
    }
    
}
