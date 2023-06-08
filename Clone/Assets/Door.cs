using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ControlerToTheDoor : MonoBehaviour
{
    public void OpenDoor()
    {
        GetComponent<Animator>().SetBool("Open", true);
    }

    public void CloseDoor()
    {
        GetComponent<Animator>().SetBool("Open", false);
    }

}
