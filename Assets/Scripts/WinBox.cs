using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<GameManager>().Finnish();
            GetComponent<SphereCollider>().enabled = false;
        }

    }
}
