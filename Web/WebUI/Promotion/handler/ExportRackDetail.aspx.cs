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

public partial class WebUI_Promotion_handler_ExportRackDetail : System.Web.UI.Page
{
    int pid;
    int supplierId;
    string supplierName = string.Empty;
    int regionId;
    string regionName = string.Empty;
    string sonStoryBagIds = string.Empty;
    string parentStoryBagIds = string.Empty;
    string shopLevels = string.Empty;//店铺级别，格式：id:name,id:name
    //string rackIds = string.Empty;
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
        if (Request.QueryString["shopLevels"] != null)
        {
            shopLevels = Request.QueryString["shopLevels"];
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
        string lastName = string.Empty;
        if (!string.IsNullOrWhiteSpace(regionName))
        {
            lastName = "-" + regionName;
        }

        //保存店铺级别id/name:将shopLevels字符串拆分后保存到字典
        Dictionary<Dictionary<int, string>, string> shopLevelDic = new Dictionary<Dictionary<int, string>, string>();
        if (!string.IsNullOrWhiteSpace(shopLevels))
        {
            string[] arr = shopLevels.Split('$');
            foreach (string s in arr)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    string[] subArr = s.Split(':');
                    Dictionary<int, string> shopLevel = new Dictionary<int, string>();
                    shopLevel.Add(int.Parse(subArr[0]), subArr[1] + ":" + subArr[2]);
                    shopLevelDic.Add(shopLevel, subArr[3]);
                }
            }
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
                        DataSet ds1 = finalPromotionShopBll.GetJoinShopList(string.Format(" PromotionShopInfo.areaid={0} and PromotionShopInfo.ProvinceID={1} ", dr["DepartmentId"].ToString(), dr["ProvinceId"].ToString()));
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
                        DataSet ds1 = finalPromotionShopBll.GetJoinShopList(string.Format(" PromotionShopInfo.areaid={0} ", dr["DepartmentId"].ToString()));
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
        int sheetCount = 0;
        if (shopLevelDic.Count > 0)
        { 
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            foreach (KeyValuePair<Dictionary<int, string>, string> item in shopLevelDic)
            {
                Dictionary<int, string> Levels = item.Key;
                //string[] rackids = item.Value.Split(',');
                string rackIds = null;
                if (!string.IsNullOrWhiteSpace(item.Value))
                    rackIds = item.Value;
                int shopLevel = 0;
                string shopLevelName = string.Empty;
                
                foreach (KeyValuePair<int, string> item1 in Levels)
                {
                    shopLevel = item1.Key;
                    shopLevelName = item1.Value.Split(':')[0];
                    
                }
                System.Text.StringBuilder whereStr = new System.Text.StringBuilder();
                whereStr.AppendFormat(" and PromotionShopInfo.ShopLevelId ={0}", shopLevel);
                if (!string.IsNullOrWhiteSpace(regionName))
                {
                    whereStr.AppendFormat(" and FinalPromotionShops.BigArea ='{0}'", regionName);
                }
                if (supplierId > 0)
                {
                    whereStr.Append(string.Format(" and FinalPromotionShops.ShopId in({0})", supplierShopIds.ToString().TrimEnd(',')));
                }

                //该推广活动订单的所有道具
                rackInShopDs = rackInShopBll.GetFinalRackList1(pid, parentStoryBagIds, whereStr.ToString(), rackIds);

                if (rackInShopDs != null && rackInShopDs.Tables[0].Rows.Count > 0)
                {
                    sheetCount++;
                    var rackList = (from rack in rackInShopDs.Tables[0].AsEnumerable()
                                    select new
                                    {
                                        Id = rack.Field<int>("RackId"),
                                        Position = rack.Field<string>("Position"),
                                        RackCode = rack.Field<string>("RackCode"),
                                        RackType = rack.Field<string>("RackType"),
                                        RackName = rack.Field<string>("RackName"),
                                        Size = rack.Field<string>("RackSize"),
                                        Texture = rack.Field<string>("Texture"),
                                        Specification = rack.Field<string>("Specification"),
                                        Category = rack.Field<string>("Category"),
                                        Price = rack.Field<double>("Price"),
                                        RackCount = rack.Field<int>("RackCount")
                                        //RackCount=0
                                    }
                                  ).OrderBy(s => s.Id).ToList();
                    var newList = (from rack in rackList
                                   group rack by new
                                   {
                                       rack.Id,
                                       rack.Position,
                                       rack.RackCode,
                                       rack.RackType,
                                       rack.RackName,
                                       rack.Size,
                                       rack.Texture,
                                       rack.Specification,
                                       rack.Category,
                                       rack.Price
                                   }
                                       into rackItem
                                       select new
                                       {
                                           rackItem.Key,
                                           RackCount = rackItem.Sum(s => s.RackCount)

                                       }).ToList();

                    NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet(shopLevelName);
                    NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
                    row1.CreateCell(0).SetCellValue("订单名称");
                    row1.CreateCell(1).SetCellValue("大区");
                    row1.CreateCell(2).SetCellValue("位置");
                    row1.CreateCell(3).SetCellValue("道具类型");
                    row1.CreateCell(4).SetCellValue("效果图类型");
                    row1.CreateCell(5).SetCellValue("效果图");
                    row1.CreateCell(6).SetCellValue("道具名称");
                    row1.CreateCell(7).SetCellValue("道具编码");
                    row1.CreateCell(8).SetCellValue("材质");
                    row1.CreateCell(9).SetCellValue("规格");
                    row1.CreateCell(10).SetCellValue("尺寸");
                    row1.CreateCell(11).SetCellValue("单价");
                    row1.CreateCell(12).SetCellValue("数量");
                    row1.CreateCell(13).SetCellValue("合计金额");
                    int rowIndex = 1;
                    double totalPrice = 0;
                    newList.ForEach(s =>
                    {
                        NPOI.SS.UserModel.IRow rowTemp = sheet1.CreateRow(rowIndex);
                        string url = GetRackImgUrl(s.Key.Id);

                        rowTemp.CreateCell(0).SetCellValue(ExcelName);
                        rowTemp.CreateCell(1).SetCellValue(regionName);
                        rowTemp.CreateCell(2).SetCellValue(s.Key.Position);
                        rowTemp.CreateCell(3).SetCellValue(s.Key.Category);
                        rowTemp.CreateCell(4).SetCellValue(s.Key.RackType);
                        AddPieChart(sheet1, book, url, rowIndex, 5);
                        //rowTemp.CreateCell(5).SetCellValue("");
                        rowTemp.CreateCell(6).SetCellValue(s.Key.RackName);
                        rowTemp.CreateCell(7).SetCellValue(s.Key.RackCode);
                        rowTemp.CreateCell(8).SetCellValue(s.Key.Texture);
                        rowTemp.CreateCell(9).SetCellValue(s.Key.Specification);
                        rowTemp.CreateCell(10).SetCellValue(s.Key.Size);
                        rowTemp.CreateCell(11).SetCellValue(double.Parse(s.Key.Price.ToString()));
                        rowTemp.CreateCell(12).SetCellValue(s.RackCount);
                        
                        double subPrice = s.RackCount * s.Key.Price;
                        totalPrice += subPrice;
                        rowTemp.CreateCell(13).SetCellValue(subPrice);
                        sheet1.SetColumnWidth(5, 30 * 256);
                        rowTemp.Height = 200 * 8;
                        rowIndex++;
                    });
                    NPOI.SS.UserModel.IRow lastRow = sheet1.CreateRow(rowIndex);
                    lastRow.CreateCell(0).SetCellValue("");
                    lastRow.CreateCell(1).SetCellValue("");
                    lastRow.CreateCell(2).SetCellValue("");
                    lastRow.CreateCell(3).SetCellValue("");
                    lastRow.CreateCell(4).SetCellValue("");
                    lastRow.CreateCell(5).SetCellValue("");
                    lastRow.CreateCell(6).SetCellValue("");
                    lastRow.CreateCell(7).SetCellValue("");
                    lastRow.CreateCell(8).SetCellValue("");
                    lastRow.CreateCell(9).SetCellValue("");
                    lastRow.CreateCell(10).SetCellValue("");
                    lastRow.CreateCell(11).SetCellValue("");
                    lastRow.CreateCell(12).SetCellValue("共计");
                    lastRow.CreateCell(13).SetCellValue(totalPrice);
                    
                }




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
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", System.Web.HttpUtility.UrlEncode(ExcelName + "-道具明细", System.Text.Encoding.UTF8)));
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
}