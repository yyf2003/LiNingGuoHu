// JScript 文件
function returnfalse()
{
  return false;
}
function checkdata(shopID)
{

   if($('#DDL_Popseat').val()=="0")
   {
      $.prompt("请选择POP画面的位置!");
      $('#DDL_Popseat').focus();
      return false;
   }
   if($.trim($('#txt_seatNum').val())=="")
   {
      $.prompt("请正确填写POP编号!");
      $('#txt_seatNum').focus();
      return false;
   }

   if($.trim($('#txt_SeatDesc').val())=="")
   {
     $.prompt("请正确填写位置描述!");
     $('#txt_SeatDesc').focus();
     return false;
   }
   if($('#DDL_sexarea').val()=="0")
   {
      $.prompt("请选择男女区域!");
      $('#DDL_sexarea').focus();
      return false;
   } 
    if(!isnumber($.trim($('#txt_realwidth').val())))
     {
       $.prompt("请正确填写POP实际制作宽!只能为数字");
      $('#txt_realwidth').focus();
      return false;
     }
   if(!isnumber($.trim($('#txt_realheight').val())))
     {
       $.prompt("请正确填写POP实际制作高!只能为数字");
      $('#txt_realheight').focus();
      return false;
     }

   if($.trim($('#txt_POPWith').val())=='')
   {
      $.prompt("请正确填写POP可视画面宽!");
      $('#txt_POPWith').focus();
      return false;
   }
   else
   {
     if(!isnumber($.trim($('#txt_POPWith').val())))
     {
       $.prompt("请正确填写POP可视画面宽!只能为数字");
      $('#txt_POPWith').focus();
      return false;
     }
   }
   
   if($.trim($('#txt_POPHeight').val())=='')
   {
      $.prompt("请正确填写POP可视画面高!");
      $('#txt_POPHeight').focus();
      return false;
   }
   else
   {
     if(!isnumber($.trim($('#txt_POPHeight').val())))
     {
       $.prompt("请正确填写POP可视画面高!只能为数字");
      $('#txt_POPHeight').focus();
      return false;
     }
   }
   if($('#DDL_plwz').val()=='0')
   {
      $.prompt("请选择POP可视画面偏离位置");
      $('#DDL_plwz').focus();
      return false;
   }
   if($('#DDL_pljd').val()=='-1')
   {
      $.prompt("请选择POP可视画面偏离角度");
      $('#DDL_pljd').focus();
      return false;
   }
   if($('#DDL_POPMaterial').val()=="0")
   {
       $.prompt("请正确填写POP的材质");
       $('#DDL_POPMaterial').focus();
       return false;
   }
   else if($('#DDL_POPMaterial').val()=="其他")
   {
   		if($.trim($('#txt_POPMaterialRemark').val()) == "")
   		{
   			$.prompt("请输入POP备注说明！！");
       		$('#txt_POPMaterialRemark').focus();
       		return false;
   		}
   }
   
   if($('#DDL_ProductLine').val()=="0")
   {
       $.prompt("请正确填写POP的产品系列");
      $('#DDL_ProductLine').focus();
      return false;
   }
   
   if(!isint($.trim($('#txt_PlatformLong').val())))
   {
      $.prompt("请正确填写橱窗空间进深!只能为数字");
      $('#txt_PlatformLong').focus();
      return false;
   }
   
   if(!isint($.trim($('#txt_PlatformWith').val())))
   {
      $.prompt("请正确填写橱窗空间长度!只能为数字");
      $('#txt_PlatformWith').focus();
      return false;
   }
   
   if(!isint($.trim($('#txt_PlatformHeight').val())))
   {
      $.prompt("请正确填写橱窗面积!只能为数字");
      $('#txt_PlatformHeight').focus();
      return false;
   }
   
   if($('#FupPOPImg1').val()=='' && $('#FupPOPImg2').val()=='' && $('#FupPOPImg3').val()=='')
   {
      $.prompt("请您上传相关图片");
     return false;
   }

   return true;
}

function getProductLine()
{
  var typeid=$("#DDL_ProductType").val();
  var url='ashx/GetPOPProductByType.ashx';
 if(typeid=='0')
 {
   $("#DDL_ProductLine").empty();
    $("<option value=0>请选择POP的产品系列</option>").appendTo($("#DDL_ProductLine"))
  }
 else
  {
        $.getJSON(url,{typeid:typeid},function(list)
        {
           $("#DDL_ProductLine").empty();
           var plist="<option value=0>请选择POP的产品系列</option>";
           for(var i=0;i<list.length;i++)
           {
              if(list[i].pid!="0")
               plist+="<option value="+list[i].pid+">"+list[i].linename+"</option>"
               }
               $(plist).appendTo($("#DDL_ProductLine"))
        })
    }
}