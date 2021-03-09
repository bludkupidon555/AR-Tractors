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
    public static AudioSource AS;
    public AudioClip Track;

    private bool StateMusic;

    MyDatabase Database;

    public Sprite Music;
    public Sprite NoMusic;

    void Start()
    {
        Button = GetComponent<Button>();
        Img = Button.GetComponent<Image>();
        AS = Button.GetComponent<AudioSource>();

        Database = new MyDatabase();// Инициализируем экзмепляр объекта MyDatabase
        Database.Name = "TractorsDB.bytes";// Присваиваем переменной Name, объекта MyDatabase, значение имени файла базы данных

        Database.CreateORCheckDB();// Вызов метода CreateORCheckDB экземпляра Database объекта (класса) MyDatabase

        Database.connection = new SqliteConnection("URI=file:" + Database.path);// Инициализация и объявление переменной connection, которая отвечает за подключение к базе даных 
        Database.connection.Open();// Вызов метода Open, который открывает подключение к базе данных по пути, который содержится в переменной connection

        if (Database.connection.State == ConnectionState.Open)// Если соединение установлено
        {
            Database.cmd = new SqliteCommand();// Инициализация и объявление переменной cmd, экземпляра Database
            Database.cmd.Connection = Database.connection;
            Database.cmd.CommandText = "SELECT * FROM StateMusicTable";// Текст запроса к базе данных, переменной cmd
            Database.reader = Database.cmd.ExecuteReader();// Инициализация переменной reader и выполнение метода ExecuteReader, переменной cmd
            while (Database.reader.Read())// Цикл while(пока) reader считывает строки из таблицы StateMusicTable
            {
                int state = Convert.ToInt32(Database.reader[0]);// Инициализация переменной state и присвоение значения из столбца StateMusic

                if (state == 0)// Если эквивалентно 0
                {
                    StateMusic = false;
                    AS.volume = 0;
                }
                else if (state == 1)// Если эквивалентно 1
                {
                    StateMusic = true;
                    AS.volume = Convert.ToSingle(Database.reader[1]);
                }
                else// Иначе
                {
                    StateMusic = false;
                    AS.volume = 0;
                }
            }
            Database.reader.Close();// Выключение reader
        }

        Database.connection.Close();// Закрытие подключения с базой данных

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

            Database.cmd.CommandText = "SELECT * FROM StateMusicTable";
            Database.reader = Database.cmd.ExecuteReader();
            while (Database.reader.Read())
            {
                AS.volume = Convert.ToSingle(Database.reader[1]);
            }

            Database.reader.Close();
            Database.connection.Close();

            Img.sprite = Music;
            StateMusic = true;
        }
    }
}

public class MyDatabase
{
    public SqliteConnection connection;// Объект, отвечающий за соединение
    public string path;// Переменная, содержащая путь к файлу базы данных
    public SqliteCommand cmd;// Объект, отвечающий за выполнение запросов к базе данных
    public SqliteDataReader reader;// Объект, отвечающий за считывание данных из запросов
    public string Name;// Переменная, содержащая название файла базы данных

    public void CreateORCheckDB()// Главный метод, который проверяет наличие файла базы данных, в случае его отсутствия загружает новый файл базы данных
    {
        if (Application.platform != RuntimePlatform.Android)// Если операционная система не Android
        {
            path = Application.dataPath + "/Plugins/" + Name;
        }
        else// Если Операционная система Android
        {
            path = Application.persistentDataPath + "/" + Name;

            if (!File.Exists(path))//Если файл базы данных по пути path не найден, заружает новый
            {
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + Name);
                while (!load.isDone)
                {
                    Debug.Log("State: " + load.isDone);
                }
                Debug.Log("State: " + load.isDone);
                File.WriteAllBytes(path, load.bytes);
            }
        }
    }
}
