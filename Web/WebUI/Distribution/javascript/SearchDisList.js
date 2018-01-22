// 显示搜索直属客户列表(分页)
function GetDistributorsInfo() {
    this.FXID = $.trim($("#txtFXID").val());             //直属客户编号
    this.FXName = $.trim($("#txtFXName").val());          //直属客户名称
    this.DealerName = $.trim($("#txtDealerName").val());  //一级客户名称
    this.DealerID = $.trim($("#txtdealerID").val());       //一级客户编号
    this.department = $("#DDL_department").val();
    this.AreaId = $("#DDL_Area").val();
    if (this.AreaId == "0") {
        this.AreaId = $("#hfAreas").val()||"0";
    }
    this.ProvinceID = $("#DDL_Province").val();
    this.CityID = $("#DDL_city").val();
    this.url = "./CallBack/GetDisList.ashx?" + new Date();   //接收客户端参数的服务器处理程序
}

GetDistributorsInfo.prototype.getList = function (pageCurrent, pageSize) {
    $.getJSON(this.url, { fid: this.FXID, fname: this.FXName, dname: this.DealerName, dealerId: this.DealerID, dept: this.department, areaId: this.AreaId, ProId: this.ProvinceID, CId: this.CityID, page: pageCurrent, pagesize: pageSize }, function (list) {
        var pList = ""; //显示列表
        var strTotle = "";  //列表总个数
        pList += "<table class=\"table\" style=\"width: 90%;margin-top:20px; color:navy\">";
        pList += "<tr>";
        pList += "<th>流水号</th>";
        pList += "<th>直属客户编号</th>";
        pList += "<th>直属客户名称</th>";
        pList += "<th>所属一级客户</th>";
        pList += "<th>联系人</th>";
        pList += "<th>联系人电话</th>";
        //		        pList += "<th>直属客户电话</th>";
        pList += "<th>编辑</th>";
        pList += "<th>操作</th>";
        pList += "</tr>";
        for (var i = 0; i < list.length; i++) {
            strTotle = list[i].TotleNumber;
            if (strTotle == "0")
                pList += "<tr><td></td><td></td><td>" + list[i].FXName + "</td><td></td><td></td><td></td><td></td><td></td></tr>";
            else {
                pList += "<tr><td>" + list[i].SNumberID + "</td>";
                pList += "<td>" + list[i].FXID + "</td>";
                pList += "<td>" + list[i].FXName + "</td>";
                pList += "<td>" + list[i].DealerName + "</td>";
                pList += "<td>" + list[i].FXContactor + "</td>";
                pList += "<td>" + list[i].FXPhone + "</td>";
                //		                pList+="<td>"+list[i].FXtel+"</td>";
                pList += "<td><a href=\"EditInfo.aspx?fxid=" + list[i].FXID + "\" >编辑</td>"
                pList += "<td><a  href=\"#\" onclick=\"DelMode('" + list[i].FXID + "')\">删除</a></td></tr>";
            }

        }
        pList += "</table>";
        $("#fillTable").html(pList);
        if (parseInt(strTotle) <= pageSize)     //如果总个数小于每页显示的个数
            $("#HyperLinkPage").html("当前页 1 / 1 &nbsp;&nbsp;&nbsp;&nbsp;  首页 上一页 下一页 尾页");
        else {
            var pageNum = 0;    //总页数
            if ((parseInt(strTotle) % pageSize) == 0)
                pageNum = parseInt(strTotle) / pageSize;
            else
                pageNum = parseInt(strTotle) / pageSize + 1;
            if (pageCurrent == 1 && parseInt(strTotle) <= pagesize) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> &nbsp;&nbsp; <a href='#'>上一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(2,pagesize)'>下一页</a> &nbsp;&nbsp; <a href='#'>尾页</a>");
            }
            else if (pageCurrent == 1 && parseInt(strTotle) > pagesize) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> &nbsp;&nbsp; <a href='#'>上一页</a>&nbsp;&nbsp;  <a href='javascript:getListMode(" + (parseInt(pageCurrent) + 1) + ",pagesize)'>下一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + parseInt(pageNum) + ",pagesize)'>尾页</a>");
            }
            else if (parseInt(pageCurrent) == parseInt(pageNum)) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:getListMode(1,pagesize)'>首页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + (parseInt(pageNum) - 1) + ",pagesize)'>上一页</a> &nbsp;&nbsp; <a href='#'>下一页</a>&nbsp;&nbsp;  <a href='#'>尾页</a>");
            }
            else if (parseInt(pageCurrent) < parseInt(pageNum)) {
                $("#HyperLinkPage").html("当前页 " + pageCurrent + " / " + parseInt(pageNum) + " &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:getListMode(1,pagesize)'>首页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + (parseInt(pageCurrent) - 1) + ",pagesize)'>上一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + (parseInt(pageCurrent) + 1) + ",pagesize)'>下一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + parseInt(pageNum) + ",pagesize)'>尾页</a>");
            }
        }

    });
}

GetDistributorsInfo.prototype.DeleteInfo = function (FXID) {
    if (window.confirm("确认删除吗？")) {
        var url = "./CallBack/DelDisInfo.ashx?" + new Date();   //接收客户端参数的服务器处理程序
        $.get(url, { id: FXID },
        //回调函数
            function (returnData) {
                if (returnData != "0") {
                    alert("删除成功！！");
                    getListMode(1, 20);
                }
                else {
                    $.prompt("删除失败！！  服务器忙，请稍后操作！！");
                }
            });
    }
}
