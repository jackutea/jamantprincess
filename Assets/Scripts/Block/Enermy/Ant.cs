using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class Ant : BlockBase {

        public bool isFlying;
        public Sprite groundAnt;
        public Sprite flyAnt;

        public Vector2 moveOff;
        Vector2 defalutPos;

        Sequence action;

        [ContextMenu("ReAwake")]
        protected override void Awake() {

            base.Awake();

            sr = GetComponent<SpriteRenderer>();
            sr.sprite = isFlying ? flyAnt : groundAnt;

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