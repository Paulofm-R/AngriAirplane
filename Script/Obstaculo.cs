using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour{

    private Rigidbody2D rb2d;
    public AudioClip pontoSom;
    
    void Start () {
        //Obtenha e armazene uma referência ao Rigidbody2D anexado a este GameObject.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update(){
        //Começar o movimento do objeto
        rb2d.velocity = new Vector2 (-2.85f - (0.50f * GameControler.instance.nivel), 0);
    }
    
    private void OnTriggerEnter2D (Collider2D other){
        if (other.GetComponent<AviaoScript>() != null){
            GameControler.instance.MarcarPonto(); //marcar ponto ao passar pelo obstaculo
            AudioSource.PlayClipAtPoint(pontoSom, this.transform.position, 0.5f); //emitir um som ao passar pelo o obstaculo
        }
    }
}
