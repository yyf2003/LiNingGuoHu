using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common;
using LN.BLL;
using NPOI;
using NPOI.SS.UserModel;
//using NPOI.HSSF.UserModel;
using System.Threading;
//using NPOI.SS.Util;
using NPOI.HSSF.UserModel;


public partial class WebUI_Promotion_handler_ExportOrder : System.Web.UI.Page
{
    int pid;
    //int sonStoryBagId;
    //int storyBagId;
    string sonStoryBagIds = string.Empty;
    string parentStoryBagIds = string.Empty;
    List<string> parentStoryBagIdList = new List<string>();
    List<string> sonStoryBagIdList = new List<string>();
    string storyBagName = string.Empty;
    //string shopLevels = string.Empty;//店铺级别，格式：id:name,id:name
    string shopLevels = string.Empty;//城市级别
    Promotion promotionBll = new Promotion();
    DataSet rackInShopDs = new DataSet();
    
    RackInShop rackInShopBll = new RackInShop();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            pid = int.Parse(Request.QueryString["pid"]);
        }
        if (Request.QueryString["parentStoryBagId"] != null)
        {
            parentStoryBagIds = Request.QueryString["parentStoryBagId"];
        }
        if (Request.QueryString["sonStoryBagId"] != null)
        {
            sonStoryBagIds = Request.QueryString["sonStoryBagId"];
        }
        if (Request.QueryString["storyBagName"] != null)
        {
            storyBagName = Request.QueryString["storyBagName"];
        }
        if (Request.QueryString["shopLevels"] != null)
        {
            shopLevels = Request.QueryString["shopLevels"];//格式：店铺类型Id:店铺类型名称:发货方式:道具Id1,具Id2$店铺类型Id:店铺类型名称:发货方式:道具Id1,具Id2
            //if (!string.IsNullOrWhiteSpace(shopLevels))
            //{
            //    shopLevels = Server.UrlDecode(shopLevels);
            //}
        }
        if (!string.IsNullOrWhiteSpace(shopLevels))
        {
            //LN.Model.PromotionSonStoryBag model = new PromotionSonStoryBag().GetModel(sonStoryBagId);
            //if (model != null)
            //{
            //    storyBagId = model.ParentStoryBagId;
            //}
            if (!string.IsNullOrWhiteSpace(sonStoryBagIds))
            {
                sonStoryBagIdList = sonStoryBagIds.Split(',').ToList();
                
            }
            else
            {
                sonStoryBagIds = "0";
            }
            if (!string.IsNullOrWhiteSpace(parentStoryBagIds))
            {
                parentStoryBagIdList = parentStoryBagIds.Split(',').ToList();
                
            }
            else
            {
                parentStoryBagIds = "0";
            }
            Export();
        }
            
    }


    void Export()
    {
        string ExcelName = "推广订单";
        LN.Model.Promotion pModel = promotionBll.GetModel(pid);
        if (pModel != null)
        {

            ExcelName = pModel.PromotionName;
        }

        //保存店铺级别id/name
        //Dictionary<Dictionary<int, string>, string> shopLevelDic = new Dictionary<Dictionary<int, string>, string>();
        Dictionary<string, string> shopLevelDic = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(shopLevels))
        {
            string[] arr = shopLevels.Split('$');
            foreach (string s in arr)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    string[] subArr = s.Split(':');
                    //Dictionary<int, string> shopLevel = new Dictionary<int, string>();
                    //shopLevel.Add(int.Parse(subArr[0]), subArr[1] + ":" + subArr[2]);
                    shopLevelDic.Add(subArr[0],subArr[1] + ":" + subArr[2]);
                }
            }
        }
       
        int sheetCount = 0;
        if (shopLevelDic.Count > 0)
        {

            //initDataTable();

            PromotionShops promotionShopBll = new PromotionShops();
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            int totalCount = 0;
            
            foreach (KeyValuePair<string, string> item in shopLevelDic)
            {
                
                //Dictionary<int, string> Levels = item.Key;

                string[] rackids = item.Value.Split(':')[1].Split(',');
                //int shopLevel =0;
                string shopLevelName = item.Key;
                string addressType = item.Value.Split(':')[0];

                //foreach (KeyValuePair<int, string> item1 in Levels)
                //{
                //    shopLevel = item1.Key;
                //    shopLevelName = item1.Value.Split(':')[0];
                //    addressType = item1.Value.Split(':')[1];
                //}
                addressType = addressType == "1" ? "到店" : "到仓";
                //UpdateExportRack(shopLevel, item.Value.TrimEnd(','));
                #region
                DataSet shops = new DataSet();
                
                //string where = " and PromotionShopInfo.ShopLevelId=" + shopLevel;
                //rackInShopDs = rackInShopBll.GetJoinList1(pid, parentStoryBagIds, shopLevel);
                rackInShopDs = rackInShopBll.GetJoinList2(pid, parentStoryBagIds);
                GetRackCount();
                //string where1 = " PromotionShops.PromotionId=" + pid + " and PromotionShopInfo.ShopLevelId=" + shopLevel;
                string where1 = " PromotionShops.PromotionId=" + pid + " and PromotionShops.ACL_ID < 4";
                if (shopLevelName=="基础店铺")
                    where1 = " PromotionShops.PromotionId=" + pid + " and (PromotionShops.ACL_ID >3 or PromotionShops.ACL_ID is null)";
                totalCount++;
                //if (totalCount == shopLevelDic.Count)
                //{
                    //where1 = "PromotionShops.PromotionId=" + pid + " and (PromotionShops.ShopLevelId=" + shopLevel + " or PromotionShops.ShopLevelId=0) ";
                    
                   
                //}
                
                shops = promotionShopBll.GetJoinList(where1);

                List<int> newRackIdList = new List<int>();

                if (shops != null && shops.Tables[0].Rows.Count > 0)
                {
                    sheetCount++;
                    NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet(shopLevelName);
                    //NPOI.HSSF.UserModel.HSSFSheet sheet1 = book.CreateSheet(shopLevelName);
                    //添加表头
                    NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
                    NPOI.SS.UserModel.IRow row2 = sheet1.CreateRow(1);
                    NPOI.SS.UserModel.IRow row3 = sheet1.CreateRow(2);
                    NPOI.SS.UserModel.IRow row4 = sheet1.CreateRow(3);
                    NPOI.SS.UserModel.IRow row5 = sheet1.CreateRow(4);
                    NPOI.SS.UserModel.IRow row6 = sheet1.CreateRow(5);
                    NPOI.SS.UserModel.IRow row7 = sheet1.CreateRow(6);
                    NPOI.SS.UserModel.IRow row8 = sheet1.CreateRow(7);
                    NPOI.SS.UserModel.IRow row9 = sheet1.CreateRow(8);
                    NPOI.SS.UserModel.IRow row10 = sheet1.CreateRow(9);
                    row1.CreateCell(0).SetCellValue("供应商");
                    row1.CreateCell(1).SetCellValue("店铺编号");
                    row1.CreateCell(2).SetCellValue("店铺名称");
                    //row1.CreateCell(3).SetCellValue("上级客户编码");
                    row1.CreateCell(3).SetCellValue("上级客户");
                    //row1.CreateCell(5).SetCellValue("直属客户编码");
                    //row1.CreateCell(6).SetCellValue("直属客户名称");
                    row1.CreateCell(4).SetCellValue("直属客户身份");

                    row1.CreateCell(5).SetCellValue("大区");

                    row1.CreateCell(6).SetCellValue("省区");
                    //row1.CreateCell(10).SetCellValue("省份");
                    //row1.CreateCell(11).SetCellValue("城市");
                    row1.CreateCell(7).SetCellValue("店铺产权关系");

                    row1.CreateCell(8).SetCellValue("店铺形象");
                    row1.CreateCell(9).SetCellValue("店铺分类名称");

                    row1.CreateCell(10).SetCellValue("收货地址（" + addressType + "）");
                    row1.CreateCell(11).SetCellValue("收货联系人");
                    row1.CreateCell(12).SetCellValue("联系电话");
                    //row1.CreateCell(14 + rackids.Length).SetCellValue("备注");
                    row1.CreateCell(13).SetCellValue("位置");
                    row2.CreateCell(13).SetCellValue("道具类型");
                    row3.CreateCell(13).SetCellValue("效果图类型");
                    row4.CreateCell(13).SetCellValue("效果图");
                    row5.CreateCell(13).SetCellValue("道具名称");
                    row6.CreateCell(13).SetCellValue("道具编码");
                    row7.CreateCell(13).SetCellValue("材质");
                    row8.CreateCell(13).SetCellValue("规格");
                    row9.CreateCell(13).SetCellValue("尺寸");
                    row10.CreateCell(13).SetCellValue("单位");
                    row4.HeightInPoints = 100;
                    sheet1.SetColumnWidth(1, 120 * 100);
                    Dictionary<string, List<string>> tableDic = new Dictionary<string, List<string>>();
                    
                    int index0 = 14;//列
                    //int tableRackId0 = 0;
                    //int tableCount = 0;
                    for (int i = 0; i < rackids.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(rackids[i]))
                        {
                            
                            int rackId = int.Parse(rackids[i]);
                            
                            string url = GetRackImgUrl(rackId);
                            
                            DataSet rackDs = new RackInfo().GetJoinList(" RackInfo.Id=" + rackId);
                            string seatName = rackDs.Tables[0].Rows[0]["seat"].ToString();
                            string rackType = rackDs.Tables[0].Rows[0]["RackType"].ToString();
                            string storyBagName = rackDs.Tables[0].Rows[0]["StoryBagName"].ToString();
                            if (seatName == "陈列桌")
                            {
                                //if (tableRackId0 == 0)
                                    //tableRackId0 = rackId;
                                rackType = rackType + "|" + rackId;
                                if (tableDic.Keys.Contains(storyBagName))
                                {
                                    List<string> typeList = tableDic[storyBagName];
                                    
                                    if (!typeList.Contains(rackType))
                                    {
                                        typeList.Add(rackType);
                                        tableDic[storyBagName] = typeList;
                                    }
                                }
                                else
                                {
                                    List<string> typeList = new List<string>();
                                    typeList.Add(rackType);
                                    tableDic.Add(storyBagName, typeList);
                                }
                                //tableCount++;
                            }
                            else
                            {
                                newRackIdList.Add(rackId);
                                row1.CreateCell(index0).SetCellValue(seatName);
                                row2.CreateCell(index0).SetCellValue(rackType);
                                row3.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["Category"].ToString());
                                AddPieChart(sheet1, book, url, 3, index0);
                                row5.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["StoryBagName"].ToString() + "-" + rackDs.Tables[0].Rows[0]["RackName"].ToString());
                                row6.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["RackCode"].ToString());
                                row7.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["Texture"].ToString());
                                row8.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["Specification"].ToString());
                                row9.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["Size"].ToString());
                                row10.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["Units"].ToString());
                                sheet1.SetColumnWidth(index0, 120 * 80);
                                index0++;
                            }
                        }
                    }
                    int tableColumnIndex = index0;
                    if (tableDic.Any())
                    {
                        
                        foreach (KeyValuePair<string, List<string>> dic in tableDic)
                        {
                            List<string> rackInfoList = dic.Value;
                            int index = 0;
                            int rid = int.Parse(rackInfoList[index].Split('|')[1]);
                            string url = GetRackImgUrl(rid);
                            string rackType = rackInfoList[index].Split('|')[0];
                            while (string.IsNullOrWhiteSpace(url))
                            {
                                index++;
                                if (index < rackInfoList.Count)
                                {
                                    string[] arr = rackInfoList[index].Split('|');
                                    if (arr.Length > 0 && !string.IsNullOrWhiteSpace(arr[1]))
                                        rid = int.Parse(arr[1]);
                                    url = GetRackImgUrl(rid);
                                    rackType = rackInfoList[index].Split('|')[0];
                                }
                            }
                            row1.CreateCell(tableColumnIndex).SetCellValue("陈列桌");
                            row2.CreateCell(tableColumnIndex).SetCellValue(rackType);
                            row3.CreateCell(tableColumnIndex).SetCellValue("");
                            AddPieChart(sheet1, book, url, 3, tableColumnIndex);
                            row5.CreateCell(tableColumnIndex).SetCellValue(dic.Key + "-陈列桌");
                            row6.CreateCell(tableColumnIndex).SetCellValue("");
                            row7.CreateCell(tableColumnIndex).SetCellValue("");
                            row8.CreateCell(tableColumnIndex).SetCellValue("");
                            row9.CreateCell(tableColumnIndex).SetCellValue("");
                            row10.CreateCell(tableColumnIndex).SetCellValue("");
                            sheet1.SetColumnWidth(tableColumnIndex, 120 * 80);
                            tableColumnIndex++;
                        }
                        
                       
                    }
                    row1.CreateCell(tableColumnIndex).SetCellValue("备注");
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 0, 0));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 1, 1));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 2, 2));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 3, 3));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 3, 3));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 5, 5));
                   //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 6, 6));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 4, 4));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 5, 5));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 6, 6));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 10, 10));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 11, 11));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 7, 7));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 8, 8));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 9, 9));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 10, 10));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 11, 11));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 12, 12));
                    //string RackCount = "";

                    

                    
                    for (int i = 0; i < shops.Tables[0].Rows.Count; i++)
                    {
                        //int provinceid = shops.Tables[0].Rows[i]["ProvinceID"].ToString() != "" ? int.Parse(shops.Tables[0].Rows[i]["ProvinceID"].ToString()) : 0;
                           
                        int shopid = int.Parse(shops.Tables[0].Rows[i]["ShopId"].ToString());
                        NPOI.SS.UserModel.IRow rowTemp = sheet1.CreateRow(i + 9);
                        rowTemp.CreateCell(0).SetCellValue(shops.Tables[0].Rows[i]["SupplierName"].ToString());
                        rowTemp.CreateCell(1).SetCellValue(shops.Tables[0].Rows[i]["PosID"].ToString());
                        rowTemp.CreateCell(2).SetCellValue(shops.Tables[0].Rows[i]["Shopname"].ToString());
                        //rowTemp.CreateCell(3).SetCellValue(shops.Tables[0].Rows[i]["DealerID"].ToString());
                        rowTemp.CreateCell(3).SetCellValue(shops.Tables[0].Rows[i]["DealerName"].ToString());
                        rowTemp.CreateCell(4).SetCellValue(shops.Tables[0].Rows[i]["FXID"].ToString());
                        //rowTemp.CreateCell(6).SetCellValue(shops.Tables[0].Rows[i]["FXName"].ToString());
                        //rowTemp.CreateCell(7).SetCellValue(shops.Tables[0].Rows[i]["CustomerCard"].ToString());
                        rowTemp.CreateCell(5).SetCellValue(shops.Tables[0].Rows[i]["BigArea"].ToString());

                        rowTemp.CreateCell(6).SetCellValue(shops.Tables[0].Rows[i]["AreaName"].ToString());
                        //rowTemp.CreateCell(10).SetCellValue(shops.Tables[0].Rows[i]["ProvinceName"].ToString());
                        //rowTemp.CreateCell(11).SetCellValue(shops.Tables[0].Rows[i]["CityName"].ToString());
                        rowTemp.CreateCell(7).SetCellValue(shops.Tables[0].Rows[i]["ShopOwnerShip"].ToString());

                        rowTemp.CreateCell(8).SetCellValue(shops.Tables[0].Rows[i]["ImageName"].ToString());
                        rowTemp.CreateCell(9).SetCellValue(shops.Tables[0].Rows[i]["ShopCategory"].ToString());

                        rowTemp.CreateCell(10).SetCellValue(shops.Tables[0].Rows[i]["PostAddress"].ToString());
                        rowTemp.CreateCell(11).SetCellValue(shops.Tables[0].Rows[i]["LinkMan"].ToString());
                        rowTemp.CreateCell(12).SetCellValue(shops.Tables[0].Rows[i]["LinkPhone"].ToString());
                        string rackName=string.Empty,rackType=string.Empty;
                        int index1 = 14;//列
                        //for (int j = 0; j < rackids.Length; j++)
                        //{
                        //    int rackId = int.Parse(rackids[j]);
                        //    string rackCount = GetRackCount(shopid, rackId, out rackName);
                        //    if (rackName != "陈列桌" && index1 < index0)
                        //    {
                        //        rowTemp.CreateCell(index1).SetCellValue(rackCount);
                        //        index1++;
                        //    }

                        //}
                        for (int j = 0; j < newRackIdList.Count; j++)
                        {
                            //string rackCount = GetRackCount(shopid, newRackIdList[j], out rackName);
                            string key = shopid + "-" + newRackIdList[j];
                            int rackCount = 0;
                            if (rackCountDic.Keys.Contains(key))
                                rackCount = rackCountDic[key];
                            if (rackCount>0)
                               rowTemp.CreateCell(index1).SetCellValue(rackCount);
                            index1++;
                        }
                        int tableColumnIndex1 = index0;
                        if (tableDic.Any())
                        {

                            foreach (KeyValuePair<string, List<string>> dic in tableDic)
                            {
                                string type = string.Empty;
                                List<string> typeList = dic.Value;
                                List<string> typeArr = new List<string>();
                                typeList.ForEach(s =>
                                {
                                    int rackid = int.Parse(s.Split('|')[1]);
                                    string type0 = s.Split('|')[0];
                                    if (!typeArr.Contains(type0))
                                       typeArr.Add(type0);
                                    string key = shopid + "-" + rackid;
                                    int rackCount = 0;
                                    if(rackCountDic.Keys.Contains(key))
                                        rackCount= rackCountDic[key];
                                    //string rackCount = GetRackCount(shopid, rackid, out rackName);
                                    if (rackCount > 0)
                                    {
                                        type = type0;
                                    }
                                });
                                rowTemp.CreateCell(tableColumnIndex1).SetCellValue(type);
                                NPOI.SS.Util.CellRangeAddressList regions = new NPOI.SS.Util.CellRangeAddressList(i + 9, i + 9, tableColumnIndex1, tableColumnIndex1);
                                DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(typeArr.ToArray());
                                HSSFDataValidation validation = new HSSFDataValidation(regions, constraint);
                                sheet1.AddValidationData(validation);
                                tableColumnIndex1++;
                            }


                        }
                        rowTemp.CreateCell(tableColumnIndex1).SetCellValue(shops.Tables[0].Rows[i]["Remark"].ToString());
                    }


                     
                }

                #endregion
            }
            //HttpContext.Current.Session["export"] = "1";
            //Thread.Sleep(3000); 
            HttpCookie cookie = Request.Cookies["export"];
            if (cookie == null)
            {
                cookie = new HttpCookie("export");
            }
            cookie.Value = "1";
            Response.Cookies.Add(cookie);
            Thread.Sleep(1000);
            if (sheetCount > 0)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                book.Write(ms);
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", System.Web.HttpUtility.UrlEncode(ExcelName+"-" + storyBagName, System.Text.Encoding.UTF8)));
                Response.BinaryWrite(ms.ToArray());
                //Response.End();
                book = null;
                ms.Close();
                ms.Dispose();
            }
            else
            {

                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "go()", true);
            }
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "go()", true);
        }
    }

    /// <summary>
    /// 获取供应商
    /// </summary>
    /// <param name="provinceId"></param>
    /// <returns></returns>
    /// 
    SupplierAssignRecord supplierAreaBll = new LN.BLL.SupplierAssignRecord();
    string GetSupplier(int provinceId)
    {
        DataTable dt = supplierAreaBll.GetSuplierByProvinceId(provinceId);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0]["ShortName"].ToString();
        }
        else
            return "";
    }



    /// <summary>
    /// 导出图片
    /// </summary>
    /// <param name="sheet"></param>
    /// <param name="workbook"></param>
    /// <param name="fileurl"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void AddPieChart(ISheet sheet, HSSFWorkbook workbook, string fileurl, int row, int col)
    {
        try
        {

            string path = Server.MapPath(fileurl);

            string FileName = path;
            byte[] bytes = System.IO.File.ReadAllBytes(FileName);
            if (!string.IsNullOrEmpty(FileName))
            {
                int pictureIdx = workbook.AddPicture(bytes, NPOI.SS.UserModel.PictureType.JPEG);
                HSSFPatriarch patriarch = (HSSFPatriarch)sheet.CreateDrawingPatriarch();
                HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 80, 70, col, row, col + 1, row + 1);
                //##处理照片位置，【图片左上角为（col, row）第row+1行col+1列，右下角为（ col +1, row +1）第 col +1+1行row +1+1列，宽为100，高为50
                HSSFPicture pict = (HSSFPicture)patriarch.CreatePicture(anchor, pictureIdx);

                // pict.Resize();这句话一定不要，这是用图片原始大小来显示
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }

    //DataView dv = new DataView();
    //DataView dv = null;
    string GetRackCount(int shopid, int rackId,out string rackName)
    {
        rackName = string.Empty;
       
        DataView dv =  rackInShopDs.Tables[0].DefaultView;
        dv.RowFilter = "ShopId=" + shopid + " and RackId=" + rackId;
        if (dv.Count > 0)
        {
            //rackType = dv[0][6].ToString();
            rackName = dv[0][7].ToString();
            if (!string.IsNullOrWhiteSpace(dv[0][4].ToString()))
            {//size
                if (dv[0][5].ToString() != "1")
                    return dv[0][4].ToString() + ":" + dv[0][5].ToString();
                else
                    return dv[0][4].ToString();
            } 
            else
                return dv[0][5].ToString();//count

        }
        else
            return "";
       
        
    }


    Dictionary<string, int> rackCountDic = new Dictionary<string, int>();
    void GetRackCount()
    {
        if (rackInShopDs != null && rackInShopDs.Tables[0].Rows.Count > 0)
        {
            string key = string.Empty;
            foreach (DataRow dr in rackInShopDs.Tables[0].Rows)
            {
                
                int shopId = int.Parse(dr["ShopId"].ToString());
                int rackId = int.Parse(dr["RackId"].ToString());
                int count = int.Parse(dr["RackCount"].ToString());
                key = shopId + "-" + rackId;
                if (rackCountDic.Keys.Contains(key))
                {
                    rackCountDic[key] = count;
                }
                else
                    rackCountDic.Add(key,count);
            }
        }
    }

    Attachment attachBll = new Attachment();
    /// <summary>
    /// 获取道具图片
    /// </summary>
    /// <param name="rackId"></param>
    /// <returns></returns>
    string GetRackImgUrl(int rackId)
    {
        string img = string.Empty;
        DataSet ds = attachBll.GetList(string.Format(" ItemTypeId={0} and ItemId={1} and FileCode=5 and (IsDelete=0 or IsDelete is null)", pid, rackId));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
           
            img = ds.Tables[0].Rows[0]["FilePath"].ToString();
        }
        return img;
    }

    /// <summary>
    /// 保存导出所选择的道具
    /// </summary>
    
    /// <param name="shopLevelId"></param>
    /// <param name="rackIds"></param>
    /// 
    ExportOrderRackBLL exportRack = new ExportOrderRackBLL();
    LN.Model.ExportOrderRack exportRackModel;
    void UpdateExportRack(int shopLevelId, string rackIds)
    {
        if (sonStoryBagIdList.Any())
        {
            exportRack.Delete1(pid, sonStoryBagIds, shopLevelId);
            if (!string.IsNullOrWhiteSpace(rackIds))
            {
                sonStoryBagIdList.ForEach(s => {
                    exportRackModel = new LN.Model.ExportOrderRack();
                    exportRackModel.PromitionId = pid;
                    exportRackModel.RackIds = rackIds;
                    exportRackModel.ShopLevelId = shopLevelId;
                    exportRackModel.StoryBagId = int.Parse(s);
                    exportRack.Add(exportRackModel);
                });
                
            }
        }
    }
}