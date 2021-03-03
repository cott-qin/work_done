'---------------------------------------------------------------
' 　ダウンロードページクラス
' 　画面処理
'---------------------------------------------------------------
Partial Class examplePage
    Inherits PageBase

#Region "定数宣言"

    Private Const V_OUTPUT_FILE_NAME As String = "data_p.csv"                                         '出力ファイル名
    Private Const MY_NUMBER_ZERO As String = "0"
    Private Const MY_NUMBER_ONE As String = "1"
    Private Const STRUCTURE_KUBUN_PARENT As String = "parent"
    Private Const STRUCTURE_KUBUN_CHILD As String = "child"

    Private Const MY_FIELD_DIV_DISCLOSURE As String = "divDisclosure"                                 '情報公開区分
    Private Const MY_FIELD_CD_SALES_COMPANY As String = "cdSalesCompany"                              '取引先会社コード
    Private Const MY_FIELD_NA_SALES_COMPANY As String = "naSalesCompany"                              '取引先会社名
    Private Const MY_FIELD_CD_SALES_OFFICE As String = "cdSalesOffice"                                '取引先事業所コード
    Private Const MY_FIELD_NA_SALES_OFFICE As String = "naSalesOffice"                                '取引先事業所名
    Private Const MY_FIELD_CD_PRODUCTING_COMPANY As String = "cdProductingCompany"                    '製造会社コード
    Private Const MY_FIELD_NA_PRODUCTING_COMPANY As String = "naProductingCompany"                    '製造会社名
    Private Const MY_FIELD_NA_PRODUCTING_COMPANY_OTHER As String = "naProductingCompanyOther"         '製造会社名
    Private Const MY_FIELD_NA_POST As String = "naPost"                                               '製造会社部署名
    Private Const MY_FIELD_NA_PERSON_CHARGE As String = "naPersonCharge"                              '製造会社担当者
    Private Const MY_FIELD_TEL_PRODUCTING_COMPANY As String = "telProductingCompany"                  '製造会社担当者TEL
    Private Const MY_FIELD_EMAIL_PRODUCTING_COMPANY As String = "emailProductingCompany"              '製造会社担当者E-mail
    Private Const MY_FIELD_NA_PRODUCT_EN As String = "naProductEn"                                    'Product name
    Private Const MY_FIELD_NA_PRODUCT As String = "naProduct"                                         '製品名
    Private Const MY_FIELD_NA_SERIES_EN As String = "naSeriesEn"                                      'Series name
    Private Const MY_FIELD_NA_SERIES As String = "naSeries"                                           'シリーズ名
    Private Const MY_FIELD_CD_PRODUCT As String = "cdProduct"                                         '製品番号
    Private Const MY_FIELD_AMOUNT_PRODUCT As String = "amountProduct"                                 '調査単位質量
    Private Const MY_FIELD_CD_UNIT_PRODUCT As String = "cdUnitProduct"                                '調査単位
    Private Const MY_FIELD_MASS_PRODUCT As String = "massProduct"                                     '製品質量
    Private Const MY_FIELD_CD_PRODUCT_UNIT_MASS As String = "cdProductUnitMass"                       '単位
    Private Const MY_FIELD_DIV_SPEC As String = "divSpec"                                             '製品仕様区分
    Private Const MY_FIELD_MAKER_DATA_VERSION As String = "makerDataVersion"                          'Maker Data Ver.
    Private Const MY_FIELD_VALIDITY_TERM As String = "validityTerm"                                   '適用日付

    Private Const MY_FIELD_CD_PARENT_SALES_COMPANY As String = "cdParentSalesCompany"                 '親製品取引先会社CD
    Private Const MY_FIELD_CD_PARENT_PRODUCT As String = "cdParentProduct"                            '親製品番号
    Private Const MY_FIELD_CD_CHILD_SALES_COMPANY As String = "cdChildSalesCompany"                   '子製品取引先会社CD
    Private Const MY_FIELD_CD_CHILD_PRODUCT As String = "cdChildProduct"                              '子製品番号
    Private Const MY_FIELD_NA_CHILD_PRODUCT As String = "naChildProduct"                              '部品名
    Private Const MY_FIELD_ASSEMBLY_ORDER As String = "assemblyOrder"                                 '順序番号
    Private Const MY_FIELD_NUMBER_PRODUCT As String = "numberProduct"                                 '員数
    Private Const MY_FIELD_AMOUNT_PRODUCT_STRUCTURE As String = "amountProductStructure"              '調査単位質量
    Private Const MY_FIELD_CD_UNIT_PRODUCT_STRUCTURE As String = "cdUnitProductStructure"             '調査単位
    Private Const MY_FIELD_MASS_PRODUCT_STRUCTURE As String = "massProductStructure"                  '製品質量
    Private Const MY_FIELD_CD_PRODUCT_UNIT_MASS_STRUCTURE As String = "cdProductUnitMassStructure"    '単位
    Private Const MY_FIELD_FLG_CONFIDENTIAL As String = "flgConfidential"                             '営業秘密

    Private Const MY_FIELD_ALIAS_MATERIAL As String = "aliasMaterial"                                 '材料名
    Private Const MY_FIELD_CD_MATERIAL As String = "cdMaterial"                                       '材料構成コード
    Private Const MY_FIELD_NA_MATERIAL As String = "naMaterial"                                       '材料構成名
    Private Const MY_FIELD_MASS_MATERIAL As String = "massMaterial"                                   '質量・率
    Private Const MY_FIELD_CD_MATERIAL_UNIT As String = "cdMaterialUnit"                              '単位
    Private Const MY_FIELD_PART_MATERIAL As String = "partMaterial"                                   '部位

    Private Const MY_FIELD_CAS_NO As String = "casNo"                                                 'CAS_NO
    Private Const MY_FIELD_SUBSTITUTION_CAS_NO As String = "substitutionCasNo"                        'CAS_NO代替
    Private Const MY_FIELD_MASS_CHEMICAL As String = "massChemical"                                   '含有量・率
    Private Const MY_FIELD_CD_CHEMICAL_UNIT As String = "cdChemicalUnit"                              '単位
    Private Const MY_FIELD_USAGE_AREA As String = "usageArea"                                         '用途

    Private Const MY_FIELD_ID_PRODUCT As String = "idProduct"                                         '製品ID
    Private Const MY_FIELD_ID_PRODUCT_MATERIAL As String = "idProductMaterial"                        '製品材料構成ID
    Private Const MY_FIELD_ID_PRODUCT_CHEMICAL As String = "idProductChemical"                        '製品含有化学物質ID

    Private Const MY_FIELD_C_UID As String = "cUid"                                                   '初期登録者
    Private Const MY_FIELD_C_DATE As String = "cDate"                                                 '初期登録日
    Private Const MY_FIELD_U_UID As String = "udUid"                                                  '最終更新者
    Private Const MY_FIELD_U_DATE As String = "udDate"                                                '最終更新日

    Private Const MY_FIELD_S_C_UID As String = "scUid"                                                   '初期登録者
    Private Const MY_FIELD_S_C_DATE As String = "scDate"                                                 '初期登録日
    Private Const MY_FIELD_S_U_UID As String = "sudUid"                                                  '最終更新者
    Private Const MY_FIELD_S_U_DATE As String = "sudDate"                                                '最終更新日
