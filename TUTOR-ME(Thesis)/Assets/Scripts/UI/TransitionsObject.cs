using System.Collections;
using System;
using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace MotionGraphics
{
    [DisallowMultipleComponent]
    [Serializable]
    public class TransitionsObject
    {
        [Header("Need Reference")] [SerializeField]
        private RectTransform shapeParent, translateEndPos, scaleEndSizeDelta;

        [Space, Header("No Need Reference"), SerializeField]
        private Ease inEase = Ease.OutCubic;

        [SerializeField, Range(0, 5)] private float duration = 0.3f, delay = 0f, delayPlus = 0.15f;
        [SerializeField] private RectTransform[] shapeChildren;
        [SerializeField] private Vector2 orig_rectSize;

        /// <summary>
        /// Initialize first the values of Transition Object before Calling or Executing
        /// </summary>
        public void InitializeValues()
        {
            try
            {
                int count = shapeParent.childCount;
                shapeChildren = new RectTransform[count];

                for (int z = 0; z < count; z++)
                    shapeChildren[z] = shapeParent.GetChild(z) as RectTransform;

                if (scaleEndSizeDelta != null)
                    orig_rectSize = shapeChildren[0].sizeDelta;
            }
            catch (Exception e) { Debug.Log(e.StackTrace); }
        }
        
        public void ShowTransitionInfo()
        {
            string shapes = "Shapes: ";
            Debug.LogWarning($"Warning! Print Info Starts");
            Debug.Log($"Parent Name: {(shapeParent == null ? "null" : shapeParent.name)} | " +
                      $"End Pos: {(translateEndPos == null ? "null" :  translateEndPos.name)} | " +
                      $"End Size Delta: {(scaleEndSizeDelta == null ? "null" : scaleEndSizeDelta.name)}");
            Debug.Log($"Ease: {inEase.ToString()} | Duration: {duration} | Delay: {delay} | Delay Plus: {delayPlus}");
            foreach (RectTransform shape in shapeChildren)
                shapes += shape.name + ", ";
            Debug.Log(shapes);
            Debug.Log($"Orig Delta Rec Size: {orig_rectSize}");
            Debug.LogWarning($"Warning! Print Info Ends");
        }
        
        # region Translate

        /// <summary>
        /// Translate Or Move Contents / Objects of the parent
        /// Reverse the List to create a rewind animation
        /// </summary>
        /// <param name="isReverse"> True to reverse and False to use the original List</param>
        /// <param name="isReset"> True to reset the animation and False to use the original List</param>

        public IEnumerator TranslateX(bool isReverse = false, bool isReset = false, Action callBack = null)
        {
            RectTransform[] children = isReverse ? shapeChildren.Reverse().ToArray() : shapeChildren;
            foreach (var child in children)
            {
                child.DOMoveX(isReset ? shapeParent.position.x : translateEndPos.position.x, duration)
                    .SetDelay(delay).SetEase(inEase);
                delay += delayPlus;
            }

            delay += delayPlus;
            yield return new WaitForSeconds(delay);
            delay = 0f;
            callBack?.Invoke();
        }

        public IEnumerator TranslateY(bool isReverse = false, bool isReset = false, Action callBack = null)
        {
            RectTransform[] children = isReverse ? shapeChildren.Reverse().ToArray() : shapeChildren;
            foreach (var child in children)
            {
                child.DOMoveX(isReset ? shapeParent.position.x : translateEndPos.position.x, duration).SetDelay(delay)
                    .SetEase(inEase);
                delay += delayPlus;
            }

            delay += delayPlus;
            yield return new WaitForSeconds(delay);
            delay = 0f;
            callBack?.Invoke();
        }

        public IEnumerator Translate2D(bool isReverse = false, bool isReset = false, Action callBack = null)
        {
            RectTransform[] children = isReverse ? shapeChildren.Reverse().ToArray() : shapeChildren;
            foreach (var child in children)
            {
                child.DOMove(isReset ? shapeParent.position : translateEndPos.position, duration).SetDelay(delay)
                    .SetEase(inEase);
                delay += delayPlus;
            }

            delay += delayPlus;
            yield return new WaitForSeconds(delay);
            delay = 0f;
            callBack?.Invoke();
        }

        #endregion

        #region Resize

        /// <summary>
        /// Swipe Contents / Objects of the parent
        /// Reverse the List to create a rewind animation
        /// </summary>
        /// <param name="isReverse"> True to reverse and False to use the original List</param>
        /// <param name="isReset"> True to reset the animation reverse and False to use the original List</param>

        public IEnumerator Swipe2D(bool isReverse = false, bool isReset = false, Action callBack = null)
        {
            RectTransform[] children = isReverse ? shapeChildren.Reverse().ToArray() : shapeChildren;
            foreach (var child in children)
            {
                child.DOSizeDelta(isReset ? orig_rectSize : scaleEndSizeDelta.rect.size, duration).SetDelay(delay)
                    .SetEase(inEase);
                delay += delayPlus;
            }

            delay += delayPlus;
            yield return new WaitForSeconds(delay);
            delay = 0f;
            callBack?.Invoke();
        }

        public IEnumerator ScaleSizeDelta2D(bool isReverse = false, bool isReset = false, Action callBack = null)
        {
            RectTransform[] children = isReverse ? shapeChildren.Reverse().ToArray() : shapeChildren;
            foreach (var child in children)
            {
                child.DOSizeDelta(isReset ? orig_rectSize : scaleEndSizeDelta.rect.size, duration).SetDelay(delay)
                    .SetEase(inEase);
                // child.DOMove(isReset ? shapeParent.position : scaleEndSizeDelta.position, duration).SetDelay(delay)
                //     .SetEase(inEase);
                delay += delayPlus;
            }

            delay += delayPlus;
            yield return new WaitForSeconds(delay);
            delay = 0f;
            callBack?.Invoke();
        }

        #endregion
    }
}
