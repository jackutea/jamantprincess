using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public static class GameObjectExtention {

        public static void ChangeButtonText(this GameObject _buttonGo, string _txt) {
            Text _text = _buttonGo.GetComponentInChildren<Text>();
            if (_text == null) return;
            _text.text = _txt;
        }

        public static void AddButtonClickEvent(this GameObject _buttonGo, Action _action) {
            Button _button = _buttonGo.GetComponent<Button>();
            if (_button == null) {
                DebugUtil.LogError("错误的类型");
                return;
            }
            _button.onClick.AddListener(() => _action?.Invoke());
        }

        public static void RemoveButtonClickEvent(this GameObject _buttonGo) {
            Button _button = _buttonGo.GetComponent<Button>();
            if (_button == null) return;
            _button.onClick.RemoveAllListeners();
        }

        public static void DestroyGoList<T>(this List<T> _list) where T: Component {
            for (int i = 0; i < _list.Count; i += 1) {
                Component _go = _list[i] as Component;
                if (_go == null) {
                    DebugUtil.LogWarning("该类型不可被销毁: " + _list[i].GetType());
                    return;
                }
                GameObject.DestroyImmediate(_go.gameObject);
            }
            _list.Clear();
        }

        public static void RemoveAndDestroy<Tkey, TValue>(this Dictionary<Tkey, TValue> _dic, Tkey _key) {
            if (_dic.ContainsKey(_key)) {
                MonoBehaviour _go = _dic.GetValue(_key) as MonoBehaviour;
                GameObject.DestroyImmediate(_go.gameObject);
                _dic.Remove(_key);
            }
        }

        public static void Show(this MonoBehaviour _mono) {
            _mono.gameObject.SetActive(true);
        }

        public static void Hide(this MonoBehaviour _mono) {
            _mono.gameObject.SetActive(false);
        }

    }
}