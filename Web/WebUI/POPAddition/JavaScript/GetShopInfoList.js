// JScript 文件


function Getshopinfolist(PageIndex)
{

//--------------------------------分页配置
 var pageCurrent = PageIndex;       //当前页码
 var pageSize = 15;   //每页显示的行数



//-----------------------------------------------------
var url='CallBack/GetShopList.ashx?'+new Date();
var PosID=$("#Txt_PosID").val();
var ShopName=$("#Txt_ShopName").val();
var ProID=$("#DDL_Province").val();
var CityID=$("#DDL_city").val();
var DealerID=$("#ddl_dealer").val();
var BoolInstall=$("#DDL_install").val();
var ShopTypeID=$("#DDL_Shoptype").val();
var SaleTypeID=$("#SaleTypeID").val();
var Fxid =$("#DDL_fx").val(); 
var StateID=1;// 店铺状态
$("#fillTable").html("");//清空
   $.getJSON(url,{Posid:PosID,Sname:ShopName,province:ProID,cityid:CityID,dealerid:DealerID,install:BoolInstall,typeid:ShopTypeID,saleid:SaleTypeID,Fxid:Fxid,sstate:StateID,page:pageCurrent,psize:pageSize},function(data){
        var plist="<table style=\"\width: 900px; font-size: 12px\"\  cellpadding=\"1\"  border=\"1\"   bordercolor=\"#D9D9FF\"  cellspacing=\"1\" class=\"table\">";
		 plist+="<tr align=\"\center\"\ style=\"\font-size: 14px\">";
		 plist+="<th style=\"width: 50px\">NO</th>";
		plist+="<th style=\"\width: 80px\"\>店铺编号</th>";
		plist+="<th style=\"\width: 250px\"\>店铺名称</th>";
		plist+="<th>店铺一级客户</td>";
		plist+="<th style=\"\width: 120px\"\>店铺城市</th>";
		plist+="<th style=\"width: 100px\">查看</th>"; 
		plist+="</tr>";
		var strTotle=0;//得到记录的总数
     for(var i=0;i<data.length;i++)
     {
        plist+="<tr>";
        plist+="<td>"+(i+1)+"</td>";
        plist+="<td>"+data[i].pID+"</td>";
        plist+="<td><a href='#' onclick= \"javascript:ShowDIV('30%','30%','700px','50px','500px','[店铺详情]','../ShopPOP/ShopPOPList.aspx?shopid=" + data[i].sID + "')\">"+data[i].SName+"</td>";
        plist+="<td>"+data[i].jxs+"</td>";
        plist+="<td>"+data[i].sf+"，"+data[i].cs+"</td>";
        plist+="<td align='center' id=c"+data[i].sID+">"+data[i].xg+"</td>"; 
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
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:Getshopinfolist(2)'>下一页</a> <a href='#'>尾页</a>");
                    }
                    else if(pageCurrent == 1 && parseInt(strTotle) > pageSize)
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='#'>首页</a> <a href='#'>上一页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageCurrent)+1) + ")'>下一页</a> <a href='javascript:Getshopinfolist(" + parseInt(pageNum) + ")'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) == parseInt(pageNum))
                    {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:Getshopinfolist(1)'>首页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageNum)-1) + ")'>上一页</a> <a href='#'>下一页</a> <a href='#'>尾页</a>");
                    }
                    else if(parseInt(pageCurrent) < parseInt(pageNum))
                   {
                        $("#HyperLinkPage").html("当前页 " + pageCurrent + " / "+parseInt(pageNum)+" &nbsp;&nbsp;&nbsp;&nbsp;  <a href='javascript:Getshopinfolist(1)'>首页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageCurrent)-1) + ")'>上一页</a> <a href='javascript:Getshopinfolist(" + (parseInt(pageCurrent)+1) + ")'>下一页</a> <a href='javascript:Getshopinfolist(" + parseInt(pageNum) + ")'>尾页</a>");
                    }
                }
                
   }
   );
}

//店铺关闭
function CloseShop(sid)
{
if(confirm('是否确认要关闭此家店铺？'))
{
 var url='Shopashx/CloseShop.ashx?'+new Date();
 $.getJSON(url,{shopid:sid},function(data){
    if(data[0].OK)
    {
      alert('店铺成功关闭');
      $("#"+sid).html("<font color='red'>已关店</font>");
       $("#c"+sid).html("修 改");
    }
 });
 }
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