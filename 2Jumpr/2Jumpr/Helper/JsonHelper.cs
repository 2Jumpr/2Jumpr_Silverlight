
using System;
using System.IO.IsolatedStorage;
using System.IO;
using System.Runtime.Serialization.Json;

namespace _2Jumper
{
    public class JsonHelper
    {
        public static void SerializeData<T>(string filePath, object objToSer, string dirPath = "")
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(filePath))
                {
                    store.DeleteFile(filePath);
                }
                if (!string.IsNullOrEmpty(dirPath) && !store.DirectoryExists(dirPath))
                {
                    store.CreateDirectory(dirPath);
                }
                using (var stream = store.OpenFile(dirPath == "" ? filePath : Path.Combine(dirPath, filePath), FileMode.Create, FileAccess.Write))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                    ser.WriteObject(stream, objToSer);
                }
            }
        }

        public static T LoadJson<T>(string filePath)
        {
            T temObject = default(T);
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists(filePath))
                    {
                        using (var stream = store.OpenFile(filePath, System.IO.FileMode.Open))
                        {
                            if (0 <= stream.Length && stream.CanRead)
                            {
                                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                                temObject = (T)ser.ReadObject(stream);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                temObject = default(T);
            }
            return temObject;
        }
    }
}
