using UnityEngine;

namespace Utils
{
    public static class RectTransformExtensions
    {
        public static Vector2 FitInScreen(this RectTransform self, Vector2 target)
        {
            var minX = self.sizeDelta.x / 2;
            var minY = self.sizeDelta.y / 2;
            
            var maxX = Screen.width - minX;
            var maxY = Screen.height - minY;

            if (target.x < minX)
            {
                target.x = minX;
            }
            else if (target.x > maxX)
            {
                target.x = maxX;
            }

            if (target.y < minY)
            {
                target.y = minY;
            }
            else if (target.y > maxY)
            {
                target.y = maxY;
            }

            return target;
        }
    }
}