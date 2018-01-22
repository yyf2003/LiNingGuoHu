// JScript 文件
function gotohref() {
    
    var url = 'shop_popinfodaochu.aspx?' + new Date();
    var PosID = $("#Txt_PosID").val(); //店铺编号
    var ShopName = $("#Txt_ShopName").val(); //店铺简称
    var ProID = $("#DDL_Province").val(); //省编号
    var CityID = $("#DDL_city").val(); //市编号
    var townID = $("#DDL_town").val(); //县编号
    var DealerID = $("#ddl_dealer").val(); //一级客户编号
    var BoolInstall = "-1"; //是否支持安装
    var ShopTypeID = $("#DDL_Shoptype").val(); //店铺类型
    var SaleTypeID = $("#SaleTypeID").val(); //销售属性
    var StateID = $("#DDL_shopstate").val(); //店铺状态
    var fxid = $("#DDL_fx").val(); //直属客户
    var department = $("#DDL_DepartMent").val(); //部门
    var areaid = $("#DDL_Area").val(); //区域
    if (areaid == "0") {
        if ($("#hfAreas").val()) {
            areaid = $("#hfAreas").val();
        }
    }
    var Citylevel = $("#DDL_Citylevel").val(); //地市级城市级别
    var townlevel = $("#DDL_TownLevel").val(); //区县级城市级别
    var CusCard = $("#DDL_CoustomerCard").val(); //客户身份
    var CusID = $("#txt_CusID").val(); //上级客户编号
    var CusLevel = $("#txt_CusName").val(); //上级客户级别
    var CusShip = $("#DDL_CustomerShip").val(); //客户产权关系
    var ShopLevel = $("#DDL_ShopLevel").val(); //店铺级别
    var shopArea = $("#txt_shopArea").val(); //营业面积
    var Popseat = $("#DDL_Popseat").val(); //POP类型
    var ProductType = $("#DDL_ProductType").val(); //POP故事包大类
    var POPline = $("#DDL_POPline").val(); //POP故事包大类
    var POParea = $("#txt_POParea").val(); //POP面积
    var PfJS = $("#txt_PfJS").val(); //POP橱窗空间进深
    var Pfcd = $("#txt_Pfcd").val(); //POP橱窗空间长度
    var Pfmj = $("#txt_Pfmj").val(); //POP橱窗空间面积
    var supplierID = $("#HidSupplierID").val(); //供应商编号

    url = url + "&Posid=" + PosID;
    url = url + "&Sname=" + encodeURI(ShopName);
    url = url + "&province=" + ProID;
    url = url + "&cityid=" + CityID;
    url = url + "&dealerid=" + DealerID;
    url = url + "&install=" + BoolInstall;
    url = url + "&typeid=" + ShopTypeID;
    url = url + "&saleid=" + SaleTypeID;
    url = url + "&sstate=" + StateID;
    url = url + "&Fxid=" + fxid;
    url = url + "&department=" + encodeURI(department);
    url = url + "&areaid=" + areaid;
    url = url + "&Citylevel=" + encodeURI(Citylevel);
    url = url + "&townlevel=" + encodeURI(townlevel);
    url = url + "&CusCard=" + encodeURI(CusCard);
    url = url + "&CusID=" + encodeURI(CusID);
    url = url + "&CusLevel=" + encodeURI(CusLevel);
    url = url + "&CusShip=" + encodeURI(CusShip);
    url = url + "&ShopLevel=" + ShopLevel;
    url = url + "&shopArea=" + shopArea;
    url = url + "&Popseat=" + encodeURI(Popseat);
    url = url + "&ProductType=" + ProductType;
    url = url + "&POPline=" + encodeURI(POPline);
    url = url + "&POParea=" + POParea;
    url = url + "&PfJS=" + PfJS;
    url = url + "&Pfcd=" + Pfcd;
    url = url + "&Pfmj=" + Pfmj;
    url = url + "&townID=" + townID;
    url = url + "&supplierID=" + supplierID;
    location.href = url;
}

