using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.UI;

public class select : MonoBehaviour
{
    public GameObject ttcoin;
    public GameObject coinspawner;
    public GameObject interaction_Info_UI;
    public Camera Camera1;
    Text interaction_text;
    Text ttcoin_text;

    private void Start()
    {
        ttcoin_text =ttcoin.GetComponent<Text>();
        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }

    void Update()
    {
        Ray ray = Camera1.ScreenPointToRay(Input.mousePosition);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            if (selectionTransform.GetComponent<Interactable>()==true&& selectionTransform.GetComponent<Interactable>().playerinrange)
            {
                Debug.Log("123");
                if (Input.GetKeyDown(KeyCode.Mouse1)&& selectionTransform.GetComponent<Interactable>().Name=="stone"&& coinspawner.GetComponent<coinspawner>().totalcoins>=15)
                {
                    selectionTransform.GetComponent<chestopen>().openchest();
                    coinspawner.GetComponent<coinspawner>().totalcoins -= 15;
                    ttcoin_text.text = "" + coinspawner.GetComponent<coinspawner>().totalcoins;

                }
                else if (Input.GetKeyDown(KeyCode.Mouse1) && selectionTransform.GetComponent<Interactable>().Name == "gold" && coinspawner.GetComponent<coinspawner>().totalcoins >= 30)
                {
                    selectionTransform.GetComponent<chestopen>().openchest();
                    coinspawner.GetComponent<coinspawner>().totalcoins -= 30;
                    ttcoin_text.text = "" + coinspawner.GetComponent<coinspawner>().totalcoins;

                }
                else if (Input.GetKeyDown(KeyCode.Mouse1) && selectionTransform.GetComponent<Interactable>().Name == "chest")
                {
                    selectionTransform.GetComponent<chestopen>().openchest();
                    ttcoin_text.text = "" + coinspawner.GetComponent<coinspawner>().totalcoins;

                }
                else if (Input.GetKeyDown(KeyCode.F) && selectionTransform.GetComponent<Interactable>().Name == "coin")
                {
                    coinspawner.GetComponent<coinspawner>().totalcoins++;
                    ttcoin_text.text= ""+coinspawner.GetComponent<coinspawner>().totalcoins;
                    selectionTransform.GetComponent<destroycoin>().destroy();
                }
                if (selectionTransform.GetComponent<chestopen>()&&selectionTransform.GetComponent<chestopen>().opened== false && selectionTransform.GetComponent<Interactable>().Name == "chest")
                {
                    interaction_text.text = "right click to open the chest";
                    interaction_Info_UI.SetActive(true);
                }
                else if (selectionTransform.GetComponent<chestopen>() && selectionTransform.GetComponent<chestopen>().opened == false && selectionTransform.GetComponent<Interactable>().Name == "stone")
                {
                    interaction_text.text = "right click to open the chest(15coins)";
                    interaction_Info_UI.SetActive(true);
                }
                else if (selectionTransform.GetComponent<chestopen>() && selectionTransform.GetComponent<chestopen>().opened == false && selectionTransform.GetComponent<Interactable>().Name == "gold")
                {
                    interaction_text.text = "right click to open the chest(30coins)";
                    interaction_Info_UI.SetActive(true);
                }
                else if( selectionTransform.GetComponent<Interactable>().Name == "coin")
                {
                    interaction_text.text = "press F to pick up the coin";
                    interaction_Info_UI.SetActive(true);
                }
                else
                {
                    interaction_Info_UI.SetActive(false);
                }
                
                //interaction_Info_UI.GetComponent<Text>().text = selectionTransform.GetComponent<Interactable>().GetItemName();
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }

        }
        else
        {
            interaction_Info_UI.SetActive(false);
        }
    }
}
