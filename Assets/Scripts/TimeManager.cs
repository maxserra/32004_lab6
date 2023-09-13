using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private int lastTime = 0;
    private float timer;

    [SerializeField] private Transform[] transformArray;

    private const float moveWait = 2.0f;

    private float max_x;
    private float min_x;
    private float max_y;
    private float min_y;

    private Vector3 topRight;
    private Vector3 botRight;
    private Vector3 botLeft;
    private Vector3 topLeft;

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

            // Move objects
            if ((int)timer % moveWait == 0)
            {
                Debug.Log("Moving objects...");
                MoveObjects();
            }
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
        max_x = Mathf.Max(transformArray[0].position.x,
                              transformArray[1].position.x);
        min_x = Mathf.Min(transformArray[0].position.x,
                          transformArray[1].position.x);
        max_y = Mathf.Max(transformArray[0].position.y,
                          transformArray[1].position.y);
        min_y = Mathf.Min(transformArray[0].position.y,
                          transformArray[1].position.y);

        topRight = new Vector3(max_x, max_y, 0);
        botRight = new Vector3(max_x, min_y, 0);
        botLeft = new Vector3(min_x, min_y, 0);
        topLeft = new Vector3(min_x, max_y, 0);

        MoveOneObjectClockwise(transformArray[0]);
        MoveOneObjectClockwise(transformArray[1]);
    }

    private void MoveOneObjectClockwise(Transform objTransform)
    {
        if (objTransform.position == topRight)
            objTransform.position = botRight;
        else if (objTransform.position == botRight)
            objTransform.position = botLeft;
        else if (objTransform.position == botLeft)
            objTransform.position = topLeft;
        else if (objTransform.position == topLeft)
            objTransform.position = topRight;
    }

    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;
    }

}
