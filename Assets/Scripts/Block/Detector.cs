using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class Detector : BlockBase {

        public UnityEvent enterAction;
        public UnityEvent stayAction;
        public UnityEvent exitAction;

        protected override void Awake() {
            base.Awake();
            sr.sprite = null;
        }

        protected override void PlayerEnter(ActorBase _actor) {
            enterAction?.Invoke();
        }

        protected override void PlayerStay(ActorBase _actor) {
            stayAction?.Invoke();
        }

        protected override void PlayerExit(ActorBase _actor) {
            exitAction?.Invoke();
        }
    }
}