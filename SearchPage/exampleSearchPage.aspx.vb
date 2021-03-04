'---------------------------------------------------------------
' �@examplePage - �[�������F��
' �@��ʏ���
'---------------------------------------------------------------
Imports System.IO
Imports System.Data
Partial Class examplePage
    Inherits PageBase

#Region " Web �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    '���̌Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
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

    '���� : ���̃v���[�X�z���_�錾�� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    '�폜����шړ����Ȃ��ł��������B
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: ���̃��\�b�h�Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
        InitializeComponent()
    End Sub

#End Region

#Region "��ʕϐ��錾"

    Private myPageFlg As Integer                                            '��ʕ\���t���O
    Private myLogic As exampleLogic                                          'Logic�̐錾
    Private mySearchInData As New exampleSearchRequest                       '��ʌ������̓f�[�^
    Private mySearchOutData As New exampleSearchResponse                     '��ʌ������ʂ�߂�
    Private myRegisterInData As New exampleRegisterRequest                   '��ʃf�[�^�o�^����
    Private myRegisterOutData As New exampleRegisterResponse                 '��ʃf�[�^�o�^���ʏo��
    Private vsProductDS As New ProductDS
    Private vsPurchaseDS As New PurchaseDS
    Private vsBuyerProductDS As New BuyerRequestProductDS
    Private mySelectData As Byte()
    Private myDataList As ArrayList

    '�J�ڐ��ʃt���O
    Private PAGE_TYPE As GR0150Logic.PAGE_TYPE

    '�ޔ�p�p�����[�^
    Private exEnvironmentApprovalFlag As Integer                           '���F��t���O
    Private exEnvironmentAprrovalComment As String                         '���F��R�����g
    Private exNoContentCertificateEscapeCode_R As String                   '�s�ܗL�ۏ؏��K�p���O�R�[�h(RoHS)
    Private exNoContentCertificateEscapeCode_E As String                   '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
    Private exMyAnalysisResult As Integer                                  '���ȕ��͌���
    Private exCertifiedPerson As String                                    '�F��S����
    Private exBikou1 As String                                             '���L����1
    Private exBikou2 As String                                             '���L����2
    Private exBikou3 As String                                             '���L����3

#End Region

#Region "��ʒ萔�錾"
    Private Const MY_NA_COMPANY As String = "s_lbl_na_label_company1"      '��Ж�
    Private Const MY_NA_OFFICE As String = "s_lbl_na_label_office1"        '��������
    Private Const MY_GANNYUU_ARU As String = "s_slct_have"                '�s�ܗL�ۏ؏�="�L"
    Private Const MY_GANNYUU_NAI As String = "s_slct_dont_have"                  '�s�ܗL�ۏ؏�="��"
    Private Const MY_SELECT_NO As String = "s_slct_no_select"                '�s�ܗL="-"
    Private Const MY_TORIHIKI As String = "s_lbl_torihiki"
    Private Const MY_PURCHASE As String = "s_lbl_purchase"
    Private Const MY_SLCT_NO_CERTIFY As String = "s_slct_no_certify"       '�F��t���O="���F��"
    Private Const MY_SLCT_PASS As String = "s_slct_pass"                '�F��t���O="���i"
    Private Const MY_SLCT_PASS_UNDER_SITUATION As String = "s_slct_pass_under_situation"     '�F��t���O="�����t�����i"
    Private Const MY_SLCT_FAIL As String = "s_slct_fail"                '�F��t���O="�s���i"
    Private Const MY_SLCT_RESERVE As String = "s_slct_reserve"                '�F��t���O="�ۗ�"
    Private Const MY_FILE_HAVE As String = "s_file_have"                '�Y�t����="�L"
    Private Const MY_FILE_NO As String = "s_file_no"                    '�Y�t����="��"
    Private Const MY_ANALYSIS_HAVE As String = "s_analysis_have"                '���ȕ��͌���="�L"
    Private Const MY_ANALYSIS_NO As String = "s_analysis_dont_have"             '���ȕ��͌���="��"
    Private Const MY_LOGIN_MESSAGE As String = "d_hd_login_msg"                '�o�^�������b�Z�[�W
    Private Const MY_DELETE_MESSAGE As String = "d_hd_delete_msg"                '�폜�������b�Z�[�W

    '��ʊԃC���^�t�F�[�X
    Private Const IF_ID_PRODUCT As String = "d_hd_id_product"               '���iID
    Private Const IF_ID_PURCHASE As String = "idPurchase"
    Private Const IF_PAGE_FLG As String = "flgPage"                         '�J�ڐ��ʃt���O
    Private Const IF_FLAG_ENTERING As String = "flgEntering"                '���͊����t���OIF
    Private Const IF_PARA_TRAN As String = "interface_para"                  'GR0150�ɑJ�ڗp
    'ViewState�p�萔
    Private Const VS_ID_PRODUCT As String = "ID_PRODUCT"                        '���iID
    Protected WithEvents d_hd_delete_msg As System.Web.UI.HtmlControls.HtmlInputHidden
    Private Const VS_CD_PRODUCT As String = "CD_PRODUCT"                        '���iCD
    Private Const VS_CD_COMPANY As String = "ID_COMPANY"                        '���CD
    Private Const VS_VRT As String = "AGN_VER"
    Private Const VS_DS_PRODT As String = "FrmProductDS"                        '���i���
    Private Const VS_DS_PURCH As String = "FrmPurchaseDS"                       '�[�����
    Private Const VS_DS_example As String = "FrmexampleDS"
    Private Const VS_UD_DATE As String = "VS_UD_DATE"                           '�[�����r������
    Private Const VS_UD_DATE_PRODUCT As String = "VS_UD_DATE_PRODUCT"           '���i���r������

    Private Enum BTN_TYPE
        BTN_DOWNLOAD = 0    '�����N�{�^���p
        BTN_DELETE = 1      '�폜�{�^���g�p
        BTN_SELECT = 2      '�I���{�^���g�p
    End Enum
