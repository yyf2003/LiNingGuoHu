// JScript 文件

function getProductLine(TypeId,Popid)
{
  //var typeid=$("#DDL_ProductType").val();
  var url='ashx/GetProductlineBytypeID.ashx';
 if(TypeId=='0')
 {
   //$("#DDL_productline").empty();
   // $("<option value=0>请选择POP的故事包</option>").appendTo($("#DDL_productline"))
  }
 else
  {
        $.getJSON(url,{typeid:TypeId,popid:Popid},function(list)
        {
        alert(list);
//           $("#DDL_productline").empty();
//           var plist="<option value=0>请选择POP的故事包</option>";
//           for(var i=0;i<list.length;i++)
//           {
//              if(list[i].pid!="0")
//               plist+="<option value="+list[i].pid+">"+list[i].linename+"</option>"
//               }
//               $(plist).appendTo($("#DDL_productline"))
        })
    }
}