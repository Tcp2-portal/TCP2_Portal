using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudar_Cor : MonoBehaviour
{
    public Color[] cor;

    public void MudarCor()
    {
        Color c = cor[0];
        GetComponent<Renderer>().material.color = c;
    }

    public void VoltarPadrao()
    {
        Color c = cor[1];
        GetComponent<Renderer>().material.color = c;
    }
}
