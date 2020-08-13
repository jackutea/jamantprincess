using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JackUtil {

    public static class FileUtil {

        public static void CreateDir(string _dirPath) {
            if (!Directory.Exists(_dirPath)) {
                Directory.CreateDirectory(_dirPath);
            }
        }

        public static void SaveFile(object _object, string _dirPath, string _fileName) {
            CreateDir(_dirPath);
            SaveFile(_object, _dirPath + _fileName);
        }

        public static void SaveFile<T>(T _object, string _url) {

            // 二进制流
            BinaryFormatter _bf = new BinaryFormatter();

            FileStream _fs;

            // 文件流
            if (!File.Exists(_url)) {

                using (_fs = File.Create(_url)) {

                    _bf.Serialize(_fs, _object);

                }

            } else {

                using (_fs = File.Open(_url, FileMode.Create)) {

                    _bf.Serialize(_fs, _object);

                }

            }
            
        }

        public static T LoadData<T>(string _filePath) {

            if (!File.Exists(_filePath)) {
                DebugUtil.Log("存档不存在" + _filePath);
                return default;
            }

            BinaryFormatter _bf = new BinaryFormatter();

            // FileStream _fs = new FileStream(_filePath, FileMode.Open);

            // T _t = (T)_bf.Deserialize(_fs);

            // _fs.Close();

            // return _t;

            using (FileStream _fs = new FileStream(_filePath, FileMode.Open)) {

                T _t = (T)_bf.Deserialize(_fs);

                return _t;

            }
            
        }

    }
}