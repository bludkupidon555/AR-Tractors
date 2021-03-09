 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    [Header("Вставьте маркер")] [SerializeField] private GameObject PlaneMarkerPrefab;

    private ARRaycastManager ARRaycastManagerScript;
    private DeleteObjectScript DeleteObjectScript;

    private Vector2 TouchPosition;

    public GameObject ObjectToSpawn;
 
    public bool ChooseObject = false;

    public GameObject ScrollView;

    [SerializeField] private Camera ARCamera;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject SelectedObject;

    public bool Rotation; 

    private Quaternion YRotation;

    public GameObject delButton;

    public ScrollRect SV;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);
        ScrollView.SetActive(false);
        delButton.SetActive(false);
    }

    void Update()
    {
        if (ChooseObject)
        { 
            ShowMarkerAndSetObjects();
        }

        MoveObjectAndRotation();
    }

    void  ShowMarkerAndSetObjects()//Функция отображения маркера и добавления объектов на сцену
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();// Лист лучей, которые нашли плоскость

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);// Запуск луча для поиска плоскости

        if (hits.Count > 0)// Если плоскость найдена, отображаем красный маркер
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)// Если есть нажатие, то добавляем выбранный объект
        {
            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
            ChooseObject = false;
            PlaneMarkerPrefab.SetActive(false); 
        }
    }

    void MoveObjectAndRotation()// Функция перемещения или вращения объектов
    {
        if(Input.touchCount > 0)// Если вы нажали на экран
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)// Если вы выделили объект на экране, то он получает тег Selected(выделенный)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("UnSelected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }

            SelectedObject = GameObject.FindWithTag("Selected");// Выделенный объект

            if (touch.phase == TouchPhase.Moved && Input.touchCount == 1)// Если вы нажали на экран и не отпустили кнопку
            {
                if (Rotation)// Если кнопка "Перемещение-вращение" активна, то выполняется функция вращения объекта
                {
                    YRotation = Quaternion.Euler(0f, -touch.deltaPosition.x*0.1f, 0f);
                    SelectedObject.transform.rotation = YRotation * SelectedObject.transform.rotation;
                    delButton.SetActive(true);
                }
                else// Иначе, объект перемещается
                {
                    ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);
                    SelectedObject.transform.position = hits[0].pose.position;
                    delButton.SetActive(true);
                }
            }

            if(touch.phase == TouchPhase.Ended)// При отжатии на экран, выбранный объект получает тег Unselected(невыделенный)
            {
                if(SelectedObject.CompareTag("Selected"))
                {
                    SelectedObject.tag = "UnSelected";
                    delButton.SetActive(false);
                }
            }
        }
    }
}
