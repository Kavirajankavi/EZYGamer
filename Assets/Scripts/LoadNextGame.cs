using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextGame : MonoBehaviour
{
    private float delay = 1f;
    public void EnablingLevel()
    {
        Invoke("NextLevel",delay);
    }

    public void DisablingLevel()
    {
        Invoke("CurrentLevel", delay);
    }

    void NextLevel()
    {
        
        gameObject.SetActive(true);
    }

    void CurrentLevel()
    {
        
        gameObject.SetActive(false);
    }
    

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
