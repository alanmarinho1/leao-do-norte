using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleCenas : MonoBehaviour
{
    public static ControleCenas instance;
    public GameObject opcoes;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NovoJogoScene()
    {
        SceneManager.LoadScene ("Fase1");
    }

    public void SairDoJogo(){
        Application.Quit();
    }

    public void MostrarOpcoes(){
        opcoes.SetActive(true);
    }

    public void VoltarMenuPrincipal(){
        opcoes.SetActive(false);
    }

    public void GameOverScene(){
        Application.LoadLevel("Tela Game Over");
    }
}
