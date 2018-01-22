// 显示搜索直属客户列表(分页)
function GetStoryBagList()
{
    this.PName =  $.trim($("#txtPName").val());             //故事包名称
    this.TypeID = $.trim($("#ddlTypeName").val());          //所属品类编号
    this.url = "./CallBack/SearchStoryBagList.ashx?" + new Date();   //接收客户端参数的服务器处理程序
}

GetStoryBagList.prototype.getList = function(pageCurrent,pageSize)
{ 
    $.getJSON(this.url,{pname:this.PName ,tid:this.TypeID, page:pageCurrent , pagesize:pageSize},function(list){
                var pList = ""; //显示列表
                var strTotle = "";  //列表总个数
                pList += "<table class=\"table\" style=\"width: 90%;margin-top:20px; color:navy\">";
                pList += "<tr>";
		        pList += "<th>流水号</th>";
		        pList += "<th>产品系列</th>";
		        pList += "<th>所属产品大类</th>";
		        pList += "</tr>";
        		for(var i = 0; i < list.length; i++)
        		{
        		    strTotle = list[i].TotleNumber;
        		    if(strTotle == "0")
        			    pList += "<tr><td></td><td>"+list[i].ProductLine+"</td><td></td><td></tr>";
        			else
        			{
        			    pList+="<tr style=\"text-align:center\"><td>"+list[i].SNumberID+"</td>";
		                pList+="<td>"+list[i].ProductLine+"</td>";
		                pList+="<td>"+list[i].ProductTypeName+"</td>";
		                pList+="</tr>";
        			}
                    
        		}
        		pList += "</table>";
                $("#fillTable").html(pList);
                if(parseInt(strTotle) <= pageSize)     //如果总个数小于每页显示的个数
                    $("#HyperLinkPage").html("当前页 1 / 1 &nbsp;&nbsp;&nbsp;&nbsp;  首页 上一页 下一页 尾页");
                else
                {
                    var pageNum = 0;    //总页数
                    if((parseInt(strTotle) % pageSize) == 0)
                        pageNum = parseInt(strTotle) / pageSize;
                    else
                        pageNum = parseInt(strTotle) / pageSize + 1;
                    if(pageCurrent == 1 && parseInt(strTotle) <= pagesize)
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> &nbsp;&nbsp; <a href='#'>上一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(2,pagesize)'>下一页</a> &nbsp;&nbsp; <a href='#'>尾页</a>");
                    }
                    else if(pageCurrent == 1 && parseInt(strTotle) > pagesize)
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> &nbsp;&nbsp; <a href='#'>上一页</a>&nbsp;&nbsp;  <a href='javascript:getListMode(" + (parseInt(pageCurrent)+1) + ",pagesize)'>下一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + parseInt(pageNum) + ",pagesize)'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) == parseInt(pageNum))
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:getListMode(1,pagesize)'>首页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + (parseInt(pageNum)-1) + ",pagesize)'>上一页</a> &nbsp;&nbsp; <a href='#'>下一页</a>&nbsp;&nbsp;  <a href='#'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) < parseInt(pageNum))
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:getListMode(1,pagesize)'>首页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + (parseInt(pageCurrent)-1) + ",pagesize)'>上一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + (parseInt(pageCurrent)+1) + ",pagesize)'>下一页</a> &nbsp;&nbsp; <a href='javascript:getListMode(" + parseInt(pageNum) + ",pagesize)'>尾页</a>");
                    }
                }
                
        	});
}

GetStoryBagList.prototype.GetTypeList = function()
{
    var GetTypeUrl = "./Callback/GetTypeList.ashx?" + new Date();   //接收客户端参数的服务器处理程序
    $.getJSON(GetTypeUrl,{isdelete:1},function(List)
    {
       $("#ddlTypeName").empty();
       var plist = "<option value=\"0\">请选择产品大类</option>";
       for(var i = 0; i < List.length; i++)
       {
          if(List[i].ProductTypeID != "0")
                plist += "<option value=\""+List[i].ProductTypeID+"\">"+List[i].ProductTypeName+"</option>";
       }
           $(plist).appendTo($("#ddlTypeName"));
    });
}

GetStoryBagList.prototype.AddTypeName = function()
{
    var TypeName =  $.trim($("#txtTypeName").val());             //品类名称
    if(TypeName == "")
    {
        alert("请输入产品大类名称");
        $("#txtTypeName").focus();
        return false;
    }
   
    $("#showMessage").html("正在提交，请稍后。。。");
    var AddUrl = "./Callback/AddTypeName.ashx?" + new Date();   //接收客户端参数的服务器处理程序
    $.get(AddUrl,{tname:TypeName},
    //回调函数
    function(returnData){
       if(parseInt(returnData) > 0)
       {
            $("#showMessage").html("添加成功！！");
            getTypeName();
       }
       else
       {
            $("#showMessage").html("添加失败，该品类已经存在！！");
            return false;
       }
    });
}

GetStoryBagList.prototype.AddProductLine = function()
{
    var pName =  $.trim($("#txtPName").val());             //故事包名称
    var pTypeID =  $.trim($("#ddlTypeName").val());             //故事包品类编号
    if(pName == "")
    {
        alert("请输入产品系列名称");
        $("#txtPName").focus();
        return false;
    }
    if(pTypeID == "0")
    {
        alert("请选择产品大类");
        return false;
    }
    var AddUrl = "./Callback/AddProductLine.ashx?" + new Date();   //接收客户端参数的服务器处理程序
    $.get(AddUrl,{pname:pName,ptype:pTypeID},
    //回调函数
    function(returnData){
       if(parseInt(returnData) > 0)
       {
            alert("添加产品系列成功！！");
            $("#txtPName").val("");
            $("#ddlTypeName").val("0");
            getListMode(1,pagesize);
       }
       else
       {
            alert("添加失败，该系列已经存在！！");
            return false;
       }
    });
}
