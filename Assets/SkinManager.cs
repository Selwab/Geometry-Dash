using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> characters = new List<Sprite>();
    private int selectedCharacter = 0;
    public GameObject player;

    public void NextCharacter()
    {
        selectedCharacter++;
        if(selectedCharacter == characters.Count)
        {
            selectedCharacter = 0;
        }
        sr.sprite = characters[selectedCharacter];
    }

    public void PreviousCharacter()
    {
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Count - 1;
        }
        sr.sprite = characters[selectedCharacter];
    }

    public void BackToMenu()
    {
        PrefabUtility.SaveAsPrefabAsset(player, "Assets/Players/SelectedSkin.prefab");
        SceneManager.LoadScene("MainMenu");
    }
}
