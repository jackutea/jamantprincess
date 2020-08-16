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
        public float bouncePower;
        public float moveSpeed;

        Sequence action;

        [ContextMenu("ReAwake")]
        protected override void Awake() {

            base.Awake();

            sr = GetComponent<SpriteRenderer>();
            sr.sprite = isFlying ? flyAnt : groundAnt;

            defalutPos = transform.position;

            if (moveSpeed == 0) {
                moveSpeed = 1;
            } else {
                moveSpeed = Mathf.Abs(moveSpeed);
            }

            action = DOTween.Sequence();
            action.AppendInterval(0.4f);
            action.Append(transform.DOMove(defalutPos + moveOff, moveOff.magnitude / moveSpeed));
            action.AppendInterval(0.4f);
            action.Append(transform.DOMove(defalutPos, moveOff.magnitude / moveSpeed));
            action.SetLoops(-1);

        }

        protected override void PlayerEnter(ActorBase _actor) {

            if (_actor.transform.position.x < transform.position.x) {

                _actor.Dead();

            }

            _actor.rig.velocity = new Vector2(_actor.rig.velocity.x, bouncePower);
            _actor.EnterState(StateType.ForceJump);

            // action.Kill();
            Reshow(0, 0, 2f);

        }

    }
}