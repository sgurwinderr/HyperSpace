using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_Scene : MonoBehaviour
{
    public void Load_Level(string str)
    {
        SceneManager.LoadScene(str, LoadSceneMode.Single);
    }
    public void App_exit()
    {
        Application.Quit();
    }
}
