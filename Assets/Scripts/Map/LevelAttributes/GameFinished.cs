using System;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class GameFinished : MonoBehaviour {

        public void PopOver() {

            DialogWindow _dialog = JUI.PopupDialog(UIManager.Instance.uiCanvas, null, "神秘人", null, "神秘人", () => {
                UIManager.Instance.EnterTitle();
            });
            _dialog.AddContent(true, "感谢试玩~\n游戏Demo暂时只做到这里");
            _dialog.AddContent(true, "祝您身心健康!");
            _dialog.NextContent();

        }
    }
}