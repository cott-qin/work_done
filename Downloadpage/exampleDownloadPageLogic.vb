'---------------------------------------------------------------
' �@�t�@�C���_�E�����[�h���W�b�N�N���X
'---------------------------------------------------------------
Public Class exampleLogic
    Inherits DBOperator

#Region "�萔�錾"

    Public Const FUNC_READ As String = "Read"   '�����������@��

#End Region

#Region "�ϐ��錾"

    Private myexampleDA As exampleDA                   'DA���i�\���ꗗ
    Private myexampleTWDA As exampleTWDA               'DA���i�\���ꗗ
    Private myexampleDS As exampleDS = New exampleDS    '���i��{���A�ޗ��\�����A�ܗL���w�������

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
    Public Sub New(ByVal session As UserSession)

        MyBase.New(session)

    End Sub

#End Region

#Region "���ʕ��@�֘A"

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ��ʉ^�s
    '
    ' �Ԃ�l�@�@: 0:����; -3:�ُ�
    '
    ' �������@�@: funcName - �֐���
    ' �@�@�@�@�@  myRequest - ���̓f�[�^
    ' �@�@�@�@�@  myResponse - �o�͌���
    '
    ' �@�\�����@: ��ʉ^�s
    '
    ' ���l�@�@�@:
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
    ' �@�\�@�@�@: �w���������
    '
    ' �Ԃ�l�@�@: �����������R�[�h��
    '
    ' �������@�@: inData    - ���̓p�����[�^
    ' �@�@�@�@�@  outData   - �o�̓p�����[�^
    '
    ' �@�\�����@:
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Function Read(ByRef inData As exampleRequest, ByRef outData As exampleResponse) As Integer

        Dim intRet As Integer
        Dim msg As String
        Dim intDivSearchTarget As Integer

        '�����Ώۃf�[�^���擾
        intDivSearchTarget = inData.DivSearchTarget
        If intDivSearchTarget = AgnConst.DEFAULT_VALUE_INTEGER_ONE Then
            Me.myexampleDA = New exampleDA(MyBase.myUserSession)

            '�ϐ��̃N���A
            Me.myexampleDA.Clear()

            Me.GetSearchPara(inData)

            '�����擾
            intRet = myexampleDA.FdProductInfMaterialRead()
        ElseIf intDivSearchTarget = AgnConst.DEFAULT_VALUE_INTEGER_ZERO Then
            Me.myexampleTWDA = New exampleTWDA(MyBase.myUserSession)

            '�ϐ��̃N���A
            Me.myexampleTWDA.Clear()

            Me.GetSearchTWPara(inData)

            '�����擾
            intRet = myexampleTWDA.FdProductInfMaterialRead()
        End If


        If intRet = AgnConst.DAReturnValue.NoInput Then
            '�Ō����������ʂ̖߂�l��-1�̏ꍇ�A�G���[��\������B
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add("SYE0000-02")
            AgnLog.Err(MyBase.myUserSession, msg)
        ElseIf intRet = AgnConst.DAReturnValue.Normal Then
            '�����������ʂ̖߂�l��0�̏ꍇ�A�������ʂȂ��̃��b�Z�[�W��\������B
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYI0000-08")
            outData.ErrorList.Add("SYI0000-08")
            AgnLog.Err(MyBase.myUserSession, msg)
            outData.ErrFlag = 1
        ElseIf intRet = AgnConst.DAReturnValue.Haita Then
            '�����������ʂ̖߂�l��0�̏ꍇ�A�������ʂȂ��̃��b�Z�[�W��\������B
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "FDE0020-01")
            outData.ErrorList.Add("FDE0020-01")
            AgnLog.Err(MyBase.myUserSession, msg)
            outData.ErrFlag = 2
        End If

        '���R�[�h�Z�b�g
        If intDivSearchTarget = 1 Then
            outData.ProductInfMaterialDataSet = CType(myexampleDA.exampleDS, exampleDS)
        ElseIf intDivSearchTarget = 0 Then
            outData.ProductInfMaterialDataSet = CType(myexampleTWDA.exampleDS, exampleDS)
        End If

        Return intRet

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �����̍쐬����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: inData - ���i���i���i�n�j�t�@�C���_�E�����[�h���N�G�X�g�I�u�W�F�N�g
    '
    ' �@�\�����@: �X�V�̏ꍇ�A�������쐬���܂�
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Sub GetSearchPara(ByRef inData As exampleRequest)

        '���iID
        Me.myexampleDA.IdProduct = inData.IdProduct
        '����R�[�h
        Me.myexampleDA.CdLang = MyBase.myUserSession.LanguageId
        '�������CD
        Me.myexampleDA.CdSalesCompany = inData.CdSalesCompany
        '���i�ԍ�
        Me.myexampleDA.CdProduct = inData.CdProduct
        '���i��
        Me.myexampleDA.NaProduct = inData.NaProduct
        '�������CD
        Me.myexampleDA.CdProductingOffice = inData.CdProductingOffice
        '������Ж�
        Me.myexampleDA.NaProductingOffice = inData.NaProductingOffice
        '�����Ώۃf�[�^
        Me.myexampleDA.DivSearchTarget = inData.DivSearchTarget
        '���i�t�H�[�}�b�g
        Me.myexampleDA.divFormat = inData.DivFormat
        '������Ж�
        Me.myexampleDA.NaSalesCompany = inData.NaSalesCompany
        '�V���[�Y��
        Me.myexampleDA.NaSeries = inData.NaSeries
        '�ܗLCAS�ԍ�
        Me.myexampleDA.CasNoChem = inData.CasNoChem
        '�ܗL������
        Me.myexampleDA.NaProductChem = inData.NaProductChem
        '�����Q
        Me.myexampleDA.CdChemGroup = inData.CdChemGroup
        '�I���`�F�b�N�{�b�N�X
        Me.myexampleDA.SlctChkBox = inData.SlctChkBox
        '���i�ԍ�
        If Not Me.myexampleDA.CdProduct Is Nothing Then
            Me.myexampleDA.IdProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.CdProduct)
            Me.myexampleDA.CdProduct = Me.myexampleDA.CdProduct.Replace("*", "")
        End If
        '���i��
        If Not Me.myexampleDA.NaProduct Is Nothing Then
            Me.myexampleDA.IdNaProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.NaProduct)
            Me.myexampleDA.NaProduct = Me.myexampleDA.NaProduct.Replace("*", "")
        End If

        '�ŏI�X�V��(from)
        Me.myexampleDA.UpdateFrom = AgnUtil.EditParaDate(inData.UpdateFrom, MyBase.myUserSession.LanguageId, AgnConst.DEFAULT_VALUE_STRING)
        '�ŏI�X�V��(to)
        Me.myexampleDA.UpdateTo = AgnUtil.EditParaDate(inData.UpdateTo, MyBase.myUserSession.LanguageId, "less")

        '�[������CD
        Me.myexampleDA.CdPurchaseCompany = inData.CdPurchaseCompany
        '�[���掖�Ə�CD
        Me.myexampleDA.CdPurchaseOffice = inData.CdPurchaseOffice
        '�������CD
        Me.myexampleDA.CdProductingOffice = inData.CdProductingOffice
        '������Ж�
        Me.myexampleDA.NaProductingOffice = inData.NaProductingOffice
        '�[�����Ж�
        Me.myexampleDA.NaPurchaseCompany = inData.NaPurchaseCompany
        '�[���掖�Ə���
        Me.myexampleDA.NaPurchaseOffice = inData.NaPurchaseOffice
        '�[����}��
        Me.myexampleDA.DesignNumber = inData.DesignNumber
        '�[����i��
        Me.myexampleDA.ProductNumber = inData.ProductNumber
        '�[����i��
        Me.myexampleDA.NaPurchaseProduct = inData.NaPurchaseProduct
        '�[����}��
        If Not Me.myexampleDA.DesignNumber Is Nothing Then
            Me.myexampleDA.IdDesignNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.DesignNumber)
            Me.myexampleDA.DesignNumber = Me.myexampleDA.DesignNumber.Replace("*", "")
        End If
        '�[����i��
        If Not Me.myexampleDA.ProductNumber Is Nothing Then
            Me.myexampleDA.IdPoductNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.ProductNumber)
            Me.myexampleDA.ProductNumber = Me.myexampleDA.ProductNumber.Replace("*", "")
        End If
        '�[����i��
        If Not Me.myexampleDA.NaPurchaseProduct Is Nothing Then
            Me.myexampleDA.IdPurchaseProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleDA.NaPurchaseProduct)
            Me.myexampleDA.NaPurchaseProduct = Me.myexampleDA.NaPurchaseProduct.Replace("*", "")
        End If

        '���j���[�t���O
        Me.myexampleDA.MenuFlag = inData.MenuFlag
        '�[��������t���O
        Me.myexampleDA.PurchaseFlg = inData.PurchaseFlg
        '���O�C�����[�U�̉�ЃR�[�h
        Me.myexampleDA.LoginCdCompany = MyBase.myUserSession.GCompanyCd
        '���O�C�����[�U�̎������R�[�h
        Me.myexampleDA.LoginCdOffice = MyBase.myUserSession.GOfficeCd

        Me.myexampleDA.PcArray = inData.PcArray
    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �����̍쐬����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: inData - ���i���i���i�n�j�t�@�C���_�E�����[�h���N�G�X�g�I�u�W�F�N�g
    '
    ' �@�\�����@: �X�V�̏ꍇ�A�������쐬���܂�
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Sub GetSearchTWPara(ByRef inData As exampleRequest)

        '���iID
        Me.myexampleTWDA.IdProduct = inData.IdProduct
        '����R�[�h
        Me.myexampleTWDA.CdLang = MyBase.myUserSession.LanguageId
        '�������CD
        Me.myexampleTWDA.CdSalesCompany = inData.CdSalesCompany
        '���i�ԍ�
        Me.myexampleTWDA.CdProduct = inData.CdProduct
        '���i��
        Me.myexampleTWDA.NaProduct = inData.NaProduct
        '������Ж�
        Me.myexampleTWDA.NaProductingOffice = inData.NaProductingOffice
        '�����Ώۃf�[�^
        Me.myexampleTWDA.DivSearchTarget = inData.DivSearchTarget
        '���i�t�H�[�}�b�g
        Me.myexampleTWDA.divFormat = inData.DivFormat
        '������Ж�
        Me.myexampleTWDA.NaSalesCompany = inData.NaSalesCompany
        '�V���[�Y��
        Me.myexampleTWDA.NaSeries = inData.NaSeries
        '�ܗLCAS�ԍ�
        Me.myexampleTWDA.CasNoChem = inData.CasNoChem
        '�ܗL������
        Me.myexampleTWDA.NaProductChem = inData.NaProductChem
        '�����Q
        Me.myexampleTWDA.CdChemGroup = inData.CdChemGroup
        '�I���`�F�b�N�{�b�N�X
        Me.myexampleTWDA.SlctChkBox = inData.SlctChkBox
        '���i�ԍ�
        If Not Me.myexampleTWDA.CdProduct Is Nothing Then
            Me.myexampleTWDA.IdProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.CdProduct)
            Me.myexampleTWDA.CdProduct = Me.myexampleTWDA.CdProduct.Replace("*", "")
        End If
        '���i��
        If Not Me.myexampleTWDA.NaProduct Is Nothing Then
            Me.myexampleTWDA.IdNaProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.NaProduct)
            Me.myexampleTWDA.NaProduct = Me.myexampleTWDA.NaProduct.Replace("*", "")
        End If

        '�ŏI�X�V��(from)
        Me.myexampleTWDA.UpdateFrom = AgnUtil.EditParaDate(inData.UpdateFrom, MyBase.myUserSession.LanguageId, AgnConst.DEFAULT_VALUE_STRING)
        '�ŏI�X�V��(to)
        Me.myexampleTWDA.UpdateTo = AgnUtil.EditParaDate(inData.UpdateTo, MyBase.myUserSession.LanguageId, "less")

        '�[������CD
        Me.myexampleTWDA.CdPurchaseCompany = inData.CdPurchaseCompany
        '�[���掖�Ə�CD
        Me.myexampleTWDA.CdPurchaseOffice = inData.CdPurchaseOffice
        '�������CD
        Me.myexampleTWDA.CdProductingOffice = inData.CdProductingOffice
        '������Ж�
        Me.myexampleTWDA.NaProductingOffice = inData.NaProductingOffice
        '�[�����Ж�
        Me.myexampleTWDA.NaPurchaseCompany = inData.NaPurchaseCompany
        '�[���掖�Ə���
        Me.myexampleTWDA.NaPurchaseOffice = inData.NaPurchaseOffice
        '�[����}��
        Me.myexampleTWDA.DesignNumber = inData.DesignNumber
        '�[����i��
        Me.myexampleTWDA.ProductNumber = inData.ProductNumber
        '�[����i��
        Me.myexampleTWDA.NaPurchaseProduct = inData.NaPurchaseProduct
        '�[����}��
        If Not Me.myexampleTWDA.DesignNumber Is Nothing Then
            Me.myexampleTWDA.IdDesignNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.DesignNumber)
            Me.myexampleTWDA.DesignNumber = Me.myexampleTWDA.DesignNumber.Replace("*", "")
        End If
        '�[����i��
        If Not Me.myexampleTWDA.ProductNumber Is Nothing Then
            Me.myexampleTWDA.IdPoductNumberSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.ProductNumber)
            Me.myexampleTWDA.ProductNumber = Me.myexampleTWDA.ProductNumber.Replace("*", "")
        End If
        '�[����i��
        If Not Me.myexampleTWDA.NaPurchaseProduct Is Nothing Then
            Me.myexampleTWDA.IdPurchaseProductSerchCondition = Me.GetFuzzyFlag(Me.myexampleTWDA.NaPurchaseProduct)
            Me.myexampleTWDA.NaPurchaseProduct = Me.myexampleTWDA.NaPurchaseProduct.Replace("*", "")
        End If
        '���j���[�t���O
        Me.myexampleTWDA.MenuFlag = inData.MenuFlag
        '�[��������t���O
        Me.myexampleTWDA.PurchaseFlg = inData.PurchaseFlg
        '���O�C�����[�U�̉�ЃR�[�h
        Me.myexampleTWDA.LoginCdCompany = MyBase.myUserSession.GCompanyCd
        '���O�C�����[�U�̎������R�[�h
        Me.myexampleTWDA.LoginCdOffice = MyBase.myUserSession.GOfficeCd

        Me.myexampleTWDA.PcArray = inData.PcArray
    End Sub

    Private Function GetFuzzyFlag(ByVal searchStr As String) As Integer

        Dim rx1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[^\*]+\*{1}$")
        Dim rx2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^\*{1}[^\*]+$")
        Dim rx3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^\*{1}[^\*]+\*{1}$")

        If searchStr.Contains("*") Then
            If rx3.IsMatch(searchStr) Then                    '������v
                Return AgnConst.DBTypeFlg.allLike
            ElseIf rx1.IsMatch(searchStr) Then                '�O����v
                Return AgnConst.DBTypeFlg.leftLike
            ElseIf rx2.IsMatch(searchStr) Then                '�����v
                Return AgnConst.DBTypeFlg.rightLike
            End If
        ElseIf String.IsNullOrEmpty(searchStr) = False Then
            Return AgnConst.DBTypeFlg.equals     '���S��v
        Else
            Return 0
        End If
    End Function

#End Region

End Class
