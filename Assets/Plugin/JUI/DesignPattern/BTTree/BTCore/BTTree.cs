using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public abstract class BTTree : MonoBehaviour {

        public virtual BTNode rootNode { get; protected set; }
        public BTContext context;
        public bool isActived = false;

        protected virtual void Awake() {

            context = GetComponent<BTContext>();
            
        }

        public abstract void Activated();

        public virtual void Activated(BTContext _context) {
            context = _context;
        }

    }

}