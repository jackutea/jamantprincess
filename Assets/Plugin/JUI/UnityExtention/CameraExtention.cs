using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using DG.Tweening;

namespace JackUtil {

    public static class CameraExtention {

        static Vector2 tempV2 = Vector2.zero;
        static Vector3 tempV3 = Vector3.zero;
        static float camVec = 0;

        // 相机平滑跟随目标
        public static void FollowTarget(this Camera _camera, Vector3 _targetPos, float _smoothDeltaTime = 0) {

            if (_smoothDeltaTime == 0) {
                _smoothDeltaTime = Time.fixedDeltaTime * 3;
            }

            Vector3 _camPos = _camera.transform.position;
            _targetPos.Set(_targetPos.x, _targetPos.y, _camPos.z);

            _targetPos = Vector3.Lerp(_camPos, _targetPos, _smoothDeltaTime);
            _camera.transform.position = _targetPos;

        }

        public static void FollowTargetLimited(this Camera _camera, Vector3 _targetPos, Vector3 _boundsCenter, BoundsInt _bounds, Vector3 _cameraOff, float _smoothDeltaTime = 0) {

            if (_smoothDeltaTime == 0) {
                _smoothDeltaTime = Time.fixedDeltaTime * 3;
            }

            Vector3 _camPos = _camera.transform.position;
            float _xLimit = Mathf.Clamp(_targetPos.x, _cameraOff.x + _boundsCenter.x, _bounds.size.x - _cameraOff.x + _boundsCenter.x);
            float _yLimit = Mathf.Clamp(_targetPos.y, _cameraOff.y + _boundsCenter.y, _bounds.size.y - _cameraOff.y + _boundsCenter.y);
            _targetPos.Set(_xLimit, _yLimit, _camPos.z);

            _targetPos = Vector3.Lerp(_camPos, _targetPos, _smoothDeltaTime);
            _camera.transform.position = _targetPos;

        }

        // 鼠标调整相机高低视野
        public static void ScrollFieldOfView(this Camera _camera, string _axisOfScroll, float _sensitivity = 0, float _min = 80, float _max = 130) {

            float _scrollVal = Input.GetAxisRaw(_axisOfScroll);

            _sensitivity += 10;

            float _smooth = Mathf.SmoothDamp(_camera.fieldOfView, _camera.fieldOfView + -_scrollVal * _sensitivity, ref camVec, Time.fixedDeltaTime * 2);

            _camera.fieldOfView = _smooth;
            if (_camera.fieldOfView >= _max) {
                _camera.fieldOfView = _max;
            } else if (_camera.fieldOfView <= _min) {
                _camera.fieldOfView = _min;
            }

        }

        // 鼠标调整相机高低视野
        public static void ScrollOrthographicSize(this Camera _camera, string _axisOfMouseScrollWheel, float _sensitivity = 0, float _min = 2, float _max = 16) {

            float _scrollVal = Input.GetAxisRaw(_axisOfMouseScrollWheel);

            _sensitivity += 10;

            float _smooth = Mathf.SmoothDamp(_camera.orthographicSize, _camera.orthographicSize + -_scrollVal * _sensitivity, ref camVec, Time.fixedDeltaTime);

            _camera.orthographicSize = _smooth;
            if (_camera.orthographicSize <= _min) {
                _camera.orthographicSize = _min;
            } else if (_camera.orthographicSize >= _max) {
                _camera.orthographicSize = _max;
            }

        }

        // 按住某键，鼠标平移相机
        public static void ClickMoveCamera(this Camera _camera, KeyCode _mousePressKey, float _sensitivity = 0.5f) {

            if (Input.GetKey(_mousePressKey)) {

                float _x = -Input.GetAxisRaw("Mouse X") * _sensitivity;
                float _y = -Input.GetAxisRaw("Mouse Y") * _sensitivity;

                tempV2.x = _x;
                tempV2.y = _y;

                _camera.transform.Translate(tempV2);

            }
        }

        public static Vector3 GetMouseWorldPosition(this Camera _camera, Vector3 _mousePosition, float _z = -99999) {
            _z = _z == -99999 ? _camera.transform.position.z : _z;
            Vector3 _tempVec = _mousePosition;
            _tempVec.Set(_mousePosition.x, _mousePosition.y, -_z);
            _tempVec = _camera.ScreenToWorldPoint(_tempVec);
            return _tempVec;
        }

        public static void ShakeScreen(this Camera _camera) {

            _camera.DOShakePosition(0.3f, 2f, 2, 2f, false);

        }

    }
}