'---------------------------------------------------------------
' �@�[�����t�@�C���Y�t�N���X


Imports System.Data.SqlClient

Public Class exampleDA
    Inherits DABase

#Region "�ϐ��錾"
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

#Region "������"

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �R���X�g���N�^
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: ���[�U�Z�b�V����
    '
    ' �@�\�����@: �Y���N���X�̃R���X�g���N�^���\�b�h
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Sub New(ByVal userSession As UserSession)
        MyBase.New(userSession)
    End Sub

#End Region

#Region "��{����"
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
    '[Name     ] ���������Q���
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
    '[Name     ] ���F��t���O
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
    '[Name     ] �[�����ID
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
    '[Name     ] ���iID
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

#Region "���s�����֘A"
    '-----------------------------------------------------------
    ' �@�\�@�@�@: �v���p�e�B���f�t�H�[���g�l�ŃZ�b�g
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �v���p�e�B���f�t�H�[���g�l�ŃZ�b�g
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Public Sub Clear()
        Me.myIdPurchase = AgnConst.DEFAULT_VALUE_STRING
        Me.myStaturs = AgnConst.DEFAULT_VALUE_INTEGER_ZERO
    End Sub
    '-----------------------------------------------------------
    ' �@�\�@�@�@: �w������̌���
    '
    ' �Ԃ�l�@�@: 0:���� -4:�f�[�^�𑶍݂��܂��� -2: �r��
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �[�������F��̓Y�t����������������
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Public Function fileInfo() As Integer
        Dim result As Integer

        '�[�����ID
        If Me.myIdPurchase.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ZERO, AgnConst.DBTypeFlg.equals)

        MyBase.ReadSql = MyBase.GetSQL("example", "example_003")

        '��������
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)

        MyBase.Execute()

        result = CType(MyBase.ResultDataSet.Tables(0).Rows(0).Item(0), Integer)

        Return result

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �w�������AGN�K�p���O�R�[�h����
    '
    ' �Ԃ�l�@�@: DataSet
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �w�������AGN�K�p���O�R�[�h����������
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Public Function getEscapeCode() As DataTable

        Dim resultDatatable As DataTable
        Dim resultDatatableRow As DataRow

        '������
        resultDatatable = New DataTable()

        '���iID�Ȃ�
        If Me.myIdProduct.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            resultDatatable.Columns.Add("err_id")
            resultDatatableRow = resultDatatable.NewRow
            resultDatatableRow("err_id") = "-1"
            resultDatatable.Rows.Add(resultDatatableRow)
            Return resultDatatable
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ONE, AgnConst.DBTypeFlg.equals)

        MyBase.ReadSql = MyBase.GetSQL("example", "example_004")

        '��������
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)

        MyBase.Execute()

        resultDatatable = MyBase.ResultDataSet.Tables(0)

        Return resultDatatable

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �w������̍X�V
    '
    ' �Ԃ�l�@�@: 0:���� -4:�f�[�^�𑶍݂��܂��� -2: �r��
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �[�����Y�t�t�@�C�����X�V����
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Public Function updateFile() As Integer
        Dim result As Integer = 0

        '�[�����ID
        If Me.myIdPurchase.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ONE, AgnConst.DBTypeFlg.update)
        MyBase.ReadSql = MyBase.GetSQL("example", "example_001")

        '��������
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)
        MyBase.Execute()

        '�[�����r������
        If MyBase.ResultDataSet.Tables(0).Rows.Count = 0 Then
            Return AgnConst.DAReturnValue.Haita
        End If

        '���i���ID
        If Me.myIdProduct.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_TWO, AgnConst.DBTypeFlg.update)
        MyBase.ReadSql = MyBase.GetSQL("example", "example_007")

        '��������
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)
        MyBase.Execute()

        '���i���r������
        If MyBase.ResultDataSet.Tables(0).Rows.Count = 0 Then
            Return AgnConst.DAReturnValue.Haita
        End If

        '�[�������F������X�V
        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ZERO, AgnConst.DBTypeFlg.update)

        MyBase.UpdateSql = MyBase.GetSQL("example", "example_002")

        result = MyBase.Execute()


        Return result

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �w������̍폜
    '
    ' �Ԃ�l�@�@: 0:���� -4:�f�[�^�𑶍݂��܂��� -2: �r��
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �[�����Y�t�t�@�C�����폜����i���g�p�t���O��1�ɂ���j
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Public Function deleteFile() As Integer
        Dim result As Integer = 0

        '�[�����ID
        If Me.myIdPurchase.Equals(AgnConst.DEFAULT_VALUE_STRING) Then
            Return AgnConst.DAReturnValue.NoInput
        End If

        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ONE, AgnConst.DBTypeFlg.update)
        MyBase.ReadSql = MyBase.GetSQL("example", "example_001")

        '��������
        MyBase.ResultDataSet = New DataSet
        MyBase.ResultDataSet.Tables.Add(New DataTable)
        MyBase.Execute()

        '�r������
        If MyBase.ResultDataSet.Tables(0).Rows.Count = 0 Then
            Return AgnConst.DAReturnValue.Haita
        End If

        '�[�����폜
        Me.GetPara(AgnConst.DEFAULT_VALUE_INTEGER_ZERO, AgnConst.DBTypeFlg.delete)

        MyBase.UpdateSql = MyBase.GetSQL("example", "example_006")

        result = MyBase.Execute()

        Return result

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �����A�X�V�A�폜�����̍쐬
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: flg - �����敪�@�@dbType-�����A�X�V�A�폜 �敪
    '
    ' �@�\�����@: �����A�X�V�A�폜�����̃��X�g���쐬���܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub GetPara(ByVal flg As Integer, ByVal dbType As Integer)
        '�f�[�^���N���A
        MyBase.ParamArrayList.Clear()

        '����
        If dbType = AgnConst.DBTypeFlg.equals Then

            If flg = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
                '�[�����ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdPurchase, SqlDbType.Decimal))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_ONE Then
                '���iID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdProduct, SqlDbType.Decimal))


            End If
        End If

        '�X�V
        If dbType = AgnConst.DBTypeFlg.update Then

            If flg = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
                '���F��t���O
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myStaturs), SqlDbType.Int))

                '���[�U�[ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, MyBase.myUserSession.UserId, SqlDbType.Decimal))

                '���F��R�����g
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myEnvironmentalApprovalComment), SqlDbType.NVarChar))

                '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myNoContentCertificateEscapeCode_R), SqlDbType.NVarChar))

                '���ȕ��͌���
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myMyAnalysisResult), SqlDbType.NVarChar))

                '�F��S����
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myCertifiedPerson), SqlDbType.NVarChar))

                '���L����1
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myBikou1), SqlDbType.NVarChar))

                '���L����2
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myBikou2), SqlDbType.NVarChar))

                '���L����3
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myBikou3), SqlDbType.NVarChar))

                '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myNoContentCertificateEscapeCode_E), SqlDbType.NVarChar))

                '�[�����ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, Me.myIdPurchase, SqlDbType.Decimal))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_ONE Then
                '�[�����ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdPurchase, SqlDbType.Decimal))

                '�X�V��
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myUdDate, SqlDbType.NVarChar))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_TWO Then
                '���i���ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myIdProduct, SqlDbType.Decimal))

                '�X�V��
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_EQUALS, Me.myUdDateProduct, SqlDbType.NVarChar))

            ElseIf flg = AgnConst.DEFAULT_VALUE_INTEGER_THREE Then
                '�����Q���
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, CStr(Me.myIdChemicalManagementGroup), SqlDbType.Int))

                '���[�U�[ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, MyBase.myUserSession.UserId, SqlDbType.Decimal))

                '���i���ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, Me.myIdProduct, SqlDbType.Decimal))

            End If
        End If

        '�폜
        If dbType = AgnConst.DBTypeFlg.delete Then

            If flg = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
                '���[�U�[ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, MyBase.myUserSession.UserId, SqlDbType.Decimal))

                '�[�����ID
                MyBase.ParamArrayList.Add(New DBParameter(DBParameter.TYPEFLG_CON_UPDATE, Me.myIdPurchase, SqlDbType.Decimal))
            End If
        End If

    End Sub

#End Region

End Class
