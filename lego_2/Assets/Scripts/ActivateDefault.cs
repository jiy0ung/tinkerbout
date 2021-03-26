using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDefault : MonoBehaviour
{
    private bool state;

    void Start()
    {
        state = false;
    }

    void Update()
    {
        if (state == false) {
            gameObject.SetActive(false);
            state = true;            
        }
    }
}
