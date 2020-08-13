using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace JackUtil {

    public abstract class FSMStateBase<T> {

        public abstract int StateEnum { get; }
        public abstract void Enter(T _actor);
        public abstract void Execute(T _actor);
        public abstract void Exit(T _actor);

    }
}