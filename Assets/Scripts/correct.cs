using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correct : MonoBehaviour
{
    private float delay = 1f;
    public void EnableIcon() 
    {
        gameObject.SetActive(true);
    }

    public void DisableIcon() 
    {
        gameObject.SetActive(false);
        
    }

    public void LateDisable() 
    {
        Invoke("WrongIcon", delay);
    }
     void WrongIcon()
    {
        gameObject.SetActive(false);
    }
}
