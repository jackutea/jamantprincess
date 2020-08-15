using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class Prick : BlockBase {

        public Sprite normal;
        public Sprite hiding;
        public bool startHiding;
        public bool isStatic = true;
        public float gapTime;
        Collider2D col;
        Sequence action;

        protected override void Awake() {

            base.Awake();

            col = GetComponent<Collider2D>();

            if (startHiding) {

                sr.sprite = hiding;

            } else {

                sr.sprite = normal;

            }

            if (!isStatic) {

                action = DOTween.Sequence();
                action.AppendInterval(gapTime);
                action.AppendCallback(SwitchActivated);
                action.SetLoops(-1);

            }

        }

        void SwitchActivated() {

            if (sr.sprite == hiding) {
                sr.sprite = normal;
                col.enabled = true;
            } else if (sr.sprite == normal) {
                sr.sprite = hiding;
                col.enabled = false;
            }

        }

        protected override void PlayerEnter(ActorBase _actor) {

            _actor.Dead();

        }

    }
}