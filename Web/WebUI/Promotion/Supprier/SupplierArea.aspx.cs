using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using LN.BLL;

public partial class WebUI_Promotion_Supprier_SupplierArea : System.Web.UI.Page
{
    SupplierInfo supplierBll = new SupplierInfo();
    SupplierArea areaBll = new SupplierArea();
    LN.Model.SupplierArea areaModel;

    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            id = int.Parse(Request.QueryString["id"].ToString());
        }
        if (!IsPostBack)
        {
            LN.Model.SupplierInfo supplierModel = supplierBll.GetModel(id);
            if (supplierModel != null)
            {
                labName.Text = supplierModel.SupplierName;
                labShortName.Text = supplierModel.ShortName;
            }
            GetSupplierArea();
            GetAreas();
        }
    }
    StringBuilder sb1 = new StringBuilder();
    void GetSupplierArea()
    {
        StringBuilder sb = new StringBuilder();
        
        DataSet ds = areaBll.GetAreaBySupplierId(id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //sb.Append(dr["ProvinceName"]+"，");
                sb1.Append(dr["DepartmentId"] + ":" + dr["ProvinceId"] + ",");
                //sb1.Append(dr["DepartmentId"] + ",");
            }
            //labArea.Text = sb.ToString().TrimEnd('，');
            hfProvinces.Value = sb1.ToString().TrimEnd(',');
        }
    }


    DepartMentInfo departmentBll = new DepartMentInfo();
    ProvinceData provinceBll = new ProvinceData();
    ProvinceInDepartment pidBll = new ProvinceInDepartment();
    void GetAreas()
    {
        DataSet departmentDs = departmentBll.GetList(" State=1");
        if (departmentDs != null && departmentDs.Tables[0].Rows.Count > 0)
        {
            StringBuilder json = new StringBuilder();
            string[] arr = sb1.ToString().Split(',');
            foreach (DataRow dr in departmentDs.Tables[0].Rows)
            {
                string check1 = string.Empty;
                foreach (string s in arr)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        string did = s.Split(':')[0];
                        if (did == dr["ID"].ToString())
                        {
                            check1 = ",checked:true";
                        }
                    }
                }
                json.Append("{\"id\":\"" + dr["ID"].ToString() + "\",\"pId\":\"0\",\"name\":\"" + dr["department"].ToString() + "\" " + check1 + ",open:true},");
                DataSet pindDs = pidBll.GetProvincesByDid(int.Parse(dr["ID"].ToString()));
                if (pindDs != null && pindDs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr1 in pindDs.Tables[0].Rows)
                    {
                        string check = string.Empty;
                        foreach (string s in arr)
                        {
                            if (!string.IsNullOrWhiteSpace(s))
                            {
                                string did = s.Split(':')[0];
                                string pid = s.Split(':')[1];
                                if (did == dr["ID"].ToString() && pid == dr1["ProvinceId"].ToString())
                                {
                                    check = ",checked:true";
                                }
                            }
                        }

                        json.Append("{\"id\":\"" + dr1["ProvinceId"].ToString() + "\",\"pId\":\"" + dr["ID"].ToString() + "\",\"name\":\"" + dr1["ProvinceName"].ToString() + "\" " + check + "},");
                    }
                }
            }
            if (json.Length > 0)
            {
                hfJson.Value = "[" + json.ToString().TrimEnd(',') + "]";
            }
        }
    }
    /// <summary>
    /// 提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        areaBll.DeleteBySuppliterId(id);
        if (!string.IsNullOrEmpty(hfProvinces.Value))
        {
            
            string[] arr = hfProvinces.Value.Split(',');
            foreach (string s in arr)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    areaModel = new LN.Model.SupplierArea();
                    areaModel.DepartmentId = int.Parse(s.Split(':')[0]);
                    areaModel.ProvinceId = int.Parse(s.Split(':')[1]);
                    //areaModel.DepartmentId = int.Parse(s);
                    //areaModel.ProvinceId =0;
                    areaModel.SupplierId = id;
                    areaBll.Add(areaModel);
                }
            }
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('提交成功！');window.location.href='SupplierArea.aspx?id="+id+"'", true);
            GetSupplierArea();
        }
    }
}