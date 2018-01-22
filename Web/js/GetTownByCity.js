// JScript 文件

function GetTownname(cID)
{
 var url='../ashx/GetTownName.ashx';
 if(cID=='0')
 {
   $("#DDL_town").empty();
    $("<option value='0'>请选择区级市</option>").appendTo($("#DDL_town"))
  }
 else
  {
    $.getJSON(url,{cityid:cID},function(list)
    {
    $("#DDL_town").empty();
       var plist="<option value='0'>请选择区级市</option>";
       for(var i=0;i<list.length;i++)
       {
       plist+="<option value="+list[i].townid+">"+list[i].IName+"</option>"
       }
      $(plist).appendTo($("#DDL_town"))
    })
    }
}

