

$(function () {
    $("#selectAllRegion").click(function () {
        var checked = this.checked;
        $("input[type='checkbox'][name='area']").each(function () {
            this.checked = checked;
        })
        GetProvinces();
    })

    $("input[type='checkbox'][name='area']").on("click", function () {
        GetProvinces();

    })
})

function GetProvinces() {
    var regionIds = "";
    $("input[type='checkbox'][name='area']:checked").each(function () {
        regionIds += $(this).val() + ",";
    })
    
    $.ajax({
        type: "get",
        url: "handler/Place.ashx?type=getProvince&regionid=" + regionIds,
        success: function (data) {
            $("#provinceDiv").html("");
            if (data != "empty") {
                
                var json = eval("(" + data + ")");
                var div = "";
                for (var i = 0; i < json.length; i++) {
                    div += "<div style='width:140px;float:left;'><input type='checkbox' name='province' value='" + json[i].ProvinceID + "' /> " + json[i].ProvinceName + "</div>";
                }
                $("#provinceDiv").html(div);
            }
        }
    })
}