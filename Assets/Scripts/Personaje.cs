using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    //Esta variable se utiliza para almacenar una referencia al GameObject llamado "Personaje"
    public GameObject personaje;
    //Esta variable se utilizará para almacenar una referencia al componente Rigidbody2D del GameObject "Personaje".
    public Rigidbody2D cuerpoPersonaje;
    float velocidad = 5f;
    //Esta variable es creada por realizar la transición del personaje con la animación de movimiento
    public Animator animadorPersonaje;

    bool tocandoSuelo = false;

    public GameObject panelGameOver;

     public GameObject panelVictoria;

    // Start is called before the first frame update
    void Start()
    {
        //En esta línea, se busca un GameObject en la escena con el nombre "Personaje" utilizando la función GameObject.Find(). Si se encuentra un GameObject con ese nombre, su referencia se asigna a la variable "personaje".
        personaje = GameObject.Find("Personaje");
        //Este componente se asigna a la variable "cuerpoPersonaje", lo que permite acceder y manipular las propiedades y funciones del Rigidbody2D del personaje en el código posterior.
        cuerpoPersonaje = personaje.GetComponent<Rigidbody2D>();
        //Este componente se asigna a la variable  "animadorPersonaje" para igualar al componente Animator de el personaje
        animadorPersonaje = personaje.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animadorPersonaje.SetBool("Corriendo", false);
        //Evaluar si se presiona la tecla A para mover el personaje a la izquierda
        if(Input.GetKey(KeyCode.A) == true){
            cuerpoPersonaje.AddForce(Vector3.left * velocidad);
            //Habilitar la transition de la animación del personaje cuando corre
            animadorPersonaje.SetBool("Corriendo", true);
            //Cambias la dirección del personaje modificando la escala en el eje X para que gire cuando presione la tecla A
            personaje.transform.localScale = new Vector3(-1, 1, 1);
        }

        //Evaluar si se presiona la tecla D para mover el personaje a la derecha
        if(Input.GetKey(KeyCode.D) == true){
            cuerpoPersonaje.AddForce(Vector3.right * velocidad);
            //Habilitar la transition de la animación del personaje cuando corre
            animadorPersonaje.SetBool("Corriendo", true);
            //Cambias la dirección del personaje modificando la escala en el eje X para que gire cuando presione la tecla D
            personaje.transform.localScale = new Vector3(1, 1, 1);
        }

        if(tocandoSuelo == true){
            //Evaluar si se presiona la tecla W para que el personaje salte
            if(Input.GetKey(KeyCode.W) == true){
                cuerpoPersonaje.AddForce(Vector3.up * 900);
                tocandoSuelo = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colision){
        if(colision.gameObject.tag == "Suelo"){
            tocandoSuelo = true;
        }

        if(colision.gameObject.tag == "Enemigo"){
            panelGameOver.SetActive(true);
            gameObject.GetComponent<Personaje>().enabled = false;
        }

        if(colision.gameObject.tag == "Meta"){
            panelVictoria.SetActive(true);
            gameObject.GetComponent<Personaje>().enabled = false;

        }
    }
}
