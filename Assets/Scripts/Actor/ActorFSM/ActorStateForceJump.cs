using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class ActorStateForceJump : FSMStateBase<ActorBase> {

        public override int StateEnum => StateType.ForceJump.ToInt();

        public override void Enter(ActorBase _actor) {

            _actor.allowState = AllowAction.allowMove
                                + AllowAction.allowChangeBody
                                + AllowAction.allowFallingWithoutRaise
                                + AllowAction.allowGroundCheck;

        }

        public override void Execute(ActorBase _actor) {

        }

        public override void Exit(ActorBase _actor) {
            
        }

    }
}