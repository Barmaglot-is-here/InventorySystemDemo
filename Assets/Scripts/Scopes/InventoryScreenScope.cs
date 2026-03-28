using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scopes
{
    public class InventoryScreenScope : LifetimeScope
    {
        [SerializeField]
        private Transform _dragZone;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dragZone);
        }
    }
}
