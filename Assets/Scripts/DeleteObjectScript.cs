using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteObjectScript : MonoBehaviour
{
    private Button button;// Кнопка к которой привязан скрипт
    
    void Start()// Функция, которая инициализирует и создает функцию DeleteObjectFunction
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DeleteObjectFunction);
    }

    public void DeleteObjectFunction()// Удаление выбранного объекта
    {
        Destroy(GameObject.FindGameObjectWithTag("Selected"));
    }
}
