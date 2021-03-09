using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class LanguageScene0 : MonoBehaviour
{
    MyDatabase Database;
    private string Language;
    private string SelectedTable;

    List<string> LanguageList;

    public Text StartB;
    public Text InstructionsB;
    public Text SettingsB;
    public Text ExitB;

    void Start()
    {
        Database = new MyDatabase();
        Database.Name = "TractorsDB.bytes";
        Database.CreateORCheckDB();

        Database.connection = new SqliteConnection("URI=file:" + Database.path);
        Database.connection.Open();

        if (Database.connection.State == ConnectionState.Open)
        {
            Database.cmd = new SqliteCommand();
            Database.cmd.Connection = Database.connection;
            Database.cmd.CommandText = "SELECT * FROM SelectedLanguageTable";
            Database.reader = Database.cmd.ExecuteReader();
            while (Database.reader.Read())
            {
                Language = Database.reader[0].ToString();

                if (Language == "Ru")
                {
                    SelectedTable = "RussianLanguageTable";
                }
                else if (Language == "En")
                {
                    SelectedTable = "EnglishLanguageTable";
                }
            }

            Database.reader.Close();

            Database.cmd.CommandText = "SELECT * FROM " + SelectedTable;
            Database.reader = Database.cmd.ExecuteReader();

            LanguageList = new List<string>();

            while (Database.reader.Read())
            {
                LanguageList.Add(Database.reader[0].ToString());
            }

            Database.reader.Close();
        }
        Database.connection.Close();

        StartB.text = LanguageList[0];
        InstructionsB.text = LanguageList[1];
        SettingsB.text = LanguageList[2];
        ExitB.text = LanguageList[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
