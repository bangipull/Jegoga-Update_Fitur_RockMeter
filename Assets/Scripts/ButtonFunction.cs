using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void LoadScene(int a)
    {
        SceneManager.LoadScene(a);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
