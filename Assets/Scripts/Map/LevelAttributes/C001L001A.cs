using UnityEngine;
using JackUtil;

namespace Jam {

    public class C001L001A : LevelAttributes {

        public Transform moveNoticeTransform;
        public Transform jumpNoticeTransform;
        public Transform changeBodyNoticeTransform;

        void Start() {

            NoticeWindow _notice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            _notice.transform.position = jumpNoticeTransform.position;
            _notice.AddContent("按\"K\"或\"空格\"跳跃");

            NoticeWindow _moveNotice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            _moveNotice.transform.position = moveNoticeTransform.position;
            _moveNotice.AddContent("按\"WSAD\"移动");

            NoticeWindow _changeBodyNotice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            _changeBodyNotice.transform.position = changeBodyNoticeTransform.position;
            _changeBodyNotice.AddContent("按\"L\"切换体形");

        }
    }
}