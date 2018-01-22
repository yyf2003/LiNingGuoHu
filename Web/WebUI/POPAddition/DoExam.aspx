<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoExam.aspx.cs" Inherits="WebUI_POPAddition_DoExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺增补POP结果信息</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js">
    </script>

    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>

    <script type="text/javascript" src="../../js/ShowDIV.js"></script>

    <script type="text/javascript">
      var UserID =<%=LoginUserID %>; 
        function doSet(key)
        {
            if(confirm('确定通过审核吗？'))
            {
                 $.get("CallBack/doSet.ashx?Date="+new Date(),{UserID:UserID,ExamState:1,AddID:key,Undes:""},function(data){
                 if(data.length>0)
                 {
                   $.prompt("操作成功",{callback:reloadpage});
                   //window.location .reload () ;
                 }
                 });
            }
        }
        
         function UndoSet(key)
         {
           var txt = '请填写未通过审核备注说明:<br /> <input type="text" id="alertName"  name="alertName" value="" style="width:260px;"  /><input type="text" id="key" name ="key" value='+key+' style="display:none;"/>'; 
             if(confirm('确定不通过审核吗？'))
             { 
                $.prompt(txt,{callback:mycallbackform,buttons:{确定: true, 取消: false }});
             }
         }
         
         function mycallbackform(v,m,f)
                 {  
                          if(v)
                          { 
                             var undes =f.alertName;
                             var key=f.key; 
                             if(undes!="")
                             {
                                $.get("CallBack/doSet.ashx?Date="+new Date(),{UserID:UserID,ExamState:2,AddID:key,Undes:undes},function(data){
                                     if(data.length>0)
                                     {
                                       $.prompt("操作成功",{callback:reloadpage});
                                       //window.location .reload () ;
                                     }
                                     });
                             }
                             else
                             {
                               alert("描述不能为空");
                             }
                          }
                 }
                 
                 function reloadpage()
                 {
                    window.location .reload () ;
                 }
         
    </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div>
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                <%=Shopname %>
                POP信息</div>
            <table class="table">
                <tr>
                    <td style="width: 15%">
                        店铺编号：</td>
                    <td style="width: 30%">
                        <asp:TextBox ID="PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        店铺零售属性：</td>
                    <td style="width: 30%">
                        <asp:TextBox ID="Txt_Saletype" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺名称：</td>
                    <td colspan="3">
                        <asp:TextBox ID="Txt_Shopname" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺简称：</td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_samplename" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        区域名称：</td>
                    <td>
                        <asp:TextBox ID="txt_areaname" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td>
                        客户身份：</td>
                    <td>
                        <asp:TextBox ID="txt_customerCard" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        店铺级别：</td>
                    <td>
                        <asp:TextBox ID="DDL_shopLevel" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="text-align: left">
                        店铺产权关系：</td>
                    <td>
                        <asp:TextBox ID="txt_shopownership" runat="server" CssClass="txtwith"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        店铺类型：</td>
                    <td>
                        <asp:TextBox ID="DDL_Shoptype" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="text-align: left">
                        店铺形象属性：</td>
                    <td>
                        <asp:TextBox ID="DDL_shopVI" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        省名称：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_Pro" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        地级城市名称：</td>
                    <td>
                        <asp:TextBox ID="Txt_City" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        区县级城市名称：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="txt_town" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        店铺状态：</td>
                    <td>
                        <asp:TextBox ID="Txt_ShopState" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        上级客户集团编号：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="txt_CustomerGroupID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        上级客户级别：</td>
                    <td>
                        <asp:TextBox ID="txt_CustomerGroupName" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店长：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_LineMan" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        店长移动电话：</td>
                    <td>
                        <asp:TextBox ID="Txt_LinkPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺零售负责人：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        零售负责人电话：</td>
                    <td>
                        <asp:TextBox ID="Txt_ShopMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        李宁省区VM负责人：</td>
                    <td>
                        <asp:TextBox ID="Txt_VMMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="text-align: left">
                        李宁省区VM负责人电话：</td>
                    <td>
                        <asp:TextBox ID="Txt_VMMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        李宁DSR负责人：</td>
                    <td>
                        <asp:TextBox ID="Txt_DSRMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="text-align: left">
                        李宁DSR负责人电话：</td>
                    <td>
                        <asp:TextBox ID="Txt_DSRMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺Email：</td>
                    <td>
                        <asp:TextBox ID="Txt_Email" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        店铺传真号码：</td>
                    <td>
                        <asp:TextBox ID="Txt_FixNumber" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        邮政编码：</td>
                    <td>
                        <asp:TextBox ID="Txt_PostCode" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        是否李宁公司统一支持安装：</td>
                    <td>
                        <asp:TextBox ID="Txt_install" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        POP配送地址：</td>
                    <td colspan="3">
                        <asp:TextBox ID="Txt_PostAddress" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        一级客户：</td>
                    <td>
                        <asp:TextBox ID="Txt_Dealer" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="text-align: left">
                        直属客户：</td>
                    <td>
                        <asp:TextBox ID="txt_fx" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        店铺营业面积：</td>
                    <td>
                        <asp:TextBox ID="Txt_Shoparea" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox>㎡</td>
                    <td>
                        店铺固定电话：</td>
                    <td>
                        <asp:TextBox ID="txt_shopphone" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        关店时间：</td>
                    <td>
                        <asp:TextBox ID="Txt_CloseTime" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        关店人：</td>
                    <td>
                        <asp:TextBox ID="Txt_CloseUser" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                    </td>
                    <td>
                    </td>
                    <td style="width: 15%">
                    </td>
                    <td>
                        <a href="#" onclick="history.back(-1)">返回上一页</a>
                    </td>
                </tr>
            </table>
            <br />
            <table class="table">
                <caption style="font-weight: bold">
                    POP信息列表：</caption>
                <tr><th>
                        POP编号</th>
                    <th>
                        POP位置</th>
                    <th>
                        材料</th>
                    <th>
                        POP实际制作高</th>
                    <th>
                        POP实际制作宽</th>
 
                    <th>
                        POP可视画面高</th>
                    <th>
                        POP可视画面宽</th>
                    <th>
                        POP面积</th>
                        <th>
                        POP可视画面位置</th>
                    <th>
                        POP可视画面偏离角度</th><th>备注</th><th>审核</th><th>状态</th><th>审核结果</th></tr>
                <asp:Repeater runat="server" ID="RepPOPList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("POPseat")%>
                            </td>
                            <td>
                                <%# Eval("POPMaterial") %>
                            </td>
                            <td align="center">
                                <%# Eval("realHeight")%>
                            </td>
                            <td align="center">
                                <%# Eval("realWith")%>
                            </td> <td align="center">
                                <%# Eval("POPHeight")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPWith")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPArea")%>
                            </td>
                             <td align="center">
                                <%# Eval("POPplwz")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPpljd")%>
                            </td>
                            <td align="center">
                                <img src='../../<%# Eval("PhotoUrl")%>' height="28px" width="45px" style="cursor: pointer;"
                                    alt='<%#Eval("Des") %>' onclick="javascript:ShowDIV('30%','30%','700px','50px','500px',this.alt,this.src)" />
                            </td>
                            <td align="center">
                                <%# Eval("Des")%>
                            </td>
                            <td align="center">
                                <a href='#' onclick="doSet(<%#Eval("AddID") %>);">通过</a>&nbsp;&nbsp; <a href='#'
                                    onclick="UndoSet(<%#Eval("AddID") %>);">不通过</a>
                            </td>
                            <td align="center">
                                <%#Eval("ExamState").ToString() == "0" ? "未审核" :Eval ("ExamState").ToString ()=="1"? "<font color=red>已审核</font>":"<font color=red>未通过审核</font>"%>
                            </td>
                            <td align="center">
                                <%#Eval("UnDes").ToString() == "" ? "无" : Eval("UnDes").ToString ()%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table class="table" style="margin-top: 3px; font-weight: bold;">
                <tr>
                    <td align="center">
                        本次增补数量<%=POPAddtionCount %>个，增补面积<%=POPAddtitionArea %>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
