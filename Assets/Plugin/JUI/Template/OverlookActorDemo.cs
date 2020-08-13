using System;
using UnityEngine;
using JackUtil;

namespace JackUtil.Template {

    public class OverlookActorDemo : MonoBehaviour {

        public Rigidbody2D rig;
        bool isJump;
        public LayerMask groundLayer;

        protected virtual void Awake() {

            rig = GetComponent<Rigidbody2D>();

        }

        void FixedUpdate() {

            Move();

            Attack();

        }

        void Move() {

            float _xaxis = Input.GetAxisRaw("Horizontal");
            float _yaxis = Input.GetAxisRaw("Vertical");
            rig.MoveAndSlide();

        }

        void Attack() {

            float _attackAxis = Input.GetAxisRaw("Fire1");
            if (_attackAxis != 0) {
                SwordMelee _melee = JWOverlook.CastSwordMelee(transform);
                _melee.Ignore(GetComponent<Collider2D>());
                _melee.enterAction = _colGo => print(_colGo.name);
            }
        }

        void OnDrawGizmos() {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.down * 0.6f, 0.1f);

        }

    }
}