#End Region

#Region "変数宣言"

    Private myLogic As exampleLogic
    Private myRequet As exampleRequest = New exampleRequest           '入力引数
    Private myResponse As exampleResponse = New exampleResponse       '出力引数
    Private myLanID As String                                       '言語コード
    Private myOutList As ArrayList = New ArrayList

#End Region

#Region " Web フォーム デザイナで生成されたコード "

    'この呼び出しは Web フォーム デザイナで必要です。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'メモ : 次のプレースホルダ宣言は Web フォーム デザイナで必要です。
    '削除および移動しないでください。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: このメソッド呼び出しは Web フォーム デザイナで必要です。
        ' コード エディタを使って変更しないでください。
        InitializeComponent()
    End Sub

#End Region

#Region "初期処理"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            '出力するデータを検索します
            SearchData(MyBase.pageDataSet)
        End If
    End Sub

#End Region

#Region "検索処理関連"

    '-----------------------------------------------------------
    ' 機能　　　: 出力するデータを検索して、出力します
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: ds - DataSet
    '
    ' 機能説明　:
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Protected Overrides Sub SearchData(ByRef ds As DataSet)

        Dim ret As Integer

        '「初期検索処理」の出力
        AgnLog.Operation(MyBase.userSession, "初期検索処理")

        Me.myLogic = New exampleLogic(MyBase.userSession)
        Me.myRequet = New exampleRequest

        Dim tempStr As String = CStr(IIf(MyBase.GetParameter("d_hd_list") Is Nothing, "", MyBase.GetParameter("d_hd_list")))

        If Not "".Equals(tempStr) Then
            Me.myRequet.PcArray = Strings.Split(tempStr, ",")
        End If

        '検索条件の作成処理
        Me.GetSearchPara()

        '検索処理
        ret = Me.myLogic.Execute(exampleLogic.FUNC_READ, CType(Me.myRequet, DTOBase), CType(Me.myResponse, DTOBase))

        If ret >= 0 Then
            If Me.myResponse.ErrFlag = 0 Then

                ds = myResponse.ProductInfMaterialDataSet

                'CSVファイルを出力する
                Me.OutputCsv(V_OUTPUT_FILE_NAME)

            Else
                '検索エラー
                MyBase.SetException(Me.myResponse)
            End If
        Else
            '異常処理を設定
            MyBase.SetException(Me.myResponse)
        End If
    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 条件の作成処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 更新の場合、条件を作成します
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Sub GetSearchPara()

        Dim strIdProduct As String
        Dim delimStr As String = ","
        Dim delimiter As Char() = delimStr.ToCharArray()
        Dim splitIdProduct As String() = Nothing
        Dim strTmp As String

        '製品ID
        strIdProduct = MyBase.GetParameter("d_hd_id_product")
        If Not "".Equals(strIdProduct) Then
            splitIdProduct = strIdProduct.Split(delimiter)
            For Each strIdProduct In splitIdProduct
                'チェック入力項目
                If Not AgnUtil.CheckDataValue(strIdProduct, AgnConst.NUM_WORD, 19, False) Then
                    Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
                End If
                Me.myRequet.IdProduct.Add(strIdProduct)
            Next strIdProduct
        End If
        '取引先会社CD
        strTmp = MyBase.GetParameter("cdSalesCompany")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdSalesCompany = strTmp
        End If
        '製品番号
        strTmp = MyBase.GetParameter("cdProduct")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, "", 128, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdProduct = strTmp
        End If
        '製品名
        strTmp = MyBase.GetParameter("naProduct")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, "", 256, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaProduct = strTmp
        End If
        '製造会社CD
        strTmp = MyBase.GetParameter("cdProductingOffice")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdProductingOffice = strTmp
        End If
        '検索対象データ
        strTmp = MyBase.GetParameter("divSearchTarget")
        If Not examplePage.MY_NUMBER_ZERO.Equals(strTmp) And Not examplePage.MY_NUMBER_ONE.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.DivSearchTarget = CType(strTmp, Integer)
        'データフォーマット
        strTmp = MyBase.GetParameter("divFormat")
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 2, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.DivFormat = strTmp
        End If

        'シリーズ名
        strTmp = MyBase.GetParameter("naSeries")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, "", 128, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaSeries = strTmp
        End If
        '含有CAS番号
        strTmp = MyBase.GetParameter("casNoChem")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUMCHARACTOR_WORD, 12, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CasNoChem = strTmp
        End If
        '含有物質名
        strTmp = MyBase.GetParameter("naProductChem")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, "", 256, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaProductChem = strTmp
        End If
        '物質群
        strTmp = MyBase.GetParameter("cdChemGroup")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, "", AgnConst.CD_CHEM_GROUP_MAXLENGTH, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdChemGroup = strTmp
        End If
        '選択チェックボックス
        strTmp = MyBase.GetParameter("slctChkBox")
        If Not examplePage.MY_NUMBER_ONE.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.SlctChkBox = CType(strTmp, Integer)


        '最終更新日(FROM)
        strTmp = MyBase.GetParameter("updateFrom")
        If Not "".Equals(strTmp) Then
            If Not IsDate(strTmp) Then
                Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
            End If

            Me.myRequet.UpdateFrom = strTmp
        End If

        '最終更新日(TO)
        strTmp = MyBase.GetParameter("updateTo")
        If Not "".Equals(strTmp) Then
            If Not IsDate(strTmp) Then
                Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
            End If

            Me.myRequet.UpdateTo = strTmp
        End If

        '納入先会社CD
        strTmp = MyBase.GetParameter("cdPurchaseCompany")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdPurchaseCompany = strTmp
        End If

        '納入先事業所CD
        strTmp = MyBase.GetParameter("cdPurchaseOffice")
        'チェック入力項目
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdPurchaseOffice = strTmp
        End If

        '納入先図番
        strTmp = MyBase.GetParameter("designNumber")
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUMCHARACTOR_WORD, 32, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.DesignNumber = strTmp
        End If

        '納入先品番
        strTmp = MyBase.GetParameter("productNumber")
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUMCHARACTOR_WORD, 32, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.ProductNumber = strTmp
        End If

        '納入先品名
        strTmp = MyBase.GetParameter("naPurchaseProduct")
        If Not AgnUtil.CheckDataValue(strTmp, "", 256, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaPurchaseProduct = strTmp
        End If

        'メニューフラグ
        strTmp = MyBase.GetParameter("menuFlag")
        If Not AgnConst.PURCHASE_MENU.Equals(strTmp) And Not AgnConst.SALES_MENU.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.MenuFlag = strTmp
        '納入先役割フラグ
        strTmp = MyBase.GetParameter("purchaseFlg")
        If Not examplePage.MY_NUMBER_ZERO.Equals(strTmp) And Not examplePage.MY_NUMBER_ONE.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.PurchaseFlg = strTmp

    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 出力データ作成
    '
    ' 返り値　　: True　成功
    '       　　: fasle 失敗
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 出力データ作成
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Public Overrides Sub WriteCsvFile()

        Dim i As Integer
        Dim intRowCnt As Integer
        Dim strTmp As String

        Dim idProductOld As Decimal              '製品ID
        Dim cdParentSalesCompanyOld As String    '親製品取引先会社CD
        Dim cdParentProductOld As String         '親製品番号
        Dim cdChildSalesCompanyOld As String     '子製品取引先会社CD
        Dim cdChildProductOld As String          '子製品番号
        Dim assemblyOrderOld As String           '順序番号
        Dim idProductMaterialOld As Decimal      '製品材料構成ID
        Dim idProductChemicalOld As Decimal      '製品含有化学物質ID

        Dim idProductNew As Decimal              '製品ID
        Dim cdParentSalesCompanyNew As String    '親製品取引先会社CD
        Dim cdParentProductNew As String         '親製品番号
        Dim cdChildSalesCompanyNew As String     '子製品取引先会社CD
        Dim cdChildProductNew As String          '子製品番号
        Dim assemblyOrderNew As String           '順序番号
        Dim idProductMaterialNew As Decimal      '製品材料構成ID
        Dim idProductChemicalNew As Decimal      '製品含有化学物質ID

        '言語コード
        Me.myLanID = MyBase.userSession.LanguageId

        intRowCnt = myResponse.ProductInfMaterialDataSet.Tables(0).Rows.Count

        Me.myOutList.Add(Me.MakeBase1())
        Me.myOutList.Add(Me.MakeBase2())
        '製品基本情報
        strTmp = Me.MakeProduct(0)
        MakeArrayList(strTmp, Me.myOutList)
        '構成品情報行
        strTmp = Me.MakeProductStruct(0)
        MakeArrayList(strTmp, Me.myOutList)
        '材料構成情報
        strTmp = Me.MakeProductMaterial(0)
        MakeArrayList(strTmp, Me.myOutList)
        '化学物質情報
        strTmp = Me.MakeProductChemical(0)
        MakeArrayList(strTmp, Me.myOutList)

        '製品ID
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ID_PRODUCT)
        If Not "".Equals(strTmp) Then
            idProductOld = CType(strTmp, Decimal)
        Else
            idProductOld = -1
        End If
        '親製品取引先会社CD
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_PARENT_SALES_COMPANY)
        If Not "".Equals(strTmp) Then
            cdParentSalesCompanyOld = CType(strTmp, String)
        Else
            cdParentSalesCompanyOld = ""
        End If
        '親製品番号
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_PARENT_PRODUCT)
        If Not "".Equals(strTmp) Then
            cdParentProductOld = CType(strTmp, String)
        Else
            cdParentProductOld = ""
        End If
        '子製品取引先会社CD
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_CHILD_SALES_COMPANY)
        If Not "".Equals(strTmp) Then
            cdChildSalesCompanyOld = CType(strTmp, String)
        Else
            cdChildSalesCompanyOld = ""
        End If
        '子製品番号
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_CHILD_PRODUCT)
        If Not "".Equals(strTmp) Then
            cdChildProductOld = CType(strTmp, String)
        Else
            cdChildProductOld = ""
        End If
        '順序番号
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ASSEMBLY_ORDER)
        If Not "".Equals(strTmp) Then
            assemblyOrderOld = CType(strTmp, String)
        Else
            assemblyOrderOld = ""
        End If
        '製品材料構成ID
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ID_PRODUCT_MATERIAL)
        If Not "".Equals(strTmp) Then
            idProductMaterialOld = CType(strTmp, Decimal)
        Else
            idProductMaterialOld = -1
        End If
        '製品含有化学物質ID
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ID_PRODUCT_CHEMICAL)
        If Not "".Equals(strTmp) Then
            idProductChemicalOld = CType(strTmp, Decimal)
        Else
            idProductChemicalOld = -1
        End If

        For i = 1 To intRowCnt - 1

            '製品ID
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ID_PRODUCT)
            If Not "".Equals(strTmp) Then
                idProductNew = CType(strTmp, Decimal)
            Else
                idProductNew = -1
            End If
            '親製品取引先会社CD
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_PARENT_SALES_COMPANY)
            If Not "".Equals(strTmp) Then
                cdParentSalesCompanyNew = strTmp
            Else
                cdParentSalesCompanyNew = ""
            End If
            '親製品番号
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_PARENT_PRODUCT)
            If Not "".Equals(strTmp) Then
                cdParentProductNew = strTmp
            Else
                cdParentProductNew = ""
            End If
            '子製品取引先会社CD
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_CHILD_SALES_COMPANY)
            If Not "".Equals(strTmp) Then
                cdChildSalesCompanyNew = strTmp
            Else
                cdChildSalesCompanyNew = ""
            End If
            '子製品番号
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_CHILD_PRODUCT)
            If Not "".Equals(strTmp) Then
                cdChildProductNew = strTmp
            Else
                cdChildProductNew = ""
            End If
            '順序番号
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ASSEMBLY_ORDER)
            If Not "".Equals(strTmp) Then
                assemblyOrderNew = strTmp
            Else
                assemblyOrderNew = ""
            End If
            '製品材料構成ID
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ID_PRODUCT_MATERIAL)
            If Not "".Equals(strTmp) Then
                idProductMaterialNew = CType(strTmp, Decimal)
            Else
                idProductMaterialNew = -1
            End If
            '製品含有化学物質ID
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ID_PRODUCT_CHEMICAL)
            If Not "".Equals(strTmp) Then
                idProductChemicalNew = CType(strTmp, Decimal)
            Else
                idProductChemicalNew = -1
            End If
            If idProductOld <> idProductNew Then
                '製品基本情報
                strTmp = Me.MakeProduct(i)
                MakeArrayList(strTmp, Me.myOutList)
                '構成品情報行
                strTmp = Me.MakeProductStruct(i)
                MakeArrayList(strTmp, Me.myOutList)
                '材料構成情報
                strTmp = Me.MakeProductMaterial(i)
                MakeArrayList(strTmp, Me.myOutList)
                '化学物質情報
                strTmp = Me.MakeProductChemical(i)
                MakeArrayList(strTmp, Me.myOutList)

                idProductOld = idProductNew
                cdParentSalesCompanyOld = cdParentSalesCompanyNew
                cdParentProductOld = cdParentProductNew
                cdChildSalesCompanyOld = cdChildSalesCompanyNew
                cdChildProductOld = cdChildProductNew
                assemblyOrderOld = assemblyOrderNew
                idProductMaterialOld = idProductMaterialNew
                idProductChemicalOld = idProductChemicalNew
            Else
                If Not (cdParentSalesCompanyOld.Equals(cdParentSalesCompanyNew) And cdParentProductOld.Equals(cdParentProductNew) And cdChildSalesCompanyOld.Equals(cdChildSalesCompanyNew) And cdChildProductOld.Equals(cdChildProductNew) And assemblyOrderOld.Equals(assemblyOrderNew)) Then
                    '構成品情報行
                    strTmp = Me.MakeProductStruct(i)
                    MakeArrayList(strTmp, Me.myOutList)
                    '材料構成情報
                    strTmp = Me.MakeProductMaterial(i)
                    MakeArrayList(strTmp, Me.myOutList)
                    '化学物質情報
                    strTmp = Me.MakeProductChemical(i)
                    MakeArrayList(strTmp, Me.myOutList)

                    idProductOld = idProductNew
                    cdParentSalesCompanyOld = cdParentSalesCompanyNew
                    cdParentProductOld = cdParentProductNew
                    cdChildSalesCompanyOld = cdChildSalesCompanyNew
                    cdChildProductOld = cdChildProductNew
                    assemblyOrderOld = assemblyOrderNew
                    idProductMaterialOld = idProductMaterialNew
                    idProductChemicalOld = idProductChemicalNew
                Else
                    If idProductMaterialOld <> idProductMaterialNew Then
                        '材料構成情報
                        strTmp = Me.MakeProductMaterial(i)
                        MakeArrayList(strTmp, Me.myOutList)
                        '化学物質情報
                        strTmp = Me.MakeProductChemical(i)
                        MakeArrayList(strTmp, Me.myOutList)

                        idProductOld = idProductNew
                        cdParentSalesCompanyOld = cdParentSalesCompanyNew
                        cdParentProductOld = cdParentProductNew
                        cdChildSalesCompanyOld = cdChildSalesCompanyNew
                        cdChildProductOld = cdChildProductNew
                        assemblyOrderOld = assemblyOrderNew
                        idProductMaterialOld = idProductMaterialNew
                        idProductChemicalOld = idProductChemicalNew
                    Else
                        If idProductChemicalOld <> idProductChemicalNew Then
                            '化学物質情報
                            strTmp = Me.MakeProductChemical(i)
                            MakeArrayList(strTmp, Me.myOutList)

                            idProductOld = idProductNew
                            cdParentSalesCompanyOld = cdParentSalesCompanyNew
                            cdParentProductOld = cdParentProductNew
                            cdChildSalesCompanyOld = cdChildSalesCompanyNew
                            cdChildProductOld = cdChildProductNew
                            assemblyOrderOld = assemblyOrderNew
                            idProductMaterialOld = idProductMaterialNew
                            idProductChemicalOld = idProductChemicalNew
                        End If
                    End If
                End If
            End If
            'End If
        Next

        For i = 0 To Me.myOutList.Count - 1
            Me.Page.Response.Output.WriteLine(Me.myOutList.Item(i))
        Next

    End Sub
    '-----------------------------------------------------------
    ' 機能　　　: 出力行作成処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: strRow　- 行情報
    '            lstRow - 出力リスト
    '
    ' 機能説明　: 出力行作成処理
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Sub MakeArrayList(ByVal strRow As String, ByRef lstRow As ArrayList)

        If Not "".Equals(Trim(strRow)) Then
            lstRow.Add(strRow)
        End If

    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 基本情報行１を作成
    '
    ' 返り値　　: 基本情報行１文字列
    '
    ' 引き数　　: なし
    '
    ' 機能説明　:　基本情報行１を作成
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Function MakeBase1() As String

        Dim sbdIN As System.Text.StringBuilder

        sbdIN = New System.Text.StringBuilder("")

        '行コード
        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code1", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'システムバージョン
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_VERSION)
        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage("version_no_of_data_p"))
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'ファイル種別
        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_file_type", Me.myLanID))
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        If "1".Equals(MyBase.userSession.GgIdeFlg) Then
            'G&G識別フラグ
            sbdIN.Append(MyBase.userSession.GgIdeFlg)
        Else
            'G&G識別フラグ
            sbdIN.Append("")
        End If

        Return sbdIN.ToString

    End Function
    '-----------------------------------------------------------
    ' 機能　　　: 基本情報行２を作成
    '
    ' 返り値　　: 基本情報行２文字列
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 基本情報行２を作成
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Function MakeBase2() As String

        Dim sbdIN As System.Text.StringBuilder

        sbdIN = New System.Text.StringBuilder("")

        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code2", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)    '行コード
        sbdIN.Append(Me.myLanID)                                                                                                             '言語コード

        Return sbdIN.ToString

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 製品基本情報行文字列を作成
    '
    ' 返り値　　: 製品基本情報行文字列
    '
    ' 引き数　　: intLineNum - 行番号
    '
    ' 機能説明　:
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Function MakeProduct(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String
        Dim strCdProductCompany As String
        Dim strCdProductCompanyOther As String
        Dim lang As Language = Language.GetLanguage()
        sbdIN = New System.Text.StringBuilder("")

        '情報公開区分
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_DIV_DISCLOSURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '取引先会社コード
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_SALES_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '取引先会社名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SALES_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '取引先事業所コード
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_SALES_OFFICE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '取引先事業所名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SALES_OFFICE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製造会社コード
        strCdProductCompany = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCTING_COMPANY)
        sbdIN.Append(strCdProductCompany & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製造会社名
        strCdProductCompanyOther = lang.GetCtrlLanguage(AgnConst.SONOTACOMPANYCODE)
        If strCdProductCompanyOther.Equals(strCdProductCompany) Then
            sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCTING_COMPANY_OTHER) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        Else
            sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCTING_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        End If
        '製造会社部署名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_POST) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製造会社担当者
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PERSON_CHARGE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製造会社担当者TEL
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_TEL_PRODUCTING_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製造会社担当者E-mail
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_EMAIL_PRODUCTING_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'Product name
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCT_EN) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製品名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'Series name
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SERIES_EN) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'シリーズ名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SERIES) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製品番号
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '調査単位質量
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_AMOUNT_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '調査単位
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_UNIT_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製品質量
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '単位
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCT_UNIT_MASS) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '製品仕様区分
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_DIV_SPEC) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'Maker Data Ver.
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MAKER_DATA_VERSION) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '適用日付
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_VALIDITY_TERM) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '初期登録者
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_C_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '初期登録日
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_C_DATE), MyBase.userSession.LanguageId) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '最終更新者
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_U_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '最終更新日
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_U_DATE), MyBase.userSession.LanguageId))

        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '行コード
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code3", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 構成品情報行の文字列を作成
    '
    ' 返り値　　: 納入情報行の文字列
    '
    ' 引き数　　: intLineNum - 行番号
    '
    ' 機能説明　: 構成品情報行の文字列を作成
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Function MakeProductStruct(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String

        sbdIN = New System.Text.StringBuilder("")

        '部品番号
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_CHILD_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '部品名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_CHILD_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '順序番号
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_ASSEMBLY_ORDER) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '員数
        sbdIN.Append(AgnUtil.ZeroSuppressEnd(
                     AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NUMBER_PRODUCT)) _
                    & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '調査単位質量
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_AMOUNT_PRODUCT_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '調査単位
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_UNIT_PRODUCT_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '構成品質量
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_PRODUCT_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '単位
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCT_UNIT_MASS_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '営業秘密
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_FLG_CONFIDENTIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '初期登録者
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_C_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '初期登録日
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_C_DATE), MyBase.userSession.LanguageId) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '最終更新者
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_U_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '最終更新日
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_U_DATE), MyBase.userSession.LanguageId))
        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '行コード
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code4", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 材料構成情報行文字列を作成
    '
    ' 返り値　　: 材料構成情報行文字列
    '
    ' 引き数　　: intLineNum - 行番号
    '
    ' 機能説明　:
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Function MakeProductMaterial(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String

        sbdIN = New System.Text.StringBuilder("")

        '材料名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_ALIAS_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '材料構成コード
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '材料構成名
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '質量・率
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '単位
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_MATERIAL_UNIT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '部位
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_PART_MATERIAL))

        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '行コード
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code5", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 含有化学物質情報行文字列を作成
    '
    ' 返り値　　: 含有化学物質情報行文字列
    '
    ' 引き数　　: intLineNum - 行番号
    '
    ' 機能説明　:
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Function MakeProductChemical(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String

        sbdIN = New System.Text.StringBuilder("")

        'CAS_NO
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CAS_NO) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'CAS_NO代替
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_SUBSTITUTION_CAS_NO) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '含有量・率
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_CHEMICAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '単位
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_CHEMICAL_UNIT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '用途
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_USAGE_AREA))

        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '行コード
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code6", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

#End Region

End Class
