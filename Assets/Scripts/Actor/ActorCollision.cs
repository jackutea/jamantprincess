using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jam {

    public class ActorCollision : MonoBehaviour {

        public Collider2D col;
        public LayerMask groundLayer;

        public bool isOnGround;
        public bool isOnWall;
        public bool isOnLeftWall;
        public bool isOnRightWall;
        public bool isClimbOverPlatform;

        public Vector2 bottomOffset, leftOffset, rightOffset, climbUpOffset;
        public float collisionRadius;
        public Vector2 collisionSquareSize;

        void Start() {

            col = GetComponent<Collider2D>();

        }

        void FixedUpdate() {

            isOnGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
            isOnLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);
            isOnRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
            isClimbOverPlatform = Physics2D.OverlapBox((Vector2)transform.position + climbUpOffset, collisionSquareSize, 0, groundLayer) == null;
            isOnWall = isOnLeftWall || isOnRightWall;

        }

        public bool IsMoveToWall(float _xAxis) {
            if (_xAxis < 0 && isOnLeftWall) return true;
            if (_xAxis > 0 && isOnRightWall) return true;
            return false;
        }

        void OnDrawGizmos() {

            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
            Gizmos.DrawWireCube((Vector2)transform.position + climbUpOffset, collisionSquareSize);

        }

    }
}