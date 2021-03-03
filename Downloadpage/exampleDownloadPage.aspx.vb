'---------------------------------------------------------------
' �@�_�E�����[�h�y�[�W�N���X
' �@��ʏ���
'---------------------------------------------------------------
Partial Class examplePage
    Inherits PageBase

#Region "�萔�錾"

    Private Const V_OUTPUT_FILE_NAME As String = "data_p.csv"                                         '�o�̓t�@�C����
    Private Const MY_NUMBER_ZERO As String = "0"
    Private Const MY_NUMBER_ONE As String = "1"
    Private Const STRUCTURE_KUBUN_PARENT As String = "parent"
    Private Const STRUCTURE_KUBUN_CHILD As String = "child"

    Private Const MY_FIELD_DIV_DISCLOSURE As String = "divDisclosure"                                 '�����J�敪
    Private Const MY_FIELD_CD_SALES_COMPANY As String = "cdSalesCompany"                              '������ЃR�[�h
    Private Const MY_FIELD_NA_SALES_COMPANY As String = "naSalesCompany"                              '������Ж�
    Private Const MY_FIELD_CD_SALES_OFFICE As String = "cdSalesOffice"                                '����掖�Ə��R�[�h
    Private Const MY_FIELD_NA_SALES_OFFICE As String = "naSalesOffice"                                '����掖�Ə���
    Private Const MY_FIELD_CD_PRODUCTING_COMPANY As String = "cdProductingCompany"                    '������ЃR�[�h
    Private Const MY_FIELD_NA_PRODUCTING_COMPANY As String = "naProductingCompany"                    '������Ж�
    Private Const MY_FIELD_NA_PRODUCTING_COMPANY_OTHER As String = "naProductingCompanyOther"         '������Ж�
    Private Const MY_FIELD_NA_POST As String = "naPost"                                               '������Е�����
    Private Const MY_FIELD_NA_PERSON_CHARGE As String = "naPersonCharge"                              '������ВS����
    Private Const MY_FIELD_TEL_PRODUCTING_COMPANY As String = "telProductingCompany"                  '������ВS����TEL
    Private Const MY_FIELD_EMAIL_PRODUCTING_COMPANY As String = "emailProductingCompany"              '������ВS����E-mail
    Private Const MY_FIELD_NA_PRODUCT_EN As String = "naProductEn"                                    'Product name
    Private Const MY_FIELD_NA_PRODUCT As String = "naProduct"                                         '���i��
    Private Const MY_FIELD_NA_SERIES_EN As String = "naSeriesEn"                                      'Series name
    Private Const MY_FIELD_NA_SERIES As String = "naSeries"                                           '�V���[�Y��
    Private Const MY_FIELD_CD_PRODUCT As String = "cdProduct"                                         '���i�ԍ�
    Private Const MY_FIELD_AMOUNT_PRODUCT As String = "amountProduct"                                 '�����P�ʎ���
    Private Const MY_FIELD_CD_UNIT_PRODUCT As String = "cdUnitProduct"                                '�����P��
    Private Const MY_FIELD_MASS_PRODUCT As String = "massProduct"                                     '���i����
    Private Const MY_FIELD_CD_PRODUCT_UNIT_MASS As String = "cdProductUnitMass"                       '�P��
    Private Const MY_FIELD_DIV_SPEC As String = "divSpec"                                             '���i�d�l�敪
    Private Const MY_FIELD_MAKER_DATA_VERSION As String = "makerDataVersion"                          'Maker Data Ver.
    Private Const MY_FIELD_VALIDITY_TERM As String = "validityTerm"                                   '�K�p���t

    Private Const MY_FIELD_CD_PARENT_SALES_COMPANY As String = "cdParentSalesCompany"                 '�e���i�������CD
    Private Const MY_FIELD_CD_PARENT_PRODUCT As String = "cdParentProduct"                            '�e���i�ԍ�
    Private Const MY_FIELD_CD_CHILD_SALES_COMPANY As String = "cdChildSalesCompany"                   '�q���i�������CD
    Private Const MY_FIELD_CD_CHILD_PRODUCT As String = "cdChildProduct"                              '�q���i�ԍ�
    Private Const MY_FIELD_NA_CHILD_PRODUCT As String = "naChildProduct"                              '���i��
    Private Const MY_FIELD_ASSEMBLY_ORDER As String = "assemblyOrder"                                 '�����ԍ�
    Private Const MY_FIELD_NUMBER_PRODUCT As String = "numberProduct"                                 '����
    Private Const MY_FIELD_AMOUNT_PRODUCT_STRUCTURE As String = "amountProductStructure"              '�����P�ʎ���
    Private Const MY_FIELD_CD_UNIT_PRODUCT_STRUCTURE As String = "cdUnitProductStructure"             '�����P��
    Private Const MY_FIELD_MASS_PRODUCT_STRUCTURE As String = "massProductStructure"                  '���i����
    Private Const MY_FIELD_CD_PRODUCT_UNIT_MASS_STRUCTURE As String = "cdProductUnitMassStructure"    '�P��
    Private Const MY_FIELD_FLG_CONFIDENTIAL As String = "flgConfidential"                             '�c�Ɣ閧

    Private Const MY_FIELD_ALIAS_MATERIAL As String = "aliasMaterial"                                 '�ޗ���
    Private Const MY_FIELD_CD_MATERIAL As String = "cdMaterial"                                       '�ޗ��\���R�[�h
    Private Const MY_FIELD_NA_MATERIAL As String = "naMaterial"                                       '�ޗ��\����
    Private Const MY_FIELD_MASS_MATERIAL As String = "massMaterial"                                   '���ʁE��
    Private Const MY_FIELD_CD_MATERIAL_UNIT As String = "cdMaterialUnit"                              '�P��
    Private Const MY_FIELD_PART_MATERIAL As String = "partMaterial"                                   '����

    Private Const MY_FIELD_CAS_NO As String = "casNo"                                                 'CAS_NO
    Private Const MY_FIELD_SUBSTITUTION_CAS_NO As String = "substitutionCasNo"                        'CAS_NO���
    Private Const MY_FIELD_MASS_CHEMICAL As String = "massChemical"                                   '�ܗL�ʁE��
    Private Const MY_FIELD_CD_CHEMICAL_UNIT As String = "cdChemicalUnit"                              '�P��
    Private Const MY_FIELD_USAGE_AREA As String = "usageArea"                                         '�p�r

    Private Const MY_FIELD_ID_PRODUCT As String = "idProduct"                                         '���iID
    Private Const MY_FIELD_ID_PRODUCT_MATERIAL As String = "idProductMaterial"                        '���i�ޗ��\��ID
    Private Const MY_FIELD_ID_PRODUCT_CHEMICAL As String = "idProductChemical"                        '���i�ܗL���w����ID

    Private Const MY_FIELD_C_UID As String = "cUid"                                                   '�����o�^��
    Private Const MY_FIELD_C_DATE As String = "cDate"                                                 '�����o�^��
    Private Const MY_FIELD_U_UID As String = "udUid"                                                  '�ŏI�X�V��
    Private Const MY_FIELD_U_DATE As String = "udDate"                                                '�ŏI�X�V��

    Private Const MY_FIELD_S_C_UID As String = "scUid"                                                   '�����o�^��
    Private Const MY_FIELD_S_C_DATE As String = "scDate"                                                 '�����o�^��
    Private Const MY_FIELD_S_U_UID As String = "sudUid"                                                  '�ŏI�X�V��
    Private Const MY_FIELD_S_U_DATE As String = "sudDate"                                                '�ŏI�X�V��
