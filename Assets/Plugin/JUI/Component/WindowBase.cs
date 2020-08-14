using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JackUtil {

    public abstract class WindowBase : MonoBehaviour {

        public void JudgePos(Vector2 _worldPos) {

            transform.position = _worldPos;
            transform.localScale = new Vector3(1, 1, 1);

        }

        public void JudgePos(Canvas _worldCanvas, Vector2 _worldPos) {

            transform.SetParent(_worldCanvas.transform);
            JudgePos(_worldPos);

        }

        public virtual void SetBackgroundSprite(Sprite _bgSprite) {

            print("未重写");

        }

    }
}