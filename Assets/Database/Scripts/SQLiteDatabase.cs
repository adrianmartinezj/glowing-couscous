using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLiteDatabase : MonoBehaviour
{
	// Public
	public static SQLiteDatabase Instance = null;
    public IDbConnection DBConnection { get; private set; }

    private void Awake()
	{
		if (!Instance)
		{
			Instance = this;
            DatabaseSystem.Database = Instance;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
	}
	private void OnApplicationQuit()
	{
		DBConnection.Close();
	}
	void Start()
    {
		// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";
		Debug.Log(Application.persistentDataPath);
		// Open connection
		DBConnection = new SqliteConnection(connection);
		DBConnection.Open();
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
