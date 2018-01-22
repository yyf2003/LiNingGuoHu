using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.OleDb;
using System.Text;
using Common;
using LN.BLL;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class WebUI_Promotion_UpdateOrder : System.Web.UI.Page
{
    int pid;
    //int storyBagApplyId;
    string storyBagApplyIds = string.Empty;
    //int regionId;
    OrderUpdateLog logBll = new OrderUpdateLog();
    RackInShop rackInShopBll = new RackInShop();
    LN.Model.RackInShop rackInShopModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            pid = int.Parse(Request.QueryString["id"].ToString());
        }
        if (!IsPostBack)
        {
            BindStoryBag();
            //BindRegion();
            BindBigArea();
            ShowUpdateLog();
        }
        if (Request.QueryString["success"] != null)
        {
            int successNum = int.Parse(Request.QueryString["success"].ToString());
            int failNum = int.Parse(Request.QueryString["fail"].ToString());
            int repeatNum = int.Parse(Request.QueryString["repeatNum"].ToString());
            string otherMsg = string.Empty;
            //int storyBagId = 0;
            string storyBagIds = string.Empty;
            string bigArea = string.Empty;
            if (Request.QueryString["otherMsg"] != null)
            {
                otherMsg = Request.QueryString["otherMsg"];
            }
            //if (Request.QueryString["storyBagId"] != null)
            //{
            //    storyBagId = int.Parse(Request.QueryString["storyBagId"]);
            //}
            if (Request.QueryString["storyBagId"] != null)
            {
                storyBagIds = Request.QueryString["storyBagId"];
            }
            if (Request.QueryString["bigArea"] != null)
            {
                bigArea = Request.QueryString["bigArea"];
            }
            uploadMsg.Style.Add("display", "");
            //labTotal.Text = (successNum + failNum).ToString();

            labuploadMsg.Text = failNum > 0 ? "部分数据更新失败" : "更新成功！";
            //labSuccessNum.Text = successNum.ToString();
            //labFailNum.Text = failNum.ToString();
            //labRepeatNum.Text = repeatNum.ToString();
            if (Session["uploadstate"] != null && !string.IsNullOrWhiteSpace(Session["uploadstate"].ToString()))
            {

                labErrorMsg.Text = Session["uploadstate"].ToString();
                errorMsg.Style.Add("display", "");
                Session["uploadstate"] = null;
            }
            else
            {
                errorMsg.Style.Add("display", "none");
            }
            if (hfImporting.Value != "1")
            {
                if (!string.IsNullOrWhiteSpace(storyBagIds))
                {
                    //rblStoryBag.SelectedValue = storyBagId.ToString();
                    List<string> idList = storyBagIds.Split(',').ToList();
                    foreach (ListItem li in cblStoryBag.Items)
                    {
                        if (idList.Contains(li.Value))
                            li.Selected = true;
                    }
                    CheckOldData();
                }
                if (!string.IsNullOrWhiteSpace(bigArea))
                    rblRegion.SelectedValue = bigArea;
            }
            DataSet ds = logBll.GetList(string.Format(" OrderUpdateLog.PromotionId={0} and OrderUpdateLog.StoryBagId in ({1}) and OrderUpdateLog.BigArea='{2}'", pid, storyBagIds, bigArea));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Panel2.Visible = true;
                Repeater2.DataSource = ds;
                Repeater2.DataBind();
                CombineCell();
            }
            //DataSet ds1 = new RepeatShopInUpdateOrderBLL().GetList(pid, storyBagId);
            DataSet ds1 = new RepeatShopInUpdateOrderBLL().GetList1(pid, storyBagIds);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                Panel3.Visible = true;
                Repeater3.DataSource = ds1;
                Repeater3.DataBind();
            }

        }
    }


    /// <summary>
    /// 合并单元格
    /// </summary>
    void CombineCell()
    {

        for (int i = Repeater2.Items.Count - 1; i > 0; i--)
        {

            HtmlTableCell cell1 = Repeater2.Items[i - 1].FindControl("tdRegion") as HtmlTableCell;
            HtmlTableCell cell2 = Repeater2.Items[i].FindControl("tdRegion") as HtmlTableCell;
            //HtmlTableCell rowNum = Repeater1.Items[i].FindControl("RowNum") as HtmlTableCell;
            cell1.RowSpan = (cell1.RowSpan == -1) ? 1 : cell1.RowSpan;
            cell2.RowSpan = (cell2.RowSpan == -1) ? 1 : cell2.RowSpan;
            if (cell2.InnerText == cell1.InnerText)
            {
                cell2.Visible = false;
                cell1.RowSpan += cell2.RowSpan;
            }
        }
    }


    void BindStoryBag()
    {
        cblStoryBag.Items.Clear();
        DataSet ds0 = new PromotionSonStoryBag().GetList(pid);
        //rblStoryBag.DataSource = ds0;
        //rblStoryBag.DataTextField = "FullStoryBagName";
        //rblStoryBag.DataValueField = "Id";
        //rblStoryBag.DataBind();
        if (ds0 != null && ds0.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds0.Tables[0].Rows)
            {
                ListItem li = new ListItem();
                li.Value = dr["Id"].ToString();
                li.Text = dr["FullStoryBagName"].ToString();

                cblStoryBag.Items.Add(li);
            }
        }

    }

    /// <summary>
    /// 绑定分区
    /// </summary>
    void BindRegion()
    {
        DataSet ds = new DepartMentInfo().GetList(" State=1");
        rblRegion.DataSource = ds;
        rblRegion.DataTextField = "department";
        rblRegion.DataValueField = "ID";
        rblRegion.DataBind();

    }

    void BindBigArea()
    {
        DataSet ds = new PromotionShopInfo().GetList("");
        List<string> areaList = new List<string>();
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (!string.IsNullOrWhiteSpace(dr["BigArea"].ToString()) && !areaList.Contains(dr["BigArea"].ToString()))
                {
                    areaList.Add(dr["BigArea"].ToString());
                    ListItem li = new ListItem();
                    li.Text = dr["BigArea"].ToString();
                    li.Value = dr["BigArea"].ToString();
                    rblRegion.Items.Add(li);
                }
            }
        }

    }


    /// <summary>
    /// 导入
    /// </summary>
    List<string> PosIds = new List<string>();
    Dictionary<string, int> shopLevels = new Dictionary<string, int>();
    //统计每个店铺的数量，然后筛选大于1的
    Dictionary<string, int> shopNum = new Dictionary<string, int>();
    protected void Button_AddProp_Click(object sender, EventArgs e)
    {
        PosIds.Clear();
        List<int> storyBagIdList = new List<int>();
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
            int repeatNum = 0;//重复数量
            int newNum = 0;
            int regionId = 0;
            string bigArea0 = string.Empty;
            if (path != "")
            {
                //if (rblStoryBag.SelectedItem != null)
                //    storyBagApplyId = int.Parse(rblStoryBag.SelectedValue);
                StringBuilder storyBagIds = new StringBuilder();
                foreach (ListItem li in cblStoryBag.Items)
                {
                    if (li.Selected)
                    {
                        
                        storyBagIds.Append(li.Value + ",");
                        if (!storyBagIdList.Contains(int.Parse(li.Value)))
                        {
                            storyBagIdList.Add(int.Parse(li.Value));
                        }
                    }
                }
                if (storyBagIds.Length > 0)
                    storyBagApplyIds = storyBagIds.ToString().TrimEnd(',');
                if (rblRegion.SelectedItem != null)
                    bigArea0 = rblRegion.SelectedValue;
                
                path = Server.MapPath(path);
                excelConnString = excelConnString.Replace("ExcelPath", path);
                OleDbConnection conn;
                OleDbDataAdapter da;
                conn = new OleDbConnection(excelConnString);
                conn.Open();
                //DataTable dt = conn.GetSchema("Tables");
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string sheetName = string.Empty;
                int num1 = 0;
                //using (TransactionScope tran = new TransactionScope())
                //{
                try
                {
                    #region
                    //finalShopBll.DeleteByStoryBagApplyId(pid, storyBagApplyId, bigArea0);
                    PromotionStoryBag storyBagBll = new PromotionStoryBag();
                    RackInfo rackBll = new RackInfo();
                    finalShopBll.DeleteByStoryBagApplyIds(pid, storyBagApplyIds, bigArea0);
                    shopLevels.Clear();
                    StringBuilder msg1 = new StringBuilder();
                    int importIndex = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        num1 = 0;
                        int successNum1 = 0;//成功导入的数量
                        int failNum1 = 0;//失败数量
                        int repeatNum1 = 0;//重复数量
                        sheetName = dt.Rows[i]["TABLE_NAME"].ToString().TrimStart('\'').TrimEnd('\'');
                        
                        int recodeCount = 0;
                        if (sheetName.IndexOf("FilterDatabase") == -1)
                        {
                            importIndex++;
                            //sheetName = StringHelper.ReplaceSpace(sheetName);
                            //sheetName = StringHelper.ReplaceChar(sheetName,"'");
                            
                            string sql = "select * from [" + sheetName + "]";
                            int levelId = 0;
                            string shtttNameTemp = sheetName.TrimEnd('$');
                            //if (shopLevels.Keys.Contains(shtttNameTemp))
                            //{
                            //    levelId = shopLevels[shtttNameTemp];
                            //}
                            //else
                            //{
                            //    levelId = GetShopLevelId(shtttNameTemp);
                            //    if (levelId != 0)
                            //        shopLevels.Add(shtttNameTemp, levelId);
                            //}
                            da = new OleDbDataAdapter(sql, conn);
                            excelDs = new DataSet();
                            da.Fill(excelDs);
                            da.Dispose();
                            if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
                            {
                                DataColumnCollection cols = excelDs.Tables[0].Columns;
                                //Dictionary<string, int> rack = new Dictionary<string, int>();
                                Dictionary<string, Dictionary<int, int>> rack = new Dictionary<string, Dictionary<int, int>>();

                                for (int j = 14; j < cols.Count; j++)
                                {
                                    string code = excelDs.Tables[0].Rows[4][j].ToString();
                                    if (!string.IsNullOrWhiteSpace(code))
                                    {
                                        int seatid = 0;
                                        int rackId = GetRackId(code, out seatid);
                                        if (!rack.Keys.Contains(code))
                                        {
                                            Dictionary<int, int> rack1 = new Dictionary<int, int>();
                                            rack1.Add(rackId, seatid);//道具id和位置Id
                                            rack.Add(code, rack1);//
                                        }
                                    }
                                }
                                int rowIndex = 0;
                                //LN.Model.PromotionShopInfo shopModel;
                                LN.BLL.PromotionShops PromotionShopBll = new PromotionShops();
                                LN.Model.PromotionShops shopModel;
                                DataTable dt1 = excelDs.Tables[0];


                                for (int rownum = 8; rownum < dt1.Rows.Count; rownum++)
                                {
                                    num1 = rownum + 2;
                                    bool isExist = true;

                                    bool canSave = true;
                                    int shopId = 0;
                                    //string bigArea = string.Empty;
                                    int areaId = 0;
                                    int provinceId = 0;
                                    int cityId = 0;
                                    int imageId = 0;//店铺形象Id


                                    string shopCode = dt1.Rows[rownum]["店铺编号"].ToString().Trim();//PosId
                                    string bigArea = dt1.Rows[rownum]["大区"].ToString().Trim();
                                    string areaName = dt1.Rows[rownum]["省区"].ToString().Trim();
                                    //string provinceName = dt1.Rows[rownum]["省份"].ToString().Trim();
                                    //string cityName = dt1.Rows[rownum]["城市"].ToString().Trim();
                                    string imageName = dt1.Rows[rownum]["店铺形象"].ToString().Trim();
                                    string address = string.Empty;
                                    string remark = string.Empty;
                                    if (cols.Contains("收货地址（到店）"))
                                        address = dt1.Rows[rownum]["收货地址（到店）"].ToString().Trim();
                                    if (cols.Contains("收货地址（到仓）"))
                                        address = dt1.Rows[rownum]["收货地址（到仓）"].ToString().Trim();
                                    if (cols.Contains("收货地址"))
                                        address = dt1.Rows[rownum]["收货地址"].ToString().Trim();
                                    if (cols.Contains("备注"))
                                        remark = dt1.Rows[rownum]["备注"].ToString().Trim();


                                    if (!string.IsNullOrWhiteSpace(imageName) && imageName.Contains("李宁-"))
                                    {
                                        imageName = imageName.Replace("李宁-", "");
                                    }
                                    switch (imageName)
                                    {
                                        case "一代店":
                                        case "1代店":
                                        case "1代":
                                            imageName = "一代";
                                            break;
                                        case "二代店":
                                        case "2代店":
                                        case "2代":
                                            imageName = "二代";
                                            break;
                                        case "三代店":
                                        case "3代店":
                                        case "3代":
                                            imageName = "三代";
                                            break;
                                        case "四代店":
                                        case "4代店":
                                        case "4代":
                                            imageName = "四代";
                                            break;
                                        case "五代店":
                                        case "5代店":
                                        case "5代":
                                            imageName = "五代";
                                            break;
                                        case "六代店":
                                        case "6代店":
                                        case "6代":
                                            imageName = "六代";
                                            break;
                                        case "七代店":
                                        case "7代店":
                                        case "7代":
                                            imageName = "七代";
                                            break;

                                    }





                                    if (string.IsNullOrWhiteSpace(shopCode))
                                    {
                                        canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行'店铺编号'没填写！<br/>", sheetName, rownum + 2));
                                    }
                                    if (!PosIds.Contains(shopCode.ToLower()))
                                    {
                                        PosIds.Add(shopCode.ToLower());
                                    }
                                    else
                                    {
                                        canSave = false;
                                        repeatNum++;
                                        repeatNum1++;
                                        string key = shtttNameTemp.ToUpper() + "|" + shopCode.ToUpper();
                                        if (shopNum.Keys.Contains(key))
                                        {
                                            shopNum[key] = shopNum[key]+1;
                                        }
                                        else
                                        {
                                            shopNum.Add(key,1);
                                        }
                                        //errorData.Append(string.Format("工作薄{0} 中 '店铺编号'为‘{1}’出现多次！<br/>", sheetName, shopCode));
                                    }
                                    if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["店铺名称"].ToString()))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行'店铺名称'没填写！已更新<br/>", sheetName, rownum + 2));
                                    }
                                    //if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["上级客户编码"].ToString()))
                                    //{
                                    //    //canSave = false;
                                    //    errorData.Append(string.Format("工作薄{0} 中 第{1}行'上级客户编码'没填写！<br/>", sheetName, rownum + 2));
                                    //}
                                    if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["上级客户"].ToString()))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行'上级客户'没填写！已更新<br/>", sheetName, rownum + 2));
                                    }
                                    //if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["直属客户编码"].ToString()))
                                    //{
                                    //    //canSave = false;
                                    //    errorData.Append(string.Format("工作薄{0} 中 第{1}行'直属客户编码'没填写！<br/>", sheetName, rownum + 2));
                                    //}
                                    //if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["直属客户名称"].ToString()))
                                    //{
                                    //    //canSave = false;
                                    //    errorData.Append(string.Format("工作薄{0} 中 第{1}行'直属客户名称'没填写！<br/>", sheetName, rownum + 2));
                                    //}
                                    if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["直属客户身份"].ToString()))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行'直属客户身份'没填写！已更新<br/>", sheetName, rownum + 2));
                                    }
                                    if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["省区"].ToString()))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行'省区'没填写！已更新<br/>", sheetName, rownum + 2));
                                    }
                                    //if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["省份"].ToString()))
                                    //{
                                    //    //canSave = false;
                                    //    errorData.Append(string.Format("工作薄{0} 中 第{1}行'省份'没填写！<br/>", sheetName, rownum + 2));
                                    //}
                                    //if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["城市"].ToString()))
                                    //{
                                    //    //canSave = false;
                                    //    //errorData.Append(string.Format("工作薄{0} 中 第{1}行'城市'没填写！<br/>", sheetName, rownum + 2));
                                    //}
                                    if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["店铺产权关系"].ToString()))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行'店铺产权关系'没填写！已更新<br/>", sheetName, rownum + 2));
                                    }
                                    if (string.IsNullOrWhiteSpace(dt1.Rows[rownum]["店铺形象"].ToString()))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行'店铺形象'没填写！已更新<br/>", sheetName, rownum + 2));
                                    }

                                    if (!CheckShop(shopCode, out shopId))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行的 店铺编码{2} 不存在！<br/>", sheetName, rownum + 2, shopCode));
                                        isExist = false;
                                    }
                                    if (!string.IsNullOrWhiteSpace(areaName) && !CheckArea(areaName, out areaId))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行省区{2} 不正确！已更新<br/>", sheetName, rownum + 2, areaName));
                                    }
                                    //if (!string.IsNullOrWhiteSpace(provinceName) && !CheckProvince(provinceName, out provinceId))
                                    //{
                                    //    //canSave = false;
                                    //    errorData.Append(string.Format("工作薄{0} 中 第{1}行省份{2} 不正确！<br/>", sheetName, rownum + 2, provinceName));
                                    //}
                                    //if (!string.IsNullOrWhiteSpace(cityName) && !CheckCity(cityName, out cityId))
                                    //{
                                    //    //canSave = false;
                                    //    //errorData.Append(string.Format("工作薄{0} 中 第{1}行城市{2} 不正确！<br/>", sheetName, rownum + 2, cityName));
                                    //}
                                    if (!string.IsNullOrWhiteSpace(imageName) && !CheckShopImage(imageName, out imageId))
                                    {
                                        //canSave = false;
                                        errorData.Append(string.Format("工作薄{0} 中 第{1}行店铺形象{2} 不正确！已更新<br/>", sheetName, rownum + 2, imageName));
                                    }
                                    if (!cbRackCountIsOk.Checked)
                                    {
                                        //检查道具数量

                                        //foreach (KeyValuePair<int, string> item in rack)
                                        //{
                                        //    if (dt1.Rows[rownum][item.Value].ToString().Length > 3)
                                        //    {
                                        //        errorCount++;
                                        //    }
                                        //}

                                        StringBuilder outLimitCode = new StringBuilder();

                                        for (int j = 14; j < cols.Count; j++)
                                        {
                                            //string rackCode = dt1.Rows[4][j].ToString();
                                            string rackName = dt1.Columns[j].ColumnName;
                                            string rackCode = dt1.Rows[4][j].ToString();
                                            string count = dt1.Rows[rownum][j].ToString();
                                            //if (rackName == "陈列桌")
                                            //{
                                            //    //数量单元格里面的 陈列桌 类型
                                            //    string tabelType = dt1.Rows[rownum][j].ToString();
                                            //    string storyBagName = dt1.Rows[3][j].ToString();
                                            //    if (!string.IsNullOrWhiteSpace(storyBagName))
                                            //        storyBagName = storyBagName.Split('-')[0];
                                            //    DataSet sbDs = storyBagBll.GetList(string.Format(" StoryBagName='{0}'", storyBagName));
                                            //    if (sbDs != null && sbDs.Tables[0].Rows.Count > 0)
                                            //    {
                                            //        int storyBagId = int.Parse(sbDs.Tables[0].Rows[0]["Id"].ToString());
                                            //        DataSet rackDs = rackBll.GetJoinList(string.Format(" RackInfo.StoryBagId={0} and RackInfo.RackType='{1}' and POPSeat.seat='{2}'", storyBagId, tabelType, rackName));
                                            //        if (rackDs != null && rackDs.Tables[0].Rows.Count > 0)
                                            //        {
                                            //            rackCode = rackDs.Tables[0].Rows[0]["RackCode"].ToString();
                                            //        }
                                            //    }
                                            //    count = "1";
                                            //}
                                            if (!string.IsNullOrWhiteSpace(rackCode) && !rackName.Contains("陈列桌"))
                                            {

                                                int seatid = 0;
                                                if (rack.Keys.Contains(rackCode))
                                                {
                                                    Dictionary<int, int> rack1 = rack[rackCode];
                                                    foreach (KeyValuePair<int, int> rack1_item in rack1)
                                                    {

                                                        seatid = rack1_item.Value;
                                                    }
                                                }
                                                
                                                if (!string.IsNullOrWhiteSpace(count) && count != "0" && StringHelper.IsInt(count))
                                                {
                                                    int limitcount = 0;
                                                    //if (!CheckRackCountLimit(levelId, seatid, int.Parse(count), out limitcount))
                                                    //{
                                                    //    outLimitCode.Append(rackCode + "，");
                                                    //}
                                                    if (!CheckRackCountLimitNew(shtttNameTemp, seatid, int.Parse(count), out limitcount))
                                                    {
                                                        outLimitCode.Append(rackCode + "，");
                                                    }

                                                }
                                            }
                                        }
                                        if (outLimitCode.Length > 0)
                                        {
                                            //canSave = false;
                                            errorData.Append(string.Format("<span style='color:red;'>工作薄{0} 中 第{1}行中道具编号‘{2}’数量超出上限 需要确认！</span><br/>", sheetName, rownum + 2, outLimitCode.ToString()));
                                        }
                                    }

                                    if (canSave)
                                    {
                                        shopModel = new LN.Model.PromotionShops();
                                        shopModel.BigArea = bigArea;
                                        if (areaId > 0)
                                            shopModel.AreaId = areaId;
                                        if (provinceId > 0)
                                            shopModel.ProvinceId = provinceId;
                                        if (cityId > 0)
                                            shopModel.CityId = cityId;
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["直属客户身份"].ToString()))
                                            shopModel.CustomerCard = dt1.Rows[rownum]["直属客户身份"].ToString();
                                        //if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["上级客户编码"].ToString()))
                                            //shopModel.DealerID = dt1.Rows[rownum]["上级客户编码"].ToString();
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["上级客户"].ToString()))
                                            shopModel.DealerName = dt1.Rows[rownum]["上级客户"].ToString();
                                        //if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["直属客户编码"].ToString()))
                                            //shopModel.FXID = dt1.Rows[rownum]["直属客户编码"].ToString();
                                        //if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["直属客户名称"].ToString()))
                                            //shopModel.FXName = dt1.Rows[rownum]["直属客户名称"].ToString();
                                        //if (levelId > 0)
                                        //    shopModel.ShopLevelId = levelId;
                                        if (imageId > 0)
                                            shopModel.ShopImageId = imageId;
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["店铺名称"].ToString()))
                                            shopModel.Shopname = dt1.Rows[rownum]["店铺名称"].ToString();
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["店铺产权关系"].ToString()))
                                            shopModel.ShopOwnerShip = dt1.Rows[rownum]["店铺产权关系"].ToString();
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["店铺名称"].ToString()))
                                            shopModel.Shopsamplename = dt1.Rows[rownum]["店铺名称"].ToString();
                                        if (!string.IsNullOrWhiteSpace(address))
                                            shopModel.PostAddress = address;
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["收货联系人"].ToString()))
                                            shopModel.LinkMan = dt1.Rows[rownum]["收货联系人"].ToString();
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["联系电话"].ToString()))
                                            shopModel.LinkPhone = dt1.Rows[rownum]["联系电话"].ToString();
                                        if (!string.IsNullOrWhiteSpace(dt1.Rows[rownum]["备注"].ToString()))
                                            shopModel.Remark = dt1.Rows[rownum]["备注"].ToString();
                                        if (!isExist)
                                        {
                                            //系统不存在的店铺，
                                            //shopModel.PosID = shopCode;
                                            //shopModel.PromotionId = pid;
                                            //shopId = PromotionShopBll.Add(shopModel);
                                            //newNum++;
                                            errorData.Append(string.Format("工作薄{0} 中 第{1}行的 店铺编码{2}不存在<br/>", sheetName, rownum + 2, shopCode));
                                        }
                                        else
                                        {
                                            shopModel.ShopId = shopId;
                                            shopModel.PromotionId = pid;
                                            PromotionShopBll.Update(shopModel);
                                        }
                                        successNum++;
                                        successNum1++;
                                        //往FinalPromotionShops插入数据
                                        int fid = 0;
                                        storyBagIdList.ForEach(s => {
                                            if (!IsExists1(shopId, bigArea0,s, out fid))
                                            {
                                                finalShopModel = new LN.Model.FinalPromotionShops();
                                                finalShopModel.PromotionId = pid;
                                                finalShopModel.ShopId = shopId;
                                                //finalShopModel.StoryBagApplyId = storyBagApplyId;
                                                finalShopModel.StoryBagApplyId = s;
                                                finalShopModel.Remark = remark;
                                                finalShopModel.AreaId = regionId;
                                                finalShopModel.BigArea = bigArea0;
                                                finalShopBll.Add(finalShopModel);

                                            }
                                            else
                                            {
                                                finalShopModel = new LN.Model.FinalPromotionShops();
                                                finalShopModel.Id = fid;
                                                finalShopModel.IsDelete = 0;
                                                finalShopModel.AreaId = regionId;
                                                finalShopModel.Remark = remark;
                                                finalShopModel.BigArea = bigArea0;
                                                finalShopBll.Update(finalShopModel);
                                            }
                                        });
                                        

                                        //更新店铺道具数量
                                        for (int j = 14; j < cols.Count; j++)
                                        {
                                            string rackName = dt1.Columns[j].ColumnName;
                                            
                                            if (rackName.Contains("陈列桌"))
                                            {
                                                string tabelType = dt1.Rows[rownum][j].ToString();
                                                if (!string.IsNullOrWhiteSpace(tabelType))
                                                {
                                                    string storyBagName = dt1.Rows[3][j].ToString();
                                                    if (!string.IsNullOrWhiteSpace(storyBagName))
                                                        storyBagName = storyBagName.Split('-')[0];
                                                    DataSet sbDs = storyBagBll.GetList(string.Format(" StoryBagName='{0}'", storyBagName));
                                                    if (sbDs != null && sbDs.Tables[0].Rows.Count > 0)
                                                    {
                                                        int storyBagId = int.Parse(sbDs.Tables[0].Rows[0]["Id"].ToString());
                                                        DataSet rackDs = rackBll.GetJoinList(string.Format(" RackInfo.StoryBagId={0} and RackInfo.RackType='{1}' and POPSeat.seat='陈列桌'", storyBagId, tabelType));
                                                        if (rackDs != null && rackDs.Tables[0].Rows.Count > 0)
                                                        {
                                                            int rackId = int.Parse(rackDs.Tables[0].Rows[0]["Id"].ToString());

                                                            DeleteTableRack(shopId, storyBagId);
                                                            rackInShopModel = new LN.Model.RackInShop();
                                                            rackInShopModel.PosId = shopCode;
                                                            rackInShopModel.ShopId = shopId;
                                                            rackInShopModel.RackId = rackId;
                                                            rackInShopModel.RackCount = 1;
                                                            rackInShopModel.Size = "";
                                                            rackInShopModel.StoryBagId = storyBagId;
                                                            rackInShopBll.Add(rackInShopModel);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                string rackCode = dt1.Rows[4][j].ToString();
                                                if (!string.IsNullOrWhiteSpace(rackCode))
                                                {
                                                    //int rackid = rack.Keys.Contains(rackCode) ? rack[rackCode] : 0;
                                                    int rackid = 0;
                                                    int seatId = 0;
                                                    if (rack.Keys.Contains(rackCode))
                                                    {
                                                        Dictionary<int, int> rack1 = rack[rackCode];
                                                        foreach (KeyValuePair<int, int> rack1_item in rack1)
                                                        {
                                                            rackid = rack1_item.Key;
                                                            seatId = rack1_item.Value;
                                                        }
                                                    }
                                                    string count = dt1.Rows[rownum][j].ToString();
                                                    CheckRackInShop(shopId, rackid);
                                                    if (!string.IsNullOrWhiteSpace(count) && count != "0")
                                                    {
                                                        string realSize = string.Empty;
                                                        //如果数量不为空
                                                        if (count.IndexOf(':') != -1)
                                                        {
                                                            realSize = count.Split(':')[0];
                                                            count = count.Split(':')[1];
                                                        }

                                                        int limitcount = 0;
                                                        //if (!CheckRackCountLimit(levelId, seatId, int.Parse(count), out limitcount))
                                                        //{
                                                            
                                                        //    count = limitcount.ToString();
                                                        //}
                                                        if (!CheckRackCountLimitNew(shtttNameTemp, seatId, int.Parse(count), out limitcount))
                                                        {
                                                            count = limitcount.ToString();
                                                        }
                                                        rackInShopModel = new LN.Model.RackInShop();
                                                        rackInShopModel.PosId = shopCode;
                                                        rackInShopModel.ShopId = shopId;
                                                        rackInShopModel.RackId = rackid;
                                                        rackInShopModel.RackCount = int.Parse(count);
                                                        rackInShopModel.Size = realSize;
                                                        rackInShopBll.Add(rackInShopModel);
                                                    }
                                                }
                                            }
                                        }
                                        recodeCount++;
                                    }
                                    else
                                    {
                                        failNum++;
                                        failNum1++;
                                    }

                                    rowIndex++;
                                }
                                storyBagIdList.ForEach(s =>
                                {


                                    if (importIndex == 1)
                                    {
                                        //logBll.delete(pid, int.Parse(rblStoryBag.SelectedValue), bigArea0);
                                        logBll.delete(pid, s, bigArea0);
                                    }
                                    LN.Model.OrderUpdateLog log = new LN.Model.OrderUpdateLog();
                                    log.FailNum = failNum1;
                                    log.PromotionId = pid;
                                    log.Region = rblRegion.SelectedItem.Text;
                                    log.RegionId = regionId;
                                    log.RepeatNum = repeatNum1;

                                    log.ShopLevel = shtttNameTemp;
                                    //log.StoryBagId = int.Parse(rblStoryBag.SelectedValue);
                                    log.StoryBagId = s;
                                    log.SuccessNum = successNum1;
                                    log.TotalRecord = successNum1 + failNum1;
                                    log.BigArea = bigArea0;
                                    logBll.Add(log);
                                });
                            }
                           
                        }

                    }
                   
                    if (errorData.Length > 0)
                    {
                        Session["uploadstate"] = errorData.Insert(0, "失败信息：<br/>").ToString();
                       
                    }
                    else
                    {
                        
                    }
                    Response.Redirect("UpdateOrder.aspx?id=" + pid + "&success=" + successNum + "&fail=" + failNum + "&newNum=" + newNum + "&repeatNum=" + repeatNum + "&storyBagId=" + storyBagApplyIds + "&bigArea=" + bigArea0, false);
                    #endregion
                }
                catch (Exception ex)
                {
                    errorMsg.Style.Add("display", "");
                    labErrorMsg.Text = string.Format("导入失败：{0}:{1}行" + ex.Message, sheetName, num1);

                }
                finally
                {
                    conn.Dispose();
                    conn.Close();
                    //tran.Dispose();
                    hfImporting.Value = "";
                    RepeatShopInUpdateOrderBLL repeatBll = new RepeatShopInUpdateOrderBLL();
                    LN.Model.RepeatShopInUpdateOrder repeatModel;
                    storyBagIdList.ForEach(s => {
                        repeatBll.Delete(pid, s);
                        if (shopNum.Keys.Count > 0)
                        {
                            foreach (KeyValuePair<string, int> item in shopNum)
                            {
                                string shoplevel = item.Key.Split('|')[0];
                                string shopNo = item.Key.Split('|')[1];
                                int num = item.Value;
                                repeatModel = new LN.Model.RepeatShopInUpdateOrder();
                                repeatModel.PromitionId = pid;
                                repeatModel.RepeatNum = num;
                                repeatModel.ShopLevel = shoplevel;
                                repeatModel.ShopNo = shopNo;
                                repeatModel.StoryBagId = s;
                                repeatModel.BigArea = rblRegion.SelectedValue;
                                repeatBll.Add(repeatModel);
                            }
                        }
                    });
                    
                }

                //}



            }
        }
    }

    /// <summary>
    /// 获取店铺级别ID
    /// </summary>
    /// <param name="levelName"></param>
    /// <returns></returns>
    int GetShopLevelId(string levelName)
    {
        int levelId = 0;
        DataSet ds = new PromotionShopLevel().GetList(string.Format(" ShortName='{0}'", levelName));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            levelId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        }
        return levelId;
    }


    RackInfo rackBll = new RackInfo();

    int GetRackId(string rackCode, out int seatid)
    {
        DataSet ds = rackBll.GetList(string.Format(" RackCode='{0}'", rackCode));
        seatid = 0;
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            seatid = int.Parse(ds.Tables[0].Rows[0]["PositionId"].ToString());
            return int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        }
        return 0;
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


    void DeleteTableRack(int shopId, int storyBagId)
    {
        string whereStr = string.Format(" ShopId={0} and RackId in(select RackInfo.id from RackInfo join POPSeat on POPSeat.SeatID=RackInfo.PositionId where POPSeat.seat='陈列桌' and RackInfo.StoryBagId={1})", shopId, storyBagId);
        rackInShopBll.Delete(whereStr);
    }

    PromotionShops shopBll = new PromotionShops();
    bool CheckShop(string posid, out int shopId)
    {
        shopId = 0;
        DataSet ds = shopBll.GetList(" PromotionId=" + pid + " and PosID='" + posid + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            shopId = int.Parse(ds.Tables[0].Rows[0]["ShopId"].ToString());
            return true;
        }
        else
            return false;
    }

    FinalPromotionShops finalShopBll = new FinalPromotionShops();
    LN.Model.FinalPromotionShops finalShopModel;
    DataSet finalShopDs = null;
    //bool IsExists(int shopId, string bigArea, out int fid)
    //{
    //    fid = 0;
    //    finalShopDs = null;
    //    finalShopDs = finalShopBll.GetList(string.Format(" PromotionId={0} and StoryBagApplyId in({1}) and BigArea='{2}'  and ShopId={3}", pid, storyBagApplyIds, bigArea, shopId));
    //    if (finalShopDs != null && finalShopDs.Tables[0].Rows.Count > 0)
    //    {
    //        fid = int.Parse(finalShopDs.Tables[0].Rows[0]["Id"].ToString());
    //        return true;
    //    }
    //    else
    //        return false;
    //}

    bool IsExists1(int shopId, string bigArea,int storyBagId, out int fid)
    {
        fid = 0;
        finalShopDs = null;
        finalShopDs = finalShopBll.GetList(string.Format(" PromotionId={0} and StoryBagApplyId ={1} and BigArea='{2}'  and ShopId={3}", pid, storyBagId, bigArea, shopId));
        if (finalShopDs != null && finalShopDs.Tables[0].Rows.Count > 0)
        {
            fid = int.Parse(finalShopDs.Tables[0].Rows[0]["Id"].ToString());
            return true;
        }
        else
            return false;
    }


    DepartMentInfo areaBll = new DepartMentInfo();
    bool CheckArea(string name, out int areaId)
    {
        bool flag = false;
        areaId = 0;
        DataSet list = areaBll.GetList(" department='" + name + "'");
        if (list != null && list.Tables[0].Rows.Count > 0)
        {
            flag = true;
            areaId = int.Parse(list.Tables[0].Rows[0]["ID"].ToString());
        }
        return flag;
    }


    ProvinceData provinceBll = new ProvinceData();
    bool CheckProvince(string name, out int provinceId)
    {
        bool flag = false;
        provinceId = 0;
        IList<LN.Model.ProvinceData> list = provinceBll.GetList(" ProvinceName='" + name + "' and State=1");
        if (list.Count > 0)
        {
            flag = true;
            provinceId = list[0].ProvinceID;

        }
        return flag;
    }

    CityData cityBll = new CityData();
    bool CheckCity(string name, out int cityId)
    {
        bool flag = false;
        cityId = 0;
        DataTable dt = cityBll.GetCityList(string.Format(" CityName='{0}'", name));
        if (dt != null && dt.Rows.Count > 0)
        {
            flag = true;
            cityId = int.Parse(dt.Rows[0]["CItyID"].ToString());
        }
        return flag;
    }

    PromotionShopImage imageBll = new PromotionShopImage();
    bool CheckShopImage(string name, out int imageId)
    {
        bool flag = false;
        imageId = 0;
        DataSet ds = imageBll.GetList(string.Format(" ImageName='{0}'", name));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
            imageId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        }
        return flag;
    }

    protected void lb_DownLoadPropTemplate_Click(object sender, EventArgs e)
    {
        string path = ConfigurationManager.AppSettings["UpdateOrderTemplate"].ToString();
        UploadFileHelper.DownLoadFile(path);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionList.aspx", false);
    }

    /// <summary>
    /// 添加更新记录
    /// </summary>
    /// <param name="promotionId"></param>
    /// <param name="storyBagId"></param>
    /// <param name="areaId"></param>
    /// <param name="msg"></param>
    /// 
    UpdateOrderLogBLL updatelogBll = new UpdateOrderLogBLL();
    void AddUpdateLog(int promotionId, int storyBagId, int areaId, string msg)
    {

        LN.Model.UpdateOrderLog logModel;
        DataSet ds = updatelogBll.GetList(string.Format(" UpdateOrderLog.PromotionId={0} and UpdateOrderLog.StoryBagId={1} and UpdateOrderLog.AreaId={2}", promotionId, storyBagId, areaId));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            logModel = new LN.Model.UpdateOrderLog();
            logModel.UpdateMsg = msg;
            logModel.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
            updatelogBll.Update(logModel);
        }
        else
        {
            logModel = new LN.Model.UpdateOrderLog();
            logModel.AreaId = areaId;
            logModel.PromotionId = promotionId;
            logModel.StoryBagId = storyBagId;
            logModel.UpdateMsg = msg;
            updatelogBll.Add(logModel);
        }
    }
    protected void rblStoryBag_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckOldData();
        //ShowUpdateLog();
    }

    /// <summary>
    /// 显示更新记录
    /// </summary>
    void ShowUpdateLog()
    {
        //if (rblStoryBag.SelectedItem != null)
        //{
        //    int sbId = int.Parse(rblStoryBag.SelectedValue);
        //    DataSet ds = updatelogBll.GetList(string.Format(" UpdateOrderLog.PromotionId={0} and UpdateOrderLog.StoryBagId={1}", pid, sbId));
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        Repeater1.DataSource = ds;
        //        Repeater1.DataBind();
        //        Panel1.Visible = true;
        //    }
        //    else
        //        Panel1.Visible = false;
        //}

    }

    /// <summary>
    /// 检查道具数量是否超过上限
    /// </summary>
    /// <param name="shopLevelId"></param>
    /// <param name="seatId"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    /// 
    Dictionary<string, int> limitDic = new Dictionary<string, int>();
    bool CheckRackCountLimit(int shopLevelId, int seatId, int count, out int outlimitCount)
    {
        bool flag = true;
        outlimitCount = 0;
        string key = shopLevelId + "-" + seatId;
        if (!limitDic.Keys.Contains(key))
        {
            RackLimitCountBLL limitBll = new RackLimitCountBLL();
            LN.Model.RackLimitCount limitModel = limitBll.GetModel(string.Format(" ShopLevelId={0} and RackSeatId={1}", shopLevelId, seatId));
            if (limitModel != null)
            {
                int limitCount = limitModel.Count ?? 0;
                limitDic.Add(key, limitCount);
            }
        }
        if (limitDic.Keys.Contains(key))
        {
            int limitCount = limitDic[key];
            if (limitCount > 0)
            {
                outlimitCount = limitCount;
                flag = limitCount >= count;
            }
        }
        return flag;
    }

    bool CheckRackCountLimitNew(string shopType, int seatId, int count, out int outlimitCount)
    {
        bool flag = true;
        outlimitCount = 0;
        string key = shopType + "-" + seatId;
        if (!limitDic.Keys.Contains(key))
        {
            RackLimitCountBLL limitBll = new RackLimitCountBLL();
            LN.Model.RackLimitCount limitModel = limitBll.GetModel(string.Format(" ShopType='{0}' and RackSeatId={1}", shopType, seatId));
            if (limitModel != null)
            {
                int limitCount = limitModel.Count ?? 0;
                limitDic.Add(key, limitCount);
            }
        }
        if (limitDic.Keys.Contains(key))
        {
            int limitCount = limitDic[key];
            if (limitCount > 0)
            {
                outlimitCount = limitCount;
                flag = limitCount >= count;
            }
        }
        return flag;
    }

    /// <summary>
    /// 检查是否存在历史数据
    /// </summary>
    void CheckOldData()
    {
        //int storyBagId = 0;
        //if (rblStoryBag.SelectedValue != "")
        //{
        //    storyBagId = int.Parse(rblStoryBag.SelectedValue);
        //}
        StringBuilder sbIds = new StringBuilder();
        foreach (ListItem li in cblStoryBag.Items)
        {
            if (li.Selected)
                sbIds.Append(li.Value + ",");
        }
        string ids ="0";
        hfStoryBag.Value = "";
        if(sbIds.Length > 0)
        {
            hfStoryBag.Value= ids = sbIds.ToString().TrimEnd(',');
        }
        DataSet ds = new LN.BLL.FinalPromotionShops().GetList(string.Format(" PromotionId={0} and StoryBagApplyId in({1})", pid, ids));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "存在历史数据";
            Label1.ForeColor = System.Drawing.Color.Red;
            btnClearData.Enabled = true;
        }
        else
        {
            btnClearData.Enabled = false;
            Label1.ForeColor = System.Drawing.Color.Blue;

            Label1.Text = "无历史数据";
        }
    }
    protected void btnClearData_Click1(object sender, EventArgs e)
    {
        //int storyBagId = 0;
        //if (rblStoryBag.SelectedValue != "")
        //{
        //    storyBagId = int.Parse(rblStoryBag.SelectedValue);
        //}
        StringBuilder sbIds = new StringBuilder();
        foreach (ListItem li in cblStoryBag.Items)
        {
            if (li.Selected)
                sbIds.Append(li.Value + ",");
        }
        string ids = sbIds.Length > 0 ? sbIds.ToString().TrimEnd(',') : "0";
        new LN.BLL.FinalPromotionShops().Delete(string.Format(" PromotionId={0} and StoryBagApplyId in({1})", pid, ids));
        CheckOldData();
    }

    protected void cblStoryBag_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckOldData();
       
    }
}