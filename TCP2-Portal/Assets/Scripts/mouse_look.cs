using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{
    public float mouseSensibilidade = 2;
    public float suavizacao = 1.5f;
    public Transform playerBody;

    private Vector2 velocidadeFrame, velocidadeRotacao;
    //float xRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        Vector2 mouseInputs = new Vector2(Input.GetAxisRaw("Mouse X"),
         Input.GetAxisRaw("Mouse Y"));

        Vector2 rawVelocidadeFrame = Vector2.Scale(mouseInputs, 
        Vector2.one * mouseSensibilidade);

        velocidadeFrame = Vector2.Lerp(velocidadeFrame, rawVelocidadeFrame, 
        1/suavizacao);
        velocidadeRotacao += velocidadeFrame;
        velocidadeRotacao.y = Mathf.Clamp(velocidadeRotacao.y, -90,90);

        transform.localRotation = Quaternion.AngleAxis(-velocidadeRotacao.y,
        Vector3.right);
        playerBody.localRotation = Quaternion.AngleAxis(velocidadeRotacao.x, 
        Vector3.up);


        // float mouseX = Input.GetAxis("Mouse X") * mouseSensibilidade * 
        //                                                 Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensibilidade * 
        //                                                 Time.deltaTime;

        // xRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation, -90, 90);

        // transform.localRotation = Quaternion.Euler(xRotation,0,0);

        // playerBody.Rotate(Vector3.up * mouseX);
    }
}
