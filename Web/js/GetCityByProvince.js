// JScript 文件


//var provinceID=$("#DDL_Province").val();

function GetCityname(provinceID) {
   
 var url='../ashx/GetCityName.ashx';
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
        if(list[i].ID!="0")
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


function GetVmByproID(provinceID)
{
  var url='../ashx/GetVmMasterByProvinceID.ashx?'+new Date();
 
  if(provinceID=='0')
    { 
        $("#DDL_Area").attr("value","0");
        $("#Txt_VMMaster").val("");
        $("#Txt_VMMasterPhone").val("");
    }
  else
    { //alert(provinceID);
       $.getJSON(url,{ID:provinceID},function(list)
       {
      // alert(list);
         $("#DDL_Area").attr("value",list[0].aid);
         $("#Txt_VMMaster").val(list[0].VMName);
         $("#Txt_VMMasterPhone").val(list[0].VMTel);
         GetDeptByarea(list[0].aid);
       }
       )
    }
 }

function GetDeptByarea(areaID)
{
   var url="../ashx/GetdepartMentByarea.ashx?"+new Date();
   
   if(areaID=='0')
   {
     $("#DDL_Area").attr("value","0");
   }
   else
   {
     $.get(url,{ID:areaID},
      function(date)
      {
       $("#DDL_department").attr("value",date);
      }
     )
   }
}

function GetAreaName(DName) {
    var MyAreas = [];
    if ($("#hfAreas").val()) {
        var areas = $("#hfAreas").val() || "";
        if ($.trim(areas) != "") {
            MyAreas = areas.split(',');
        }
    }
    
	var url="../ashx/GetAreaByDepID.ashx?"+new Date();
	if(DName=='0')
	{
		$("#DDL_Area").empty();
		$("<option value=0>请选择区域</option>").appendTo($("#DDL_Area"));
	}
	else
	{
	    $.getJSON(url, { depName: DName }, function (list) {
	        $("#DDL_Area").empty();
	        
	        var plist = "<option value=0>请选择区域</option>";
	        for (var i = 0; i < list.length; i++) {
	            if (list[i].AreaID != "0") {

	                if (MyAreas.length > 0) {
	                    var isOk = false;
	                    $.each(MyAreas, function (key, val) {
	                        
	                        if (parseInt(val) == parseInt(list[i].AreaID)) {
	                            isOk = true;

	                        }
	                    })
	                    if (isOk) {
	                        plist += "<option value=" + list[i].AreaID + ">" + list[i].AreaName + "</option>";
	                    }
	                }
	                else
	                    plist += "<option value=" + list[i].AreaID + ">" + list[i].AreaName + "</option>";
	            }

	        }
	        $(plist).appendTo($("#DDL_Area"));
	    })
	}
}

