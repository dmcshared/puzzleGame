namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;

    public class PointsFinished : Provider
    {
        PointManager pointManager;

        private void Start()
        {
            pointManager = Universal.Instance.GetComponent<PointManager>();
        }

        public override bool isProviding()
        {
            return pointManager.points == pointManager.maxPoints;
        }


    }
}