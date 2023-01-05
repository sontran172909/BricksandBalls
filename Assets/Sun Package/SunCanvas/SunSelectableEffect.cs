using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Sun_Package
{
    public class SunSelectableEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Sub-Classes
        [Serializable]
        public class UIButtonEvent : UnityEvent<PointerEventData.InputButton> { }
        #endregion
        
        #region Events
        public bool usingPressEvent;
        public bool usingReleaseEvent;
        public bool usingHeldEvent;
        
        public UIButtonEvent OnButtonPress;
        public UIButtonEvent OnButtonRelease;
        public UIButtonEvent OnButtonHeld;
        
        private bool _pressed;
        private PointerEventData _heldEventData;
        #endregion

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (usingPressEvent) OnButtonPress?.Invoke(eventData.button);
            _pressed = true;
            _heldEventData = eventData;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (usingReleaseEvent) OnButtonRelease?.Invoke(eventData.button);
            _pressed = false;
            _heldEventData = null;
        }

        private void Update()
        {
            if (!_pressed) return;

            if (usingHeldEvent) OnButtonHeld?.Invoke(_heldEventData.button);
        }

        private void OnDisable()
        {
            _pressed = false;
        }
    }
}