using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class ConnectionScript : MonoBehaviour
{
    public SqliteConnection dbconnection;
    private string path;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setConnection()
    {
        path = Application.dataPath + "/StreamingAssets/TractorsDB.db";
        dbconnection = new SqliteConnection("URI=file:" + path);
        dbconnection.Open();
        if(dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbconnection;
            cmd.CommandText = "SELECT * FROM Tractors";
            SqliteDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Debug.Log(String.Format("{0}    {1} ", r[0], r[1]));
            }
            dbconnection.Close();
        }
        else
        {
            Debug.Log("Error connection");
        }
    }
}
