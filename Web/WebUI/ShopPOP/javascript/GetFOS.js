// JScript 文件
function GetFosPOPSeat(POPSeatInfo,ShopID)
{
    var url='./ashx/GetFOS.ashx?'+new Date();
    $.getJSON(url,{seat:POPSeatInfo},function(list)
    {
        if(list[0].FOS_ID!="0")
        {
            if(list[0].FOS_POPSeat != "橱窗")
            {
                GetPOPMaterial(0,list[0].FOS_POPMateria,ShopID);
                $("#DDL_POPMaterial").val(list[0].FOS_POPMateria);
                $("#DDL_POPMaterial").attr("readonly","readonly");
                
                $("#txt_realwidth").val(list[0].FOS_POPRealWith);
                $("#txt_realwidth").attr("readonly","readonly");
                
                $("#txt_realheight").val(list[0].FOS_POPRealHeight);
                $("#txt_realheight").attr("readonly","readonly");
                
                $("#txt_POPWith").val(list[0].FOS_POPWith);
                $("#txt_POPWith").attr("readonly","readonly");
                
                $("#txt_POPHeight").val(list[0].FOS_POPHeight);
                $("#txt_POPHeight").attr("readonly","readonly");
            }
            else
            {
                GetPOPMaterial(1,list[0].FOS_POPMateria,ShopID);
                $("#DDL_POPMaterial").val("");
                $("#DDL_POPMaterial").removeAttr("readonly");
                
                $("#txt_realwidth").val("");
                $("#txt_realwidth").removeAttr("readonly");
                
                $("#txt_realheight").val("");
                $("#txt_realheight").removeAttr("readonly");
                
                $("#txt_POPWith").val("");
                $("#txt_POPWith").removeAttr("readonly");
                
                $("#txt_POPHeight").val("");
                $("#txt_POPHeight").removeAttr("readonly");
            }
            
        }
        
    })
}

function GetPOPMaterial(typeID,POPMateriaName,ShopID)
{
    $("#DDL_POPMaterial").empty();
    if(typeID==0)
    {
        var plist="<option value=\"0\">请选择POP材质</option>";
        plist+="<option value="+POPMateriaName+">"+POPMateriaName+"</option>";
        $(plist).appendTo($("#DDL_POPMaterial"));
    }
    else
    {
        var url='./ashx/GetPOPMaterial.ashx?'+new Date();
        $.getJSON(url,{id:ShopID},function(list)
        {
            var mlist="<option value=\"0\">请选择POP材质</option>";
            for(var i=0;i<list.length;i++)
            {
                mlist+="<option value="+list[i].materiapro+">"+list[i].materiapro+"</option>";
            }
            $(mlist).appendTo($("#DDL_POPMaterial"));
        })
    }
}

