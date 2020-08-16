using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class TitlePanel : MonoBehaviour {

        void Update() {

            if (isActiveAndEnabled) {

                if (Input.GetKeyUp(KeyCode.J)) {

                    App.Instance.LoadMap("Nio001");

                    this.Hide();

                } else if (Input.GetKeyUp(KeyCode.Escape)) {

                    Application.Quit();
                    
                }

            }
        }
    }
}