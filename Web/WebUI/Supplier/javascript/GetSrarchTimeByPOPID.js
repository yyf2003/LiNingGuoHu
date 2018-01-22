/*

 *author:秦浩 

 *Create date: 2010-12-03
 
 *Description: 根据POPID获取最后下载订单的时间

*/

function GetSrarchTimeByPOPIDJS(POPID)
{
    var popid = POPID;
    var URL = "./CallBack/GetSrarchTimeByPOPID.ashx?" + new Date();   //接收客户端参数的服务器处理程序
    
    $.get(URL,{id:popid},
    //回调函数
    function(returnData){
       if(returnData != ""){
            $("#txtBeginDate").val(returnData)
       }
    });
}
