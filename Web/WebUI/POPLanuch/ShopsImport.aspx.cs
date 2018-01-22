using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Bestcomy.Web.Controls.Upload;
using System.Data;
public partial class WebUI_POPLanuch_ShopsImport : System.Web.UI.Page
{
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
        AspnetUpload upldr = new AspnetUpload();
        upldr.RegisterProgressBar();
        this._uploadID = upldr.get_UploadID();
        this.btnAddShops.Attributes.Add("onclick", "return  showProgressBar();" + ClientScript.GetPostBackEventReference(btnAddShops, string.Empty) + ";");
        Page.ClientScript.RegisterClientScriptInclude("prototype", "../../js/prototype-1.3.1.js");
        Page.ClientScript.RegisterClientScriptInclude("dom-drag", "../../js/dom-drag.js");
    }
    protected void btnAddShops_Click(object sender, EventArgs e)
    {
        LN.BLL.POPChangeSet bll = new LN.BLL.POPChangeSet();
        DataTable dt = new DataTable();
        string savefilepath = "";
        Bestcomy.Web.Controls.Upload.UploadFile FileUP = AspnetUpload.GetUploadFile("File1");
        if (FileUP != null)
        {
            string fpath = Server.MapPath("../../UpLoad/UpLoadfiles/Excel");//判断上传的文件夹是否存在 不存在则创建
            if (!Directory.Exists(fpath))
                Directory.CreateDirectory(fpath);
            string filename = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            string ex = System.IO.Path.GetExtension(FileUP.get_FileName()).ToLower();
            try
            {
                FileUP.SaveAs(Server.MapPath("../../UpLoad/UpLoadfiles/Excel/") + filename + ex);
                savefilepath = Server.MapPath("../../UpLoad/UpLoadfiles/Excel/") + filename + ex;
                dt = ExcelIntoTable.ReturnTable(savefilepath);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["店铺编号"].ToString().Trim() != "")
                    {
                        bll.JoinPopLanuchByPosId(dr["店铺编号"].ToString().Trim());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}