using UnityEngine;

namespace Game.UI.DescriptionSystem
{
    internal static class DescriptionViewPositionCalculator
    {
        public static Vector2 Calculate(RectTransform viewTransform, Vector2 mousePosition)
        {
            var offcetX = viewTransform.sizeDelta.x / 2;
            var offcetY = viewTransform.sizeDelta.y / 2;

            return mousePosition - new Vector2(-offcetX, offcetY);
        }
    }
}
