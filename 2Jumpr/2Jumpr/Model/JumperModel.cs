using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _2Jumpr.Model
{
    [DataContract(Name="J")]
    public class JumperModel
    {
        string dateTime;
        /// <summary>
        /// 時間
        /// </summary>
        [DataMember(Name = "d")]
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        string path;
        /// <summary>
        /// URi
        /// </summary>
        [DataMember(Name="p")]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