#End Region

#Region "�ϐ��錾"

    Private myLogic As exampleLogic
    Private myRequet As exampleRequest = New exampleRequest           '���͈���
    Private myResponse As exampleResponse = New exampleResponse       '�o�͈���
    Private myLanID As String                                       '����R�[�h
    Private myOutList As ArrayList = New ArrayList

#End Region

#Region " Web �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    '���̌Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    '���� : ���̃v���[�X�z���_�錾�� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    '�폜����шړ����Ȃ��ł��������B
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: ���̃��\�b�h�Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
        InitializeComponent()
    End Sub

#End Region

#Region "��������"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            '�o�͂���f�[�^���������܂�
            SearchData(MyBase.pageDataSet)
        End If
    End Sub

#End Region

#Region "���������֘A"

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �o�͂���f�[�^���������āA�o�͂��܂�
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: ds - DataSet
    '
    ' �@�\�����@:
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Protected Overrides Sub SearchData(ByRef ds As DataSet)

        Dim ret As Integer

        '�u�������������v�̏o��
        AgnLog.Operation(MyBase.userSession, "������������")

        Me.myLogic = New exampleLogic(MyBase.userSession)
        Me.myRequet = New exampleRequest

        Dim tempStr As String = CStr(IIf(MyBase.GetParameter("d_hd_list") Is Nothing, "", MyBase.GetParameter("d_hd_list")))

        If Not "".Equals(tempStr) Then
            Me.myRequet.PcArray = Strings.Split(tempStr, ",")
        End If

        '���������̍쐬����
        Me.GetSearchPara()

        '��������
        ret = Me.myLogic.Execute(exampleLogic.FUNC_READ, CType(Me.myRequet, DTOBase), CType(Me.myResponse, DTOBase))

        If ret >= 0 Then
            If Me.myResponse.ErrFlag = 0 Then

                ds = myResponse.ProductInfMaterialDataSet

                'CSV�t�@�C�����o�͂���
                Me.OutputCsv(V_OUTPUT_FILE_NAME)

            Else
                '�����G���[
                MyBase.SetException(Me.myResponse)
            End If
        Else
            '�ُ폈����ݒ�
            MyBase.SetException(Me.myResponse)
        End If
    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �����̍쐬����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �X�V�̏ꍇ�A�������쐬���܂�
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Sub GetSearchPara()

        Dim strIdProduct As String
        Dim delimStr As String = ","
        Dim delimiter As Char() = delimStr.ToCharArray()
        Dim splitIdProduct As String() = Nothing
        Dim strTmp As String

        '���iID
        strIdProduct = MyBase.GetParameter("d_hd_id_product")
        If Not "".Equals(strIdProduct) Then
            splitIdProduct = strIdProduct.Split(delimiter)
            For Each strIdProduct In splitIdProduct
                '�`�F�b�N���͍���
                If Not AgnUtil.CheckDataValue(strIdProduct, AgnConst.NUM_WORD, 19, False) Then
                    Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
                End If
                Me.myRequet.IdProduct.Add(strIdProduct)
            Next strIdProduct
        End If
        '�������CD
        strTmp = MyBase.GetParameter("cdSalesCompany")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdSalesCompany = strTmp
        End If
        '���i�ԍ�
        strTmp = MyBase.GetParameter("cdProduct")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, "", 128, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdProduct = strTmp
        End If
        '���i��
        strTmp = MyBase.GetParameter("naProduct")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, "", 256, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaProduct = strTmp
        End If
        '�������CD
        strTmp = MyBase.GetParameter("cdProductingOffice")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdProductingOffice = strTmp
        End If
        '�����Ώۃf�[�^
        strTmp = MyBase.GetParameter("divSearchTarget")
        If Not examplePage.MY_NUMBER_ZERO.Equals(strTmp) And Not examplePage.MY_NUMBER_ONE.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.DivSearchTarget = CType(strTmp, Integer)
        '�f�[�^�t�H�[�}�b�g
        strTmp = MyBase.GetParameter("divFormat")
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 2, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.DivFormat = strTmp
        End If

        '�V���[�Y��
        strTmp = MyBase.GetParameter("naSeries")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, "", 128, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaSeries = strTmp
        End If
        '�ܗLCAS�ԍ�
        strTmp = MyBase.GetParameter("casNoChem")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUMCHARACTOR_WORD, 12, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CasNoChem = strTmp
        End If
        '�ܗL������
        strTmp = MyBase.GetParameter("naProductChem")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, "", 256, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaProductChem = strTmp
        End If
        '�����Q
        strTmp = MyBase.GetParameter("cdChemGroup")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, "", AgnConst.CD_CHEM_GROUP_MAXLENGTH, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdChemGroup = strTmp
        End If
        '�I���`�F�b�N�{�b�N�X
        strTmp = MyBase.GetParameter("slctChkBox")
        If Not examplePage.MY_NUMBER_ONE.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.SlctChkBox = CType(strTmp, Integer)


        '�ŏI�X�V��(FROM)
        strTmp = MyBase.GetParameter("updateFrom")
        If Not "".Equals(strTmp) Then
            If Not IsDate(strTmp) Then
                Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
            End If

            Me.myRequet.UpdateFrom = strTmp
        End If

        '�ŏI�X�V��(TO)
        strTmp = MyBase.GetParameter("updateTo")
        If Not "".Equals(strTmp) Then
            If Not IsDate(strTmp) Then
                Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
            End If

            Me.myRequet.UpdateTo = strTmp
        End If

        '�[������CD
        strTmp = MyBase.GetParameter("cdPurchaseCompany")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdPurchaseCompany = strTmp
        End If

        '�[���掖�Ə�CD
        strTmp = MyBase.GetParameter("cdPurchaseOffice")
        '�`�F�b�N���͍���
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUM_WORD, 10, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.CdPurchaseOffice = strTmp
        End If

        '�[����}��
        strTmp = MyBase.GetParameter("designNumber")
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUMCHARACTOR_WORD, 32, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.DesignNumber = strTmp
        End If

        '�[����i��
        strTmp = MyBase.GetParameter("productNumber")
        If Not AgnUtil.CheckDataValue(strTmp, AgnConst.ENNUMCHARACTOR_WORD, 32, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.ProductNumber = strTmp
        End If

        '�[����i��
        strTmp = MyBase.GetParameter("naPurchaseProduct")
        If Not AgnUtil.CheckDataValue(strTmp, "", 256, False) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        strTmp = strTmp.Trim
        If Not "".Equals(strTmp) Then
            Me.myRequet.NaPurchaseProduct = strTmp
        End If

        '���j���[�t���O
        strTmp = MyBase.GetParameter("menuFlag")
        If Not AgnConst.PURCHASE_MENU.Equals(strTmp) And Not AgnConst.SALES_MENU.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.MenuFlag = strTmp
        '�[��������t���O
        strTmp = MyBase.GetParameter("purchaseFlg")
        If Not examplePage.MY_NUMBER_ZERO.Equals(strTmp) And Not examplePage.MY_NUMBER_ONE.Equals(strTmp) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        Me.myRequet.PurchaseFlg = strTmp

    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �o�̓f�[�^�쐬
    '
    ' �Ԃ�l�@�@: True�@����
    '       �@�@: fasle ���s
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �o�̓f�[�^�쐬
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Public Overrides Sub WriteCsvFile()

        Dim i As Integer
        Dim intRowCnt As Integer
        Dim strTmp As String

        Dim idProductOld As Decimal              '���iID
        Dim cdParentSalesCompanyOld As String    '�e���i�������CD
        Dim cdParentProductOld As String         '�e���i�ԍ�
        Dim cdChildSalesCompanyOld As String     '�q���i�������CD
        Dim cdChildProductOld As String          '�q���i�ԍ�
        Dim assemblyOrderOld As String           '�����ԍ�
        Dim idProductMaterialOld As Decimal      '���i�ޗ��\��ID
        Dim idProductChemicalOld As Decimal      '���i�ܗL���w����ID

        Dim idProductNew As Decimal              '���iID
        Dim cdParentSalesCompanyNew As String    '�e���i�������CD
        Dim cdParentProductNew As String         '�e���i�ԍ�
        Dim cdChildSalesCompanyNew As String     '�q���i�������CD
        Dim cdChildProductNew As String          '�q���i�ԍ�
        Dim assemblyOrderNew As String           '�����ԍ�
        Dim idProductMaterialNew As Decimal      '���i�ޗ��\��ID
        Dim idProductChemicalNew As Decimal      '���i�ܗL���w����ID

        '����R�[�h
        Me.myLanID = MyBase.userSession.LanguageId

        intRowCnt = myResponse.ProductInfMaterialDataSet.Tables(0).Rows.Count

        Me.myOutList.Add(Me.MakeBase1())
        Me.myOutList.Add(Me.MakeBase2())
        '���i��{���
        strTmp = Me.MakeProduct(0)
        MakeArrayList(strTmp, Me.myOutList)
        '�\���i���s
        strTmp = Me.MakeProductStruct(0)
        MakeArrayList(strTmp, Me.myOutList)
        '�ޗ��\�����
        strTmp = Me.MakeProductMaterial(0)
        MakeArrayList(strTmp, Me.myOutList)
        '���w�������
        strTmp = Me.MakeProductChemical(0)
        MakeArrayList(strTmp, Me.myOutList)

        '���iID
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ID_PRODUCT)
        If Not "".Equals(strTmp) Then
            idProductOld = CType(strTmp, Decimal)
        Else
            idProductOld = -1
        End If
        '�e���i�������CD
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_PARENT_SALES_COMPANY)
        If Not "".Equals(strTmp) Then
            cdParentSalesCompanyOld = CType(strTmp, String)
        Else
            cdParentSalesCompanyOld = ""
        End If
        '�e���i�ԍ�
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_PARENT_PRODUCT)
        If Not "".Equals(strTmp) Then
            cdParentProductOld = CType(strTmp, String)
        Else
            cdParentProductOld = ""
        End If
        '�q���i�������CD
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_CHILD_SALES_COMPANY)
        If Not "".Equals(strTmp) Then
            cdChildSalesCompanyOld = CType(strTmp, String)
        Else
            cdChildSalesCompanyOld = ""
        End If
        '�q���i�ԍ�
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_CD_CHILD_PRODUCT)
        If Not "".Equals(strTmp) Then
            cdChildProductOld = CType(strTmp, String)
        Else
            cdChildProductOld = ""
        End If
        '�����ԍ�
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ASSEMBLY_ORDER)
        If Not "".Equals(strTmp) Then
            assemblyOrderOld = CType(strTmp, String)
        Else
            assemblyOrderOld = ""
        End If
        '���i�ޗ��\��ID
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ID_PRODUCT_MATERIAL)
        If Not "".Equals(strTmp) Then
            idProductMaterialOld = CType(strTmp, Decimal)
        Else
            idProductMaterialOld = -1
        End If
        '���i�ܗL���w����ID
        strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, 0, MY_FIELD_ID_PRODUCT_CHEMICAL)
        If Not "".Equals(strTmp) Then
            idProductChemicalOld = CType(strTmp, Decimal)
        Else
            idProductChemicalOld = -1
        End If

        For i = 1 To intRowCnt - 1

            '���iID
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ID_PRODUCT)
            If Not "".Equals(strTmp) Then
                idProductNew = CType(strTmp, Decimal)
            Else
                idProductNew = -1
            End If
            '�e���i�������CD
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_PARENT_SALES_COMPANY)
            If Not "".Equals(strTmp) Then
                cdParentSalesCompanyNew = strTmp
            Else
                cdParentSalesCompanyNew = ""
            End If
            '�e���i�ԍ�
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_PARENT_PRODUCT)
            If Not "".Equals(strTmp) Then
                cdParentProductNew = strTmp
            Else
                cdParentProductNew = ""
            End If
            '�q���i�������CD
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_CHILD_SALES_COMPANY)
            If Not "".Equals(strTmp) Then
                cdChildSalesCompanyNew = strTmp
            Else
                cdChildSalesCompanyNew = ""
            End If
            '�q���i�ԍ�
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_CD_CHILD_PRODUCT)
            If Not "".Equals(strTmp) Then
                cdChildProductNew = strTmp
            Else
                cdChildProductNew = ""
            End If
            '�����ԍ�
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ASSEMBLY_ORDER)
            If Not "".Equals(strTmp) Then
                assemblyOrderNew = strTmp
            Else
                assemblyOrderNew = ""
            End If
            '���i�ޗ��\��ID
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ID_PRODUCT_MATERIAL)
            If Not "".Equals(strTmp) Then
                idProductMaterialNew = CType(strTmp, Decimal)
            Else
                idProductMaterialNew = -1
            End If
            '���i�ܗL���w����ID
            strTmp = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, i, MY_FIELD_ID_PRODUCT_CHEMICAL)
            If Not "".Equals(strTmp) Then
                idProductChemicalNew = CType(strTmp, Decimal)
            Else
                idProductChemicalNew = -1
            End If
            If idProductOld <> idProductNew Then
                '���i��{���
                strTmp = Me.MakeProduct(i)
                MakeArrayList(strTmp, Me.myOutList)
                '�\���i���s
                strTmp = Me.MakeProductStruct(i)
                MakeArrayList(strTmp, Me.myOutList)
                '�ޗ��\�����
                strTmp = Me.MakeProductMaterial(i)
                MakeArrayList(strTmp, Me.myOutList)
                '���w�������
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
                    '�\���i���s
                    strTmp = Me.MakeProductStruct(i)
                    MakeArrayList(strTmp, Me.myOutList)
                    '�ޗ��\�����
                    strTmp = Me.MakeProductMaterial(i)
                    MakeArrayList(strTmp, Me.myOutList)
                    '���w�������
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
                        '�ޗ��\�����
                        strTmp = Me.MakeProductMaterial(i)
                        MakeArrayList(strTmp, Me.myOutList)
                        '���w�������
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
                            '���w�������
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
    ' �@�\�@�@�@: �o�͍s�쐬����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: strRow�@- �s���
    '            lstRow - �o�̓��X�g
    '
    ' �@�\�����@: �o�͍s�쐬����
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Sub MakeArrayList(ByVal strRow As String, ByRef lstRow As ArrayList)

        If Not "".Equals(Trim(strRow)) Then
            lstRow.Add(strRow)
        End If

    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ��{���s�P���쐬
    '
    ' �Ԃ�l�@�@: ��{���s�P������
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@:�@��{���s�P���쐬
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Function MakeBase1() As String

        Dim sbdIN As System.Text.StringBuilder

        sbdIN = New System.Text.StringBuilder("")

        '�s�R�[�h
        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code1", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�V�X�e���o�[�W����
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_VERSION)
        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage("version_no_of_data_p"))
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�t�@�C�����
        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_file_type", Me.myLanID))
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        sbdIN.Append(AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        If "1".Equals(MyBase.userSession.GgIdeFlg) Then
            'G&G���ʃt���O
            sbdIN.Append(MyBase.userSession.GgIdeFlg)
        Else
            'G&G���ʃt���O
            sbdIN.Append("")
        End If

        Return sbdIN.ToString

    End Function
    '-----------------------------------------------------------
    ' �@�\�@�@�@: ��{���s�Q���쐬
    '
    ' �Ԃ�l�@�@: ��{���s�Q������
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: ��{���s�Q���쐬
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Function MakeBase2() As String

        Dim sbdIN As System.Text.StringBuilder

        sbdIN = New System.Text.StringBuilder("")

        sbdIN.Append(PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code2", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)    '�s�R�[�h
        sbdIN.Append(Me.myLanID)                                                                                                             '����R�[�h

        Return sbdIN.ToString

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ���i��{���s��������쐬
    '
    ' �Ԃ�l�@�@: ���i��{���s������
    '
    ' �������@�@: intLineNum - �s�ԍ�
    '
    ' �@�\�����@:
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Function MakeProduct(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String
        Dim strCdProductCompany As String
        Dim strCdProductCompanyOther As String
        Dim lang As Language = Language.GetLanguage()
        sbdIN = New System.Text.StringBuilder("")

        '�����J�敪
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_DIV_DISCLOSURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '������ЃR�[�h
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_SALES_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '������Ж�
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SALES_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '����掖�Ə��R�[�h
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_SALES_OFFICE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '����掖�Ə���
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SALES_OFFICE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '������ЃR�[�h
        strCdProductCompany = AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCTING_COMPANY)
        sbdIN.Append(strCdProductCompany & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '������Ж�
        strCdProductCompanyOther = lang.GetCtrlLanguage(AgnConst.SONOTACOMPANYCODE)
        If strCdProductCompanyOther.Equals(strCdProductCompany) Then
            sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCTING_COMPANY_OTHER) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        Else
            sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCTING_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        End If
        '������Е�����
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_POST) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '������ВS����
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PERSON_CHARGE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '������ВS����TEL
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_TEL_PRODUCTING_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '������ВS����E-mail
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_EMAIL_PRODUCTING_COMPANY) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'Product name
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCT_EN) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '���i��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'Series name
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SERIES_EN) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�V���[�Y��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_SERIES) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '���i�ԍ�
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����P�ʎ���
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_AMOUNT_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����P��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_UNIT_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '���i����
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�P��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCT_UNIT_MASS) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '���i�d�l�敪
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_DIV_SPEC) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'Maker Data Ver.
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MAKER_DATA_VERSION) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�K�p���t
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_VALIDITY_TERM) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����o�^��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_C_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����o�^��
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_C_DATE), MyBase.userSession.LanguageId) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�ŏI�X�V��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_U_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�ŏI�X�V��
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_U_DATE), MyBase.userSession.LanguageId))

        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '�s�R�[�h
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code3", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �\���i���s�̕�������쐬
    '
    ' �Ԃ�l�@�@: �[�����s�̕�����
    '
    ' �������@�@: intLineNum - �s�ԍ�
    '
    ' �@�\�����@: �\���i���s�̕�������쐬
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Function MakeProductStruct(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String

        sbdIN = New System.Text.StringBuilder("")

        '���i�ԍ�
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_CHILD_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '���i��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_CHILD_PRODUCT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����ԍ�
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_ASSEMBLY_ORDER) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '����
        sbdIN.Append(AgnUtil.ZeroSuppressEnd(
                     AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NUMBER_PRODUCT)) _
                    & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����P�ʎ���
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_AMOUNT_PRODUCT_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����P��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_UNIT_PRODUCT_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�\���i����
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_PRODUCT_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�P��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_PRODUCT_UNIT_MASS_STRUCTURE) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�c�Ɣ閧
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_FLG_CONFIDENTIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����o�^��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_C_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�����o�^��
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_C_DATE), MyBase.userSession.LanguageId) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�ŏI�X�V��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_U_UID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�ŏI�X�V��
        sbdIN.Append(AgnUtil.EditDateByLanguage(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_S_U_DATE), MyBase.userSession.LanguageId))
        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '�s�R�[�h
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code4", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �ޗ��\�����s��������쐬
    '
    ' �Ԃ�l�@�@: �ޗ��\�����s������
    '
    ' �������@�@: intLineNum - �s�ԍ�
    '
    ' �@�\�����@:
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Function MakeProductMaterial(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String

        sbdIN = New System.Text.StringBuilder("")

        '�ޗ���
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_ALIAS_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�ޗ��\���R�[�h
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�ޗ��\����
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_NA_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '���ʁE��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_MATERIAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�P��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_MATERIAL_UNIT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '����
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_PART_MATERIAL))

        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '�s�R�[�h
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code5", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �ܗL���w�������s��������쐬
    '
    ' �Ԃ�l�@�@: �ܗL���w�������s������
    '
    ' �������@�@: intLineNum - �s�ԍ�
    '
    ' �@�\�����@:
    '
    ' ���l�@�@�@:
    '-----------------------------------------------------------
    Private Function MakeProductChemical(ByVal intLineNum As Integer) As String

        Dim sbdIN As System.Text.StringBuilder
        Dim strRet As String

        sbdIN = New System.Text.StringBuilder("")

        'CAS_NO
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CAS_NO) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        'CAS_NO���
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_SUBSTITUTION_CAS_NO) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�ܗL�ʁE��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_MASS_CHEMICAL) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�P��
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_CD_CHEMICAL_UNIT) & AgnConst.FILE_DOWNLOAD_SPLITCHAR)
        '�p�r
        sbdIN.Append(AgnUtil.GetDataFromDataSet(myResponse.ProductInfMaterialDataSet, intLineNum, MY_FIELD_USAGE_AREA))

        strRet = sbdIN.ToString
        strRet = strRet.Replace(AgnConst.FILE_DOWNLOAD_SPLITCHAR, "")
        If "".Equals(Trim(strRet)) Then
            strRet = ""
        Else
            '�s�R�[�h
            strRet = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, "s_lbl_line_code6", Me.myLanID) & AgnConst.FILE_DOWNLOAD_SPLITCHAR & sbdIN.ToString
        End If

        Return strRet

    End Function

#End Region

End Class
