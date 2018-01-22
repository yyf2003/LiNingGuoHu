<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierReport.aspx.cs" Inherits="WebUI_ReportDamage_SupplierReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报损列表</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <style>
   a:link{text-decoration :none; color:#424242;}
   a:visited{text-decoration :none;color:#424242;}
   a:active{text-decoration :none;}
   a:hover{text-decoration :underline;}  
    </style>

    <script language="javascript" type="text/javascript" src="../../js/calendar.js"></script>

    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <!--  end-->

    <script>
     
     var dt1="";
     var dt2=""; 
     var  SupplierID ="";
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
     
  
   if(d1!="")
  {
    arry ="?StartTime="+d1;
  
     if(d2!="")
     {
        arry +="&EndTime="+d2;
     }  
  }   
  alert(arry);
 location.href ="ReportDamageList.aspx"+arry;
 
     } 
      function timefocus()
  {
   $("txtEndTime").focus(); 
  }  
     
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" class="table">
            <tr>
                <td>
                    POP报损--供应商:<%#SupplierName %>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;">
            <tr>
                <td width="100px">
                    开始时间:
                </td>
                <td width="350px">
                    <input id="txtStartTime" type="text" onclick="setday(this,document.getElementById('txtStartTime'))"
                        readonly="readOnly" />
                </td>
                <td width="100px">
                    结束时间:
                </td>
                <td>
                    <input id="txtEndTime" type="text" onclick="setday(this,document.getElementById('txtEndTime'))"
                        readonly="readOnly" /><input id="Button1" type="button" value="查询" class="qr0" onclick="return CheckTime();" style ="margin-left :10px;" />
                </td>
            </tr>
        </table>
        <div style="width: 100%; margin-top: 3px;" class="table">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">
                <Columns>
                    <asp:TemplateField HeaderText="店铺编号">
                        <ItemTemplate>
                            <%#GetShopPosCodeWithShopID(Eval("ShopID").ToString ())%>
                        </ItemTemplate>
                        <HeaderStyle Width="25%" />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺名称">
                        <ItemTemplate>
                            <%#GetShopName(Eval("ShopID").ToString())%>
                        </ItemTemplate>
                        <HeaderStyle Width="25%" />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="数量">
                        <ItemTemplate>
                            <%#Eval("num")%>
                        </ItemTemplate>
                        <HeaderStyle Width="8%" />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="查看">
                        <ItemTemplate>
                            <a href="SupplierReportList.aspx?ShopID=<%#Eval("ShopID") %>">查看</a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                        <HeaderStyle Width="25%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
       <asp:HiddenField ID="hidSupplierID" runat="server" /> 
    </form>
</body>
</html>
