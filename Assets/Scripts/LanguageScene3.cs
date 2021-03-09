using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class LanguageScene3 : MonoBehaviour
{
    MyDatabase Database;
    private string Language;
    private string SelectedTable;

    List<string> LanguageList;

    public Text SettingsB;
    public Text VolumeMusic;
    public Text SelectL;
    public Text SelectedL;
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

        SettingsB.text = LanguageList[9];
        VolumeMusic.text = LanguageList[10];
        SelectL.text = LanguageList[11];

        string l = "";
        if(Language == "Ru")
        {
            l = "Русский";
        }
        else
        {
            l = "English";
        }

        SelectedL.text = LanguageList[12] + Environment.NewLine + Environment.NewLine + "<color='green'>"+ l +"</color>";
    }
}
