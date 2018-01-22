
$(function () {
    $("#checkShops").on("click", function () {
        GetVal();
        //var href = "CheckSelectShops.aspx?shopsaletype=" + $("#hfShopST").val() + "&shoplevel=" + $("#hfShoplevel").val() + "&shoptype=" + $("#hfShopType").val() + "&shopvi=" + $("#hfShopVI").val() + "&areacitylevel=" + $("#hfACL").val() + "&towncitylevel=" + $("#hfTCL").val() + "&area=" + $("#hfRegion").val() + "&province=" + $("#hfProvince").val();
        var href = "CheckSelectShops.aspx?shopsaletype=" + $("#hfShopST").val() + "&shoplevel=" + $("#hfShoplevel").val() + "&shoptype=" + $("#hfShopType").val() + "&shopvi=" + $("#hfShopVI").val() + "&area=" + $("#hfRegion").val() + "&province=" + $("#hfProvince").val();
        $.fancybox.open({
            href: href,
            type: 'iframe',
            padding: 5,
            width: "90%"


        });

    })
})

function GetVal() {
    var shopSaleType = "";
    $("input[type='checkbox'][name='shopSaleType']:checked").each(function () {
        shopSaleType += $(this).val() + ",";
    })
    $("#hfShopST").val(shopSaleType);

    var shopLevel = "";
    $("input[type='checkbox'][name='shopLevel']:checked").each(function () {
        shopLevel += $(this).val() + ",";
    })
    $("#hfShoplevel").val(shopLevel);

    var shopType = "";
    $("input[type='checkbox'][name='shopType']:checked").each(function () {
        shopType += $(this).val() + ",";
    })
    $("#hfShopType").val(shopType);

    var shopVI = "";
    $("input[type='checkbox'][name='shopVI']:checked").each(function () {
        shopVI += $(this).val() + ",";
    })
    $("#hfShopVI").val(shopVI);

//    var AreaCityLevel = "";
//    $("input[type='checkbox'][name='AreaCityLevel']:checked").each(function () {
//        AreaCityLevel += $(this).val() + ",";
//    })
//    $("#hfACL").val(AreaCityLevel);

//    var TownCityLevel = "";
//    $("input[type='checkbox'][name='TownCityLevel']:checked").each(function () {
//        TownCityLevel += $(this).val() + ",";
//    })
//    $("#hfTCL").val(TownCityLevel);
    var count = 0;
    var area = "";
    $("input[type='checkbox'][name='area']:checked").each(function () {
        area += $(this).val() + ",";
        count++;
    })
    $("#hfRegion").val(area);
    
    var province = "";
    $("input[type='checkbox'][name='province']:checked").each(function () {
        province += $(this).val() + ",";
        count++;
    })
    $("#hfProvince").val(province);
    
    return count;
}