using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public static class RigidBody2DExtention {

        // TODO 定期GC，内存优化
        static Dictionary<Rigidbody2D, float> xVecDic = new Dictionary<Rigidbody2D, float>();
        static Dictionary<Rigidbody2D, float> yVecDic = new Dictionary<Rigidbody2D, float>();
        static Dictionary<Rigidbody2D, float> crushTimeDic = new Dictionary<Rigidbody2D, float>();
        const float colSensitivity = 0.01f;

        public static void MoveAndSlide(this Rigidbody2D _rig, float _moveSpeed = 2.5f, float _accelerate = 0.008f, float _decelerate = 0.0032f, bool _isDefaultControls = true) {
            float _xAxis = Input.GetAxisRaw("Horizontal");
            float _yAxis = Input.GetAxisRaw("Vertical");
            MoveAndSlide(_rig, _xAxis, _yAxis, _moveSpeed, _accelerate, _decelerate);
        }

        // TODO 碰撞后平滑移动
        public static void MoveAndSlide(this Rigidbody2D _rig, float _xAxis, float _yAxis, float _moveSpeed = 2.5f, float _accelerate = 0.008f, float _decelerate = 0.0032f) {

            float _xVec;
            if (!xVecDic.ContainsKey(_rig)) {
                xVecDic.Add(_rig, 0);
                _xVec = 0;
            } else {
                _xVec = xVecDic.GetValue(_rig);
            }

            float _yVec;
            if (!yVecDic.ContainsKey(_rig)) {
                yVecDic.Add(_rig, 0);
                _yVec = 0;
            } else {
                _yVec = yVecDic.GetValue(_rig);
            }

            // Vector2 _tempVec2 = Vector2.zero;

            if (_xAxis != 0) {

                _xAxis = Mathf.SmoothDamp(_rig.velocity.x, _moveSpeed * Time.fixedDeltaTime * 60 * _xAxis.ToOne(), ref _xVec, _accelerate);

            } else {

                _xAxis = Mathf.SmoothDamp(_rig.velocity.x, 0, ref _xVec, _decelerate);

            }

            if (_yAxis != 0) {

                _yAxis = Mathf.SmoothDamp(_rig.velocity.y, _moveSpeed * Time.fixedDeltaTime * 60 * _yAxis.ToOne(), ref _yVec, _accelerate);

            } else {

                _yAxis = Mathf.SmoothDamp(_rig.velocity.y, 0, ref _yVec, _decelerate);

            }

            _rig.velocity = new Vector2(_xAxis, _yAxis);

        }

        public static void MoveInPlatform(this Rigidbody2D _rig, float _xAxis,float _moveSpeed = 10.5f, float _accelerate = 0.018f, float _decelerate = 0.0032f) {

            float _xVec;
            if (!xVecDic.ContainsKey(_rig)) {
                xVecDic.Add(_rig, 0);
                _xVec = 0;
            } else {
                _xVec = xVecDic.GetValue(_rig);
            }

            if (_xAxis != 0) {

                _rig.velocity = new Vector2(Mathf.SmoothDamp(_rig.velocity.x, _moveSpeed * Time.fixedDeltaTime * 60 * _xAxis.ToOne(), ref _xVec, _accelerate), _rig.velocity.y);

            } else {

                _rig.velocity = new Vector2(Mathf.SmoothDamp(_rig.velocity.x, 0, ref _xVec, _decelerate), _rig.velocity.y);

            }

        }

        public static void Jump(this Rigidbody2D _rig, float _jumpAxis, ref bool _isJump, float _jumpSpeed = 10f) {

            if (_jumpAxis > 0 && !_isJump) {
                _rig.velocity = new Vector2(_rig.velocity.x, _jumpSpeed);
                _isJump = true;
            }

        }

        public static void Falling(this Rigidbody2D _rig, float _jumpAxis, float _gravity = -16f, float _fallMultiplier = 4.5f, float _raiseJumpMultiplier = 2.5f) {

            // 下落
            if (_rig.velocity.y <= 0) {

                _rig.velocity += Vector2.up * _gravity * _fallMultiplier * Time.fixedDeltaTime;
                // DebugUtil.Log("直接下降" + _rig.velocity.y);
            
            // 上升时 未托底
            } else if (_rig.velocity.y > 0 && _jumpAxis == 0) {

                _rig.velocity += Vector2.up * _gravity * _fallMultiplier * Time.fixedDeltaTime;
                // DebugUtil.Log("上升时没有托底" + _rig.velocity.y);

            // 上升时 托底
            } else if (_rig.velocity.y > 0 && _jumpAxis != 0) {

                _rig.velocity += Vector2.up * _gravity * _raiseJumpMultiplier * Time.fixedDeltaTime;
                // DebugUtil.Log("上升时托底" + _rig.velocity.y);

            }
        }

        public static Collider2D CollideBox(this Rigidbody2D _rig, Vector2 _offSet, Vector2 _size, LayerMask _layer) {

            Collider2D _col = Physics2D.OverlapBox((Vector2)_rig.transform.position + _offSet, _size, 0, _layer);
            return _col; 

        }

        public static Collider2D CollideCircle(this Rigidbody2D _rig, Vector2 _offSet, float _radius, LayerMask _layer) {

            Collider2D _col = Physics2D.OverlapCircle((Vector2)_rig.transform.position + _offSet, _radius, _layer);
            return _col; 

        }

        public static Collider2D[] CollideAll(this Rigidbody2D _rig, Vector2 _offSet, Vector2 _size, LayerMask _layer) {

            Collider2D[] _cols = Physics2D.OverlapBoxAll((Vector2)_rig.transform.position + _offSet, _size, _layer);
            return _cols;

        }

        public static bool IsOnWall(this Rigidbody2D _rig, Vector2 _vec, LayerMask _layer) {

            Collider2D _collider = _rig.gameObject.GetComponent<Collider2D>();

            _vec = _vec * colSensitivity;

            Vector3 _size = _collider.bounds.size;
            _size.Set(_size.x + _vec.x, _size.y + _vec.y, 0);

            Collider2D _col = CollideBox(_rig, _collider.offset + _vec, _size, _layer);
            return _col != null;

        }

        public static bool IsOnFloor(this Rigidbody2D _rig, LayerMask _layer) {

            Collider2D _collider = _rig.gameObject.GetComponent<Collider2D>();

            // 方法一： 检测脚底大量点
            Vector2[] _footPos = new Vector2[10];
            float _xStart = _rig.transform.position.x - 0.1f;
            for (int i = 0; i < 10; i += 1) {

                _footPos[i] = new Vector2(0, _rig.transform.position.y + -_collider.bounds.size.y / 2f);

                RaycastHit2D _hit = Physics2D.Linecast(new Vector2(_xStart, _rig.transform.position.y), _footPos[i]);

                if (_hit.collider != null) {

                    if (_hit.collider.tag == "Wall") {

                        return true;

                    }

                }

            }

            return false;

            // // 方法二： 脚底Overlap
            // Collider2D[] _cols = Physics2D.OverlapBoxAll(_rig.transform.position, _collider.bounds.size, 0, _layer);

            // if (_cols.Length > 0) {
            //     return true;
            // } else {
            //     return false;
            // }

        }

        public static bool IsOnHorizontalWall(this Rigidbody2D _rig, Vector2 _horizontalOff, LayerMask _wallLayer, float _radius = 0.1f) {

            Collider2D _collider = _rig.gameObject.GetComponent<Collider2D>();
            _horizontalOff.Set(_horizontalOff.x * 0.4f, 0.2f);

            // Vector3 _size = new Vector3(0.1f, 0.01f, 0);

            Collider2D _col = CollideCircle(_rig, _horizontalOff, _radius, _wallLayer);
            return _col != null;

        }

        public static bool IsOnGround(this Rigidbody2D _rig, Vector2 _bottomOffset, LayerMask _groundLayer, float _radius = 0.1f) {

            Collider2D _collider = _rig.gameObject.GetComponent<Collider2D>();

            // Vector3 _size = new Vector3(_collider.bounds.size.x * 0.01f, 0.1f, 0);

            // 在玩家下面生成一个BOX判断
            // 位置 + 尺寸 + 角度 + 碰撞层
            Collider2D _col = CollideCircle(_rig, _bottomOffset, _radius, _groundLayer);
            return _col != null;

        }

        // public static bool IsOnGround(this Rigidbody2D _rig, LayerMask _groundLayer) {

        //     Collider2D _collider = _rig.gameObject.GetComponent<Collider2D>();
        //     Vector2 _vec = new Vector2(0, -0.5f + _collider.offset.y);

        //     // Vector3 _size = new Vector3(_collider.bounds.size.x * 0.01f, 0.1f, 0);

        //     // 在玩家下面生成一个BOX判断
        //     // 位置 + 尺寸 + 角度 + 碰撞层
        //     Collider2D _col = CollideCircle(_rig, _vec, 0.1f, _groundLayer);
        //     return _col != null;

        // }

        public static void ShootParabola(this Rigidbody2D _rig, Vector2 _targetPosition) {

            Vector2 _vec = FindInitialVelocity(_rig, _targetPosition);

            _rig.AddForce(_vec * _rig.mass, ForceMode2D.Impulse);

        }

        public static Vector2 FindInitialVelocity(this Rigidbody2D _rig, Vector2 _targetPosition) {

            // 速度向量
            Vector2 _vec = Vector2.zero;

            Vector2 _dir = _targetPosition - (Vector2)_rig.transform.position;

            float _range = _dir.magnitude;

            Vector2 _rigDir = _dir.normalized;

            float _maxYPos = _targetPosition.y;

            if (_maxYPos < _rig.transform.position.y) {

                _maxYPos = _rig.transform.position.y;

            }

            // Y方向的初始速度
            float _ft = -2f * Physics2D.gravity.y * (_maxYPos - _rig.transform.position.y);
            if (_ft < 0) {
                _ft = 0;
            }

            _vec.y = Mathf.Sqrt(_ft);

            // 最大时间
            _ft = -2f * (_maxYPos - _rig.transform.position.y) / Physics2D.gravity.y;
            if (_ft < 0) {
                _ft = 0;
            }
            float _timeToMax = Mathf.Sqrt(_ft);

            // 到达Y轴的时间
            _ft = -2f * (_maxYPos - _targetPosition.y) / Physics2D.gravity.y;
            if (_ft < 0) {
                _ft = 0;
            }

            float _timeToY = Mathf.Sqrt(_ft);

            float _totalTimeMax = _timeToMax + _timeToY;

            // 返回初始运动量
            float _horizontalMagnitude = _range / _totalTimeMax;

            _vec.x = _horizontalMagnitude * _rigDir.x;
            // _vec.y = _horizontalMagnitude * _rigDir.y;

            return _vec;

        }

    }
}