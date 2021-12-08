using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        Application.targetFrameRate = 60;
    }

    private void Exit()
    {
        Application.Quit();
    }
}

