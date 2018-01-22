// JScript 文件
function ShowPOPImgJudgeResult(PageIndex)
{

//--------------------------------分页配置
 var pageCurrent = PageIndex;       //当前页码
 var pageSize = 20;   //每页显示的行数

//-----------------------------------------------------
var url='./CallBack/POPSetupJudge.ashx?'+new Date();
var PosID=$("#Txt_PosID").val();
var ShopName=$("#Txt_ShopName").val();
var ProID=$("#DDL_Province").val();
var CityID=$("#DDL_city").val();
var DealerID=$("#ddl_dealer").val();
var DDL_POP=$("#DDL_POP").val();
var SupplierID=$("#HidSupplierID").val();
var DDL_JudgeState=$("#DDL_JudgeState").val();

$("#fillTable").html("");//清空
   $.getJSON(url,{Posid:PosID,Sname:ShopName,province:ProID,cityid:CityID,dealerid:DealerID,popid:DDL_POP,sid:SupplierID,state:DDL_JudgeState,page:pageCurrent,psize:pageSize},function(data){
        var plist="<table style=\"\width: 90%; font-size: 12px\"\  cellpadding=\"1\"  border=\"1\"   bordercolor=\"#D9D9FF\"  cellspacing=\"1\" class=\"table\">";
		 plist+="<tr align=\"\center\"\ style=\"\font-size: 14px\">";
		 plist+="<th style=\"width: 50px\">NO</th>";
		plist+="<th style=\"\width: 80px\"\>店铺编号</th>";
		plist+="<th style=\"\width: 250px\"\>店铺名称</th>";
		plist+="<th>店铺一级客户</td>";
		plist+="<th style=\"\width: 120px\"\>店铺城市</th>";
		plist+="<th >状态</th>";
		plist+="<th >操作</th>";
		plist+="</tr>";
		var strTotle=0;//得到记录的总数
     for(var i=0;i<data.length;i++)
     {
        plist+="<tr>";
        plist+="<td>"+(i+1)+"</td>";
        plist+="<td>"+data[i].pID+"</td>";
        if(data[i].TotalNumber == "0")
        {
            plist+="<td>"+data[i].SName+"</td>";
            plist+="<td></td>";
            plist+="<td></td>";
            plist+="<td></td>";
            plist+="<td align='center'></td>";
        }
        else
        {
            plist+="<td><a href='#' onclick= \"javascript:ShowDIV('30%','30%','700px','50px','500px','[店铺详情]','../ShopPOP/ShopPOPList.aspx?shopid=" + data[i].sID + "')\">"+data[i].SName+"</a></td>";
            plist+="<td>"+data[i].jxs+"</td>";
            plist+="<td>"+data[i].sf+"，"+data[i].cs+"</td>";
            plist+="<td>"+data[i].state+"</td>";
            plist+="<td align='center'><a href='./ShowJudgeResult.aspx?id="+data[i].sID+"&popid="+data[i].popid+"&sid="+data[i].SupplierID+"' >查看</a></td>";
        }
        plist+="</tr>";
        
        strTotle=data[i].TotalNumber;
     }
     plist+="</table>";
     //alert(plist);
      $(plist).appendTo($("#fillTable"));
      
      
      if(parseInt(strTotle) <= pageSize)     //如果总个数小于每页显示的个数
                    $("#HyperLinkPage").html("当前页 1 / 1 &nbsp;&nbsp;&nbsp;&nbsp;  首页 上一页 下一页 尾页");
                else
                {
                    var pageNum = 0;    //总页数

                    if((strTotle % pageSize) == 0)
                        pageNum = parseInt(strTotle) / pageSize;
                    else
                        pageNum = parseInt(strTotle) / pageSize + 1;
                    if(pageCurrent == 1 && parseInt(strTotle) <= pageSize)
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:ShowPOPImgJudgeResult(2)'>下一页</a> <a href='#'>尾页</a>");
                    }
                    else if(pageCurrent == 1 && parseInt(strTotle) > pageSize)
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:ShowPOPImgJudgeResult(" + (parseInt(pageCurrent)+1) + ")'>下一页</a> <a href='javascript:ShowPOPImgJudgeResult(" + parseInt(pageNum) + ")'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) == parseInt(pageNum))
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:ShowPOPImgJudgeResult(1)'>首页</a> <a href='javascript:ShowPOPImgJudgeResult(" + (parseInt(pageNum)-1) + ")'>上一页</a> <a href='#'>下一页</a> <a href='#'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) < parseInt(pageNum))
                   {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:ShowPOPImgJudgeResult(1)'>首页</a> <a href='javascript:ShowPOPImgJudgeResult(" + (parseInt(pageCurrent)-1) + ")'>上一页</a> <a href='javascript:ShowPOPImgJudgeResult(" + (parseInt(pageCurrent)+1) + ")'>下一页</a> <a href='javascript:ShowPOPImgJudgeResult(" + parseInt(pageNum) + ")'>尾页</a>");
                    }
                }
                
   }
   );
}
// js 解析url中的参数
    
function request(paras){ 
    var url = location.href;   
    var paraString = url.substring(url.indexOf("?")+1,url.length).split("&");   
    var paraObj = {};
        for (i=0; j=paraString[i]; i++){   
        paraObj[j.substring(0,j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf 
        ("=")+1,j.length);   
        }   
    var returnValue = paraObj[paras.toLowerCase()];   
    if(typeof(returnValue)=="undefined"){   
    return "";   
    }else{  
   
    return returnValue;   
    }   
}