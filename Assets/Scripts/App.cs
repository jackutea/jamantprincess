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
        public GameObject mapEditor;
        
        public Vector3 cameraOffset = Vector3.zero;
        public string startLevelId;
        Camera mainCam;

        bool isCheat = false;
        public string cheatKey = string.Empty;

        protected override void Awake() {

            base.Awake();

            Destroy(mapEditor);

        }

        void Start() {

            // base.Awake();

            InitMapDic();

            mainCam = Camera.main;
            // cameraOffset = new Vector3(23.95f, 13.5f, -10);
            cameraOffset = new Vector3(20, 11.25f, -10);

            Application.targetFrameRate = 120;

            DontDestroyOnLoad(gameObject);

            actor.Hide();

            // Todo
            // LoadMap(startLevelId);

        }

        void Update() {

            if (App.Instance.actor != null && currentMap != null) {

                mainCam.FollowTargetLimited(App.Instance.actor.transform.position, currentMap.transform.position, currentMap.bounds, cameraOffset, 1f);

            }

            if (Input.GetKeyUp(KeyCode.Home)) {

                isCheat = !isCheat;
                string _msg = isCheat ? "开启作弊模式" : "关闭作弊模式";
                FloatTextGo _float = JUI.PopupFloatText(UIManager.Instance.worldCanvas);
                _float.SetText(_msg);
                _float.FlyUp(actor.transform.position, Color.red);

            }

            if (!isCheat) {
                return;
            }

            if (Input.GetKeyUp(KeyCode.Insert)) {

                if (cheatKey.Length > 2) {

                    string _c = string.Empty;
                    cheatKey = cheatKey.ToLower();
                    _c = (cheatKey.ToUpper()[0]).ToString();
                    _c += cheatKey.Substring(1, cheatKey.Length - 1);

                    print(_c);

                    List<string> _mapId = new List<string>(mapPrefabDic.Keys);
                    foreach (string _str in _mapId) {
                        if (_str == _c) {
                            LoadMap(_str);
                            cheatKey = string.Empty;
                            return;
                        }
                    }

                }

                cheatKey = string.Empty;

            }

            if (Input.anyKey) {

                foreach (KeyCode _kc in Enum.GetValues(typeof(KeyCode))) {

                    if (Input.GetKeyDown(_kc)) {
                        string _k = _kc.ToString();
                        if (_k.Contains("Alpha")) {
                            _k = _k.Replace("Alpha", "");
                        }
                        if (_k.Contains("Insert")) {
                            continue;
                        }
                        cheatKey += _k;
                    }
                }

            }
        }

        void InitMapDic() {

            mapDic = new Dictionary<string, MapGo>();
            mapPrefabDic = new Dictionary<string, GameObject>();

            GameObject[] _prefabArray = Resources.LoadAll<GameObject>("Levels");
            DebugUtil.Log("载入地图数: " + _prefabArray.Length);
            for (int i = 0; i < _prefabArray.Length; i += 1) {
                GameObject _prefab = _prefabArray[i];
                GameObject _go = Instantiate(_prefab);
                _go.SetActive(false);
                MapGo _mapGo = _go.GetComponentInChildren<MapGo>();
                mapDic.Add(_mapGo.levelId, _mapGo);
                mapPrefabDic.Add(_mapGo.levelId, _prefab);
            }

        }

        public void LoadMap(string _mapId) {

            if (currentMap != null) {

                currentMap.transform.parent.gameObject.SetActive(false);

            }

            currentMap = mapDic.GetValue(_mapId);
            if (currentMap == null) {
                DebugUtil.LogError("StartLevelId输入错误: " + startLevelId);
                return;
            }
            currentMap.transform.parent.gameObject.SetActive(true);

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

            actor.Hide();

            CurtainWindow _curtain = JUI.PopupCurtain(UIManager.Instance.uiCanvas);
            _curtain.LeftToRight(() => {
                actor.Show();
                actor.EnterState(StateType.Idle);
                actor.rig.velocity = Vector2.zero;
                actor.controller.Reset();
                actor.transform.position = currentMap.playerStartPos;
                UIManager.Instance.EnterGame();
                Destroy(_curtain.gameObject);
            }, 0.5f, 0.5f, 0.5f);

        }

        void IgnoreCollision() {

        }

    }

}