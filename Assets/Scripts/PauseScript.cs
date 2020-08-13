using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }

    public void HandleQuiButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
