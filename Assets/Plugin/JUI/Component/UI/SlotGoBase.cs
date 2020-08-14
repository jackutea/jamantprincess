using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace JackUtil {

    public class SlotGoBase : MonoBehaviour, IComparable<SlotGoBase>, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

        public int index;
        CanvasGroup canvasGroup;
        [HideInInspector]
        public Sprite defaulSprite;
        public Image image;
        public Text text;

        public event Action<SlotGoBase> enterAction;
        public event Action exitAction;
        public event Action<SlotGoBase> endDragAction;

        RectTransform rectTransform;
        public Vector2 defalutPos = Vector2.zero;
        Vector2 outPos;

        void Start() {

            canvasGroup = GetComponent<CanvasGroup>();

        }

        public void RenderItem(int _index, Sprite _sprite, string _text) {

            index = _index;

            defaulSprite = image.sprite;

            image.sprite = _sprite == null ? defaulSprite : _sprite;
            text.text = _text;

        }

        public virtual void UseThis() {

            print("(未重写)使用物品");

        }

        public virtual void ShowInfo() {

        }

        public virtual void HideInfo() {

        }

        public virtual void DestroyItem() {

        }

        public int CompareTo(SlotGoBase _itemGo) {

            if (index == _itemGo.index) {
                return 0;
            }
            if (index < _itemGo.index) {
                return -1;
            }
            if (index > _itemGo.index) {
                return 1;
            }

            return index.CompareTo(_itemGo.index);

        }

        public void OnPointerClick(PointerEventData _e) {

            if (_e.button == PointerEventData.InputButton.Right) {

                UseThis();

            }

        }

        // 鼠标进入显示物品信息
        public void OnPointerEnter(PointerEventData _e) {

            enterAction?.Invoke(this);

            if (enterAction == null) {
                // DebugUtil.Log("未绑定 Enter 事件");
            }

            // 弹出信息
            ShowInfo();

            // 记录初始坐标
            defalutPos = transform.localPosition;
        }

        public void OnPointerExit(PointerEventData _e) {

            exitAction?.Invoke();

            HideInfo();

        }

        public void OnBeginDrag(PointerEventData _e) {

            canvasGroup.blocksRaycasts = false;

            rectTransform = transform.parent.GetComponent<RectTransform>();

        }

        public void OnDrag(PointerEventData _e) {

            outPos = rectTransform.ScreenToLocalPosition(Input.mousePosition, _e.enterEventCamera);
            transform.localPosition = outPos;

        }

        public void OnEndDrag(PointerEventData _e) {

            // print(_e.pointerCurrentRaycast.gameObject);

            endDragAction?.Invoke(this);

            canvasGroup.blocksRaycasts = true;

        }

        public void PutDefaultPosition() {

            transform.localPosition = defalutPos;

        }

    }

}