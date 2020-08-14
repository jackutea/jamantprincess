using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class ActorStateIdle : FSMStateBase<ActorBase> {

        public override int StateEnum => StateType.Idle.ToInt();

        public override void Enter(ActorBase _actor) {

        }

        public override void Execute(ActorBase _actor) {

        }

        public override void Exit(ActorBase _actor) {
            
        }

    }
}