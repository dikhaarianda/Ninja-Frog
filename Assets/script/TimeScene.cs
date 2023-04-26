using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeScene : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(AfterTime());
    }
    
    IEnumerator AfterTime()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("StartGame");
    }
}
