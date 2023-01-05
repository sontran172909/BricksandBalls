using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Sun_Package
{
    // ================== //
    public enum Style { Once, Loop, LoopWithCount }

    // ================== //
    public enum Direction { Forward, Reverse }

    // ================== //
    public enum EventWhen { None, Forward, Reverse, Both }

    // ================== //
    public enum DelayWhen { None, Forward, Reverse, Both }

    // ================== //
    public enum GroupTween { Show, Hide, Other }

    public abstract class SunTween : MonoBehaviour
    {
        #region Fields
        
        public GroupTween groupTween;
        public int tweenIndex;
        public bool isActive = true;
        public float duration = .5f;
        public RectTransform mainTarget;

        public bool isAutoPlay;
        public Direction direction = Direction.Forward;

        public bool enableBeforeForward;
        public bool disableAfterReverse;

        public bool sameStyleInReverse = true;
        public Ease easeForward = Ease.OutBack;
        public Style styleForward = Style.Once;
        public Ease easeReverse = Ease.InBack;
        public Style styleReverse = Style.Once;

        public LoopType loopStyle = LoopType.Yoyo;
        public int loopCount = -1;

        public DelayWhen delayWhen = DelayWhen.None;
        public float delay;

        public EventWhen startEventWhen = EventWhen.None;
        public EventWhen finishedEventWhen = EventWhen.None;
        public UnityEvent onStart;
        public UnityEvent onFinished;

        public bool Animating { get; set; }
        public Tween MainTween { get; set; }

        #endregion

        #region Unity callback functions

        private void Reset()
        {
            mainTarget = GetComponent<RectTransform>();
            LoadInReset();
        }

        private void Awake()
        {
            LoadInAwake();
        }

        private void OnEnable()
        {
            if (isActive && isAutoPlay)
            {
                switch (direction)
                {
                    case Direction.Forward:
                        PlayForward();
                        break;
                    case Direction.Reverse:
                        PlayReverse();
                        break;
                }
            }
        }

        #endregion

        #region Tween functions

        public virtual void LoadInReset() { }
        public virtual void LoadInAwake() { }

        public abstract void PlayForward();
        public abstract void PlayReverse();
        public abstract void Play(bool forward = true);
        public abstract void Stop(bool complete = false);
        
        public abstract void SetCurrentValueToStart();
        public abstract void SetCurrentValueToEnd();

        public abstract void SetStartToCurrentValue();
        public abstract void SetEndToCurrentValue();

        public void SetMainTarget()
        {
            mainTarget = GetComponent<RectTransform>();
        }

        public void AddListenerToStart(UnityAction listener) => onStart.AddListener(listener);
        public void AddListenerToEnd(UnityAction listener) => onFinished.AddListener(listener);

        #endregion
    }
}