using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    private Button Button;

    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(LoadSceneFunction);
    }

    void LoadSceneFunction()
    {
        SceneManager.LoadScene(3);
    }
}
