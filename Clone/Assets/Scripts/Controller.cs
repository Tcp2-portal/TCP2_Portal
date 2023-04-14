using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.ComTypes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
namespace Scripts
{
    public class Controller : MonoBehaviour
    {
        public float speed = 5f;
        private void LateUpdate()
        {
            float VAxes = Input.GetAxis("Vertical");
            float HAxes = Input.GetAxis("Horizontal");



            Vector3 dir = new Vector3(HAxes, 0, VAxes);
            this.transform.Translate(dir * speed * Time.deltaTime);
        }
    }
}