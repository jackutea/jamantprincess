using System;

namespace JackUtil {

    public static class ArrayExtention {

        public static T[] Shuffle<T>(this T[] _arr, Random _random = null) {

            if (_random == null) _random = new Random();

            for (int i = 0; i < _arr.Length; i += 1) {

                T _cur = _arr[i];

                int _rdIndex = _random.Next(_arr.Length);

                _arr[i] = _arr[_rdIndex];

                _arr[_rdIndex] = _cur;

            }

            return _arr;

        }

        public static bool TryGetEmptySlotIndex<T>(this T[] _arr, out int _index) {

            for (int i = 0; i < _arr.Length; i += 1) {
                T _cur = _arr[i];
                if (_cur == null) {
                    _index = i;
                    return true;
                }
            }

            _index = -1;
            return false;

        }

        public static T[] Sort<T>(this T[] _arr) {

            if (_arr == null || _arr.Length == 0) {
                return _arr;
            }
            if (_arr[0] as IComparable<T> == null) {
                DebugUtil.LogError("未实现 IComparable<T>");
                return _arr;
            }

            for (int i = 0; i < _arr.Length; i += 1) {
                for (int j = 0; j < _arr.Length; j += 1) {
                    T _t = _arr[j];
                    IComparable<T> _compare = _t as IComparable<T>;
                    if (j + 1 < _arr.Length) {
                        if (_compare.CompareTo(_arr[j + 1]) == 1) {
                            _arr[j] = _arr[j + 1];
                            _arr[j + 1] = _t;
                        }
                    }
                    
                }
            }

            return _arr;

        }

    }
}