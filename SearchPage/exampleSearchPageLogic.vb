'---------------------------------------------------------------
' 　納入情報環境認定登録
'---------------------------------------------------------------
Public Class exampleLogic
    Inherits DBOperator

#Region "変数.定数宣言"

    Private myexampleDA As exampleDA

    Public Const FUNC_UPDATE As String = "update"
    Public Const FUNC_DELETE As String = "delete"
    Public Const FUNC_DOWNLOAD As String = "download"
    Public Const FUNC_READ As String = "init"

    Private myBuyerRequestProductDA As BuyerRequestProductDA                '調達者調査依頼製品データクラス

    Private myPurchaseDA As PurchaseDA                                      '納入情報データアクセス
    Private myProductDAT As ProductDA                                        '製品基本情報(入力完了)
    Private PAGE_TYPE As GR0150Logic.PAGE_TYPE                               '遷移先画面フラグ
#End Region

#Region "初期処理"
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

#Region "画面実行"
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
                Me.init(CType(myRequest, exampleSearchRequest), CType(myResponse, exampleSearchResponse))
                Return DBOperator.ExecuteMyFuncResult.OK
            Case FUNC_UPDATE
                Me.update(CType(myRequest, exampleRegisterRequest), CType(myResponse, exampleRegisterResponse))
                Return DBOperator.ExecuteMyFuncResult.OK
            Case FUNC_DELETE
                Me.delete(CType(myRequest, exampleRegisterRequest), CType(myResponse, exampleRegisterResponse))
                Return DBOperator.ExecuteMyFuncResult.OK
            Case Else
                Return DBOperator.ExecuteMyFuncResult.UNDEF
        End Select

    End Function

#End Region