#End Region

#Region "���������֘A"
    '-----------------------------------------------------------
    ' �@�\�@�@�@: �������̏���
    '
    ' �Ԃ�l�@�@: True:����; False:�G���[������
    '
    ' �������@�@: sender - �V�X�e���I�u�W�F�N�g
    '            e - �V�X�e���C�x���g
    '
    ' �@�\�����@: �y�[�W��Load���A��������
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Protected Overrides Function PageLoadEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean
        '�������[�h�̎�
        If Not IsPostBack Then
            '���j���[���e���Z�b�g
            MyBase.SetMenuBySession()

            '�C���^�t�F�[�X�`�F�b�N
            Me.CheckIFPara()

            '��ʍ��ڂ̏�����
            Me.InitGamenData()

            'DropDownList�̏�����
            Me.InitDropDownList()

            '�{�^���̏�����
            Me.InitButton()

            '�f�[�^���擾����
            Me.GetInitData()

        End If

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �C���^�t�F�[�X�`�F�b�N����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �C���^�t�F�[�X�`�F�b�N
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub CheckIFPara()
        Dim strTemp As String
        Dim para As String

        '���iID
        strTemp = MyBase.GetParameter(examplePage.IF_ID_PRODUCT)
        If Not AgnUtil.CheckDataValue(strTemp, AgnConst.NUM_WORD, AgnConst.PRODUCT_MAXLENGTH, True) Then
            Me.TransferTo(AgnConst.ERROR_PAGE & "?Err=" & "SYE0000-02")
        End If
        '�[�����ID
        Me.ViewState(examplePage.IF_ID_PURCHASE) = CType(MyBase.GetParameter(examplePage.IF_ID_PURCHASE), Decimal)
        '��ʃt���O
        Me.ViewState(examplePage.IF_PAGE_FLG) = CType(MyBase.GetParameter(examplePage.IF_PAGE_FLG), Decimal)
        '���iID
        Me.ViewState(examplePage.IF_ID_PRODUCT) = strTemp

        '���͊����t���O
        Me.ViewState(examplePage.IF_FLAG_ENTERING) = CType(MyBase.GetParameter(examplePage.IF_FLAG_ENTERING), Decimal)

        para = "?" & examplePage.IF_ID_PRODUCT & "=" & strTemp & "&" & examplePage.IF_ID_PURCHASE & "=" &
                MyBase.GetParameter(examplePage.IF_ID_PURCHASE) & "&" & examplePage.IF_PAGE_FLG & "=" &
                MyBase.GetParameter(examplePage.IF_PAGE_FLG) & "&" & examplePage.IF_FLAG_ENTERING & "=" &
                MyBase.GetParameter(examplePage.IF_FLAG_ENTERING)

        Me.ViewState(examplePage.IF_PARA_TRAN) = para
    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ��ʍ��ڂ̏������A��ʍ��ڂ�\���ł��傤��
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �y�[�W��Load���A��ʍ��ڂ����������܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub InitGamenData()
        '*** ���i�����̕\��

        '���Ж�/������Ж�
        Me.d_lbl_na_company.Text = AgnConst.HTML_SPACE
        '�����Ə���/����掖�Ə���
        Me.d_lbl_na_office.Text = AgnConst.HTML_SPACE


        If CInt(Me.ViewState(examplePage.IF_PAGE_FLG)) = GR0150Logic.PAGE_TYPE.PURCH_PROD Then
            '��Ж�
            Me.s_lbl_na_label_company.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_NA_COMPANY, MyBase.userSession.LanguageId)
            '��������
            Me.s_lbl_na_label_office.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_NA_OFFICE, MyBase.userSession.LanguageId)

        End If
        'A Gree'Net Data Ver.
        Me.d_lbl_agn_version.Text = AgnConst.HTML_SPACE
        '�s�ܗL�ۏ؏�
        Me.d_lbl_no_content_certificate.Text = AgnConst.HTML_SPACE

        '�[�����Ж�
        Me.d_lbl_na_purchase_company.Text = AgnConst.HTML_SPACE
        '�[���掖�Ə���
        Me.d_lbl_na_purchase_office.Text = AgnConst.HTML_SPACE

        '�[����i��
        Me.d_lbl_na_purchase_product.Text = AgnConst.HTML_SPACE
        '�[����R�����g
        Me.d_lbl_input_division.Text = AgnConst.HTML_SPACE
        '�Y�t����
        Me.d_lbl_input_file.Text = AgnConst.HTML_SPACE
        '�O���[�����B�K�C�h���C��Ver.
        Me.d_lbl_green_version.Text = AgnConst.HTML_SPACE
        '�o�^�������b�Z�[�W
        Me.d_hd_login_msg.Value = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_LOGIN_MESSAGE, MyBase.userSession.LanguageId)
        '�폜�������b�Z�[�W
        Me.d_hd_delete_msg.Value = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_DELETE_MESSAGE, MyBase.userSession.LanguageId)


        '�������̎��ANG�S����\��
        '���F��R�����g
        Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:none")
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
        Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:none")
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
        Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:none")
        '�F��S����
        Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:none")
        '���L����1
        Me.s_lbl_err_bikou1.Attributes.Add("style", "display:none")
        '���L����2
        Me.s_lbl_err_bikou2.Attributes.Add("style", "display:none")
        '���L����3
        Me.s_lbl_err_bikou3.Attributes.Add("style", "display:none")

    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �{�^���̏���������
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �y�[�W��Load���A�{�^����������
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub InitButton()

        ''�u�I���v�Ɓu�폜�v�{�^���̊������i�Y���[���揊������j
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

        '�u���ʁv�{�^��
        Me.d_btn_product_login.Attributes.Item("onclick") += "registFlag=false;"
        Me.d_btn_product_login.Attributes.Add("control", "self")

        Me.d_btn_product_delete.Attributes.Item("onclick") += "registFlag=false;"
        Me.d_btn_product_delete.Attributes.Add("control", "self")

        Me.s_btn_back2.Enabled = True

    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �f�[�^�̌�������
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �����\���f�[�^���擾���܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub GetInitData()
        Dim ret As Integer

        '�u���������v�̏o��
        AgnLog.Operation(MyBase.userSession, "��������")

        Me.GetSearchPara()
        Me.myLogic = New exampleLogic(MyBase.userSession)
        '��ʃ��W�b�N���ʂ����s���܂�
        ret = Me.myLogic.Execute(exampleLogic.FUNC_READ, CType(Me.mySearchInData, DTOBase), CType(Me.mySearchOutData, DTOBase))
        If ret = 0 Then
            If Me.mySearchOutData.ErrFlag >= 0 Then

                Me.ShowInitData(True)

            ElseIf Me.mySearchOutData.ErrFlag = -22 Then
                '���iDA�Ƀf�[�^���Ȃ���΁A�G���[�ł�
                MyBase.SetException(Me.mySearchOutData)
            Else
                '�G���[���Z�[�W�\��
                AgnMsg.ShowErrMessage(Me, Me.mySearchOutData.ErrorList)
            End If
        Else
            '�ُ폈����ݒ�
            MyBase.SetException(Me.mySearchOutData)
        End If
    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �f�[�^��\��
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: convsFlg=true - �ϊ�
    '            convsFlg=false - �ϊ����Ȃ�
    '
    ' �@�\�����@: �f�[�^��\�����܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub ShowInitData(ByVal convsFlg As Boolean)
        '���i����\��
        Me.SetInitData(convsFlg)

    End Sub
    '-----------------------------------------------------------
    ' �@�\�@�@�@: DropDownList�̏�����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �y�[�W��Load���ADropDownList�̏�����
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub InitDropDownList()
        '���F��I������
        Dim lstListItem As New ListItem

        '���F��I�����ڏ�����
        Me.d_ddl_select.Items.Clear()

        '���F��I�����ځF0.���F��
        lstListItem.Value = "0"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_NO_CERTIFY, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '���F��I�����ڐV�K�ǉ�
        lstListItem = New ListItem

        '���F��I�����ځF1.���i
        lstListItem.Value = "1"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_PASS, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '���F��I�����ڐV�K�ǉ�
        lstListItem = New ListItem

        '���F��I�����ځF2.�����t�����i
        lstListItem.Value = "2"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_PASS_UNDER_SITUATION, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '���F��I�����ڐV�K�ǉ�
        lstListItem = New ListItem

        '���F��I�����ځF3.�s���i
        lstListItem.Value = "3"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_FAIL, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '���F��I�����ڐV�K�ǉ�
        lstListItem = New ListItem

        '���F��I�����ځF4.�ۗ�
        lstListItem.Value = "4"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SLCT_RESERVE, MyBase.userSession.LanguageId)
        Me.d_ddl_select.Items.Add(lstListItem)

        '���F��t���O�擾
        Dim environmentalApprovalFlg As Integer = CInt(MyBase.GetParameter("EnvironmentalApproval"))

        '���F��t���O����
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

        '���ȕ��͌��ʑI�����ڐV�K�ǉ�
        lstListItem = New ListItem

        '���ȕ��͌��ʑI�����ځF0.��
        lstListItem.Value = "0"
        lstListItem.Text = ""
        Me.d_ddl_my_analysis_result.Items.Add(lstListItem)

        '���ȕ��͌��ʑI�����ڐV�K�ǉ�
        lstListItem = New ListItem

        '���ȕ��͌��ʑI�����ځF1.�L
        lstListItem.Value = "1"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_ANALYSIS_HAVE, MyBase.userSession.LanguageId)
        Me.d_ddl_my_analysis_result.Items.Add(lstListItem)

        '���ȕ��͌��ʑI�����ڐV�K�ǉ�
        lstListItem = New ListItem

        '���ȕ��͌��ʑI�����ځF2.��
        lstListItem.Value = "2"
        lstListItem.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_ANALYSIS_NO, MyBase.userSession.LanguageId)
        Me.d_ddl_my_analysis_result.Items.Add(lstListItem)

        Me.d_ddl_my_analysis_result.SelectedIndex = 0

    End Sub
    '-----------------------------------------------------------
    ' �@�\�@�@�@: �f�[�^��\��
    '
    ' �Ԃ�l�@�@: 0 ����  0�ȊO �ُ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �f�[�^��\�����܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Function SetInitData(ByVal convsFlg As Boolean) As Integer
        Dim productCompany As String = ""           '������Ж�
        Dim flgNOContent As String = ""

        If Me.mySearchOutData.FrmProductDS.Tables(0).Rows.Count = 0 Then
            '�G���[���Z�[�W�\��
            AgnMsg.ShowErrMessage(Me, Me.mySearchOutData.ErrorList)
            Return -1
        Else

            '������Ж�
            productCompany = AgnUtil.GetCompanyName(Me.mySearchOutData.FrmProductDS)
            '���i�ԍ�
            If convsFlg = True Then
                Me.ViewState(examplePage.VS_CD_PRODUCT) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "cdProduct")
            Else
                Me.ViewState(examplePage.VS_CD_PRODUCT) = Me.Server.HtmlDecode(AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "cdProduct"))
            End If
            '���iCD
            If Len(CStr(Me.ViewState(examplePage.VS_CD_PRODUCT))) = 0 Then
                Return -1
            End If
            '�������CD
            Me.ViewState(examplePage.VS_CD_COMPANY) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "cdCompany1")
            '�������CD
            If Len(CStr(Me.ViewState(examplePage.VS_CD_COMPANY))) = 0 Then
                Return -1
            End If

            If convsFlg = True Then
                '�����̃f�[�^�̃Z�L���A�ϊ�
                AgnUtil.ConvDs(Me, CType(Me.mySearchOutData.FrmProductDS, DataSet))
            End If


            '������Ж�
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaCompany1") = "" Or
                    AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaCompany1") Is Nothing Then
                Me.d_lbl_na_company.Text = AgnConst.HTML_SPACE
            Else
                Me.d_lbl_na_company.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaCompany1")
            End If

            '����掖������
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaOffice1") = "" Or
                    AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaOffice1") Is Nothing Then
                Me.d_lbl_na_office.Text = AgnConst.HTML_SPACE
            Else
                Me.d_lbl_na_office.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaOffice1")
            End If

            '���������QID
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "idChemicalInvGroup") = "" Or
                    AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "idChemicalInvGroup") Is Nothing Then
                Me.d_lbl_green_version.Text = AgnConst.HTML_SPACE
                Me.d_lbl_na_surveyeproductgrp.Text = AgnConst.HTML_SPACE
            Else
                '���������Q��
                If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaInvChemicalGroupLatest") = "" Or
                        AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaInvChemicalGroupLatest") Is Nothing Then
                    Me.d_lbl_green_version.Text = AgnConst.HTML_SPACE
                    Me.d_lbl_na_surveyeproductgrp.Text = AgnConst.HTML_SPACE
                Else
                    '��ʏ��js���g���A���������QID�ƒ��������Q���ɂ���āA�O���[�����B�K�C�h���C��ver.��ݒ肷��
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "setChemicalInvGroup",
                                "<script type=""text/javascript"">setChemicalInvGroup(" & AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "idChemicalInvGroup") & ",""" & AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "lcNaInvChemicalGroupLatest") & """);</script>")
                End If
            End If

            '�r������pUD_DATE
            Me.ViewState(examplePage.VS_UD_DATE_PRODUCT) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmProductDS, DataSet), 0, "udDate")

        End If


        If Me.mySearchOutData.FrmPurchaseDS.Tables(0).Rows.Count = 0 Then
            '�G���[���Z�[�W�\��
            AgnMsg.ShowErrMessage(Me, Me.mySearchOutData.ErrorList)
            Return -1
        Else

            '���F��R�����g
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval") Is Nothing Then
                Me.d_txt_enviroment_approval_comment.Text = ""
            Else
                Me.d_txt_enviroment_approval_comment.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksEnvironmentApproval")
            End If
            '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV") Is Nothing Then
                Me.d_txt_no_content_certificate_escape_code_e.Text = ""
            Else
                Me.d_txt_no_content_certificate_escape_code_e.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeELV")
            End If
            '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS") Is Nothing Then
                Me.d_txt_no_content_certificate_escape_code_r.Text = ""
            Else
                Me.d_txt_no_content_certificate_escape_code_r.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "noContentCertificateEscapeCodeROHS")
            End If

            '�F��S����
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson") Is Nothing Then
                Me.d_txt_cetified_person.Text = ""
            Else
                Me.d_txt_cetified_person.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "certifiedPerson")
            End If
            '���L����1
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1") Is Nothing Then
                Me.d_txt_bikou1.Text = ""
            Else
                Me.d_txt_bikou1.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou1")
            End If
            '���L����2
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2") Is Nothing Then
                Me.d_txt_bikou2.Text = ""
            Else
                Me.d_txt_bikou2.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou2")
            End If
            '���L����3
            If AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3") = "" Or
                AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3") = AgnConst.HTML_SPACE Or
                       AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3") Is Nothing Then
                Me.d_txt_bikou3.Text = ""
            Else
                Me.d_txt_bikou3.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "bikou3")
            End If

            If convsFlg = True Then
                '�����̃f�[�^�̃Z�L���A�ϊ�
                AgnUtil.ConvDs(Me, CType(Me.mySearchOutData.FrmPurchaseDS, DataSet))
            End If

            'A Gree'Net Data Ver.
            Me.d_lbl_agn_version.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "agnDataVersion")
            '�s�ܗL�ۏ؏�
            flgNOContent = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "flgNoContentCertificate")
            If "0".Equals(flgNOContent) Then
                Me.d_lbl_no_content_certificate.Text = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_SELECT_NO, MyBase.userSession.LanguageId)
            ElseIf "1".Equals(flgNOContent) Then
                Me.d_lbl_no_content_certificate.Text = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_GANNYUU_ARU, MyBase.userSession.LanguageId)
            Else
                Me.d_lbl_no_content_certificate.Text = PageBase.mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_GANNYUU_NAI, MyBase.userSession.LanguageId)

            End If


            '�[�����Ж�
            Me.d_lbl_na_purchase_company.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "lcPurchaseNaCompany")
            '�[���掖�Ə���
            Me.d_lbl_na_purchase_office.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "lcPurchaseNaOffice")
            '�[����i��
            Me.d_lbl_na_purchase_product.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "naPurchaseProduct")
            '�[����R�����g
            Me.d_lbl_input_division.Text = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "remarksPurchaseCompany")

            '�Y�t����
            If Me.mySearchOutData.FileHave Then
                Me.d_lbl_input_file.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_FILE_HAVE, MyBase.userSession.LanguageId)
            Else
                Me.d_lbl_input_file.Text = mergeCtl.GetCtrlLanguage(MyBase.myFormID, examplePage.MY_FILE_NO, MyBase.userSession.LanguageId)
            End If

            '�r������pUD_DATE
            Me.ViewState(examplePage.VS_UD_DATE) = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "udDate")

            '�u�I���v�Ɓu�폜�v�{�^���̊������i�Y���[���揊������j
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

            '���ȕ��͌���
            Me.d_ddl_my_analysis_result.SelectedIndex = AgnUtil.GetDataFromDataSet(CType(Me.mySearchOutData.FrmPurchaseDS, DataSet), 0, "myAnalysisResult")

        End If

        'AGN�K�p���O�R�[�h(ELV)
        If Me.mySearchOutData.AgnEscapeCode_E = String.Empty Then
            Me.d_lbl_agn_escape_code_e.Text = AgnConst.HTML_SPACE
        Else
            Me.d_lbl_agn_escape_code_e.Text = Me.mySearchOutData.AgnEscapeCode_E
        End If

        'AGN�K�p���O�R�[�h(ROHS)
        If Me.mySearchOutData.AgnEscapeCode_R = String.Empty Then
            Me.d_lbl_agn_escape_code_r.Text = AgnConst.HTML_SPACE
        Else
            Me.d_lbl_agn_escape_code_r.Text = Me.mySearchOutData.AgnEscapeCode_R
        End If

        '��ʃR���g���[���̃X�y�[�X���폜����
        TrimSpace()

        Return AgnConst.DEFAULT_VALUE_LONG_ZERO

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ���������̍쐬����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �����������쐬���܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub GetSearchPara()

        '���iID
        Me.mySearchInData.IdProduct = CType(MyBase.GetParameter(examplePage.IF_ID_PRODUCT), Decimal)
        Me.ViewState(examplePage.VS_ID_PRODUCT) = Me.mySearchInData.IdProduct

        Me.mySearchInData.IdPurchase = CType(Me.ViewState(examplePage.IF_ID_PURCHASE), Decimal)

    End Sub
#End Region

#Region "�{�^�������֘A"

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ���F��o�^�̑O�`�F�b�N(�d�l�ύX�ɂ��)
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: sender - System.Object
    ' �@�@�@�@�@�@e�@- System.EventArgs
    '
    ' �@�\�����@: ���F��o�^���X�V�������܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_login.Click

        '��ʃR���g���[���̃X�y�[�X���폜����
        TrimSpace()

        '�o�^�O�̃`�F�b�N
        If preCheck() = False Then
            Exit Sub
        Else
            '�ޔ�p�p�����[�^�i�[
            Me.ExSave()
            'subwin�ɂ�郆�[�U�[�m�F
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "uploadCheck",
                            "<script type=""text/javascript"">uploadCheck();</script>")

            '�ޔ�p�p�����[�^�擾
            Me.ExRead()
            Exit Sub
        End If

    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ���F��o�^�̍X�V�����{����(�d�l�ύX�ɂ��)
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: sender - System.Object
    ' �@�@�@�@�@�@e�@- System.EventArgs
    '
    ' �@�\�����@: ���F��o�^���X�V�������܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_login_hd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_login_hd.Click
        Dim ret As Integer

        '��ʃR���g���[���̃X�y�[�X���폜����
        TrimSpace()

        '�[�����ID
        Me.myRegisterInData.IdPurchase = CType(Me.ViewState(examplePage.IF_ID_PURCHASE), Decimal)
        '���i���ID
        Me.myRegisterInData.IdProduct = CType(Me.ViewState(examplePage.IF_ID_PRODUCT), Decimal)
        '���F��t���O
        Me.myRegisterInData.Staturs = CInt(Me.d_ddl_select.SelectedValue)
        '�[�����r������p
        Me.myRegisterInData.UdDate = CStr(Me.ViewState(examplePage.VS_UD_DATE))
        '���i���r������p
        Me.myRegisterInData.UdDateProduct = CStr(Me.ViewState(examplePage.VS_UD_DATE_PRODUCT))
        '���������Q
        If d_hd_id_surveyeproductgrp.Value = "" Or d_hd_id_surveyeproductgrp.Value Is Nothing Then
            Me.myRegisterInData.IdChemicalManagementGroup = String.Empty
        Else
            Me.myRegisterInData.IdChemicalManagementGroup = CInt(d_hd_id_surveyeproductgrp.Value)
        End If
        '���F��R�����g
        If Me.d_txt_enviroment_approval_comment.Text = "" Or Me.d_txt_enviroment_approval_comment.Text Is Nothing Then
            Me.myRegisterInData.EnvironmentalApprovalComment = String.Empty
        ElseIf Me.d_txt_enviroment_approval_comment.Text.Contains("script>") Then
            Me.myRegisterInData.EnvironmentalApprovalComment = String.Empty
        Else
            Me.myRegisterInData.EnvironmentalApprovalComment = CStr(Me.d_txt_enviroment_approval_comment.Text)
        End If
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
        If Me.d_txt_no_content_certificate_escape_code_e.Text = "" Or Me.d_txt_no_content_certificate_escape_code_e.Text Is Nothing Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_E = String.Empty
        ElseIf Me.d_txt_no_content_certificate_escape_code_e.Text.Contains("script>") Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_E = String.Empty
        Else
            Me.myRegisterInData.NoContentCertificateEscapeCode_E = CStr(Me.d_txt_no_content_certificate_escape_code_e.Text)
        End If
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
        If Me.d_txt_no_content_certificate_escape_code_r.Text = "" Or Me.d_txt_no_content_certificate_escape_code_r.Text Is Nothing Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_R = String.Empty
        ElseIf Me.d_txt_no_content_certificate_escape_code_r.Text.Contains("script>") Then
            Me.myRegisterInData.NoContentCertificateEscapeCode_R = String.Empty
        Else
            Me.myRegisterInData.NoContentCertificateEscapeCode_R = CStr(Me.d_txt_no_content_certificate_escape_code_r.Text)
        End If
        '���ȕ��͌���
        Me.myRegisterInData.MyAnalysisResult = CInt(Me.d_ddl_my_analysis_result.SelectedValue)
        '�F��S����
        If Me.d_txt_cetified_person.Text = "" Or Me.d_txt_cetified_person.Text Is Nothing Then
            Me.myRegisterInData.CertifiedPerson = String.Empty
        ElseIf Me.d_txt_cetified_person.Text.Contains("script>") Then
            Me.myRegisterInData.CertifiedPerson = String.Empty
        Else
            Me.myRegisterInData.CertifiedPerson = CStr(Me.d_txt_cetified_person.Text)
        End If
        '���L����1
        If Me.d_txt_bikou1.Text = "" Or Me.d_txt_bikou1.Text Is Nothing Then
            Me.myRegisterInData.Bikou1 = String.Empty
        ElseIf Me.d_txt_bikou1.Text.Contains("script>") Then
            Me.myRegisterInData.Bikou1 = String.Empty
        Else
            Me.myRegisterInData.Bikou1 = CStr(Me.d_txt_bikou1.Text)
        End If
        '���L����2
        If Me.d_txt_bikou2.Text = "" Or Me.d_txt_bikou2.Text Is Nothing Then
            Me.myRegisterInData.Bikou2 = String.Empty
        ElseIf Me.d_txt_bikou2.Text.Contains("script>") Then
            Me.myRegisterInData.Bikou2 = String.Empty
        Else
            Me.myRegisterInData.Bikou2 = CStr(Me.d_txt_bikou2.Text)
        End If
        '���L����3
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
                '�Y���[����񂪂���ꍇ�A�G���[���b�Z�[�W���o�͂���.�i�Ɩ��G���[�j
                AgnMsg.ShowErrMessage(Me, myRegisterOutData.ErrorList)
            End If
            Me.d_btn_product_login.Enabled = True
        Else
            '�ُ폈����ݒ�
            Me.myRegisterOutData.ErrorList.Add("SYE0000-01")
            MyBase.SetException(Me.myRegisterOutData)
        End If
    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ���F��o�^�̍폜����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: sender - System.Object
    ' �@�@�@�@�@�@e�@- System.EventArgs
    '
    ' �@�\�����@: ���F��o�^���폜�������܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_delete.Click

        '��ʃR���g���[���̃X�y�[�X���폜����
        TrimSpace()

        '�ޔ�p�p�����[�^�i�[
        Me.ExSave()

        'subwin�ɂ�郆�[�U�[�m�F
        Me.ClientScript.RegisterStartupScript(Me.GetType(), "deleteCheck",
                            "<script type=""text/javascript"">deleteCheck();</script>")

        '�ޔ�p�p�����[�^�擾
        Me.ExRead()
        Exit Sub

    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ���F��o�^�̍폜����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: sender - System.Object
    ' �@�@�@�@�@�@e�@- System.EventArgs
    '
    ' �@�\�����@: ���F��o�^���폜�������܂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub d_btn_product_delete_hd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_btn_product_delete_hd.Click
        Dim ret As Integer

        '�[�����ID
        Me.myRegisterInData.IdPurchase = CType(Me.ViewState(examplePage.IF_ID_PURCHASE), Decimal)
        '�[�����r������p
        Me.myRegisterInData.UdDate = CStr(Me.ViewState(examplePage.VS_UD_DATE))

        Me.myLogic = New exampleLogic(MyBase.userSession)
        ret = Me.myLogic.Execute(exampleLogic.FUNC_DELETE, CType(Me.myRegisterInData, DTOBase), CType(Me.myRegisterOutData, DTOBase))

        If ret >= 0 Then
            If Me.myRegisterOutData.ErrFlag >= 0 Then
                Me.TransferTo(AgnConst.GR0150_PAGE & CStr(Me.ViewState(examplePage.IF_PARA_TRAN)))
            Else
                '�Y���[����񂪂���ꍇ�A�G���[���b�Z�[�W���o�͂���.�i�Ɩ��G���[�j
                AgnMsg.ShowErrMessage(Me, myRegisterOutData.ErrorList)
            End If
            Me.d_btn_product_login.Enabled = True
        Else
            '�ُ폈����ݒ�
            MyBase.SetException(Me.myRegisterOutData)
        End If
    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �[������ʂɖ߂�
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: sender - System.Object
    ' �@�@�@�@�@�@e�@- System.EventArgs
    '
    ' �@�\�����@: �[������ʂɖ߂�
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub s_btn_back2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s_btn_back2.Click
        Me.TransferTo(AgnConst.GR0150_PAGE & CStr(Me.ViewState(examplePage.IF_PARA_TRAN)))
    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: ��ʃR���g���[���̃X�y�[�X���폜����
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: ��ʃR���g���[���̃X�y�[�X���폜����
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub TrimSpace()

        '���F��R�����g
        AgnUtil.TrimFormSpace(Me.d_txt_enviroment_approval_comment)
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
        AgnUtil.TrimFormSpace(Me.d_txt_no_content_certificate_escape_code_e)
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
        AgnUtil.TrimFormSpace(Me.d_txt_no_content_certificate_escape_code_r)
        '�F��S����
        AgnUtil.TrimFormSpace(Me.d_txt_cetified_person)
        '���L����1
        AgnUtil.TrimFormSpace(Me.d_txt_bikou1)
        '���L����2
        AgnUtil.TrimFormSpace(Me.d_txt_bikou2)
        '���L����3
        AgnUtil.TrimFormSpace(Me.d_txt_bikou3)

    End Sub

    '---------------------------------------------------------------------------
    ' �@�\�@�@�@: �o�^�O�̃`�F�b�N
    '
    ' �Ԃ�l�@�@: �G���[�t���O
    '
    ' �������@�@: 
    '
    ' �@�\�����@: �o�^�O�̃`�F�b�N
    '
    ' ���l�@�@�@: 
    '---------------------------------------------------------------------------
    Private Function preCheck() As Boolean

        Dim errList As ArrayList = New ArrayList    '�G���[���X�g
        Dim isNoErr As Boolean = True '�G���[�t���O

        '�������̎��ANG�S����\��
        '���F��R�����g
        Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:none")
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
        Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:none")
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
        Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:none")
        '�F��S����
        Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:none")
        '���L����1
        Me.s_lbl_err_bikou1.Attributes.Add("style", "display:none")
        '���L����2
        Me.s_lbl_err_bikou2.Attributes.Add("style", "display:none")
        '���L����3
        Me.s_lbl_err_bikou3.Attributes.Add("style", "display:none")


        ' GRE0800-01 ���F��R�����g��200�����ȉ��œ��͂��Ă��������B
        If Me.d_txt_enviroment_approval_comment.Text.Length > 200 Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-01"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-01"))
            'NG��\������
            Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_enviroment_approval_comment.Text.Length > 0 And Me.d_txt_enviroment_approval_comment.Text.Contains(vbTab) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add("���F��R�����g�̓^�u����͂��Ȃ��Ă��������B")
            'NG��\������
            Me.s_lbl_err_enviroment_approval_comment.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-02 �s�ܗL�ۏ؏��K�p���O�R�[�h�͔��p�̂�100�����ȉ��œ��͂��Ă��������B(ROHS)
        If Me.d_txt_no_content_certificate_escape_code_r.Text.Length > 100 Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            'NG��\������
            Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_r.Text.Length > 0 And (Not (System.Text.RegularExpressions.Regex.Match(Me.d_txt_no_content_certificate_escape_code_r.Text, "^[a-zA-Z0-9!-/:;-@\[-`{-~]+$")).Success) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-02"))
            'NG��\������
            Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_r.Text.Length > 0 And Me.d_txt_no_content_certificate_escape_code_r.Text.Contains(vbTab) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add("�s�ܗL�ۏ؏��K�p���O�R�[�h(RoHS)�̓^�u����͂��Ȃ��Ă��������B")
            'NG��\������
            Me.s_lbl_err_no_content_certificate_escape_code_r.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-07 �s�ܗL�ۏ؏��K�p���O�R�[�h�͔��p�̂�100�����ȉ��œ��͂��Ă��������B(ELV)
        If Me.d_txt_no_content_certificate_escape_code_e.Text.Length > 100 Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            'NG��\������
            Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_e.Text.Length > 0 And (Not (System.Text.RegularExpressions.Regex.Match(Me.d_txt_no_content_certificate_escape_code_e.Text, "^[a-zA-Z0-9!-/:;-@\[-`{-~]+$")).Success) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-07"))
            'NG��\������
            Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_no_content_certificate_escape_code_e.Text.Length > 0 And Me.d_txt_no_content_certificate_escape_code_e.Text.Contains(vbTab) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add("�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)�̓^�u����͂��Ȃ��Ă��������B")
            'NG��\������
            Me.s_lbl_err_no_content_certificate_escape_code_e.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-03 �F��S���҂�100�����ȉ��œ��͂��Ă��������B
        If Me.d_txt_cetified_person.Text.Length > 100 Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-03"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-03"))
            'NG��\������
            Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_cetified_person.Text.Length > 0 And Me.d_txt_cetified_person.Text.Contains(vbTab) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add("�F��S���҂̓^�u����͂��Ȃ��Ă��������B")
            'NG��\������
            Me.s_lbl_err_cetified_person.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-04 ���L����1��200�����ȉ��œ��͂��Ă��������B
        If Me.d_txt_bikou1.Text.Length > 200 Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-04"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-04"))
            'NG��\������
            Me.s_lbl_err_bikou1.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_bikou1.Text.Length > 0 And Me.d_txt_bikou1.Text.Contains(vbTab) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add("���L����1�̓^�u����͂��Ȃ��Ă��������B")
            'NG��\������
            Me.s_lbl_err_bikou1.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-05 ���L����2��200�����ȉ��œ��͂��Ă��������B
        If Me.d_txt_bikou2.Text.Length > 200 Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-05"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-05"))
            'NG��\������
            Me.s_lbl_err_bikou2.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_bikou2.Text.Length > 0 And Me.d_txt_bikou2.Text.Contains(vbTab) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add("���L����2�̓^�u����͂��Ȃ��Ă��������B")
            'NG��\������
            Me.s_lbl_err_bikou2.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        ' GRE0800-06 ���L����3��200�����ȉ��œ��͂��Ă��������B
        If Me.d_txt_bikou3.Text.Length > 200 Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add(AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-06"))
            '�G���[���O���o�͂���
            AgnLog.Err(MyBase.userSession, AgnMsg.GetMessage(MyBase.userSession.LanguageId, "GRE0800-06"))
            'NG��\������
            Me.s_lbl_err_bikou3.Attributes.Add("style", "display:inline")
            isNoErr = False

        ElseIf Me.d_txt_bikou3.Text.Length > 0 And Me.d_txt_bikou3.Text.Contains(vbTab) Then

            '�G���[���b�Z�[�W��ݒ肷��
            errList.Add("���L����3�̓^�u����͂��Ȃ��Ă��������B")
            'NG��\������
            Me.s_lbl_err_bikou3.Attributes.Add("style", "display:inline")
            isNoErr = False
        End If

        If isNoErr = False Then

            '�G���[���o�͂���
            AgnMsg.ShowErrMessage(Me, errList)
        End If

        Return isNoErr

    End Function

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �ޔ�p�p�����[�^�i�[
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �ޔ�p�p�����[�^���i�[����
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub ExSave()

        '���F��
        exEnvironmentApprovalFlag = Me.d_ddl_select.SelectedIndex
        '���ȕ��͌���
        exMyAnalysisResult = Me.d_ddl_my_analysis_result.SelectedIndex
        '���F��R�����g
        exEnvironmentAprrovalComment = Me.d_txt_enviroment_approval_comment.Text
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
        exNoContentCertificateEscapeCode_E = Me.d_txt_no_content_certificate_escape_code_e.Text
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
        exNoContentCertificateEscapeCode_R = Me.d_txt_no_content_certificate_escape_code_r.Text
        '�F��S����
        exCertifiedPerson = Me.d_txt_cetified_person.Text
        '���L����1
        exBikou1 = Me.d_txt_bikou1.Text
        '���L����2
        exBikou2 = Me.d_txt_bikou2.Text
        '���L����3
        exBikou3 = Me.d_txt_bikou3.Text

    End Sub

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �ޔ�p�p�����[�^�擾
    '
    ' �Ԃ�l�@�@: �Ȃ�
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �ޔ�p�p�����[�^���擾����
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub ExRead()

        '�f�[�^���擾����
        Me.GetInitData()

        '���F��
        Me.d_ddl_select.SelectedIndex = exEnvironmentApprovalFlag
        '���ȕ��͌���
        Me.d_ddl_my_analysis_result.SelectedIndex = exMyAnalysisResult
        '���F��R�����g
        Me.d_txt_enviroment_approval_comment.Text = exEnvironmentAprrovalComment
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
        Me.d_txt_no_content_certificate_escape_code_e.Text = exNoContentCertificateEscapeCode_E
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
        Me.d_txt_no_content_certificate_escape_code_r.Text = exNoContentCertificateEscapeCode_R
        '�F��S����
        Me.d_txt_cetified_person.Text = exCertifiedPerson
        '���L����1
        Me.d_txt_bikou1.Text = exBikou1
        '���L����2
        Me.d_txt_bikou2.Text = exBikou2
        '���L����3
        Me.d_txt_bikou3.Text = exBikou3

    End Sub

#End Region

End Class