using System;
using System.IO;

namespace JackUtil {

    public static class AssemblyUtil {

        static string url = "Assembly-CSharp.csproj";

        public static void DeleteSameLine() {
            string[] _lines = ReadFile("Compile");
            WriteFile(_lines);
        }
        public static string[] ReadFile(string _sameContent) {
            string[] _lines = File.ReadAllLines(url);
            int _sameCount = 0;
            for (int i = 0; i < _lines.Length; i += 1) {
                string _cur = _lines[i];
                if (i - 1 > 0) {
                    string _last = _lines[i - 1];
                    if (_last.Contains(_sameContent) && _last == _cur) {
                        _lines[i - 1] = string.Empty;
                        _sameCount += 1;
                    }
                }

            }
            return _lines;
        }
        public static void WriteFile(string[] _lines) {
            File.WriteAllLines(url, _lines);
        }

    }

}
