using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Sprite noactive;
    public Sprite active;

    private Button Button;
    private Image Img;

    private ProgrammManager ProgrammManagerScript;

    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        Button = GetComponent<Button>();
        Img = Button.GetComponent<Image>();

        Button.onClick.AddListener(RotationFunction);
    }

    void RotationFunction()
    {
        if (ProgrammManagerScript.Rotation)
        {
            ProgrammManagerScript.Rotation = false;
            //GetComponent<Image>().color = Color.clear;
            Img.sprite = noactive;
        }
        else
        {
            ProgrammManagerScript.Rotation = true;
            //GetComponent<Image>().color = Color.green;
            Img.sprite = active;
        }
    }
}