function gotoShophref() {
    
    var url = 'shopinfodaochu.aspx?' + new Date();
    var PosID = $("#Txt_PosID").val(); //店铺编号
    var ShopName = $("#Txt_ShopName").val(); //店铺简称
    var ProID = $("#DDL_Province").val(); //省编号
    var CityID = $("#DDL_city").val(); //市编号
    var townID = $("#DDL_town").val(); //县编号
    var DealerID = $("#ddl_dealer").val(); //一级客户编号
    var BoolInstall = "-1"; //是否支持安装
    var ShopTypeID = $("#DDL_Shoptype").val(); //店铺类型
    var SaleTypeID = $("#SaleTypeID").val(); //销售属性
    var StateID = $("#DDL_shopstate").val(); //店铺状态
    var fxid = $("#DDL_fx").val(); //直属客户
    var department = $("#DDL_DepartMent").val(); //部门
    var areaid = $("#DDL_Area").val(); //区域

    if (areaid == "0") {
        if ($("#hfAreas").val()) {
            areaid = $("#hfAreas").val();
        }
    }


    var Citylevel = $("#DDL_Citylevel").val(); //地市级城市级别
    var townlevel = $("#DDL_TownLevel").val(); //区县级城市级别
    var CusCard = $("#DDL_CoustomerCard").val(); //客户身份
    var CusID = $("#txt_CusID").val(); //上级客户编号
    var CusLevel = $("#txt_CusName").val(); //上级客户级别
    var CusShip = $("#DDL_CustomerShip").val(); //客户产权关系
    var ShopLevel = $("#DDL_ShopLevel").val(); //店铺级别
    var shopArea = $("#txt_shopArea").val(); //营业面积
    var Popseat = $("#DDL_Popseat").val(); //POP类型
    var ProductType = $("#DDL_ProductType").val(); //POP故事包大类
    var POPline = $("#DDL_POPline").val(); //POP故事包大类
    var POParea = $("#txt_POParea").val(); //POP面积
    var PfJS = $("#txt_PfJS").val(); //POP橱窗空间进深
    var Pfcd = $("#txt_Pfcd").val(); //POP橱窗空间长度
    var Pfmj = $("#txt_Pfmj").val(); //POP橱窗空间面积
    var supplierID = $("#HidSupplierID").val(); //供应商编号

    

    url = url + "&Posid=" + PosID;
    url = url + "&Sname=" + encodeURI(ShopName);
    url = url + "&province=" + ProID;
    url = url + "&cityid=" + CityID;
    url = url + "&dealerid=" + DealerID;
    url = url + "&install=" + BoolInstall;
    url = url + "&typeid=" + ShopTypeID;
    url = url + "&saleid=" + SaleTypeID;
    url = url + "&sstate=" + StateID;
    url = url + "&Fxid=" + fxid;
    url = url + "&department=" + encodeURI(department);
    url = url + "&areaid=" + areaid;
    url = url + "&Citylevel=" + encodeURI(Citylevel);
    url = url + "&townlevel=" + encodeURI(townlevel);
    url = url + "&CusCard=" + encodeURI(CusCard);
    url = url + "&CusID=" + encodeURI(CusID);
    url = url + "&CusLevel=" + encodeURI(CusLevel);
    url = url + "&CusShip=" + encodeURI(CusShip);
    url = url + "&ShopLevel=" + ShopLevel;
    url = url + "&shopArea=" + shopArea;
    url = url + "&Popseat=" + encodeURI(Popseat);
    url = url + "&ProductType=" + ProductType;
    url = url + "&POPline=" + encodeURI(POPline);
    url = url + "&POParea=" + POParea;
    url = url + "&PfJS=" + PfJS;
    url = url + "&Pfcd=" + Pfcd;
    url = url + "&Pfmj=" + Pfmj;
    url = url + "&townID=" + townID;
    url = url + "&supplierID=" + supplierID;
    location.href = url;
}


