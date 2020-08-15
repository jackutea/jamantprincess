using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class ActorStateJump : FSMStateBase<ActorBase> {

        public override int StateEnum => StateType.Jump.ToInt();

        public override void Enter(ActorBase _actor) {

            _actor.allowState = AllowAction.allowMove
                                + AllowAction.allowChangeBody
                                + AllowAction.allowFalling
                                + AllowAction.allowGroundCheck;

        }

        public override void Execute(ActorBase _actor) {

        }

        public override void Exit(ActorBase _actor) {
            
        }

    }
}