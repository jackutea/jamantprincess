using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class FallingWall : BlockBase {

        public Vector2 fallingDir;
        public float fallingSpeed;
        public float waitTime;

        Rigidbody2D rig;
        Vector3 defaultPos;

        Vector2 size;

        protected override void Awake() {

            base.Awake();

            rig = GetComponent<Rigidbody2D>();

            rig.gravityScale = 0;

            defaultPos = transform.position;

            size = sr.size;

        }

        protected override void PlayerStay(ActorBase _actor) {

            Vector2 _playerPos = _actor.transform.position;

            if (_playerPos.x >= transform.position.x && _playerPos.x <= transform.position.x + size.x) {

                if ((transform.position.y >= _playerPos.y && _actor.coll.isOnGround) || (transform.position.y <= _playerPos.y && _actor.coll.isOnCeiling)) {

                    _actor.Dead();

                }

            }

        }

        // protected override void OnCollisionEnter2D(Collision2D _col) {

        //     if (_col.gameObject.tag == TagCollection.groundTag && defaultPos != transform.position) {

        //         StartFade(0, 0.2f);

        //     }

        // }

        public void Activated() {

            Sequence _action = DOTween.Sequence();
            _action.AppendInterval(waitTime);
            _action.AppendCallback(() => {
                rig.gravityScale = fallingDir.y * fallingSpeed;
                rig.velocity = new Vector2(fallingDir.x * fallingSpeed, rig.velocity.y);
                _action = null;
            });

        }

    }
}