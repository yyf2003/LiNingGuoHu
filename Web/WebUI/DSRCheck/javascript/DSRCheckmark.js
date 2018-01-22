// JScript 文件

function bjsj(t1,t2)
{
   var a=new Date(t1);
   var b=new Date(t2);
   if(t2<=t1)
   {
     alert('结束时间要大于开始时间');
     return false;
   }
   else
   {
     return true;
   }
}