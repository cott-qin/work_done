<%@ Register TagPrefix="uc1" TagName="UserFoot" Src="../common/UserFoot.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="examplePage.aspx.vb" Inherits="agreenet.examplePage" %>
<%@ Register TagPrefix="uc1" TagName="UserTitle" Src="../common/UserTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserMessage" Src="../common/UserMessage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserBase" Src="../common/UserBase.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserMenu" Src="../common/UserMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>A Gree'Net System</title>
		<meta content="True" name="vs_snapToGrid">
		<META http-equiv="Content-Type" content="text/html; charset=UTF-8" Pragma="no-cache" Cache-Control="no-cache">
		<script language="javascript" src="../script/common.js" type="text/javascript"></script>
		<LINK href="../css/styles.css" type="text/css" rel="StyleSheet">
			<SCRIPT language="JavaScript"> <!--
			    /**
    　　　　　　 * 親画面に値をセット
    　　　　　　 */
			    function setValue(cdChemicalGrp,naChemicalGrp){
			
			        if(opener == null) {
			            window.close();
			            return false;
			        }
	
			        if(opener.setChemicalGroup == null) {
			            window.close();
			            return false;
			        }
			        opener.setChemicalGroup(cdChemicalGrp,naChemicalGrp);
	 
			        window.close();
	
			    }

			    function openSubWin(){
	
			        var para = "";
			        var url = event.srcElement.getAttribute('src')
	
			        if(url == null){
			            return false;
			        }
	
			        //MR0240へ
			        if (url.indexOf("MR0240") != -1){

			            para = addCommonPara(document.forms[0], para);
			            open_subwindow(url + para, MODEL_SMALL,"MR0240");
			        }
	
			        return false;
			    }

			    /**
                 * 調査物質群検索
                 */
			    function setChemicalInvGroup(code, name)
			    {	
			        //調査物質群コード
			        document.forms[0].d_hd_id_surveyeproductgrp.value = code;
			        //調査物質群名称
			        //document.forms[0].d_txt_na_surveyeproductgrp.value = name;
			        if (name != "&nbsp;"){
			            document.getElementById("d_lbl_na_surveyeproductgrp").innerText = name;
			        }else{
			            document.getElementById("d_lbl_na_surveyeproductgrp").innerText = "";
			        }

			        //調査物質群コードが1-20の場合はver.6
			        if (code>0 & code<=20)
			        {
			            document.getElementById("d_lbl_green_version").innerText= "6";
			        }
			            //調査物質群コードが21-29の場合はver.7
			        else if(code>20 & code<=29)
			        {
			            document.getElementById("d_lbl_green_version").innerText= "7";
			        }
			            //調査物質群コードが30-39の場合はver.8
			        else if(code>29 & code<=39)
			        {
			            document.getElementById("d_lbl_green_version").innerText= "8";
			        }
			            //調査物質群コードが40-49の場合はver.9
			        else if(code>39 & code<=49)
			        {
			            document.getElementById("d_lbl_green_version").innerText= "9";
			        }
			            //調査物質群コードが50-59の場合はver.10
			        else if(code>49 & code<=59)
			        {
			            document.getElementById("d_lbl_green_version").innerText= "10";
			        }
			            //調査物質群(予備)
			        else
			        {
			            document.getElementById("d_lbl_green_version").innerText= "";
			        }

			    }

			    /**
                 * 登録処理ユーザー側チェック
                 */
			    function uploadCheck() {
	
			        var msg = "";
			        msg = document.forms[0].d_hd_login_msg.value;
			        if (!showMsg(msg, MBTN_OKCANCEL,MTYPE_QUESTION, MDBTN_DEFAULT2)) {
			            return false;
			        }
			        document.getElementById('<%=d_btn_product_login_hd.ClientId%>').click();
			    }

			    /**
                 * 削除処理ユーザー側チェック
                 */
			    function deleteCheck() {
	
			        var msg = "";
			        msg = document.forms[0].d_hd_delete_msg.value;
			        if (!showMsg(msg, MBTN_OKCANCEL,MTYPE_QUESTION, MDBTN_DEFAULT2)) {
			            return false;
			        }
			        document.getElementById('<%=d_btn_product_delete_hd.ClientID%>').click();
			    }

			    /**
                * Edgeに対して、ボタンの非活性化
                */
			    function setButtonDisabled(){
			        if(typeof(document.forms[0].d_btn_product_login) != "undefined"){
			            document.forms[0].d_btn_product_login.disabled= true;
			        }
			        if(typeof(document.forms[0].d_btn_product_delete) != "undefined"){
			            document.forms[0].d_btn_product_delete.disabled="disabled";
			        }
			    }


	--></SCRIPT>
	</HEAD>
	<body  bgColor="#ffffff" onload="page_load('example');"
		onunload="page_unload('example');">
		<FORM id="Form1" name="Form1" method="post" runat="server">
			<div id="s_div_left_menu" class="left_menu"><uc1:usermenu id="UserMenu1" runat="server"></uc1:usermenu></div>
			<div id="s_div_right_menu" class="right_menu">
				<asp:panel id="s_pal_back" runat="server">
				<uc1:usertitle id="UserTitle1" runat="server"></uc1:usertitle>
				<uc1:usermessage id="UserMessage1" runat="server"></uc1:usermessage>
				<uc1:userbase id="UserBase1" runat="server"></uc1:userbase>
				</asp:Button><INPUT id="d_hd_msg_jump_flag" type="hidden" value="0" name="d_hd_msg_jump_flag" runat="server">
				<asp:label id="s_lbl_file_info" Runat="server" Font-Bold =True ></asp:label>
