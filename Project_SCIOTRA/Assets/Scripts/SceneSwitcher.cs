using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
   
    public void GotoFirstScene()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void GotoCameraScene()
    {
        SceneManager.LoadScene("CameraScene");
    }
}
