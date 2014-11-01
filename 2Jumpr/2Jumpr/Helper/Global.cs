using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verne.StorageManager
{

    public class Global
    {
        /// <summary>
        /// 本地文件夹根目录
        /// </summary>
        internal static Windows.Storage.StorageFolder rootDirctory = Windows.Storage.ApplicationData.Current.LocalFolder;
        /// <summary>
        /// 安装目录根目录
        /// </summary>
        internal static Windows.Storage.StorageFolder installedLocationDirctory = Windows.ApplicationModel.Package.Current.InstalledLocation;
    }
}
