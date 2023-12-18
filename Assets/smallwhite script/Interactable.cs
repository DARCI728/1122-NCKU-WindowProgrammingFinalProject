using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public bool playerinrange;
    public string GetItemName()
    {
        return Name;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FirstPersonController")
        {
            playerinrange = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name== "FirstPersonController")
        {
            playerinrange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FirstPersonController")
        {
            playerinrange = false;
        }
    }
}
