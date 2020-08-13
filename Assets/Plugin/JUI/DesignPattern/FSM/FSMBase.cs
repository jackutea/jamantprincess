using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace JackUtil {

    public class FSMBase<T> {

        public bool isRunning;
        public FSMStateBase<T> currentState;
        Dictionary<int, FSMStateBase<T>> stateDic;

        T actor;

        public FSMBase(T _actor) {

            actor = _actor;

            stateDic = new Dictionary<int, FSMStateBase<T>>();

        }

        public void StartFSM(FSMStateBase<T> _state) {

            isRunning = true;

            currentState = _state;

        }

        public void RegisterState(FSMStateBase<T> _state) {

            stateDic.Add(_state.StateEnum, _state);

            if (currentState == null) {

                StartFSM(_state);

            }

        }

        public void EnterState(int _enum) {

            if (currentState == null) {
                DebugUtil.LogError("当前无状态, 这是不应该出现的情况");
                return;
            }

            if (_enum == currentState.StateEnum) {
                // DebugUtil.Log("进入的状态相同");
                return;
            }

            FSMStateBase<T> _targetState = stateDic.GetValue(_enum);
            if (_targetState == null) {
                DebugUtil.LogError("错误的Enum: " + _enum.ToString());
            }
            currentState.Exit(actor);
            currentState = _targetState;
            currentState.Enter(actor);

        }

        public void Execute() {

            if (!isRunning) return;

            if (currentState == null) return;

            currentState.Execute(actor);

        }

    }
}