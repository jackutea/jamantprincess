using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public enum ButtonColor : byte {

        Red,
        Green,
        Yellow,

    }

    public class DoorButton : BlockBase {

        public UnityEvent openActions;
        public UnityEvent closeActions;
        public bool isOpened = false;
        public ButtonColor buttonColor;
        public Sprite inOff;
        public Sprite inOn;

        public Sprite redOn;
        public Sprite redOff;
        public Sprite greenOn;
        public Sprite greenOff;
        public Sprite yellowOn;
        public Sprite yellowOff;

        [ContextMenu("ReAwake")]
        protected override void Awake() {

            base.Awake();

            switch(buttonColor) {
                case ButtonColor.Green:
                    inOff = greenOff;
                    inOn = greenOn;
                    break;
                case ButtonColor.Red:
                    inOff = redOff;
                    inOn = redOn;
                    break;
                case ButtonColor.Yellow:
                    inOff = yellowOff;
                    inOn = yellowOn;
                    break;
            }

            sr.sprite = inOff;

        }

        protected override void PlayerEnter(ActorBase _actor) {

            if (isOpened) {

                closeActions?.Invoke();
                isOpened = false;
                sr.sprite = inOff;
                
            } else {

                openActions?.Invoke();
                isOpened = true;
                sr.sprite = inOn;

            }

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