using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class Bullet : BlockBase {

        public Vector2 fallingDir;
        public float fallingSpeed;
        public float waitTime;
        Rigidbody2D rig;
        Vector3 defaultPos;

        protected override void Awake() {

            base.Awake();

            rig = GetComponent<Rigidbody2D>();

            rig.gravityScale = 0;

            defaultPos = transform.position;

        }

        protected override void PlayerEnter(ActorBase _actor) {

            _actor.Dead();

        }

        protected override void OnCollisionEnter2D(Collision2D _col) {

            base.OnCollisionEnter2D(_col);

            if (_col.gameObject.tag == TagCollection.groundTag && defaultPos != transform.position) {

                StartFade(0, 0.2f);
                Destroy(gameObject);

            }

        }

        public void Activated() {

            Awake();

            Sequence _action = DOTween.Sequence();
            _action.AppendInterval(waitTime);
            _action.AppendCallback(() => {
                rig.gravityScale = -fallingDir.y * fallingSpeed;
                rig.velocity = new Vector2(fallingDir.x * fallingSpeed, rig.velocity.y);
                _action = null;
            });

        }

    }
}