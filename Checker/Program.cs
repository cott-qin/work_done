using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using csrCommons;
//2019/12/25 OracleからSQL版変更　START
//using Oracle.DataAccess.Client;
using System.Data.SqlClient;
//2019/12/25 OracleからSQL版変更　END
using schagr.db.dao;
using schagr.db.model;

namespace ResourceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                ResourceInfo ri = new ResourceInfo();

                String keyword  = "Agr";
                String userId = "";
                String password = "";
                String dataSorce = "";

                int returnValue = CommonClass.GetOracleConnectionInfomation(keyword, ref userId, ref password, ref dataSorce);
                if (returnValue != 0)
                {
                    throw new Exception("DB接続でエラーが発生しました。詳細不明");
                }


                //2019/12/25 OracleからSQL版変更　START
                //using (OracleConnection connection = new OracleConnection("User Id=" + userId + ";Password=" + password + ";Data Source=" + dataSorce))
                dataSorce = dataSorce.Replace(";", ";Initial Catalog=");
                using (SqlConnection connection = new SqlConnection("User Id=" + userId + ";Password=" + password + ";Data Source=" + dataSorce + ";Persist Security Info=True"))
                {
                    //using (OracleCommand cmd = connection.CreateCommand())
                    using (SqlCommand cmd = connection.CreateCommand())
                    //2019/12/25 OracleからSQL版変更　END
                    {
                        connection.Open();

                        TServerResourceInfoDao dao = new TServerResourceInfoDao();
                        TServerResourceInfoModel model = new TServerResourceInfoModel();
                        model.RegistDate = DateTime.Now.ToString();
                        model.ServerName = Dns.GetHostName();
                        model.CpuUsageRate = Convert.ToString(ri.getCpuUsagePer());
                        model.MemoryUsageRate = Convert.ToString(ri.getMemoryUsagePer());

                        foreach (OwnDriveInfo odi in ri.getDriveInfoList())
                        {
                            switch (odi.getDriveName())
                            {
                                case "C":
                                    model.CDriveUsageRate = Convert.ToString(odi.getDriveUsagePer());
                                    break;
                                case "D":
                                    model.DDriveUsageRate = Convert.ToString(odi.getDriveUsagePer());
                                    break;
                                case "G":
                                    model.GDriveUsageRate = Convert.ToString(odi.getDriveUsagePer());
                                    break;
                                case "H":
                                    model.HDriveUsageRate = Convert.ToString(odi.getDriveUsagePer());
                                    break;
                                case "W":
                                    model.WDriveUsageRate = Convert.ToString(odi.getDriveUsagePer());
                                    break;
                            }
                        }
                        dao.insert(cmd, model);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine("異常が発生しました。");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                LogClass.WriteErrorLog("E", "共通 サーバリソース監視", "XXXXXX", "XXXX", 99, "エラー発生サーバ：" + Dns.GetHostName() + "　エラー内容：" + e.Message);
            }
            if (args.Length > 0)
            {
                if ("pause".Equals(args[0]))
                {
                    Console.WriteLine("press enter key...");
                    Console.ReadLine();
                }
            }

        }
    }
}
