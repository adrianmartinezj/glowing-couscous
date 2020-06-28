using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using UnityEngine.Assertions;

public class CommandResult
{
	public bool IsSuccessful = true;
	public object Packet;
	public CommandResult(bool wasSuccess, object packet)
	{
		Packet = packet;
		IsSuccessful = wasSuccess;
	}
}

public static class DatabaseSystem
{
	// Public
	[SerializeField]
	public static SQLiteDatabase Database;
	public enum SQLiteCommand { CreateTable, Select, Insert };

    public static void testFunc()
    {
		Command(SQLiteCommand.CreateTable, "IF NOT EXISTS Weapons ( id INTEGER PRIMARY KEY, damage INTEGER, speed REAL, name TEXT );");
		//Command(SQLiteCommand.Insert, "INTO Weapons (id, damage, name, speed) VALUES (0, 100, 'Warp Sword', .5 );");
		IDataReader reader = (IDataReader)Command(SQLiteCommand.Select, "* FROM Weapons").Packet;
		if (reader != null)
		{
			while (reader.Read())
			{
				Debug.Log("id: " + reader[0].ToString());
				Debug.Log("damage: " + reader[1].ToString());
				Debug.Log("speed: " + reader[2].ToString());
				Debug.Log("name: " + reader[3].ToString());
			}
		}
	}

	/*
	 * Returns true if command sent, otherwise false.
	 */
	public static CommandResult Command(SQLiteCommand cmd, string args)
	{
		if (!Database) return new CommandResult(false, null);
		else
		{
			IDbConnection dbcon = Database.DBConnection;
			IDbCommand dbcmd = dbcon.CreateCommand();
			string commandText = "";
			object result = null;

			switch (cmd)
			{
				case SQLiteCommand.CreateTable:
					commandText = "CREATE TABLE " + args;
					break;
				case SQLiteCommand.Select:
					commandText = "SELECT " + args;
					break;
				case SQLiteCommand.Insert:
					commandText = "INSERT " + args;
					break;
				default:
					Debug.LogError("Unknown SQLite command type.");
					break;
			}
			dbcmd.CommandText = commandText;
			result = dbcmd.ExecuteReader();
			return new CommandResult(false, result);
		}
	}
}
