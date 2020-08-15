using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using JackUtil;

namespace Jam {

    public class ActorBase : MonoBehaviour {

        Camera mainCam;
        public bool isFollowActor;

        SpriteRenderer sr;
        public Sprite normalBody;
        public Sprite smallBody;
        public Sprite hugeBody;

        FSMBase<ActorBase> fsm;
        Rigidbody2D rig;

        [HideInInspector]
        public ActorController controller;
        public ActorCollision coll;

        [HideInInspector]
        public Animator ani;
        [HideInInspector]
        public int face;
        [HideInInspector]
        public Vector2 faceDir;

        [HideInInspector]
        public int allowState = 1;

        public float moveSpeed;
        public float acceleteTime;
        public float deceleteTime;

        public float jumpSpeed;
        public float gravity;
        public float fallingSpeed;
        public float fallingSpeedMax;
        public float raiseSpeed;
        [HideInInspector]
        public bool isJumping;

        public Status normalStatus;
        public Status smallStatus;
        public Status hugeStatus;

        public int bodySize;

        public float maxHeight;

        bool allowDebugFalling;

        protected virtual void Awake() {

            mainCam = Camera.main;

            sr = GetComponent<SpriteRenderer>();

            fsm = new FSMBase<ActorBase>(this);
            fsm.RegisterState(new ActorStateIdle());
            fsm.RegisterState(new ActorStateJump());
            fsm.currentState.Enter(this);

            controller = GetComponent<ActorController>();
            coll = GetComponent<ActorCollision>();
            coll.Awake();

            rig = GetComponent<Rigidbody2D>();

            ani = GetComponent<Animator>();

            InitValue();

            ChangeBody(1);

        }

        protected virtual void Update() {

            if (fsm != null) {

                fsm.Execute();

            }

        }

        protected virtual void FixedUpdate() {

            if (transform.position.y > maxHeight) {
                maxHeight = transform.position.y;
            }

            if ((allowState & AllowAction.allowMove) != 0) {

                // rig.velocity = new Vector2(10, rig.velocity.y);
                Move();

            }

            if ((allowState & AllowAction.allowJump) != 0) {

                Jump();

            }

            if ((allowState & AllowAction.allowChangeBody) != 0) {

                ListenChangeBody();

            }

            if ((allowState & AllowAction.allowFalling) != 0) {

                Falling();

            }

            if ((allowState & AllowAction.allowGroundCheck) != 0) {

                OnGround();

            }

            if ((allowState & AllowAction.allowFallingWithoutRaise) != 0) {

                FallingWithoutRaise();

            }

        }

        public virtual void InitValue() {

            isFollowActor = true;

            faceDir = new Vector2(1, 0);
            face = faceDir.GetFace8(face);

            moveSpeed = 6.5f;
            acceleteTime = 0.016f;
            deceleteTime = 0.008f;

            jumpSpeed = 15.5f;
            gravity = -18f;
            fallingSpeed = 3.6f;
            fallingSpeedMax = 20f;
            raiseSpeed = 2.0f;
            isJumping = false;

            smallStatus = new Status(0);
            normalStatus = new Status(1);
            hugeStatus = new Status(2);

        }

        public virtual void ListenChangeBody() {

            // Plan-A: 2 Keys
            if (controller.changeBiggerAxis != 0) {

                if (bodySize >= 1) {
                    ChangeBody(0);
                } else {
                    ChangeBody(bodySize + 1);
                }

            } else if (controller.changeSmallerAxis != 0) {

                if (bodySize <= 0) {
                    ChangeBody(1);
                } else {
                    ChangeBody(bodySize - 1);
                }

            }
            
            // Plan-B: 3 Keys
            // if (controller.changeBiggerAxis != 0) {
            //     ChangeBody(2);
            // } else if (controller.changeSmallerAxis != 0) {
            //     ChangeBody(0);
            // } else if (controller.changeNormalAxis != 0) {
            //     ChangeBody(1);
            // }

        }

