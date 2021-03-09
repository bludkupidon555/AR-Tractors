using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteObjectScript : MonoBehaviour
{
    private Button button;// ������ � ������� �������� ������
    
    void Start()// �������, ������� �������������� � ������� ������� DeleteObjectFunction
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DeleteObjectFunction);
    }

    public void DeleteObjectFunction()// �������� ���������� �������
    {
        Destroy(GameObject.FindGameObjectWithTag("Selected"));
    }
}
