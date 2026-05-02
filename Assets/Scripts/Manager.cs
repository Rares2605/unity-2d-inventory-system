using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public GameObject inventory;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.SetActive(false);
        }
      
    }
 
}
