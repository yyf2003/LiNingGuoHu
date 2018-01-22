using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using LN.BLL;

public partial class FileUploadUC_UpLoadContraol : System.Web.UI.UserControl
{
    public string UserId { get; set; }
    public string FileType { get; set; }
    public string FileCode { get; set; }
    public string Code { get; set; }
    public string ItemId { get; set; }
    public string ItemTypeId { get; set; }
    public string JosnStr = string.Empty;

    Attachment attachBll = new Attachment();
    LN.Model.Attachment attachModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetFiles();
    }

    void GetFiles()
    {
        FileCode = FileCode != null ? FileCode : "0";
        
        string setItemId = string.Empty;
        if (!string.IsNullOrWhiteSpace(ItemId))
        {
            setItemId = " and ItemId='" + ItemId + "' ";
        }
        DataSet ds = null;
        ds = attachBll.GetList(string.Format(" FileCode='{0}' and FileType='{1}' and IsDelete=0 and ItemTypeId='{2}' {3}", FileCode, FileType, ItemTypeId, setItemId));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<LN.Model.Attachment> AttactList = new List<LN.Model.Attachment>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                attachModel = new LN.Model.Attachment();
                attachModel.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                attachModel.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                attachModel.ItemId = ds.Tables[0].Rows[i]["ItemId"].ToString();
                attachModel.ItemTypeId = ds.Tables[0].Rows[i]["ItemTypeId"].ToString();
                attachModel.FileCode = ds.Tables[0].Rows[i]["FileCode"].ToString();
                attachModel.FileType = ds.Tables[0].Rows[i]["FileType"].ToString();
                attachModel.SmallImgUrl = ds.Tables[0].Rows[i]["SmallImgUrl"].ToString();
                attachModel.FilePath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                AttactList.Add(attachModel);
            }
            JosnStr = JsonConvert.SerializeObject(AttactList);
        }
    }
}