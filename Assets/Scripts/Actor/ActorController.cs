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

        [HideInInspector]
        public Vector2 moveAxis;
        [HideInInspector]
        public float actAxis;
        [HideInInspector]
        public float jumpAxis;
        [HideInInspector]
        public float exchangeAxis;
        [HideInInspector]
        public float castAxis;
        public float changeBiggerAxis;
        public float changeSmallerAxis;

        void Start() {
            actor = GetComponent<ActorBase>();
            Reset();
        }

        public void Reset() {

            actAxis = 0;
            jumpAxis = 0;
            exchangeAxis = 0;
            castAxis = 0;
            changeBiggerAxis = 0;
            changeSmallerAxis = 0;

        }

        void OnMovement(InputValue _value) {

            moveAxis = _value.Get<Vector2>();
            // print("OnMove: " + moveAxis);

        }

        void OnAct(InputValue _value) {

            actAxis = 1;
            // print("OnAct");

        }

        void OnJump(InputValue _value) {

            jumpAxis = _value.Get<float>();
            // print("OnJump: " + jumpAxis);

        }

        void OnCast(InputValue _value) {

            castAxis = 1;
            // print("OnCast");

        }

        void OnExchange(InputValue _value) {

            exchangeAxis = 1;
            // print("OnExchange");

        }

        void OnChangeBigger(InputValue _value) {

            changeBiggerAxis = 1;

        }

        void OnChangeSmaller(InputValue _value) {

            changeSmallerAxis = 1;

        }

    }
}