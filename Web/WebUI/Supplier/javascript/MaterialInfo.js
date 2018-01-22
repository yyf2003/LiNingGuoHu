// 显示指定供应商所供应的店铺列表(分页)
function MaterialInfo(uID,PageIndex,PageSize)
{
    this.id = uID;             //用户编号
    this.pageCurrent = PageIndex;       //当前页码
    this.pageSize = PageSize;   //每页显示的行数
    this.totleNumber = 0;   //初始化总数
    this.url = "./CallBack/SupplierMaterial.ashx?" + new Date();   //接收客户端参数的服务器处理程序
}

MaterialInfo.prototype.getList = function(pageCurrent,pageSize)
{ 
    $.getJSON(this.url,{uID:this.id , page:this.pageCurrent , pagesize:this.pageSize},function(list){
                var pList = ""; //显示列表
                var strTotle = "";  //列表总个数
                pList += "<table class=\"table\" style=\"margin-top:20px; color:navy\">";
                pList += "<tr>";
                pList += "<th style=\"width:20% \">材料编号</th>";
                pList += "<th style=\"width:60% \">材料名称</th>";
                pList += "</tr>";
        		for(var i = 0; i < list.length; i++)
        		{
        			pList += "<tr>";
                    pList += "<td style=\"width:20% \">" + list[i].MateriaID + "</td>";
                    pList += "<td>" + list[i].MateriaPro + "</td>";
                    pList += "</tr>";
                    strTotle = list[i].TotleNumber;
        		}
        		pList += "</table>";
        		
                $("#showMaterialList").html(pList);
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








