using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackUtil;

namespace Jam {

    public sealed class App : Singleton<App> {

        public ActorBase actor;
        public MapGo currentMap;
        
        static Vector3 cameraOffset = Vector3.zero;
        Camera mainCam;

        protected override void Awake() {

            base.Awake();

            cameraOffset = new Vector3(23.95f, 13.5f, -10);

            mainCam = Camera.main;

            Application.targetFrameRate = 120;

            DontDestroyOnLoad(gameObject);

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