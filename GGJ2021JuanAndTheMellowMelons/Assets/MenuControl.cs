using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonLoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        if (sceneIndex == 1)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    public void ButtonExit()
    {
        Application.Quit();
    }
}
