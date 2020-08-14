using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JackUtil;

namespace Jam {

    public class ActorBase : MonoBehaviour {

        FSMBase<ActorBase> fsm;

        public float moveSpeed;

        protected virtual void Awake() {

            fsm = new FSMBase<ActorBase>(this);
            fsm.RegisterState(new ActorStateIdle());

        }

        protected virtual void EnterState(StateType _type) {
            fsm.EnterState(_type.ToInt());
        }

    }
}