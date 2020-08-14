using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JackUtil {

    public class FloatTextGo : MonoBehaviour {

        public Text text;
        Sequence action;

        protected virtual void Awake() {

            text = GetComponent<Text>();

        }

        public void FlyUp(Vector2 _position, Color _color) {

            RectTransform _rt = GetComponent<RectTransform>();

            _rt.position = _position;

            Color _c = _color;
            _c.a = 0;

            text.color = _c;

            action = DOTween.Sequence();

            action.Append(_rt.DOMove(_position + Vector2.up * 10, 0.4f));
            action.Join(text.DOColor(_c.GetFullColor(), 0.4f));
            action.AppendInterval(0.11f);
            action.Append(_rt.DOMove(_position + Vector2.up * 100, 0.4f));
            action.Join(text.DOColor(_c.GetTransparent(), 0.4f));
            action.AppendCallback(() => {

                Destroy(gameObject);

                action.Kill();

                action = null;

            });

        }

    }
}