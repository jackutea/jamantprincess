using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class MovableWall : BlockBase {

        public Vector2 moveOffset;
        Vector2 defalutPos;

        public float moveSpeed;
        public float stayTime;
        Sequence action;

        protected override void Awake() {

            base.Awake();

            defalutPos = transform.position;

            if (moveSpeed == 0) {
                moveSpeed = 1;
            } else {
                moveSpeed = Math.Abs(moveSpeed);
            }

            action = DOTween.Sequence();
            action.AppendInterval(stayTime);
            action.Append(transform.DOMove(defalutPos + moveOffset, moveOffset.magnitude / moveSpeed));
            action.AppendInterval(stayTime);
            action.Append(transform.DOMove(defalutPos, moveOffset.magnitude / moveSpeed));
            action.SetLoops(-1);

        }

        protected override void PlayerEnter(ActorBase _actor) {

            _actor.transform.SetParent(transform);

        }

        protected override void PlayerExit(ActorBase _actor) {

            _actor.transform.parent = null;

        }
        
    }

}