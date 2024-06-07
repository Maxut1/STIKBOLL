using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "geng")
        {
         Time.timeScale = 0.1f;
         Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }

}
