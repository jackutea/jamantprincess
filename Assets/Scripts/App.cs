using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackUtil;

namespace Jam {

    public sealed class App : Singleton<App> {

        public ActorBase actor;
        public MapGo currentMap;
        Dictionary<string, MapGo> mapDic;
        Dictionary<string, GameObject> mapPrefabDic;
        
        public Vector3 cameraOffset = Vector3.zero;
        public string startLevelId;
        Camera mainCam;

        protected override void Awake() {

            base.Awake();

            InitMapDic();

            mainCam = Camera.main;
            // cameraOffset = new Vector3(23.95f, 13.5f, -10);
            cameraOffset = new Vector3(15f, 8.5f, -10);

            Application.targetFrameRate = 120;

            DontDestroyOnLoad(gameObject);

            actor.enabled = false;
            actor.Hide();

            LoadMap(startLevelId);

        }

        void InitMapDic() {

            mapDic = new Dictionary<string, MapGo>();
            mapPrefabDic = new Dictionary<string, GameObject>();

            GameObject[] _prefabArray = Resources.LoadAll<GameObject>("Levels");
            DebugUtil.Log("载入地图数: " + _prefabArray.Length);
            for (int i = 0; i < _prefabArray.Length; i += 1) {
                GameObject _prefab = _prefabArray[i];
                GameObject _go = Instantiate(_prefab);
                MapGo _mapGo = _go.GetComponentInChildren<MapGo>();
                mapDic.Add(_mapGo.levelId, _mapGo);
                mapPrefabDic.Add(_mapGo.levelId, _prefab);
            }

        }

        public void LoadMap(string _mapId) {

            if (currentMap != null) {

                currentMap.enabled = false;
                currentMap.Hide();

            }

            currentMap = mapDic.GetValue(_mapId);
            if (currentMap == null) {
                DebugUtil.LogError("StartLevelId输入错误: " + startLevelId);
                return;
            }
            currentMap.enabled = true;
            currentMap.Show();

            ReloadMap();

        }

        public void ReloadMap() {

            if (currentMap == null) {

                DebugUtil.LogError("错误, 不可重载");
                return;

            }

            string _currentMapId = currentMap.levelId;
            Destroy(currentMap.transform.parent.gameObject);
            GameObject _prefab = mapPrefabDic.GetValue(_currentMapId);
            GameObject _go = Instantiate(_prefab);
            MapGo _mapGo = _go.GetComponentInChildren<MapGo>();
            mapDic.AddOrReplace(_currentMapId, _mapGo);
            currentMap = _mapGo;

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

            if (App.Instance.actor != null && currentMap != null) {

                mainCam.FollowTargetLimited(App.Instance.actor.transform.position, currentMap.transform.position, currentMap.bounds, cameraOffset, 1f);

            }

        }

        void IgnoreCollision() {

        }

    }

}