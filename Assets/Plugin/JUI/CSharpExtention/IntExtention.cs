using System;

namespace JackUtil {

    public static class IntExtention {

        public static bool Contains(this int _i, int _min, int _max) {
            return _i >= _min && _i <= _max;
        }

    }

}