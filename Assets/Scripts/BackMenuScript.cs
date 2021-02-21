using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackMenuScript : MonoBehaviour
{
    private Button Button;

    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(BackFunction);
    }

    // Update is called once per frame
    void BackFunction()
    {
        SceneManager.LoadScene(0);
    }
}
