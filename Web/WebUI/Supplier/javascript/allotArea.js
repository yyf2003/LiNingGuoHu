// JScript 文件



function GetArea(dept)
{
  $('#areadiv')[0].style.display='';
  if($('#'+dept).attr('checked'))
  {
   var divlist= $("#areadiv div").get();
   disp(divlist,dept,'');
  }
  if(!$('#'+dept).attr('checked'))
  {
   var divlist= $("#areadiv div").get();
   disp(divlist,dept,'none');
   clearchoose(divlist,dept);
  }
}
//通过区域ID得到相应的省市
function GetProvince(areaid)
{
  $('#pro')[0].style.display='';
  if($('#'+areaid).attr('checked'))
  {
   var divlist= $("#pro div").get();
   disp(divlist,areaid,'');
  }
  if(!$('#'+areaid).attr('checked'))
  {
   var divlist= $("#pro div").get();
   disp(divlist,areaid,'none');
   clearchoose(divlist,areaid);
  }
}
//控制层的现实和隐藏
function disp(tdlist,oid,flag)
{
  for(var i=0;i<tdlist.length;i++)
  {
    if(tdlist[i].id=='a'+oid)
    {
      tdlist[i].style.display=flag;
    }
  }
}
//把隐藏的checkbox 的状态改为未选择状态
function clearchoose(tdlist,oid)
{
  for(var i=0;i<tdlist.length;i++)
  {
    if(tdlist[i].style.display=='none')
    {
      tdlist[i].firstChild.checked=false;
    }
  }
}

//把隐藏的checkbox 的状态改为未选择状态
function clearTownchoose(tdlist,oid,flag)
{
  for(var i=0;i<tdlist.length;i++)
  {
    if(tdlist[i].style.display=='none')
    {
      tdlist[i].firstChild.checked=flag;
    }
    if(tdlist[i].style.display=='')
    {
      tdlist[i].firstChild.checked=flag;
    }
  }
}
//显示和隐藏相应的子项目
function GetCity(proid)
{
$('#citytable')[0].style.display='';
if($('#'+proid).attr('checked'))
  {
   var divlist= $("#citytable div").get();
   disp(divlist,proid,'');
  }
   if(!$('#'+proid).attr('checked'))
  {
   var divlist= $("#citytable div").get();
   disp(divlist,proid,'none');
   clearchoose(divlist,proid);
  }
}
var deptlist="";
var arealist="";
var citylist="";
function checkData()
{
 deptlist="";
 arealist="";
 citylist="";
//得到选择的部门名称
var deptdivlist= $("#deptdiv input[type=checkbox]").get();
   for(var i=0;i<deptdivlist.length;i++)
     {
         if(deptdivlist[i].checked)
            {
               deptlist+=deptdivlist[i].value+",";
            }
     }
//得到选择的省区名称
var prodivlist= $("#pro input[type=checkbox]").get();
   for(var i=0;i<prodivlist.length;i++)
     {
         if(prodivlist[i].checked)
            {
               citylist+=prodivlist[i].value+",";
            }
     }
   var a=0;
   var divlist= $("#areadiv input[type=checkbox]").get();
   //alert(divlist.length);
   for(var i=0;i<divlist.length;i++)
   {//alert(divlist[i].checked);
    if(divlist[i].checked)
    {
       arealist+=divlist[i].value+",";
       a++;
    }
  }
  if(a<=0)
  {
    alert('您没有选择任何的省区，请重新选择！');
    return false;
  }
  return true;
}
if(citylist.length>0)
  citylist=citylist.substr(0,citylist.length-1);
if(arealist.length>0)
  arealist=arealist.substr(0,arealist.length-1);
if(deptlist.length>0)
  deptlist=deptlist.substr(0,deptlist.length-1);
//function GetTown(cityid)
//{
//$('#towntable')[0].style.display='';

// if($('#'+cityid).attr('checked'))
//  {
//   var divlist= $("#towntable div").get();
//   disp(divlist,cityid,'');
//   clearTownchoose(divlist,cityid,false);
//  }
// if(!$('#'+cityid).attr('checked'))
//  {
//   var divlist= $("#towntable div").get();
//   disp(divlist,cityid,'none');
//   clearTownchoose(divlist,cityid,false);
//  }
//}
function GetselctShop(id)
{

   if(!checkData())
   {
      return false;
   }
   else
   {
     var url="allotarea_getShopByarea.aspx?citylist="+citylist+"&deptlist="+escape(deptlist)+"&arealist="+arealist+"&id="+id;
   // alert(url);
     onObjMore(url,"shop","800px","1000px","form1");
   }
}

 function onObjMore(url,name,height,width,formName) {
		 //window.alert(formName.file.type);
		 var feature = "dialogWidth:"+width+"px;dialogHeight:"+height+"px;scroll:yes;status:no;help:no;center:1";
		 var returnTarget = window.showModalDialog(url, name, feature);
		 //alert(returnTarget);
		 if(returnTarget != undefined && returnTarget.length > 0) {
		  //document.location = returnTarget;
	
		 $("#HF_shopid").val(returnTarget);
  }
 return false;
}