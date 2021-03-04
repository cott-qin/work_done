'---------------------------------------------------------------
' 　examplePage - 納入情報環境認定
' 　画面処理
'---------------------------------------------------------------
Imports System.IO
Imports System.Data
Partial Class examplePage
    Inherits PageBase

#Region " Web フォーム デザイナで生成されたコード "

    'この呼び出しは Web フォーム デザイナで必要です。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents s_lbl_na_registered As System.Web.UI.WebControls.Label
    Protected WithEvents s_lbl_c_date As System.Web.UI.WebControls.Label
    Protected WithEvents d_lbl_c_date As System.Web.UI.WebControls.Label
    Protected WithEvents s_lbl_c_uid As System.Web.UI.WebControls.Label
    Protected WithEvents d_lbl_c_uid As System.Web.UI.WebControls.Label
    Protected WithEvents s_lbl_ud_date As System.Web.UI.WebControls.Label
    Protected WithEvents d_lbl_ud_date As System.Web.UI.WebControls.Label
    Protected WithEvents s_lbl_ud_uid As System.Web.UI.WebControls.Label
    Protected WithEvents d_lbl_ud_uid As System.Web.UI.WebControls.Label
    Protected WithEvents s_btn_product_examine2 As System.Web.UI.WebControls.Button
    Protected WithEvents s_btn_common As System.Web.UI.WebControls.Button
    Protected WithEvents h_hd_id_file As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents h_hd_kubun As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents h_hd_file_size As System.Web.UI.HtmlControls.HtmlInputHidden

    'メモ : 次のプレースホルダ宣言は Web フォーム デザイナで必要です。
    '削除および移動しないでください。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: このメソッド呼び出しは Web フォーム デザイナで必要です。
        ' コード エディタを使って変更しないでください。
        InitializeComponent()
    End Sub

#End Region

#Region "画面変数宣言"

    Private myPageFlg As Integer                                            '画面表示フラグ
    Private myLogic As exampleLogic                                          'Logicの宣言
    Private mySearchInData As New exampleSearchRequest                       '画面検索入力データ
    Private mySearchOutData As New exampleSearchResponse                     '画面検索結果を戻る
    Private myRegisterInData As New exampleRegisterRequest                   '画面データ登録入力
    Private myRegisterOutData As New exampleRegisterResponse                 '画面データ登録結果出力
    Private vsProductDS As New ProductDS
    Private vsPurchaseDS As New PurchaseDS
    Private vsBuyerProductDS As New BuyerRequestProductDS
    Private mySelectData As Byte()
    Private myDataList As ArrayList

    '遷移先画面フラグ
    Private PAGE_TYPE As GR0150Logic.PAGE_TYPE

    '退避用パラメータ
    Private exEnvironmentApprovalFlag As Integer                           '環境認定フラグ
    Private exEnvironmentAprrovalComment As String                         '環境認定コメント
    Private exNoContentCertificateEscapeCode_R As String                   '不含有保証書適用除外コード(RoHS)
    Private exNoContentCertificateEscapeCode_E As String                   '不含有保証書適用除外コード(ELV)
    Private exMyAnalysisResult As Integer                                  '自己分析結果
    Private exCertifiedPerson As String                                    '認定担当者
    Private exBikou1 As String                                             '特記事項1
    Private exBikou2 As String                                             '特記事項2
    Private exBikou3 As String                                             '特記事項3

#End Region

#Region "画面定数宣言"
    Private Const MY_NA_COMPANY As String = "s_lbl_na_label_company1"      '会社名
    Private Const MY_NA_OFFICE As String = "s_lbl_na_label_office1"        '事務所名
    Private Const MY_GANNYUU_ARU As String = "s_slct_have"                '不含有保証書="有"
    Private Const MY_GANNYUU_NAI As String = "s_slct_dont_have"                  '不含有保証書="無"
    Private Const MY_SELECT_NO As String = "s_slct_no_select"                '不含有="-"
    Private Const MY_TORIHIKI As String = "s_lbl_torihiki"
    Private Const MY_PURCHASE As String = "s_lbl_purchase"
    Private Const MY_SLCT_NO_CERTIFY As String = "s_slct_no_certify"       '認定フラグ="未認定"
    Private Const MY_SLCT_PASS As String = "s_slct_pass"                '認定フラグ="合格"
    Private Const MY_SLCT_PASS_UNDER_SITUATION As String = "s_slct_pass_under_situation"     '認定フラグ="条件付き合格"
    Private Const MY_SLCT_FAIL As String = "s_slct_fail"                '認定フラグ="不合格"
    Private Const MY_SLCT_RESERVE As String = "s_slct_reserve"                '認定フラグ="保留"
    Private Const MY_FILE_HAVE As String = "s_file_have"                '添付資料="有"
    Private Const MY_FILE_NO As String = "s_file_no"                    '添付資料="無"
    Private Const MY_ANALYSIS_HAVE As String = "s_analysis_have"                '自己分析結果="有"
    Private Const MY_ANALYSIS_NO As String = "s_analysis_dont_have"             '自己分析結果="無"
    Private Const MY_LOGIN_MESSAGE As String = "d_hd_login_msg"                '登録処理メッセージ
    Private Const MY_DELETE_MESSAGE As String = "d_hd_delete_msg"                '削除処理メッセージ

    '画面間インタフェース
    Private Const IF_ID_PRODUCT As String = "d_hd_id_product"               '製品ID
    Private Const IF_ID_PURCHASE As String = "idPurchase"
    Private Const IF_PAGE_FLG As String = "flgPage"                         '遷移先画面フラグ
    Private Const IF_FLAG_ENTERING As String = "flgEntering"                '入力完了フラグIF
    Private Const IF_PARA_TRAN As String = "interface_para"                  'GR0150に遷移用
    'ViewState用定数
    Private Const VS_ID_PRODUCT As String = "ID_PRODUCT"                        '製品ID
    Protected WithEvents d_hd_delete_msg As System.Web.UI.HtmlControls.HtmlInputHidden
    Private Const VS_CD_PRODUCT As String = "CD_PRODUCT"                        '製品CD
    Private Const VS_CD_COMPANY As String = "ID_COMPANY"                        '会社CD
    Private Const VS_VRT As String = "AGN_VER"
    Private Const VS_DS_PRODT As String = "FrmProductDS"                        '製品情報
    Private Const VS_DS_PURCH As String = "FrmPurchaseDS"                       '納入情報
    Private Const VS_DS_example As String = "FrmexampleDS"
    Private Const VS_UD_DATE As String = "VS_UD_DATE"                           '納入情報排他判定
    Private Const VS_UD_DATE_PRODUCT As String = "VS_UD_DATE_PRODUCT"           '製品情報排他判定

    Private Enum BTN_TYPE
        BTN_DOWNLOAD = 0    'リンクボタン用
        BTN_DELETE = 1      '削除ボタン使用
        BTN_SELECT = 2      '選択ボタン使用
    End Enum
