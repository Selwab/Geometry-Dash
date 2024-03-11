using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedCharacter;
    public GameObject player;

    private Sprite playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = selectedCharacter.GetComponent<SpriteRenderer>().sprite;
        player.GetComponent<SpriteRenderer>().sprite = playerSprite;
    }

}
