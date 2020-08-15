using UnityEngine;
using JackUtil;

namespace Jam {

    public class C001L005A : LevelAttributes {

        public Transform noticeTransform;
        NoticeWindow notice;

        void Start() {

            notice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            notice.transform.position = noticeTransform.position;
            notice.AddContent("起跳时，从大切换至小体形，并按住\"K\"，可以提升跳跃高度");

        }

        void OnDisable() {

            if (notice == null) return;

            Destroy(notice.gameObject);

        }
    }
}