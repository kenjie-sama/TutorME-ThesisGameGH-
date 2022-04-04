using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MainMenu());  
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneChange.MoveToScene(1);
    }
}
