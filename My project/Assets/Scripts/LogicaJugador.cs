using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour {
    public Vida vida;
    public bool Vida0 = false;
    [SerializeField] private Animator animadorPerder;
    public Puntaje puntaje;

	// Use this for initialization
	void Start () {
        vida = GetComponent<Vida>();
        puntaje.valor = 0;
	}
	
	// Update is called once per frame
	void Update () {
        RevisarVida();
	}

    void RevisarVida()
    {
        if (Vida0) return;
        if(vida.valor <= 0)
        {
            AudioListener.volume = 0f;
            animadorPerder.SetTrigger("Mostrar");
            Vida0 = true;
            Invoke("ReiniciarJuego", 2f);
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        puntaje.valor = 0;
        AudioListener.volume = 1f;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemigo")
        {
            gameObject.GetComponent<AudioSource>().volume= 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemigo")
        {
            gameObject.GetComponent<AudioSource>().volume= 1f;
        }
    }
}
