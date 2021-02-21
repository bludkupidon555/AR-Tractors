using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddObject : MonoBehaviour
{
    private Button button;
    private ProgrammManager ProgrammManagerScript;
    private bool closeScrollView = false;

    //private GameObject cont;
    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(AddObjectFunction);
    }

    void Update()
    {
        if (Convert.ToString(Screen.orientation) == "Portrait")
        {
            
        }
        else if (Convert.ToString(Screen.orientation) == "LandscapeLeft")
        {
            
        }
        else if (Convert.ToString(Screen.orientation) == "LandscapeRight")
        {
            
        }
        else if (Convert.ToString(Screen.orientation) == "PortraitUpsideDown")
        {
            
        }
    }

    void AddObjectFunction()
    {
        if (!closeScrollView)
        {
            ProgrammManagerScript.ScrollView.SetActive(true);
            closeScrollView = true;
        }
        else
        {
            ProgrammManagerScript.ScrollView.SetActive(false);
            closeScrollView = false;
        }

        
        //button.transform.Rotate(0, 0, -90);
        //cont = GameObject.Find("tractor1Button");
        //cont.transform.Rotate(0, 0, -90);
    }
}
