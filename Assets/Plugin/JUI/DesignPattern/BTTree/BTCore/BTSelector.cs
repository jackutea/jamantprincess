using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    // 挑一个满足条件的子节点进入 执行结果等同于子节点结果
    public class BTSelector : BTNode {

        BTNode activeChild;

        public BTSelector(BTPrecondition _precondition = null) : base(_precondition) {}

        public override bool DoEvaluate() {

            foreach (BTNode _node in children) {

                if (_node.Evaluate()) {

                    if (activeChild != null && activeChild != _node) {
                        activeChild.Reset();
                    }

                    activeChild = _node;

                    return true;

                }

            }

            if (activeChild != null) {
                activeChild.Reset();
                activeChild = null;
            }

            return false;

        }

        public override BTResult Tick() {

            if (activeChild == null) {

                return BTResult.Ended;

            }

            BTResult _res = activeChild.Tick();
            if (_res != BTResult.Running) {
                activeChild.Reset();
                activeChild = null;
            }

            return _res;

        }

        public override void Reset() {

            if (activeChild != null) {
                activeChild.Reset();
                activeChild = null;
            }
            
        }

    }

}