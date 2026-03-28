using TMPro;
using UnityEngine;

namespace Game.UI.DescriptionSystem
{
    public abstract class DescriptionView<T> : MonoBehaviour where T : DescriptionData
    {
        [SerializeField]
        private TMP_Text _name;
        [SerializeField]
        private TMP_Text _description;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public virtual void Show(T description, Vector2 position)
        {
            gameObject.SetActive(true);

            SetPosition(position);
            ShowText(description.Name, description.Description);
        }

        private void SetPosition(Vector2 position)
        {
            position = DescriptionViewPositionCalculator.Calculate(_rectTransform, position);

            _rectTransform.position = position;
        }

        private void ShowText(string name, string description)
        {
            _name.text          = name;
            _description.text   = description;
        }

        public void Hide() => gameObject.SetActive(false);
    }
}
