using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public class BarPanel : BarBase {

        public Image bgImg;
        public Image barImg;

        [ContextMenu("ReAwake")]
        void Awake() {

            bgImg.sprite = barBackgroundSprite;

            switch(barType) {
                case BarType.Hp: barImg.sprite = hpBarSprite; break;
                case BarType.Mp: barImg.sprite = mpBarSprite; break;
                case BarType.Shield: barImg.sprite = shieldSprite; break;
                default: DebugUtil.LogError("错误的Bar类型"); break;
            }

        }

        public override void RefreshBar(int _currentValue, int _maxValue) {
            RefreshBar((float)_currentValue, (float)_maxValue);
        }

        public override void RefreshBar(float _currentValue, float _maxValue) {
            if (_maxValue <= 0) {
                barImg.fillAmount = 0;
            } else {
                float _percent = _currentValue / _maxValue;
                barImg.fillAmount = _percent;
            }
        }

    }
}