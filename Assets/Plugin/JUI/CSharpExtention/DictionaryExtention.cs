using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace JackUtil {

    public static class DictionaryExtention {

        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> _dic, TKey _key, TValue _value = default(TValue)) {
            return _dic.ContainsKey(_key) ? _dic[_key] : _value;
        }

        public static TValue GetValue<TKey, TValue>(this SortedDictionary<TKey, TValue> _dic, TKey _key, TValue _value = default(TValue)) {
            return _dic.ContainsKey(_key) ? _dic[_key] : _value;
        }

        public static bool TryRemove<TKey, TValue>(this Dictionary<TKey, TValue> _dic, TKey _key) {
            if (_dic.ContainsKey(_key)) {
                _dic.Remove(_key);
                return true;
            } else {
                return false;
            }
        }

        public static bool TryRemove<TKey, TValue>(this SortedDictionary<TKey, TValue> _dic, TKey _key) {
            if (_dic.ContainsKey(_key)) {
                _dic.Remove(_key);
                return true;
            } else {
                return false;
            }
        }

        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> _dic, TKey _key, TValue _value) {
            if (_dic.ContainsKey(_key)) {
                _dic[_key] = _value;
            } else {
                _dic.Add(_key, _value);
            }
            return _dic;
        }

        public static SortedDictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this SortedDictionary<TKey, TValue> _dic, TKey _key, TValue _value) {
            if (_dic.ContainsKey(_key)) {
                _dic[_key] = _value;
            } else {
                _dic.Add(_key, _value);
            }
            return _dic;
        }

        public static List<TValue> GetValueList<TKey, TValue>(this Dictionary<TKey, TValue> _dic) {
            return new List<TValue>(_dic.Values);
        }

        public static List<TValue> GetValueList<TKey, TValue>(this SortedDictionary<TKey, TValue> _dic) {
            return new List<TValue>(_dic.Values);
        }

        public static TKey GetKeyWithValue<TKey, TValue>(this Dictionary<TKey, TValue> _dic, TValue _value) {
            foreach (var _kv in _dic) {
                if (_kv.Value.Equals(_value)) {
                    return _kv.Key;
                }
            }
            return default;
        }

        public static TKey GetKeyWithValue<TKey, TValue>(this SortedDictionary<TKey, TValue> _dic, TValue _value) {
            foreach (var _kv in _dic) {
                if (_kv.Value.Equals(_value)) {
                    return _kv.Key;
                }
            }
            return default;
        }

    }
}