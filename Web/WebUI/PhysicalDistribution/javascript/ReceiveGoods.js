// JScript 文件

function submitdata(userid,pid)
{
 var chkBoxlist = $("input[type='checkbox']");      //复选框集合
 var checkshopid='';
 var IsCheck=0;
    for(var i = 0; i < chkBoxlist.length; i++)
    {
        if(chkBoxlist[i].checked)
        {
            IsCheck ++;
           // checkshopid=checkshopid+chkBox[i].attr("value")+',';
           //alert(chkBoxlist[i].attr('value'));
        }
    }
    if(IsCheck=0)
    {
      alert('请选择店铺');
      return false;
    }
//    if(IsAllCheck>0)
//    {
//       var sj=$('#txt_time').val();
//       var fenshu=$('#fs').val();
//       var pingjia=$('#txt_fk').val();
//       
//       $.get('/ashx/receiveGoods.ashx',{uid:userid,rdate:sj,fs:fenshu,pj:pingjia,popid:pid,shopid:checkshopid},function(data){
//            if(data>0)
//            {
//              alert('确认成功');
//              window.location.href='ReceiveGoods.aspx';
//            }
//       }
//       );
//    }
 }