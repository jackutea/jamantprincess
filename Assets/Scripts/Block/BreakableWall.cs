using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class BreakableWall : BlockBase {

        public Sprite startBreaking;
        public Sprite failed;

        Sequence action;

        bool isEntered;
        public float fadeTime;
        public float reshowWaitTime;

        protected override void Awake() {

            base.Awake();

            isEntered = false;

        }

        protected override void PlayerEnter(ActorBase _actor) {

            ReshowThis(_actor);

        }

        protected override void PlayerStay(ActorBase _actor) {

            ReshowThis(_actor);

        }

        void ReshowThis(ActorBase _actor) {

            if (_actor.bodySize == 1 && !isEntered) {

                isEntered = true;

                if (action != null) {

                    action.Kill();

                }

                action = DOTween.Sequence();
                sr.sprite = startBreaking;
                action.Append(transform.DOShakeRotation(1, 6, 6, 1, false));
                action.AppendCallback(() => {
                    sr.sprite = failed;
                });
                action.Append(transform.DOShakeRotation(1, 6, 6, 1, false));
                action.AppendCallback(() => {
                    AudioManager.Instance.Play(AudioType.Broken);
                    Reshow(0, 0, reshowWaitTime, () => {
                        sr.sprite = startBreaking;
                        isEntered = false;
                    });
                });

            }

        }

    }
}