using System;
using System.Data;
using System.Configuration;

namespace schagr.db.model
{
    /// <summary>
    /// exampleGroupModel �̃��f����`
    /// </summary>
    public class exampleGroupModel
    {
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public exampleGroupModel()
        {
        }

        private String idChemicalGroup;
        private String cdChemicalGroup;
        private String flgUnused;
        private String cUid;
        private String cDate;
        private String udUid;
        private String udDate;

		//where��ł̔�r���Z�q��ێ�����t�B�[���h
		private String idChemicalGroupOperand = "=";
		private String cdChemicalGroupOperand = "=";
		private String flgUnusedOperand = "=";
		private String cUidOperand = "=";
		private String cDateOperand = "=";
		private String udUidOperand = "=";
		private String udDateOperand = "=";

        public String IdChemicalGroup
        {
            get
            {
                return this.idChemicalGroup;
            }
            set
            {
                this.idChemicalGroup = value;
            }
        }
        public String CdChemicalGroup
        {
            get
            {
                return this.cdChemicalGroup;
            }
            set
            {
                this.cdChemicalGroup = value;
            }
        }
        public String FlgUnused
        {
            get
            {
                return this.flgUnused;
            }
            set
            {
                this.flgUnused = value;
            }
        }
        public String CUid
        {
            get
            {
                return this.cUid;
            }
            set
            {
                this.cUid = value;
            }
        }
        public String CDate
        {
            get
            {
                return this.cDate;
            }
            set
            {
                this.cDate = value;
            }
        }
        public String UdUid
        {
            get
            {
                return this.udUid;
            }
            set
            {
                this.udUid = value;
            }
        }
        public String UdDate
        {
            get
            {
                return this.udDate;
            }
            set
            {
                this.udDate = value;
            }
        }

		/// <summary>
        /// �������ł̔�r���Z�q��ݒ肵�܂��B
		/// �����ݒ肵�Ȃ��ꍇ�͏]���ǂ��� = �ŕ]�����܂��B
        /// </summary>
        public String IdChemicalGroupOperand
        {
        	get
            {
                return this.idChemicalGroupOperand;
            }
            set
            {
                this.idChemicalGroupOperand = value;
            }

        }
		/// <summary>
        /// �������ł̔�r���Z�q��ݒ肵�܂��B
		/// �����ݒ肵�Ȃ��ꍇ�͏]���ǂ��� = �ŕ]�����܂��B
        /// </summary>
        public String CdChemicalGroupOperand
        {
        	get
            {
                return this.cdChemicalGroupOperand;
            }
            set
            {
                this.cdChemicalGroupOperand = value;
            }

        }
		/// <summary>
        /// �������ł̔�r���Z�q��ݒ肵�܂��B
		/// �����ݒ肵�Ȃ��ꍇ�͏]���ǂ��� = �ŕ]�����܂��B
        /// </summary>
        public String FlgUnusedOperand
        {
        	get
            {
                return this.flgUnusedOperand;
            }
            set
            {
                this.flgUnusedOperand = value;
            }

        }
		/// <summary>
        /// �������ł̔�r���Z�q��ݒ肵�܂��B
		/// �����ݒ肵�Ȃ��ꍇ�͏]���ǂ��� = �ŕ]�����܂��B
        /// </summary>
        public String CUidOperand
        {
        	get
            {
                return this.cUidOperand;
            }
            set
            {
                this.cUidOperand = value;
            }

        }
		/// <summary>
        /// �������ł̔�r���Z�q��ݒ肵�܂��B
		/// �����ݒ肵�Ȃ��ꍇ�͏]���ǂ��� = �ŕ]�����܂��B
        /// </summary>
        public String CDateOperand
        {
        	get
            {
                return this.cDateOperand;
            }
            set
            {
                this.cDateOperand = value;
            }

        }
		/// <summary>
        /// �������ł̔�r���Z�q��ݒ肵�܂��B
		/// �����ݒ肵�Ȃ��ꍇ�͏]���ǂ��� = �ŕ]�����܂��B
        /// </summary>
        public String UdUidOperand
        {
        	get
            {
                return this.udUidOperand;
            }
            set
            {
                this.udUidOperand = value;
            }

        }
		/// <summary>
        /// �������ł̔�r���Z�q��ݒ肵�܂��B
		/// �����ݒ肵�Ȃ��ꍇ�͏]���ǂ��� = �ŕ]�����܂��B
        /// </summary>
        public String UdDateOperand
        {
        	get
            {
                return this.udDateOperand;
            }
            set
            {
                this.udDateOperand = value;
            }

        }

    }
}