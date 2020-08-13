using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace JackUtil {

    public static class CloneExtention {

        // 返回深复制对象
        public static T CreateDeepClone<T>(this T obj) {

            if (obj == null) return obj;

            T t;

            MemoryStream ms = new MemoryStream();

            BinaryFormatter bf = new BinaryFormatter();

            // 把数据序列化成二进制
            bf.Serialize(ms, obj);

            ms.Position = 0;

            // 把数据从二进制反序列化
            t = (T)bf.Deserialize(ms);

            return t;

        }

    }

}
