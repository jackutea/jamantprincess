using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class MapGo : MonoBehaviour {

        Tilemap tilemap;

        protected virtual void Awake() {

            tilemap = GetComponent<Tilemap>();

        }

        void Update() {

            Vector2Int _pos = tilemap.GetMouseTilePos(Camera.main.GetMouseWorldPosition(Input.mousePosition));

            print(_pos);
            
        }

    }
}