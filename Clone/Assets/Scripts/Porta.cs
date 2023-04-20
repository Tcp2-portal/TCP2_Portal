using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class Porta : MonoBehaviour
{
    Vector3 position;
    public float EndPosY;
    private float StartPosY;
    private bool open = false;
    public float speed = .05f;
    private void Start()
    {
        position = transform.localPosition;
        StartPosY = transform.localPosition.y;
    }

    public void AbrePorta()
    {
        open = true;
    }

    public void FecharPorta()
    {
        open = false;
    }
    private void Update()
    {
        if (open)
        {
            position.y = Mathf.Lerp(position.y, EndPosY, speed * Time.deltaTime);
        }
        if (!open)
        {
            position.y = Mathf.Lerp(position.y, StartPosY, speed * Time.deltaTime);
        }
        transform.localPosition = position;
    }
}
