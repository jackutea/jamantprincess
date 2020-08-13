using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace JackUtil {

    public static class CSVUtil {

        public static string[,] LoadToString(string _path) {

            string[] _str = File.ReadAllLines(_path);

            return LoadToString(_str);

        }

        public static string[,] LoadToString(string[] _csvLines) {

            string[,] _csv = null;

            for (int i = 0; i < _csvLines.Length; i += 1) {

                string _line = _csvLines[i];

                string[] _oneLine = _line.Trim().Split(',');

                if (_csv == null) {

                    _csv = new string[_csvLines.Length, _oneLine.Length];

                }

                for (int j = 0; j < _oneLine.Length; j += 1) {

                    _oneLine[j] = _oneLine[j].Trim();

                    _csv[i, j] = _oneLine[j];

                }

            }

            return _csv;

        }
        
    }
}