using System;
using System.Data;
using System.Configuration;

namespace schagr.db.model
{
    /// <summary>
    /// exampleGroupModel ‚Ìƒ‚ƒfƒ‹’è‹`
    /// </summary>
    public class exampleGroupModel
    {
        /// <summary>
        /// ƒfƒtƒHƒ‹ƒgƒRƒ“ƒXƒgƒ‰ƒNƒ^
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

		//where‹å‚Å‚Ì”äŠr‰‰Zq‚ğ•Û‚·‚éƒtƒB[ƒ‹ƒh
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
        /// ğŒ®‚Å‚Ì”äŠr‰‰Zq‚ğİ’è‚µ‚Ü‚·B
		/// ‰½‚àİ’è‚µ‚È‚¢ê‡‚Í]—ˆ‚Ç‚¨‚è = ‚Å•]‰¿‚µ‚Ü‚·B
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
        /// ğŒ®‚Å‚Ì”äŠr‰‰Zq‚ğİ’è‚µ‚Ü‚·B
		/// ‰½‚àİ’è‚µ‚È‚¢ê‡‚Í]—ˆ‚Ç‚¨‚è = ‚Å•]‰¿‚µ‚Ü‚·B
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
        /// ğŒ®‚Å‚Ì”äŠr‰‰Zq‚ğİ’è‚µ‚Ü‚·B
		/// ‰½‚àİ’è‚µ‚È‚¢ê‡‚Í]—ˆ‚Ç‚¨‚è = ‚Å•]‰¿‚µ‚Ü‚·B
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
        /// ğŒ®‚Å‚Ì”äŠr‰‰Zq‚ğİ’è‚µ‚Ü‚·B
		/// ‰½‚àİ’è‚µ‚È‚¢ê‡‚Í]—ˆ‚Ç‚¨‚è = ‚Å•]‰¿‚µ‚Ü‚·B
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
        /// ğŒ®‚Å‚Ì”äŠr‰‰Zq‚ğİ’è‚µ‚Ü‚·B
		/// ‰½‚àİ’è‚µ‚È‚¢ê‡‚Í]—ˆ‚Ç‚¨‚è = ‚Å•]‰¿‚µ‚Ü‚·B
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
        /// ğŒ®‚Å‚Ì”äŠr‰‰Zq‚ğİ’è‚µ‚Ü‚·B
		/// ‰½‚àİ’è‚µ‚È‚¢ê‡‚Í]—ˆ‚Ç‚¨‚è = ‚Å•]‰¿‚µ‚Ü‚·B
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
        /// ğŒ®‚Å‚Ì”äŠr‰‰Zq‚ğİ’è‚µ‚Ü‚·B
		/// ‰½‚àİ’è‚µ‚È‚¢ê‡‚Í]—ˆ‚Ç‚¨‚è = ‚Å•]‰¿‚µ‚Ü‚·B
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