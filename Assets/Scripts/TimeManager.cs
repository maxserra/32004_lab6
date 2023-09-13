using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private int lastTime = 0;
    private float timer;

    [SerializeField] private Transform[] transformArray;

    private const float moveWait = 2.0f;

    private void Start()
    {
        // Reset time
        ResetTime();

        // Change camere perspective
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 2.5f;
    }

    private void Update()
    {
        // Timer things
        if (Time.timeScale != 0 &
            ((timer == 0) |
             (timer - lastTime >= 1)))
        {
            Debug.Log((int)timer);
            lastTime = (int)timer;
        }
        timer += Time.deltaTime;

        // Spacebar stopper
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");
            if (Time.timeScale != 0)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        // Enter resetter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }
    }

    private void MoveObjects()
    {

    }

    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;
    }

}
