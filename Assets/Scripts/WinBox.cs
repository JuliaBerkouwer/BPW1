using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinBox : MonoBehaviour
{

    public GameObject rescueBoard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<GameManager>().CheckRabbits())
            {
                other.GetComponent<GameManager>().Finnish();
                GetComponent<SphereCollider>().enabled = false;
            }

            else
            {
                rescueBoard.SetActive(true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            rescueBoard.SetActive(false);
        }
    }
}
