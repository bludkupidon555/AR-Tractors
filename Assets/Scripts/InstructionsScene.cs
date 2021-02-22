using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsScene : MonoBehaviour
{
    private Button Button;

    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(LoadSceneFunction);
    }

    void LoadSceneFunction()
    {
        SceneManager.LoadScene(2);
    }
}
