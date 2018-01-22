using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Common;
using LN.BLL;



public partial class FileUploadUC_Upload : System.Web.UI.Page
{
    public string fileType = "Others";
    string userId = "0";
    string fileCode = "0";
    string Code = "1";
    string itemId = "0";
    string itemTypeId = "0";
    Attachment attachBll = new Attachment();
    LN.Model.Attachment attactModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["filetype"] != null)
        {
            fileType = Request.QueryString["filetype"].ToString();
        }
        if (Request.QueryString["userid"] != null)
        {
            userId = Request.QueryString["userid"].ToString();
        }

        if (Request.QueryString["filecode"] != null)
        {
            fileCode = Request.QueryString["filecode"].ToString();
        }
        if (Request.QueryString["code"] != null)
        {
            Code = Request.QueryString["code"].ToString();
        }
        if (Request.QueryString["itemid"] != null)
        {
            itemId = Request.QueryString["itemid"].ToString();
        }
        if (Request.QueryString["itemtypeid"] != null)
        {
            itemTypeId = Request.QueryString["itemtypeid"].ToString();
        }
    }
    protected void btn_UpLoad_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentLength <= 30485760)//<=30m
            {

                attactModel = new LN.Model.Attachment();
                attactModel.FileType = fileType;
                attactModel.ItemId = itemId;
                attactModel.ItemTypeId = itemTypeId;
                attactModel.FileCode = fileCode;
                UploadFileHelper.UpFiles(FileUpload1.PostedFile, ref attactModel);
                attactModel.AddDate = DateTime.Now;
                attactModel.AddUserId = int.Parse(userId);
                attactModel.IsDelete = 0;
                attactModel.FileNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
                int id = attachBll.Add(attactModel);
                attactModel.Id = id;
                string jsonStr = JsonConvert.SerializeObject(attactModel);
                ClientScript.RegisterClientScriptBlock(GetType(), "callback", "callback(" + jsonStr + "," + Code + ")", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "callback", "AlertError()", true);

            }
        }
    }
}