#Region "納入情報環境認定の検索リクエストオブジェクト"
'---------------------------------------------------------------
' 　example - 納入情報環境認定登録リクエスト
' 　入力引数
'---------------------------------------------------------------
Public Class exampleSearchRequest
    Inherits DTOBase

    Private myGamenFlg As Integer                           '画面フラグ
    Private myIdProduct As Decimal                          '製品ID
    Private myIdBuyerRequestInvProduct As Decimal           '調達者調査依頼製品ID
    Private myIdPurchase As Decimal                         '納入情報ID
    Private myEnteringFlag As String                        '入力完了フラグ　　"0":入力中　　　"1" :入力完了
    '-----------------------------------------------------------
    '[Name     ] 納入情報ID
    '-----------------------------------------------------------
    Public Property IdPurchase() As Decimal
        Get
            Return Me.myIdPurchase
        End Get
        Set(ByVal Value As Decimal)
            Me.myIdPurchase = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 製品ID
    '-----------------------------------------------------------
    Public Property IdProduct() As Decimal
        Get
            Return Me.myIdProduct
        End Get
        Set(ByVal Value As Decimal)
            Me.myIdProduct = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 調達者調査依頼製品ID
    '-----------------------------------------------------------
    Public Property IdBuyerRequestInvProduct() As Decimal
        Get
            Return Me.myIdBuyerRequestInvProduct
        End Get
        Set(ByVal Value As Decimal)
            Me.myIdBuyerRequestInvProduct = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 画面フラグ
    '-----------------------------------------------------------
    Public Property GamenFlg() As Integer
        Get
            Return Me.myGamenFlg
        End Get
        Set(ByVal Value As Integer)
            Me.myGamenFlg = Value
        End Set
    End Property
    '-----------------------------------------------------------
    '[Name     ] 入力完了フラグ
    '-----------------------------------------------------------
    Public Property EnteringFlag() As String
        Get
            Return Me.myEnteringFlag
        End Get
        Set(ByVal Value As String)
            Me.myEnteringFlag = Value
        End Set
    End Property
End Class

#End Region

#Region "納入情報環境認定の検索レスポンスオブジェクト"
'---------------------------------------------------------------
' @(h) All Rights Reserved , Copyright (C) 2005 , Hitachi , Ltd
' @(h) exampleDT0SearchRequest.vb ver 1.0 ( 2006.02.18 )
' @(s)
' 　example - 納入情報環境認定リクエスト
' 　入力引数
'---------------------------------------------------------------
Public Class exampleSearchResponse
    Inherits DTOBase

    Private myProductDS As New ProductDS                                    '製品情報データセット
    Private myPurchaseDS As New PurchaseDS                                  '納入情報データセット
    Private myBuyerProductDS As BuyerRequestProductDS                       '調達者調査依頼製品データセット
    Private myFileHave As Boolean                                           '添付情報
    Private myAgnEscapeCode As String                                       'AGN適用除外コード
    Private myAgnEscapeCode_E As String                                       'AGN適用除外コード
    Private myAgnEscapeCode_R As String                                       'AGN適用除外コード


    '-----------------------------------------------------------
    '[Name     ] AGN適用除外コード(ROHS)
    '-----------------------------------------------------------
    Public Property AgnEscapeCode_R() As String
        Get
            Return myAgnEscapeCode_R
        End Get
        Set(ByVal Value As String)
            myAgnEscapeCode_R = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] AGN適用除外コード(ELV)
    '-----------------------------------------------------------
    Public Property AgnEscapeCode_E() As String
        Get
            Return myAgnEscapeCode_E
        End Get
        Set(ByVal Value As String)
            myAgnEscapeCode_E = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 添付情報
    '-----------------------------------------------------------
    Public Property FileHave() As Boolean
        Get
            Return myFileHave
        End Get
        Set(ByVal Value As Boolean)
            myFileHave = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] AGN適用除外コード
    '-----------------------------------------------------------
    Public Property AgnEscapeCode() As String
        Get
            Return myAgnEscapeCode
        End Get
        Set(ByVal Value As String)
            myAgnEscapeCode = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 製品情報
    '-----------------------------------------------------------
    Public Property FrmProductDS() As ProductDS
        Get
            Return myProductDS
        End Get
        Set(ByVal Value As ProductDS)
            myProductDS = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 納入情報
    '-----------------------------------------------------------
    Public Property FrmPurchaseDS() As PurchaseDS
        Get
            Return myPurchaseDS
        End Get
        Set(ByVal Value As PurchaseDS)
            myPurchaseDS = Value
        End Set
    End Property

    '-----------------------------------------------------------
    '[Name     ] 調達者調査依頼製品
    '-----------------------------------------------------------
    Public Property FrmBuyerProductDS() As BuyerRequestProductDS
        Get
            Return myBuyerProductDS
        End Get
        Set(ByVal Value As BuyerRequestProductDS)
            myBuyerProductDS = Value
        End Set
    End Property

