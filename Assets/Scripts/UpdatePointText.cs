using UnityEngine;
using DaMastaCoda.PuzzleGame;

public class UpdatePointText : MonoBehaviour
{
    public TMPro.TMP_Text textItem;

    PointManager pointManager;

    private void Start()
    {
        pointManager = Universal.Instance.GetComponent<PointManager>();
    }

    private void Update()
    {
        textItem.text = "Score: " + pointManager.points + " / " + pointManager.maxPoints;
    }
}