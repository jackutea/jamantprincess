using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public static class ColorExtention {

        public static Color GetTransparent(this Color _color) {
            _color = new Color(_color.r, _color.g, _color.a, 0);
            return _color;
        }

        public static Color GetFullColor(this Color _color) {
            _color = new Color(_color.r, _color.g, _color.a, 255);
            return _color;
        }
    }
}