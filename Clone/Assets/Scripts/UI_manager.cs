using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    public GameObject canvas, cubo, player; 

    public float distObj; // vai receber a distância entre os objetos.
    public float minDist; // será a distância mínima entre os objetos para executar uma ação.
    


    void Start()
    {
        
    }

    void Update()
    {
        AtivarCanvas();
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SairJogo();
        }

    }

    void AtivarCanvas()
    {
        distObj = Vector3.Distance(player.transform.position, cubo.transform.position);
        
        if(distObj <= minDist)
        {
            canvas.gameObject.SetActive(true);
        }
        if(distObj <= 1.2f || distObj > minDist)
        {
            canvas.gameObject.SetActive(false);            
        } 
    }

    public void SairJogo()
    {
        //editor unity
        //UnityEditor.EditorApplication.isPlaying = false; 

        //jogo compilado
        Application.Quit();

        Debug.Log("FechouJogo");
    }
}   
