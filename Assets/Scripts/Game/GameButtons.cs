using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public void ToMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
}
