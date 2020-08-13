using System;

namespace JackUtil {

    public static class FloatExtention {

        public static float ToOne(this float _f) {
            if (_f > 0) {
                _f = 1;
            } else if (_f < 0) {
                _f = -1;
            }
            return _f;
        }
    }
}