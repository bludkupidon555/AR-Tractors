using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Test1 : MonoBehaviour
{
    private Button Button;
    public Text Text;

    private SqliteConnection connection;
    private string path;
    private SqliteCommand cmd;
    private SqliteDataReader reader;
    private string DatabaseName = "TractorsDB.bytes";

    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(TestFunction);

        if (Application.platform != RuntimePlatform.Android)
        {
            path = Application.dataPath + "/Plugins/" + DatabaseName;
        }
        else
        {
            path = Application.persistentDataPath + "/" + DatabaseName;

            if (!File.Exists(path))
            {
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/"+DatabaseName);
                while(!load.isDone) 
                {
                    Debug.Log("State: "+ load.isDone);
                }
                Debug.Log("State: " + load.isDone);
                File.WriteAllBytes(path, load.bytes);
            }
        }
    }
    
    void TestFunction()
    {
        connection = new SqliteConnection("URI=file:" + path);
        connection.Open();

        if (connection.State == ConnectionState.Open)
        {
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT StateMusic FROM StateMusicTable";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Text.text = reader.GetInt32(0).ToString();
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Text.text = e.ToString();
                Debug.Log(e);
            }
        }
        else
        {
            Text.color = Color.red;
            Text.text = "Close";
        }

        connection.Close();
    }
}
