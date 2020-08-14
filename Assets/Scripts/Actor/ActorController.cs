using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using JackUtil;

namespace Jam {

    [Serializable]
    public class ActorController : MonoBehaviour {

        [NonSerialized]
        ActorBase actor;

        public Vector2 moveAxis;
        public float actAxis;
        public float jumpAxis;
        public float exchangeAxis;
        public float castAxis;

        void Start() {
            actor = GetComponent<ActorBase>();
            actAxis = 0;
            jumpAxis = 0;
            exchangeAxis = 0;
            castAxis = 0;
        }

        void Update() {

        }

        void OnMovement(InputValue _value) {

            moveAxis = _value.Get<Vector2>();

        }

        void OnAct(InputValue _value) {

            actAxis = 1;

        }

        void OnJump(InputValue _value) {

            jumpAxis = _value.Get<float>();

        }

        void OnCast(InputValue _value) {

            castAxis = 1;

        }

        void OnExchange(InputValue _value) {

            exchangeAxis = 1;

        }

    }
}