using UnityEngine;
using JackUtil;

namespace Jam {

    public class C001L005A : LevelAttributes {

        public Transform noticeTransform;
        NoticeWindow notice;

        void Start() {

            notice = JUI.PopupNotice(UIManager.Instance.worldCanvas);
            notice.transform.position = noticeTransform.position;
            notice.AddContent("起跳时，从大变小，可提升跳跃高度");

        }

        void OnDisable() {

            if (notice == null) return;

            Destroy(notice.gameObject);

        }
    }
}