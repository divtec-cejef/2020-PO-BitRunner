using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneNameToLoad;

    // Effectue le changement de scène
    public void changeScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
