﻿using DG.Tweening;
using UnityEngine;

namespace Sun_Package
{
    public class SunTweenScale : SunTween
    {
        #region Fields

        public Vector3 from = Vector3.zero;
        public Vector3 to = Vector3.zero;

        #endregion

        #region Tween

        // ReSharper disable Unity.PerformanceAnalysis
        private void SetTweenForward(Vector3 f, Vector3 t)
        {
            if (MainTween != null && MainTween.IsActive())
            {
                if (!MainTween.IsComplete())
                {
                    MainTween.Kill();
                }
            }
            else
            {
                mainTarget.localScale = f;
            }

            if (enableBeforeForward) mainTarget.gameObject.SetActive(true);
            switch (styleForward)
            {
                case Style.Once:
                    MainTween = mainTarget.DOScale(t, duration)
                        .SetDelay(delayWhen == DelayWhen.Both || delayWhen == DelayWhen.Forward ? delay : 0)
                        .SetEase(easeForward)
                        .OnStart(() =>
                        {
                            if (startEventWhen == EventWhen.Forward || startEventWhen == EventWhen.Both)
                                onStart?.Invoke();
                            Animating = true;
                        })
                        .OnComplete(() =>
                        {
                            if (finishedEventWhen == EventWhen.Forward || finishedEventWhen == EventWhen.Both)
                                onFinished?.Invoke();
                            Animating = false;
                        });
                    break;
                case Style.Loop:
                    MainTween = mainTarget.DOScale(t, duration)
                        .SetDelay(delayWhen == DelayWhen.Both || delayWhen == DelayWhen.Forward ? delay : 0)
                        .SetLoops(-1, loopStyle)
                        .SetEase(easeForward)
                        .OnStart(() =>
                        {
                            if (startEventWhen == EventWhen.Forward || startEventWhen == EventWhen.Both)
                                onStart?.Invoke();
                            Animating = true;
                        });
                    break;
                case Style.LoopWithCount:
                    MainTween = mainTarget.DOScale(t, duration)
                        .SetDelay(delayWhen == DelayWhen.Both || delayWhen == DelayWhen.Forward ? delay : 0)
                        .SetLoops(loopCount * 2, loopStyle)
                        .SetEase(easeForward)
                        .OnStart(() =>
                        {
                            if (startEventWhen == EventWhen.Forward || startEventWhen == EventWhen.Both)
                                onStart?.Invoke();
                            Animating = true;
                        })
                        .OnComplete(() =>
                        {
                            if (finishedEventWhen == EventWhen.Forward || finishedEventWhen == EventWhen.Both)
                                onFinished?.Invoke();
                            Animating = false;
                        });
                    break;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void SetTweenReverse(Vector3 f, Vector3 t)
        {
            if (MainTween != null && MainTween.IsActive())
            {
                if (!MainTween.IsComplete())
                {
                    MainTween.Kill();
                }
            }
            else
            {
                mainTarget.localScale = f;
            }

            switch (sameStyleInReverse ? styleForward : styleReverse)
            {
                case Style.Once:
                    MainTween = mainTarget.DOScale(t, duration)
                        .SetDelay(delayWhen == DelayWhen.Both || delayWhen == DelayWhen.Reverse ? delay : 0)
                        .SetEase(sameStyleInReverse ? easeForward : easeReverse)
                        .OnStart(() =>
                        {
                            if (startEventWhen == EventWhen.Reverse || startEventWhen == EventWhen.Both)
                                onStart?.Invoke();
                            Animating = true;
                        })
                        .OnComplete(() =>
                        {
                            if (finishedEventWhen == EventWhen.Reverse || finishedEventWhen == EventWhen.Both)
                                onFinished?.Invoke();
                            Animating = false;
                            if (disableAfterReverse) mainTarget.gameObject.SetActive(false);
                        });
                    break;
                case Style.Loop:
                    MainTween = mainTarget.DOScale(t, duration)
                        .SetDelay(delayWhen == DelayWhen.Both || delayWhen == DelayWhen.Reverse ? delay : 0)
                        .SetLoops(-1, loopStyle)
                        .SetEase(sameStyleInReverse ? easeForward : easeReverse)
                        .OnStart(() =>
                        {
                            if (startEventWhen == EventWhen.Reverse || startEventWhen == EventWhen.Both)
                                onStart?.Invoke();
                            Animating = true;
                        });
                    break;
                case Style.LoopWithCount:
                    MainTween = mainTarget.DOScale(t, duration)
                        .SetDelay(delayWhen == DelayWhen.Both || delayWhen == DelayWhen.Reverse ? delay : 0)
                        .SetLoops(loopCount * 2, loopStyle)
                        .SetEase(sameStyleInReverse ? easeForward : easeReverse)
                        .OnStart(() =>
                        {
                            if (startEventWhen == EventWhen.Reverse || startEventWhen == EventWhen.Both)
                                onStart?.Invoke();
                            Animating = true;
                        })
                        .OnComplete(() =>
                        {
                            if (finishedEventWhen == EventWhen.Reverse || finishedEventWhen == EventWhen.Both)
                                onFinished?.Invoke();
                            Animating = false;
                            if (disableAfterReverse) mainTarget.gameObject.SetActive(false);
                        });
                    break;
            }
        }

        #endregion

        #region Implement tween functions

        public override void PlayForward()
        {
            if (!isActive) return;
            SetTweenForward(@from, to);
        }

        public override void PlayReverse()
        {
            if (!isActive) return;
            SetTweenReverse(to, @from);
        }

        public override void Play(bool forward = true)
        {
            if (forward)
                PlayForward();
            else
                PlayReverse();
        }

        public override void Stop(bool complete = false)
        {
            MainTween.Kill(complete);
        }

        [ContextMenu("Set current value to 'From'")]
        public override void SetCurrentValueToStart()
        {
            var target = GetComponent<RectTransform>();
            @from = target.localScale;
        }

        [ContextMenu("Set current value to 'To'")]
        public override void SetCurrentValueToEnd()
        {
            var target = GetComponent<RectTransform>();
            to = target.localScale;
        }

        [ContextMenu("Set 'From' to current value")]
        public override void SetStartToCurrentValue()
        {
            var target = GetComponent<RectTransform>();
            target.localScale = @from;
        }

        [ContextMenu("Set 'To' to current value")]
        public override void SetEndToCurrentValue()
        {
            var target = GetComponent<RectTransform>();
            target.localScale = to;
        }

        #endregion
    }
}