using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class LanguageScene2 : MonoBehaviour
{
    MyDatabase Database;
    private string Language;
    private string SelectedTable;

    List<string> LanguageList;

    public Text Help;
    public Text AddB;
    public Text DelB;
    public Text RotationB;
    public Text Instructions;

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

        Help.text = LanguageList[4];
        AddB.text = LanguageList[5];
        DelB.text = LanguageList[6];
        RotationB.text = LanguageList[7];
        Instructions.text = LanguageList[8];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