End Class
#End Region

#Region "納入情報環境認定登録の登録と削除（更新）リクエストオブジェクト"

'---------------------------------------------------------------
' @(h) All Rights Reserved , Copyright (C) 2005 , Hitachi , Ltd
' @(h) exampleDTO.vb ver 1.0 ( 2006.01.18)
' @(s)
' 　example - 納入情報環境認定リクエスト
' 　入力引数
'---------------------------------------------------------------
Public Class exampleRegisterRequest
    Inherits DTOBase

    Private myIdPurchase As Decimal                         '納入情報ID
    Private myStaturs As Integer                           '登録区分フラグ
    Private myUdDate As String                             '納入情報排他判定用更新日
    Private myUdDateProduct As String                      '製品情報排他判定用更新日
    Private myIdChemicalManagementGroup As String         '調査物質群
    Private myEnvironmentalApprovalComment As String       '環境認定コメント
    Private myNoContentCertificateEscapeCode As String     '不含有保証書適用除外コード
    Private myMyAnalysisResult As String                   '自己分析結果
    Private myCertifiedPerson As String                    '認定担当者
    Private myBikou1 As String                             '特記事項1
    Private myBikou2 As String                             '特記事項2
    Private myBikou3 As String                             '特記事項3
    Private myIdProduct As Decimal                         '製品情報ID
    Private myNoContentCertificateEscapeCode_E As String     '不含有保証書適用除外コード
    Private myNoContentCertificateEscapeCode_R As String     '不含有保証書適用除外コード


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
    '[Name     ] 製品情報ID
    '-----------------------------------------------------------
    Public Property IdProduct() As Decimal
        Get
            Return myIdProduct
        End Get
        Set(ByVal Value As Decimal)
            myIdProduct = Value
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
    '[Name     ] 不含有保証書適用除外コード
    '-----------------------------------------------------------
    Public Property NoContentCertificateEscapeCode() As String
        Get
            Return myNoContentCertificateEscapeCode
        End Get
        Set(ByVal Value As String)
            myNoContentCertificateEscapeCode = Value
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
    '[Name     ] 調査物質群
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
    '[Name     ] 納入情報ID
    '-----------------------------------------------------------
    Public Property IdPurchase() As Decimal
        Get
            Return myIdPurchase
        End Get
        Set(ByVal Value As Decimal)
            myIdPurchase = Value
        End Set
    End Property


    '-----------------------------------------------------------
    '[Name     ] 納入情報環境認定フラグ
    '-----------------------------------------------------------
    Public Property Staturs() As Integer
        Get
            Return myStaturs
        End Get
        Set(ByVal Value As Integer)
            myStaturs = Value
        End Set
    End Property
End Class
#End Region

#Region "納入情報環境認定登録の登録と削除（更新）レスポンスオブジェクト"

'---------------------------------------------------------------
' 　example -  納入情報環境認定レスポンスオブジェクト
' 　出力引数
'---------------------------------------------------------------
Public Class exampleRegisterResponse
    Inherits DTOBase
End Class
#End Region