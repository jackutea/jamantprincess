using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackUtil;

namespace Jam {

    public sealed class App : Singleton<App> {

        public ActorBase actor;
        public MapGo currentMap;
        
        public Vector3 cameraOffset = Vector3.zero;
        Camera mainCam;

        protected override void Awake() {

            base.Awake();

            // cameraOffset = new Vector3(23.95f, 13.5f, -10);
            cameraOffset = new Vector3(15f, 8.5f, -10);

            mainCam = Camera.main;

            Application.targetFrameRate = 120;

            DontDestroyOnLoad(gameObject);

        }

        public void InitLoadMap(string _mapId) {

        }

        public void ReloadMap() {

            actor.enabled = false;
            actor.Hide();

            CurtainWindow _curtain = JUI.PopupCurtain(UIManager.Instance.uiCanvas);
            _curtain.LeftToRight(() => {
                actor.enabled = true;
                actor.Show();
                actor.transform.position = currentMap.playerStartPos;
            }, 0.5f, 0.5f, 0.3f);

        }

        void Update() {

            if (App.Instance.actor != null) {

                mainCam.FollowTargetLimited(App.Instance.actor.transform.position, currentMap.transform.position, currentMap.bounds, cameraOffset, 1f);

            }

        }

        void IgnoreCollision() {

        }

    }

}