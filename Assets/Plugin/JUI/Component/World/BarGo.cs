using System;
using UnityEngine;

namespace JackUtil {

    public class BarGo : BarBase {

        public SpriteRenderer bgSr;
        public SpriteRenderer barSr;

        [ContextMenu("ReAwake")]
        void Awake() {

            bgSr.sprite = barBackgroundSprite;

            switch(barType) {
                case BarType.Hp: barSr.sprite = hpBarSprite; break;
                case BarType.Mp: barSr.sprite = mpBarSprite; break;
                case BarType.Shield: barSr.sprite = shieldSprite; break;
                default: DebugUtil.LogError("错误的Bar类型"); break;
            }

        }

        public override void RefreshBar(int _currentValue, int _maxValue) {
            RefreshBar((float)_currentValue, (float)_maxValue);
        }

        public override void RefreshBar(float _currentValue, float _maxValue) {
            float _percent = _currentValue / _maxValue;
            barSr.size = new Vector2(_percent, barSr.size.y);
        }

    }
}