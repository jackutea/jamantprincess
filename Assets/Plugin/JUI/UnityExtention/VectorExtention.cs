using System;
using UnityEngine;

namespace JackUtil {

    public static class VectorExtention {

        public static Vector2 ToZ0(this Vector3 _v3) {
            _v3.z = 0;
            return _v3;
        }

        public static Vector3Int SetAndReturn(ref this Vector3Int _v3, int _x, int _y, int _z = 0) {
            _v3.Set(_x, _y, _z);
            return _v3;
        }

        public static Vector3 SetAndReturn(ref this Vector3 _v3, float _x, float _y, float _z = 0) {
            _v3.Set(_x, _y, _z);
            return _v3;
        }

        public static Vector2Int SetAndReturn(ref this Vector2Int _v2, int _x, int _y) {
            _v2.Set(_x, _y);
            return _v2;
        }

        public static Vector2 SetAndReturn(ref this Vector2 _v2, float _x, float _y) {
            _v2.Set(_x, _y);
            return _v2;
        }

        public static Vector2 ToOne(this Vector2 _v2) {
            _v2.Set(_v2.x.ToOne(), _v2.y.ToOne());
            return _v2;
        }

        public static float To2DFaceAngle(this Vector2 _v2) {

            return Mathf.Atan2(_v2.y, _v2.x) * Mathf.Rad2Deg;

        }

        public static Quaternion To2DFaceRotation(this Vector2 _v2) {

            return Quaternion.AngleAxis(_v2.To2DFaceAngle(), Vector3.forward);

        }

        public static int GetFace4(this Vector2 _dir, int _oldFace) {

            // 四向
            // 左右优先
            //   0
            // 3   1
            //   2
            if (_dir.x < 0) {
                return 3;
            }
            if (_dir.x > 0) {
                return 1;
            }
            if (_dir.y < 0) {
                return 0;
            }
            if (_dir.y > 0) {
                return 2;
            }

            return _oldFace;

        }

        public static Vector2 GetFace8(this Vector2 _dir, Vector2 _oldDir) {

            if (_dir.magnitude == 0) {

                return _oldDir;

            } else {

                return _dir;

            }
        }

        public static Vector2 GetFace8FromInt(this Vector2 _dir, int _oldFace) {
            switch(_oldFace) {
                case 7: _dir.Set(-1, 1); break;
                case 6: _dir.Set(-1, 0); break;
                case 5: _dir.Set(-1, -1); break;
                case 0: _dir.Set(0, 1); break;
                case 4: _dir.Set(0, -1); break;
                case 1: _dir.Set(1, 1); break;
                case 2: _dir.Set(1, 0); break;
                case 3: _dir.Set(1, -1); break;
            }
            return _dir;
        }

        public static int GetFace8(this Vector2 _dir, int _oldFace) {

            // 八向
            // 7  0  1
            // 6     2
            // 5  4  3
            if (_dir.x < 0 && _dir.y > 0) {
                return 7;
            }
            if (_dir.x < 0 && _dir.y == 0) {
                return 6;
            }
            if (_dir.x < 0 && _dir.y < 0) {
                return 5;
            }
            if (_dir.x == 0 && _dir.y > 0) {
                return 0;
            }
            if (_dir.x == 0 && _dir.y < 0) {
                return 4;
            }
            if (_dir.x > 0 && _dir.y > 0) {
                return 1;
            }
            if (_dir.x > 0 && _dir.y == 0) {
                return 2;
            }
            if (_dir.x > 0 && _dir.y < 0) {
                return 3;
            }

            return _oldFace;

        }

    }
}