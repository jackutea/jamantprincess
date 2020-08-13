using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public class JUI : MonoBehaviour {

        static JUI m_instance;
        public static JUI Instance { get => m_instance; }

        public Camera uiCamera;
        public Canvas uiCanvas;
        public Canvas worldCanvas;

        void Awake() {

            m_instance = m_instance ?? this;

            DontDestroyOnLoad(gameObject);

        }

        public static CurtainWindow PopupCurtain(Canvas _canvas) {

            CurtainWindow _prefab = JUIPrefabCollection.Instance.curtainWindowPrefab;

            CurtainWindow _go = GameObject.Instantiate(_prefab, _canvas.transform);

            return _go;
            
        }

        public static PopupCheckWindow PopupConfirm(Canvas _canvas, string _title, string _content, Action _yesAction, Action _noAction) {

            PopupCheckWindow _popPrefab = JUIPrefabCollection.Instance.popupCheckWindowPrefab;

            PopupCheckWindow _popGo = GameObject.Instantiate(_popPrefab, _canvas.transform);

            _popGo.SetTexts(_title, _content);

            _popGo.BindingYes(_yesAction);

            _popGo.BindingNo(_noAction);

            return _popGo;

        }

        public static OptionWindow PopupOption(Canvas _canvas, string _title, string _content) {

            OptionWindow _popPrefab = JUIPrefabCollection.Instance.optionWindowPrefab;

            OptionWindow _popGo = GameObject.Instantiate(_popPrefab, _canvas.transform);

            _popGo.SetTexts(_title, _content);

            return _popGo;
            
        }

        public static DialogWindow PopupDialog(Canvas _canvas, Sprite _playerSprite, string _playerName, Sprite _npcSprite, string _npcName, Action _endTalkAction) {

            DialogWindow _dialogPrefab = JUIPrefabCollection.Instance.dialogWindowPrefab;

            DialogWindow _dialogGo = GameObject.Instantiate(_dialogPrefab, _canvas.transform);

            _dialogGo.SetTalkerInfo(_playerSprite, _playerName, _npcSprite, _npcName, _endTalkAction);

            return _dialogGo;

        }

        public static BagWindow PopupBagWindow(Canvas _canvas, int _maxSlot) {

            BagWindow _bagPrefab = JUIPrefabCollection.Instance.bagWindowPrefab;

            BagWindow _bagWindowGo = GameObject.Instantiate(_bagPrefab, _canvas.transform);

            _bagWindowGo.SetBagSlot(_maxSlot);

            return _bagWindowGo;

        }

        public static NoticeWindow PopupNotice(Canvas _canvas, Vector2 _offsetLocalPosition = default) {

            NoticeWindow _noticePrefab = JUIPrefabCollection.Instance.noticeWindowPrefab;

            NoticeWindow _noticeWindow = GameObject.Instantiate(_noticePrefab, _canvas.transform);

            _noticeWindow.SetNotice();
            _noticeWindow.transform.localPosition = _offsetLocalPosition;

            return _noticeWindow;

        }

        public static AlertWindow PopupAlert(Canvas _canvas, Vector2 _offsetLocalPosition = default) {

            AlertWindow _alertPrefab = JUIPrefabCollection.Instance.alertWindowPrefab;

            AlertWindow _alertWindow = GameObject.Instantiate(_alertPrefab, _canvas.transform);

            _alertWindow.SetAlert();
            _alertWindow.transform.localPosition = _offsetLocalPosition;
            
            return _alertWindow;
        }

        public static FloatTextGo PopupFloatText(Canvas _canvas) {

            FloatTextGo _prefab = JUIPrefabCollection.Instance.floatTextPrefab;

            FloatTextGo _go = GameObject.Instantiate(_prefab, _canvas.transform);

            return _go;

        }

    }
}