using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    private Button Button;

    private ProgrammManager ProgrammManagerScript;

    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        Button = GetComponent<Button>();
        Button.onClick.AddListener(RotationFunction);
    }

    void RotationFunction()
    {
        if (ProgrammManagerScript.Rotation)
        {
            ProgrammManagerScript.Rotation = false;
            GetComponent<Image>().color = Color.clear;
        }
        else
        {
            ProgrammManagerScript.Rotation = true;
            GetComponent<Image>().color = Color.green;
        }
    }
}