using UnityEngine;
using JackUtil;

namespace Jam {

    public class C001L005A : LevelAttributes {

        public Transform noticeTransform;

        void Start() {

            NoticeWindow _notice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            _notice.transform.position = noticeTransform.position;
            _notice.AddContent("起跳时，从大切换至小体形，并按住\"K\"，可以提升跳跃高度");

        }
    }
}