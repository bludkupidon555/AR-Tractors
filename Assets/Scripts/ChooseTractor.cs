using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTractor : MonoBehaviour
{
    private ProgrammManager ProgrammManagerScript;

    private Button button;

    public GameObject ChoosedTractor;
    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseTractorsFunction);
    }

    void ChooseTractorsFunction()
    {
        ProgrammManagerScript.ObjectToSpawn = ChoosedTractor;
        ProgrammManagerScript.ChooseObject = true;
        ProgrammManagerScript.ScrollView.SetActive(false);
    }
}
