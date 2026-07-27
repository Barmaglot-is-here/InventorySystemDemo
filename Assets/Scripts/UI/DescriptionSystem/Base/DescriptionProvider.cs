using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.DescriptionSystem
{
    public abstract class DescriptionProvider<TView, TData> : MonoBehaviour, 
        IPointerEnterHandler, IPointerExitHandler
        where TView : DescriptionView<TData> 
        where TData : DescriptionData
    {
        [SerializeField]
        private float _showDelaySeconds = 0.3f;

        private WaitForSeconds _waitForSeconds;
        private Coroutine _showCoroutine;

        private TView _view;

        protected virtual bool CanShow => true;

        protected virtual void Awake()
        {
            _view               = FindAnyObjectByType<TView>(FindObjectsInactive.Include);
            _waitForSeconds     = new(_showDelaySeconds);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            _showCoroutine = StartCoroutine(ShowTask(eventData));
        }

        private IEnumerator ShowTask(PointerEventData eventData)
        {
            yield return _waitForSeconds;

            if (!CanShow)
                yield break;

            var data = GetViewData();

            _view.Show(data, eventData.position);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            CancelShowTask();

            _view.Hide();
        }

        protected void CancelShowTask() => StopCoroutine(_showCoroutine);

        protected abstract TData GetViewData();
    }
}
