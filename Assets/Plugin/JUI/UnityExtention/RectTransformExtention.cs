using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public static class RectTransformExtention {

        public static Vector2 ScreenToLocalPosition(this RectTransform _rect, Vector2 _screenPosition, Camera _camera) {
            Vector2 _outPos;
            bool _isInside = RectTransformUtility.ScreenPointToLocalPointInRectangle(_rect, _screenPosition, _camera, out _outPos);
            return _outPos;
        }
    }
}