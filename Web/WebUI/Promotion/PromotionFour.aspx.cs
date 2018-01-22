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

public partial class WebUI_Promotion_PromotionFour : System.Web.UI.Page
{
    int pid;
    int userId;
    PromotionShops promotionShopBll = new PromotionShops();
    LN.Model.PromotionShops promotionShopModel;
    PromotionShopInfo promotionShopInfoBll = new PromotionShopInfo();
    LN.Model.PromotionShopInfo promotionShopInfoModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null)
        //{
        //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
        //    return;
        //}
        //userId = int.Parse(Request.Cookies["UserID"].Value);
        if (Request.QueryString["id"] != null)
        {
            pid = int.Parse(Request.QueryString["id"].ToString());
        }
        if (!IsPostBack)
        {
            Promotion promotionBll = new Promotion();
            LN.Model.Promotion promotionModel = promotionBll.GetModel(pid);
            if (promotionModel != null)
            {
                labPromotionId.Text = promotionModel.PromotionId;
                labTitle.Text = promotionModel.PromotionName;

            }
            BindData();
        }
    }

    /// <summary>
    /// 筛选条件
    /// </summary>
    void BindData()
    {
        GetShopST();
        GetShoplevel();
        GetShopType();
        GetShopVI();
        //GetShopACL();
        //etShopTCL();
        GetArea();
    }

    /// <summary>
    /// 得到店铺零售属性
    /// </summary>
    private void GetShopST()
    {
        DataSet ds = new LN.BLL.SaleTypeInfo().GetList("");
        DataTable dt = ds.Tables[0];
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            levelstr.Append("<input value=\"" + dt.Rows[i]["SaleTypeID"].ToString() + "\" id=\"" + dt.Rows[i]["SaleTypeID"].ToString() + "\"checked=\"checked\"  name=\"shopSaleType\" type=\"checkbox\"/ >" + dt.Rows[i]["SaleType"].ToString());
        }
        labShopST.Text = levelstr.ToString();

    }

    /// <summary>
    /// 得到店铺级别
    /// </summary>
    private void GetShoplevel()
    {
        DataSet ds = new LN.BLL.PromotionShopLevel().GetList("");
        DataTable dt = ds.Tables[0];
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            levelstr.Append("<input value=\"" + dt.Rows[i]["Id"].ToString() + "\" id=\"" + dt.Rows[i]["Id"].ToString() + "\"checked=\"checked\"  name=\"shopLevel\" type=\"checkbox\"/ >" + dt.Rows[i]["ShopLevelName"].ToString());
        }
        labShoplevel.Text = levelstr.ToString();
    }

    /// <summary>
    /// 加载店铺类型 
    /// </summary>
    private void GetShopType()
    {
        IList<LN.Model.ShopType> typelist = new LN.BLL.ShopType().GetList("");
        StringBuilder typestr = new StringBuilder();
        foreach (LN.Model.ShopType model in typelist)
        {
            typestr.Append("<input value=\"" + model.ID + "\" id=\"" + model.ID + "\"checked=\"checked\"  name=\"shopType\" type=\"checkbox\"/ >" + model.ShopTypename);
        }
        labShopType.Text = typestr.ToString();
    }

    /// <summary>
    /// 店铺形象属性
    /// </summary>
    private void GetShopVI()
    {
        DataSet ds = new LN.BLL.PromotionShopImage().GetList("");
        StringBuilder vistr = new StringBuilder();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            vistr.Append("<input value=\"" + ds.Tables[0].Rows[i]["Id"].ToString() + "\" id=\"" + ds.Tables[0].Rows[i]["Id"].ToString() + "\"checked=\"checked\"  name=\"shopVI\" type=\"checkbox\"/ >" + ds.Tables[0].Rows[i]["ImageName"].ToString());
        }
        labShopVI.Text = vistr.ToString();
    }

    /// <summary>
    /// 地市级城市级别-市场定义
    /// </summary>
    private void GetShopACL()
    {
        IList<LN.Model.AreaCityLevel> list = new LN.BLL.AreaCityLevel().GetList("");
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            levelstr.Append("<input value=\"" + list[i].ACL_Id.ToString() + "\" id=\"" + list[i].ACL_Id.ToString() + "\"checked=\"checked\"  name=\"AreaCityLevel\" type=\"checkbox\"/ >" + list[i].ACL_Name);
        }
        //labTCL.Text = levelstr.ToString();
    }

    /// <summary>
    /// 区县级城市级别-市场定义
    /// </summary>
    private void GetShopTCL()
    {
        IList<LN.Model.TownCityLevel> list = new LN.BLL.TownCityLevel().GetList("");
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            levelstr.Append("<input value=\"" + list[i].TCL_Id.ToString() + "\" id=\"" + list[i].TCL_Id.ToString() + "\"checked=\"checked\"  name=\"TownCityLevel\" type=\"checkbox\"/ >" + list[i].TCL_Name);
        }
        //labACL.Text = levelstr.ToString();
    }


    /// <summary>
    /// 获取全部大区域
    /// </summary>
    private void GetArea()
    {
        IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList("");
        DataSet ds = new LN.BLL.DepartMentInfo().GetList(" State=1");
        StringBuilder areaStr = new StringBuilder();
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                areaStr.Append("<input value=\"" + dr["ID"].ToString() + "\" name=\"area\" id=\"" + dr["ID"].ToString() + "\"  type=\"checkbox\"/ >" + dr["department"].ToString() + "\t");
            }
        }

        //for (int i = 0; i < AreaList.Count; i++)
        //{
        //    areaStr.Append("<input value=\"" + AreaList[i].AreaID.ToString() + "\" name=\"area\" id=\"" + AreaList[i].AreaID.ToString() + "\"  type=\"checkbox\"/ >" + AreaList[i].AreaName + "\t");
        //}

        labRegion.Text = areaStr.ToString();
        //DataSet ds = new LN.BLL.DepartMentInfo().GetList("");
        //if (ds != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    StringBuilder areaStr = new StringBuilder();
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        areaStr.Append("<input value=\"" + ds.Tables[0].Rows[i]["ID"].ToString() + "\" name=\"area\" id=\"" + ds.Tables[0].Rows[i]["ID"].ToString() + "\"  type=\"checkbox\"/ >" + ds.Tables[0].Rows[i]["department"].ToString() + "\t");
        //    }
        //    labRegion.Text = areaStr.ToString();
        //}
    }

    protected void rblSelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected = (sender as RadioButtonList).SelectedValue;
        switch (selected)
        {
            case "1":
                MultiView1.ActiveViewIndex = 1;
                break;
            case "2":
                MultiView1.ActiveViewIndex = 2;
                break;
            default:
                MultiView1.ActiveViewIndex = 0;
                break;
        }
    }

    /// <summary>
    /// 手动导入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            if (path != "")
            {
                path = Server.MapPath(path);
                excelConnString = excelConnString.Replace("ExcelPath", path);
                OleDbConnection conn;
                OleDbDataAdapter da;
                conn = new OleDbConnection(excelConnString);
                string sql = "select * from [Sheet1$]";
                da = new OleDbDataAdapter(sql, conn);
                excelDs = new DataSet();
                da.Fill(excelDs);
                conn.Dispose();
                conn.Close();
                da.Dispose();

            }
            if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
            {
                //删除数据
                DeleteByPromotionId();
                StringBuilder errorData = new StringBuilder();
                int rowIndex = 0;
                int successNum = 0;//成功导入的数量
                int failNum = 0;//失败数量
                int newNum = 0;//新增数量
                List<string> importShopNo = new List<string>();
                foreach (DataRow dr in excelDs.Tables[0].Rows)
                {
                    //bool isExist = false;
                    //int shopId = 0;
                    bool canSave = true;

                    //int areaId = 0;
                    //int provinceId = 0;
                    //int cityId = 0;
                    //int tclId = 0;
                    //int aclId = 0;
                    //int saleTypeId = 0;
                    //int shopTypeId = 0;
                    //int shopLevelId = 0;
                    //int stateId = 0;






                    string posCode = dr["店铺编号"].ToString().Trim();//PosId
                    //string areaName = dr["省区"].ToString().Trim();
                    //string provinceName = dr["省份"].ToString().Trim();
                    //string cityName = dr["城市"].ToString().Trim();
                    //string cityLevel = dr["城市级别"].ToString().Trim();
                    //string areaCityLevel = dr["区县级城市级别"].ToString().Trim();
                    //string saleTypeName = dr["店铺零售属性"].ToString().Trim();
                    //string shopTypeName = dr["店铺类型"].ToString().Trim();
                    //string levelName = dr["新店铺类型"].ToString().Trim();
                    //string stateName = dr["店铺状态"].ToString().Trim();
                    rowIndex++;
                    if (string.IsNullOrWhiteSpace(posCode))
                    {
                        canSave = false;
                        errorData.AppendFormat("第{0}行：店铺编号 不能为空；<br/>", rowIndex + 1);
                    }
                    if (string.IsNullOrWhiteSpace(dr["店铺名称"].ToString().Trim()))
                    {
                        canSave = false;
                        errorData.AppendFormat("第{0}行：店铺名称 不能为空；<br/>", rowIndex + 1);
                    }
                    if (importShopNo.Contains(posCode))
                    {
                        canSave = false;
                        errorData.AppendFormat("第{0}行：店铺编号'{1}' 重复；<br/>", rowIndex + 1, dr["店铺编号"].ToString());
                    }
                    LN.Model.PromotionShopInfo shopInfoModel = null;
                    if (!CheckShop(posCode, out shopInfoModel))
                    {
                        canSave = false;
                        errorData.AppendFormat("第{0}行：店铺不存在，请先更新店铺信息；<br/>", rowIndex + 1);
                    }
                    if (canSave)
                    {
                        
                        //if (!string.IsNullOrWhiteSpace(areaName) && !CheckArea(areaName, out areaId))
                        //{

                        //    //errorData.Append(string.Format("第{0}行省区：{1} 不正确！<br/>", rowIndex + 2, areaName));
                        //}
                        //if (!string.IsNullOrWhiteSpace(provinceName) && !CheckProvince(provinceName, out provinceId))
                        //{
                        //    //canSave = false;
                        //    //errorData.Append(string.Format("第{0}行省份：{1} 不正确！<br/>", rowIndex + 2, provinceName));
                        //}
                        //if (!string.IsNullOrWhiteSpace(cityName) && !CheckCity(cityName, out cityId))
                        //{
                        //    //canSave = false;
                        //    //errorData.Append(string.Format("第{0}行城市：{1} 不正确！<br/>", rowIndex + 2, cityName));
                        //}
                        //if (!string.IsNullOrWhiteSpace(cityLevel) && !CheckTownCityLevel(cityLevel, out tclId))
                        //{

                        //}
                        //if (!string.IsNullOrWhiteSpace(areaCityLevel) && !CheckAreaCityLevel(areaCityLevel, out aclId))
                        //{

                        //}
                        //if (!string.IsNullOrWhiteSpace(saleTypeName) && !CheckSaleType(saleTypeName, out saleTypeId))
                        //{

                        //}
                        //if (!string.IsNullOrWhiteSpace(saleTypeName) && !CheckSaleType(saleTypeName, out saleTypeId))
                        //{

                        //}
                        //if (!string.IsNullOrWhiteSpace(shopTypeName) && !CheckShopType(shopTypeName, out shopTypeId))
                        //{

                        //}
                        //if (!string.IsNullOrWhiteSpace(levelName) && !CheckShopLevel(levelName, out shopLevelId))
                        //{

                        //}
                        //if (!string.IsNullOrWhiteSpace(stateName) && !CheckShopState(stateName, out stateId))
                        //{

                        //}
                        //if (!isExist)
                        //{
                            //promotionShopInfoModel = promotionShopInfoBll.GetModel(shopId);
                            //if (promotionShopInfoModel != null)
                            //{
                            //    if (aclId > 0)
                            //        promotionShopInfoModel.ACL_ID = aclId;
                            //    if (areaId > 0)
                            //        promotionShopInfoModel.areaid = areaId;
                            //    if (cityId > 0)
                            //        promotionShopInfoModel.CityID = cityId;
                            //    promotionShopInfoModel.CustomerCard = dr["直属客户身份"].ToString();
                            //    promotionShopInfoModel.DealerID = dr["上级客户编码"].ToString();
                            //    promotionShopInfoModel.DealerName = dr["上级客户"].ToString();
                            //    promotionShopInfoModel.FXID = dr["直属客户编码"].ToString();
                            //    promotionShopInfoModel.FXName = dr["直属客户"].ToString();
                            //    if (provinceId > 0)
                            //        promotionShopInfoModel.ProvinceID = provinceId;
                            //    if (saleTypeId > 0)
                            //        promotionShopInfoModel.SaleTypeID = saleTypeId;
                            //    promotionShopInfoModel.ShopAddress = dr["店铺营业地址"].ToString();
                            //    if (shopLevelId > 0)
                            //        promotionShopInfoModel.ShopLevelId = shopLevelId;
                            //    promotionShopInfoModel.Shopname = dr["店铺名称"].ToString();
                            //    promotionShopInfoModel.ShopOwnerShip = dr["店铺产权关系"].ToString();
                            //    promotionShopInfoModel.Shopsamplename = dr["店铺简称"].ToString();
                            //    if (stateId > 0)
                            //        promotionShopInfoModel.ShopState = stateId;
                            //    if (shopTypeId > 0)
                            //        promotionShopInfoModel.ShopType = shopTypeId;
                            //    if (tclId > 0)
                            //        promotionShopInfoModel.TCL_ID = tclId;
                            //    promotionShopInfoBll.Update(promotionShopInfoModel);
                            //}
                            //promotionShopInfoModel = new LN.Model.PromotionShopInfo();
                            //promotionShopInfoModel.ACL_ID = aclId;
                            //promotionShopInfoModel.areaid = areaId;
                            //promotionShopInfoModel.CityID = cityId;
                            //promotionShopInfoModel.CustomerCard = dr["直属客户身份"].ToString();
                            //promotionShopInfoModel.DealerID = dr["上级客户编码"].ToString();
                            //promotionShopInfoModel.DealerName = dr["上级客户"].ToString();
                            //promotionShopInfoModel.FXID = dr["直属客户编码"].ToString();
                            //promotionShopInfoModel.FXName = dr["直属客户"].ToString();
                            //promotionShopInfoModel.ProvinceID = provinceId;
                            //promotionShopInfoModel.SaleTypeID = saleTypeId;
                            //promotionShopInfoModel.ShopAddress = dr["店铺营业地址"].ToString();
                            //promotionShopInfoModel.ShopLevelId = shopLevelId;
                            //promotionShopInfoModel.Shopname = dr["店铺名称"].ToString();
                            //promotionShopInfoModel.ShopOwnerShip = dr["店铺产权关系"].ToString();
                            //promotionShopInfoModel.Shopsamplename = dr["店铺名称"].ToString();
                            //promotionShopInfoModel.ShopState = stateId;
                            //promotionShopInfoModel.ShopType = shopTypeId;
                            //promotionShopInfoModel.TCL_ID = tclId;
                            //promotionShopInfoModel.CreateDate = DateTime.Now;
                            //promotionShopInfoModel.PosID = posCode;
                            //shopId = promotionShopInfoBll.Add(promotionShopInfoModel);
                            //newNum++;
                        //}
                        
                        promotionShopModel = new LN.Model.PromotionShops();
                        promotionShopModel.AddDate = DateTime.Now;
                        promotionShopModel.AddUserId = userId;
                       
                        promotionShopModel.CityId = shopInfoModel.CityID;
                        promotionShopModel.PromotionId = pid;
                        promotionShopModel.ProvinceId = shopInfoModel.ProvinceID;
                        promotionShopModel.ShopId = shopInfoModel.ID;
                        promotionShopModel.AreaId = shopInfoModel.areaid;
                        promotionShopModel.BigArea = shopInfoModel.BigArea;
                        promotionShopModel.CustomerCard = shopInfoModel.CustomerCard;
                        promotionShopModel.DealerID = shopInfoModel.DealerID;
                        promotionShopModel.DealerName = shopInfoModel.DealerName;
                        promotionShopModel.FXID = shopInfoModel.FXID;
                        promotionShopModel.FXName = shopInfoModel.FXName;
                        promotionShopModel.LinkMan = shopInfoModel.LinkMan;
                        promotionShopModel.LinkPhone = shopInfoModel.LinkPhone;
                        promotionShopModel.PosID = shopInfoModel.PosID;
                        promotionShopModel.PostAddress = shopInfoModel.PostAddress;
                        promotionShopModel.ShopAddress = shopInfoModel.ShopAddress;
                        promotionShopModel.ShopCategory = shopInfoModel.ShopCategory;
                        promotionShopModel.ShopImageId = shopInfoModel.ShopImageId;
                        promotionShopModel.ShopLevelId = shopInfoModel.ShopLevelId;
                        promotionShopModel.Shopname = shopInfoModel.Shopname;
                        promotionShopModel.ShopOwnerShip = shopInfoModel.ShopOwnerShip;
                        promotionShopModel.Shopsamplename = shopInfoModel.Shopsamplename;
                        promotionShopModel.ShopType = shopInfoModel.ShopType;
                        promotionShopModel.TownId = shopInfoModel.TownID;
                        promotionShopModel.ACL_ID = shopInfoModel.ACL_ID;
                        promotionShopModel.Remark = shopInfoModel.Remark;
                        promotionShopBll.Add(promotionShopModel);
                        successNum++;
                        importShopNo.Add(dr["店铺编号"].ToString());
                    }
                    else
                        failNum++;









                }
                uploadMsg.Style.Add("display", "");
                labTotal.Text = (successNum + failNum).ToString();
                if (successNum == 0)
                {
                    labuploadMsg.Text = "导入失败！";
                }
                else
                    labuploadMsg.Text = failNum == 0 ? "导入成功！" : "部分数据导入失败！";

                labSuccessNum.Text = successNum.ToString();
                labNewNum.Text = newNum.ToString();
                labFailNum.Text = failNum.ToString();

                if (errorData.Length > 0)
                {
                    labErrorMsg.Text = errorData.ToString();
                    errorMsg.Style.Add("display", "");
                }
                else
                {
                    errorMsg.Style.Add("display", "none");
                }
                showButton.Style.Add("display", "");
                showWaiting.Style.Add("display", "none");
                if (successNum == 0)
                {
                    //全部导入失败，算失败
                    Session["uploadstate"] = "fail";
                }
                else
                {
                    //部分导入成功也算成功
                    Session["uploadstate"] = "success";
                }
            }
        }
    }

    /// <summary>
    /// 检查店铺是否存在
    /// </summary>
    /// <param name="posid"></param>
    /// <param name="shopId"></param>
    /// <returns></returns>
    bool CheckShop(string posid, out LN.Model.PromotionShopInfo model)
    {
        model = null;
        model = promotionShopInfoBll.GetModel(" PosID='" + posid + "'");
        if (model!=null)
        {
            return true;
        }
        else
            return false;
    }

    DepartMentInfo areaBll = new DepartMentInfo();
    /// <summary>
    /// 检查大区
    /// </summary>
    /// <param name="name"></param>
    /// <param name="areaId"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 检查省份
    /// </summary>
    /// <param name="name"></param>
    /// <param name="provinceId"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 检查城市
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cityId"></param>
    /// <returns></returns>
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


    PromotionShopLevel levelBll = new PromotionShopLevel();
    /// <summary>
    /// 检查店铺类型
    /// </summary>
    /// <param name="name"></param>
    /// <param name="levelId"></param>
    /// <returns></returns>
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







    void DeleteByPromotionId()
    {
        promotionShopBll.DeleteByPromotionId(pid);
    }



    //bool ShopIsExist(string poscode, out int shopid,out int provinceId,out int cityId)
    //{
    //    shopid = 0;
    //    provinceId = 0;
    //    cityId = 0;
    //    bool flag = false;
    //    DataSet ds = shopBll.GetList(string.Format(" PosID='{0}'", poscode));
    //    if (ds != null && ds.Tables[0].Rows.Count > 0)
    //    {
    //        shopid = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
    //        provinceId = int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString()!=""?ds.Tables[0].Rows[0]["ProvinceID"].ToString():"0");
    //        cityId = int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString() != "" ? ds.Tables[0].Rows[0]["CityID"].ToString() : "0");
    //        flag = true;
    //    }
    //    return flag;
    //}







    #region
    /// <summary>
    /// 检查省
    /// </summary>
    //ProvinceData ProvinceDataBll = new ProvinceData();
    //bool CheckProvinceData(string Provincename, out int provinceId, out int areaId)
    //{
    //    bool flag = false;
    //    areaId = 0;
    //    provinceId = 0;
    //    IList<LN.Model.ProvinceData> list = ProvinceDataBll.GetList(string.Format(" ProvinceName='{0}'", Provincename));
    //    if (list.Count > 0)
    //    {
    //        provinceId = list[0].ProvinceID;
    //        areaId = list[0].AreaID ?? 0;
    //        flag = true;
    //    }
    //    return flag;
    //}

    ///// <summary>
    ///// 检查城市
    ///// </summary>
    //CityData CityDataBll = new CityData();
    //bool CheckCityData(string Cityname, int provinceId, out int cityId)
    //{
    //    bool flag = false;
    //    cityId = 0;
    //    IList<LN.Model.CityData> list = CityDataBll.GetList(string.Format(" CityName='{0}' and ProvinceID={1}", Cityname, provinceId));
    //    if (list.Count > 0)
    //    {
    //        cityId = list[0].CItyID;
    //        flag = true;
    //    }
    //    return flag;
    //}

    ///// <summary>
    ///// 检查县
    ///// </summary>
    //TownData TownDataBll = new TownData();
    //bool CheckTownData(string Townname, int cityId, out int townId)
    //{
    //    bool flag = false;
    //    townId = 0;
    //    IList<LN.Model.TownData> list = TownDataBll.GetList(string.Format(" TownName='{0}' and CityID={1}", Townname, cityId));
    //    if (list.Count > 0)
    //    {
    //        townId = list[0].TownID ?? 0;
    //        flag = true;
    //    }
    //    return flag;
    //}
    #endregion
    /// <summary>
    /// 下载模板
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_DownLoadPropTemplate_Click(object sender, EventArgs e)
    {
        string path = ConfigurationManager.AppSettings["POPShopsTemplate"].ToString();
        UploadFileHelper.DownLoadFile(path);
    }

    bool GetShopsByCondition()
    {
        string ShopST = hfShopST.Value;
        string Shoplevel = hfShoplevel.Value;
        string ShopType = hfShopType.Value;
        string ShopVI = hfShopVI.Value;
        //string ACL = hfACL.Value;
        //string TCL = hfTCL.Value;
        string Region = hfRegion.Value;
        string Province = hfProvince.Value;
        StringBuilder where = new StringBuilder();
        where.Append(" 1=1");
        if (!string.IsNullOrWhiteSpace(ShopST))
        {
            ShopST = ShopST.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.SaleTypeID in({0})", ShopST);
        }
        if (!string.IsNullOrWhiteSpace(Shoplevel))
        {
            Shoplevel = Shoplevel.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ShopLevelId in({0})", Shoplevel);
        }
        if (!string.IsNullOrWhiteSpace(ShopType))
        {
            ShopType = ShopType.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ShopType in({0})", ShopType);
        }
        if (!string.IsNullOrWhiteSpace(ShopVI))
        {
            ShopVI = ShopVI.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ShopImageId in({0})", ShopVI);
        }
        //if (!string.IsNullOrWhiteSpace(ACL))
        //{
        //    ACL = ACL.TrimEnd(',');
        //    where.AppendFormat(" and PromotionShopInfo.ACL_ID in({0})", ACL);
        //}
        //if (!string.IsNullOrWhiteSpace(TCL))
        //{
        //    TCL = TCL.TrimEnd(',');
        //    where.AppendFormat(" and PromotionShopInfo.TCL_ID in({0})", TCL);
        //}
        if (!string.IsNullOrWhiteSpace(Province))
        {
            Province = Province.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ProvinceID in({0})", Province);
        }
        else if (!string.IsNullOrWhiteSpace(Region))
        {
            Region = Region.TrimEnd(',');
            //ProvinceData provinceBll = new ProvinceData();
            //IList<LN.Model.ProvinceData> list = provinceBll.GetList(string.Format(" AreaID in ({0})", Region));
            //if (list.Count > 0)
            //{
            //    list.ToList().ForEach(s =>
            //    {
            //        Province += s.ProvinceID + ",";
            //    });
            //    if (!string.IsNullOrWhiteSpace(Province))
            //    {
            //        Province = Province.TrimEnd(',');
            //        where.AppendFormat(" and ProvinceID in({0})", Province);
            //    }
            //}
            where.AppendFormat(" and PromotionShopInfo.areaid in({0})", Region);
        }
        DataSet ds = new LN.BLL.PromotionShopInfo().GetList(where.ToString());
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            DeleteByPromotionId();//
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                promotionShopModel = new LN.Model.PromotionShops();
                promotionShopModel.AddDate = DateTime.Now;
                promotionShopModel.AddUserId = userId;
                promotionShopModel.AreaId = 0;
                promotionShopModel.CityId = dr["CityID"].ToString() != "" ? int.Parse(dr["CityID"].ToString()) : 0;
                promotionShopModel.PromotionId = pid;
                promotionShopModel.ProvinceId = dr["ProvinceID"].ToString() != "" ? int.Parse(dr["ProvinceID"].ToString()) : 0;
                promotionShopModel.ShopId = int.Parse(dr["ID"].ToString());
                promotionShopModel.TownId = dr["TownID"].ToString() != "" ? int.Parse(dr["TownID"].ToString()) : 0; ;
                promotionShopBll.Add(promotionShopModel);
            }
            return true;
        }
        else
            return false;


    }


    protected void BtnNext_Click(object sender, EventArgs e)
    {

        switch (rblSelectType.SelectedValue)
        {
            //全部店面
            case "0":
                DataSet ds = new PromotionShopInfo().GetList("");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DeleteByPromotionId();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        promotionShopModel = new LN.Model.PromotionShops();
                        promotionShopModel.AddDate = DateTime.Now;
                        promotionShopModel.AddUserId = userId;
                        promotionShopModel.AreaId = 0;
                        promotionShopModel.CityId = dr["CityID"].ToString() != "" ? int.Parse(dr["CityID"].ToString()) : 0;
                        promotionShopModel.PromotionId = pid;
                        promotionShopModel.ProvinceId = dr["ProvinceID"].ToString() != "" ? int.Parse(dr["ProvinceID"].ToString()) : 0;
                        promotionShopModel.ShopId = int.Parse(dr["ID"].ToString());
                        promotionShopModel.TownId = dr["TownID"].ToString() != "" ? int.Parse(dr["TownID"].ToString()) : 0; ;
                        promotionShopBll.Add(promotionShopModel);
                    }

                }
                UpdatePromotion();
                Response.Redirect("PromotionFive.aspx?id=" + pid, false);
                break;
            //按条件
            case "1":
                if (GetShopsByCondition())
                {
                    UpdatePromotion();
                    Response.Redirect("PromotionFive.aspx?id=" + pid, false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "ShowMsg('没有符合条件的店铺信息')", true);
                }
                break;
            //手动导入
            case "2":
                if (Session["uploadstate"] != null && Session["uploadstate"].ToString() == "success")
                {
                    UpdatePromotion();
                    Response.Redirect("PromotionFive.aspx?id=" + pid, false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "ShowMsg('导入失败，请重新导入！')", true);
                }
                break;

        }
    }

    /// <summary>
    /// 选择店铺后，表示提交完成
    /// </summary>
    void UpdatePromotion()
    {
        LN.Model.Promotion promotionModel = new LN.Model.Promotion();
        promotionModel.State = 1;//1：提交成功
        promotionModel.Id = pid;
        new Promotion().Update(promotionModel);
    }


    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionTwo.aspx?id=" + pid, false);
    }
    protected void lbJump_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionFive.aspx?id=" + pid, false);
    }
}