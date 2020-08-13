using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public enum BarType : byte {

        Hp,
        Mp,
        Shield

    }

    public class BarBase : MonoBehaviour {

        [Header("User")]
        public BarType barType;

        [Header("Default")]
        public Sprite barBackgroundSprite;
        public Sprite hpBarSprite;
        public Sprite mpBarSprite;
        public Sprite shieldSprite;

        public virtual void RefreshBar(int _currentValue, int _maxValue) {

        }

        public virtual void RefreshBar(float _currentValue, float _maxValue) {

        }

    }
}