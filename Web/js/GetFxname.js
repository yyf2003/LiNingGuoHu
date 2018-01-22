// JScript 文件

// JScript 文件


//var provinceID=$("#DDL_Province").val();

function GetFxbyDealerid(dealerid)
{
var url='../ashx/GetFXByDealer.ashx';
 if(dealerid=='0')
 {
   $("#DDL_fx").empty();
    $("<option value=0>请选择店铺的直属客户</option>").appendTo($("#DDL_fx"))
  }
 else
  {
        $.getJSON(url,{dealerid:dealerid},function(list)
        {
           $("#DDL_fx").empty();
           var plist="<option value=0>请选择店铺的直属客户</option>";
           for(var i=0;i<list.length;i++)
           {
              if(list[i].ID!="0")
                    plist+="<option value="+list[i].ID+">"+list[i].fxname+"</option>";
           }
           $(plist).appendTo($("#DDL_fx"));
        })
    }
}

function GetFxlist()
{
   var dealerid=$("#ddl_dealer").val();
   GetFxbyDealerid(dealerid);
 
}