// JScript 文件


//var provinceID=$("#DDL_Province").val();

function GetCityname(provinceID)
{var url='../ashx/GetCityName.ashx';
 if(provinceID=='0')
 {
   $("#DDL_city").empty();
    $("<option value=0>请选择市</option>").appendTo($("#DDL_city"))
  }
 else
  {
    $.getJSON(url,{ProvinceID:provinceID},function(list)
    {
    $("#DDL_city").empty();
       var plist="<option value=0>请选择市</option>";
       for(var i=0;i<list.length;i++)
       {
       plist+="<option value="+list[i].ID+">"+list[i].IName+"</option>"
       }
      $(plist).appendTo($("#DDL_city"))
    })
    }
}

function GetcityList()
{
var provinceID=$("#DDL_Province").val();
   GetCityname(provinceID);
 
}