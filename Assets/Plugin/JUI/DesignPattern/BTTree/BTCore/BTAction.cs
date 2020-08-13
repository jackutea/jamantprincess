using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public enum BTResult : byte {
        Ready,
        Running,
        Ended,
    }

    public enum BTActionState : byte {
        Ready,
        Running,
    }

    public abstract class BTAction : BTNode {

        protected BTActionState actionState = BTActionState.Ready;

        public BTAction(BTPrecondition _precondition = null) : base(_precondition) {}

        public abstract void Enter();
        public abstract BTResult Execute();
        public abstract void Exit();

        public override BTResult Tick() {
            BTResult _res = BTResult.Running;
            if (actionState == BTActionState.Ready) {
                Enter();
                actionState = BTActionState.Running;
            }

            if (actionState == BTActionState.Running) {
                _res = Execute();
                if (_res != BTResult.Running) {
                    Exit();
                    actionState = BTActionState.Ready;
                }
            }
            return _res;
        }

        public override void AddChild(BTNode _node) {
            DebugUtil.LogError("Forbid To AddChild");
        }

        public override void RemoveChild(BTNode _node) {
            DebugUtil.LogError("Forbid To RemoveChild");
        }

    }

}