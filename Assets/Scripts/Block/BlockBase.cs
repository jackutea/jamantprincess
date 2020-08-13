using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class BlockBase : MonoBehaviour {

        protected virtual void OnCollisionEnter2D(Collision2D _col) {

        }

        protected virtual void OnCollisionStay2D(Collision2D _col) {
            
        }

        protected virtual void OnCollisionExit2D(Collision2D _col) {

        }

        protected virtual void OnTriggerEnter2D(Collider2D _col) {

        }

        protected virtual void OnTriggerStay2D(Collider2D _col) {
            
        }

        protected virtual void OnTriggerExit2D(Collider2D _col) {
            
        }

    }
}