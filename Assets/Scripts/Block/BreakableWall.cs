using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class BreakableWall : BlockBase {

        protected override void PlayerEnter(ActorBase _actor) {

            if (_actor.bodySize == 2) {

                Destroy(gameObject);

            }

        }

        protected override void PlayerStay(ActorBase _actor) {

            if (_actor.bodySize == 2) {

                Destroy(gameObject);
                
            }

        }
    }
}