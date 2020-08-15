using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class DoorButton : BlockBase {

        public UnityEvent enterActions;
        public bool isOpened = false;
        public Sprite closed;
        public Sprite opened;

        protected override void PlayerEnter(ActorBase _actor) {

            enterActions?.Invoke();

            isOpened = true;

            sr.sprite = opened;

        }

        void Activated() {

            // if (isOpened) {

            //     sr.sprite = opened;

            // } else {

            //     sr.sprite = closed;

            // }
        }
    }
}