using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class Prick : BlockBase {

        protected override void PlayerEnter(ActorBase _actor) {

            _actor.Dead();

        }

    }
}