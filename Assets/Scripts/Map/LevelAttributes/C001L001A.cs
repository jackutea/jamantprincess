using UnityEngine;
using JackUtil;

namespace Jam {

    public class C001L001A : LevelAttributes {

        public Transform moveNoticeTransform;
        public Transform jumpNoticeTransform;
        public Transform changeBodyNoticeTransform;

        NoticeWindow jumpNotice;
        NoticeWindow moveNotice;
        NoticeWindow changeNotice;

        void Start() {

            jumpNotice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            jumpNotice.transform.position = jumpNoticeTransform.position;
            jumpNotice.AddContent("按\"K\"或\"空格\"跳跃");

            moveNotice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            moveNotice.transform.position = moveNoticeTransform.position;
            moveNotice.AddContent("按\"WSAD\"移动");

            changeNotice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            changeNotice.transform.position = changeBodyNoticeTransform.position;
            changeNotice.AddContent("按\"L\"切换体形");

        }

        void OnDisable() {

            print("dis");

            Destroy(jumpNotice.gameObject);
            Destroy(moveNotice.gameObject);
            Destroy(changeNotice.gameObject);
        }
    }
}