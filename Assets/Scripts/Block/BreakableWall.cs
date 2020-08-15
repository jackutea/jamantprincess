using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class BreakableWall : BlockBase {

        bool isEntered;
        public float fadeTime;
        public float reshowWaitTime;

        protected override void Awake() {

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

                Reshow(fadeTime/2f, fadeTime/2f, reshowWaitTime, () => {
                    isEntered = false;
                });

            }

        }

    }
}