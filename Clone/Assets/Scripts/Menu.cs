using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cenaComecar;
    public string cenaRecomecar;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCreditos;

    public void ComecarJogo()
    {
        SceneManager.LoadScene(cenaComecar);
    }

    public void AbrirOpcoes() 
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void Creditos()
    {   
        painelMenuInicial.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void Fecharcreditos()
    {   
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
    }

    public void SairJogo()
    {
        //editor unity
        //UnityEditor.EditorApplication.isPlaying = false; 

        //jogo compilado
        Application.Quit();

        Debug.Log("FechouJogo");
    }
    public void Recomecar()
    {
        SceneManager.LoadScene(cenaRecomecar);
    }
}
