
function InitData(pageindx,pagesize)
{
    var strURL = "./CallBack/GetShopList.ashx";   //更新材料状态的服务器处理程序  
    var FXID = $("#txtFXID").val();     //直属客户编号
    var FXName = $("#DDL_fx").val(); //直属客户名称
    var ShopID = $("#txtShopID").val();     //店铺编号
    var ShopName = $("#txtShopName").val(); //店铺名称
    
    var tbody = ""; //显示的数据集合
    var Total = ""; //数据总数
    $("#fillTable").html("");
    $.ajax({
       type: "GET",//用GET方式传输
       dataType: "json",//数据格式:JSON
       url: strURL,//目标地址
       data: "p="+(pageindx+1)+"&pagesize="+pagesize+"&did="+DealerID+"&fid="+FXID+"&fname="+FXName+"&sid="+ShopID+"&sname="+ShopName,
       beforeSend:function(){$("#divload").show();$("#Pagination").hide();},//发送数据之前
       complete:function(){$("#divload").hide();$("#Pagination").show()},//接收数据完毕
       success:function(list) {
                
                tbody = "<table class=\"table\" style=\"margin-top:20px; color:navy; float:left; margin-left:20px\">";
                tbody += "<tr style=\"height:22px\">";
                tbody += "<th style=\"width:10%\">流水号</th>";
                tbody += "<th style=\"width:15%\">PosID</th>";
                tbody += "<th>店铺名称</th>";
                tbody += "<th style=\"width:15%\">安装确认</th>";
                tbody += "</tr>";
                for(var i = 0; i < list.length; i++)
        		{
        		    if(list[i].TotleNumber == "0")
        		    {
        			    tbody += "<tr style=\"height:22px;\">";
                        tbody += "<td>" + list[i].SNumberID + "</td>";
                        tbody += "<td>" + list[i].PosID + "</td>";
                        tbody += "<td>" + list[i].Shopname + "</td>";
                        tbody += "<td></td>";
                        tbody += "</tr>";
                    }
                    else
                    {
                        tbody += "<tr style=\"height:22px;text-align:center\">";
                        tbody += "<td>" + list[i].SNumberID + "</td>";
                        tbody += "<td>" + list[i].PosID + "</td>";
                        tbody += "<td>" + list[i].Shopname + "</td>";
                        if(list[i].Boolinstall == "1")
                            tbody += "<td><a href=\"../PhysicalDistribution/SetupToShop.aspx?id="+list[i].ShopID+"&sid="+list[i].SupplierID+"&did="+DealerID+"&fxid="+list[i].FXID+"\">安装确认</a></td>";
                        else
                            tbody += "<td><a href=\"./ConfirmSetUp.aspx?id="+list[i].ShopID+"&popid="+list[i].POPID+"&did="+DealerID+"&sid="+list[i].SupplierID+"&fxid="+list[i].FXID+"&href=1\">安装确认</a></td>";
                        tbody += "</tr>";
                    }
                    Total = list[i].TotleNumber;
                    
        		}
        		tbody += "</table>";
                
                $(tbody).appendTo($("#fillTable"));
                
                var strJS = "pageOperate("+pageindx+","+pagesize+","+Total+")";
                eval(strJS);
        }});
}

function pageselectCallback (page_id)
{
    InitData(page_id,pageSize);
}


function pageOperate(cPage,sPage,total)
{
     $("#Pagination").pagination(total, {
            callback: pageselectCallback,
            prev_text: '« 上一页',
            next_text: '下一页 »',
            items_per_page:sPage,
            num_display_entries:6,
            current_page:cPage,
            num_edge_entries:2
        });
}