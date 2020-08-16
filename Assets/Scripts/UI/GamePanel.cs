using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class GamePanel : MonoBehaviour {

        public GameObject menuPanel;

        void Update() {

            if (isActiveAndEnabled) {

                if (Input.GetKeyUp(KeyCode.Escape)) {

                    if (menuPanel.activeSelf) {

                        menuPanel.SetActive(false);

                    } else {

                        menuPanel.SetActive(true);

                    }

                }

            }
            
        }

        void OnEnable() {

            menuPanel.SetActive(false);
            
        }

        public void CloseMenu() {

            menuPanel.SetActive(false);

        }

        public void BackTitle() {

            UIManager.Instance.EnterTitle();

        }

        public void ExitGame() {

            Application.Quit();

        }

    }
}