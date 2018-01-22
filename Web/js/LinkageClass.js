// JScript 文件

function LinkageClass(){}

//根据部门编号获取区域信息
LinkageClass.prototype.GetProvinceName = function (areaID)
{ 
    var url = "../ashx/GetProvinceName.ashx?" + new Date();
    if(areaID=='0')
    {
        $("#DDL_Province").empty();
        $("<option value=\"0\">请选择省</option>").appendTo($("#DDL_Province"));
    }
    else
    {
        $.getJSON(url,{areaid:areaID},function(list)
        {
            $("#DDL_Province").empty();
            var plist="<option value=\"0\">请选择省</option>";
            for(var i=0;i<list.length;i++)
            {
                plist+="<option value=\""+list[i].Proid+"\">"+list[i].Proname+"</option>";
            }
            $(plist).appendTo($("#DDL_Province"));
        });
    }
   
}

//根据一级客户编号获取直属客户信息
LinkageClass.prototype.GetFxbyDealerid = function (dealerid)
{
    var url = "../ashx/GetFXByDealer.ashx?" + new Date();
    if(dealerid=='0')
    {
        $("#DDL_Dis").empty();
        $("<option value=\"0\">请选择直属客户</option>").appendTo($("#DDL_Dis"));
    }
    else
    {
        $.getJSON(url,{dealerid:dealerid},function(list)
        {
            $("#DDL_Dis").empty();
            var plist="<option value=\"0\">请选择直属客户</option>";
            for(var i=0;i<list.length;i++)
            {
                if(list[i].ID!="0")
                    plist+="<option value=\""+list[i].ID+"\">"+list[i].fxname+"</option>";
            }
            $(plist).appendTo($("#DDL_Dis"));
        });
    }
}

//根据区域编号获取一级客户信息
LinkageClass.prototype.GetDealerByAreaID = function (areaID)
{
    var url = "../ashx/GetDealerByAreaID.ashx?" + new Date();
    if(areaID=='0')
    {
        $("#DDL_DealerInfo").empty();
        $("<option value=\"0\">请选择一级客户</option>").appendTo($("#DDL_DealerInfo"));
    }
    else
    {
        $.getJSON(url,{areaID:areaID},function(list)
        {
            $("#DDL_DealerInfo").empty();
            var plist="<option value=\"0\">请选择一级客户</option>";
            for(var i=0;i<list.length;i++)
            {
                if(list[i].ID!="0")
                    plist+="<option value=\""+list[i].ID+"\">"+list[i].dname+"</option>";
            }
            $(plist).appendTo($("#DDL_DealerInfo"));
        });
    }
}