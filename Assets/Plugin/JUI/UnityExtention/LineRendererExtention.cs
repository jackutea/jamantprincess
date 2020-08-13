using System;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public static class LineRendererExtention {

        public static void DrawHollowCircle(this LineRenderer _lr, Camera _camera, Vector3 _mousePosition, Color _color, float _border, float _radius) {

            _lr.startColor = _color;
            _lr.endColor = _color;

            _lr.startWidth = _border;
            _lr.endWidth = _border;

            int _pointCount = 362;
            _lr.positionCount = _pointCount;
            
            Vector3 _targetPosition = _camera.GetMouseWorldPosition(_mousePosition);

            // 以鼠标为中心画圆
            for (int i = 0; i < _pointCount; i += 1) {

                float _x = Mathf.Cos((360 * (i + 1) / _pointCount) * Mathf.Deg2Rad) * _radius + _targetPosition.x;
                float _y = Mathf.Sin((360 * (i + 1) / _pointCount) * Mathf.Deg2Rad) * _radius + _targetPosition.y;
                _lr.SetPosition(i, new Vector2(_x, _y));
                
            }

        }

        public static void DrawSolidCircle(this LineRenderer _lr, Camera _camera, Vector3 _mousePosition, Color _color, float _radius) {

            _lr.startColor = _color;
            _lr.endColor = _color;

            _lr.startWidth = _radius;
            _lr.endWidth = _radius;

            _lr.positionCount = 2;

            Vector3 _targetPosition = _camera.GetMouseWorldPosition(_mousePosition);

            _lr.SetPosition(0, new Vector2(_targetPosition.x, _targetPosition.y));
            _lr.SetPosition(1, new Vector2(_targetPosition.x, _targetPosition.y));

        }

        public static void DrawSolidRay(this LineRenderer _lr, Camera _camera, Vector3 _fromPosition, Vector3 _mousePosition, Color _color, float _width) {

            _lr.startColor = _color;
            _lr.endColor = _color;

            _lr.startWidth = _width;
            _lr.endWidth = _width;

            _lr.positionCount = 2;

            Vector3 _targetPosition = _camera.GetMouseWorldPosition(_mousePosition);
            _lr.SetPosition(0, new Vector2(_fromPosition.x, _fromPosition.y));
            _lr.SetPosition(1, new Vector2(_targetPosition.x, _targetPosition.y));

        }

        public static void DrawSolidRay(this LineRenderer _lr, Camera _camera, Vector3 _fromPosition, Vector3 _mousePosition, Color _color, float _width, LayerMask _layer) {

            _lr.startColor = _color;
            _lr.endColor = _color;

            _lr.startWidth = _width;
            _lr.endWidth = _width;

            _lr.positionCount = 2;

            Vector3 _targetPosition = _camera.GetMouseWorldPosition(_mousePosition);
            RaycastHit2D _hit = Physics2D.Linecast(_fromPosition, _targetPosition, _layer);
            if (_hit) {
                _targetPosition = _hit.point;
            }
            _lr.SetPosition(0, new Vector2(_fromPosition.x, _fromPosition.y));
            _lr.SetPosition(1, new Vector2(_targetPosition.x, _targetPosition.y));

        }

    }
}