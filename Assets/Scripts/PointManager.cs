using System.Collections;
using System.Collections.Generic;
using DaMastaCoda.PuzzleGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    public int points = 0;
    public int maxPoints = 0;

    public void AddPoint()
    {
        points++;
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        maxPoints += FindObjectsOfType(typeof(AddPoint)).Length;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        maxPoints += FindObjectsOfType(typeof(AddPoint)).Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
