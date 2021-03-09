using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddObject : MonoBehaviour
{
    private Button button;// ������ � ������� �������� ������
    private ProgrammManager ProgrammManagerScript;// ������ �� ������� ������ ����������
    private bool closeScrollView = false;// ���������� ���������� �� ����������� ScrollView

    //private GameObject cont;
    void Start()// �������, ������� �������� �� ������������� � ��������� �����������, ����� �� �������� �������� ������� � ������
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(AddObjectFunction);
    }

    void AddObjectFunction()// �������, ������� ��������� ����������� ���������� �������, ����� �������� �� ����������� ScrollView
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
