using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public class MonoPool<T> where T : MonoBehaviour {

        public T prefab;
        List<T> sets;
        int index;
        int maxCount;

        public MonoPool(T _prefab, int _maxCount) {

            prefab = _prefab;
            maxCount = _maxCount;
            index = 0;

            sets = new List<T>();
            ExtendPool(maxCount);

        }

        public void CleanPool() {
            index = 0;
            sets.Clear();
        }

        public void ExtendPool(int _count) {

            for (int i = 0; i < _count; i += 1) {
                T _go = GameObject.Instantiate(prefab);
                Release(_go);
                sets.Add(_go);
            }

        }

        public T GetObject() {

            index += 1;

            if (index >= sets.Count) {

                T _go = GetObject(0, ref index);
                if (_go != null) {
                    return _go;
                }

            } else {

                T _go = GetObject(index, ref index);
                if (_go != null) {
                    return _go;
                }

            }

            // 无则扩容
            ExtendPool(maxCount);
            return sets[index];

        }

        T GetObject(int _fromIndex, ref int _index) {

            for (int i = _fromIndex; i < sets.Count; i += 1) {

                MonoBehaviour _go = sets[i];
                if (!_go.isActiveAndEnabled) {
                    _index = i;
                    Activated((T)_go);
                    return (T)_go;
                }

            }

            return null;

        }

        public void Release(T _go) {
            _go.Hide();
        }

        public void Activated(T _go) {
            _go.Show();
        }

    }
}