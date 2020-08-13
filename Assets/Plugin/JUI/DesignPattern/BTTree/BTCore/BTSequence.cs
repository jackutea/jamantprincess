using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public class BTSequence : BTNode {

        BTNode activeChild;
        int activeIndex = -1;

        public BTSequence(BTPrecondition _precondition = null) : base(_precondition) {}

        public override bool DoEvaluate() {

            if (activeChild != null) {
                bool _res = activeChild.Evaluate();
                if (!_res) {
                    activeChild.Reset();
                    activeChild = null;
                    activeIndex = -1;
                }
                return _res;

            } else {

                return children[0].Evaluate();

            }
        }

        public override BTResult Tick() {

            if (activeChild == null) {
                activeChild = children[0];
                activeIndex = 0;
            }

            BTResult _res = activeChild.Tick();
            if (_res == BTResult.Ended) {
                activeIndex += 1;
                if (activeIndex >= children.Count) {
                    activeChild.Reset();
                    activeChild = null;
                    activeIndex = -1;
                } else {
                    activeChild.Reset();
                    activeChild = children[activeIndex];
                    _res = BTResult.Running;
                }
            }
            return _res;
        }

        public override void Reset() {
            if (activeChild != null) {
                activeChild = null;
                activeIndex = -1;
            }

            foreach (BTNode _node in children) {
                _node.Reset();
            }
        }

    }
    
}