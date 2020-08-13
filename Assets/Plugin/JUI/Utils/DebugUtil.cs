using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public class DebugUtil {

        static bool notAllow = false;

        public static void Log(object _msg) {
            if (notAllow) return;
            Debug.Log(_msg);
        }

        static StringBuilder rowSb = new StringBuilder();
        public static void LogCSV(string[,] _csv) {
            if (notAllow) return;
            rowSb.Clear();
            for (int i = 0; i < _csv.GetLength(0); i += 1) {
                for (int j = 0; j < _csv.GetLength(1); j += 1) {
                    rowSb.Append(_csv[i, j] + ',');
                }
                rowSb.AppendLine();
            }
            Log(rowSb.ToString());
            
        }

        public static void LogWarning(object _msg) {
            if (notAllow) return;
            Debug.LogWarning(_msg);
        }

        public static void LogError(object _msg) {
            if (notAllow) return;
            Debug.LogError(_msg);
        }

        public static void LogAssert(bool _condition, object _msg) {
            if (notAllow) return;
            Debug.Assert(_condition, _msg);
        }

        public static void LogUnregisterEvent() {
            if (notAllow) return;
            Debug.Log("事件未注册");
        }

        public static void LogArr<T>(T[] _arr) {
            if (notAllow) return;
            string _str = string.Empty;
            foreach (T _t in _arr) {
                _str += _t.ToString() + ", ";
            }
            Log(_str);
        }

        public static void LogList<T>(List<T> _list) {
            if (notAllow) return;
            string _str = string.Empty;
            foreach (T _t in _list) {
                _str += _t.ToString() + ", ";
            }
            Log(_str);
        }

        public static void LogListHash<T>(List<T> _list) {
            if (notAllow) return;
            string _str = string.Empty;
            foreach (T _t in _list) {
                _str += _t.GetHashCode() + ",";
            }
            Debug.Log(_str);
        }

        public static void LogObject<T>(T _arg) {
            if (notAllow) return;
            string _msg = JsonUtility.ToJson(_arg);
            Debug.Log(_msg);
        }
    }
}
