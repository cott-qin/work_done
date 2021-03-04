'---------------------------------------------------------------
' �@�[�������F��o�^
'---------------------------------------------------------------
Public Class exampleLogic
    Inherits DBOperator

#Region "�ϐ�.�萔�錾"

    Private myexampleDA As exampleDA

    Public Const FUNC_UPDATE As String = "update"
    Public Const FUNC_DELETE As String = "delete"
    Public Const FUNC_DOWNLOAD As String = "download"
    Public Const FUNC_READ As String = "init"

    Private myBuyerRequestProductDA As BuyerRequestProductDA                '���B�Ғ����˗����i�f�[�^�N���X

    Private myPurchaseDA As PurchaseDA                                      '�[�����f�[�^�A�N�Z�X
    Private myProductDAT As ProductDA                                        '���i��{���(���͊���)
    Private PAGE_TYPE As GR0150Logic.PAGE_TYPE                               '�J�ڐ��ʃt���O
#End Region

#Region "��������"
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

#Region "��ʎ��s"
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

#Region "��������"

    '-----------------------------------------------------------
    ' �@�\�@�@�@: �w���������
    '
    ' �Ԃ�l�@�@: �Ȃ� 
    '
    ' �������@�@: inData    - ���̓p�����[�^
    ' �@�@�@�@�@  outData   - �o�̓p�����[�^
    '
    ' �@�\�����@: �w������̃��R�[�h�����擾����
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub init(ByVal inData As exampleSearchRequest, ByRef outData As exampleSearchResponse)
        Dim intReturnValue As Integer
        Dim msg As String
        Dim idProduct As Decimal
        Dim resultEscapeCodeTable As DataTable


        '�V�Ώۂ̐���
        Me.myProductDAT = New ProductDA(MyBase.myUserSession)
        '�N���A
        Me.myProductDAT.ProductClear()
        '�p�����[�^�̎擾
        '���iID�̐ݒ�
        Me.myProductDAT.IdProduct = inData.IdProduct
        Me.myProductDAT.CdLang = MyBase.myUserSession.LanguageId
        '�����ތ^�̐ݒ�
        Me.myProductDAT.ReadPattern = 0
        idProduct = Me.myProductDAT.IdProduct

        intReturnValue = Me.myProductDAT.ProductRead()

        outData.ErrFlag = intReturnValue

        '�߂�l�𔻒f
        If intReturnValue = AgnConst.DAReturnValue.NoInput Then
            '�p�����[�^�G���[
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            Me.myProductDAT = Nothing
            Return
        ElseIf intReturnValue = 0 Then
            '�f�[�^����
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYI0000-08")
            outData.ErrorList.Add("SYI0000-08")
            AgnLog.Err(MyBase.myUserSession, msg)
            Me.myProductDAT = Nothing
            outData.ErrFlag = -22   '���iDA�Ƀf�[�^���Ȃ���΁A�G���[�ł�
            Return
        End If


        '�����̃f�[�^�Z�b�g�̐ݒ�
        outData.FrmProductDS = CType(Me.myProductDAT.ResultDataSet, ProductDS)

        Me.myProductDAT = Nothing

        Me.myPurchaseDA = New PurchaseDA(MyBase.myUserSession)
        Me.myPurchaseDA.CDLang = MyBase.myUserSession.LanguageId
        Me.myPurchaseDA.IDPurchase = inData.IdPurchase
        Me.myPurchaseDA.ReadPattern = 0
        '�������s
        intReturnValue = Me.myPurchaseDA.PurchaseRead()

        outData.ErrFlag = intReturnValue

        '�߂�l�𔻒f
        If intReturnValue = AgnConst.DAReturnValue.NoInput Then
            '�p�����[�^�G���[
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
                outData.ErrFlag = -22   '���iDA�Ƀf�[�^���Ȃ���΁A�G���[�ł�
                Return
            End If
        End If

        '�����̃f�[�^�Z�b�g�̐ݒ�
        outData.FrmPurchaseDS = CType(Me.myPurchaseDA.ResultDataSet, PurchaseDS)

        Me.myPurchaseDA = Nothing

        Me.myexampleDA = New exampleDA(Me.myUserSession)
        '�[�����ID
        Me.myexampleDA.IdPurchase = CStr(inData.IdPurchase)

        intReturnValue = Me.myexampleDA.fileInfo()
        outData.ErrFlag = intReturnValue
        If intReturnValue = AgnConst.DAReturnValue.NoInput Then
            '�p�����[�^�G���[
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
        '���iID
        Me.myexampleDA.IdProduct = CStr(inData.IdProduct)

        resultEscapeCodeTable = Me.myexampleDA.getEscapeCode()

        '���ʃe�[�u���Ƀf�[�^������ꍇ
        If resultEscapeCodeTable.Rows.Count > 0 Then

            If resultEscapeCodeTable.Rows(0).Item(0) = CType(AgnConst.DAReturnValue.NoInput, String) Then
                '�p�����[�^�G���[
                msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
                outData.ErrorList.Add(msg)
                AgnLog.Err(MyBase.myUserSession, msg)
                Me.myexampleDA = Nothing
                Return
            End If

            For i = 0 To resultEscapeCodeTable.Rows.Count - 1
                '�ŏ��̏��O�R�[�h
                If i = 0 Then
                    outData.AgnEscapeCode = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                    '�ŏ��ȊO�̏��O�R�[�h
                Else
                    outData.AgnEscapeCode = outData.AgnEscapeCode & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                End If
            Next

            Dim r As Integer = 0
            Dim e As Integer = 0
            For i = 0 To resultEscapeCodeTable.Rows.Count - 1
                'ENV�̏ꍇ
                If "E" = CType(resultEscapeCodeTable.Rows(i).Item(1), String) Then
                    '�ŏ���ENV���O�R�[�h
                    If e = 0 Then
                        outData.AgnEscapeCode_E = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        e = e + 1
                        '�ŏ��ȊO��ENV���O�R�[�h
                    Else
                        '�d���ȏ��O�R�[�h�\������Ȃ�
                        If outData.AgnEscapeCode_E.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_E = outData.AgnEscapeCode_E & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                    'ROHS�̏ꍇ
                ElseIf "R" = CType(resultEscapeCodeTable.Rows(i).Item(1), String) Then
                    '�ŏ���ROHS���O�R�[�h
                    If r = 0 Then
                        outData.AgnEscapeCode_R = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        r = r + 1
                        '�ŏ��ȊO��ROHS���O�R�[�h
                    Else
                        '�d���ȏ��O�R�[�h�\������Ȃ�
                        If outData.AgnEscapeCode_R.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_R = outData.AgnEscapeCode_R & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                    'ROHS,ENV�̏ꍇ
                ElseIf "R,E" = CType(resultEscapeCodeTable.Rows(i).Item(1), String) Then
                    '�ŏ���ENV���O�R�[�h
                    If e = 0 Then
                        outData.AgnEscapeCode_E = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        e = e + 1
                        '�ŏ��ȊO��ENV���O�R�[�h
                    Else
                        '�d���ȏ��O�R�[�h�\������Ȃ�
                        If outData.AgnEscapeCode_E.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_E = outData.AgnEscapeCode_E & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                    '�ŏ���ROHS���O�R�[�h
                    If r = 0 Then
                        outData.AgnEscapeCode_R = CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        r = r + 1
                        '�ŏ��ȊO��ROHS���O�R�[�h
                    Else
                        '�d���ȏ��O�R�[�h�\������Ȃ�
                        If outData.AgnEscapeCode_R.Contains(CType(resultEscapeCodeTable.Rows(i).Item(0), String)) Then
                            'do nothing
                        Else
                            outData.AgnEscapeCode_R = outData.AgnEscapeCode_R & ";" & CType(resultEscapeCodeTable.Rows(i).Item(0), String)
                        End If
                    End If
                End If
            Next


            '���ʃe�[�u���Ƀf�[�^���Ȃ��ꍇ
        Else
            outData.AgnEscapeCode = String.Empty
            outData.AgnEscapeCode_E = String.Empty
            outData.AgnEscapeCode_R = String.Empty
        End If

    End Sub

