using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using example.db.model;
using example.db.exception;
using commons4.db;


//SQL文自動生成プログラム(c#)
namespace example.db.dao
{
    /// <summary>
    /// データアクセスクラス
    /// </summary>
    public abstract class AbstractMChemicalDao
    {
    	//検索カラムの変数
    	private String columnList = null;

		/// <summary>
        /// 検索カラムの設定
        /// </summary>
        public void setColumnList(String columnList)
        {
            this.columnList = columnList;
        }

        /// <summary>
        /// 指定した条件のデータをDataSet型で返却するメソッド
        /// </summary>
        public DataSet select(SqlCommand cmd, MChemicalModel condition, String otherCondition, String orderCondition)
        {
			cmd.Parameters.Clear();
            //SQL本体と条件部を結合する。
            cmd.CommandText = getQueryText(cmd, condition, otherCondition, orderCondition);
            DataSet ds = new DataSet();
            SqlDataAdapter oda = new SqlDataAdapter(cmd);
            oda.Fill(ds);
            return ds;
        }


        /// <summary>
        /// 実行するSQL文を生成するメソッド
        /// </summary>
        private String getQueryText(SqlCommand cmd, MChemicalModel condition, String otherCondition, String orderCondition)
        {
            String sqlText = "select id_chemical,cas_no,cas_no_retrieval_string,flg_unused,c_uid,c_date,ud_uid,ud_date from m_chemical";
			if (this.columnList != null)
            {
                sqlText = "select " + this.columnList + " from m_chemical";
            }
            sqlText = sqlText + this.createCondition(condition, otherCondition, cmd) + " " + orderCondition;
            return sqlText.ToUpper();
        }

        /// <summary>
        /// 指定した条件のデータ件数を返却するメソッド
        /// </summary>
        public int count(SqlCommand cmd, MChemicalModel condition, String otherCondition)
        {
			cmd.Parameters.Clear();
            String sqlText = "select count(*) from m_chemical";
            //SQL本体と条件部を結合する。
            cmd.CommandText = sqlText + this.createCondition(condition, otherCondition, cmd);
            DataSet ds = new DataSet();
            SqlDataAdapter oda = new SqlDataAdapter(cmd);
            oda.Fill(ds);
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }


        /// <summary>
        /// 指定した条件のデータを削除するメソッド
        /// </summary>
        public int delete(SqlCommand cmd, MChemicalModel condition, String otherCondition)
        {
        	cmd.Parameters.Clear();
            String sqlText = "delete from m_chemical";
            //SQL本体と条件部を結合する。
            cmd.CommandText = sqlText + this.createCondition(condition, otherCondition, cmd);
            int delCnt = cmd.ExecuteNonQuery();
            return delCnt;
        }

