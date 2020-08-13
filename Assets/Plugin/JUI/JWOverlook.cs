using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    // JWorld
    public class JWOverlook : MonoBehaviour {

        public static SwordMelee CastSwordMelee(Transform _caster) {

            GameObject _prefab = JUIPrefabCollection.Instance.swordMeleePrefab;

            SwordMelee _go = Instantiate(_prefab, _caster).GetComponentInChildren<SwordMelee>();

            return _go;

        }

    }
}