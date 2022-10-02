using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour{
    
    public float speed = .2f;

    private Renderer r;

    void Start(){
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update(){
        if (!GameControler.instance.gameOver){
            Vector2 offset = new Vector2(Time.time * speed, 0);
            r.material.mainTextureOffset = offset;
        }
    }
}