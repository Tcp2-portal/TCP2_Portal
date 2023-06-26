using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadScene : MonoBehaviour
{
    public string cenaACarregar;
    public float TempoFixoSeg =5;
    public enum TipoCarregar {Carregamento, TempoFixo};
    public TipoCarregar TipoDeCarregamento;
    public Image barradeCarregamento;
    public TextMeshProUGUI TextoProgresso;
    private int progresso = 0;
    private string textoOriginal;

    void Start()
    {
        switch (TipoDeCarregamento)
        {
            case TipoCarregar.Carregamento:
                StartCoroutine(CenaDeCarregamento(cenaACarregar));
                break;

            case TipoCarregar.TempoFixo:
                StartCoroutine(TempoFixo(cenaACarregar));
                break;
        }
        //
        if(TextoProgresso != null){
            textoOriginal = TextoProgresso.text;   
        }
        if(barradeCarregamento != null){
        barradeCarregamento.type = Image.Type.Filled;
        barradeCarregamento.fillMethod = Image.FillMethod.Horizontal;
        barradeCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
        
    }

    IEnumerator CenaDeCarregamento(string cena)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        while (!carregamento.isDone)
        {
            progresso = (int)(carregamento.progress * 100.0f);
            yield return null;
        }
    }

    IEnumerator TempoFixo(string cena){
        yield return new WaitForSeconds(TempoFixoSeg);
        SceneManager.LoadScene(cena);
    }


    void Update()
    {
        switch (TipoDeCarregamento)
        {
            case TipoCarregar.Carregamento:
                break;
            case TipoCarregar.TempoFixo:
                progresso = (int)(Mathf.Clamp((Time.time/TempoFixoSeg),0.0f,1.0f) *100.0f);
                break;
        }
        if(TextoProgresso != null){
            TextoProgresso.text = textoOriginal + " " + progresso + "%";
        }
        if(barradeCarregamento != null){
            barradeCarregamento.fillAmount = (progresso/100.0f);
        }
    }
}
