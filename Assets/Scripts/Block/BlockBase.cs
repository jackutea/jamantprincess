using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class BlockBase : MonoBehaviour {

        protected virtual void PlayerEnter(ActorBase _actor) {

        }

        protected virtual void PlayerStay(ActorBase _actor) {

        }

        protected virtual void PlayerExit(ActorBase _actor) {

        }

        protected virtual void OnMouseEnter() {

            // print("Enter: " + name);

        }

        protected virtual void OnMouseOver() {

            // print("Over: ");

        }

        protected virtual void OnMouseDown() {

            // print("Down: ");

        }

        protected virtual void OnMouseUp() {

            // print("Up: ");

        }

        protected virtual void OnMouseExit() {

            // print("Exit: ");

        }

        protected virtual void OnCollisionEnter2D(Collision2D _col) {

            if (_col.gameObject.tag == TagCollection.playerTag) {

                PlayerEnter(_col.gameObject.GetComponent<ActorBase>());

            }

        }

        protected virtual void OnCollisionStay2D(Collision2D _col) {

            if (_col.gameObject.tag == TagCollection.playerTag) {

                PlayerStay(_col.gameObject.GetComponent<ActorBase>());

            }
            
        }

        protected virtual void OnCollisionExit2D(Collision2D _col) {

            if (_col.gameObject.tag == TagCollection.playerTag) {

                PlayerExit(_col.gameObject.GetComponent<ActorBase>());

            }

        }

        protected virtual void OnTriggerEnter2D(Collider2D _col) {

            if (_col.gameObject.tag == TagCollection.playerTag) {

                PlayerEnter(_col.gameObject.GetComponent<ActorBase>());

            }

        }

        protected virtual void OnTriggerStay2D(Collider2D _col) {

            if (_col.gameObject.tag == TagCollection.playerTag) {

                PlayerStay(_col.gameObject.GetComponent<ActorBase>());

            }
            
        }

        protected virtual void OnTriggerExit2D(Collider2D _col) {

            if (_col.gameObject.tag == TagCollection.playerTag) {

                PlayerExit(_col.gameObject.GetComponent<ActorBase>());

            }
            
        }

    }
}