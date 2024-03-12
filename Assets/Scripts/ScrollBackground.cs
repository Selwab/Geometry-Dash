using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    
    public Transform background;
    public float scrollingSpeed = 10f;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        background.GetComponent<Transform>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = background.position;
        Debug.Log("Posición de la imagen: " + position);
        transform.Translate(Vector3.left * scrollingSpeed * Time.deltaTime);

        if(transform.position.x < -20.55f / 2)
        {
            transform.position = startPosition;
        }

    }

    //public Transform firstBackground;
    //public Transform secondBackground;
    //public float scrollingSpeed = 10f;
    //private Vector3 startPosition;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    firstBackground.GetComponent<Transform>();
    //    secondBackground.GetComponent<Transform>();
    //    startPosition = firstBackground.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    firstBackground.Translate(Vector3.left * scrollingSpeed * Time.deltaTime);
    //    secondBackground.Translate(Vector3.left * scrollingSpeed * Time.deltaTime);

    //    if (firstBackground.position.x <= -20.55f / 2)
    //    {
    //        // Coloca el primer fondo justo al lado del segundo fondo
    //        firstBackground.position = new Vector3(secondBackground.position.x + 20.55f, startPosition.y, startPosition.z);
    //    }
    //    else if (secondBackground.position.x <= -20.55f )
    //    {
    //        // Coloca el segundo fondo justo al lado del primer fondo
    //        secondBackground.position = new Vector3(firstBackground.position.x + 20.55f, startPosition.y, startPosition.z);
    //    }
    //}
}
