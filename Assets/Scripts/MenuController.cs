using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelSelector;

    public void goToGame()
    {  
        levelSelector.SetActive(true);
    }

   public void goToSelectCharacter()
   {
        SceneManager.LoadScene("CharacterSelection");
   }

    public void gotToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void gotToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
