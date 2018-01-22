// JScript 文件

//发货到直属客户添加或删除单个的店铺
function AddOrDeleteIDBy(obj,isAdd)
{
    var idcontain = obj.id.split("_");    
    var checkid = idcontain[1];
    
    var ShopID = $("#RepShopList_"+checkid+"_lblID").val();    
    var DealerID = $("#RepShopList_"+checkid+"_lblDealerID").val();
    var popnum =$("#RepShopList_"+checkid+"_lbl_popnum").val();    
    var fx = $("#RepShopList_"+checkid+"_lbfx").val();
    var isadd = isAdd;
    
    $.get("./ashx/SaveIDToSession.ashx?"+new Date(),{ShopID:ShopID,DealerID:DealerID,popnum:popnum,fx:fx,isAdd:isadd},function(data){
            
    });   

}

////发货到直属客户全选或全部删除店铺
//function AddOrDeleteIDAllBy(obj,isAdd)
//{
//    var idcontain = obj.id.split("_");    
//    var checkid = idcontain[1];    
//    var ShopID = $("#RepShopList_"+checkid+"_lblID").val();      
//    var DealerID = $("#RepShopList_"+checkid+"_lblDealerID").val();
//    var popnum =$("#RepShopList_"+checkid+"_lbl_popnum").val();
//    var fx = $("#RepShopList_"+checkid+"_lbfx").val();
//    var isadd = isAdd;
//    
//    $.get("./ashx/SaveIDAllToSession.ashx?"+new Date(),{ShopID:ShopID,DealerID:DealerID,popnum:popnum,fx:fx,isAdd:isadd},function(data){
//            
//    });   

//}

//发货到一级客户添加或删除单个的店铺
function AddOrDeleteIDsBy(obj,isAdd)
{
    var idcontain = obj.id.split("_");    
    var checkid = idcontain[1];    
    var ShopID = $("#RepShopList_"+checkid+"_lblID").val();
    var DealerID = $("#RepShopList_"+checkid+"_lblDealerID").val();
    var popnum =$("#RepShopList_"+checkid+"_lbl_popnum").val();
    var fx = $("#RepShopList_"+checkid+"_lbfx").val();
    var isadd = isAdd;
    
    $.get("./ashx/SaveIDsToSession.ashx?"+new Date(),{ShopID:ShopID,DealerID:DealerID,popnum:popnum,fx:fx,isAdd:isadd},function(data){
            
    });   

}



////发货到一级客户全选或全部删除店铺
//function AddOrDeleteIDsAllBy(obj,isAdd)
//{
//    var idcontain = obj.id.split("_");    
//    var checkid = idcontain[1];    
//    var ShopID = $("#RepShopList_"+checkid+"_lblID").val();   
//    var DealerID = $("#RepShopList_"+checkid+"_lblDealerID").val();
//    var popnum =$("#RepShopList_"+checkid+"_lbl_popnum").val();
//    var isadd = isAdd;
//    
//    var fx = $("#RepShopList_"+checkid+"_lbfx").val();
//    
//    $.get("./ashx/SaveIDsAllToSession.ashx?"+new Date(),{ShopID:ShopID,DealerID:DealerID,popnum:popnum,fx:fx,isAdd:isadd},function(data){
//            
//    });   

//}