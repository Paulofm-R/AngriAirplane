using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour{

    public static GameControler instance;
    public GameObject GameOverTexto;
    public GameObject ComecarTexto;
    public GameObject Pontuacao;
    public Text PontuacaoTexto;
    public Text PontuacaoFinal;
    public bool gameOver = false;
    public bool inicio = true;
    public int pontuacao = 0;
    public int nivel = 0;
    
    // Start is called before the first frame update
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update(){
        if (gameOver && Input.GetKeyDown(KeyCode.Space)){
            // depois do jogar ter perdido
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (inicio && Input.GetKeyDown(KeyCode.Space)){
            // antes do jogo começar
            ComecarTexto.SetActive(false);
            inicio = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)){  //sair da aplicação com a tecla ESC
            Application.Quit();
        }
    }

    // Quando o jogador perder
    public void Morte(){
        PontuacaoFinal.text = PontuacaoTexto.text;
        GameOverTexto.SetActive(true);
        Pontuacao.SetActive(false);
        gameOver = true;
    }

    public void MarcarPonto(){
        if(gameOver){
            return;
        }
        pontuacao++;
        PontuacaoTexto.text = "Score: " + pontuacao.ToString();

        // A cada 5 pontos, aumentar o nivel da dificuldade 
        if(pontuacao > 0 && pontuacao % 5 == 0){
            nivel++;
        }
    }
}