#End Region

#Region "�X�V�������s"
    '-----------------------------------------------------------
    ' �@�\�@�@�@: �w������X�V
    '
    ' �Ԃ�l�@�@: �Ȃ� 
    '
    ' �������@�@: inData    - ���̓p�����[�^
    ' �@�@�@�@�@  outData   - �o�̓p�����[�^
    '
    ' �@�\�����@: �w������̃��R�[�h���X�V����
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub update(ByVal inData As exampleRegisterRequest, ByRef outData As exampleRegisterResponse)
        Dim result As Integer
        Dim msg As String               '���b�Z�[�W
        Dim inDataSearch As New exampleSearchRequest
        Dim outDataSearch As New exampleSearchResponse

        myexampleDA = New exampleDA(Me.myUserSession)
        '�[�����ID
        Me.myexampleDA.IdPurchase = CStr(inData.IdPurchase)
        '���F��t���O
        Me.myexampleDA.Staturs = inData.Staturs
        '�[�����r������p�o�^����
        Me.myexampleDA.UdDate = inData.UdDate
        '���i���r������p�o�^����
        Me.myexampleDA.UdDateProduct = inData.UdDateProduct
        '���i���ID
        Me.myexampleDA.IdProduct = CStr(inData.IdProduct)
        '���������Q
        Me.myexampleDA.IdChemicalManagementGroup = inData.IdChemicalManagementGroup
        '���F��R�����g
        Me.myexampleDA.EnvironmentalApprovalComment = inData.EnvironmentalApprovalComment
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ROHS)
        Me.myexampleDA.NoContentCertificateEscapeCode_R = inData.NoContentCertificateEscapeCode_R
        '���ȕ��͌���
        Me.myexampleDA.MyAnalysisResult = inData.MyAnalysisResult
        '�F��S����
        Me.myexampleDA.CertifiedPerson = inData.CertifiedPerson
        '���L����1
        Me.myexampleDA.Bikou1 = inData.Bikou1
        '���L����2
        Me.myexampleDA.Bikou2 = inData.Bikou2
        '���L����3
        Me.myexampleDA.Bikou3 = inData.Bikou3
        '�s�ܗL�ۏ؏��K�p���O�R�[�h(ELV)
        Me.myexampleDA.NoContentCertificateEscapeCode_E = inData.NoContentCertificateEscapeCode_E

        result = myexampleDA.updateFile()

        '�G���[�t���O��ݒ�
        outData.ErrFlag = result

        '�G���[���O�o��
        If result = AgnConst.DAReturnValue.NoInput Then
            '�p�����[�^�G���[
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        ElseIf result = AgnConst.DAReturnValue.Haita Then
            '�����[�U�̑���ɂ��A���i��{��񂪕ύX����Ă��܂��B�ēx�������A������s���ĉ������B
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-09")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            '�G���[�t���O��ݒ�
            outData.ErrFlag = -23
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        End If

        Me.myexampleDA = Nothing

    End Sub
