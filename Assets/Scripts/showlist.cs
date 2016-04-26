using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;
using UnityEngine.UI;

public class showlist : MonoBehaviour {

    public Text textt;

       public void Select()

    {
        string connectionString = "URI=file:" + Application.dataPath + "/mydatabase.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(connectionString);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();


        string sqlQuery = "SELECT * FROM Account";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string username = reader.GetString(1);
            string password  = reader.GetString(2);
            int age = reader.GetInt32(3);

            textt.text += "\nUsername=" + username + "\nPassword=" + password + "\nAge=" + age;
        }
        reader.Close(); reader = null;
        dbcmd.Dispose(); dbcmd = null;
        dbconn.Close(); dbconn = null;
    }







    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
