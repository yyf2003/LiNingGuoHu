<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserReportDamageList.aspx.cs"
    Inherits="WebUI_ReportDamage_UserReportDamageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报损列表</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/showDIV.css" />

    <script language="javascript" type="text/javascript" src="../../js/calendar.js"></script>


    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <script type="text/javascript" src="../../js/ShowImg.js"></script>


    <script> 
     var dt1="";
     var dt2=""; 
     var  satation ="";
     var arry ="";
     var d1="";
     var d2=""; 
     function CheckTime()
     {
        d1 =$("#txtStartTime").val();
        d2 =$("#txtEndTime").val(); 
     arry ="";
    if(d1!="")
   {
      var arr1 =d1.toString ().split ('-'); 
      if(d2!="")
     { 
      var arr2 =d2.toString ().split ('-');   
      dt1 =new Date(arr1[0],arr1[1],arr1[2]);
      dt2 =new Date(arr2[0],arr2[1],arr2[2]); 
     if(dt1-dt2>0)
     {
       $.prompt("结束时间不能小于开始时间！",{callback:timefocus});
       return false;
     } 
     } 
     else
     {
         $.prompt("请选择结束时间！",{callback:timefocus});
        return false; 
     } 
   }  
    
   satation =$("#vmstation").val();
  
   if(d1!="")
  {
    arry ="?StartTime="+d1;   
    arry +="&EndTime="+d2; 
     if(satation!="")
     {
        arry +="&Station="+satation; 
     }  
  }   
  else
  {
       if(satation!="")
       {
      arry ="?Station="+satation; 
       }
  } 
 
 location.href ="UserReportDamageList.aspx"+arry; 
     } 
      function timefocus()
  {
   $("txtEndTime").focus(); 
  }  
     
    </script>

</head>
<body >
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" class="table">
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;">
            <tr>
                <td width="100px">
                    开始时间:
                </td>
                <td width="350px">
                    <input id="txtStartTime" type="text" onclick="setday(this,document.getElementById('txtStartTime'))"
                        readonly="readOnly"  class ="txtwith" />
                </td>
                <td width="100px">
                    结束时间:
                </td>
                <td>
                     <input id="txtEndTime" type="text" onclick="setday(this,document.getElementById('txtEndTime'))"
                        readonly="readOnly"  class ="txtwith"/> 
                </td>
            </tr>
            <tr>
                <td width="100px">
                    状态：
                </td>
                <td>
                    <select id="vmstation" class ="DDlstyle">
                        <option value="0">未通过</option>
                        <option value="1">通过</option>
                    </select>
                </td>
                <td colspan="2">
                    <input id="Button1" type="button" value="查询" class="qr0" onclick="return CheckTime();" /></td>
            </tr>
        </table>
        <div class="table" style="margin-top: 3px;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="899px"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="图片">
                        <ItemTemplate>
                            <%#Eval("PhotoPath").ToString() == "" ? "" : "<img src='../" + Eval("PhotoPath") + "' / width='22' height='22' alt='" + Eval("ShopDesc") + "' border='0'  onclick=\"javascript:ShowImg('40%','40%','600px','50px','450px','',this.src)\">"%>
                        </ItemTemplate>
                        <HeaderStyle Width="4%" />
                        <ItemStyle Width="4%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="提交时间">
                        <ItemTemplate>
                            <%#Eval("UpPOPDate")%>
                        </ItemTemplate>
                        <HeaderStyle Width="18%" />
                        <ItemStyle Width="18%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="描述">
                        <ItemTemplate>
                            <%#Eval("ShopDesc")%>
                            </textarea>
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VM描述">
                        <ItemTemplate>
                            <%#Eval("VMDesc") %>
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <%#Eval("VMState").ToString()=="1"?"已通过":"未通过"%>
                        </ItemTemplate>
                        <HeaderStyle Width="8%" />
                        <ItemStyle Width="8%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
