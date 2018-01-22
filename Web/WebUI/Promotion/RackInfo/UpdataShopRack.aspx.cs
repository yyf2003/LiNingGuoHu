using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.UI.WebControls;
using Common;
using LN.BLL;
using System.Linq;

public partial class WebUI_Promotion_RackInfo_UpdataShopRack : System.Web.UI.Page
{
    RackInShop rackInShopBll = new RackInShop();
    LN.Model.RackInShop rackInShopModel;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["success"] != null)
        {
            int successNum = int.Parse(Request.QueryString["success"].ToString());
            int failNum = int.Parse(Request.QueryString["fail"].ToString());
            //int repeatNum = int.Parse(Request.QueryString["repeat"].ToString());
            //int newNum = int.Parse(Request.QueryString["newNum"].ToString());
            uploadMsg.Style.Add("display", "");
            labTotal.Text = (successNum + failNum).ToString();
            labuploadMsg.Text = "更新成功！";
            labSuccessNum.Text = successNum.ToString();
            labFailNum.Text = failNum.ToString();
            //labRepeatNum.Text = repeatNum.ToString();
            //labNewNum.Text = newNum.ToString();
            if (Session["uploadstate"] != null && !string.IsNullOrWhiteSpace(Session["uploadstate"].ToString()))
            {
                labErrorMsg.Text = Session["uploadstate"].ToString();
                errorMsg.Style.Add("display", "");
            }
            else
            {
                errorMsg.Style.Add("display", "none");
            }
        }
    }

    protected void Button_AddProp_Click(object sender, EventArgs e)
    {
        string excelConnString = string.Empty;
        if (ConfigurationManager.AppSettings["ExcelConnString"] != null)
            excelConnString = ConfigurationManager.AppSettings["ExcelConnString"].ToString();
        if (FileUpload1.HasFile)
        {
            DataSet excelDs = null;
            LN.Model.Attachment fileModel = new LN.Model.Attachment();
            fileModel.FileType = FileTypeEnum.Excel.ToString();
            UploadFileHelper.UpFiles(FileUpload1.PostedFile, ref fileModel);
            string path = fileModel.FilePath;
            StringBuilder errorData = new StringBuilder();
            int successNum = 0;//成功导入的数量
            int failNum = 0;//失败数量
            if (path != "")
            {
                path = Server.MapPath(path);
                excelConnString = excelConnString.Replace("ExcelPath", path);
                OleDbConnection conn;
                OleDbDataAdapter da;
                conn = new OleDbConnection(excelConnString);
                conn.Open();
                DataTable dt = conn.GetSchema("Tables");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sheetName = dt.Rows[i]["TABLE_NAME"].ToString();
                    if (sheetName.IndexOf("FilterDatabase") == -1)
                    {
                        string sql = "select * from [" + sheetName + "]";
                        //string sql = "select * from [Sheet1$]";
                        da = new OleDbDataAdapter(sql, conn);
                        excelDs = new DataSet();
                        da.Fill(excelDs);
                        da.Dispose();
                        if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
                        {
                            DataColumnCollection cols = excelDs.Tables[0].Columns;
                            Dictionary<int, string> rack = new Dictionary<int, string>();
                            for (int j = 1; j < cols.Count; j++)
                            {
                                int rackId = GetRackId(cols[j].ColumnName);
                                if (!rack.Keys.Contains(rackId))
                                {
                                    rack.Add(rackId, cols[j].ColumnName);
                                }
                            }
                            int shopId = 0;
                            int rowIndex = 0;
                            foreach (DataRow dr in excelDs.Tables[0].Rows)
                            {
                                string shopCode = dr["店铺编码"].ToString();
                                bool canPass = true;
                                if (!CheckShop(shopCode, out shopId))
                                {
                                   
                                    canPass = false;
                                    errorData.Append(string.Format("第{0}行店铺编码：{1} 不存在！<br/>", rowIndex + 1, shopCode));
                                }
                                if (canPass)
                                {
                                    foreach (KeyValuePair<int, string> item in rack)
                                    {
                                        CheckRackInShop(shopId, item.Key);
                                        string count = dr[item.Value].ToString();
                                        string realSize = string.Empty;//店铺pop的实际尺寸
                                        if (!string.IsNullOrWhiteSpace(count) && count != "0")
                                        {
                                            //如果数量不为空
                                            if (count.IndexOf(':') != -1)
                                            {
                                                realSize = count.Split(':')[0];
                                                count = count.Split(':')[1];
                                            }
                                            else if (count.Length > 3)
                                            {
                                                realSize = count;
                                                count = "1";
                                            }
                                            rackInShopModel = new LN.Model.RackInShop();
                                            rackInShopModel.PosId = shopCode;
                                            rackInShopModel.ShopId = shopId;
                                            rackInShopModel.RackId = item.Key;
                                            rackInShopModel.RackCount = int.Parse(count);
                                            rackInShopModel.Size = realSize;
                                            rackInShopBll.Add(rackInShopModel);
                                        }
                                    }
                                    successNum++;
                                }
                                else
                                {
                                    failNum++;
                                }

                            }
                        }
                    }

                }
                conn.Dispose();
                conn.Close();
                if (errorData.Length > 0)
                {
                    Session["uploadstate"] = errorData.Insert(0, "失败信息：<br/>").ToString();

                }

                Response.Redirect("UpdataShopRack.aspx?success=" + successNum + "&fail=" + failNum, false);

            }
            
        }
    }


    RackInfo rackBll = new RackInfo();

    int GetRackId(string rackCode)
    {
        DataSet ds = rackBll.GetList(string.Format(" RackCode='{0}'", rackCode));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            return int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        }
        return 0;
    }

    PromotionShopInfo shopBll = new PromotionShopInfo();
    bool CheckShop(string code, out int shopId)
    {
        shopId = 0;
        DataSet ds = shopBll.GetList(" PosID='" + code + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            shopId = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            return true;
        }
        else
            return false;
    }

    void CheckRackInShop(int shopId, int rackId)
    {
        DataSet ds = rackInShopBll.GetList(string.Format(" ShopId={0} and RackId={1}", shopId, rackId));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            int id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
            rackInShopBll.Delete(id);
        }
    }

    protected void lb_DownLoadPropTemplate_Click(object sender, EventArgs e)
    {
        string path = ConfigurationManager.AppSettings["UpdateShopRackTemplate"].ToString();
        UploadFileHelper.DownLoadFile(path);
    }
}