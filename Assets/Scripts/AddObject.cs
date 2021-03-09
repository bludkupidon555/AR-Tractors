using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddObject : MonoBehaviour
{
    private Button button;// Кнопка к которой привязан скрипт
    private ProgrammManager ProgrammManagerScript;// Ссылка на Главный скрипт управления
    private bool closeScrollView = false;// Переменная отвечающая за отображение ScrollView

    //private GameObject cont;
    void Start()// Функция, которая отвечает за инициализацию и получение компонентов, также за создание привязку события к кнопке
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(AddObjectFunction);
    }

    void AddObjectFunction()// Функция, которая проверяет возможность добавление объекта, также отвечает за отображение ScrollView
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
    }
}
