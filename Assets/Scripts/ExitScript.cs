using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    private Button Button;
    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(ExitFunction);
    }

    // Update is called once per frame
    void ExitFunction()
    {
        Application.Quit();
    }
}
