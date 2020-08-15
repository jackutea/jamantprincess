using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class LevelAttributes : MonoBehaviour {

        public void TransLevel(string _levelId) {

            App.Instance.LoadMap(_levelId);
            
        }
    }
}