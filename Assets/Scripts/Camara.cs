using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject personaje;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        background = GameObject.Find("BrickBackground");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(personaje.transform.position.x, 0, -10);
        background.transform.position = new Vector3(personaje.transform.position.x, 0, 0);
    }
}