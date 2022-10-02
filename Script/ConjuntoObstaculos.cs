using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjuntoObstaculos : MonoBehaviour{

    public int ConjuntObstTamanho = 15;
    public GameObject ObstaculosPatoPrefab;
    public GameObject ObstaculosGaivotaPrefab;
    public float spawnRate = 4f;
    public float obstaculoMin = -3.75f;
    public float obstaculoMax = 5.25f;
    
    private GameObject[] Obstaculos;
    private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
    private float temporizadorSpawn;
    private float spawnXPosition = 10f;
    private int atualObstaculo = 0;
    
    void Start(){
        Obstaculos = new GameObject[ConjuntObstTamanho];
        for (int i = 0; i < ConjuntObstTamanho; i++){
            if((i+1) % 5 == 0){
                // Colocar a gaivota
                Obstaculos[i] = (GameObject) Instantiate(ObstaculosGaivotaPrefab, objectPoolPosition, Quaternion.identity);
            }
            else{
                // Colocar o pato
                Obstaculos[i] = (GameObject) Instantiate(ObstaculosPatoPrefab, objectPoolPosition, Quaternion.identity);  
            }
        }
    }

    // Update is called once per frame
    void Update(){
        if(!GameControler.instance.inicio){
            temporizadorSpawn += Time.deltaTime;

            if(!GameControler.instance.gameOver && temporizadorSpawn >= (spawnRate - (0.15f * GameControler.instance.nivel))){
                temporizadorSpawn = 0;
                float spawnYPosition = Random.Range(obstaculoMin, obstaculoMax);  //local de aparecer nas coordenadas de y
                
                Obstaculos[atualObstaculo].transform.position = new Vector2 (spawnXPosition, spawnYPosition); //local de aparecimento do obstaculo
                atualObstaculo++;

                if(atualObstaculo >= ConjuntObstTamanho){ //quando passarem todos os obstaculos, voltar a inicio
                    atualObstaculo = 0;                    
                }
            }
        }
    }
}
