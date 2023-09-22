using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInicio : MonoBehaviour
{
    public GameObject personaje;
    public GameObject panelInicio;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        personaje.gameObject.GetComponent<Personaje>().enabled = false;
    }

    // Update is called once per frame
    public void btnPlay()
    {
        personaje.gameObject.GetComponent<Personaje>().enabled = true;
        panelInicio.SetActive(false);
    }
}
