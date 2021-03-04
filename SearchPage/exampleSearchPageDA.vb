'---------------------------------------------------------------
' 　納入情報ファイル添付クラス


Imports System.Data.SqlClient

Public Class exampleDA
    Inherits DABase

#Region "変数宣言"
    Private myIdPurchase As String
    Private myStaturs As Integer
    Private myUdDate As String
    Private myIdProduct As String
    Private myUdDateProduct As String
    Private myIdChemicalManagementGroup As String
    Private myEnvironmentalApprovalComment As String
    Private myNoContentCertificateEscapeCode_R As String
    Private myMyAnalysisResult As String
    Private myCertifiedPerson As String
    Private myBikou1 As String
    Private myBikou2 As String
    Private myBikou3 As String
    Private myNoContentCertificateEscapeCode_E As String
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
    Sub New(ByVal userSession As UserSession)
        MyBase.New(userSession)
    End Sub

#End Region

#Region "基本属性"
    '-----------------------------------------------------------
    '[Name     ] 不含有保証書適用除外コード(ELV)
    '-----------------------------------------------------------
    Public Property NoContentCertificateEscapeCode_E() As String
        Get
            Return myNoContentCertificateEscapeCode_E
        End Get
        Set(ByVal Value As String)
            myNoContentCertificateEscapeCode_E = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 特記事項3
    '-----------------------------------------------------------
    Public Property Bikou3() As String
        Get
            Return myBikou3
        End Get
        Set(ByVal Value As String)
            myBikou3 = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 特記事項2
    '-----------------------------------------------------------
    Public Property Bikou2() As String
        Get
            Return myBikou2
        End Get
        Set(ByVal Value As String)
            myBikou2 = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 特記事項1
    '-----------------------------------------------------------
    Public Property Bikou1() As String
        Get
            Return myBikou1
        End Get
        Set(ByVal Value As String)
            myBikou1 = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 認定担当者
    '-----------------------------------------------------------
    Public Property CertifiedPerson() As String
        Get
            Return myCertifiedPerson
        End Get
        Set(ByVal Value As String)
            myCertifiedPerson = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 自己分析結果
    '-----------------------------------------------------------
    Public Property MyAnalysisResult() As String
        Get
            Return myMyAnalysisResult
        End Get
        Set(ByVal Value As String)
            myMyAnalysisResult = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 不含有保証書適用除外コード(ROHS)
    '-----------------------------------------------------------
    Public Property NoContentCertificateEscapeCode_R() As String
        Get
            Return myNoContentCertificateEscapeCode_R
        End Get
        Set(ByVal Value As String)
            myNoContentCertificateEscapeCode_R = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 環境認定コメント
    '-----------------------------------------------------------
    Public Property EnvironmentalApprovalComment() As String
        Get
            Return myEnvironmentalApprovalComment
        End Get
        Set(ByVal Value As String)
            myEnvironmentalApprovalComment = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 調査物質群情報
    '-----------------------------------------------------------
    Public Property IdChemicalManagementGroup() As String
        Get
            Return myIdChemicalManagementGroup
        End Get
        Set(ByVal Value As String)
            myIdChemicalManagementGroup = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ]製品情報排他判定用更新日
    '-----------------------------------------------------------
    Public Property UdDateProduct() As String
        Get
            Return myUdDateProduct
        End Get
        Set(ByVal Value As String)
            myUdDateProduct = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ]納入情報排他判定用更新日
    '-----------------------------------------------------------
    Public Property UdDate() As String
        Get
            Return myUdDate
        End Get
        Set(ByVal Value As String)
            myUdDate = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 環境認定フラグ
    '-----------------------------------------------------------
    Public Property Staturs() As Integer
        Get
            Return myStaturs
        End Get
        Set(ByVal Value As Integer)
            myStaturs = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 納入情報ID
    '-----------------------------------------------------------
    Public Property IdPurchase() As String
        Get
            Return Me.myIdPurchase
        End Get
        Set(ByVal Value As String)
            Me.myIdPurchase = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 製品ID
    '-----------------------------------------------------------
    Public Property IdProduct() As String
        Get
            Return Me.myIdProduct
        End Get
        Set(ByVal Value As String)
            Me.myIdProduct = Value
        End Set
    End Property

#End Region

