using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceChecker
{
    class ResourceInfo
    {
        /// <summary>
        /// CPU利用率
        /// </summary>
        private Double cpuUsagePer;
        /// <summary>
        /// メモリ利用率
        /// </summary>
        private Double memoryUsagePer;
        /// <summary>
        /// ドライブ利用状況リスト
        /// </summary>
        private List<OwnDriveInfo> driveInfoList;

        /// <summary>
        /// デフォルト コンストラクタ
        /// </summary>
        public ResourceInfo()
        {
            Console.WriteLine("CPU利用率取得 start " + DateTime.Now.ToString());
            this.cpuUsagePer = calculateCpuUsagePer();
            Console.WriteLine("CPU利用率取得 end" + DateTime.Now.ToString());
            Console.WriteLine("メモリ利用率取得 start" + DateTime.Now.ToString());
            this.memoryUsagePer = calculateMemoryUsagePer();
            Console.WriteLine("メモリ利用率取得 end" + DateTime.Now.ToString());
            Console.WriteLine("ドライブ利用状況取得 start" + DateTime.Now.ToString());
            this.driveInfoList = calculateDriveInfoList();
            Console.WriteLine("ドライブ利用状況取得 end" + DateTime.Now.ToString());
        }

        /// <summary>
        /// クラス内情報文字列表現を返却するメソッド
        /// </summary>
        /// <returns>クラス内情報文字列表現</returns>
        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CPU利用率:").Append(cpuUsagePer).Append("%").Append("\r\n");
            sb.Append("メモリ利用率:").Append(memoryUsagePer).Append("%").Append("\r\n");

            sb.Append("ドライブ利用状況:").Append("\r\n");
            foreach (OwnDriveInfo ownDriveInfo in driveInfoList)
            {
                sb.Append(ownDriveInfo.toString()).Append("\r\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// CPU利用率を返却するメソッド
        /// </summary>
        /// <returns>CPU利用率</returns>
        public Double getCpuUsagePer()
        {
            return this.cpuUsagePer;
        }

        /// <summary>
        /// メモリ利用率を返却するメソッド
        /// </summary>
        /// <returns>メモリ利用率</returns>
        public Double getMemoryUsagePer()
        {
            return this.memoryUsagePer;
        }

        /// <summary>
        /// ドライブ利用状況リストを返却するメソッド
        /// </summary>
        /// <returns>ドライブ利用状況リスト</returns>
        public List<OwnDriveInfo> getDriveInfoList()
        {
            return this.driveInfoList;
        }
        
        /// <summary>
        /// CPU利用率を返却するメソッド
        /// 全てのプロセッサから一秒毎に5回利用率を取得し利用率が最大の率を返却する。
        /// </summary>
        /// <returns>CPU利用率</returns>
        private Double calculateCpuUsagePer()
        {
            Double maxCpuUsagePer = 0D;     //最大CPU利用率を保持する変数
            int checkCount = 5;             //計測回数を保持する変数

            // プロセッサ数分のPerformanceCounterを格納する配列
            var pcs = new PerformanceCounter[Environment.ProcessorCount];

            for (var index = 0; index < pcs.Length; index++)
            {
                // プロセッサ毎の使用率を計測するPerformanceCounterを作成
                pcs[index] = new PerformanceCounter("Processor", "% Processor Time", index.ToString());
            }

            for (int i = 0; i < checkCount; i++)
            {
                foreach (var pc in pcs)
                {
                    Double currentValue = pc.NextValue() / 100.0f;

                    if (currentValue > maxCpuUsagePer) {
                        maxCpuUsagePer = currentValue;
                    }

                    //Console.Write("{0,8:P2} ", currentValue);
                }
                //Console.WriteLine();
                
                Thread.Sleep(1000);
            }
            return Math.Round(maxCpuUsagePer * 100,2);

        }

        /// <summary>
        /// メモリ使用率を返却するメソッド
        /// </summary>
        /// <returns>メモリ使用率</returns>
        private Double calculateMemoryUsagePer()
        {
            Double totalVisibleMemorySize = 0D;
            Double freePhysicalMemory = 0D;

            using (ManagementClass mc = new ManagementClass("Win32_OperatingSystem"))
            {
                using (ManagementObjectCollection moc = mc.GetInstances())
                {
                    foreach (System.Management.ManagementObject mo in moc)
                    {
                        totalVisibleMemorySize = Convert.ToDouble(mo["TotalVisibleMemorySize"]);
                        freePhysicalMemory = Convert.ToDouble(mo["FreePhysicalMemory"]);
                        mo.Dispose();
                    }
                }
            }
            return Math.Round((1 - (freePhysicalMemory / totalVisibleMemorySize)) * 100, 2);        
        }

        /// <summary>
        /// ドライブ情報(利用量、総量)を返却するメソッド
        /// </summary>
        /// <returns>ドライブ情報(利用量、総量)</returns>
        private List<OwnDriveInfo> calculateDriveInfoList()
        {
            driveInfoList = new List<OwnDriveInfo>();

            String[] drives = Directory.GetLogicalDrives();

            foreach (String driveName in drives) {
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(driveName);

                //固定ディスクの場合
                if (driveInfo.DriveType == System.IO.DriveType.Fixed)
                {
                    //ドライブの準備ができているか調べる
                    if (driveInfo.IsReady)
                    {
                        OwnDriveInfo ownDriveInfo = new OwnDriveInfo(driveName.Substring(0,1), driveInfo.TotalSize, driveInfo.TotalFreeSpace);
                        driveInfoList.Add(ownDriveInfo);
                    }
                }
            }
            return driveInfoList;
        }
    }
}