#End Region

#Region "初期処理関連"
    '-----------------------------------------------------------
    ' 機能　　　: 初期化の処理
    '
    ' 返り値　　: True:正常; False:エラーが発生
    '
    ' 引き数　　: sender - システムオブジェクト
    '            e - システムイベント
    '
    ' 機能説明　: ページをLoad時、初期処理
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Protected Overrides Function PageLoadEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean
        '初期ロードの時
        If Not IsPostBack Then
            'メニュー内容をセット
            MyBase.SetMenuBySession()

            'インタフェースチェック
            Me.CheckIFPara()

            '画面項目の初期化
            Me.InitGamenData()

            'DropDownListの初期化
            Me.InitDropDownList()

            'ボタンの初期化
            Me.InitButton()

            'データを取得する
            Me.GetInitData()

        End If

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: インタフェースチェック処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: インタフェースチェック
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub CheckIFPara()
        Dim strTemp As String
        Dim para As String

        '製品ID
        strTemp = MyBase.GetParameter(examplePage.IF_ID_PRODUCT)
        If Not AgnUtil.CheckDataValue(strTemp, AgnConst.NUM_WORD, AgnConst.PRODUCT_MAXLENGTH, True) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        '納入情報ID
        Me.ViewState(examplePage.IF_ID_PURCHASE) = CType(MyBase.GetParameter(examplePage.IF_ID_PURCHASE), Decimal)
        '画面フラグ
        Me.ViewState(examplePage.IF_PAGE_FLG) = CType(MyBase.GetParameter(examplePage.IF_PAGE_FLG), Decimal)
        '製品ID
        Me.ViewState(examplePage.IF_ID_PRODUCT) = strTemp

        '入力完了フラグ
        Me.ViewState(examplePage.IF_FLAG_ENTERING) = CType(MyBase.GetParameter(examplePage.IF_FLAG_ENTERING), Decimal)

        para = "?" & examplePage.IF_ID_PRODUCT & "=" & strTemp & "&" & examplePage.IF_ID_PURCHASE & "=" &
                MyBase.GetParameter(examplePage.IF_ID_PURCHASE) & "&" & examplePage.IF_PAGE_FLG & "=" &
                MyBase.GetParameter(examplePage.IF_PAGE_FLG) & "&" & examplePage.IF_FLAG_ENTERING & "=" &
                MyBase.GetParameter(examplePage.IF_FLAG_ENTERING)

        Me.ViewState(examplePage.IF_PARA_TRAN) = para
    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 画面項目の初期化、画面項目を表示でしょうか
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: ページをLoad時、画面項目を初期化します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub InitGamenData()
        '*** 製品部分の表示

        '自社名/取引先会社名
        Me.d_lbl_na_company.Text = AgnConst.HTML_SPACE
        '自事業所名/取引先事業所名
        Me.d_lbl_na_office.Text = AgnConst.HTML_SPACE


        If CInt(Me.ViewState(examplePage.IF_PAGE_FLG)) = GR0150Logic.PAGE_TYPE.PURCH_PROD Then
            '会社名
            Me.s_lbl_na_label_company.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_NA_COMPANY, MyBase.userSession.LanguageId)
            '事務所名
            Me.s_lbl_na_label_office.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_NA_OFFICE, MyBase.userSession.LanguageId)

        End If
        'A Gree'Net Data Ver.
        Me.d_lbl_agn_version.Text = AgnConst.HTML_SPACE
        '不含有保証書
        Me.d_lbl_no_content_certificate.Text = AgnConst.HTML_SPACE

        '納入先会社名
        Me.d_lbl_na_purchase_company.Text = AgnConst.HTML_SPACE
        '納入先事業所名
        Me.d_lbl_na_purchase_office.Text = AgnConst.HTML_SPACE

        '納入先品名
        Me.d_lbl_na_purchase_product.Text = AgnConst.HTML_SPACE
        '納入先コメント
        Me.d_lbl_input_division.Text = AgnConst.HTML_SPACE
        '添付資料
        Me.d_lbl_input_file.Text = AgnConst.HTML_SPACE
        'グリーン調達ガイドラインVer.
        Me.d_lbl_green_version.Text = AgnConst.HTML_SPACE
        '登録処理メッセージ
        Me.d_hd_login_msg.Value = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_LOGIN_MESSAGE, MyBase.userSession.LanguageId)
        '削除処理メッセージ
        Me.d_hd_delete_msg.Value = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_DELETE_MESSAGE, MyBase.userSession.LanguageId)


        '初期化の時、NG全部非表示
        '環境認定コメント
        Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:none")
        '不含有保証書適用除外コード(ELV)
        Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:none")
        '不含有保証書適用除外コード(ROHS)
        Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:none")
        '認定担当者
        Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:none")
        '特記事項1
        Me.s_lbl_err_bikou1.Attributes.Add("style", "display:none")
        '特記事項2
        Me.s_lbl_err_bikou2.Attributes.Add("style", "display:none")
        '特記事項3
        Me.s_lbl_err_bikou3.Attributes.Add("style", "display:none")

    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: ボタンの初期化処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: ページをLoad時、ボタンを初期化
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub InitButton()

        ''「選択」と「削除」ボタンの活性化（該当納入先所属判定）
        'Dim cdPurchaseCompany As String = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "cdPurchaseCompany")
        'Dim cdPurchaseOffice As String = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "cdPurchaseOffice")

        'If Not cdPurchaseOffice = MyBase.userSession.GOfficeCd Or Not cdPurchaseCompany = MyBase.userSession.GCompanyCd Then
        '    Me.d_btn_product_login.Enabled = False
        '    Me.d_btn_product_delete.Enabled = False
        '    Me.ClientScript.RegisterStartupScript(Me.GetType(), "setButtonDisabled", _
        '                    "<script type=""text/javascript"">setButtonDisabled();</script>")
        '    Me.d_btn_product_delete.Attributes.Remove("disabled")
        '    Me.d_btn_product_login.Attributes.Add("disabled", True)
        '    Me.d_btn_product_delete.Attributes.Add("disabled", "disabled")
        'Else
        '    'do nothing
        'End If

        '「共通」ボタン
        Me.d_btn_product_login.Attributes.Item("onclick") += "registFlag=false;"
        Me.d_btn_product_login.Attributes.Add("control", "self")

        Me.d_btn_product_delete.Attributes.Item("onclick") += "registFlag=false;"
        Me.d_btn_product_delete.Attributes.Add("control", "self")

        Me.s_btn_back2.Enabled = True

    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: データの検索処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 初期表示データを取得します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub GetInitData()
        Dim ret As Integer

        '「検索処理」の出力
        AgnLog.Operation(MyBase.userSession, "初期処理")

        Me.GetSearchPara()
        Me.myLogic = New exampleLogic(MyBase.userSession)
        '画面ロジック共通を実行します
        ret = Me.myLogic.Execute(exampleLogic.FUNC_READ, CType(Me.mySearchInData, DTOBase), CType(Me.mySearchOutData, DTOBase))
        If ret = 0 Then
            If Me.mySearchOutData.ErrFlag >= 0 Then

                Me.ShowInitData(True)

            ElseIf Me.mySearchOutData.ErrFlag = -22 Then
                '製品DAにデータがなければ、エラー頁へ
                MyBase.SetException(Me.mySearchOutData)
            Else
                'エラーメセージ表示
                AgnMsg.ShowErrMessage(Me, Me.mySearchOutData.ErrorList)
            End If
        Else
            '異常処理を設定
            MyBase.SetException(Me.mySearchOutData)
        End If
    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: データを表示
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: convsFlg=true - 変換
    '            convsFlg=false - 変換しない
    '
    ' 機能説明　: データを表示します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub ShowInitData(ByVal convsFlg As Boolean)
        '製品情報を表示
        Me.SetInitData(convsFlg)

    End Sub
    '-----------------------------------------------------------
    ' 機能　　　: DropDownListの初期化
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: ページをLoad時、DropDownListの初期化
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub InitDropDownList()
        '環境認定選択項目
        Dim lstListItem As New ListItem

        '環境認定選択項目初期化
        Me.d_ddl_select.Items.Clear()

        '環境認定選択項目：0.未認定
        lstListItem.Value = "0"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_NO_CERTIFY, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '環境認定選択項目新規追加
        lstListItem = New ListItem

        '環境認定選択項目：1.合格
        lstListItem.Value = "1"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_PASS, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '環境認定選択項目新規追加
        lstListItem = New ListItem

        '環境認定選択項目：2.条件付き合格
        lstListItem.Value = "2"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_PASS_UNDER_SITUATION, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '環境認定選択項目新規追加
        lstListItem = New ListItem

        '環境認定選択項目：3.不合格
        lstListItem.Value = "3"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_FAIL, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '環境認定選択項目新規追加
        lstListItem = New ListItem

        '環境認定選択項目：4.保留
        lstListItem.Value = "4"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_RESERVE, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '環境認定フラグ取得
        Dim environmentalApprovalFlg As Integer = CInt(MyBase.GetParameter("EnvironmentalApproval"))

        '環境認定フラグ判定
        If environmentalApprovalFlg = AgnConst.DEFAULT_VALUE_INTEGER_ONE Then
            Me.d_ddl_select.SelectedIndex = 1
        ElseIf environmentalApprovalFlg = AgnConst.DEFAULT_VALUE_INTEGER_TWO Then
            Me.d_ddl_select.SelectedIndex = 2
        ElseIf environmentalApprovalFlg = AgnConst.DEFAULT_VALUE_INTEGER_THREE Then
            Me.d_ddl_select.SelectedIndex = 3
        ElseIf environmentalApprovalFlg = AgnConst.DEFAULT_VALUE_INTEGER_FOUR Then
            Me.d_ddl_select.SelectedIndex = 4
        Else
            Me.d_ddl_select.SelectedIndex = 0
        End If

        '自己分析結果選択項目新規追加
        lstListItem = New ListItem

        '自己分析結果選択項目：0.空欄
        lstListItem.Value = "0"
        lstListItem.Text = ""
        Me.d_ddl_my_analysis_result.Items.Add(lstListItem)

        '自己分析結果選択項目新規追加
        lstListItem = New ListItem

        '自己分析結果選択項目：1.有
        lstListItem.Value = "1"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_ANALYSIS_HAVE, MyBase.userSession.LanguageId)
        Me.d_ddl_my_analysis_result.Items.Add(lstListItem)

        '自己分析結果選択項目新規追加
        lstListItem = New ListItem

        '自己分析結果選択項目：2.無
        lstListItem.Value = "2"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_ANALYSIS_NO, MyBase.userSession.LanguageId)
        Me.d_ddl_my_analysis_result.Items.Add(lstListItem)

        Me.d_ddl_my_analysis_result.SelectedIndex = 0

    End Sub
    '-----------------------------------------------------------
    ' 機能　　　: データを表示
    '
    ' 返り値　　: 0 正常  0以外 異常
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: データを表示します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Function SetInitData(ByVal convsFlg As Boolean) As Integer
        Dim productCompany As String = ""           '製造会社名
        Dim flgNOContent As String = ""

        If Me.mySearchOutData.FrmProductDS.Tables(0).Rows.Count = 0 Then
            'エラーメセージ表示
            AgnMsg.ShowErrMessage(Me, Me.mySearchOutData.ErrorList)
            Return -1
        Else

            '製造会社名
            productCompany = AgnUtil.GetCompanyName(Me.mySearchOutData.FrmProductDS)
            '製品番号
            If convsFlg = True Then
                Me.ViewState(examplePage.VS_CD_PRODUCT) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "cdProduct")
            Else
                Me.ViewState(examplePage.VS_CD_PRODUCT) = Me.Server.HtmlDecode(AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "cdProduct"))
            End If
            '製品CD
            If Len(CStr(Me.ViewState(examplePage.VS_CD_PRODUCT))) = 0 Then
                Return -1
            End If
            '取引先会社CD
            Me.ViewState(examplePage.VS_CD_COMPANY) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "cdCompany1")
            '取引先会社CD
            If Len(CStr(Me.ViewState(examplePage.VS_CD_COMPANY))) = 0 Then
                Return -1
            End If

            If convsFlg = True Then
                '検索のデータのセキュア変換
                AgnUtil.ConvDs(Me, CType(Me.mySearchOutData.FrmProductDS, DataSet))
            End If


            '取引先会社名
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaCompany1") = "" Or
                    AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaCompany1") Is Nothing Then
                Me.d_lbl_na_company.Text = AgnConst.HTML_SPACE
            Else
                Me.d_lbl_na_company.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaCompany1")
            End If

            '取引先事務所名
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaOffice1") = "" Or
                    AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaOffice1") Is Nothing Then
                Me.d_lbl_na_office.Text = AgnConst.HTML_SPACE
            Else
                Me.d_lbl_na_office.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaOffice1")
            End If

            '調査物質群ID
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "idChemicalInvGroup") = "" Or
                    AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "idChemicalInvGroup") Is Nothing Then
                Me.d_lbl_green_version.Text = AgnConst.HTML_SPACE
                Me.d_lbl_na_surveyeproductgrp.Text = AgnConst.HTML_SPACE
            Else
                '調査物質群名
                If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaInvChemicalGroupLatest") = "" Or
                        AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaInvChemicalGroupLatest") Is Nothing Then
                    Me.d_lbl_green_version.Text = AgnConst.HTML_SPACE
                    Me.d_lbl_na_surveyeproductgrp.Text = AgnConst.HTML_SPACE
                Else
                    '画面上のjsを使う、調査物質群IDと調査物質群名によって、グリーン調達ガイドラインver.を設定する
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "setChemicalInvGroup",
                                "<script type=""text/javascript"">setChemicalInvGroup(" & AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "idChemicalInvGroup") & ",""" & AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaInvChemicalGroupLatest") & """);</script>")
                End If
            End If

            '排他判定用UD_DATE
            Me.ViewState(examplePage.VS_UD_DATE_PRODUCT) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "udDate")

        End If


        If Me.mySearchOutData.FrmPurchaseDS.Tables(0).Rows.Count = 0 Then
            'エラーメセージ表示
            AgnMsg.ShowErrMessage(Me, Me.mySearchOutData.ErrorList)
            Return -1
        Else

            '環境認定コメント
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval") Is Nothing Then
                Me.d_txt_enviroment_approval_comment.Text = ""
            Else
                Me.d_txt_enviroment_approval_comment.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval")
            End If
            '不含有保証書適用除外コード(ELV)
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV") Is Nothing Then
                Me.d_txt_no_content_certificate_escape_code_e.Text = ""
            Else
                Me.d_txt_no_content_certificate_escape_code_e.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV")
            End If
            '不含有保証書適用除外コード(ROHS)
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS") Is Nothing Then
                Me.d_txt_no_content_certificate_escape_code_r.Text = ""
            Else
                Me.d_txt_no_content_certificate_escape_code_r.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS")
            End If

            '認定担当者
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson") Is Nothing Then
                Me.d_txt_cetified_person.Text = ""
            Else
                Me.d_txt_cetified_person.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson")
            End If
            '特記事項1
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1") Is Nothing Then
                Me.d_txt_bikou1.Text = ""
            Else
                Me.d_txt_bikou1.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1")
            End If
            '特記事項2
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2") Is Nothing Then
                Me.d_txt_bikou2.Text = ""
            Else
                Me.d_txt_bikou2.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2")
            End If
            '特記事項3
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3") Is Nothing Then
                Me.d_txt_bikou3.Text = ""
            Else
                Me.d_txt_bikou3.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3")
            End If

            If convsFlg = True Then
                '検索のデータのセキュア変換
                AgnUtil.ConvDs(Me, CType(Me.mySearchOutData.FrmPurchaseDS, DataSet))
            End If

            'A Gree'Net Data Ver.
            Me.d_lbl_agn_version.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "agnDataVersion")
            '不含有保証書
            flgNOContent = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "flgNoContentCertificate")
            If "0".Equals(flgNOContent) Then
                Me.d_lbl_no_content_certificate.Text = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SELECT_NO, MyBase.userSession.LanguageId)
            ElseIf "1".Equals(flgNOContent) Then
                Me.d_lbl_no_content_certificate.Text = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_GANNYUU_ARU, MyBase.userSession.LanguageId)
            Else
                Me.d_lbl_no_content_certificate.Text = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_GANNYUU_NAI, MyBase.userSession.LanguageId)

            End If


            '納入先会社名
            Me.d_lbl_na_purchase_company.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "lcPurchaseNaCompany")
            '納入先事業所名
            Me.d_lbl_na_purchase_office.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "lcPurchaseNaOffice")
            '納入先品名
            Me.d_lbl_na_purchase_product.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "naPurchaseProduct")
            '納入先コメント
            Me.d_lbl_input_division.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksPurchaseCompany")

            '添付資料
            If Me.mySearchOutData.FileHave Then
                Me.d_lbl_input_file.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_FILE_HAVE, MyBase.userSession.LanguageId)
            Else
                Me.d_lbl_input_file.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_FILE_NO, MyBase.userSession.LanguageId)
            End If

            '排他判定用UD_DATE
            Me.ViewState(examplePage.VS_UD_DATE) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "udDate")

            '「選択」と「削除」ボタンの活性化（該当納入先所属判定）
            Dim cdPurchaseCompany As String = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "cdPurchaseCompany")
            Dim cdPurchaseOffice As String = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "cdPurchaseOffice")

            If Not cdPurchaseOffice = MyBase.userSession.GOfficeCd Or Not cdPurchaseCompany = MyBase.userSession.GCompanyCd Then
                Me.d_btn_product_login.Enabled = False
                Me.d_btn_product_delete.Enabled = False
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "setButtonDisabled",
                                "<script type=""text/javascript"">setButtonDisabled();</script>")
                Me.d_btn_product_login.Attributes.Add("disabled", True)
                Me.d_btn_product_delete.Attributes.Add("disabled", "disabled")
            Else
                'do nothing
            End If

            '自己分析結果
            Me.d_ddl_my_analysis_result.SelectedIndex = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "myAnalysisResult")

        End If

        'AGN適用除外コード(ELV)
        If Me.mySearchOutData.AgnEscapeCode_E = String.Empty Then
            Me.d_lbl_agn_escape_code_e.Text = AgnConst.HTML_SPACE
        Else
            Me.d_lbl_agn_escape_code_e.Text = Me.mySearchOutData.AgnEscapeCode_E
        End If

        'AGN適用除外コード(ROHS)
        If Me.mySearchOutData.AgnEscapeCode_R = String.Empty Then
            Me.d_lbl_agn_escape_code_r.Text = AgnConst.HTML_SPACE
        Else
            Me.d_lbl_agn_escape_code_r.Text = Me.mySearchOutData.AgnEscapeCode_R
        End If

        '画面コントロールのスペースを削除する
        TrimSpace()

        Return AgnConst.DEFAULT_VALUE_LONG_ZERO

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 検索条件の作成処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 検索条件を作成します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub GetSearchPara()

        '製品ID
        Me.mySearchInData.IdProduct = CType(MyBase.GetParameter(examplePage.IF_ID_PRODUCT), Decimal)
        Me.ViewState(examplePage.VS_ID_PRODUCT) = Me.mySearchInData.IdProduct

        Me.mySearchInData.IdPurchase = CType(Me.ViewState(examplePage.IF_ID_PURCHASE), Decimal)

    End Sub
