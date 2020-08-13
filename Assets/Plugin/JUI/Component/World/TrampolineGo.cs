using System;
using UnityEngine;

namespace JackUtil {

    public class TrampolineGo : MonoBehaviour {

        public float horizontalForce = 10;
        public float jumpForce = 28;

        void OnCollisionEnter2D(Collision2D _col) {
            if (_col.gameObject.tag == "Player") {
                Rigidbody2D _rig = _col.gameObject.GetComponent<Rigidbody2D>();
                _rig.AddForce(new Vector2(horizontalForce, jumpForce), ForceMode2D.Impulse);
            }
        }

    }
}