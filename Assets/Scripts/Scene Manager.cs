using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(string aScreenName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(aScreenName);
    }
}  


