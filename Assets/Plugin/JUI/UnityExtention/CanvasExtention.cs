using System;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public static class CanvasExtention {

        public static Vector2 ScreenToLocalPosition(this Canvas _canvas, Vector2 _screenPosition, Camera _uiCamera) {
            RectTransform _rect =_canvas.GetComponent<RectTransform>();
            Vector2 _pos;
            bool _isInside = RectTransformUtility.ScreenPointToLocalPointInRectangle(_rect, _screenPosition, _uiCamera, out _pos);
            return _pos;
        }

    }
}