        public virtual void ChangeBody(int _size) {

            controller.changeBiggerAxis = 0;
            controller.changeNormalAxis = 0;
            controller.changeSmallerAxis = 0;

            if (!AllowChangeBody()) return;

            bodySize = _size;
            float _height = 0;

            switch(bodySize) {
                case 0: // 微型
                    _height = 1;
                    sr.sprite = smallBody;
                    jumpSpeed = smallStatus.jumpSpeed;
                    fallingSpeed = smallStatus.fallingSpeed;
                    fallingSpeedMax = smallStatus.fallingSpeedMax;
                    raiseSpeed = smallStatus.raiseSpeed;
                    break;
                case 1: // 中型
                    _height = 2;
                    sr.sprite = normalBody;
                    jumpSpeed = normalStatus.jumpSpeed;
                    fallingSpeed = normalStatus.fallingSpeed;
                    fallingSpeedMax = normalStatus.fallingSpeedMax;
                    raiseSpeed = normalStatus.raiseSpeed;
                    break;
                case 2: // 大型
                    _height = 3;
                    sr.sprite = hugeBody;
                    jumpSpeed = hugeStatus.jumpSpeed;
                    fallingSpeed = hugeStatus.fallingSpeed;
                    fallingSpeedMax = hugeStatus.fallingSpeedMax;
                    raiseSpeed = hugeStatus.raiseSpeed;
                    break;
            }

            sr.drawMode = SpriteDrawMode.Tiled;
            sr.size = new Vector2(1, _height);
            coll.col.offset = new Vector2(0, _height / 2f);
            (coll.col as CapsuleCollider2D).size = new Vector2(1, _height);

        }

        public virtual bool AllowChangeBody() {

            // MapGo _currentMap = App.Instance.currentMap;
            // if (_currentMap == null) {
            //     return true;
            // }

            // Vector3Int _gridPos = _currentMap.tilemap.GetTilePos(transform.position);
            // TileBase _tileUp = _currentMap.tilemap.GetTile(_gridPos + new Vector3Int(0, 1, 0));
            // TileBase _tileDown = _currentMap.tilemap.GetTile(_gridPos + new Vector3Int(0, -1, 0));
            // if (_tileUp != null && _tileDown != null) {
            //     DebugUtil.LogWarning("上下夹住，不可变身");
            //     return false;
            // }

            if (coll.isOnCeiling && coll.isOnGround) {
                // DebugUtil.Log("上下夹住，不可变身");
                return false;
            }
            return true;
        }

        public virtual void Move() {

            Vector2 _dir = controller.moveAxis;

            rig.MoveInPlatform(_dir.x, moveSpeed, acceleteTime, deceleteTime);

            face = _dir.normalized.GetFace8(face);

            // 切换左右面向显示
            Vector3 _scale = transform.localScale;
            if (face < 4 && face > 0) {

                _scale.Set(-1, _scale.y, _scale.z);

            } else if (face > 4 && face < 8) {

                _scale.Set(1, _scale.y, _scale.z);

            }

            transform.localScale = _scale;

        }

        public virtual void Jump() {

            if (controller.jumpAxis != 0 && !isJumping) {

                rig.Jump(1, ref isJumping, jumpSpeed);

                allowDebugFalling = true;

                print("起点:" + transform.position);
                maxHeight = 0;

                EnterState(StateType.Jump);

            }

        }

        public virtual void Falling() {

            float _raiseAxis = controller.jumpAxis;

            if (_raiseAxis == 0 && coll.isOnGround) {

                isJumping = false;

            }

            rig.Falling(_raiseAxis, gravity, fallingSpeed, raiseSpeed);

            if (rig.velocity.y < -fallingSpeedMax) {

                rig.velocity = new Vector2(rig.velocity.x, -fallingSpeedMax);

            }
            
        }

        public virtual void FallingWithoutRaise() {

            rig.Falling(0, gravity, fallingSpeed, raiseSpeed);

            if (rig.velocity.y < -fallingSpeedMax) {

                rig.velocity = new Vector2(rig.velocity.x, -fallingSpeedMax);

            }

        }

        public virtual void OnGround() {

            if (coll.isOnGround) {

                if (rig.velocity.y <= 0) {

                    if (allowDebugFalling) {

                        print("落点: " + transform.position);
                        print("MaxHeight: " + maxHeight);

                        allowDebugFalling = false;

                    }


                    EnterState(StateType.Idle);

                }

            }

        }

        protected virtual void EnterState(StateType _type) {
            fsm.EnterState(_type.ToInt());
        }

        public virtual void Dead() {

            print("Dead");

            App.Instance.ReloadMap();

        }

    }
}