        /// <summary>
        /// データ挿入するメソッド
        /// </summary>
        public int insert(SqlCommand cmd, MChemicalModel value)
        {
        	cmd.Parameters.Clear();
            if (value == null)
            {
                throw new NullReferenceException("insert処理なのにNullオブジェクト設定はダメダメです。");
            }
            String sqlText = "insert into m_chemical ";
            Boolean isStarted = false;
            StringBuilder colSb = new StringBuilder();
            StringBuilder valSb = new StringBuilder();

            //値があったら
            if (value.IdChemical != null)
            {
               //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    //書き込み開始ステータスにする。
                    isStarted = true;
                    //開始文字列を設定する。
                    colSb.Append(" ( ");
                    valSb.Append(" values ( ");
                }
                else
                {
                    colSb.Append(" , ");
                    valSb.Append(" , ");
                }
                colSb.Append(" id_chemical ");
                valSb.Append(" nullif(@id_chemical,'') ");
                cmd.Parameters.Add(new SqlParameter("@ID_CHEMICAL", value.IdChemical));
            }
            //値があったら
            if (value.CasNo != null)
            {
               //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    //書き込み開始ステータスにする。
                    isStarted = true;
                    //開始文字列を設定する。
                    colSb.Append(" ( ");
                    valSb.Append(" values ( ");
                }
                else
                {
                    colSb.Append(" , ");
                    valSb.Append(" , ");
                }
                colSb.Append(" cas_no ");
                valSb.Append(" nullif(@cas_no,'') ");
                cmd.Parameters.Add(new SqlParameter("@CAS_NO", value.CasNo));
            }
            //値があったら
            if (value.CasNoRetrievalString != null)
            {
               //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    //書き込み開始ステータスにする。
                    isStarted = true;
                    //開始文字列を設定する。
                    colSb.Append(" ( ");
                    valSb.Append(" values ( ");
                }
                else
                {
                    colSb.Append(" , ");
                    valSb.Append(" , ");
                }
                colSb.Append(" cas_no_retrieval_string ");
                valSb.Append(" nullif(@cas_no_retrieval_string,'') ");
                cmd.Parameters.Add(new SqlParameter("@CAS_NO_RETRIEVAL_STRING", value.CasNoRetrievalString));
            }
            //値があったら
            if (value.FlgUnused != null)
            {
               //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    //書き込み開始ステータスにする。
                    isStarted = true;
                    //開始文字列を設定する。
                    colSb.Append(" ( ");
                    valSb.Append(" values ( ");
                }
                else
                {
                    colSb.Append(" , ");
                    valSb.Append(" , ");
                }
                colSb.Append(" flg_unused ");
                valSb.Append(" nullif(@flg_unused,'') ");
                cmd.Parameters.Add(new SqlParameter("@FLG_UNUSED", value.FlgUnused));
            }
            //値があったら
            if (value.CUid != null)
            {
               //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    //書き込み開始ステータスにする。
                    isStarted = true;
                    //開始文字列を設定する。
                    colSb.Append(" ( ");
                    valSb.Append(" values ( ");
                }
                else
                {
                    colSb.Append(" , ");
                    valSb.Append(" , ");
                }
                colSb.Append(" c_uid ");
                valSb.Append(" nullif(@c_uid,'') ");
                cmd.Parameters.Add(new SqlParameter("@C_UID", value.CUid));
            }
            //値があったら
            if (value.CDate != null)
            {
                if (OraDateTypeConverter.convert(value.CDate) != null) {
                    //まだ書きはじめていなかったら
                    if (!isStarted)
                    {
                        //書き込み開始ステータスにする。
                        isStarted = true;
                        //開始文字列を設定する。
                        colSb.Append(" ( ");
                        valSb.Append(" values ( ");
                    }
                    else
                    {
                        colSb.Append(" , ");
                        valSb.Append(" , ");
                    }
                    colSb.Append(" c_date ");
                    valSb.Append(" ").Append(OraDateTypeConverter.convert(value.CDate)).Append(" ");
                }
            }
            //値があったら
            if (value.UdUid != null)
            {
               //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    //書き込み開始ステータスにする。
                    isStarted = true;
                    //開始文字列を設定する。
                    colSb.Append(" ( ");
                    valSb.Append(" values ( ");
                }
                else
                {
                    colSb.Append(" , ");
                    valSb.Append(" , ");
                }
                colSb.Append(" ud_uid ");
                valSb.Append(" nullif(@ud_uid,'') ");
                cmd.Parameters.Add(new SqlParameter("@UD_UID", value.UdUid));
            }
            //値があったら
            if (value.UdDate != null)
            {
                if (OraDateTypeConverter.convert(value.UdDate) != null) {
                    //まだ書きはじめていなかったら
                    if (!isStarted)
                    {
                        //書き込み開始ステータスにする。
                        isStarted = true;
                        //開始文字列を設定する。
                        colSb.Append(" ( ");
                        valSb.Append(" values ( ");
                    }
                    else
                    {
                        colSb.Append(" , ");
                        valSb.Append(" , ");
                    }
                    colSb.Append(" ud_date ");
                    valSb.Append(" ").Append(OraDateTypeConverter.convert(value.UdDate)).Append(" ");
                }
            }

            //何かしら値の設定がある場合
            if (!isStarted)
            {
                //何も設定されていない場合。
                throw new GenerateDbException("Insert処理でパラメータが何も設定されていません。");
            }

            //閉じ括弧をいれる。
            colSb.Append(" ) ");
            valSb.Append(" ) ");

            //SQL本体と条件部を結合する。
            cmd.CommandText = sqlText + colSb.ToString() + valSb.ToString();

            int insCnt = cmd.ExecuteNonQuery();
            return insCnt;
        }


        /// <summary>
        /// データ更新するメソッド
        /// </summary>
        public int update(SqlCommand cmd, MChemicalModel condition, MChemicalModel value, String otherCondition)
        {
            if (value == null)
            {
                throw new NullReferenceException("update処理なのにNullオブジェクト設定はダメダメです。");
            }
            String sqlText = "update m_chemical set";
            Boolean isStarted = false;
            StringBuilder valSb = new StringBuilder();

            cmd.Parameters.Clear();

            //値があったら
            if (value.IdChemical != null)
            {
                //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    isStarted = true;
                }
                else
                {
                    valSb.Append(" , ");
                }
                valSb.Append(" id_chemical = nullif(@v_id_chemical,'') ");
                cmd.Parameters.Add(new SqlParameter("@V_ID_CHEMICAL", value.IdChemical));
            }
            //値があったら
            if (value.CasNo != null)
            {
                //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    isStarted = true;
                }
                else
                {
                    valSb.Append(" , ");
                }
                valSb.Append(" cas_no = nullif(@v_cas_no,'') ");
                cmd.Parameters.Add(new SqlParameter("@V_CAS_NO", value.CasNo));
            }
            //値があったら
            if (value.CasNoRetrievalString != null)
            {
                //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    isStarted = true;
                }
                else
                {
                    valSb.Append(" , ");
                }
                valSb.Append(" cas_no_retrieval_string = nullif(@v_cas_no_retrieval_string,'') ");
                cmd.Parameters.Add(new SqlParameter("@V_CAS_NO_RETRIEVAL_STRING", value.CasNoRetrievalString));
            }
            //値があったら
            if (value.FlgUnused != null)
            {
                //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    isStarted = true;
                }
                else
                {
                    valSb.Append(" , ");
                }
                valSb.Append(" flg_unused = nullif(@v_flg_unused,'') ");
                cmd.Parameters.Add(new SqlParameter("@V_FLG_UNUSED", value.FlgUnused));
            }
            //値があったら
            if (value.CUid != null)
            {
                //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    isStarted = true;
                }
                else
                {
                    valSb.Append(" , ");
                }
                valSb.Append(" c_uid = nullif(@v_c_uid,'') ");
                cmd.Parameters.Add(new SqlParameter("@V_C_UID", value.CUid));
            }
            //値があったら
            if (value.CDate != null)
            {
                if (OraDateTypeConverter.convert(value.CDate) != null) {
                    //まだ書きはじめていなかったら
                    if (!isStarted)
                    {
                        isStarted = true;
                    }
                    else
                    {
                        valSb.Append(" , ");
                    }
                    valSb.Append(" c_date = ").Append(OraDateTypeConverter.convert(value.CDate));
                }
                else if ("".Equals(value.CDate))
                {
                	//まだ書きはじめていなかったら
               		if (!isStarted)
	                {
	                    isStarted = true;
	                }
	                else
	                {
	                    valSb.Append(" , ");
	                }
	                valSb.Append(" c_date = nullif(@v_c_date,'') ");

	                cmd.Parameters.Add(new SqlParameter("@V_C_DATE", value.CDate));
                }
            }
            //値があったら
            if (value.UdUid != null)
            {
                //まだ書きはじめていなかったら
                if (!isStarted)
                {
                    isStarted = true;
                }
                else
                {
                    valSb.Append(" , ");
                }
                valSb.Append(" ud_uid = nullif(@v_ud_uid,'') ");
                cmd.Parameters.Add(new SqlParameter("@V_UD_UID", value.UdUid));
            }
            //値があったら
            if (value.UdDate != null)
            {
                if (OraDateTypeConverter.convert(value.UdDate) != null) {
                    //まだ書きはじめていなかったら
                    if (!isStarted)
                    {
                        isStarted = true;
                    }
                    else
                    {
                        valSb.Append(" , ");
                    }
                    valSb.Append(" ud_date = ").Append(OraDateTypeConverter.convert(value.UdDate));
                }
                else if ("".Equals(value.UdDate))
                {
                	//まだ書きはじめていなかったら
               		if (!isStarted)
	                {
	                    isStarted = true;
	                }
	                else
	                {
	                    valSb.Append(" , ");
	                }
	                valSb.Append(" ud_date = nullif(@v_ud_date,'') ");

	                cmd.Parameters.Add(new SqlParameter("@V_UD_DATE", value.UdDate));
                }
            }

            //何も設定されていない場合。
            if (!isStarted)
            {
                throw new GenerateDbException("Update処理でパラメータが何も設定されていません。");
            }


            //SQL本体と条件部を結合する。
            cmd.CommandText = sqlText + valSb.ToString() + this.createCondition(condition, otherCondition, cmd);

            int updCnt = cmd.ExecuteNonQuery();
            return updCnt;
        }

        /// <summary>
        /// 条件部文字列を生成するメソッド
        /// </summary>
        private String createCondition(MChemicalModel condition, String otherCondition, SqlCommand cmd)
        {
            String wherestr = " where ";
            StringBuilder sb = new StringBuilder();

            if (condition != null && ( condition.IdChemical != null || condition.CasNo != null || condition.CasNoRetrievalString != null || condition.FlgUnused != null || condition.CUid != null || condition.CDate != null || condition.UdUid != null || condition.UdDate != null ) || otherCondition != null)
            {
                sb.Append(wherestr);
            }

            //検索条件が入力されている場合
            if (condition != null && ( condition.IdChemical != null || condition.CasNo != null || condition.CasNoRetrievalString != null || condition.FlgUnused != null || condition.CUid != null || condition.CDate != null || condition.UdUid != null || condition.UdDate != null ))
            {

                if (condition.IdChemical != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.IdChemical == "null")
                    {
                        sb.Append(" id_chemical is null");
                    }
                    else if ((String)condition.IdChemical == "")
                    {
                        sb.Append(" id_chemical = null");
                    }
                    else
                    {
                        sb.Append(" id_chemical " + condition.IdChemicalOperand + " @id_chemical ");
                        cmd.Parameters.Add(new SqlParameter("@ID_CHEMICAL", condition.IdChemical));
                    }
                }
                if (condition.CasNo != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.CasNo == "null")
                    {
                        sb.Append(" cas_no is null");
                    }
                    else if ((String)condition.CasNo == "")
                    {
                        sb.Append(" cas_no = null");
                    }
                    else
                    {
                        sb.Append(" cas_no " + condition.CasNoOperand + " @cas_no ");
                        cmd.Parameters.Add(new SqlParameter("@CAS_NO", condition.CasNo));
                    }
                }
                if (condition.CasNoRetrievalString != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.CasNoRetrievalString == "null")
                    {
                        sb.Append(" cas_no_retrieval_string is null");
                    }
                    else if ((String)condition.CasNoRetrievalString == "")
                    {
                        sb.Append(" cas_no_retrieval_string = null");
                    }
                    else
                    {
                        sb.Append(" cas_no_retrieval_string " + condition.CasNoRetrievalStringOperand + " @cas_no_retrieval_string ");
                        cmd.Parameters.Add(new SqlParameter("@CAS_NO_RETRIEVAL_STRING", condition.CasNoRetrievalString));
                    }
                }
                if (condition.FlgUnused != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.FlgUnused == "null")
                    {
                        sb.Append(" flg_unused is null");
                    }
                    else if ((String)condition.FlgUnused == "")
                    {
                        sb.Append(" flg_unused = null");
                    }
                    else
                    {
                        sb.Append(" flg_unused " + condition.FlgUnusedOperand + " @flg_unused ");
                        cmd.Parameters.Add(new SqlParameter("@FLG_UNUSED", condition.FlgUnused));
                    }
                }
                if (condition.CUid != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.CUid == "null")
                    {
                        sb.Append(" c_uid is null");
                    }
                    else if ((String)condition.CUid == "")
                    {
                        sb.Append(" c_uid = null");
                    }
                    else
                    {
                        sb.Append(" c_uid " + condition.CUidOperand + " @c_uid ");
                        cmd.Parameters.Add(new SqlParameter("@C_UID", condition.CUid));
                    }
                }
                if (condition.CDate != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.CDate == "null")
                    {
                        sb.Append(" c_date is null");
                    }
                    else if ((String)condition.CDate == "")
                    {
                        sb.Append(" c_date = null");
                    }
                    else
                    {
                        sb.Append(" c_date " + condition.CDateOperand + " @c_date ");
                        cmd.Parameters.Add(new SqlParameter("@C_DATE", condition.CDate));
                    }
                }
                if (condition.UdUid != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.UdUid == "null")
                    {
                        sb.Append(" ud_uid is null");
                    }
                    else if ((String)condition.UdUid == "")
                    {
                        sb.Append(" ud_uid = null");
                    }
                    else
                    {
                        sb.Append(" ud_uid " + condition.UdUidOperand + " @ud_uid ");
                        cmd.Parameters.Add(new SqlParameter("@UD_UID", condition.UdUid));
                    }
                }
                if (condition.UdDate != null)
                {
                    //where条件が既に設定されている場合
                    if (sb.ToString() != wherestr)
                    {
                        sb.Append(" and ");
                    }

                    if ((String)condition.UdDate == "null")
                    {
                        sb.Append(" ud_date is null");
                    }
                    else if ((String)condition.UdDate == "")
                    {
                        sb.Append(" ud_date = null");
                    }
                    else
                    {
                        sb.Append(" ud_date " + condition.UdDateOperand + " @ud_date ");
                        cmd.Parameters.Add(new SqlParameter("@UD_DATE", condition.UdDate));
                    }
                }
            }
            //その他条件を設定する。
            if (otherCondition != null)
            {
                //where条件が既に設定されている場合
                if (sb.ToString() != wherestr)
                {
                    sb.Append(" and ");
                }
                sb.Append(" ").Append(otherCondition);
            }
            return sb.ToString().ToUpper();
        }
    }
}
