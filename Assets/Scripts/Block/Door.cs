using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class Door : BlockBase {

        public Sprite doorClosed;
        public Sprite doorOpened;
        public bool isOpened = false;

        Collider2D col;

        protected override void Awake() {

            base.Awake();

            col = GetComponent<Collider2D>();

        }

        public void Activated(bool _isOpen) {

            isOpened = _isOpen;

            if (isOpened) {

                sr.sprite = doorOpened;
                col.enabled = false;

            } else {

                sr.sprite = doorClosed;
                col.enabled = true;

            }

        }

    }
}