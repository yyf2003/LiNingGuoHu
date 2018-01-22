<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>出错了！！</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
    body{
	    font-size:9pt; color: #000000; font-family: Verdana, Arial, Helvetica, sans-serif, 宋体; text-align:center}
	.bg {
		background-color:#fff;}
	.bg_td {
		background-color: #f7f7f7}
	.bg_tds {
		background-color: #eee}
	.bg_table {
		background-color: #fff}
	.bg_frame {
		background-color: #00659c}
	.tablew {
		width: 98%}
	.table {
		border-right:1px; border-top:1px; border-left:1px;width:98%; border-bottom:1px; background-color:#fff}
	.tims {
		font-size: 7pt; color: #808080; font-family: Verdana, Arial, Helvetica, sans-serif}
	.htd {
		line-height:150%;}
	.btd {
		font-weight:bold;}
	.bw {
		word-wrap:break-word}
	.tf {
		table-layout:fixed;}
	.gray {
		color: #808080}
	.red {
		color: #ff0000}
	.red2 {
		color: #cc3300}
	.blue {
		color: #0066cc}
	.ftd {
		color: #ffffff}
	.fbg {
		color: #ffffff}
	.div_alt {
		border-right: black 1px solid; padding-right: 2px; border-top: black 1px solid; padding-left:2px; padding-bottom: 2px; margin-left:18px; border-left:black 1px solid; width:240px; color: #000000; padding-top:2px; border-bottom: black 1px solid; background-color: #ffffe1}
	a {
		color: #000000; text-decoration: none
	}
	a:hover {
		color: #ff0000; text-decoration: underline
	}
	a.h_menu {
		color: #333333; text-decoration: none
	}
	a.h_menu:hover {
		color: #ff0000; text-decoration: underline
	}
	</style>

</head>
<body>
    <form id="form1" runat="server">
    <CENTER>
<DIV id=page>
<TABLE cellSpacing=0 cellPadding=0 width=980 align=center border=0>
  <TBODY>
  <TR>
    <TD align=middle>&nbsp;</TD></TR></TBODY></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="80%" border=0>
  <TBODY>
  <TR>
    <TD><IMG src="./images/error/1.gif" width="17" height="18"></TD>
    <TD width="100%" 
    background="./images/error/3.gif"></TD>
    <TD><IMG src="./images/error/2.gif" width="17" height="18"></TD>
  </TR></TBODY></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="80%" border=0>
  <TBODY>
  <TR>
    <TD width=7 
background="./images/error/left.gif"></TD>
    <TD class=bg align=middle width=*>
      <TABLE cellSpacing=0 cellPadding=0 width="98%" align=center border=0>
        <TBODY>
        <TR>
          <TD align=left width="80%" 
            height=30>&nbsp; </TD>
          <TD align=right width="20%">
            <DIV id=div_msg>
            <MARQUEE onMouseOver="if (document.all!=null){this.stop()}" 
            onmouseout="if (document.all!=null){this.start()}" scrollAmount=3 
            scrollDelay=100><IMG src="./images/error/gao.gif" width="19" height="17"> <FONT 
            class=red>欢迎使用李宁pop管理系统</FONT>
            </MARQUEE></DIV></TD></TR></TBODY></TABLE></TD>
    <TD width=7 
    background="./images/error/right.gif"></TD></TR></TBODY></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="80%" border=0>
  <TBODY>
  <TR>
    <TD width=7 
background="./images/error/left.gif"></TD>
    <TD class=bg align=middle width=*>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TBODY>
        <TR>
          <TD class=bg_1 align=middle height=300>
            <TABLE cellSpacing=0 cellPadding=0 width=590 border=0>
              <TBODY>
              <TR>
                <TD align=right><IMG 
                  src="./images/error/center_error.gif" width="450" height="32" 
                  border=0></TD>
              </TR>
              <TR>
                <TD align=middle height=380>
                  <TABLE cellSpacing=0 cellPadding=0 width=534 border=0>
                    <TBODY>
                    <TR>
                      <TD colSpan=3><IMG height=42 src="./images/error/error_r1_c1.gif" 
                        width=534 border=0></TD>
                      <TD><IMG height=42 src="./images/error/60du.htm" 
                        width=1 border=0></TD></TR>
                    <TR>
                      <TD rowSpan=2><IMG height=239 src="./images/error/error_r2_c1.gif" 
                        width=43 border=0></TD>
                      <TD class=htd align=middle width=479 bgColor=#f7f7f7 
                      height=228>
                        <P><%= errorInfo%></P>
                        </TD>
                      <TD rowSpan=2><IMG height=239 src="./images/error/error_r2_c3.gif" 
                        width=12 border=0></TD>
                      <TD><IMG height=228 src="./images/error/60du.htm" 
                        width=1 border=0></TD></TR>
                    <TR>
                      <TD><IMG height=11 src="./images/error/error_r3_c2.gif" 
                        width=479 border=0></TD>
                      <TD><IMG height=11 src="./images/error/60du.htm" 
                        width=1 
            border=0></TD></TR></TBODY></TABLE><BR></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD>
    <TD width=7 
    background="./images/error/right.gif"></TD></TR></TBODY></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="80%" border=0>
  <TBODY>
  <TR>
    <TD class=bg align=middle width=*>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TBODY>
        <TR>
          <TD><IMG src="./images/error/4.gif" width="17" height="18"></TD>
          <TD width="100%" 
          background="./images/error/6.gif"></TD>
          <TD><IMG src="./images/error/5.gif" width="17" height="18"></TD>
        </TR></TBODY></TABLE><BR>
      <DIV></DIV></TD></TR></TBODY></TABLE>
<CENTER></CENTER></DIV></CENTER>    </form>
</body>
</html>
