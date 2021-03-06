using System;
using System.Data;
using System.Configuration;

namespace schagr.db.model
{
    /// <summary>
    /// exampleGroupModel のモデル定義
    /// </summary>
    public class exampleGroupModel
    {
        /// <summary>
        /// デフォルトコンストラクタ
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

		//where句での比較演算子を保持するフィールド
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
        /// 条件式での比較演算子を設定します。
		/// 何も設定しない場合は従来どおり = で評価します。
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
        /// 条件式での比較演算子を設定します。
		/// 何も設定しない場合は従来どおり = で評価します。
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
        /// 条件式での比較演算子を設定します。
		/// 何も設定しない場合は従来どおり = で評価します。
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
        /// 条件式での比較演算子を設定します。
		/// 何も設定しない場合は従来どおり = で評価します。
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
        /// 条件式での比較演算子を設定します。
		/// 何も設定しない場合は従来どおり = で評価します。
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
        /// 条件式での比較演算子を設定します。
		/// 何も設定しない場合は従来どおり = で評価します。
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
        /// 条件式での比較演算子を設定します。
		/// 何も設定しない場合は従来どおり = で評価します。
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