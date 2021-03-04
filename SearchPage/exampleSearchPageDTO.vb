#Region "�[�������F��̌������N�G�X�g�I�u�W�F�N�g"
'---------------------------------------------------------------
' �@example - �[�������F��o�^���N�G�X�g
' �@���͈���
'---------------------------------------------------------------
Public Class exampleSearchRequest
    Inherits DTOBase

    Private myGamenFlg As Integer                           '��ʃt���O
    Private myIdProduct As Decimal                          '���iID
    Private myIdBuyerRequestInvProduct As Decimal           '���B�Ғ����˗����iID
    Private myIdPurchase As Decimal                         '�[�����ID
    Private myEnteringFlag As String                        '���͊����t���O�@�@"0":���͒��@�@�@"1" :���͊���
    '-----------------------------------------------------------
    '[Name     ] �[�����ID
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
    '[Name     ] ���iID
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
    '[Name     ] ���B�Ғ����˗����iID
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
    '[Name     ] ��ʃt���O
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
    '[Name     ] ���͊����t���O
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

#Region "�[�������F��̌������X�|���X�I�u�W�F�N�g"
'---------------------------------------------------------------
' @(h) All Rights Reserved , Copyright (C) 2005 , Hitachi , Ltd
' @(h) exampleDT0SearchRequest.vb ver 1.0 ( 2006.02.18 )
' @(s)
' �@example - �[�������F�胊�N�G�X�g
' �@���͈���
'---------------------------------------------------------------
Public Class exampleSearchResponse
    Inherits DTOBase

    Private myProductDS As New ProductDS                                    '���i���f�[�^�Z�b�g
    Private myPurchaseDS As New PurchaseDS                                  '�[�����f�[�^�Z�b�g
    Private myBuyerProductDS As BuyerRequestProductDS                       '���B�Ғ����˗����i�f�[�^�Z�b�g
    Private myFileHave As Boolean                                           '�Y�t���
    Private myAgnEscapeCode As String                                       'AGN�K�p���O�R�[�h
    Private myAgnEscapeCode_E As String                                       'AGN�K�p���O�R�[�h
    Private myAgnEscapeCode_R As String                                       'AGN�K�p���O�R�[�h


    '-----------------------------------------------------------
    '[Name     ] AGN�K�p���O�R�[�h(ROHS)
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
    '[Name     ] AGN�K�p���O�R�[�h(ELV)
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
    '[Name     ] �Y�t���
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
    '[Name     ] AGN�K�p���O�R�[�h
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
    '[Name     ] ���i���
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
    '[Name     ] �[�����
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
    '[Name     ] ���B�Ғ����˗����i
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

#Region "�[�������F��o�^�̓o�^�ƍ폜�i�X�V�j���N�G�X�g�I�u�W�F�N�g"

'---------------------------------------------------------------
' @(h) All Rights Reserved , Copyright (C) 2005 , Hitachi , Ltd
' @(h) exampleDTO.vb ver 1.0 ( 2006.01.18)
' @(s)
' �@example - �[�������F�胊�N�G�X�g
' �@���͈���
'---------------------------------------------------------------
Public Class exampleRegisterRequest
    Inherits DTOBase

    Private myIdPurchase As Decimal                         '�[�����ID
    Private myStaturs As Integer                           '�o�^�敪�t���O
    Private myUdDate As String                             '�[�����r������p�X�V��
    Private myUdDateProduct As String                      '���i���r������p�X�V��
    Private myIdChemicalManagementGroup As String         '���������Q
    Private myEnvironmentalApprovalComment As String       '���F��R�����g
    Private myNoContentCertificateEscapeCode As String     '�s�ܗL�ۏ؏��K�p���O�R�[�h
    Private myMyAnalysisResult As String                   '���ȕ��͌���
    Private myCertifiedPerson As String                    '�F��S����
    Private myBikou1 As String                             '���L����1
    Private myBikou2 As String                             '���L����2
    Private myBikou3 As String                             '���L����3
    Private myIdProduct As Decimal                         '���i���ID
    Private myNoContentCertificateEscapeCode_E As String     '�s�ܗL�ۏ؏��K�p���O�R�[�h
    Private myNoContentCertificateEscapeCode_R As String     '�s�ܗL�ۏ؏��K�p���O�R�[�h


    '-----------------------------------------------------------
    '[Name     ] �s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
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
    '[Name     ] �s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
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
    '[Name     ] ���i���ID
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
    '[Name     ] ���L����3
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
    '[Name     ] ���L����2
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
    '[Name     ] ���L����1
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
    '[Name     ] �F��S����
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
    '[Name     ] ���ȕ��͌���
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
    '[Name     ] �s�ܗL�ۏ؏��K�p���O�R�[�h
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
    '[Name     ] ���F��R�����g
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
    '[Name     ] ���������Q
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
    '[Name     ]���i���r������p�X�V��
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
    '[Name     ]�[�����r������p�X�V��
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
    '[Name     ] �[�����ID
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
    '[Name     ] �[�������F��t���O
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

#Region "�[�������F��o�^�̓o�^�ƍ폜�i�X�V�j���X�|���X�I�u�W�F�N�g"

'---------------------------------------------------------------
' �@example -  �[�������F�背�X�|���X�I�u�W�F�N�g
' �@�o�͈���
'---------------------------------------------------------------
Public Class exampleRegisterResponse
    Inherits DTOBase
End Class
#End Region