#End Region

#Region "ボタン処理関連"

    '-----------------------------------------------------------
    ' 機能　　　: 環境認定登録の前チェック(仕様変更により)
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: sender - System.Object
    ' 　　　　　　e　- System.EventArgs
    '
    ' 機能説明　: 環境認定登録を更新処理します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_login.Click

        '画面コントロールのスペースを削除する
        TrimSpace()

        '登録前のチェック
        If preCheck() = False Then
            Exit Sub
        Else
            '退避用パラメータ格納
            Me.ExSave()
            'subwinによるユーザー確認
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "uploadCheck",
                            "<script type=""text/javascript"">uploadCheck();</script>")

            '退避用パラメータ取得
            Me.ExRead()
            Exit Sub
        End If

    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 環境認定登録の更新処理本処理(仕様変更により)
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: sender - System.Object
    ' 　　　　　　e　- System.EventArgs
    '
    ' 機能説明　: 環境認定登録を更新処理します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_login_hd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_login_hd.Click
        Dim ret As Integer

        '画面コントロールのスペースを削除する
        TrimSpace()

        '納入情報ID
        Me.myRegisterInData.IdPurchase = CType(Me.ViewState(examplePage.IF_ID_PURCHASE), Decimal)
        '製品情報ID
        Me.myRegisterInData.IdProduct = CType(Me.ViewState(examplePage.IF_ID_PRODUCT), Decimal)
        '環境認定フラグ
        Me.myRegisterInData.Staturs = CInt(Me.d_ddl_select.SelectedValue)
        '納入情報排他判定用
        Me.myRegisterInData.UdDate = CStr(Me.ViewState(examplePage.VS_UD_DATE))
        '製品情報排他判定用
        Me.myRegisterInData.UdDateProduct = CStr(Me.ViewState(examplePage.VS_UD_DATE_PRODUCT))
        '調査物質群
        If d_hd_id_surveyeproductgrp.Value = "" Or d_hd_id_surveyeproductgrp.Value Is Nothing Then
            Me.myRegisterInData.IdChemicalManagementGroup = String.Empty
        Else
            Me.myRegisterInData.IdChemicalManagementGroup = CInt(d_hd_id_surveyeproductgrp.Value)
        End If
        '環境認定コメント
        If Me.d_txt_enviroment_approval_comment.Text = "" Or Me.d_txt_enviroment_approval_comment.Text Is Nothing Then
            Me.myRegisterInData.EnvironmentalApprovalComment = String.Empty
        ElseIf Me.d_txt_enviroment_approval_comment.Text.Contains("script>") Then
            Me.myRegisterInData.EnvironmentalApprovalComment = String.Empty
        Else
            Me.myRegisterInData.EnvironmentalApprovalComment = CStr(Me.d_txt_enviroment_approval_comment.Text)
        End If
        '不含有保証書適用除外コード(ELV)
        If Me.d_txt_no_content_certificate_escape_code_e.Text = "" Or Me.d_txt_no_content_certificate_escape_code_e.Text Is Nothing Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_E = String.Empty
        ElseIf Me.d_txt_no_content_certificate_escape_code_e.Text.Contains("script>") Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_E = String.Empty
        Else
            Me.myRegisterInData.NoContentCertificateEscapeCode_E = CStr(Me.d_txt_no_content_certificate_escape_code_e.Text)
        End If
        '不含有保証書適用除外コード(ROHS)
        If Me.d_txt_no_content_certificate_escape_code_r.Text = "" Or Me.d_txt_no_content_certificate_escape_code_r.Text Is Nothing Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_R = String.Empty
        ElseIf Me.d_txt_no_content_certificate_escape_code_r.Text.Contains("script>") Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_R = String.Empty
        Else
            Me.myRegisterInData.NoContentCertificateEscapeCode_R = CStr(Me.d_txt_no_content_certificate_escape_code_r.Text)
        End If
        '自己分析結果
        Me.myRegisterInData.MyAnalysisResult = CInt(Me.d_ddl_my_analysis_result.SelectedValue)
        '認定担当者
        If Me.d_txt_cetified_person.Text = "" Or Me.d_txt_cetified_person.Text Is Nothing Then
            Me.myRegisterInData.CertifiedPerson = String.Empty
        ElseIf Me.d_txt_cetified_person.Text.Contains("script>") Then
            Me.myRegisterInData.CertifiedPerson = String.Empty
        Else
            Me.myRegisterInData.CertifiedPerson = CStr(Me.d_txt_cetified_person.Text)
        End If
        '特記事項1
        If Me.d_txt_bikou1.Text = "" Or Me.d_txt_bikou1.Text Is Nothing Then
            Me.myRegisterInData.Bikou1 = String.Empty
        ElseIf Me.d_txt_bikou1.Text.Contains("script>") Then
            Me.myRegisterInData.Bikou1 = String.Empty
        Else
            Me.myRegisterInData.Bikou1 = CStr(Me.d_txt_bikou1.Text)
        End If
        '特記事項2
        If Me.d_txt_bikou2.Text = "" Or Me.d_txt_bikou2.Text Is Nothing Then
            Me.myRegisterInData.Bikou2 = String.Empty
        ElseIf Me.d_txt_bikou2.Text.Contains("script>") Then
            Me.myRegisterInData.Bikou2 = String.Empty
        Else
            Me.myRegisterInData.Bikou2 = CStr(Me.d_txt_bikou2.Text)
        End If
        '特記事項3
        If Me.d_txt_bikou3.Text = "" Or Me.d_txt_bikou3.Text Is Nothing Then
            Me.myRegisterInData.Bikou3 = String.Empty
        ElseIf Me.d_txt_bikou3.Text.Contains("script>") Then
            Me.myRegisterInData.Bikou3 = String.Empty
        Else
            Me.myRegisterInData.Bikou3 = CStr(Me.d_txt_bikou3.Text)
        End If

        Me.myLogic = New exampleLogic(MyBase.userSession)
        ret = Me.myLogic.Execute(exampleLogic.FUNC_UPDATE, CType(Me.myRegisterInData, DTOBase), CType(Me.myRegisterOutData, DTOBase))

        If ret >= 0 Then
            If Me.myRegisterOutData.ErrFlag >= 0 Then
                Me.TransferTo(AgnConst.GR0150_PAGE & CStr(Me.ViewState(examplePage.IF_PARA_TRAN)))
            Else
                '該当納入情報がある場合、エラーメッセージを出力する.（業務エラー）
                AgnMsg.ShowErrMessage(Me, myRegisterOutData.ErrorList)
            End If
            Me.d_btn_product_login.Enabled = True
        Else
            '異常処理を設定
            Me.myRegisterOutData.ErrorList.Add("SYE0000-01")
            MyBase.SetException(Me.myRegisterOutData)
        End If
    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 環境認定登録の削除処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: sender - System.Object
    ' 　　　　　　e　- System.EventArgs
    '
    ' 機能説明　: 環境認定登録を削除処理します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_delete.Click

        '画面コントロールのスペースを削除する
        TrimSpace()

        '退避用パラメータ格納
        Me.ExSave()

        'subwinによるユーザー確認
        Me.ClientScript.RegisterStartupScript(Me.GetType(), "deleteCheck",
                            "<script type=""text/javascript"">deleteCheck();</script>")

        '退避用パラメータ取得
        Me.ExRead()
        Exit Sub

    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 環境認定登録の削除処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: sender - System.Object
    ' 　　　　　　e　- System.EventArgs
    '
    ' 機能説明　: 環境認定登録を削除処理します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_delete_hd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_delete_hd.Click
        Dim ret As Integer

        '納入情報ID
        Me.myRegisterInData.IdPurchase = CType(Me.ViewState(examplePage.IF_ID_PURCHASE), Decimal)
        '納入情報排他判定用
        Me.myRegisterInData.UdDate = CStr(Me.ViewState(examplePage.VS_UD_DATE))

        Me.myLogic = New exampleLogic(MyBase.userSession)
        ret = Me.myLogic.Execute(exampleLogic.FUNC_DELETE, CType(Me.myRegisterInData, DTOBase), CType(Me.myRegisterOutData, DTOBase))

        If ret >= 0 Then
            If Me.myRegisterOutData.ErrFlag >= 0 Then
                Me.TransferTo(AgnConst.GR0150_PAGE & CStr(Me.ViewState(examplePage.IF_PARA_TRAN)))
            Else
                '該当納入情報がある場合、エラーメッセージを出力する.（業務エラー）
                AgnMsg.ShowErrMessage(Me, myRegisterOutData.ErrorList)
            End If
            Me.d_btn_product_login.Enabled = True
        Else
            '異常処理を設定
            MyBase.SetException(Me.myRegisterOutData)
        End If
    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 納入情報画面に戻る
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: sender - System.Object
    ' 　　　　　　e　- System.EventArgs
    '
    ' 機能説明　: 納入情報画面に戻る
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub s_btn_back2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s_btn_back2.Click
        Me.TransferTo(AgnConst.GR0150_PAGE & CStr(Me.ViewState(examplePage.IF_PARA_TRAN)))
    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 画面コントロールのスペースを削除する
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 画面コントロールのスペースを削除する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub TrimSpace()

        '環境認定コメント
        AgnUtil.TrimFormSpace(Me.d_txt_enviroment_approval_comment)
        '不含有保証書適用除外コード(ELV)
        AgnUtil.TrimFormSpace(Me.d_txt_no_content_certificate_escape_code_e)
        '不含有保証書適用除外コード(ROHS)
        AgnUtil.TrimFormSpace(Me.d_txt_no_content_certificate_escape_code_r)
        '認定担当者
        AgnUtil.TrimFormSpace(Me.d_txt_cetified_person)
        '特記事項1
        AgnUtil.TrimFormSpace(Me.d_txt_bikou1)
        '特記事項2
        AgnUtil.TrimFormSpace(Me.d_txt_bikou2)
        '特記事項3
        AgnUtil.TrimFormSpace(Me.d_txt_bikou3)

    End Sub

    '---------------------------------------------------------------------------
    ' 機能　　　: 登録前のチェック
    '
    ' 返り値　　: エラーフラグ
    '
    ' 引き数　　: 
    '
    ' 機能説明　: 登録前のチェック
    '
    ' 備考　　　: 
    '---------------------------------------------------------------------------
    Private Function preCheck() As Boolean

        Dim errList As ArrayList = New ArrayList    'エラーリスト
        Dim isNoErr As Boolean = True 'エラーフラグ

        '初期化の時、NG全部非表示
        '環境認定コメント
        Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:none")
        '不含有保証書適用除外コード(ELV)
        Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:none")
        '不含有保証書適用除外コード(ROHS)
        Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:none")
        '認定担当者
        Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:none")
        '特記事項1
        Me.s_lbl_err_bikou1.Attributes.Add("style", "display:none")
        '特記事項2
        Me.s_lbl_err_bikou2.Attributes.Add("style", "display:none")
        '特記事項3
        Me.s_lbl_err_bikou3.Attributes.Add("style", "display:none")


        ' GRE0800-01 環境認定コメントは200文字以下で入力してください。
        If Me.d_txt_enviroment_approval_comment.Text.Length > 200 Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-01"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-01"))
            'NGを表示する
            Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_enviroment_approval_comment.Text.Length > 0 And Me.d_txt_enviroment_approval_comment.Text.Contains(vbTab) Then

            'エラーメッセージを設定する
            errList.Add("環境認定コメントはタブを入力しないてください。")
            'NGを表示する
            Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-02 不含有保証書適用除外コードは半角のみ100文字以下で入力してください。(ROHS)
        If Me.d_txt_no_content_certificate_escape_code_r.Text.Length > 100 Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            'NGを表示する
            Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_r.Text.Length > 0 And (Not (System.Text.RegularExpressions.Regex.Match(Me.d_txt_no_content_certificate_escape_code_r.Text, "^[a-zA-Z0-9!-/:;-@\[-`{-~]+$")).Success) Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            'NGを表示する
            Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_r.Text.Length > 0 And Me.d_txt_no_content_certificate_escape_code_r.Text.Contains(vbTab) Then

            'エラーメッセージを設定する
            errList.Add("不含有保証書適用除外コード(RoHS)はタブを入力しないてください。")
            'NGを表示する
            Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-07 不含有保証書適用除外コードは半角のみ100文字以下で入力してください。(ELV)
        If Me.d_txt_no_content_certificate_escape_code_e.Text.Length > 100 Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            'NGを表示する
            Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_e.Text.Length > 0 And (Not (System.Text.RegularExpressions.Regex.Match(Me.d_txt_no_content_certificate_escape_code_e.Text, "^[a-zA-Z0-9!-/:;-@\[-`{-~]+$")).Success) Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            'NGを表示する
            Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_e.Text.Length > 0 And Me.d_txt_no_content_certificate_escape_code_e.Text.Contains(vbTab) Then

            'エラーメッセージを設定する
            errList.Add("不含有保証書適用除外コード(ELV)はタブを入力しないてください。")
            'NGを表示する
            Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-03 認定担当者は100文字以下で入力してください。
        If Me.d_txt_cetified_person.Text.Length > 100 Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-03"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-03"))
            'NGを表示する
            Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_cetified_person.Text.Length > 0 And Me.d_txt_cetified_person.Text.Contains(vbTab) Then

            'エラーメッセージを設定する
            errList.Add("認定担当者はタブを入力しないてください。")
            'NGを表示する
            Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-04 特記事項1は200文字以下で入力してください。
        If Me.d_txt_bikou1.Text.Length > 200 Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-04"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-04"))
            'NGを表示する
            Me.s_lbl_err_bikou1.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_bikou1.Text.Length > 0 And Me.d_txt_bikou1.Text.Contains(vbTab) Then

            'エラーメッセージを設定する
            errList.Add("特記事項1はタブを入力しないてください。")
            'NGを表示する
            Me.s_lbl_err_bikou1.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-05 特記事項2は200文字以下で入力してください。
        If Me.d_txt_bikou2.Text.Length > 200 Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-05"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-05"))
            'NGを表示する
            Me.s_lbl_err_bikou2.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_bikou2.Text.Length > 0 And Me.d_txt_bikou2.Text.Contains(vbTab) Then

            'エラーメッセージを設定する
            errList.Add("特記事項2はタブを入力しないてください。")
            'NGを表示する
            Me.s_lbl_err_bikou2.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-06 特記事項3は200文字以下で入力してください。
        If Me.d_txt_bikou3.Text.Length > 200 Then

            'エラーメッセージを設定する
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-06"))
            'エラーログを出力する
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-06"))
            'NGを表示する
            Me.s_lbl_err_bikou3.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_bikou3.Text.Length > 0 And Me.d_txt_bikou3.Text.Contains(vbTab) Then

            'エラーメッセージを設定する
            errList.Add("特記事項3はタブを入力しないてください。")
            'NGを表示する
            Me.s_lbl_err_bikou3.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        If isNoErr = False Then

            'エラーを出力する
            AgnMsg.ShowErrMessage(Me, errList)
        End If

        Return isNoErr

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 退避用パラメータ格納
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 退避用パラメータを格納する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub ExSave()

        '環境認定
        exEnvironmentApprovalFlag = Me.d_ddl_select.SelectedIndex
        '自己分析結果
        exMyAnalysisResult = Me.d_ddl_my_analysis_result.SelectedIndex
        '環境認定コメント
        exEnvironmentAprrovalComment = Me.d_txt_enviroment_approval_comment.Text
        '不含有保証書適用除外コード(ELV)
        exNoContentCertificateEscapeCode_E = Me.d_txt_no_content_certificate_escape_code_e.Text
        '不含有保証書適用除外コード(ROHS)
        exNoContentCertificateEscapeCode_R = Me.d_txt_no_content_certificate_escape_code_r.Text
        '認定担当者
        exCertifiedPerson = Me.d_txt_cetified_person.Text
        '特記事項1
        exBikou1 = Me.d_txt_bikou1.Text
        '特記事項2
        exBikou2 = Me.d_txt_bikou2.Text
        '特記事項3
        exBikou3 = Me.d_txt_bikou3.Text

    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 退避用パラメータ取得
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 退避用パラメータを取得する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub ExRead()

        'データを取得する
        Me.GetInitData()

        '環境認定
        Me.d_ddl_select.SelectedIndex = exEnvironmentApprovalFlag
        '自己分析結果
        Me.d_ddl_my_analysis_result.SelectedIndex = exMyAnalysisResult
        '環境認定コメント
        Me.d_txt_enviroment_approval_comment.Text = exEnvironmentAprrovalComment
        '不含有保証書適用除外コード(ELV)
        Me.d_txt_no_content_certificate_escape_code_e.Text = exNoContentCertificateEscapeCode_E
        '不含有保証書適用除外コード(ROHS)
        Me.d_txt_no_content_certificate_escape_code_r.Text = exNoContentCertificateEscapeCode_R
        '認定担当者
        Me.d_txt_cetified_person.Text = exCertifiedPerson
        '特記事項1
        Me.d_txt_bikou1.Text = exBikou1
        '特記事項2
        Me.d_txt_bikou2.Text = exBikou2
        '特記事項3
        Me.d_txt_bikou3.Text = exBikou3

    End Sub

#End Region

End Class