// JScript 文件
function GetVmMasterByAreaID(AreaID)
{
    var url="../ashx/GetVmMasterByAreaID.ashx?" + new Date();

    $.getJSON(url,{areaID:AreaID},function(list){

        for(var i=0;i<list.length;i++)
        {
            if(list[i].VMName!="0")
            {
                $("#Txt_VMMaster").val(list[i].VMName);
                $("#Txt_VMMasterPhone").val(list[i].VMTel);
            }
        }
    })
}
