// JScript 文件

function GetAreaName(dept) {
    
    var url = '../ashx/GetAreaBydepartMent.ashx';
    if (dept == '0') {
        $("#DDL_Area").attr("value", "0");
    }
    else {
        $.getJSON(url, { dept: dept }, function (list) {
            
            $("#DDL_Area").empty();
            var plist = "<option value=0>请选择区域名称</option>";
            for (var i = 0; i < list.length; i++) {
            if (list[i].ID != "0")
            plist += "<option value=" + list[i].ID + ">" + list[i].IName + "</option>";
            }
            $(plist).appendTo($("#DDL_Area"));


            
           
        })
    }
}
