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



public partial class WebUI_Promotion_Import_ImportShopInfo : System.Web.UI.Page
{
    PromotionShopInfo shopBll = new PromotionShopInfo();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["success"] != null)
        {
            int successNum = int.Parse(Request.QueryString["success"].ToString());
            int failNum = int.Parse(Request.QueryString["fail"].ToString());
            int repeatNum = int.Parse(Request.QueryString["repeat"].ToString());
            uploadMsg.Style.Add("display", "");
            labTotal.Text = (successNum + failNum + repeatNum).ToString();
            //if (successNum == 0)
            //{
            //    labuploadMsg.Text = "导入失败！";
            //}
            //else
            //    labuploadMsg.Text = failNum == 0 ? "导入成功！" : "部分数据导入失败！";
            labuploadMsg.Text = "导入成功！";
            labSuccessNum.Text = successNum.ToString();
            labFailNum.Text = failNum.ToString();
            labRepeatNum.Text = repeatNum.ToString();
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
            int repeatNum = 0;//重复数量
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
                       //string sql = "select * from [Sheet1$]";
                       string sql = "select * from [" + sheetName + "]";
                       da = new OleDbDataAdapter(sql, conn);
                       excelDs = new DataSet();
                       da.Fill(excelDs);
                       da.Dispose();
                       if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
                       {
                           DataColumnCollection cols = excelDs.Tables[0].Columns;
                           int colCount = cols.Count;
                           int rowIndex = 0;
                           //successNum = 0;//成功导入的数量
                           //failNum = 0;//失败数量
                           LN.Model.PromotionShopInfo shopModel;
                           foreach (DataRow dr in excelDs.Tables[0].Rows)
                           {

                               bool canSave = true;
                               int shopId = 0;
                               //int supplierId = 0;//供应商Id
                               //int areaId = 0;
                               //int provinceId = 0;
                               //int cityId = 0;
                               //int imageId = 0;//店铺形象Id
                               //int levelId = 0;//店铺级别
                               //int saleTypeId = 0;//销售类型
                               //int shopTypeId = 0;//店铺类型
                               //int tclId = 0;
                               //int aclId = 0;
                               //int stateId = 0;
                               //string supplierName = dr["供应商"].ToString().Trim();
                               string posCode = dr["店铺编号"].ToString().Trim();//PosId
                               //string parentClientId = dr["上级客户编码"].ToString().Trim();//上级客户
                               //string clientId = dr["直属客户编码"].ToString().Trim();//直属客户
                               //string areaName = dr["省区"].ToString().Trim();
                               //string provinceName = dr["省份"].ToString().Trim();
                               //string cityName = dr["城市"].ToString().Trim();
                               //string imageName = dr["店铺形象"].ToString().Trim();
                               //string levelName = dr["店铺级别"].ToString().Trim();
                               //string saleTypeName = dr["店铺零售属性"].ToString().Trim();
                               //string shopTypeName = dr["店铺类型"].ToString().Trim();
                               //string tclName = dr["地市级城市级别"].ToString().Trim();
                               //string aclName = dr["区县级城市级别"].ToString().Trim();
                               //string shopState = dr["店铺状态"].ToString();
                               
                               if (!CheckShop(posCode, out shopId))
                               {
                                   canSave = false;

                               }

                                   //if (!string.IsNullOrWhiteSpace(supplierName) && !CheckSupplier(supplierName, out supplierId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行供应商：{1} 不正确！<br/>", rowIndex + 2, supplierName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(parentClientId) && !CheckParentClient(parentClientId))
                                   //{

                                   //    AddParentClient(parentClientId, dr["上级客户"].ToString());
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(clientId) && !CheckClient(clientId))
                                   //{

                                   //    AddClient(clientId, parentClientId, dr["直属客户"].ToString());
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(areaName) && !CheckArea(areaName, out areaId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行省区：{1} 不正确！<br/>", rowIndex + 2, areaName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(provinceName) && !CheckProvince(provinceName, out provinceId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行省份：{1} 不正确！<br/>", rowIndex + 2, provinceName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(cityName) && !CheckCity(cityName, out cityId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行城市：{1} 不正确！<br/>", rowIndex + 2, cityName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(levelName) && !CheckShopLevel(levelName, out levelId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行店铺级别：{1} 不正确！<br/>", rowIndex + 2, levelName));
                                   //}
                               //if (!string.IsNullOrWhiteSpace(imageName) && !CheckImage(imageName, out imageId))
                               //{
                               //    canSave = false;
                               //    errorData.Append(string.Format("第{0}行店铺形象：{1} 不正确！<br/>", rowIndex + 2, imageName));
                               //}
                                   //if (!string.IsNullOrWhiteSpace(saleTypeName) && !CheckSaleType(saleTypeName, out saleTypeId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行店铺零售属性：{1} 不正确！<br/>", rowIndex + 2, saleTypeName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(shopTypeName) && !CheckShopType(shopTypeName, out shopTypeId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行店铺类型：{1} 不正确！<br/>", rowIndex + 2, shopTypeName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(tclName) && !CheckTownCityLevel(tclName, out tclId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行地市级城市级别：{1} 不正确！<br/>", rowIndex + 2, tclName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(aclName) && !CheckAreaCityLevel(aclName, out aclId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行地市级城市级别：{1} 不正确！<br/>", rowIndex + 2, aclName));
                                   //}
                                   //if (!string.IsNullOrWhiteSpace(shopState) && !CheckShopState(shopState, out stateId))
                                   //{
                                   //    canSave = false;
                                   //    errorData.Append(string.Format("第{0}行店铺属性：{1} 不正确！<br/>", rowIndex + 2, shopState));
                                   //}
                                   if (canSave)
                                   {
                                       shopModel = new LN.Model.PromotionShopInfo();
                                       shopModel.ID = shopId;
                                       //shopModel.areaid = areaId;
                                       //shopModel.CityID = cityId;
                                       //shopModel.CreateDate = DateTime.Now;
                                       //shopModel.CustomerCard = dr["直属客户身份"].ToString();
                                       //shopModel.DealerID = parentClientId;
                                       //shopModel.DealerName = dr["上级客户"].ToString();
                                       //shopModel.FXID = clientId;
                                       //shopModel.FXName = dr["直属客户"].ToString();
                                       shopModel.LinkMan = dr["收货联系人"].ToString();
                                       shopModel.LinkPhone = dr["联系电话"].ToString();
                                       //shopModel.PosID = posCode;
                                       //shopModel.PostAddress = dr["收货地址"].ToString();
                                       //shopModel.ProvinceID = provinceId;
                                       //shopModel.ShopAddress = dr["收货地址"].ToString();
                                       //shopModel.ShopImageId = imageId;
                                       //shopModel.Shopname = dr["店铺简称"].ToString();
                                       //shopModel.ShopOwnerShip = dr["店铺产权关系"].ToString();
                                       //shopModel.Shopsamplename = dr["店铺简称"].ToString();
                                       //shopModel.SupplierId = supplierId;
                                       //shopModel.TownID = 0;
                                       //shopModel.ShopLevelId = levelId;
                                       //shopModel.ACL_ID = aclId;
                                       //shopModel.SaleTypeID = saleTypeId;
                                       //shopModel.ShopType = shopTypeId;
                                       //shopModel.TCL_ID = tclId;
                                       //shopModel.ShopState = stateId;
                                       shopBll.Update(shopModel);
                                       successNum++;
                                   }
                                   else
                                       failNum++;
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

                Response.Redirect("ImportShopInfo.aspx?success=" + successNum + "&fail=" + failNum + "&repeat=" + repeatNum, false);

            }

        }
    }

    /// <summary>
    /// 检查店铺是否已存在
    /// </summary>
    /// <param name="posid"></param>
    /// <returns>false:不存在</returns>
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
        IList<LN.Model.ProvinceData> list = provinceBll.GetList(" ProvinceName='" + name + "'");
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
    int AddClient(string id,string parentid, string name)
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

    SaleTypeInfo SaleTypeInfoBll = new SaleTypeInfo();
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

    TownCityLevel TownCityLevelBll = new TownCityLevel();
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

    ShopStateInfo ShopStateInfoBll = new ShopStateInfo();
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