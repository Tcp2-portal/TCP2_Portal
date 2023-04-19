using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    Vector3 position;
    public float alturaPorta;

    private void Start() 
    {
        // position = new Vector3(2.48f, 1.45f, 24.98f);
        // transform.position = position;
    }

    public void MoverPorta()
    {
        if(position.y < 4)
        {
            position.y += alturaPorta;
            transform.position=position;
            Debug.Log("Subiu");
        }
    }

    public void FecharPorta()
    {
        if(position.y > -3)
        {
            position.y -= alturaPorta;
            transform.position=position;
            Debug.Log("Desceu");
        }
    }
}
