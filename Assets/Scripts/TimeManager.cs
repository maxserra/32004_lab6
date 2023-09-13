using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private int lastTime = 0;

    private void Start()
    {
        Debug.Log(lastTime);
    }

    private void Update()
    {
        if ((Time.time - lastTime) >= 1)
        {
            lastTime = (int)Time.time;
            Debug.Log(lastTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");
            if (Time.timeScale != 0)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }

}
