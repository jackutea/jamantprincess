using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JackUtil {

    public class CurtainWindow : MonoBehaviour {

        public Image curtain;

        public void SetIndex(int _index = 0) {

            transform.SetSiblingIndex(_index);

        }

        public void LeftToRight(Action _callback = null, float _closeTime = 1.5f, float _waitTime = 1.5f, float _openTime = 1f) {

            curtain.type = Image.Type.Filled;

            curtain.fillMethod = Image.FillMethod.Horizontal;

            curtain.fillOrigin = (int)Image.OriginHorizontal.Left;

            Sequence _action = DOTween.Sequence();

            _action.Append(curtain.DOFillAmount(1, _closeTime));
            _action.AppendInterval(_waitTime);
            _action.AppendCallback(() => {
                curtain.fillOrigin = (int)Image.OriginHorizontal.Right;
            });
            _action.Append(curtain.DOFillAmount(0, _openTime));
            _action.AppendCallback(() => {
                _callback?.Invoke();
                _action.Kill();
            });

        }

        public void RightToLeft(Action _callback = null, float _closeTime = 1.5f, float _waitTime = 1.5f, float _openTime = 1f) {

            curtain.type = Image.Type.Filled;

            curtain.fillMethod = Image.FillMethod.Horizontal;

            curtain.fillOrigin = (int)Image.OriginHorizontal.Right;

            Sequence _action = DOTween.Sequence();

            _action.Append(curtain.DOFillAmount(1, _closeTime));
            _action.AppendInterval(_waitTime);
            _action.AppendCallback(() => {
                curtain.fillOrigin = (int)Image.OriginHorizontal.Left;
                curtain.DOFillAmount(0, _openTime);
                _callback?.Invoke();
                _action.Kill();
            });

        }

        public void TopToBottom(Action _callback = null, float _closeTime = 1.5f, float _waitTime = 1.5f, float _openTime = 1f) {

            curtain.type = Image.Type.Filled;

            curtain.fillMethod = Image.FillMethod.Vertical;

            curtain.fillOrigin = (int)Image.OriginVertical.Top;

            Sequence _action = DOTween.Sequence();

            _action.Append(curtain.DOFillAmount(1, _closeTime));
            _action.AppendInterval(_waitTime);
            _action.AppendCallback(() => {
                curtain.fillOrigin = (int)Image.OriginVertical.Bottom;
                curtain.DOFillAmount(0, _openTime);
                _callback?.Invoke();
                _action.Kill();
            });

        }

        public void BottomToTop(Action _callback = null, float _closeTime = 1.5f, float _waitTime = 1.5f, float _openTime = 1f) {

            curtain.type = Image.Type.Filled;

            curtain.fillMethod = Image.FillMethod.Vertical;

            curtain.fillOrigin = (int)Image.OriginVertical.Bottom;

            Sequence _action = DOTween.Sequence();

            _action.Append(curtain.DOFillAmount(1, _closeTime));
            _action.AppendInterval(_waitTime);
            _action.AppendCallback(() => {
                curtain.fillOrigin = (int)Image.OriginVertical.Top;
                curtain.DOFillAmount(0, _openTime);
                _callback?.Invoke();
                _action.Kill();
            });

        }

    }
}