using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class AntGround : BlockBase {

        protected override void PlayerEnter(ActorBase _actor) {

            if (_actor.transform.position.x < transform.position.x) {

                _actor.Dead();
                return;

            } else {

            }

            Destroy(gameObject);

        }

    }
}