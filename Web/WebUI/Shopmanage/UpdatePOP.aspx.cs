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

public partial class WebUI_Shopmanage_UpdatePOP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
        if (Request.QueryString["import"] != null)
        {
            string num = Request.QueryString["successNum"];
            Label1.Text = "更新成功！完成数量：" + num;
        }
    }

    POPInfo popBll = new POPInfo();
    DataColumnCollection cols;
    protected void btnUpLoad_Click(object sender, EventArgs e)
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
            if (path != "")
            {
                path = Server.MapPath(path);
                excelConnString = excelConnString.Replace("ExcelPath", path);
                OleDbConnection conn;
                OleDbDataAdapter da;
                conn = new OleDbConnection(excelConnString);
                conn.Open();
                //DataTable dt = conn.GetSchema("Tables");
                string sql = "select * from [Sheet1$]";
                da = new OleDbDataAdapter(sql, conn);
                excelDs = new DataSet();
                da.Fill(excelDs);
                da.Dispose();
                if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
                {
                    cols = excelDs.Tables[0].Columns;

                    LN.Model.POPInfo popModel;
                    int successNum = 0;
                    foreach (DataRow dr in excelDs.Tables[0].Rows)
                    {
                        int shopId = 0;
                        string shopNo = string.Empty;
                        string popNo = string.Empty;
                        string popType = string.Empty;
                        string positionDescribe = string.Empty;
                        string material = string.Empty;
                        string materialRemark = string.Empty;
                        string realWidth = string.Empty;
                        string realHeight = string.Empty;
                        string popWidth = string.Empty;
                        string popHeight = string.Empty;
                        string popPlace = string.Empty;
                        string count = string.Empty;
                        string area = string.Empty;
                        string sexArea = string.Empty;
                        if (cols.Contains("编号"))
                        {
                            shopNo = dr["编号"].ToString();
                        }
                        else if (cols.Contains("店铺编号"))
                        {
                            shopNo = dr["店铺编号"].ToString();
                        }
                        if (cols.Contains("POP编号"))
                        {
                            popNo = dr["POP编号"].ToString();
                        }
                        else if (cols.Contains("pop编号"))
                        {
                            popNo = dr["pop编号"].ToString();
                        }
                        if (cols.Contains("POP类型"))
                        {
                            popType = dr["POP类型"].ToString();
                        }
                        else if (cols.Contains("pop类型"))
                        {
                            popType = dr["pop类型"].ToString();
                        }
                        if (cols.Contains("位置描述"))
                        {
                            positionDescribe = dr["位置描述"].ToString();
                        }
                        if (cols.Contains("POP材质"))
                        {
                            material = dr["POP材质"].ToString();
                        }
                        else if (cols.Contains("pop材质"))
                        {
                            material = dr["pop材质"].ToString();
                        }
                        if (cols.Contains("材质备注"))
                        {
                            materialRemark = dr["材质备注"].ToString();
                        }
                        if (cols.Contains("POP实际制作宽mm"))
                        {
                            realWidth = dr["POP实际制作宽mm"].ToString();
                        }
                        else if (cols.Contains("POP实际制作宽"))
                        {
                            realWidth = dr["POP实际制作宽"].ToString();
                        }
                        else if (cols.Contains("pop实际制作宽mm"))
                        {
                            realWidth = dr["pop实际制作宽mm"].ToString();
                        }
                        else if (cols.Contains("pop实际制作宽"))
                        {
                            realWidth = dr["pop实际制作宽"].ToString();
                        }



                        if (cols.Contains("POP实际制作高mm"))
                        {
                            realHeight = dr["POP实际制作高mm"].ToString();
                        }
                        else if (cols.Contains("POP实际制作高"))
                        {
                            realHeight = dr["POP实际制作高"].ToString();
                        }
                        else if (cols.Contains("pop实际制作高mm"))
                        {
                            realHeight = dr["pop实际制作高mm"].ToString();
                        }
                        else if (cols.Contains("pop实际制作高"))
                        {
                            realHeight = dr["pop实际制作高"].ToString();
                        }


                        if (cols.Contains("POP可视画面宽mm"))
                        {
                            popWidth = dr["POP可视画面宽mm"].ToString();
                        }
                        else if (cols.Contains("POP可视画面宽"))
                        {
                            popWidth = dr["POP可视画面宽"].ToString();
                        }
                        else if (cols.Contains("pop可视画面宽mm"))
                        {
                            popWidth = dr["pop可视画面宽mm"].ToString();
                        }
                        else if (cols.Contains("pop可视画面宽"))
                        {
                            popWidth = dr["pop可视画面宽"].ToString();
                        }


                        if (cols.Contains("POP可视画面高mm"))
                        {
                            popHeight = dr["POP可视画面高mm"].ToString();
                        }
                        else if (cols.Contains("POP可视画面高"))
                        {
                            popHeight = dr["POP可视画面高"].ToString();
                        }
                        else if (cols.Contains("pop可视画面高mm"))
                        {
                            popHeight = dr["pop可视画面高mm"].ToString();
                        }
                        else if (cols.Contains("pop可视画面高"))
                        {
                            popHeight = dr["pop可视画面高"].ToString();
                        }


                        if (cols.Contains("POP可视画面位置"))
                        {
                            popPlace = dr["POP可视画面位置"].ToString();
                        }
                        else if (cols.Contains("pop可视画面位置"))
                        {
                            popPlace = dr["pop可视画面位置"].ToString();
                        }

                        if (cols.Contains("数量"))
                        {
                            count = dr["数量"].ToString();
                        }

                        if (cols.Contains("POP面积"))
                        {
                            area = dr["POP面积"].ToString();
                        }
                        else if (cols.Contains("pop面积"))
                        {
                            area = dr["pop面积"].ToString();
                        }
                        if (cols.Contains("男女区域"))
                        {
                            sexArea = dr["男女区域"].ToString();
                        }
                        bool canSave = true;
                        if (string.IsNullOrWhiteSpace(shopNo))
                        {
                            canSave = false;
                        }
                        else if (!GetShopId(shopNo, dr, out shopId))
                        {
                            canSave = false;
                        }

                        if (canSave)
                        {

                            bool update = false;
                            popModel = new LN.Model.POPInfo();
                            if (!string.IsNullOrWhiteSpace(popNo))
                            {
                                DataSet popDs = popBll.GetDSList(string.Format(" ShopID={0} and SeatNum={1}", shopId, popNo));
                                if (popDs != null && popDs.Tables[0].Rows.Count > 0)
                                {
                                    int popId = int.Parse(popDs.Tables[0].Rows[0]["ID"].ToString());
                                    popModel = popBll.GetModel(popId);
                                    if (popModel != null)
                                        update = true;
                                }
                            }
                            else
                            {
                                int popNum = popBll.GetMaxPOPNumByShopId(shopId);
                                popNo = (popNum + 1).ToString();
                            }

                            popModel.POPArea = StringHelper.ToDecimal(area);
                            popModel.POPHeight = StringHelper.ToDecimal(popHeight);
                            popModel.POPMaterial = material;
                            popModel.POPMaterialRemark = materialRemark;
                            popModel.POPPlwz = popPlace;
                            popModel.POPWith = StringHelper.ToDecimal(popWidth);
                            popModel.RealHeight = StringHelper.ToDecimal(realHeight);
                            popModel.RealWith = StringHelper.ToDecimal(realWidth);
                            if (!string.IsNullOrWhiteSpace(popType))
                                popModel.POPSeat = popType;
                            popModel.SeatDesc = positionDescribe;
                            popModel.Sexarea = sexArea;

                            if (update)
                            {
                                popBll.Update(popModel);
                            }
                            else
                            {
                                popModel.ShopID = shopId;
                                popModel.SeatNum = popNo;
                                popModel.AddState = "新增";
                                popModel.ExamState = 1;
                                popModel.Glass = 0;
                                popModel.IsHide = 0;
                                popModel.IsSubmit = 0;
                                popModel.PlatformHeight = 0;
                                popModel.PlatformLong = 0;
                                popModel.PlatformWith = 0;
                                popModel.POPPljd = 0;
                                popModel.SysTime = DateTime.Now.ToShortDateString();
                                popModel.VMExamState = 1;

                                popBll.Add(popModel);
                            }
                            successNum++;
                        }
                    }



                    Response.Redirect("UpdatePOP.aspx?import=1&successNum=" + successNum, false);
                }
            }
        }
    }


    Dictionary<string, int> shopDic = new Dictionary<string, int>();
    ShopInfo shopBll = new ShopInfo();
    bool GetShopId(string shopNo, DataRow dr, out int shopId)
    {
        shopId = 0;
        bool flag = false;
        if (shopDic.Keys.Contains(shopNo.ToUpper()))
        {
            shopId = shopDic[shopNo.ToUpper()];
            flag = true;
        }
        else
        {
            DataSet ds = shopBll.GetList(string.Format(" PosID='{0}'", shopNo));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                shopId = int.Parse(ds.Tables[0].Rows[0]["ShopID"].ToString());
                flag = true;

            }
            else
            {
                shopId = AddShop(shopNo, dr);
                flag = true;
            }
            if (!shopDic.Keys.Contains(shopNo.ToUpper()))
                shopDic.Add(shopNo.ToUpper(), shopId);
        }
        return flag;
    }

    int AddShop(string shopNo, DataRow dr)
    {
        string ShopName = string.Empty;
        string Shopsamplename = string.Empty;
        string PostAddress = string.Empty;
        string City = string.Empty;

        string TCL = string.Empty;
        string Town = string.Empty;
        string ACL = string.Empty;
        string Province = string.Empty;
        string Area = string.Empty;
        string Department = string.Empty;
        string ShopType = string.Empty;
        string ShopOwnerShip = string.Empty;
        string SaleType = string.Empty;
        string ShopLevel = string.Empty;
        string ShopVI = string.Empty;
        string ShopState = string.Empty;
        string ShopArea = string.Empty;
        string CustomerCard = string.Empty;
        //直属
        string FXID = string.Empty;
        string FXName = string.Empty;
        //一级客户
        string DealerID = string.Empty;
        string DealerName = string.Empty;

        string CustomerGroupID = string.Empty;
        string Install = string.Empty;
        string supplier = string.Empty;
        if (cols.Contains("店铺名称"))
            ShopName = dr["店铺名称"].ToString();
        if (cols.Contains("店铺简称"))
            Shopsamplename = dr["店铺简称"].ToString();
        if (cols.Contains("店铺邮政地址"))
            PostAddress = dr["店铺邮政地址"].ToString();
        if (cols.Contains("地市级城市名称"))
            City = dr["地市级城市名称"].ToString();
        if (cols.Contains("地市级城市级别_市场定义"))
            TCL = dr["地市级城市级别_市场定义"].ToString();
        if (cols.Contains("区县级城市名称"))
            Town = dr["区县级城市名称"].ToString();
        if (cols.Contains("区县级城市级别_市场定义"))
            ACL = dr["区县级城市级别_市场定义"].ToString();
        if (cols.Contains("省名称"))
            Province = dr["省名称"].ToString();
        if (cols.Contains("区域名称"))
            Area = dr["区域名称"].ToString();
        if (cols.Contains("部门名称"))
            Department = dr["部门名称"].ToString();
        if (cols.Contains("店铺类型"))
            ShopType = dr["店铺类型"].ToString();
        if (cols.Contains("店铺产权关系"))
            ShopOwnerShip = dr["店铺产权关系"].ToString();
        if (cols.Contains("店铺零售属性"))
            SaleType = dr["店铺零售属性"].ToString();
        if (cols.Contains("店铺级别"))
            ShopLevel = dr["店铺级别"].ToString();
        if (cols.Contains("店铺形象属性"))
            ShopVI = dr["店铺形象属性"].ToString();
        if (cols.Contains("店铺状态"))
            ShopState = dr["店铺状态"].ToString();
        if (cols.Contains("营业面积"))
            ShopArea = dr["营业面积"].ToString();
        if (cols.Contains("客户身份"))
            CustomerCard = dr["客户身份"].ToString();
        if (cols.Contains("直属客户编号"))
            FXID = dr["直属客户编号"].ToString();
        if (cols.Contains("直属客户名"))
            FXName = dr["直属客户名"].ToString();
        if (cols.Contains("一级客户编号"))
            DealerID = dr["一级客户编号"].ToString();
        if (cols.Contains("一级客户名"))
            DealerName = dr["一级客户名"].ToString();
        if (cols.Contains("上级客户集团编号"))
            CustomerGroupID = dr["上级客户集团编号"].ToString();
        if (cols.Contains("是否李宁公司统一支持安装"))
            Install = dr["是否李宁公司统一支持安装"].ToString();

        //supplier = dr["供应商"].ToString();



        LN.Model.ShopInfo shopModel = new LN.Model.ShopInfo();
        shopModel.ACL_ID = GetACLId(ACL);
        shopModel.AreaID = GetAreaId(Area);
        shopModel.Boolinstall = string.IsNullOrWhiteSpace(Install) ? 0 : int.Parse(Install);
        shopModel.CityID = GetCityId(City);
        shopModel.CustomerCard = CustomerCard;
        shopModel.CustomerGroupID = CustomerGroupID;
        shopModel.DealerID = DealerID;
        shopModel.ExamState = 1;
        shopModel.PosID = shopNo;
        shopModel.PostAddress = PostAddress;
        shopModel.ProvinceID = GetProvinceId(Province);
        shopModel.SaleTypeID = GetSaleTypeId(SaleType);
        shopModel.ShopArea = !string.IsNullOrWhiteSpace(ShopArea) ? decimal.Parse(ShopArea) : 0;
        shopModel.ShopLevelID = GetShopLevelId(ShopLevel);
        shopModel.Shopname = ShopName;
        shopModel.ShopOwnerShip = ShopOwnerShip;
        shopModel.ShopSampleName = Shopsamplename;
        shopModel.ShopState = GetShopStateId(ShopState);
        shopModel.ShopType = GetShopTypeId(ShopType);
        shopModel.ShopVI = GetShopVIId(ShopVI);
        shopModel.TCL_ID = GetTCLId(TCL);
        shopModel.TownID = GetTownId(Town, shopModel.CityID);

        return new ShopInfo().Add(shopModel);

    }

    Dictionary<string, int> cityDic = new Dictionary<string, int>();
    Dictionary<string, int> provinceDic = new Dictionary<string, int>();
    Dictionary<string, int> areaDic = new Dictionary<string, int>();
    Dictionary<string, int> departmentDic = new Dictionary<string, int>();
    Dictionary<string, int> aclDic = new Dictionary<string, int>();
    Dictionary<string, int> tclDic = new Dictionary<string, int>();
    int GetCityId(string city)
    {
        int cityId = 0;
        if (cityDic.Keys.Contains(city))
        {
            cityId = cityDic[city];
        }
        else
        {
            IList<LN.Model.CityData> list = new CityData().GetList(string.Format(" CityName='{0}'", city));
            if (list.Any())
            {
                cityId = list[0].CItyID;
                cityDic.Add(city, cityId);
            }
        }
        return cityId;
    }

    int GetProvinceId(string province)
    {
        int provinceId = 0;
        if (provinceDic.Keys.Contains(province))
        {
            provinceId = provinceDic[province];
        }
        else
        {
            IList<LN.Model.ProvinceData> list = new ProvinceData().GetList(string.Format(" ProvinceName='{0}'", province));
            if (list.Any())
            {
                provinceId = list[0].ProvinceID;
                provinceDic.Add(province, provinceId);
            }
        }
        return provinceId;
    }

    int GetAreaId(string area)
    {
        int areaId = 0;
        if (areaDic.Keys.Contains(area))
        {
            areaId = areaDic[area];
        }
        else
        {
            IList<LN.Model.AreaData> list = new AreaData().GetList(string.Format(" AreaName='{0}'", area));
            if (list.Any())
            {
                areaId = list[0].AreaID;
                areaDic.Add(area, areaId);
            }
        }
        return areaId;
    }

    int GetDepartmentId(string department)
    {
        int departId = 0;
        if (departmentDic.Keys.Contains(department))
        {
            departId = departmentDic[department];
        }
        else
        {
            DataSet ds = new DepartMentInfo().GetList(string.Format(" department='{0}'", department));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                departId = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                departmentDic.Add(department, departId);
            }
        }
        return departId;
    }

    int GetTownId(string town, int cityId)
    {
        int townId = 0;
        IList<LN.Model.TownData> list = new TownData().GetList(string.Format(" TownName='{0}' and CityID={1}", town, cityId));
        if (list.Any())
            townId = list[0].TownID ?? 0;
        return townId;
    }

    int GetACLId(string acl)
    {
        int aclId = 0;
        if (aclDic.Keys.Contains(acl))
        {
            aclId = aclDic[acl];
        }
        else
        {
            IList<LN.Model.AreaCityLevel> list = new AreaCityLevel().GetList(string.Format(" ACL_Name='{0}'", acl));
            if (list.Any())
            {
                aclId = list[0].ACL_Id;
                aclDic.Add(acl, aclId);
            }
        }
        return aclId;
    }

    int GetTCLId(string tcl)
    {
        int tclId = 0;
        if (tclDic.Keys.Contains(tcl))
        {
            tclId = tclDic[tcl];
        }
        else
        {
            IList<LN.Model.TownCityLevel> list = new TownCityLevel().GetList(string.Format(" TCL_Name='{0}'", tcl));
            if (list.Any())
            {
                tclId = list[0].TCL_Id;
                tclDic.Add(tcl, tclId);
            }
        }
        return tclId;
    }



    Dictionary<string, int> shopLevelDic = new Dictionary<string, int>();
    Dictionary<string, int> shopVIDic = new Dictionary<string, int>();
    Dictionary<string, int> shopTypeDic = new Dictionary<string, int>();
    Dictionary<string, int> shopStateDic = new Dictionary<string, int>();
    Dictionary<string, int> saleTypeDic = new Dictionary<string, int>();

    int GetShopTypeId(string type)
    {
        int typeId = 0;
        if (shopTypeDic.Keys.Contains(type))
        {
            typeId = shopTypeDic[type];
        }
        else
        {
            List<LN.Model.ShopType> list = new ShopType().GetList(string.Format(" ShopTypename='{0}'", type));
            if (list.Any())
            {
                typeId = list[0].ID;
                shopTypeDic.Add(type, typeId);
            }
        }
        return typeId;
    }

    int GetSaleTypeId(string saleType)
    {
        int saleId = 0;
        if (saleTypeDic.Keys.Contains(saleType))
        {
            saleId = saleTypeDic[saleType];
        }
        else
        {
            DataSet ds = new SaleTypeInfo().GetList(string.Format(" SaleType='{0}'", saleType));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                saleId = int.Parse(ds.Tables[0].Rows[0]["SaleTypeID"].ToString());
                saleTypeDic.Add(saleType, saleId);
            }
        }
        return saleId;
    }

    int GetShopLevelId(string level)
    {
        int levelId = 0;
        if (shopLevelDic.Keys.Contains(level))
        {
            levelId = shopLevelDic[level];
        }
        else
        {
            DataSet ds = new ShopLevel().GetList(string.Format(" ShopLevel='{0}'", level));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                levelId = int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
                shopLevelDic.Add(level, levelId);
            }
        }
        return levelId;
    }

    int GetShopVIId(string vi)
    {
        int viId = 0;
        if (shopVIDic.Keys.Contains(vi))
        {
            viId = shopVIDic[vi];
        }
        else
        {
            List<LN.Model.ShopVI> list = new ShopVI().GetList(string.Format(" ShopVIName='{0}'", vi));
            if (list.Any())
            {
                viId = list[0].ShopVIID;
                shopVIDic.Add(vi, viId);
            }
        }
        return viId;
    }

    int GetShopStateId(string state)
    {
        int stateId = 0;
        if (shopStateDic.Keys.Contains(state))
        {
            stateId = shopStateDic[state];
        }
        else
        {
            DataSet ds = new ShopStateInfo().GetList(string.Format(" ShopState='{0}'", state));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                stateId = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                shopStateDic.Add(state, stateId);
            }
        }
        return stateId;
    }
}

