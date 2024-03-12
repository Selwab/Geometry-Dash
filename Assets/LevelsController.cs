using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    // Start is called before the first frame update
    
    void gotToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    void gotToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
