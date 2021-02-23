using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPositionScrollView : MonoBehaviour
{
    public Button BackB;
    private RectTransform RectBackB;

    public Button DelB;
    private RectTransform RectDelB;

    public Button AddB;
    private RectTransform RectAddB;

    public Button RotateB;
    private RectTransform RectRotateB;

    public ScrollRect SV;
    private RectTransform RectSV;

    void Start()
    {
        RectBackB = BackB.GetComponent<RectTransform>();
        RectDelB = DelB.GetComponent<RectTransform>();
        RectAddB = AddB.GetComponent<RectTransform>();
        RectRotateB = RotateB.GetComponent<RectTransform>();
        RectSV = SV.GetComponent<RectTransform>();
    }

    void Update()
    {
        // ������� ������ BackB
        if (RectBackB.anchoredPosition.x != (RectBackB.rect.width / 2 + 30))
        {
            float offsetX = 0;

            if (RectBackB.anchoredPosition.x > (RectBackB.rect.width / 2 + 30))
            {
                offsetX = RectBackB.anchoredPosition.x - (RectBackB.rect.width / 2 + 30);

                // �������� ������� �����
                RectBackB.offsetMin += new Vector2(-offsetX, 0);
                RectBackB.offsetMax -= new Vector2(offsetX, 0);
            }
            else if (RectBackB.anchoredPosition.x < (RectBackB.rect.width / 2 + 30))
            {
                offsetX = (RectBackB.rect.width / 2 + 30) - RectBackB.anchoredPosition.x;

                // �������� ������� ������
                RectBackB.offsetMin += new Vector2(offsetX, 0);
                RectBackB.offsetMax -= new Vector2(-offsetX, 0);
            }
        }// �������� �� X, BackB
        if (RectBackB.anchoredPosition.y != -(RectBackB.rect.height / 2 + 30))
        {
            float offsetY = 0;

            if (RectBackB.anchoredPosition.y > -(RectBackB.rect.height / 2 + 30))
            {
                offsetY = RectBackB.anchoredPosition.y - -(RectBackB.rect.height / 2 + 30);

                // �������� ����
                RectBackB.offsetMin += new Vector2(0, -offsetY);
                RectBackB.offsetMax -= new Vector2(0, offsetY);
            }
            else if (RectBackB.anchoredPosition.y < -(RectBackB.rect.height / 2 + 30))
            {
                offsetY = -(RectBackB.rect.height / 2 + 30) - RectBackB.anchoredPosition.y;

                // �������� �����
                RectBackB.offsetMin += new Vector2(0, offsetY);
                RectBackB.offsetMax -= new Vector2(0, -offsetY);
            }
        }// �������� �� Y, BackB
        // --------------------

        // ������� ������ DelB
        if (RectDelB.anchoredPosition.x != -(RectDelB.rect.width / 2 + 30))
        {
            float offsetX = 0;

            if (RectDelB.anchoredPosition.x > -(RectDelB.rect.width / 2 + 30))
            {
                offsetX = RectDelB.anchoredPosition.x - -(RectDelB.rect.width / 2 + 30);

                // �������� ������� �����
                RectDelB.offsetMin += new Vector2(-offsetX, 0);
                RectDelB.offsetMax -= new Vector2(offsetX, 0);
            }
            else if (RectDelB.anchoredPosition.x < (RectDelB.rect.width / 2 + 30))
            {
                offsetX = -(RectDelB.rect.width / 2 + 30) - RectDelB.anchoredPosition.x;

                // �������� ������� ������
                RectDelB.offsetMin += new Vector2(offsetX, 0);
                RectDelB.offsetMax -= new Vector2(-offsetX, 0);
            }
        }// �������� �� X, DelB
        if (RectDelB.anchoredPosition.y != -(RectBackB.rect.height / 2 + 30))
        {
            float offsetY = 0;

            if (RectDelB.anchoredPosition.y > -(RectDelB.rect.height / 2 + 30))
            {
                offsetY = RectDelB.anchoredPosition.y - -(RectDelB.rect.height / 2 + 30);

                // �������� ����
                RectDelB.offsetMin += new Vector2(0, -offsetY);
                RectDelB.offsetMax -= new Vector2(0, offsetY);
            }
            else if (RectDelB.anchoredPosition.y < -(RectDelB.rect.height / 2 + 30))
            {
                offsetY = -(RectDelB.rect.height / 2 + 30) - RectDelB.anchoredPosition.y;

                // �������� �����
                RectDelB.offsetMin += new Vector2(0, offsetY);
                RectDelB.offsetMax -= new Vector2(0, -offsetY);
            }
        }// �������� �� Y, DelB
        // --------------------

        // ������� ������ AddB
        if (RectAddB.anchoredPosition.x != (RectAddB.rect.width / 2 + 30))
        {
            float offsetX = 0;

            if (RectAddB.anchoredPosition.x > (RectAddB.rect.width / 2 + 30))
            {
                offsetX = RectAddB.anchoredPosition.x - (RectAddB.rect.width / 2 + 30);

                // �������� ������� �����
                RectAddB.offsetMin += new Vector2(-offsetX, 0);
                RectAddB.offsetMax -= new Vector2(offsetX, 0);
            }
            else if (RectAddB.anchoredPosition.x < (RectAddB.rect.width / 2 + 30))
            {
                offsetX = (RectAddB.rect.width / 2 + 30) - RectAddB.anchoredPosition.x;

                // �������� ������� ������
                RectAddB.offsetMin += new Vector2(offsetX, 0);
                RectAddB.offsetMax -= new Vector2(-offsetX, 0);
            }
        }// �������� �� X, AddB
        if (RectAddB.anchoredPosition.y != (RectAddB.rect.height / 2 + 30))
        {
            float offsetY = 0;

            if (RectAddB.anchoredPosition.y > (RectAddB.rect.height / 2 + 30))
            {
                offsetY = RectAddB.anchoredPosition.y - (RectAddB.rect.height / 2 + 30);

                // �������� ����
                RectAddB.offsetMin += new Vector2(0, -offsetY);
                RectAddB.offsetMax -= new Vector2(0, offsetY);
            }
            else if (RectAddB.anchoredPosition.y < (RectAddB.rect.height / 2 + 30))
            {
                offsetY = (RectAddB.rect.height / 2 + 30) - RectAddB.anchoredPosition.y;

                // �������� �����
                RectAddB.offsetMin += new Vector2(0, offsetY);
                RectAddB.offsetMax -= new Vector2(0, -offsetY);
            }
        }// �������� �� Y, AddB
        // --------------------

        // ������� ������ RotateB
        if (RectRotateB.anchoredPosition.x != -(RectRotateB.rect.width / 2 + 30))
        {
            float offsetX = 0;

            if (RectRotateB.anchoredPosition.x > -(RectRotateB.rect.width / 2 + 30))
            {
                offsetX = RectRotateB.anchoredPosition.x - -(RectRotateB.rect.width / 2 + 30);

                // �������� ������� �����
                RectRotateB.offsetMin += new Vector2(-offsetX, 0);
                RectRotateB.offsetMax -= new Vector2(offsetX, 0);
            }
            else if (RectRotateB.anchoredPosition.x < (RectRotateB.rect.width / 2 + 30))
            {
                offsetX = -(RectRotateB.rect.width / 2 + 30) - RectRotateB.anchoredPosition.x;

                // �������� ������� ������
                RectRotateB.offsetMin += new Vector2(offsetX, 0);
                RectRotateB.offsetMax -= new Vector2(-offsetX, 0);
            }
        }// �������� �� X, RotateB
        if (RectRotateB.anchoredPosition.y != (RectRotateB.rect.height / 2 + 30))
        {
            float offsetY = 0;

            if (RectRotateB.anchoredPosition.y > (RectRotateB.rect.height / 2 + 30))
            {
                offsetY = RectRotateB.anchoredPosition.y - (RectRotateB.rect.height / 2 + 30);

                // �������� ����
                RectRotateB.offsetMin += new Vector2(0, -offsetY);
                RectRotateB.offsetMax -= new Vector2(0, offsetY);
            }
            else if (RectRotateB.anchoredPosition.y < (RectRotateB.rect.height / 2 + 30))
            {
                offsetY = (RectRotateB.rect.height / 2 + 30) - RectRotateB.anchoredPosition.y;

                // �������� �����
                RectRotateB.offsetMin += new Vector2(0, offsetY);
                RectRotateB.offsetMax -= new Vector2(0, -offsetY);
            }
        }// �������� �� Y, RotateB
        // --------------------

        if (Screen.orientation == ScreenOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            //������� ������ ScrollView � Portrait
            if (RectSV.anchoredPosition.y != (60 + RectAddB.rect.height + RectSV.rect.height / 2))
            {
                float offsetY = 0;

                if (RectSV.anchoredPosition.y > (60 + RectAddB.rect.height + RectSV.rect.height / 2))
                {
                    offsetY = RectSV.anchoredPosition.y - (60 + RectAddB.rect.height + RectSV.rect.height / 2);

                    // �������� ������� ����
                    RectSV.offsetMin += new Vector2(0, -offsetY);
                    RectSV.offsetMax -= new Vector2(0, offsetY);
                }
                else if (RectSV.anchoredPosition.y < (60 + RectAddB.rect.height + RectSV.rect.height / 2))
                {
                    offsetY = (60 + RectAddB.rect.height + RectSV.rect.height / 2) - RectSV.anchoredPosition.y;

                    // �������� ������� �����
                    RectSV.offsetMin += new Vector2(0, offsetY);
                    RectSV.offsetMax -= new Vector2(0, -offsetY);
                }

            }// �������� �� Y, ScrollView
            // --------------------
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            //������� ������ ScrollView � Landscape
            if (RectSV.anchoredPosition.y != (30 + RectSV.rect.height / 2))
            {
                float offsetY = 0;

                if (RectSV.anchoredPosition.y > (30 + RectSV.rect.height / 2))
                {
                    offsetY = RectSV.anchoredPosition.y - (30 + RectSV.rect.height / 2);

                    // �������� ������� ����
                    RectSV.offsetMin += new Vector2(0, -offsetY);
                    RectSV.offsetMax -= new Vector2(0, offsetY);
                }
                else if (RectSV.anchoredPosition.y < (30 + RectSV.rect.height / 2))
                {
                    offsetY = (30 + RectSV.rect.height / 2) - RectSV.anchoredPosition.y;

                    // �������� ������� �����
                    RectSV.offsetMin += new Vector2(0, offsetY);
                    RectSV.offsetMax -= new Vector2(0, -offsetY);
                }

            }// �������� �� Y, ScrollView
            // --------------------
        }
    }
}
