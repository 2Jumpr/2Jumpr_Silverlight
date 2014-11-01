
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Verne.StorageManager
{
    /// <summary>
    /// 臨時在Jumper使用，不支持Floder
    /// </summary>
    public class FileManager
    {

        public static async Task<StorageFile> GetFile(string path)
        {
            try
            {
                StorageFile file = await Global.rootDirctory.GetFileAsync(path);

                return file;
            }
            catch (Exception ex) //FileNotFoundException)
            {
                return null;
            }
        }
        public static async Task<StorageFile> CreateFile(string path, IBuffer buffer)
        {
            StorageFile file = await Global.rootDirctory.CreateFileAsync(path, CreationCollisionOption.OpenIfExists);

            using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await stream.WriteAsync(buffer);
            }
            return file;
        }
        public static async Task<StorageFile> IsExistsFile(string fileName, StorageFolder folder = null)
        {
            folder = folder ?? Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                return await folder.GetFileAsync(fileName);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static async Task<bool> RemoveFile(string fileName, StorageFolder folder = null)
        {
            try
            {
                folder = folder ?? Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await IsExistsFile(fileName, folder);
                if (file != null)
                    await file.DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
