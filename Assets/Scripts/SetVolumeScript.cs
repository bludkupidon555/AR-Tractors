using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class SetVolumeScript : MonoBehaviour
{
    public Text Text;

    public static float Volume;
    MyDatabase Database;

    private AudioSource AS;
    private Slider Slider;

    void Start()
    {
        Slider = GetComponent<Slider>();
        AS = GetComponent<AudioSource>();
        Database = new MyDatabase();
        Database.Name = "TractorsDB.bytes";
        Database.CreateORCheckDB();

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
                    AS.volume = 0;
                }
                else if (state == 1)
                {
                    Volume = Convert.ToSingle(Database.reader[1]);
                    AS.volume = Volume;
                    Slider.value = Volume;
                    Text.text = Math.Round(Volume, 2).ToString();
                }
                else
                {
                    AS.volume = 0;
                }
            }
            Database.reader.Close();
        }

        Database.connection.Close();

        Slider.onValueChanged.AddListener(SetVolumeFunction);
    }

    void Update()
    {
        AS.volume = Volume;
    }

    public void SetVolumeFunction(float vol)
    {
        Database.connection = new SqliteConnection("URI=file:" + Database.path);
        Database.connection.Open();

        if (Database.connection.State == ConnectionState.Open)
        {
            Database.cmd = new SqliteCommand();
            Database.cmd.Connection = Database.connection;
            Database.cmd.CommandText = "UPDATE StateMusicTable SET Volume = '"+ vol +"' WHERE Volume = '"+ Volume +"'";
            Database.cmd.ExecuteNonQuery();
        }

        Database.connection.Close();

        Volume = vol;
        Text.text = Math.Round(Volume, 2).ToString();
    }
}
