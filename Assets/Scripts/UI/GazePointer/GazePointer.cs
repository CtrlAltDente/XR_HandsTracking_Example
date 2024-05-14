using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace XRHandsExample.UI.Gaze
{
    public class GazePointer : MonoBehaviour
    {
        [SerializeField]
        private Image _pointerImage;

        [SerializeField]
        private Color _idleColor;
        [SerializeField]
        private Color _hoverColor;
        [SerializeField]
        private Color _selectColor;

        private const float DURATION_TIME = 1.5f;

        private Tween _colorTween;
        private Tween _scaleTween;

        public void Idle()
        {
            StopTweens();

            _colorTween = _pointerImage.DOColor(_idleColor, DURATION_TIME / 3f);
            _scaleTween = _pointerImage.rectTransform.DOScale(1f, DURATION_TIME / 3f);
        }

        public void Hover()
        {
            _pointerImage.DOColor(_hoverColor, DURATION_TIME);
        }

        public void Select()
        {
            StopTweens();

            _colorTween = _pointerImage.DOColor(_hoverColor, DURATION_TIME).OnComplete(() => _pointerImage.DOColor(_selectColor, DURATION_TIME / 3f).OnComplete(() => _pointerImage.DOColor(_idleColor, DURATION_TIME / 3f)));
            _scaleTween = _pointerImage.rectTransform.DOScale(2f, DURATION_TIME).OnComplete(() => _pointerImage.rectTransform.DOScale(2.5f, DURATION_TIME / 3f).OnComplete(() => _pointerImage.rectTransform.DOScale(1f, DURATION_TIME / 3f)));
        }

        private void StopTweens()
        {
            _colorTween.Kill();
            _scaleTween.Kill();
        }
    }
}