using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GotoFirstScene()
    {
        SceneManager.LoadScene("InitialScene");
    }
    public void GotoMapScene()
    {
        SceneManager.LoadScene("MapView");
    }

    public void GotoCameraScene()
    {
        SceneManager.LoadScene("CameraView");
    }
}

