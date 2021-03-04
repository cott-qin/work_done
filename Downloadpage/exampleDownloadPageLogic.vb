'---------------------------------------------------------------
' 　ファイルダウンロードロジッククラス
'---------------------------------------------------------------
Public Class exampleLogic
    Inherits DBOperator

#Region "定数宣言"

    Public Const FUNC_READ As String = "Read"   '検索処理方法名

#End Region

#Region "変数宣言"

    Private myexampleDA As exampleDA                   'DA製品構成一覧
    Private myexampleTWDA As exampleTWDA               'DA製品構成一覧
    Private myexampleDS As exampleDS = New exampleDS    '製品基本情報、材料構成情報、含有化学物質情報

#End Region

#Region "初期化"

    '-----------------------------------------------------------
    ' 機能　　　: コンストラクタ
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: ユーザセッション
    '
    ' 機能説明　: 該当クラスのコンストラクタメソッド
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Public Sub New(ByVal session As UserSession)

        MyBase.New(session)

    End Sub

#End Region

#Region "共通方法関連"

    '-----------------------------------------------------------
    ' 機能　　　: 画面運行
    '
    ' 返り値　　: 0:正常; -3:異常
    '
    ' 引き数　　: funcName - 関数名
    ' 　　　　　  myRequest - 入力データ
    ' 　　　　　  myResponse - 出力結果
    '
    ' 機能説明　: 画面運行
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Public Overrides Function Run(ByVal funcName As String, ByVal myRequest As DTOBase, ByRef myResponse As DTOBase) As Integer

        Select Case funcName
            Case FUNC_READ
                Me.Read(CType(myRequest, exampleRequest), CType(myResponse, exampleResponse))
                Return exampleLogic.ExecuteMyFuncResult.OK
            Case Else
                Return exampleLogic.ExecuteMyFuncResult.UNDEF
        End Select

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 指定条件検索
    '
    ' 返り値　　: 検索したレコード数
    '
    ' 引き数　　: inData    - 入力パラメータ
    ' 　　　　　  outData   - 出力パラメータ
    '
    ' 機能説明　:
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Function Read(ByRef inData As exampleRequest, ByRef outData As exampleResponse) As Integer

        Dim intRet As Integer
        Dim msg As String
        Dim intDivSearchTarget As Integer

        '検索対象データを取得
        intDivSearchTarget = inData.DivSearchTarget
        If intDivSearchTarget = AgnConst.DEFAULT_VALUE_INTEGER_ONE Then
            Me.myexampleDA = New exampleDA(MyBase.myUserSession)

            '変数のクリア
            Me.myexampleDA.Clear()

            Me.GetSearchPara(inData)

            '情報を取得
            intRet = myexampleDA.FdProductInfMaterialRead()
        ElseIf intDivSearchTarget = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
            Me.myexampleTWDA = New exampleTWDA(MyBase.myUserSession)

            '変数のクリア
            Me.myexampleTWDA.Clear()

            Me.GetSearchTWPara(inData)

            '情報を取得
            intRet = myexampleTWDA.FdProductInfMaterialRead()
        End If


        If intRet = AgnConst.DAReturnValue.NoInput Then
            'で検索した結果の戻り値が-1の場合、エラーを表示する。
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add("SYE0000-02")
            AgnLog.Err(MyBase.myUserSession, msg)
        ElseIf intRet = AgnConst.DAReturnValue.Normal Then
            '検索した結果の戻り値が0の場合、検索結果なしのメッセージを表示する。
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYI0000-08")
            outData.ErrorList.Add("SYI0000-08")
            AgnLog.Err(MyBase.myUserSession, msg)
            outData.ErrFlag = 1
        ElseIf intRet = AgnConst.DAReturnValue.Haita Then
            '検索した結果の戻り値が0の場合、検索結果なしのメッセージを表示する。
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "FDE0020-01")
            outData.ErrorList.Add("FDE0020-01")
            AgnLog.Err(MyBase.myUserSession, msg)
            outData.ErrFlag = 2
        End If

        'レコードセット
        If intDivSearchTarget = 1 Then
            outData.ProductInfMaterialDataSet = CType(myexampleDA.exampleDS, exampleDS)
        ElseIf intDivSearchTarget = 0 Then
            outData.ProductInfMaterialDataSet = CType(myexampleTWDA.exampleDS, exampleDS)
        End If

        Return intRet

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 条件の作成処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: inData - 製品情報（部品系）ファイルダウンロードリクエストオブジェクト
    '
    ' 機能説明　: 更新の場合、条件を作成します
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Sub GetSearchPara(ByRef inData As exampleRequest)

        '製品ID
        Me.myexampleDA.IdProduct = inData.IdProduct
        '言語コード
        Me.myexampleDA.CdLang = MyBase.myUserSession.LanguageId
        '取引先会社CD
        Me.myexampleDA.CdSalesCompany = inData.CdSalesCompany
        '製品番号
        Me.myexampleDA.CdProduct = inData.CdProduct
        '製品名
        Me.myexampleDA.NaProduct = inData.NaProduct
        '製造会社CD
        Me.myexampleDA.CdProductingOffice = inData.CdProductingOffice
        '製造会社名
        Me.myexampleDA.NaProductingOffice = inData.NaProductingOffice
        '検索対象データ
        Me.myexampleDA.DivSearchTarget = inData.DivSearchTarget
        '製品フォーマット
        Me.myexampleDA.divFormat = inData.DivFormat
        '取引先会社名
        Me.myexampleDA.NaSalesCompany = inData.NaSalesCompany
        'シリーズ名
        Me.myexampleDA.NaSeries = inData.NaSeries
        '含有CAS番号
        Me.myexampleDA.CasNoChem = inData.CasNoChem
        '含有物質名
        Me.myexampleDA.NaProductChem = inData.NaProductChem
        '物質群
        Me.myexampleDA.CdChemGroup = inData.CdChemGroup
        '選択チェックボックス
        Me.myexampleDA.SlctChkBox = inData.SlctChkBox
        '製品番号
        If Not Me.myexampleDA.CdProduct Is Nothing Then
            Me.myexampleDA.IdProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.CdProduct)
            Me.myexampleDA.CdProduct = Me.myexampleDA.CdProduct.Replace("*", "")
        End If
        '製品名
        If Not Me.myexampleDA.NaProduct Is Nothing Then
            Me.myexampleDA.IdNaProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.NaProduct)
            Me.myexampleDA.NaProduct = Me.myexampleDA.NaProduct.Replace("*", "")
        End If

        '最終更新日(from)
        Me.myexampleDA.UpdateFrom = AgnUtil.EditParaDate(inData.UpdateFrom, MyBase.myUserSession.LanguageId, AgnConst.DEFAULT_VALUE_STRING)
        '最終更新日(to)
        Me.myexampleDA.UpdateTo = AgnUtil.EditParaDate(inData.UpdateTo, MyBase.myUserSession.LanguageId, "less")

        '納入先会社CD
        Me.myexampleDA.CdPurchaseCompany = inData.CdPurchaseCompany
        '納入先事業所CD
        Me.myexampleDA.CdPurchaseOffice = inData.CdPurchaseOffice
        '製造会社CD
        Me.myexampleDA.CdProductingOffice = inData.CdProductingOffice
        '製造会社名
        Me.myexampleDA.NaProductingOffice = inData.NaProductingOffice
        '納入先会社名
        Me.myexampleDA.NaPurchaseCompany = inData.NaPurchaseCompany
        '納入先事業所名
        Me.myexampleDA.NaPurchaseOffice = inData.NaPurchaseOffice
        '納入先図番
        Me.myexampleDA.DesignNumber = inData.DesignNumber
        '納入先品番
        Me.myexampleDA.ProductNumber = inData.ProductNumber
        '納入先品名
        Me.myexampleDA.NaPurchaseProduct = inData.NaPurchaseProduct
        '納入先図番
        If Not Me.myexampleDA.DesignNumber Is Nothing Then
            Me.myexampleDA.IdDesignNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.DesignNumber)
            Me.myexampleDA.DesignNumber = Me.myexampleDA.DesignNumber.Replace("*", "")
        End If
        '納入先品番
        If Not Me.myexampleDA.ProductNumber Is Nothing Then
            Me.myexampleDA.IdPoductNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.ProductNumber)
            Me.myexampleDA.ProductNumber = Me.myexampleDA.ProductNumber.Replace("*", "")
        End If
        '納入先品名
        If Not Me.myexampleDA.NaPurchaseProduct Is Nothing Then
            Me.myexampleDA.IdPurchaseProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.NaPurchaseProduct)
            Me.myexampleDA.NaPurchaseProduct = Me.myexampleDA.NaPurchaseProduct.Replace("*", "")
        End If

        'メニューフラグ
        Me.myexampleDA.MenuFlag = inData.MenuFlag
        '納入先役割フラグ
        Me.myexampleDA.PurchaseFlg = inData.PurchaseFlg
        'ログインユーザの会社コード
        Me.myexampleDA.LoginCdCompany = MyBase.myUserSession.GCompanyCd
        'ログインユーザの事務所コード
        Me.myexampleDA.LoginCdOffice = MyBase.myUserSession.GOfficeCd

        Me.myexampleDA.PcArray = inData.PcArray
    End Sub

    '-----------------------------------------------------------
    ' 機能　　　: 条件の作成処理
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: inData - 製品情報（部品系）ファイルダウンロードリクエストオブジェクト
    '
    ' 機能説明　: 更新の場合、条件を作成します
    '
    ' 備考　　　:
    '-----------------------------------------------------------
    Private Sub GetSearchTWPara(ByRef inData As exampleRequest)

        '製品ID
        Me.myexampleTWDA.IdProduct = inData.IdProduct
        '言語コード
        Me.myexampleTWDA.CdLang = MyBase.myUserSession.LanguageId
        '取引先会社CD
        Me.myexampleTWDA.CdSalesCompany = inData.CdSalesCompany
        '製品番号
        Me.myexampleTWDA.CdProduct = inData.CdProduct
        '製品名
        Me.myexampleTWDA.NaProduct = inData.NaProduct
        '製造会社名
        Me.myexampleTWDA.NaProductingOffice = inData.NaProductingOffice
        '検索対象データ
        Me.myexampleTWDA.DivSearchTarget = inData.DivSearchTarget
        '製品フォーマット
        Me.myexampleTWDA.divFormat = inData.DivFormat
        '取引先会社名
        Me.myexampleTWDA.NaSalesCompany = inData.NaSalesCompany
        'シリーズ名
        Me.myexampleTWDA.NaSeries = inData.NaSeries
        '含有CAS番号
        Me.myexampleTWDA.CasNoChem = inData.CasNoChem
        '含有物質名
        Me.myexampleTWDA.NaProductChem = inData.NaProductChem
        '物質群
        Me.myexampleTWDA.CdChemGroup = inData.CdChemGroup
        '選択チェックボックス
        Me.myexampleTWDA.SlctChkBox = inData.SlctChkBox
        '製品番号
        If Not Me.myexampleTWDA.CdProduct Is Nothing Then
            Me.myexampleTWDA.IdProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.CdProduct)
            Me.myexampleTWDA.CdProduct = Me.myexampleTWDA.CdProduct.Replace("*", "")
        End If
        '製品名
        If Not Me.myexampleTWDA.NaProduct Is Nothing Then
            Me.myexampleTWDA.IdNaProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.NaProduct)
            Me.myexampleTWDA.NaProduct = Me.myexampleTWDA.NaProduct.Replace("*", "")
        End If

        '最終更新日(from)
        Me.myexampleTWDA.UpdateFrom = AgnUtil.EditParaDate(inData.UpdateFrom, MyBase.myUserSession.LanguageId, AgnConst.DEFAULT_VALUE_STRING)
        '最終更新日(to)
        Me.myexampleTWDA.UpdateTo = AgnUtil.EditParaDate(inData.UpdateTo, MyBase.myUserSession.LanguageId, "less")

        '納入先会社CD
        Me.myexampleTWDA.CdPurchaseCompany = inData.CdPurchaseCompany
        '納入先事業所CD
        Me.myexampleTWDA.CdPurchaseOffice = inData.CdPurchaseOffice
        '製造会社CD
        Me.myexampleTWDA.CdProductingOffice = inData.CdProductingOffice
        '製造会社名
        Me.myexampleTWDA.NaProductingOffice = inData.NaProductingOffice
        '納入先会社名
        Me.myexampleTWDA.NaPurchaseCompany = inData.NaPurchaseCompany
        '納入先事業所名
        Me.myexampleTWDA.NaPurchaseOffice = inData.NaPurchaseOffice
        '納入先図番
        Me.myexampleTWDA.DesignNumber = inData.DesignNumber
        '納入先品番
        Me.myexampleTWDA.ProductNumber = inData.ProductNumber
        '納入先品名
        Me.myexampleTWDA.NaPurchaseProduct = inData.NaPurchaseProduct
        '納入先図番
        If Not Me.myexampleTWDA.DesignNumber Is Nothing Then
            Me.myexampleTWDA.IdDesignNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.DesignNumber)
            Me.myexampleTWDA.DesignNumber = Me.myexampleTWDA.DesignNumber.Replace("*", "")
        End If
        '納入先品番
        If Not Me.myexampleTWDA.ProductNumber Is Nothing Then
            Me.myexampleTWDA.IdPoductNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.ProductNumber)
            Me.myexampleTWDA.ProductNumber = Me.myexampleTWDA.ProductNumber.Replace("*", "")
        End If
        '納入先品名
        If Not Me.myexampleTWDA.NaPurchaseProduct Is Nothing Then
            Me.myexampleTWDA.IdPurchaseProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.NaPurchaseProduct)
            Me.myexampleTWDA.NaPurchaseProduct = Me.myexampleTWDA.NaPurchaseProduct.Replace("*", "")
        End If
        'メニューフラグ
        Me.myexampleTWDA.MenuFlag = inData.MenuFlag
        '納入先役割フラグ
        Me.myexampleTWDA.PurchaseFlg = inData.PurchaseFlg
        'ログインユーザの会社コード
        Me.myexampleTWDA.LoginCdCompany = MyBase.myUserSession.GCompanyCd
        'ログインユーザの事務所コード
        Me.myexampleTWDA.LoginCdOffice = MyBase.myUserSession.GOfficeCd

        Me.myexampleTWDA.PcArray = inData.PcArray
    End Sub

    Private Function GetFuzzyFlag(ByVal searchStr As String) As Integer

        Dim rx1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[^\*]+\*{1}$")
        Dim rx2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^\*{1}[^\*]+$")
        Dim rx3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^\*{1}[^\*]+\*{1}$")

        If searchStr.Contains("*") Then
            If rx3.IsMatch(searchStr) Then                    '部分一致
                Return AgnConst.DBTypeFlg.allLike
            ElseIf rx1.IsMatch(searchStr) Then                '前方一致
                Return AgnConst.DBTypeFlg.leftLike
            ElseIf rx2.IsMatch(searchStr) Then                '後方一致
                Return AgnConst.DBTypeFlg.rightLike
            End If
        ElseIf String.IsNullOrEmpty(searchStr) = False Then
            Return AgnConst.DBTypeFlg.equals     '完全一致
        Else
            Return 0
        End If
    End Function

#End Region

End Class