#Region "実行処理関連"
    '-----------------------------------------------------------
    ' 機能　　　: プロパティをデフォールト値でセット
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: プロパティをデフォールト値でセット
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Public Sub Clear()
        Me.myIdPurchase = AgnConst.DEFAULT_VALUE_STRING
        Me.myStaturs = AgnConst.DEFAULT_VALUE_INTEGER_ZERO
    End Sub
    '-----------------------------------------------------------
    ' 機能　　　: 指定条件の検索
    '
    ' 返り値　　: 0:正常 -4:データを存在しません -2: 排他
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 納入情報環境認定の添付資料情報を検索する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Public Function fileInfo() As Integer
        Dim result As Integer

        '納入情報ID
        If Me.myIdPurchase.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ZERO, AgnConst.DBTypeFlg.equals)

        MyBase.ReadSql = MyBase.GetSQL("example", "example_003")

        '検索結果
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)

        MyBase.Execute()

        result = CType(MyBase.ResultDataSet.Tables(0).Rows(0).Item(0), Integer)

        Return result

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 指定条件のAGN適用除外コード検索
    '
    ' 返り値　　: DataSet
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 指定条件のAGN適用除外コードを検索する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Public Function getEscapeCode() As DataTable

        Dim resultDatatable As DataTable
        Dim resultDatatableRow As DataRow

        '初期化
        resultDatatable = New DataTable()

        '製品IDなし
        If Me.myIdProduct.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            resultDatatable.Columns.Add("err_id")
            resultDatatableRow = resultDatatable.NewRow
            resultDatatableRow("err_id") = "-1"
            resultDatatable.Rows.Add(resultDatatableRow)
            Return resultDatatable
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ONE, AgnConst.DBTypeFlg.equals)

        MyBase.ReadSql = MyBase.GetSQL("example", "example_004")

        '検索結果
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)

        MyBase.Execute()

        resultDatatable = MyBase.ResultDataSet.Tables(0)

        Return resultDatatable

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 指定条件の更新
    '
    ' 返り値　　: 0:正常 -4:データを存在しません -2: 排他
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 納入情報添付ファイルを更新する
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Public Function updateFile() As Integer
        Dim result As Integer = 0

        '納入情報ID
        If Me.myIdPurchase.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ONE, AgnConst.DBTypeFlg.update)
        MyBase.ReadSql = MyBase.GetSQL("example", "example_001")

        '検索結果
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)
        MyBase.Execute()

        '納入情報排他判定
        If MyBase.ResultDataSet.Tables(0).Rows.Count = 0 Then
            Return AgnConst.DAReturnValue.Haita
        End If

        '製品情報ID
        If Me.myIdProduct.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_TWO, AgnConst.DBTypeFlg.update)
        MyBase.ReadSql = MyBase.GetSQL("example", "example_007")

        '検索結果
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)
        MyBase.Execute()

        '製品情報排他判定
        If MyBase.ResultDataSet.Tables(0).Rows.Count = 0 Then
            Return AgnConst.DAReturnValue.Haita
        End If

        '納入情報環境認定情報を更新
        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ZERO, AgnConst.DBTypeFlg.update)

        MyBase.UpdateSql = MyBase.GetSQL("example", "example_002")

        result = MyBase.Execute()


        Return result

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 指定条件の削除
    '
    ' 返り値　　: 0:正常 -4:データを存在しません -2: 排他
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 納入情報添付ファイルを削除する（未使用フラグを1にする）
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Public Function deleteFile() As Integer
        Dim result As Integer = 0

        '納入情報ID
        If Me.myIdPurchase.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ONE, AgnConst.DBTypeFlg.update)
        MyBase.ReadSql = MyBase.GetSQL("example", "example_001")

        '検索結果
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)
        MyBase.Execute()

        '排他判定
        If MyBase.ResultDataSet.Tables(0).Rows.Count = 0 Then
            Return AgnConst.DAReturnValue.Haita
        End If

        '納入情報削除
        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ZERO, AgnConst.DBTypeFlg.delete)

        MyBase.UpdateSql = MyBase.GetSQL("example", "example_006")

        result = MyBase.Execute()

        Return result

    End Function

    '-----------------------------------------------------------
    ' 機能　　　: 検索、更新、削除条件の作成
    '
    ' 返り値　　: なし
    '
    ' 引き数　　: flg - 条件区分　　dbType-検索、更新、削除 区分
    '
    ' 機能説明　: 検索、更新、削除条件のリストを作成します
    '
    ' 備考　　　: 
    '-----------------------------------------------------------
    Private Sub GetPara(ByVal flg As Integer, ByVal dbType As Integer)
        'データをクリア
        MyBase.ParamArrayList.Clear()

        '検索
        If dbType = AgnConst.DBTypeFlg.equals Then

            If flg = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
                '納入情報ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdPurchase, SqlDbType.Decimal))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_ONE Then
                '製品ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdProduct, SqlDbType.Decimal))


            End If
        End If

        '更新
        If dbType = AgnConst.DBTypeFlg.update Then

            If flg = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
                '環境認定フラグ
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myStaturs), SqlDbType.Int))

                'ユーザーID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, MyBase.myUserSession.UserId, SqlDbType.Decimal))

                '環境認定コメント
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myEnvironmentalApprovalComment), SqlDbType.NVarChar))

                '不含有保証書適用除外コード(ROHS)
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myNoContentCertificateEscapeCode_R), SqlDbType.NVarChar))

                '自己分析結果
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myMyAnalysisResult), SqlDbType.NVarChar))

                '認定担当者
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myCertifiedPerson), SqlDbType.NVarChar))

                '特記事項1
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myBikou1), SqlDbType.NVarChar))

                '特記事項2
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myBikou2), SqlDbType.NVarChar))

                '特記事項3
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myBikou3), SqlDbType.NVarChar))

                '不含有保証書適用除外コード(ELV)
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myNoContentCertificateEscapeCode_E), SqlDbType.NVarChar))

                '納入情報ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, Me.myIdPurchase, SqlDbType.Decimal))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_ONE Then
                '納入情報ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdPurchase, SqlDbType.Decimal))

                '更新日
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myUdDate, SqlDbType.NVarChar))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_TWO Then
                '製品情報ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdProduct, SqlDbType.Decimal))

                '更新日
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myUdDateProduct, SqlDbType.NVarChar))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_THREE Then
                '物質群情報
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myIdChemicalManagementGroup), SqlDbType.Int))

                'ユーザーID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, MyBase.myUserSession.UserId, SqlDbType.Decimal))

                '製品情報ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, Me.myIdProduct, SqlDbType.Decimal))

            End If
        End If

        '削除
        If dbType = AgnConst.DBTypeFlg.delete Then

            If flg = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
                'ユーザーID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, MyBase.myUserSession.UserId, SqlDbType.Decimal))

                '納入情報ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, Me.myIdPurchase, SqlDbType.Decimal))
            End If
        End If

    End Sub

#End Region

End Class
