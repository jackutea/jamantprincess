using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public enum ParallelType : byte {
        And,
        Or,
    }

    public class BTParallel : BTNode {

        List<BTResult> resList;
        ParallelType paraType;

        public BTParallel(ParallelType _type) : this(_type, null) {}

        public BTParallel(ParallelType _type, BTPrecondition _precondition) : base(_precondition) {
            resList = new List<BTResult>();
            paraType = _type;
        }

        public override bool DoEvaluate() {
            foreach (BTNode _node in children) {
                if (!_node.Evaluate()) {
                    return false;
                }
            }
            return true;
        }

        public override BTResult Tick() {
            int _endCount = 0;

            for (int i = 0; i < children.Count; i += 1) {

                if (paraType == ParallelType.And) {

                    if (resList[i] == BTResult.Running) {
                        resList[i] = children[i].Tick();
                    }
                    if (resList[i] != BTResult.Running) {
                        _endCount += 1;
                    }

                } else {

                    if (resList[i] == BTResult.Running) {
                        resList[i] = children[i].Tick();
                    }
                    if (resList[i] != BTResult.Running) {
                        ResetResults();
                        return BTResult.Ended;
                    }

                }
            }

            if (_endCount == children.Count) {
                ResetResults();
                return BTResult.Ended;
            }
            return BTResult.Running;

        }

        public override void Reset() {

            ResetResults();

            foreach (BTNode _node in children) {
                
                _node.Reset();

            }
        }

        public override void AddChild(BTNode _node) {
            base.AddChild(_node);
            resList.Add(BTResult.Running);
        }

        public override void RemoveChild(BTNode _node) {
            int _index = children.IndexOf(_node);
            resList.RemoveAt(_index);
            base.RemoveChild(_node);
        }

        void ResetResults() {
            for (int i = 0; i < resList.Count; i += 1) {
                resList[i] = BTResult.Running;
            }
        }

    }

}