　　　　　　　　<TABLE class="Line" cellSpacing="0" cellPadding="1" width="100%" border="0">
						<TR>
							<TD align="right">
								<TABLE cellSpacing="0" cellPadding="2" width="100%" border="1">
									        <TR>
											  <TD class="lefthead" width="30%">
												<asp:Label id="s_lbl_select" runat="server"></asp:Label></TD>
											  <TD>
												<asp:DropDownList id="d_ddl_select" runat="server"></asp:DropDownList></TD>
										   </TR>
                                           <TR>
                                             <TD class="lefthead" width="30%">
                                              <asp:label id="s_lbl_enviroment_approval_comment" Runat="server"></asp:label></TD>
										     <TD>
											  <asp:TextBox id="d_txt_enviroment_approval_comment" runat="server" MaxLength="250" style="width: 300px"></asp:TextBox>
                                              <asp:label id="s_lbl_err_enviroment_approval_comment" runat="server" CssClass="error"></asp:label>
										     </TD>
                                          </TR>
                                         
                                     <TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_agn_version" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_agn_version" Runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_no_content_certificate" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_no_content_certificate" Runat="server"></asp:label></TD>
									</TR>
                                    <TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_green_version" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_green_version" Runat="server"></asp:label></TD>
									</TR>
                                         <TR>
                                             <TD class="lefthead" width="30%">
                                             <asp:label id="s_lbl_na_surveyeproductgrp" Runat="server"></asp:label></TD>
										 <TD>
                                             <asp:label id="d_lbl_na_surveyeproductgrp" Runat="server"></asp:label>
                                             <INPUT id="d_hd_id_surveyeproductgrp" type="hidden" name="d_hd_id_surveyeproductgrp" runat="server">
                                             
                                        </TD>
									</TR>
                                          <TR>
                                             <TD class="lefthead" width="30%">
                                              <asp:label id="s_lbl_no_content_certificate_escape_code_r" Runat="server"></asp:label></TD>
										     <TD>
											  <asp:TextBox id="d_txt_no_content_certificate_escape_code_r" runat="server" MaxLength="128" style="width: 200px"></asp:TextBox>
                                              <asp:label id="s_lbl_err_no_content_certificate_escape_code_r" runat="server" CssClass="error"></asp:label>
										     </TD>
                                          </TR>
                                    <TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_agn_escape_code_r" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_agn_escape_code_r" Runat="server"></asp:label></TD>
									</TR>
                                          <TR>
                                             <TD class="lefthead" width="30%">
                                              <asp:label id="s_lbl_no_content_certificate_escape_code_e" Runat="server"></asp:label></TD>
										     <TD>
											  <asp:TextBox id="d_txt_no_content_certificate_escape_code_e" runat="server" MaxLength="128" style="width: 200px"></asp:TextBox>
                                              <asp:label id="s_lbl_err_no_content_certificate_escape_code_e" runat="server" CssClass="error"></asp:label>
										     </TD>
                                          </TR>
                                          
                                    <TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_agn_escape_code_e" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_agn_escape_code_e" Runat="server"></asp:label></TD>
									</TR>
                                    <TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_na_purchase_company" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_na_purchase_company" Runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_na_purchase_office" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_na_purchase_office" Runat="server"></asp:label></TD>
									</TR>
                                    <TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_na_purchase_product" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_na_purchase_product" Runat="server"></asp:label></TD>
									</TR>
                                           <TR>
											  <TD class="lefthead" width="30%">
												<asp:Label id="s_lbl_my_analysis_result" runat="server"></asp:Label></TD>
											  <TD>
												<asp:DropDownList id="d_ddl_my_analysis_result" runat="server"></asp:DropDownList></TD>
										   </TR>
                                          <TR>
                                             <TD class="lefthead" width="30%">
                                              <asp:label id="s_lbl_cetified_person" Runat="server"></asp:label></TD>
										     <TD>
											  <asp:TextBox id="d_txt_cetified_person" runat="server" MaxLength="128" style="width: 200px"></asp:TextBox>
                                              <asp:label id="s_lbl_err_cetified_person" runat="server" CssClass="error"></asp:label>
										     </TD>
                                          </TR>
									<TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_input_division" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_input_division" Runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_input_file" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_input_file" Runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_na_label_company" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_na_company" Runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD class="lefthead" width="30%">
											<asp:label id="s_lbl_na_label_office" Runat="server"></asp:label></TD>
										<TD>
											<asp:label id="d_lbl_na_office" Runat="server"></asp:label></TD>
									</TR>
                                           <TR>
                                             <TD class="lefthead" width="30%">
                                              <asp:label id="s_lbl_bikou1" Runat="server"></asp:label></TD>
										     <TD>
											  <asp:TextBox id="d_txt_bikou1" runat="server" MaxLength="250" style="width: 300px"></asp:TextBox>
                                              <asp:Label id="s_lbl_err_bikou1" runat="server" CssClass="error"></asp:Label>
										     </TD>
                                          </TR>
                                          <TR>
                                             <TD class="lefthead" width="30%">
                                              <asp:label id="s_lbl_bikou2" Runat="server"></asp:label></TD>
										     <TD>
											  <asp:TextBox id="d_txt_bikou2" runat="server" MaxLength="250" style="width: 300px"></asp:TextBox>
                                              <asp:Label id="s_lbl_err_bikou2" runat="server" CssClass="error"></asp:Label>
										     </TD>
                                          </TR>
                                          <TR>
                                             <TD class="lefthead" width="30%">
                                              <asp:label id="s_lbl_bikou3" Runat="server"></asp:label></TD>
										     <TD>
											  <asp:TextBox id="d_txt_bikou3" runat="server" MaxLength="250" style="width: 300px"></asp:TextBox>
                                              <asp:Label id="s_lbl_err_bikou3" runat="server" CssClass="error"></asp:Label>
										     </TD>
                                          </TR>
									
								</TABLE>
							</TD>
						</TR>
                                     <TR>
										<TD>
											
											<asp:button id="d_btn_product_login" Runat="server"></asp:button>
                                            <asp:button id="d_btn_product_delete" Runat="server"></asp:button>
                                            <asp:Button id="d_btn_product_login_hd" runat="server" Text="d_btn_product_login_hd" Style="visibility:hidden;" />
                                            <asp:Button id="d_btn_product_delete_hd" runat="server" Text="d_btn_product_delete_hd" Style="visibility:hidden;" />
                                            <INPUT id="d_hd_login_msg" type=hidden name=d_hd_login_msg runat="server"> 
                                            <INPUT id="d_hd_delete_msg" type=hidden name=d_hd_delete_msg runat="server"> 
										</TD>
									</TR>
					</TABLE><BR>

					<asp:button id="s_btn_back2" Runat="server"></asp:button>
					</asp:panel>
			</div>
		</FORM>
		<uc1:userfoot id="UserFoot1" runat="server"></uc1:userfoot>
		<FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT>
	</body>
</HTML>

