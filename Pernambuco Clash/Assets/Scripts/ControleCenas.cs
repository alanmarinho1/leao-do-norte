using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleCenas : MonoBehaviour
{
    public static ControleCenas instance;
    public GameObject opcoes;
    public bool paused = false;

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

    public void PauseAndResumeGame()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            opcoes.SetActive(false);
        }
        else
        {
            opcoes.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NovoJogoScene()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void MostrarOpcoes()
    {
        opcoes.SetActive(true);
    }

    public void VoltarMenuPrincipal()
    {
        opcoes.SetActive(false);
    }

    public void GameOverScene()
    {
        Application.LoadLevel("Tela Game Over");
    }
}
