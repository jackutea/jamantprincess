using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class BreakableWall : BlockBase {

        bool isEntered = false;
        public float fadeTime;
        public float reshowWaitTime;

        protected override void PlayerEnter(ActorBase _actor) {

            isEntered = true;

            if (_actor.bodySize == 1) {

                Reshow(fadeTime/2f, fadeTime/2f, reshowWaitTime);

            }

        }

        protected override void PlayerStay(ActorBase _actor) {

            if (!isEntered) {

                isEntered = true;

                if (_actor.bodySize == 1) {

                    Reshow(fadeTime/2f, fadeTime/2f, reshowWaitTime);

                }

            }

        }

    }
}