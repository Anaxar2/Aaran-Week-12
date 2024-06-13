using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startScreen, pauseScreen;
    bool pauseScreenActive;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(!pauseScreenActive);
            if (pauseScreenActive)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            pauseScreenActive = !pauseScreenActive;
        }
    }
    public void StartButton()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
