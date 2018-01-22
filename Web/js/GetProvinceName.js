// JScript 文件

function GetProvincename(areaID) {
   
    var url = '../ashx/GetProvinceName.ashx';
    if (areaID == '0') {
        $("#DDL_Province").empty();
        $("<option value=0>请选择省</option>").appendTo($("#DDL_Province"))
    }
    else {
        $.getJSON(url, { areaid: areaID }, function (list) {
            $("#DDL_Province").empty();
            var plist = "<option value=0>请选择省</option>";
            for (var i = 0; i < list.length; i++) {
                plist += "<option value=" + list[i].Proid + ">" + list[i].Proname + "</option>"
            }
            $(plist).appendTo($("#DDL_Province"))
        })
    }
}


function GetprovinceList() {
    var areaid = $("#DDL_Area").val();
    $("#hfAreaId").val(areaid);
    GetProvincename(areaid);
    GetCityname('0');
}
