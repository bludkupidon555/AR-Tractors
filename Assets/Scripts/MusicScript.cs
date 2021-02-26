using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;


public class MusicScript : MonoBehaviour
{
    private Button Button;
    private Image Img;
    private AudioSource AS;
    public AudioClip Track;

    private bool StateMusic;

    MyDatabase Database;

    public Sprite Music;
    public Sprite NoMusic;

    private float Volume = 0.75f;

    void Start()
    {
        Button = GetComponent<Button>();
        Img = Button.GetComponent<Image>();
        AS = Button.GetComponent<AudioSource>();

        Database = new MyDatabase();
        Database.Name = "TractorsDB.bytes";

        if (Application.platform != RuntimePlatform.Android)
        {
            Database.path = Application.dataPath + "/Plugins/" + Database.Name;
        }
        else
        {
            Database.path = Application.persistentDataPath + "/" + Database.Name;

            if (!File.Exists(Database.path))
            {
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + Database.Name);
                while (!load.isDone)
                {
                    Debug.Log("State: " + load.isDone);
                }
                Debug.Log("State: " + load.isDone);
                File.WriteAllBytes(Database.path, load.bytes);
            }
        }

        Database.connection = new SqliteConnection("URI=file:" + Database.path);
        Database.connection.Open();

        if (Database.connection.State == ConnectionState.Open)
        {
            Database.cmd = new SqliteCommand();
            Database.cmd.Connection = Database.connection;
            Database.cmd.CommandText = "SELECT * FROM StateMusicTable";
            Database.reader = Database.cmd.ExecuteReader();
            while (Database.reader.Read())
            {
                int state = Convert.ToInt32(Database.reader[0]);

                if (state == 0)
                {
                    StateMusic = false;
                    AS.volume = 0;
                }
                else if (state == 1)
                {
                    StateMusic = true;
                    AS.volume = Volume;
                }
                else
                {
                    StateMusic = false;
                    AS.volume = 0;
                }
            }
            Database.reader.Close();

        }

        Database.connection.Close();

        if (StateMusic == true)
        {
            Img.sprite = Music;
        }
        else
        {
            Img.sprite = NoMusic;
        }

        Button.onClick.AddListener(MusicFunction);
    }

    
    void MusicFunction()
    {
        if (StateMusic == true)
        {
            Database.connection.Open();
            if (Database.connection.State == ConnectionState.Open)
            {
                Database.cmd.Connection = Database.connection;
                Database.cmd.CommandText = "UPDATE StateMusicTable SET StateMusic = 0 WHERE StateMusic = 1";
                Database.cmd.ExecuteNonQuery();
            }
            Database.connection.Close();

            Img.sprite = NoMusic;
            AS.volume = 0;
            StateMusic = false;
        }
        else
        {
            Database.connection.Open();
            if (Database.connection.State == ConnectionState.Open)
            {
                Database.cmd.Connection = Database.connection;
                Database.cmd.CommandText = "UPDATE StateMusicTable SET StateMusic = 1 WHERE StateMusic = 0";
                Database.cmd.ExecuteNonQuery();
            }
            Database.connection.Close();

            Img.sprite = Music;
            AS.volume = Volume;
            StateMusic = true;
        }
    }
}

public class MyDatabase
{
    public SqliteConnection connection;
    public string path;
    public SqliteCommand cmd;
    public SqliteDataReader reader;
    public string Name;
}
