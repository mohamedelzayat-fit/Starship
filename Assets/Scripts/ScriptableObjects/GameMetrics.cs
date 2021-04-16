using UnityEngine;

namespace Starship.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Starship/Game Metrics", fileName = "GameMetrics", order = 0)]
    public class GameMetrics : ScriptableObject
    {
        public float LimitRight => limitRight;
        public float LimitLeft => limitLeft;
        public float LimitUp => limitUp;
        public float LimitDown => limitDown;
        
        private float limitRight;
        private float limitLeft;
        private float limitUp;
        private float limitDown;

        private void OnEnable()
        {
            if (Camera.main != null)
            {
                var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
                limitRight = planes[0].distance;
                limitLeft = -planes[1].distance;
                limitUp = planes[2].distance;
                limitDown = -planes[3].distance;
            }
        }
    }
}
