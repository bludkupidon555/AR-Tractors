using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class SetLEnB : MonoBehaviour
{
    private Button Button;
    MyDatabase Database;

    private string SelectedTable;
    List<string> LanguageList;

    public Text Settings;
    public Text VolumeMusic;
    public Text SelectLanguage;
    public Text SelectedLanguage;

    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(SetLanguageFunction);
    }

    // Update is called once per frame
    void SetLanguageFunction()
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
            Database.cmd.CommandText = "UPDATE SelectedLanguageTable SET SelectedLanguage = 'En' WHERE SelectedLanguage = 'Ru'";
            Database.cmd.ExecuteNonQuery();
        }

        SelectedTable = "EnglishLanguageTable";

        Database.cmd.CommandText = "SELECT * FROM " + SelectedTable;
        Database.reader = Database.cmd.ExecuteReader();

        LanguageList = new List<string>();

        while (Database.reader.Read())
        {
            LanguageList.Add(Database.reader[0].ToString());
        }
        Database.reader.Close();
        Database.connection.Close();

        Settings.text = LanguageList[9];
        VolumeMusic.text = LanguageList[10];
        SelectLanguage.text = LanguageList[11];
        SelectedLanguage.text = LanguageList[12] + Environment.NewLine + Environment.NewLine + "<color='green'>English</color>";
    }
}
