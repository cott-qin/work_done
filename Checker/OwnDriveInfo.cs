using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceChecker
{
    public class OwnDriveInfo
    {
        /// <summary>
        /// ドライブ名
        /// </summary>
        private String driveName;

        /// <summary>
        /// 全体のサイズ
        /// </summary>
        private Double totalSize;

        /// <summary>
        /// 空いているサイズ
        /// </summary>
        private Double totalFreeSpace;

        /// <summary>
        /// ドライブの利用率
        /// </summary>
        private Double driveUsagePer;

        /// <summary>
        /// プライベートコンストラクタ
        /// </summary>
        private OwnDriveInfo()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="driveName"></param>
        /// <param name="totalSize"></param>
        /// <param name="totalFreeSpace"></param>
        public OwnDriveInfo(String driveName, long totalSize, long totalFreeSpace)
        {
            this.driveName = driveName;
            this.totalSize = convertB2Gb(totalSize);
            this.totalFreeSpace = convertB2Gb(totalFreeSpace);
            //全体容量と空き容量から利用率を算出設定
            this.driveUsagePer = Math.Round(Convert.ToDouble((1 - (this.totalFreeSpace / this.totalSize)) * 100), 2);
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ドライブ名:").Append(driveName).Append(" ");
            sb.Append("全体のサイズ:").Append(totalSize).Append("GB").Append(" ");
            sb.Append("空いているサイズ:").Append(totalFreeSpace).Append("GB").Append(" ");
            sb.Append("ドライブの利用率:").Append(driveUsagePer).Append("%");
            return sb.ToString();
        }

        /// <summary>
        /// バイト数をギガバイト数に変換するメソッド
        /// </summary>
        /// <param name="value">バイト数</param>
        /// <returns>ギガバイト数</returns>
        private Double convertB2Gb(long value)
        {
            return Math.Round(Convert.ToDouble(value / (1024 * 1024 * 1024)), 2);
        }


        public String getDriveName()
        {
            return driveName;
        }

        public Double getDriveUsagePer()
        {
            return driveUsagePer;
        }

    }
}
