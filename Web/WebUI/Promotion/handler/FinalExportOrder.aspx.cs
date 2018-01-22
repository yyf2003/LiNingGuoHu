using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common;
using LN.BLL;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Threading;


public partial class WebUI_Promotion_handler_FinalExportOrder : System.Web.UI.Page
{
    int pid;
    int supplierId;
    string supplierName = string.Empty;
    int regionId;
    string regionName = string.Empty;
    //int sonStoryBagId;
    string sonStoryBagIds = string.Empty;
    string parentStoryBagIds = string.Empty;
    string storyBagName = string.Empty;
    //string shopLevels = string.Empty;//店铺级别，格式：id:name,id:name
    string shopLevels = string.Empty;//城市级别
    string isExportRackMoney = "0";
    Promotion promotionBll = new Promotion();
    DataSet rackInShopDs = new DataSet();
    RackInShop rackInShopBll = new RackInShop();
    FinalPromotionShops finalPromotionShopBll = new FinalPromotionShops();
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
        }
        
        if (Request.QueryString["regionName"] != null)
        {
            regionName = Request.QueryString["regionName"];
        }
        if (Request.QueryString["supplierId"] != null)
        {
            supplierId = int.Parse(Request.QueryString["supplierId"]);
        }
        if (Request.QueryString["supplierName"] != null)
        {
            supplierName = Request.QueryString["supplierName"];
        }
        if (Request.QueryString["isExportRackMoney"] != null)
        {
            isExportRackMoney = Request.QueryString["isExportRackMoney"];
        }
        Export();
    }


    void Export()
    {
        string ExcelName = "推广订单";
        LN.Model.Promotion pModel = promotionBll.GetModel(pid);
        if (pModel != null)
        {
            ExcelName = pModel.PromotionName;
        }
        //int parentStoryBagId = 0;
        //LN.Model.PromotionSonStoryBag model = new PromotionSonStoryBag().GetModel(sonStoryBagId);
        //if (model != null)
        //{
        //    parentStoryBagId = model.ParentStoryBagId;

        //}
        string lastName = string.Empty;
        if (!string.IsNullOrWhiteSpace(regionName))
        {
            lastName = "-" + regionName;
        }

        //如果按供应商导出，先获取供应商负责的店
        System.Text.StringBuilder supplierShopIds = new System.Text.StringBuilder();
        if (supplierId > 0)
        {
            DataSet ds = new SupplierArea().GetAreaBySupplierId(supplierId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["ProvinceId"].ToString() != "0")
                    {
                        DataSet ds1 = finalPromotionShopBll.GetJoinShopList(string.Format(" PromotionShops.PromotionId={0} and PromotionShops.areaid={1} and PromotionShops.ProvinceID={2} ",pid, dr["DepartmentId"].ToString(), dr["ProvinceId"].ToString()));
                        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            {
                                supplierShopIds.Append(dr1["ShopId"] + ",");
                            }
                        }
                    }
                    else
                    {
                        DataSet ds1 = finalPromotionShopBll.GetJoinShopList(string.Format(" PromotionShops.PromotionId={0} and  PromotionShops.areaid={1} ",pid, dr["DepartmentId"].ToString()));
                        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            {
                                supplierShopIds.Append(dr1["ShopId"] + ",");
                            }
                        }
                    }
                }
            }
            if (supplierShopIds.Length == 0)
                supplierShopIds.Append("0,");
            lastName += "-" + supplierName;
        }
        //保存店铺级别id/name:将shopLevels字符串拆分后保存到字典
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
                    //shopLevelDic.Add(shopLevel, subArr[3]);
                    shopLevelDic.Add(subArr[0], subArr[1] + ":" + subArr[2]);
                }
            }
        }

        int sheetCount = 0;
        if (shopLevelDic.Count > 0)
        {

            //initDataTable();


            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            foreach (KeyValuePair<string, string> item in shopLevelDic)
            {

                //Dictionary<int, string> Levels = item.Key;
                //string[] rackids = item.Value.Split(',');
                List<int> newRackIdList = new List<int>();
                //int shopLevel = 0;
                //string shopLevelName = string.Empty;
                //string addressType = string.Empty;
                //foreach (KeyValuePair<int, string> item1 in Levels)
                //{
                //    shopLevel = item1.Key;
                //    shopLevelName = item1.Value.Split(':')[0];
                //    addressType = item1.Value.Split(':')[1];
                //}
                string[] rackids = item.Value.Split(':')[1].Split(',');
               
                string shopLevelName = item.Key;
                string addressType = item.Value.Split(':')[0];
                addressType = addressType == "1" ? "到店" : "到仓";
                #region
                DataSet shops = new DataSet();

                //string where = " and PromotionShops.ShopLevelId=" + shopLevel;

                string where = " and PromotionShops.ACL_ID < 4";
                if (shopLevelName == "基础店铺")
                    where = "and (PromotionShops.ACL_ID >3 or PromotionShops.ACL_ID is null)";


                rackInShopDs = rackInShopBll.GetFinalRackList1(pid, parentStoryBagIds, where);
                GetRackCount();
                System.Text.StringBuilder whereStr = new System.Text.StringBuilder();
                int sonStoryBagId = 0;
                if (!string.IsNullOrWhiteSpace(sonStoryBagIds))
                    sonStoryBagId = int.Parse(sonStoryBagIds.Split(',')[0]);
                if (shopLevelName == "重点店铺")
                whereStr.Append(string.Format(" FinalPromotionShops.PromotionId={0} and PromotionShops.PromotionId={0} and FinalPromotionShops.StoryBagApplyId ={1} and PromotionShops.ACL_ID < 4", pid, sonStoryBagId));
                else
                    whereStr.Append(string.Format(" FinalPromotionShops.PromotionId={0} and PromotionShops.PromotionId={0} and FinalPromotionShops.StoryBagApplyId ={1} and (PromotionShops.ACL_ID >3 or PromotionShops.ACL_ID is null)", pid, sonStoryBagId));
                if (!string.IsNullOrWhiteSpace(regionName))
                {
                    //if (regionName == "-1")
                    //{
                    //    whereStr.Append(" and PromotionShopInfo.BigArea in('南中国区','北中国区')");
                    //}
                    //else
                    whereStr.Append(string.Format(" and PromotionShops.BigArea ='{0}'", regionName));
                }
                if (supplierId > 0)
                {
                    whereStr.Append(string.Format(" and PromotionShops.ShopId in({0})", supplierShopIds.ToString().TrimEnd(',')));
                }
                shops = finalPromotionShopBll.GetJoinList(whereStr.ToString());

                if (shops != null && shops.Tables[0].Rows.Count > 0)
                {
                    sheetCount++;
                    if (isExportRackMoney == "1")
                    {
                        decimal rackMoney = GetRackMoney(shops, rackids);
                        shopLevelName = shopLevelName + "(道具汇总金额" + rackMoney + ")";
                    }
                    NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet(shopLevelName);
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
                    int index0 = 14;//列
                    Dictionary<string, List<string>> tableDic = new Dictionary<string, List<string>>();
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
                                
                            }
                            else
                            {
                                row1.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["seat"].ToString());
                                row2.CreateCell(index0).SetCellValue(rackDs.Tables[0].Rows[0]["RackType"].ToString());
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
                                newRackIdList.Add(rackId);
                            }
                        }
                    }
                    int tableColumnIndex = index0;
                    if (tableDic.Any())
                    {
                        
                        foreach (KeyValuePair<string, List<string>> dic in tableDic)
                        {
                            //int rid = int.Parse(dic.Value[0].Split('|')[1]);
                            //string url = GetRackImgUrl(rid);
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
                                    rid = int.Parse(rackInfoList[index].Split('|')[1]);
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
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 4, 4));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 5, 5));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 6, 6));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 3, 3));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 4, 4));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 5, 5));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 10, 10));
                    //sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 11, 11));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 6, 6));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 7, 7));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 8, 8));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 9, 9));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 10, 10));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 11, 11));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 12, 12));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 8, 14 + rackids.Length, 14 + rackids.Length));
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
                        //rowTemp.CreateCell(5).SetCellValue(shops.Tables[0].Rows[i]["FXID"].ToString());
                        //rowTemp.CreateCell(6).SetCellValue(shops.Tables[0].Rows[i]["FXName"].ToString());
                        rowTemp.CreateCell(4).SetCellValue(shops.Tables[0].Rows[i]["CustomerCard"].ToString());

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
                        int index1 = 14;//列
                        string rackName = string.Empty;
                        //for (int j = 0; j < rackids.Length; j++)
                        //{
                        //    int rackId = int.Parse(rackids[j]);
                        //    string rackCount = GetRackCount(shopid, rackId, out rackName);
                        //    if (!rackName.Contains("陈列桌"))
                        //    {
                        //        rowTemp.CreateCell(index1).SetCellValue(rackCount);
                        //        index1++;
                        //    }
                        //    //rowTemp.CreateCell(index1).SetCellValue(GetRackCount(shopid, rackId, out rackName));
                        //    //index1++;
                        //}
                        newRackIdList.ForEach(rid => {
                            //string rackCount = GetRackCount(shopid, rid, out rackName);
                            //if (!rackName.Contains("陈列桌"))
                            //{
                                
                            //}
                            string key = shopid + "-" + rid;
                            int rackCount = 0;
                            if (rackCountDic.Keys.Contains(key))
                                rackCount = rackCountDic[key];
                            if (rackCount > 0)
                               rowTemp.CreateCell(index1).SetCellValue(rackCount);
                            index1++;
                        });
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
                                    //string rackCount = GetRackCount(shopid, rackid, out rackName);
                                    string key = shopid + "-" + rackid;
                                    int rackCount = 0;
                                    if (rackCountDic.Keys.Contains(key))
                                        rackCount = rackCountDic[key];
                                    if (rackCount > 0)
                                    {
                                        type = type0;
                                    }
                                });
                                rowTemp.CreateCell(tableColumnIndex1).SetCellValue(type);
                                //NPOI.SS.Util.CellRangeAddressList regions = new NPOI.SS.Util.CellRangeAddressList(i + 9, i + 9, tableColumnIndex, tableColumnIndex);
                                //DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(typeArr.ToArray());
                                //HSSFDataValidation validation = new HSSFDataValidation(regions, constraint);
                                //sheet1.AddValidationData(validation);
                                tableColumnIndex1++;
                            }


                        }
                        rowTemp.CreateCell(tableColumnIndex1).SetCellValue(shops.Tables[0].Rows[i]["Remark"].ToString());
                    }




                }

                #endregion
            }

            HttpCookie cookie = Request.Cookies["export"];
            if (cookie == null)
            {
                cookie = new HttpCookie("export");
            }
            cookie.Value = "1";
            cookie.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Add(cookie);

            Thread.Sleep(1000);
            if (sheetCount > 0)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                book.Write(ms);
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", System.Web.HttpUtility.UrlEncode(ExcelName + "-" + storyBagName + lastName, System.Text.Encoding.UTF8)));
                Response.BinaryWrite(ms.ToArray());

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

    DataView dv = new DataView();
    string GetRackCount(int shopid, int rackId, out string rackName)
    {
        rackName = string.Empty;
        dv = rackInShopDs.Tables[0].DefaultView;
        dv.RowFilter = "ShopId=" + shopid + " and RackId=" + rackId;
        if (dv.Count > 0)
        {
            rackName = dv[0][6].ToString();
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
                    rackCountDic.Add(key, count);
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
    /// 统计每个级别的道具总金额
    /// </summary>
    /// <param name="shopDs">每个级别的店铺集合</param>
    /// <param name="rackIds">每个级别要导出的道具</param>
    /// <returns></returns>
    List<LN.Model.RackInfo> rackList = new List<LN.Model.RackInfo>();
    List<LN.Model.RackInShop> rackInShopList = new List<LN.Model.RackInShop>();
    decimal GetRackMoney(DataSet shopDs, string[] rackIds)
    {
        decimal money = 0;
        if (rackIds.Length > 0)
        {
            foreach (DataRow dr in shopDs.Tables[0].Rows)
            {
                int shopId = int.Parse(dr["ID"].ToString());
                foreach (string rackid in rackIds)
                {
                    if (!string.IsNullOrWhiteSpace(rackid))
                    {
                        int rid = int.Parse(rackid);
                        if (!rackList.Any())
                        {
                            //所有道具信息
                            rackList = new RackInfo().GetRackList("");

                        }
                        if (!rackInShopList.Any())
                        {
                            rackInShopList = new RackInShop().GetRackList("");
                        }
                        LN.Model.RackInShop rackInShopModel = rackInShopList.Where(r => r.ShopId == shopId && r.RackId == rid).FirstOrDefault();
                        if (rackInShopModel != null)
                        {
                            int rackNum = rackInShopModel.RackCount ?? 0;
                            var rack = rackList.Where(r => r.Id == rid).FirstOrDefault();
                            decimal price = rack != null ? (rack.Price ?? 0) : 0;
                            money += rackNum * price;
                        }
                    }
                }
            }
        }


        return money;
    }
}