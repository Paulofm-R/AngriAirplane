using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoScript : MonoBehaviour{

    // public GameControler GameControler;
    public Rigidbody2D Aviao;
    public float salto = 3.5f; //altura do salto

    private bool vivo = true;

    void Start(){
        Aviao = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update(){
        if(!GameControler.instance.inicio){
            if(vivo && Input.GetKeyDown(KeyCode.Space)){
                // Salto
                Aviao.velocity = new Vector2(0, salto);
            }
        }
        else{
            Aviao.velocity = new Vector2(0, 0.18f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        GetComponent<Collider2D>().enabled = false;
        vivo = false;
        GameControler.instance.Morte();
    }
}