using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotina : MonoBehaviour
{
    public string cena;
    public float tempo;
    // Start is called before the first frame update
    void Start(){

    }

        

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;

        if(tempo <= 0.0f){
            SceneManager.LoadScene(cena);
        }
    
    }

    
}
