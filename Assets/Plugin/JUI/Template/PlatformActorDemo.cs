using System;
using UnityEngine;
using JackUtil;

namespace JackUtil.Template {

    public class PlatformActorDemo : MonoBehaviour {

        public Rigidbody2D rig;
        bool isJump;
        public LayerMask groundLayer;
        // ---- FSM Test ----
        public FSMBase<PlatformActorDemo> fsm;
        // ---- Pool Test ----
        public MonoPool<MonoBehaviour> pool;
        public MonoBehaviour prefab;

        protected virtual void Awake() {

            rig = GetComponent<Rigidbody2D>();

            fsm = new FSMBase<PlatformActorDemo>(this);
            fsm.RegisterState(new FSMStateIdle());
            fsm.EnterState(FSMStateEnum.Idle.ToInt());

            pool = new MonoPool<MonoBehaviour>(prefab, 100);

        }

        void FixedUpdate() {

            Move();

            Jump();

            Falling();

            GroundCheck();

        }

        void Move() {

            float _xaxis = Input.GetAxisRaw("Horizontal");
            rig.MoveInPlatform(_xaxis);

        }

        void Jump() {

            float _jumpAxis = Input.GetAxisRaw("Jump");

            if (!isJump && _jumpAxis != 0) {

                rig.Jump(_jumpAxis, ref isJump);

                FloatTextGo _text = JUI.PopupFloatText(JUIDemo.Instance.uiCanvas);

                _text.FlyUp(Camera.main.WorldToScreenPoint(transform.position.ToZ0()), Color.red);

            }

        }

        void Falling() {

            float _jumpAxis = Input.GetAxisRaw("Jump");
            rig.Falling(_jumpAxis);

        }

        void GroundCheck() {

            bool _isOnGround = rig.IsOnGround(Vector2.down * 0.6f, groundLayer);
            if (_isOnGround) {
                isJump = false;
            }

        }

        void OnDrawGizmos() {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.down * 0.6f, 0.1f);
        }

    }
}