// 显示指定供应商所供应的店铺列表(分页)
function GetSupplierAssignRecord(sID,PageIndex,PageSize)
{
    this.id = sID;             //供应商编号
    this.pageCurrent = PageIndex;       //当前页码
    this.pageSize = PageSize;   //每页显示的行数
    this.totleNumber = 0;   //初始化总数
    this.url = "./CallBack/GetSupplierAssignRecord.ashx?" + new Date();   //接收客户端参数的服务器处理程序
}

GetSupplierAssignRecord.prototype.getList = function(pageCurrent,pageSize)
{ 
    $.getJSON(this.url,{sID:this.id , page:this.pageCurrent , pagesize:this.pageSize},function(list){
                var pList = ""; //显示列表
                var strTotle = "";  //列表总个数
                pList += "<table class=\"table\" style=\"margin-top:20px;\">";
                pList += "<caption style=\"height:20px; font-size:14px; font-weight:bold;color:purple\">所供应的店铺</caption>";
                pList += "<tr>";
                pList += "<th style=\"width:10%;\" >流水号</th >";
                pList += "<th style=\"height: 30px; width:50%;\">店铺名称</th >";
                pList += "<th style=\"width:20%\">所在省份</th >";
                pList += "<th>所在城市</th >";
                pList += "<th>查看详情</th >";
                pList += "</tr>";
        		for(var i = 0; i < list.length; i++)
        		{
        			pList += "<tr style=\"height:25px;\">";
                    pList += "<td>" + list[i].ID + "</td>";
                    pList += "<td>" + list[i].Shopname + "</td>";
                    pList += "<td>" + list[i].ProvinceName + "</td>";
                    pList += "<td>" + list[i].CityName + "</td>";
                    if(list[i].Shopname == "暂无分配店铺")
                        pList += "<td></td>";
                    else    //../Shopmanage/OneShopInfo.aspx?shopid="+sID+"
                        pList += "<td><a href=\"#\" onclick=\"javascript:ShowDIV('40%','40%','700px','50px','505px','[店铺详情]','../Shopmanage/OneShopInfo.aspx?shopid=" + list[i].ShopID + "')\">查看</a></td>";
                    pList += "</tr>";
                    strTotle = list[i].TotleNumber;
        		}
        		pList += "</table>";
        		
                $("#showOrderList").html(pList);
                if(parseInt(strTotle) <= pageSize)     //如果总个数小于每页显示的个数
                    $("#HyperLinkPage").html("当前页 1 / 1 &nbsp;&nbsp;&nbsp;&nbsp;  首页 上一页 下一页 尾页");
                else
                {
                    var pageNum = 0;    //总页数
                    if((strTotle % pageSize) == 0)
                        pageNum = parseInt(strTotle) / pageSize;
                    else
                        pageNum = parseInt(strTotle) / pageSize + 1;
                    if(pageCurrent == 1 && parseInt(strTotle) <= pagesize)
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:getListMode(id,2,pagesize)'>下一页</a> <a href='#'>尾页</a>");
                    }
                    else if(pageCurrent == 1 && parseInt(strTotle) > pagesize)
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:getListMode(id," + (parseInt(pageCurrent)+1) + ",pagesize)'>下一页</a> <a href='javascript:getListMode(id," + parseInt(pageNum) + ",pagesize)'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) == parseInt(pageNum))
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:getListMode(id,1,pagesize)'>首页</a> <a href='javascript:getListMode(id," + (parseInt(pageNum)-1) + ",pagesize)'>上一页</a> <a href='#'>下一页</a> <a href='#'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) < parseInt(pageNum))
                   {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:getListMode(id,1,pagesize)'>首页</a> <a href='javascript:getListMode(id," + (parseInt(pageCurrent)-1) + ",pagesize)'>上一页</a> <a href='javascript:getListMode(id," + (parseInt(pageCurrent)+1) + ",pagesize)'>下一页</a> <a href='javascript:getListMode(id," + parseInt(pageNum) + ",pagesize)'>尾页</a>");
                    }
                }
                
        	});
   
}




