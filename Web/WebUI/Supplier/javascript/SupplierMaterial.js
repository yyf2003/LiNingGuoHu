// 显示指定供应商所供应的店铺列表(分页)
function GetSupplierMaterial(uID,PageIndex,PageSize)
{
    this.id = uID;             //用户编号
    this.pageCurrent = PageIndex;       //当前页码
    this.pageSize = PageSize;   //每页显示的行数
    this.totleNumber = 0;   //初始化总数
    this.url = "./CallBack/SupplierMaterial.ashx?" + new Date();   //接收客户端参数的服务器处理程序
}

GetSupplierMaterial.prototype.getList = function(pageCurrent,pageSize)
{ 
    $.getJSON(this.url,{uID:this.id , page:this.pageCurrent , pagesize:this.pageSize},function(list){
                var pList = ""; //显示列表
                var strTotle = "";  //列表总个数
                pList += "<table class=\"table\" style=\"margin-top:20px; color:navy\">";
                pList += "<tr>";
                pList += "<th style=\"width:20% \">材料编号</th>";
                pList += "<th style=\"width:20% \">材料名称</th>";
                pList += "<th style=\"width:20% \">材料支持安装类型</th>";
                pList += "<th style=\"width:20% \">材料状态</th>";
                pList += "<th>操作</th>";
                pList += "</tr>";
        		for(var i = 0; i < list.length; i++)
        		{
        			pList += "<tr>";
                    pList += "<td style=\"width:20% \">" + list[i].MateriaID + "</td>";
                    pList += "<td>" + list[i].MateriaPro + "</td>";
                    if(list[i].IsSupport=="1")
                    pList += "<td>支持</td>";
                    else
                      pList += "<td>不支持</td>";
                    if(list[i].MateriaPro == "暂无材料")
                        pList += "<td></td><td></td>";
                    else    
                    {
                        var isDelete = list[i].IsDelete == "0" ? "使用" : "<span style='color:red'>弃用</span>";
                        pList += "<td>" + isDelete + "</td>";
                        if(list[i].IsDelete == "0")
                        {
                            pList += "<td><span id=\"show"+list[i].MateriaID+"\" style=\"cursor:pointer\" onclick=\"javascript:showDIV(this.id," + list[i].MateriaID + ")\">";
                            pList += "修改</span> <span style=\" margin-left:5%; cursor:pointer; \" onclick=\"javascript:IsDelete(" + list[i].MateriaID + ",1)\" >弃用</span></td>";
                        }
                        else
                        {
                            pList += "<td><span id=\"show"+list[i].MateriaID+"\" style=\"cursor:pointer\">修改</span><span style=\" margin-left:5%; cursor:pointer; \" onclick=\"javascript:IsDelete(" + list[i].MateriaID + ",0)\" >使用</span></td>";
                        }
                    }
                    pList += "</tr>";
                    pList += "<tr id=\""+list[i].MateriaID+"\" style=\"display:none\">";
                    pList += "<td colspan=\"4\" style=\"text-align:left; padding-left:20%\"><input id=\"txt" + list[i].MateriaID + "\" name=\"txt" + list[i].MateriaID + "\" style=\"width:50%\" type=\"text\" value=\"" + list[i].MateriaPro + "\" /></td>";
                    pList += "<td><span style=\"cursor:pointer; font-weight:bold\" onclick=\"UpdateMaterial(" + list[i].MateriaID  + ", $.trim($('#txt" + list[i].MateriaID + "').val()))\">完成</span></td>";
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






