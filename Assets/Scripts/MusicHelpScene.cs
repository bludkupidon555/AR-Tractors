using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class MusicHelpScene : MonoBehaviour
{
    MyDatabase Database;
    private AudioSource AS;

    void Start()
    {
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
                    AS.volume = Convert.ToSingle(Database.reader[1]);
                }
                else
                {
                    AS.volume = 0;
                }
            }
            Database.reader.Close();
        }

        Database.connection.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
