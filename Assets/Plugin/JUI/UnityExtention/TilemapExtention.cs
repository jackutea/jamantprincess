using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JackUtil {

    public static class TilemapExtention {

        public static Vector3Int GetTilePos(this Tilemap _tileMap, Vector3 _worldPos) {

            Vector3Int _pos = _tileMap.WorldToCell(_worldPos);

            return _pos;

        }

        public static string[,] ToStringArray(this Tilemap _tileMap, BoundsInt _bounds) {

            Vector3Int _tempPos = Vector3Int.zero;

            TileBase _tb;
            string[,] _dataArr = new string[_bounds.size.x, _bounds.size.y];
            for (int i = 0; i < _bounds.size.x; i += 1) {
                for (int j = 0; j < _bounds.size.y; j += 1) {
                    _tempPos.Set(i, j, 0);
                    _tb = _tileMap.GetTile(_tempPos);
                    if (_tb == null) {
                        _dataArr[i, j] = string.Empty;
                    } else {
                        _dataArr[i, j] = _tb.name;
                    }
                    // print("存入:" + _dataArr[i, j]);
                }
            }

            return _dataArr;

        }
    }
}
