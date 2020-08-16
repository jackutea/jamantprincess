using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class ActorStateIdle : FSMStateBase<ActorBase> {

        public override int StateEnum => StateType.Idle.ToInt();

        public override void Enter(ActorBase _actor) {

            _actor.allowState = AllowAction.allowMove
                                + AllowAction.allowJump
                                + AllowAction.allowChangeBody
                                + AllowAction.allowFalling
                                + AllowAction.allowGroundCheck;

        }

        public override void Execute(ActorBase _actor) {

            bool _isrunning = false;

            if (_actor.bodySize == 0) {

                _actor.ani.SetBool("IsSmallJumping", false);

            } else {

                _actor.ani.SetBool("IsBigJumping", false);

            }

            if (_actor.controller.moveAxis.x != 0) {

                _isrunning = true;

                if (_actor.bodySize == 0) {

                    _actor.ani.SetBool("IsSmallRunning", true);

                } else {

                    _actor.ani.SetBool("IsBigRunning", true);

                }


            } else {

                if (_actor.bodySize == 0) {

                    _actor.ani.SetBool("IsSmallRunning", false);

                } else {

                    _actor.ani.SetBool("IsBigRunning", false);
                    
                }

            }

            if (_isrunning) {

                AudioManager.Instance.Play(AudioType.Walk);

            }

        }

        public override void Exit(ActorBase _actor) {
            
        }

    }
}