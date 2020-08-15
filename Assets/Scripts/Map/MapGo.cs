using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class MapGo : MonoBehaviour {

        public string levelId;

        Camera mainCam;
        Tilemap tilemap;

        public Vector2 playerStartPos;
        public BoundsInt bounds;

        protected virtual void Awake() {

            tilemap = GetComponent<Tilemap>();

        }

        void Update() {

            

        }

    }
}