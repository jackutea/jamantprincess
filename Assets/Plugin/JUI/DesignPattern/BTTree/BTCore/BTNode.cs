using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    // --------
    // 行为节点基类:
    // ① 子节点
    // ② 前置条件
    // ③ 数据上下文
    // --------
    public abstract class BTNode {

        protected List<BTNode> children;
        protected BTPrecondition precondition;
        protected BTContext context;
        protected bool isActived;

        public float interval = 0;
        float lastTimeEvaluated = 0;

        public BTNode(BTPrecondition _precondition = null) {

            precondition = _precondition;

        }

        // 激活
        public virtual void Activate(BTContext _context) {

            if (isActived) return;

            context = _context;

            if (precondition != null) {

                precondition.Activate(_context);

            }

            if (children != null) {

                foreach (BTNode _node in children) {

                    _node.Activate(_context);

                }

            }

            isActived = true;

        }

        // 评估是否进入该节点
        public bool Evaluate() {

            return isActived && CheckTimer() && (precondition == null || precondition.Check()) && DoEvaluate();

        }

        public virtual bool DoEvaluate() {
            
            return true;

        }

        public virtual BTResult Tick() {

            return BTResult.Ended;

        }

        public virtual void AddChild(BTNode _node) {

            if (children == null) {

                children = new List<BTNode>();

            }

            if (_node != null) {

                children.Add(_node);

            }
        }

        public virtual void RemoveChild(BTNode _node) {

            if (children != null && _node != null) {

                children.Remove(_node);

            }
        }

        bool CheckTimer() {
            if (Time.time - lastTimeEvaluated > interval) {
                lastTimeEvaluated = Time.time;
                return true;
            }
            return false;
        }

        public virtual void Reset() {

        }

    }

}