#End Region

#Region "�폜�������s"
    '-----------------------------------------------------------
    ' �@�\�@�@�@: �w������폜
    '
    ' �Ԃ�l�@�@: �Ȃ� 
    '
    ' �������@�@: inData    - ���̓p�����[�^
    ' �@�@�@�@�@  outData   - �o�̓p�����[�^
    '
    ' �@�\�����@: �w������̃��R�[�h���폜����(���g�p�t���O��1�ɂ���)
    '
    ' ���l�@�@�@: 
    '-----------------------------------------------------------
    Private Sub delete(ByVal inData As exampleRegisterRequest, ByRef outData As exampleRegisterResponse)
        Dim result As Integer
        Dim msg As String               '���b�Z�[�W
        Dim inDataSearch As New exampleSearchRequest
        Dim outDataSearch As New exampleSearchResponse

        myexampleDA = New exampleDA(Me.myUserSession)
        '�[�����ID
        Me.myexampleDA.IdPurchase = CStr(inData.IdPurchase)
        '�폜����
        Me.myexampleDA.UdDate = inData.UdDate

        result = myexampleDA.deleteFile()

        '�G���[�t���O��ݒ�
        outData.ErrFlag = result

        '�G���[���O�o��
        If result = AgnConst.DAReturnValue.NoInput Then
            '�p�����[�^�G���[
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-02")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        ElseIf result = AgnConst.DAReturnValue.Haita Then
            '�����[�U�̑���ɂ��A���i��{��񂪕ύX����Ă��܂��B�ēx�������A������s���ĉ������B
            msg = AgnMsg.GetMessage(MyBase.myUserSession.LanguageId, "SYE0000-09")
            outData.ErrorList.Add(msg)
            AgnLog.Err(MyBase.myUserSession, msg)
            '�G���[�t���O��ݒ�
            outData.ErrFlag = -23
            MyBase.RollBack(CType(inData, DTOBase))
            Me.myexampleDA = Nothing
            Return
        End If

        Me.myexampleDA = Nothing

    End Sub
#End Region

End Class
