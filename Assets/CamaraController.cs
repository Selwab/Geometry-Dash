using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= 0)
        {
            //Debug.Log("Posicion Personaje: " + player.position.x);
            //Debug.Log("Posicion Camara: " + transform.position.x);
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }

    }
}
