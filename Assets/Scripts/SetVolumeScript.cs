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
    public static float Volume = 0.75f;

    MyDatabase Database;

    void Start()
    {
        //Database = new MyDatabase();
        //Database.Name = "TractorsDB.bytes";
        //Database.CreateORCheckDB();
    }

    void Update()
    {
        
    }

    public void SetVolume()
    {

    }
}
