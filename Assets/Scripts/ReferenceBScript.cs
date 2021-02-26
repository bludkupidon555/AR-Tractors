using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceBScript : MonoBehaviour
{
    private Button Button;
    
    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(OpenRefFunction);
    }

    void OpenRefFunction()
    {
        Application.OpenURL("http://en.kirovets-ptz.com/");
    }
}
