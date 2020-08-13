using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace JackUtil {

    public class JUIDemo : MonoBehaviour {

        static JUIDemo m_instance;
        public static JUIDemo Instance { get => m_instance; }

        public Camera uiCamera;
        public Canvas uiCanvas;

        public float shakeDuration;
        public float shakeStrengh;
        public int shakePower;
        public float randomNess;

        [ContextMenu("ReStart")]
        void Start() {

            if (m_instance == null) m_instance = this;

            // uiCamera.DOShakePosition(shakeDuration, shakeStrengh, shakePower, randomNess, false);

            // AlertWindow 弹出提示窗(自动渐隐)
            // AlertWindow _alertWindow = JUI.PopupAlert(uiCanvas, Vector2.zero);
            // _alertWindow.AddContent("哈楼");

            // DialogWindow 对话窗
            DialogWindow _dialogWindow = JUI.PopupDialog(uiCanvas, null, "玩家名", null, "NPC名", () => {

                // DebugUtil.Log("对话结束调用的方法");

            });
            _dialogWindow.AddContent(true, "Hifffffffffffffffffffffffffffffffffffffffffffffffffffffffffff"); // true为玩家说话
            _dialogWindow.AddContent(false, "there"); // false 为Npc说话

            _dialogWindow.NextContent(); // 继续对话 通常按某个键后执行它



            // // CheckWindow 确认窗
            // PopupCheckWindow _checkWindow = JUI.PopupConfirm(uiCanvas, "确认框标题", "点击领取一个赞",

            //     // 确认事件, 如果为null 则默认点击关闭
            //     () => {},

            //     // 取消事件, 如果为null 则默认点击关闭
            //     null 

            // );



            // // OptionWindow 选项窗
            // OptionWindow _optionWindow = JUI.PopupOption(uiCanvas, "通常标题可用Npc名", "请选择下列选项");
            // OptionButtonGo _option1 = _optionWindow.AddOption("选项名1", () => {
            //     // DebugUtil.Log("选择该选项执行的事件");
            // });
            // _optionWindow.AddOption("选项名2", () => {
            //     // DebugUtil.Log("选择该选项执行的事件");
            // });
            // _optionWindow.AddOption("取消", null);
            // _optionWindow.SetDefaultOption(_option1); // 设定默认选项, 如不设置, 默认为第一个选项



            // // NoticeWIndow 常驻提示
            // NoticeWindow _noticeWindow = JUI.PopupNotice(uiCanvas, Vector2.zero);
            // _noticeWindow.AddContent("通用用于鼠标移到物件上的提示");
            // _noticeWindow.SetBgColor(Color.white.GetTransparent());
            // _noticeWindow.SetMaxWidth(120);

            // // BagWindow 背包窗
            // // 通常缓存起来使用
            // // 支持背包内物品拖拽
            // BagWindow _bagWindwo = JUI.PopupBagWindow(uiCanvas, 16);
            // _bagWindwo.Show(); // 显示背包

            // // CurtainWindow 幕布窗
            // CurtainWindow _curtainWindow = JUI.PopupCurtain(uiCanvas);
            // _curtainWindow.TopToBottom();

        }
    }
}