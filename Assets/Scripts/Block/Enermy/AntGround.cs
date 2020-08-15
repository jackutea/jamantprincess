using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class AntGround : BlockBase {

        Vector2 defalutPos;
        public Vector2 moveOff;

        Sequence action;

        protected override void Awake() {

            defalutPos = transform.position;

            action = DOTween.Sequence();
            action.AppendInterval(0.4f);
            action.Append(transform.DOMove(defalutPos + moveOff, 0.4f));
            action.AppendInterval(0.4f);
            action.Append(transform.DOMove(defalutPos, 0.4f));
            action.SetLoops(-1);

        }

        protected override void PlayerEnter(ActorBase _actor) {

            if (_actor.transform.position.x < transform.position.x) {

                _actor.Dead();

            } else {

            }

            action.Kill();
            Destroy(gameObject);

        }

    }
}