// JScript 文件

function Getshopinfolist(PageIndex) {

    //--------------------------------分页配置
    var pageCurrent = PageIndex;       //当前页码
    var pageSize = 15;   //每页显示的行数
    
    //-----------------------------------------------------
    var url = 'Shopashx/GetShopOrderformPreview.ashx?' + new Date();
    var PosID = $("#Txt_PosID").val();
    var ShopName = $("#Txt_ShopName").val();
    var ProID = $("#DDL_Province").val();
    var CityID = $("#DDL_city").val();
    var DealerID = $("#ddl_dealer").val();
    var BoolInstall = $("#DDL_install").val();
    var ShopTypeID = $("#DDL_Shoptype").val();
    var SaleTypeID = $("#SaleTypeID").val();
    var StateID = $("#DDL_shopstate").val();
    var fxid = $("#DDL_fx").val();
    var department = $("#DDL_department").val();
    var AreaID = $("#DDL_Area").val();
    if (AreaID == "0") {
        AreaID = $("#hfAreas").val()||"0";
    }
    var POPID = $("#DDL_POPID").val();
    var supplierId = $("#h_supplierId").val(); //add by mhj 2012.2.5
    var specialType = $("#ddl_specialType").val(); //add by mhj 2012.2.5
    $("#fillTable").html(""); //清空
    $.getJSON(url, { Posid: PosID, Sname: ShopName, province: ProID, cityid: CityID, dealerid: DealerID, Fxid: fxid, install: BoolInstall, typeid: ShopTypeID, saleid: SaleTypeID, sstate: StateID, dept: department, areaid: AreaID, popID: POPID, page: pageCurrent, psize: pageSize, supplierId: supplierId, specialType: specialType }, function (data) {
        var plist = "<table style=\"\width: 900px; font-size: 12px\"\  cellpadding=\"1\"  border=\"1\"   bordercolor=\"#D9D9FF\"  cellspacing=\"1\" class=\"table\">";
        plist += "<tr align=\"\center\"\ style=\"\font-size: 14px\">";
        plist += "<th style=\"width: 50px\">NO</th>";
        plist += "<th style=\"\width: 80px\"\>店铺编号</th>";
        plist += "<th style=\"\width: 250px\"\>店铺名称</th>";
        plist += "<th>店铺一级客户</td>";
        plist += "<th style=\"\width: 120px\"\>店铺城市</th>";
        plist += "<th style=\"width: 50px\">查看</th>";
        plist += "<th style=\"width: 50px\">状态</th>";
        plist += "</tr>";
        var strTotle = 0; //得到记录的总数
        for (var i = 0; i < data.length; i++) {
            plist += "<tr>";
            plist += "<td>" + (i + 1) + "</td>";
            plist += "<td>" + data[i].pID + "</td>";
            plist += "<td><a href='#' onclick= \"javascript:ShowDIV('30%','30%','700px','50px','500px','[店铺详情]','../ShopPOP/ShopPOPList.aspx?shopid=" + data[i].sID + "')\">" + data[i].SName + "</td>";
            plist += "<td>" + data[i].jxs + "</td>";
            plist += "<td>" + data[i].sf + "，" + data[i].cs + "</td>";
            plist += "<td align='center' id=c" + data[i].sID + ">" + data[i].xg + "</td>";
            plist += "<td align='center' id=" + data[i].sID + ">" + data[i].gd + "</td>";
            plist += "</tr>";

            strTotle = data[i].TotalNumber;
        }
        plist += "</table>";
        //alert(plist);
        $(plist).appendTo($("#fillTable"));


        if (parseInt(strTotle) <= pageSize)     //如果总个数小于每页显示的个数
            $("#HyperLinkPage").html("当前页 1 / 1 &nbsp;&nbsp;&nbsp;&nbsp;  首页 上一页 下一页 尾页");
        else {
            var pageNum = 0;    //总页数
            if ((strTotle % pageSize) == 0)
                pageNum = parseInt(strTotle) / pageSize;
            else
                pageNum = parseInt(strTotle) / pageSize + 1;
            if (pageCurrent == 1 && parseInt(strTotle) <= pageSize) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:Getshopinfolist(2)'>下一页</a> <a href='#'>尾页</a>");
            }
            else if (pageCurrent == 1 && parseInt(strTotle) > pageSize) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageCurrent) + 1) + ")'>下一页</a> <a href='javascript:Getshopinfolist(" + parseInt(pageNum) + ")'>尾页</a>");
            }
            else if (parseInt(pageCurrent) == parseInt(pageNum)) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:Getshopinfolist(1)'>首页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageNum) - 1) + ")'>上一页</a> <a href='#'>下一页</a> <a href='#'>尾页</a>");
            }
            else if (parseInt(pageCurrent) < parseInt(pageNum)) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:Getshopinfolist(1)'>首页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageCurrent) - 1) + ")'>上一页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageCurrent) + 1) + ")'>下一页</a> <a href='javascript:Getshopinfolist(" + parseInt(pageNum) + ")'>尾页</a>");
            }
        }

    }
   );
}



// js 解析url中的参数

function request(paras) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {};
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf
                ("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {

        return returnValue;
    }
}

//跳转详细POP订单信息页
function GetShopOrderformDetail(shopID) {
    var POPID = $("#DDL_POPID").val();
    window.location.href = "ShopOrderformDetail.aspx?POPID=" + POPID + "&ShopID=" + shopID;
}
//获取POP发起ID
function ChangePOPID() {
    $("#showPOPID").html($("#DDL_POPID").val());
}