#Region "検索処理"

    '-----------------------------------------------------------
    ' 機能　　　: 指定条件検索
    '
    ' 返り値　　: なし 
    '
    ' 引き数　　: inData    - 入力パラメータ
    ' 　　　　　  outData   - 出力パラメータ
    '
    ' 機能説明　: 指定条件のレコード数を取得する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub init(ByVal inData As exampleSearchRequest, ByRef outData As exampleSearchResponse)
        Dim intReturnValue As Integer
        Dim msg As String
        Dim idProduct As Decimal
        Dim resultEscapeCodeTable As DataTable


        '新対象の生成
        Me.myProductDAT = New ProductDA(MyBase.myUserSession)
        'クリア
        Me.myProductDAT.ProductClear()
        'パラメータの取得
        '製品IDの設定
        Me.myProductDAT.IdProduct = inData.IdProduct
        Me.myProductDAT.CdLang = MyBase.myUserSession.LanguageId
        '検索類型の設定
        Me.myProductDAT.ReadPattern = 0
        idProduct = Me.myProductDAT.IdProduct

        intReturnValue = Me.myProductDAT.ProductRead()

        outData.ErrFlag = intReturnValue

        '戻り値を判断
        If intReturnValue = AgnConst.DAReturnValue.NoInput Then
            'パラメータエラー
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            Me.myProductDAT = Nothing
            Return
        ElseIf intReturnValue = 0 Then
            'データ無し
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYI0000-08")
            outData.ErrorList.Add("SYI0000-08")
            AgnLog.Err(MyBase.myUserSession, msg)
            Me.myProductDAT = Nothing
            outData.ErrFlag = -22   '製品DAにデータがなければ、エラー頁へ
            Return
        End If


        '検索のデータセットの設定
        outData.FrmProductDS = CType(Me.myProductDAT.ResultDataSet, ProductDS)

        Me.myProductDAT = Nothing

        Me.myPurchaseDA = New PurchaseDA(MyBase.myUserSession)
        Me.myPurchaseDA.CDLang = MyBase.myUserSession.LanguageId
        Me.myPurchaseDA.IDPurchase = inData.IdPurchase
        Me.myPurchaseDA.ReadPattern = 0
        '検索実行
        intReturnValue = Me.myPurchaseDA.PurchaseRead()

        outData.ErrFlag = intReturnValue

        '戻り値を判断
        If intReturnValue = AgnConst.DAReturnValue.NoInput Then
            'パラメータエラー
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            Me.myPurchaseDA = Nothing
            Return
        ElseIf intReturnValue = 0 Then
            outData.FrmPurchaseDS = CType(Me.myPurchaseDA.ResultDataSet, PurchaseDS)
            If outData.FrmPurchaseDS.Tables(0).Rows.Count = 0 Then
                msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYI0000-08")
                outData.ErrorList.Add("SYI0000-08")
                AgnLog.Err(MyBase.myUserSession, msg)
                Me.myPurchaseDA = Nothing
                outData.ErrFlag = -22   '製品DAにデータがなければ、エラー頁へ
                Return
            End If
        End If

        '検索のデータセットの設定
        outData.FrmPurchaseDS = CType(Me.myPurchaseDA.ResultDataSet, PurchaseDS)

        Me.myPurchaseDA = Nothing

        Me.myexampleDA = New exampleDA(Me.myUserSession)
        '納入情報ID
        Me.myexampleDA.IdPurchase = CStr(inData.IdPurchase)

        intReturnValue = Me.myexampleDA.fileInfo()
        outData.ErrFlag = intReturnValue
        If intReturnValue = AgnConst.DAReturnValue.NoInput Then
            'パラメータエラー
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            Me.myexampleDA = Nothing
            Return
        End If

        If intReturnValue > AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
            outData.FileHave = True
        Else
            outData.FileHave = False
        End If


        Me.myexampleDA = New exampleDA(Me.myUserSession)
        '製品ID
        Me.myexampleDA.IdProduct = CStr(inData.IdProduct)

        resultEscapeCodeTable = Me.myexampleDA.getEscapeCode()

        '結果テーブルにデータがある場合
        If resultEscapeCodeTable.Rows.Count > 0 Then

            If resultEscapeCodeTable.Rows(0).Item(0) = CType(AgnConst.DAReturnValue.NoInput, String) Then
                'パラメータエラー
                msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
                outData.ErrorList.Add(msg)
                AgnLog.Err(MyBase.myUserSession, msg)
                Me.myexampleDA = Nothing
                Return
            End If

            For i = 0 To resultEscapeCodeTable.Rows.Count - 1
                '最初の除外コード
                If i = 0 Then
                    outData.AgnEscapeCode = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                    '最初以外の除外コード
                Else
                    outData.AgnEscapeCode = outData.AgnEscapeCode & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                End If
            Next

            Dim r As Integer = 0
            Dim e As Integer = 0
            For i = 0 To resultEscapeCodeTable.Rows.Count - 1
                'ENVの場合
                If "E" = CType(resultEscapeCodeTable.Rows(i).Item(1), String) Then
                    '最初のENV除外コード
                    If e = 0 Then
                        outData.AgnEscapeCode_E = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        e = e + 1
                        '最初以外のENV除外コード
                    Else
                        '重複な除外コード表示されない
                        If outData.AgnEscapeCode_E.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_E = outData.AgnEscapeCode_E & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                    'ROHSの場合
                ElseIf "R" = CType(resultEscapeCodeTable.Rows(i).Item(1), String) Then
                    '最初のROHS除外コード
                    If r = 0 Then
                        outData.AgnEscapeCode_R = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        r = r + 1
                        '最初以外のROHS除外コード
                    Else
                        '重複な除外コード表示されない
                        If outData.AgnEscapeCode_R.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_R = outData.AgnEscapeCode_R & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                    'ROHS,ENVの場合
                ElseIf "R,E" = CType(resultEscapeCodeTable.Rows(i).Item(1), String) Then
                    '最初のENV除外コード
                    If e = 0 Then
                        outData.AgnEscapeCode_E = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        e = e + 1
                        '最初以外のENV除外コード
                    Else
                        '重複な除外コード表示されない
                        If outData.AgnEscapeCode_E.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_E = outData.AgnEscapeCode_E & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                    '最初のROHS除外コード
                    If r = 0 Then
                        outData.AgnEscapeCode_R = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        r = r + 1
                        '最初以外のROHS除外コード
                    Else
                        '重複な除外コード表示されない
                        If outData.AgnEscapeCode_R.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_R = outData.AgnEscapeCode_R & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                End If
            Next


            '結果テーブルにデータがない場合
        Else
            outData.AgnEscapeCode = String.Empty
            outData.AgnEscapeCode_E = String.Empty
            outData.AgnEscapeCode_R = String.Empty
        End If

    End Sub

#End Region

