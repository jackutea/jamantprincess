using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackUtil;

namespace Jam {

    public sealed class App : MonoBehaviour {

        void Awake() {

            Application.targetFrameRate = 60;

            DontDestroyOnLoad(gameObject);

        }

    }
}