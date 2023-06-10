using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos_botao : MonoBehaviour
{
    public UnityEvent entrouNoColisor;
    public UnityEvent saiuDoColisor;

    public Mudar_Cor[] objetos;

    private void OnTriggerEnter(Collider other)
    {
        entrouNoColisor.Invoke(); 
        foreach (Mudar_Cor objeto in objetos)
        {
            objeto.MudarCor();
        }  
    }

    private void OnTriggerExit(Collider other) 
    {
        saiuDoColisor.Invoke();foreach (Mudar_Cor objeto in objetos)
        {
            objeto.VoltarPadrao();
        } 
        
    }
}