#Region "更新処理実行"
    '-----------------------------------------------------------
    ' 機能　　　: 指定条件更新
    '
    ' 返り値　　: なし 
    '
    ' 引き数　　: inData    - 入力パラメータ
    ' 　　　　　  outData   - 出力パラメータ
    '
    ' 機能説明　: 指定条件のレコードを更新する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub update(ByVal inData As exampleRegisterRequest, ByRef outData As exampleRegisterResponse)
        Dim result As Integer
        Dim msg As String               'メッセージ
        Dim inDataSearch As New exampleSearchRequest
        Dim outDataSearch As New exampleSearchResponse

        myexampleDA = New exampleDA(Me.myUserSession)
        '納入情報ID
        Me.myexampleDA.IdPurchase = CStr(inData.IdPurchase)
        '環境認定フラグ
        Me.myexampleDA.Staturs = inData.Staturs
        '納入情報排他判定用登録日時
        Me.myexampleDA.UdDate = inData.UdDate
        '製品情報排他判定用登録日時
        Me.myexampleDA.UdDateProduct = inData.UdDateProduct
        '製品情報ID
        Me.myexampleDA.IdProduct = CStr(inData.IdProduct)
        '調査物質群
        Me.myexampleDA.IdChemicalManagementGroup = inData.IdChemicalManagementGroup
        '環境認定コメント
        Me.myexampleDA.EnvironmentalApprovalComment = inData.EnvironmentalApprovalComment
        '不含有保証書適用除外コード(ROHS)
        Me.myexampleDA.NoContentCertificateEscapeCode_R = inData.NoContentCertificateEscapeCode_R
        '自己分析結果
        Me.myexampleDA.MyAnalysisResult = inData.MyAnalysisResult
        '認定担当者
        Me.myexampleDA.CertifiedPerson = inData.CertifiedPerson
        '特記事項1
        Me.myexampleDA.Bikou1 = inData.Bikou1
        '特記事項2
        Me.myexampleDA.Bikou2 = inData.Bikou2
        '特記事項3
        Me.myexampleDA.Bikou3 = inData.Bikou3
        '不含有保証書適用除外コード(ELV)
        Me.myexampleDA.NoContentCertificateEscapeCode_E = inData.NoContentCertificateEscapeCode_E

        result = myexampleDA.updateFile()

        'エラーフラグを設定
        outData.ErrFlag = result

        'エラーログ出力
        If result = AgnConst.DAReturnValue.NoInput Then
            'パラメータエラー
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        ElseIf result = AgnConst.DAReturnValue.Haita Then
            '他ユーザの操作により、製品基本情報が変更されています。再度検索し、操作を行って下さい。
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-09")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            'エラーフラグを設定
            outData.ErrFlag = -23
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        End If

        Me.myexampleDA = Nothing

    End Sub
#End Region

#Region "削除処理実行"
    '-----------------------------------------------------------
    ' 機能　　　: 指定条件削除
    '
    ' 返り値　　: なし 
    '
    ' 引き数　　: inData    - 入力パラメータ
    ' 　　　　　  outData   - 出力パラメータ
    '
    ' 機能説明　: 指定条件のレコードを削除する(未使用フラグを1にする)
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub delete(ByVal inData As exampleRegisterRequest, ByRef outData As exampleRegisterResponse)
        Dim result As Integer
        Dim msg As String               'メッセージ
        Dim inDataSearch As New exampleSearchRequest
        Dim outDataSearch As New exampleSearchResponse

        myexampleDA = New exampleDA(Me.myUserSession)
        '納入情報ID
        Me.myexampleDA.IdPurchase = CStr(inData.IdPurchase)
        '削除日時
        Me.myexampleDA.UdDate = inData.UdDate

        result = myexampleDA.deleteFile()

        'エラーフラグを設定
        outData.ErrFlag = result

        'エラーログ出力
        If result = AgnConst.DAReturnValue.NoInput Then
            'パラメータエラー
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        ElseIf result = AgnConst.DAReturnValue.Haita Then
            '他ユーザの操作により、製品基本情報が変更されています。再度検索し、操作を行って下さい。
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-09")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            'エラーフラグを設定
            outData.ErrFlag = -23
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        End If

        Me.myexampleDA = Nothing

    End Sub
#End Region

End Class
