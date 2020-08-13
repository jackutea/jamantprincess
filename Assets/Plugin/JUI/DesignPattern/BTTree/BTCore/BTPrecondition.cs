using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public abstract class BTPrecondition : BTNode {

        public virtual bool Check() {

            return true;

        }

        public override BTResult Tick() {
            bool _res = Check();
            if (_res) {
                return BTResult.Ended;
            } else {
                return BTResult.Running;
            }
        }

    }
}