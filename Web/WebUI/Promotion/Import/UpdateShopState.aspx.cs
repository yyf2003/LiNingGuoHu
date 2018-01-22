using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Common;
using LN.BLL;

public partial class WebUI_Promotion_Import_UpdateShopState : System.Web.UI.Page
{
    PromotionShopInfo shopBll = new PromotionShopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["success"] != null)
        {
            int successNum = int.Parse(Request.QueryString["success"].ToString());
            int failNum = int.Parse(Request.QueryString["fail"].ToString());
            int repeatNum = int.Parse(Request.QueryString["repeat"].ToString());
            int newNum = int.Parse(Request.QueryString["newNum"].ToString());
            uploadMsg.Style.Add("display", "");
            labTotal.Text = (successNum + failNum).ToString();

            labuploadMsg.Text = "更新成功！";
            labSuccessNum.Text = successNum.ToString();
            labFailNum.Text = failNum.ToString();
            labRepeatNum.Text = repeatNum.ToString();
            labNewNum.Text = newNum.ToString();
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
        }
    }

    RackInShop rackInShopBll = new RackInShop();
    LN.Model.RackInShop rackInShopModel;


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
            int repeatNum = 0;//重复数量
            int newNum = 0;
            if (path != "")
            {
                path = Server.MapPath(path);
                excelConnString = excelConnString.Replace("ExcelPath", path);
                OleDbConnection conn;
                OleDbDataAdapter da;
                conn = new OleDbConnection(excelConnString);
                conn.Open();
                DataTable dt = conn.GetSchema("Tables");
                string sql = "select * from [Sheet1$]";
                da = new OleDbDataAdapter(sql, conn);
                excelDs = new DataSet();
                da.Fill(excelDs);
                da.Dispose();
                if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
                {
                    DataColumnCollection cols = excelDs.Tables[0].Columns;
                    Dictionary<string, int> areaIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> provinceIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> cityIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> imageIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> levelIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> saleTypeIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> shopTypeIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> tclIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> aclIdDic = new Dictionary<string, int>();
                    Dictionary<string, int> stateIdDic = new Dictionary<string, int>();
                    int colCount = cols.Count;
                    int rowIndex = 0;
                    //successNum = 0;//成功导入的数量
                    //failNum = 0;//失败数量
                    LN.Model.PromotionShopInfo shopModel;
                    bool isRack = rblIsRack.SelectedValue == "1";
                    Dictionary<int, string> rack = new Dictionary<int, string>();
                    if (isRack)
                    {

                        for (int j = 0; j < cols.Count; j++)
                        {
                            if (cols[j].ColumnName.StartsWith("M"))
                            {
                                int rackId = GetRackId(cols[j].ColumnName);
                                if (!rack.Keys.Contains(rackId) && rackId>0)
                                {
                                    rack.Add(rackId, cols[j].ColumnName);
                                }
                            }
                            
                        }
                    }
                    foreach (DataRow dr in excelDs.Tables[0].Rows)
                    {
                        bool isExist = false;
                        int shopId = 0;
                        bool canSave = true;
                        int supplierId = 0;//供应商Id
                        int areaId = 0;
                        int provinceId = 0;
                        int cityId = 0;
                        int imageId = 0;//店铺形象Id
                        int levelId = 0;//店铺级别
                        int saleTypeId = 0;//销售类型
                        int shopTypeId = 0;//店铺类型
                        int tclId = 0;
                        int aclId = 0;
                        int stateId = 0;
                        

                        string posCode = dr["店铺编号"].ToString().Trim();//PosId
                        string bigArea = string.Empty;
                        string areaName = string.Empty;
                        string provinceName = string.Empty;
                        string cityName = string.Empty;
                        string levelName = string.Empty;
                        string imageName = string.Empty;
                        string cityLevel = string.Empty;
                        string saleTypeName = string.Empty;
                        string areaCityLevel = string.Empty;
                        string shopStateName = string.Empty;
                        string shopTypeName = string.Empty;

                        string CustomerCard = string.Empty;
                        string DealerID = string.Empty;
                        string DealerName = string.Empty;
                        string FXID = string.Empty;
                        string FXName = string.Empty;

                        string Shopname = string.Empty;
                        string ShopOwnerShip = string.Empty;
                        string Shopsamplename = string.Empty;

                        string PostAddress = string.Empty;
                        string LinkMan = string.Empty;
                        string LinkPhone = string.Empty;
                        string ShopCategory = string.Empty;
                        string remark = string.Empty;

                        if (cols.Contains("大区"))
                            bigArea = dr["大区"].ToString().Trim();
                        if (cols.Contains("省区"))
                            areaName = dr["省区"].ToString().Trim();
                        if (cols.Contains("省份"))
                            provinceName = dr["省份"].ToString().Trim();
                        if (cols.Contains("城市"))
                            cityName = dr["城市"].ToString().Trim();


                        if (cols.Contains("店铺名称"))
                            Shopname = dr["店铺名称"].ToString();
                        if (cols.Contains("店铺产权关系"))
                            ShopOwnerShip = dr["店铺产权关系"].ToString();
                        if (cols.Contains("店铺简称"))
                            Shopsamplename = dr["店铺简称"].ToString();


                        if (cols.Contains("收货地址"))
                           PostAddress = dr["收货地址"].ToString();
                        if (cols.Contains("收货联系人"))
                            LinkMan = dr["收货联系人"].ToString();
                        if (cols.Contains("联系电话"))
                            LinkPhone = dr["联系电话"].ToString();



                        if (cols.Contains("直属客户身份"))
                            CustomerCard = dr["直属客户身份"].ToString().Trim();
                        if (cols.Contains("上级客户编码"))
                            DealerID = dr["上级客户编码"].ToString().Trim();
                        if (cols.Contains("上级客户"))
                            DealerName = dr["上级客户"].ToString().Trim();
                        if (cols.Contains("直属客户编码"))
                            FXID = dr["直属客户编码"].ToString().Trim();
                        if (cols.Contains("直属客户名称"))
                            FXName = dr["直属客户名称"].ToString().Trim();
                        if (cols.Contains("直属客户"))
                            FXName = dr["直属客户"].ToString().Trim();
                        


                        //if (cols.Contains("新店铺类型final"))
                        //    shopTypeName = dr["新店铺类型final"].ToString().Trim();
                        //else if (cols.Contains("新店铺类型"))
                        //    shopTypeName = dr["新店铺类型"].ToString().Trim();
                        if (cols.Contains("店铺类型"))
                            shopTypeName = dr["店铺类型"].ToString().Trim();
                        if (cols.Contains("店铺形象"))
                            imageName = dr["店铺形象"].ToString().Trim();
                        if (cols.Contains("城市级别"))
                            cityLevel = dr["城市级别"].ToString().Trim();
                        if (cols.Contains("区县级城市级别"))
                            areaCityLevel = dr["区县级城市级别"].ToString().Trim();
                        if (cols.Contains("店铺零售属性"))
                            saleTypeName = dr["店铺零售属性"].ToString().Trim();
                        if (cols.Contains("状态更新"))
                            shopStateName = dr["状态更新"].ToString().Trim();
                        if (cols.Contains("店铺级别"))
                            levelName = dr["店铺级别"].ToString().Trim();
                        else if (cols.Contains("店铺类型（NEW）"))
                            levelName = dr["店铺类型（NEW）"].ToString().Trim();
                        if (cols.Contains("店铺分类名称"))
                            ShopCategory = dr["店铺分类名称"].ToString().Trim();
                        else if (cols.Contains("店铺分类"))
                            ShopCategory = dr["店铺分类"].ToString().Trim();
                        else if (cols.Contains("品类店分类"))
                            ShopCategory = dr["品类店分类"].ToString().Trim();

                        if (cols.Contains("备注"))
                            remark = dr["备注"].ToString().Trim();


                        if (!string.IsNullOrWhiteSpace(shopTypeName) && shopTypeName.Contains("李宁-"))
                        {
                            shopTypeName = shopTypeName.Replace("李宁-", "");
                        }
                        if (!string.IsNullOrWhiteSpace(imageName) && imageName.Contains("李宁-"))
                        {
                            imageName=imageName.Replace("李宁-", "");
                        }
                        switch (imageName)
                        {
                            case "一代店":
                                imageName = "一代";
                                break;
                            case "二代店":
                                imageName = "二代";
                                break;
                            case "三代店":
                                imageName = "三代";
                                break;
                            case "四代店":
                                imageName = "四代";
                                break;
                            case "五代店":
                                imageName = "五代";
                                break;
                            case "六代店":
                                imageName = "六代";
                                break;
                            case "七代店":
                                imageName = "七代";
                                break;
                            
                        }
                        if (CheckShop(posCode, out shopId))
                        {
                            isExist = true;
                        }
                        //if (!string.IsNullOrWhiteSpace(parentClientId) && !CheckParentClient(parentClientId))
                        //{
                        //    AddParentClient(parentClientId, dr["上级客户"].ToString());
                        //}
                        //if (!string.IsNullOrWhiteSpace(clientId) && !CheckClient(clientId))
                        //{

                        //    AddClient(clientId, parentClientId, dr["直属客户"].ToString());
                        //}
                        if (!string.IsNullOrWhiteSpace(areaName))
                        {
                            if (!areaIdDic.Keys.Contains(areaName))
                            {
                                if (!CheckArea(areaName, out areaId))
                                {
                                    //canSave = false;
                                    errorData.Append(string.Format("第{0}行省区：{1} 不正确！<br/>", rowIndex + 2, areaName));
                                }
                                else
                                    areaIdDic.Add(areaName, areaId);
                            }
                            else
                            {
                                areaId = areaIdDic[areaName];
                            }
                            
                        }

                        if (!string.IsNullOrWhiteSpace(provinceName))
                        {
                            if (!provinceIdDic.Keys.Contains(provinceName))
                            {
                                if (!CheckProvince(provinceName, out provinceId))
                                {
                                    //canSave = false;
                                    errorData.Append(string.Format("第{0}行省份：{1} 不正确！<br/>", rowIndex + 2, provinceName));
                                }
                                else
                                    provinceIdDic.Add(provinceName, provinceId);
                            }
                            else
                            {
                                provinceId = provinceIdDic[provinceName];
                            }

                        }
                        if (!string.IsNullOrWhiteSpace(cityName))
                        {
                            if (!cityIdDic.Keys.Contains(cityName))
                            {
                                if (!CheckCity(cityName, out cityId))
                                {
                                    //canSave = false;
                                    //errorData.Append(string.Format("第{0}行省区：{1} 不正确！<br/>", rowIndex + 2, cityName));
                                }
                                else
                                    cityIdDic.Add(cityName, cityId);
                            }
                            else
                            {
                                cityId = cityIdDic[cityName];
                            }

                        }
                        if (!string.IsNullOrWhiteSpace(imageName))
                        {
                            if (!imageIdDic.Keys.Contains(imageName))
                            {
                                if (!CheckImage(imageName, out imageId))
                                {
                                    canSave = false;
                                    errorData.Append(string.Format("第{0}行店铺形象：{1} 不正确！<br/>", rowIndex + 2, imageName));
                                }
                                else
                                    imageIdDic.Add(imageName, imageId);
                            }
                            else
                            {
                                imageId = imageIdDic[imageName];
                            }

                        }
                        if (!string.IsNullOrWhiteSpace(levelName))
                        {
                            if (!levelIdDic.Keys.Contains(levelName))
                            {
                                if (!CheckShopLevel(levelName, out levelId))
                                {
                                    canSave = false;
                                    errorData.Append(string.Format("第{0}行店铺级别：{1} 不正确！<br/>", rowIndex + 2, levelName));
                                }
                                else
                                    levelIdDic.Add(levelName, levelId);
                            }
                            else
                            {
                                levelId = levelIdDic[levelName];
                            }

                        }
                        if (!string.IsNullOrWhiteSpace(cityLevel))
                        {
                            if (!tclIdDic.Keys.Contains(cityLevel))
                            {
                                if (!CheckTownCityLevel(cityLevel, out tclId))
                                {
                                    canSave = false;
                                    errorData.Append(string.Format("第{0}行城市级别：{1} 不正确！<br/>", rowIndex + 2, cityLevel));
                                }
                                else
                                    tclIdDic.Add(cityLevel, tclId);
                            }
                            else
                            {
                                tclId = tclIdDic[cityLevel];
                            }

                        }
                        if (!string.IsNullOrWhiteSpace(areaCityLevel))
                        {
                            if (!aclIdDic.Keys.Contains(areaCityLevel))
                            {
                                if (!CheckAreaCityLevel(areaCityLevel, out aclId))
                                {
                                    canSave = false;
                                    errorData.Append(string.Format("第{0}行区县级城市级别：{1} 不正确！<br/>", rowIndex + 2, areaCityLevel));
                                }
                                else
                                    aclIdDic.Add(areaCityLevel, aclId);
                            }
                            else
                            {
                                aclId = aclIdDic[areaCityLevel];
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(saleTypeName))
                        {
                            if (!saleTypeIdDic.Keys.Contains(saleTypeName))
                            {
                                if (!CheckSaleType(saleTypeName, out saleTypeId))
                                {
                                    canSave = false;
                                    errorData.Append(string.Format("第{0}行店铺零售属性：{1} 不正确！<br/>", rowIndex + 2, saleTypeName));
                                }
                                else
                                    saleTypeIdDic.Add(saleTypeName, saleTypeId);
                            }
                            else
                            {
                                saleTypeId = saleTypeIdDic[saleTypeName];
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(shopTypeName))
                        {
                            if (!shopTypeIdDic.Keys.Contains(shopTypeName))
                            {
                                if (!CheckShopType(shopTypeName, out shopTypeId))
                                {
                                    canSave = false;
                                    errorData.Append(string.Format("第{0}行店铺类型：{1} 不正确！<br/>", rowIndex + 2, shopTypeName));
                                }
                                else
                                    shopTypeIdDic.Add(shopTypeName, shopTypeId);
                            }
                            else
                            {
                                shopTypeId = shopTypeIdDic[shopTypeName];
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(shopStateName))
                        {
                            if (!stateIdDic.Keys.Contains(shopStateName))
                            {
                                if (!CheckShopState(shopStateName, out stateId))
                                {
                                    canSave = false;
                                    errorData.Append(string.Format("第{0}行状态更新：{1} 不正确！<br/>", rowIndex + 2, shopStateName));
                                }
                                else
                                    stateIdDic.Add(shopStateName, stateId);
                            }
                            else
                            {
                                stateId = stateIdDic[shopStateName];
                            }
                        }

                        if (string.IsNullOrWhiteSpace(Shopname))
                        {
                            Shopname = Shopsamplename;
                        }
                       

                        if (canSave)
                        {
                            shopModel = new LN.Model.PromotionShopInfo();
                            if (!string.IsNullOrWhiteSpace(bigArea))
                                shopModel.BigArea = bigArea;

                            if (areaId > 0)
                                shopModel.areaid = areaId;
                            if (cityId > 0)
                                shopModel.CityID = cityId;
                            shopModel.CreateDate = DateTime.Now;
                            if (!string.IsNullOrWhiteSpace(CustomerCard))
                                shopModel.CustomerCard = CustomerCard;
                            if (!string.IsNullOrWhiteSpace(DealerID))
                                shopModel.DealerID = DealerID;
                            if (!string.IsNullOrWhiteSpace(DealerName))
                                shopModel.DealerName = DealerName;
                            if (!string.IsNullOrWhiteSpace(FXID))
                                shopModel.FXID = FXID;
                            if (!string.IsNullOrWhiteSpace(FXName))
                                shopModel.FXName = FXName;
                            shopModel.PosID = posCode;
                            if (provinceId > 0)
                                shopModel.ProvinceID = provinceId;
                            if (imageId > 0)
                                shopModel.ShopImageId = imageId;
                            if (!string.IsNullOrWhiteSpace(Shopname))
                                shopModel.Shopname = Shopname;
                            if (!string.IsNullOrWhiteSpace(ShopOwnerShip))
                                shopModel.ShopOwnerShip = ShopOwnerShip;
                            if (!string.IsNullOrWhiteSpace(Shopsamplename))
                                shopModel.Shopsamplename = Shopsamplename;
                            //shopModel.SupplierId = supplierId;
                            shopModel.TownID = 0;
                            if (levelId > 0)
                                shopModel.ShopLevelId = levelId;
                            if (aclId > 0)
                                shopModel.ACL_ID = aclId;
                            if (saleTypeId > 0)
                                shopModel.SaleTypeID = saleTypeId;
                            if (shopTypeId > 0)
                                shopModel.ShopType = shopTypeId;
                            if (tclId > 0)
                                shopModel.TCL_ID = tclId;
                            if (stateId > 0)
                                shopModel.ShopState = stateId;
                            if (!string.IsNullOrWhiteSpace(PostAddress))
                                shopModel.PostAddress = PostAddress;
                            if (!string.IsNullOrWhiteSpace(LinkMan))
                                shopModel.LinkMan = LinkMan;
                            if (!string.IsNullOrWhiteSpace(LinkPhone))
                                shopModel.LinkPhone = LinkPhone;
                            shopModel.ShopCategory = ShopCategory;
                            shopModel.Remark = remark;
                            if (isExist)
                            {
                                repeatNum++;
                                shopModel.ID = shopId;
                                shopBll.Update(shopModel);

                            }
                            else
                            {
                                newNum++;
                                shopId = shopBll.Add(shopModel);
                            }
                            if (isRack)
                            {
                                //更新店铺道具数量
                                foreach (KeyValuePair<int, string> item in rack)
                                {
                                    CheckRackInShop(shopId, item.Key);
                                    string count = dr[item.Value].ToString();

                                    if (!string.IsNullOrWhiteSpace(count) && count != "0")
                                    {
                                        string realSize = string.Empty;
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
                                        rackInShopModel.PosId = posCode;
                                        rackInShopModel.ShopId = shopId;
                                        rackInShopModel.RackId = item.Key;
                                        rackInShopModel.RackCount = int.Parse(count);
                                        rackInShopModel.Size = realSize;
                                        rackInShopBll.Add(rackInShopModel);
                                    }
                                }
                            }
                            successNum++;
                        }
                        else
                            failNum++;

                        rowIndex++;


                    }


                }




                conn.Dispose();
                conn.Close();
                if (errorData.Length > 0)
                {
                    Session["uploadstate"] = errorData.Insert(0, "失败信息：<br/>").ToString();

                }

                Response.Redirect("UpdateShopState.aspx?success=" + successNum + "&fail=" + failNum + "&repeat=" + repeatNum + "&newNum=" + newNum, false);

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

    void CheckRackInShop(int shopId, int rackId)
    {
        DataSet ds = rackInShopBll.GetList(string.Format(" ShopId={0} and RackId={1}", shopId, rackId));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            int id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
            rackInShopBll.Delete(id);
        }
    }

    bool CheckShop(string posid, out int shopId)
    {
        shopId = 0;
        DataSet ds = shopBll.GetList(" PosID='" + posid + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            shopId = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            return true;
        }
        else
            return false;
    }

    SupplierInfo supplierBll = new SupplierInfo();
    bool CheckSupplier(string name, out int supplierId)
    {
        IList<LN.Model.SupplierInfo> list = supplierBll.GetList(" ShortName='" + name + "'");
        bool flag = false;
        supplierId = 0;
        if (list.Count > 0)
        {
            flag = true;
            supplierId = list[0].SupplierID;
        }
        return flag;
    }

    DealerInfo DealerInfoBll = new DealerInfo();
    /// <summary>
    /// 检查上级客户是否存在
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool CheckParentClient(string id)
    {
        DataTable dt = DealerInfoBll.GetDealerName(" DealerID='" + id + "'");
        return dt != null && dt.Rows.Count > 0;
    }

    DistributorsInfo DistributorsInfoBll = new DistributorsInfo();
    /// <summary>
    /// 检查直属客户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool CheckClient(string id)
    {
        DataTable dt = DistributorsInfoBll.GetFXinfolistsBy(id);
        return dt != null && dt.Rows.Count > 0;
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
    /// <summary>
    /// 检查店铺形象
    /// </summary>
    /// <param name="name"></param>
    /// <param name="imageId"></param>
    /// <returns></returns>
    bool CheckImage(string name, out int imageId)
    {
        bool flag = false;
        imageId = 0;
        DataSet ds = imageBll.GetList(" ImageName='" + name + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
            imageId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        }
        return flag;
    }

    PromotionShopLevel levelBll = new PromotionShopLevel();
    bool CheckShopLevel(string name, out int levelId)
    {
        bool flag = false;
        levelId = 0;
        if (name.IndexOf("Core") != -1)
        {
            name = "CR店";
        }
        else if (name.IndexOf("Other") != -1)
        {
            name = "OR店";
        }
        DataSet ds = levelBll.GetList(string.Format(" ShopLevelName='{0}'", name));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
            levelId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        }
        return flag;
    }




    TownCityLevel TownCityLevelBll = new TownCityLevel();
    /// <summary>
    /// 检查城市级别
    /// </summary>
    /// <param name="name"></param>
    /// <param name="tclId"></param>
    /// <returns></returns>
    bool CheckTownCityLevel(string name, out int tclId)
    {
        bool flag = false;
        tclId = 0;
        IList<LN.Model.TownCityLevel> list = TownCityLevelBll.GetList(string.Format(" TCL_Name='{0}'", name));
        if (list.Count > 0)
        {
            flag = true;
            tclId = list[0].TCL_Id;
        }
        return flag;
    }

    AreaCityLevel AreaCityLevelBll = new AreaCityLevel();
    /// <summary>
    /// 区县级城市级别
    /// </summary>
    /// <param name="name"></param>
    /// <param name="aclId"></param>
    /// <returns></returns>
    bool CheckAreaCityLevel(string name, out int aclId)
    {
        bool flag = false;
        aclId = 0;
        IList<LN.Model.AreaCityLevel> list = AreaCityLevelBll.GetList(string.Format(" ACL_Name='{0}'", name));
        if (list.Count > 0)
        {
            flag = true;
            aclId = list[0].ACL_Id;
        }
        return flag;
    }

    SaleTypeInfo SaleTypeInfoBll = new SaleTypeInfo();
    /// <summary>
    /// 检查零售属性
    /// </summary>
    /// <param name="name"></param>
    /// <param name="saleTypeId"></param>
    /// <returns></returns>
    bool CheckSaleType(string name, out int saleTypeId)
    {
        bool flag = false;
        saleTypeId = 0;
        DataSet ds = SaleTypeInfoBll.GetList(string.Format(" SaleType='{0}'", name));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
            saleTypeId = int.Parse(ds.Tables[0].Rows[0]["SaleTypeID"].ToString());
        }
        return flag;
    }

    ShopType ShopTypeBll = new ShopType();
    /// <summary>
    /// 检查店铺类型
    /// </summary>
    /// <param name="name"></param>
    /// <param name="shopTypeId"></param>
    /// <returns></returns>
    bool CheckShopType(string name, out int shopTypeId)
    {
        bool flag = false;
        shopTypeId = 0;
        IList<LN.Model.ShopType> list = ShopTypeBll.GetList(string.Format(" ShopTypename='{0}'", name));
        if (list.Count > 0)
        {
            flag = true;
            shopTypeId = list[0].ID;
        }
        return flag;
    }

    ShopStateInfo ShopStateInfoBll = new ShopStateInfo();
    /// <summary>
    /// 检查店铺状态
    /// </summary>
    /// <param name="name"></param>
    /// <param name="stateId"></param>
    /// <returns></returns>
    bool CheckShopState(string name, out int stateId)
    {
        bool flag = false;
        stateId = 0;
        DataSet ds = ShopStateInfoBll.GetList(string.Format(" ShopState='{0}'", name));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
            stateId = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
        }
        return flag;
    }















    /// <summary>
    /// 如果没有上级客户，就添加一个
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    int AddParentClient(string id, string name)
    {
        LN.Model.DealerInfo model = new LN.Model.DealerInfo();
        model.Address = "无";
        model.AreaID = 0;
        model.CityID = 0;
        model.Contactor = "";
        model.ContactorPhone = "";
        model.DealerChannel = "";
        model.DealerID = id;
        model.DealerName = name;
        model.ExamState = 1;
        model.ExamUserID = 1;
        model.PostAddress = "";
        model.ProvinceID = 0;
        model.VMExamState = 1;
        model.VMExamUserID = 1;
        return DealerInfoBll.Add(model);
    }
    /// <summary>
    /// 如果没有直属客户，就添加一个
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    int AddClient(string id, string parentid, string name)
    {
        LN.Model.DistributorsInfo model = new LN.Model.DistributorsInfo();
        model.AreaID = 0;
        model.CityID = 0;
        model.DealerID = parentid;
        model.ExamDate = DateTime.Now.ToString();
        model.ExamState = 1;
        model.ExamUserID = 1;
        model.FXAddress = "";
        model.FXContactor = "";
        model.FXID = id;
        model.FXName = name;
        model.FXPhone = "";
        model.FXtel = "";
        model.NewDealerID = "";
        model.ProvinceID = 0;
        return DistributorsInfoBll.Add(model);
    }

    /// <summary>
    /// 下载模板
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_DownLoadPropTemplate_Click(object sender, EventArgs e)
    {
        string path = ConfigurationManager.AppSettings["UpdatePromotionShopsTemplate"].ToString();
        UploadFileHelper.DownLoadFile(path);
    }
}