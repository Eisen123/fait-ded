using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vida : MonoBehaviour {
    public float valor = 100;
	public Vida padreRef;
	public float multiplicadorDeDa�o = 1.0f;
	public GameObject textoFlotantePrefab;
	public float da�oTotal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RecibirDa�o(float da�o)
    {
		da�o *= multiplicadorDeDa�o;
		if (padreRef != null)
		{
			padreRef.RecibirDa�o(da�o);
			return;
		}
        valor -= da�o;
		da�oTotal = da�o;
		if(valor>=0) MostrarTextoFlotante();
        if (valor < 0)
        {
            valor = 0;
			MostrarTextoFlotante();
        }
    }
	void MostrarTextoFlotante()
	{
		var go= Instantiate(textoFlotantePrefab, transform.position, Quaternion.identity, transform);
		go.GetComponent<TextMesh>().text = da�oTotal.ToString();
		//go.GetComponent<TextMesh>().Text = valor.ToString();
	}
}
