using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public abstract class JSkillBase : MonoBehaviour {

        public Action<GameObject> enterAction;
        public Action<GameObject> stayAction;
        public Action<GameObject> exitAction;

        public void Ignore(Collider2D _target) {
            Physics2D.IgnoreCollision(_target, GetComponent<Collider2D>());
        }

        protected virtual void OnEnter(GameObject _go) {

        }

        protected virtual void OnStay(GameObject _go) {

        }

        protected virtual void OnExit(GameObject _go) {

        }

        void OnCollisionEnter2D(Collision2D _col) {

        }

        void OnCollisionStay2D(Collision2D _col) {

        }

        void OnCollisionExit2D(Collision2D _col) {

        }

        void OnTriggerEnter2D(Collider2D _col) {

            if (enterAction == null) {

                OnEnter(_col.gameObject);

            } else {

                enterAction.Invoke(_col.gameObject);

            }
            
        }

        void OnTriggerStay2D(Collider2D _col) {

            if (stayAction == null) {

                OnStay(_col.gameObject);

            } else {

                stayAction.Invoke(_col.gameObject);

            }

        }

        void OnTriggerExit2D(Collider2D _col) {

            if (exitAction == null) {

                OnExit(_col.gameObject);

            } else {

                exitAction.Invoke(_col.gameObject);

            }

        }

    }
}