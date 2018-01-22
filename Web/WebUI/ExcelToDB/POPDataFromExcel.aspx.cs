using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using LN.DBUtility;
using LN.BLL;
using System.Linq;
public partial class WebUI_ExcelToDB_DataFromExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void GetExcelData(string filepath)
    {
        System.Data.OleDb.OleDbConnection conn = new OleDbConnection();
        System.Data.OleDb.OleDbDataReader reader = null;
        System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
        string connstr = null;
        DataSet ds = new DataSet();
        DataTable table = new DataTable();
        try
        {

            //设置连接字符串。

            connstr = "Data Source=" + filepath + ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;";

            //打开连接
            conn.ConnectionString = connstr;
            conn.Open();

            //设置命令属性。

            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from [sheet1$]";

            //读数据

            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (reader.HasRows)
            {
                DataTable schematable = reader.GetSchemaTable();


                for (int i = 0; i < schematable.Rows.Count; i++)
                {
                    DataColumn column = new DataColumn();
                    column.ColumnName = reader.GetName(i);
                    table.Columns.Add(column);
                }
                ds.Tables.Add(table);

                //get data
                DataRowCollection rc = table.Rows;
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        row[i] = reader.GetValue(i);
                    }
                    rc.Add(row);
                }



            }
        }
        catch
        {
        }
        finally
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
        if (table.Rows.Count > 0)
        {
            GridView1.DataSource = table;
            GridView1.DataBind();
            List<string> insertSql = new List<string>();
            StringBuilder sb = null;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sb = new StringBuilder();

                sb.Append("insert into popinfo select (");
                sb.Append(string.Format("select top 1 shopid from shopinfo where posid='{0}'),", table.Rows[i]["店铺编号"].ToString()));
                sb.Append(string.Format("'{0}',", table.Rows[i]["POP位置编号"].ToString()));
                sb.Append(string.Format("'{0}',", table.Rows[i]["POP类型"].ToString()));
                sb.Append(string.Format("'{0}',", table.Rows[i]["位置描述"].ToString()));
                sb.Append(table.Rows[i]["实际高mm"].ToString() == "" ? "0," : table.Rows[i]["实际高mm"].ToString() + ",");
                sb.Append(table.Rows[i]["实际宽mm"].ToString() == "" ? "0," : table.Rows[i]["实际宽mm"].ToString() + ",");
                sb.Append(table.Rows[i]["画面高mm"].ToString() == "" ? "0," : table.Rows[i]["画面高mm"].ToString() + ",");
                sb.Append(table.Rows[i]["画面宽mm"].ToString() == "" ? "0," : table.Rows[i]["画面宽mm"].ToString() + ",");
                sb.Append(table.Rows[i]["POP面积"].ToString() == "" ? "0," : table.Rows[i]["POP面积"].ToString() + ",");
                sb.Append(string.Format("'{0}',", table.Rows[i]["POP材质"].ToString()));
                sb.Append(string.Format("(select top 1 ProductLineID from View_ProductLine where ProductTypeName='{0}' and ProductLine='{1}'), ", table.Rows[i]["故事包大类"].ToString(), table.Rows[i]["POP故事包"].ToString()));
                sb.Append(string.Format("'{0}',", table.Rows[i]["男女区域"].ToString()));
                sb.Append("0,0,");
                sb.Append(table.Rows[i]["橱窗进深mm"].ToString() == "" ? "0," : table.Rows[i]["橱窗进深mm"].ToString() + ",");
                sb.Append(table.Rows[i]["橱窗长度mm"].ToString() == "" ? "0," : table.Rows[i]["橱窗长度mm"].ToString() + ",");
                sb.Append(table.Rows[i]["橱窗面积"].ToString() == "" ? "0," : table.Rows[i]["橱窗面积"].ToString() + ",");
                sb.Append("1,null,'',getdate(),null");


                insertSql.Add(sb.ToString());
            }
            LN.DBUtility.DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), insertSql);
        }
    }
    protected void Btn_show_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (fileExt.Equals(".xls") || fileExt.Equals(".xlsx"))
            {
                string savefile = DateTime.Now.Ticks.ToString() + fileExt;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("uploadexcel//") + savefile);
                Session["filename"] = null;
                Session["filename"] = savefile;

                //GetExcelData(Server.MapPath("uploadexcel//" + Session["filename"].ToString()));
                //ToDB(Server.MapPath("uploadexcel//" + Session["filename"].ToString()));
                UpdatePOPInfo(Server.MapPath("uploadexcel//" + Session["filename"].ToString()));
            }
        }
    }


    void ToDB(string path)
    {
        System.Data.OleDb.OleDbConnection conn = new OleDbConnection();
        System.Data.OleDb.OleDbDataReader reader = null;
        System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
        string connstr = null;
        DataSet ds = new DataSet();
        DataTable table = new DataTable();
        connstr = "Data Source=" + path + ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;";

        //打开连接
        conn.ConnectionString = connstr;
        conn.Open();

        //设置命令属性。

        cmd.Connection = conn;
        cmd.CommandText = "SELECT * from [sheet1$]";
        reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        int updateNum = 0;
        int newNum = 0;
        while (reader.Read())
        {
            string shopNo = reader["店铺编号"].ToString();
            string popCode = reader["POP编号"].ToString();
            int shopid = 0;
            int popid = getPOPId(shopNo, popCode, out shopid);
            if (popid > 0)
            {
                LN.Model.POPInfo popModel = popBll.GetModel(popid);
                if (popModel != null)
                {
                    popModel.Glass = int.Parse(reader["玻璃"].ToString() != "" ? reader["玻璃"].ToString() : "0");
                    popModel.POPHeight = decimal.Parse(reader["画面高mm"].ToString() != "" ? reader["画面高mm"].ToString() : "0");
                    popModel.POPMaterial = reader["POP材质"].ToString();
                    popModel.POPMaterialRemark = reader["材质备注"].ToString();
                    popModel.POPSeat = reader["POP类型"].ToString();
                    popModel.POPWith = decimal.Parse(reader["画面宽mm"].ToString() != "" ? reader["画面宽mm"].ToString() : "0");
                    popModel.RealHeight = decimal.Parse(reader["实际高mm"].ToString() != "" ? reader["实际高mm"].ToString() : "0");
                    popModel.RealWith = decimal.Parse(reader["实际宽mm"].ToString() != "" ? reader["实际宽mm"].ToString() : "0");
                    popModel.SeatDesc = reader["位置描述"].ToString();
                    decimal POPArea = reader["实际高mm"].ToString() != "" && reader["实际宽mm"].ToString() != "" ? decimal.Parse(reader["实际高mm"].ToString()) * decimal.Parse(reader["实际宽mm"].ToString()) / 1000000 : 0;
                    popModel.POPArea = decimal.Parse(POPArea.ToString("#0.00"));
                    //popModel.SeatNum = reader["POP编号"].ToString();
                    popModel.Sexarea = reader["男女区域"].ToString();
                    popModel.SysTime = DateTime.Now.ToLongDateString();
                    popModel.TwoSided = int.Parse(reader["是否为双面"].ToString() != "" ? reader["是否为双面"].ToString() : "0");
                    popModel.ID = popid;
                    popBll.UpdatePOP(popModel);
                    updateNum++;
                }

            }
            else
            {
                LN.Model.POPInfo popModel = new LN.Model.POPInfo();
                popModel.Glass = int.Parse(reader["玻璃"].ToString() != "" ? reader["玻璃"].ToString() : "0");
                popModel.POPHeight = decimal.Parse(reader["画面高mm"].ToString() != "" ? reader["画面高mm"].ToString() : "0");
                popModel.POPMaterial = reader["POP材质"].ToString();
                popModel.POPMaterialRemark = reader["材质备注"].ToString();
                popModel.POPSeat = reader["POP类型"].ToString();
                popModel.POPWith = decimal.Parse(reader["画面宽mm"].ToString() != "" ? reader["画面宽mm"].ToString() : "0");
                popModel.RealHeight = decimal.Parse(reader["实际高mm"].ToString() != "" ? reader["实际高mm"].ToString() : "0");
                popModel.RealWith = decimal.Parse(reader["实际宽mm"].ToString() != "" ? reader["实际宽mm"].ToString() : "0");
                popModel.SeatDesc = reader["位置描述"].ToString();
                popModel.SeatNum = reader["POP编号"].ToString();
                popModel.Sexarea = reader["男女区域"].ToString();
                popModel.SysTime = DateTime.Now.ToLongDateString();
                popModel.TwoSided = int.Parse(reader["是否为双面"].ToString() != "" ? reader["是否为双面"].ToString() : "0");
                popModel.ShopID = shopid;
                popModel.AddState = DateTime.Now.ToLongDateString();
                popModel.ExamState = 1;
                popModel.IsHide = 0;
                decimal POPArea = reader["实际高mm"].ToString() != "" && reader["实际宽mm"].ToString() != "" ? decimal.Parse(reader["实际高mm"].ToString()) * decimal.Parse(reader["实际宽mm"].ToString()) / 1000000 : 0;
                popModel.POPArea = decimal.Parse(POPArea.ToString("#0.00"));
                popModel.VMExamState = 1;
                popBll.Add(popModel);
                newNum++;
            }
        }
        labUpdate.Text = "更新数量：" + updateNum;
        labNew.Text = "新增数量：" + newNum;
    }

    POPInfo popBll = new POPInfo();
    ShopInfo shop = new ShopInfo();
    LN.Model.POPInfo popInfoModel;
    LN.Model.ShopInfo shopInfoModel;
    int getPOPId(string shopNo, string popCode, out int shopid)
    {
        DataSet ds = new DataSet();

        int popId = 0;
        shopid = 0;
        ds = shop.GetList(string.Format(" PosID='{0}'", shopNo));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            shopid = int.Parse(ds.Tables[0].Rows[0]["ShopID"].ToString());
            List<LN.Model.POPInfo> list = popBll.GetList(string.Format(" ShopID={0} and SeatNum={1}", shopid, popCode));
            if (list.Count > 0)
            {
                popId = list[0].ID;
            }
        }
        return popId;
    }


    void UpdatePOPInfo(string path)
    {
        System.Data.OleDb.OleDbConnection conn = new OleDbConnection();
        //System.Data.OleDb.OleDbDataReader reader = null;
        System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
        string connstr = null;
        DataSet ds = new DataSet();
        DataTable table = new DataTable();
        //connstr = "Data Source=" + path + ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;";
        connstr = "Provider=Microsoft.Ace.OleDb.12.0;data source=" + path + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=1'";
        //打开连接
        conn.ConnectionString = connstr;
        conn.Open();

        //设置命令属性。

        cmd.Connection = conn;
        OleDbDataAdapter da;
        DataTable dt = conn.GetSchema("Tables");
        Dictionary<string, int> shopDic = new Dictionary<string, int>();
        StringBuilder stateMsg = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            string sheetName = dt.Rows[i]["TABLE_NAME"].ToString();
            int updateNum = 0;
            int newNum = 0;
            if (sheetName.IndexOf("FilterDatabase") == -1)
            {
                string sql = "select * from [" + sheetName + "]";
                da = new OleDbDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        string shopNo = dr["店铺编号"].ToString();
                        string shopName = dr["店铺名称"].ToString();
                        string shopShortName = dr["店铺简称"].ToString();
                        string postAddress = dr["店铺邮政地址"].ToString();
                        string city = dr["地市级城市名称"].ToString();//找id
                        string TCL_IDName = dr["地市级城市级别_市场定义"].ToString();//找id
                        string Town = dr["区县级城市名称"].ToString();//找id
                        string ACL_IDName = dr["区县级城市级别_市场定义"].ToString();//找id
                        string province = dr["省名称"].ToString();//找id
                        string areaName = dr["区域名称"].ToString();//找id
                        string shopTypeName = dr["店铺类型"].ToString();//找id
                        string ShopOwnerShip = dr["店铺产权关系"].ToString();
                        string SaleTypeName = dr["店铺零售属性"].ToString();//找id SaleTypeInfo
                        string ShopLevelName = dr["店铺级别"].ToString();//找id
                        string ShopVIName = dr["店铺形象属性"].ToString();//找id
                        string ShopStateName = dr["店铺状态"].ToString();//找id
                        string ShopArea = dr["营业面积"].ToString();
                        string CustomerCard = dr["客户身份"].ToString();
                        string FXID = dr["直属客户编号"].ToString();//DistributorsInfo
                        string FXIDName = dr["直属客户名"].ToString();
                        string DealerID = dr["一级客户编号"].ToString();
                        string DealerIDName = dr["一级客户名"].ToString();//DealerInfo 
                        string CustomerGroupID = dr["上级客户集团编号"].ToString();
                        string Boolinstall = dr["是否李宁公司统一支持安装"].ToString();
                        string SupplierName = dr["所属POP供应商"].ToString();//查找SupplierAssignRecord
                        string popNum = dr["POP编号"].ToString();
                        string popType = dr["POP类型"].ToString();
                        string SeatDesc = dr["位置描述"].ToString();
                        string POPMaterial = dr["POP材质"].ToString();
                        string POPMaterialRemark = dr["材质备注"].ToString();
                        string RealWith = dr["POP实际制作宽mm"].ToString();
                        string RealHeight = dr["POP实际制作高mm"].ToString();
                        string POPWith = dr["POP可视画面宽mm"].ToString();
                        string POPHeight = dr["POP可视画面高mm"].ToString();
                        string POPPlwz = dr["POP可视画面位置"].ToString();
                        string POPPljd = dr["POP可视画面偏离角度"].ToString();
                        string POPArea = dr["POP面积"].ToString();
                        string Sexarea = dr["男女区域"].ToString();
                        string TwoSided = dr["是否为双面"].ToString();
                        string Glass = dr["是否粘贴与玻璃表面"].ToString();
                        string PlatformWith = dr["橱窗空间进深mm"].ToString();
                        string PlatformHeight = dr["橱窗空间长度mm"].ToString();
                        string PlatformLong = dr["橱窗空间面积"].ToString();
                        if (!string.IsNullOrWhiteSpace(shopNo))
                        {
                            int shopId = 0;
                            if (!shopDic.Keys.Contains(shopNo))
                            {

                                int cityId = 0;
                                int provinceId = 0;
                                int townId = 0;
                                int tclId = 0;
                                int aclId = 0;
                                int areaId = 0;
                                int shopTypeId = 0;
                                int saleTypeId = 0;
                                int shopLevelId = 0;
                                int shopVIId = 0;
                                int shopStateId = 0;
                                DataSet dsshop = shop.GetList(string.Format(" PosID='{0}'", shopNo));
                                if (dsshop != null && dsshop.Tables[0].Rows.Count > 0)
                                {
                                    //已存在店铺
                                    shopId = int.Parse(dsshop.Tables[0].Rows[0]["ShopID"].ToString());

                                    //shopInfoModel = shop.GetModel(shopId);
                                    //if (shopInfoModel != null)
                                    //{
                                    //shopInfoModel.ACL_ID = aclId;
                                    //shopInfoModel.AreaID = areaId;

                                    //}
                                }
                                else
                                {
                                    //新增的店铺
                                    if (!string.IsNullOrWhiteSpace(areaName))
                                        areaId = getAreaId(areaName);
                                    if (!string.IsNullOrWhiteSpace(province))
                                        provinceId = getProvinceId(areaId, province);
                                    if (!string.IsNullOrWhiteSpace(city))
                                        cityId = GetCityId(provinceId, city);
                                    if (!string.IsNullOrWhiteSpace(Town))
                                        townId = GetTownId(cityId, Town);
                                    if (!string.IsNullOrWhiteSpace(TCL_IDName))
                                        tclId = GetTCL_ID(TCL_IDName);
                                    if (!string.IsNullOrWhiteSpace(ACL_IDName))
                                        aclId = GetACL_ID(ACL_IDName);
                                    if (!string.IsNullOrWhiteSpace(shopTypeName))
                                        shopTypeId = GetshopTypeId(shopTypeName);
                                    if (!string.IsNullOrWhiteSpace(SaleTypeName))
                                        saleTypeId = GetSaleTypeId(SaleTypeName);
                                    if (!string.IsNullOrWhiteSpace(ShopLevelName))
                                        shopLevelId = GetShopLevelId(ShopLevelName);
                                    if (!string.IsNullOrWhiteSpace(ShopVIName))
                                        shopVIId = GetShopVIId(ShopVIName);
                                    if (!string.IsNullOrWhiteSpace(ShopStateName))
                                        shopStateId = GetShopStateId(ShopStateName);
                                    shopInfoModel = new LN.Model.ShopInfo();
                                    shopInfoModel.ACL_ID = aclId;
                                    shopInfoModel.AreaID = areaId;
                                    shopInfoModel.Boolinstall = int.Parse(!string.IsNullOrWhiteSpace(Boolinstall) ? Boolinstall : "0");
                                    shopInfoModel.CityID = cityId;
                                    shopInfoModel.CustomerCard = CustomerCard;
                                    shopInfoModel.CustomerGroupID = CustomerGroupID;
                                    shopInfoModel.DealerID = DealerID;
                                    shopInfoModel.ExamState = 1;
                                    shopInfoModel.PosID = shopNo;
                                    shopInfoModel.PostAddress = postAddress;
                                    shopInfoModel.ProvinceID = provinceId;
                                    shopInfoModel.SaleTypeID = saleTypeId;
                                    shopInfoModel.ShopAddress = postAddress;
                                    shopInfoModel.ShopArea = decimal.Parse(!string.IsNullOrWhiteSpace(ShopArea) ? ShopArea : "0");
                                    shopInfoModel.ShopLevelID = shopLevelId;
                                    shopInfoModel.Shopname = shopName;
                                    shopInfoModel.ShopOwnerShip = ShopOwnerShip;
                                    shopInfoModel.ShopSampleName = shopShortName;
                                    shopInfoModel.ShopState = shopStateId;
                                    shopInfoModel.ShopType = shopTypeId;
                                    shopInfoModel.ShopVI = shopVIId;
                                    shopInfoModel.TCL_ID = tclId;
                                    shopInfoModel.TownID = townId;
                                    shopId = shop.Add(shopInfoModel);
                                    if (!string.IsNullOrWhiteSpace(SupplierName))
                                        CheckSupplier(SupplierName, shopId, areaId, provinceId, cityId);
                                }
                                shopDic.Add(shopNo, shopId);
                            }
                            else
                            {
                                shopId = shopDic[shopNo];
                            }
                            //以下是更新pop信息
                            int popid = 0;
                            if (!string.IsNullOrWhiteSpace(popNum))
                            {
                                List<LN.Model.POPInfo> list = popBll.GetList(string.Format(" ShopID={0} and SeatNum={1}", shopId, popNum));
                                if (list.Any())
                                {
                                    popid = list[0].ID;
                                }
                                if (popid > 0)
                                {
                                    
                                    LN.Model.POPInfo popModel = popBll.GetModel(popid);
                                    if (popModel != null)
                                    {
                                        popModel.Glass = int.Parse(!string.IsNullOrWhiteSpace(Glass) ? Glass : "0");
                                        popModel.POPHeight = decimal.Parse(!string.IsNullOrWhiteSpace(POPHeight) ? POPHeight : "0");
                                        popModel.POPMaterial = POPMaterial;
                                        popModel.POPMaterialRemark = POPMaterialRemark;
                                        popModel.POPSeat = popType;
                                        popModel.POPWith = decimal.Parse(!string.IsNullOrWhiteSpace(POPWith) ? POPWith : "0");
                                        popModel.RealHeight = decimal.Parse(!string.IsNullOrWhiteSpace(RealHeight) ? RealHeight : "0");
                                        popModel.RealWith = decimal.Parse(!string.IsNullOrWhiteSpace(RealWith) ? RealWith : "0");
                                        popModel.SeatDesc = SeatDesc;
                                        popModel.POPArea = decimal.Parse(!string.IsNullOrWhiteSpace(POPArea) ? POPArea : "0");
                                        popModel.Sexarea = Sexarea;
                                        popModel.SysTime = DateTime.Now.ToLongDateString();
                                        popModel.TwoSided = int.Parse(!string.IsNullOrWhiteSpace(TwoSided) ? TwoSided : "0");
                                        popModel.PlatformHeight = decimal.Parse(!string.IsNullOrWhiteSpace(PlatformHeight) ? PlatformHeight : "0");
                                        popModel.PlatformWith = decimal.Parse(!string.IsNullOrWhiteSpace(PlatformWith) ? PlatformWith : "0");
                                        popModel.PlatformLong = decimal.Parse(!string.IsNullOrWhiteSpace(PlatformLong) ? PlatformLong : "0");
                                        popModel.IsHide = 0;
                                        
                                        popModel.POPPlwz = POPPlwz;
                                        popModel.POPPljd = int.Parse(!string.IsNullOrWhiteSpace(POPPljd) ? POPPljd : "0");
                                        popModel.ID = popid;

                                        popBll.UpdatePOP(popModel);
                                    updateNum++;
                                    }

                                }
                                else
                                {
                                    LN.Model.POPInfo popModel = new LN.Model.POPInfo();
                                    popModel.Glass = int.Parse(!string.IsNullOrWhiteSpace(Glass) ? Glass : "0");
                                    popModel.POPHeight = decimal.Parse(!string.IsNullOrWhiteSpace(POPHeight) ? POPHeight : "0");
                                    popModel.POPMaterial = POPMaterial;
                                    popModel.POPMaterialRemark = POPMaterialRemark;
                                    popModel.POPSeat = popType;
                                    popModel.POPWith = decimal.Parse(!string.IsNullOrWhiteSpace(POPWith) ? POPWith : "0");
                                    popModel.RealHeight = decimal.Parse(!string.IsNullOrWhiteSpace(RealHeight) ? RealHeight : "0");
                                    popModel.RealWith = decimal.Parse(!string.IsNullOrWhiteSpace(RealWith) ? RealWith : "0");
                                    popModel.SeatDesc = SeatDesc;
                                    popModel.POPArea = decimal.Parse(!string.IsNullOrWhiteSpace(POPArea) ? POPArea : "0");
                                    popModel.Sexarea = Sexarea;
                                    popModel.SysTime = DateTime.Now.ToLongDateString();
                                    popModel.TwoSided = int.Parse(!string.IsNullOrWhiteSpace(TwoSided) ? TwoSided : "0");
                                    popModel.PlatformHeight = decimal.Parse(!string.IsNullOrWhiteSpace(PlatformHeight) ? PlatformHeight : "0");
                                    popModel.PlatformWith = decimal.Parse(!string.IsNullOrWhiteSpace(PlatformWith) ? PlatformWith : "0");
                                    popModel.PlatformLong = decimal.Parse(!string.IsNullOrWhiteSpace(PlatformLong) ? PlatformLong : "0");
                                    popModel.IsHide = 0;
                                    popModel.IsSubmit = 0;
                                    popModel.POPPlwz = POPPlwz;
                                    popModel.POPPljd = int.Parse(!string.IsNullOrWhiteSpace(POPPljd) ? POPPljd : "0");
                                    popModel.ShopID = shopId;
                                    popModel.AddState = DateTime.Now.ToLongDateString();
                                    popModel.ExamState = 1;
                                    popModel.VMExamState = 1;
                                    popBll.Add(popModel);
                                    newNum++;
                                }
                            }
                            
                        }
                    }
                }
                stateMsg.AppendFormat("工作薄{0}：更新{1}，新增{2}<br/>", sheetName, updateNum, newNum);
            }
        }
        labStateMsg.Text = stateMsg.ToString();
    }


    AreaData areaBll = new AreaData();
    int getAreaId(string areaName)
    {
        IList<LN.Model.AreaData> list = areaBll.GetList(string.Format("AreaName='{0}'", areaName));
        if (list.Any())
        {
            return list[0].AreaID;
        }
        return 0;
    }

    ProvinceData provinceBll = new ProvinceData();
    int getProvinceId(int areaId, string provinceName)
    {
        IList<LN.Model.ProvinceData> list = provinceBll.GetList(string.Format("ProvinceName='{0}' and AreaID={1}", provinceName, areaId));
        if (list.Any())
        {
            return list[0].ProvinceID;
        }
        return 0;
    }

    CityData cityBll = new CityData();
    int GetCityId(int provinceId, string cityName)
    {
        IList<LN.Model.CityData> list = cityBll.GetList(string.Format("CityName='{0}' and ProvinceID={1}", cityName, provinceId));
        if (list.Any())
        {
            return list[0].CItyID;
        }
        return 0;
    }

    TownData townBll = new TownData();
    int GetTownId(int cityId, string townName)
    {
        IList<LN.Model.TownData> list = townBll.GetList(string.Format("TownName='{0}' and CityID={1}", townName, cityId));
        if (list.Any())
        {
            return list[0].TownID ?? 0;
        }
        return 0;
    }

    TownCityLevel tclBll = new TownCityLevel();
    int GetTCL_ID(string TCL_IDName)
    {
        IList<LN.Model.TownCityLevel> list = tclBll.GetList(string.Format(" TCL_Name='{0}'", TCL_IDName));
        if (list.Count > 0)
        {

            return list[0].TCL_Id;
        }
        return 0;
    }

    AreaCityLevel aclBll = new AreaCityLevel();
    int GetACL_ID(string name)
    {

        IList<LN.Model.AreaCityLevel> list = aclBll.GetList(string.Format(" ACL_Name='{0}'", name));
        if (list.Count > 0)
        {
            return list[0].ACL_Id;
        }
        return 0;
    }

    ShopType shopTypeBll = new ShopType();
    int GetshopTypeId(string shopTypeName)
    {
        IList<LN.Model.ShopType> list = shopTypeBll.GetList(string.Format(" ShopTypename='{0}'", shopTypeName));
        if (list.Any())
        {
            return list[0].ID;
        }
        return 0;
    }

    SaleTypeInfo saleTypeBll = new SaleTypeInfo();
    int GetSaleTypeId(string SaleTypeName)
    {
        DataSet ds = saleTypeBll.GetList(string.Format(" SaleType='{0}'", SaleTypeName));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            return int.Parse(ds.Tables[0].Rows[0]["SaleTypeID"].ToString());
        }
        return 0;
    }

    ShopLevel shopLevelBll = new ShopLevel();
    int GetShopLevelId(string ShopLevelName)
    {
        DataSet ds = shopLevelBll.GetList(string.Format(" ShopLevel='{0}'", ShopLevelName));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            return int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
        }
        return 0;
    }

    ShopVI shopVIBll = new ShopVI();
    int GetShopVIId(string ShopVIName)
    {
        IList<LN.Model.ShopVI> list = shopVIBll.GetList(string.Format(" ShopVIName='{0}'", ShopVIName));
        if (list.Any())
        {
            return list[0].ShopVIID;
        }
        return 0;
    }

    ShopStateInfo shopStateBll = new ShopStateInfo();
    int GetShopStateId(string ShopStateName)
    {
        DataSet ds = shopStateBll.GetList(string.Format(" ShopState='{0}'", ShopStateName));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            return int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
        }
        return 0;
    }

    SupplierInfo supplierBll = new SupplierInfo();
    SupplierAssignRecord assignBll = new SupplierAssignRecord();
    LN.Model.SupplierAssignRecord assignModel;
    void CheckSupplier(string SupplierName, int shopid, int areaId, int provinceId, int cityId)
    {
        IList<LN.Model.SupplierInfo> list = supplierBll.GetList(string.Format(" SupplierName='{0}'", SupplierName));
        if (list.Any())
        {
            int sid = list[0].SupplierID;
            DataSet ds = assignBll.GetList(string.Format(" SupplierID={0} and AssignShopID={0}", sid, shopid));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                assignModel = new LN.Model.SupplierAssignRecord();
                assignModel.AssignCityID = cityId;
                assignModel.AssignProID = provinceId;
                assignModel.AssignRuleID = 0;
                assignModel.AssignShopID = shopid;
                assignModel.SupplierID = sid;
                assignModel.Remarks = areaId.ToString();
                assignBll.Add(assignModel);
            }
        }

    }
}

