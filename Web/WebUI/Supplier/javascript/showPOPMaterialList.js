/*

 *author:秦浩 

 *Create date: 2009-05-09
 
 *Description: 显示指定供应商的材料报价

*/
var divNum = 0;
function showPOPMaterialList(sID,userID)
{
    this.sid = sID;             //供应商编号
    this.userID = userID;       //用户编号
    this.url = "./CallBack/showPOPMaterialList.ashx?" + new Date();   //接收客户端参数的服务器处理程序
    this.num = divNum + 1;
}

showPOPMaterialList.prototype.getList = function()
{
    $.getJSON(this.url,{sID:this.sid , uID:this.userID },function(list){

                var strID = Math.floor(Math.random()*1000000);
                var pList = "<div id=\"" + strID + "\" style=\"width:800px;border:1px solid #6d6060; margin-top:10px;\"> ";
                pList += "<div style=\"width:50px; background-color:red;color:white; float:right; cursor:pointer\" onclick='javascript:$(\"#"+strID+"\").css(\"display\",\"none\");'>关  闭</div>"; //显示列表
                for(var i = 0; i < list.length; i++)
                    pList += "<div class=\"cailiao\">" + list[i].POPMaterial + "：" + list[i].POPprice + "</div>";
                pList += "<br /><br /><br /><br /><br /></div>";
                $("#waitDIV").css("display","none");
                var temp = $("#showPOPMaterial").html() + pList;
                 $("#showPOPMaterial").html(temp);
     });
}

