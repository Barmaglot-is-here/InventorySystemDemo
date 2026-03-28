using Game.InventorySystem;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.UI
{
    public class SlotsViewFactory : MonoBehaviour
    {
        [SerializeField]
        private SlotView _slotPrefab;

        private IObjectResolver _resolver;

        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public List<SlotView> Create(Transform container, Inventory inventory)
        {
            List<SlotView> views = new(inventory.Size);

            for (int i = 0; i < inventory.Size; i++)
            {
                var view = _resolver.Instantiate(_slotPrefab, container);

                view.name += " " + i;

                var slot = inventory[i];

                view.Bind(slot);
                views.Add(view);
            }

            return views;
        }
    }
}
