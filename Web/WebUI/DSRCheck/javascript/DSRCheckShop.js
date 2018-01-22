// JScript 文件

        //id Check_Yes服务器控件在客户端的ID
        //Remarks  备注在客户端的ID
        //Flag 选择是
        //显示分数的Lable客户端的ID
		function chooesYes(id,Remarks,NoID,fen)
		{
		    //alert(id);
		    //alert($("#"+id).attr("checked"));
			if($("#"+id).attr("checked")==true)
			{
			   $("#"+fen).val("是");
			   $("#"+Remarks).val("");
			   $("#"+NoID).attr("checked",false);
			}else
			{
			  $("#"+fen).val("");
			}
		}
		
		function chooesNo(id,Remarks,YesID,fen)
		{
		   if($("#"+id).attr("checked")==true)
			{
			   $("#"+fen).val("否");
			   $("#"+Remarks).val("请填写备注");
			   $("#"+YesID).attr("checked",false);
			}else
			{
			  $("#"+fen).val("");
			   $("#"+Remarks).val("");
			}
		}
		//判断是否每个项目都做了检查录入
		function Checkall()
		{
		
		  var i=0;
		  var r=0;
		  $("#GridView1 *").each(function(){
		  if($(this).attr("type")=="text")
		  {
             if($(this).val()=="" || $(this).val()=="请选择")
             {
               $(this).cssName="nochoose";
               $(this).val("请选择");
               i++;
             }
		  }
		  })
//		  $("#GridView1 textarea").each(function(){
//		  if($(this).val()=="请填写备注")
//		   r++;
//		  }
//		  )
		  if(i>0)
		  {
		  alert("请将提示“请选择”的项目检查完成");
		  return false;
		  }
//		  if(r>0)
//		  {
//		    alert("请将选择否的项目 填写备注");
//		    return false;
//		  }
		  return true;
		}