using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;

public class HighScoreManager : MonoBehaviour {
    private String connectionString;

    private List<HighScore> highScores = new List<HighScore>();

    
    public GameObject scorePrefab;
    public int topRanks;
    public int saveScores;
    public Transform scoreParent;
    
   


    // Use this for initialization
    void Start () {
        connectionString = "URI=file:" + Application.dataPath+ "/HighScoresDB.sqlite";
        
        DeleteExtraScore();
        ShowScores();
	}
	
	// Update is called once per frame
	void Update () {
 
	}
    private void ShowScores()
    {

        GetScores();
        for(int i =0; i<topRanks; i++)
        {
            if (topRanks > highScores.Count -1)
            {
                topRanks = highScores.Count;
            }
            GameObject tempObjec = Instantiate(scorePrefab);

            HighScore tmpScore = highScores[i];

            tempObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), (i+1).ToString());

            tempObjec.transform.SetParent(scoreParent);

            tempObjec.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.17f, 1.0f);
        }
    }
    private void DeleteScore(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", id);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    public void InsertScore(String name, int newScore)
    {

        
        int hsCount = highScores.Count;
        if (highScores.Count >0)
        {
            HighScore lowestScore = highScores[highScores.Count - 1];
            /**saveScores tells how many scores they want in the list if highscores has more than that then check 
             and see if a score needs replaced**/
            if (lowestScore != null && saveScores > 0 && highScores.Count >= saveScores && newScore > lowestScore.Score)
            {
                DeleteScore(lowestScore.ID);
                hsCount--;
            }
        }

        if (hsCount < saveScores)
        {
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, newScore);

                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbConnection.Close();

                }
            }
        }

    }
    private void GetScores()
    {
        highScores.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT PlayerID, Name, Score, Date FROM HighScores";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
                        
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        highScores.Sort();
    }

    private void DeleteExtraScore()
    {
        GetScores();
        if(saveScores <= highScores.Count)
        {
            int deleteCount = highScores.Count - saveScores;
            highScores.Reverse();
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    for(int i = 0; i < deleteCount; i++)
                    {
                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", highScores[i].ID);

                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                    }
                    dbConnection.Close();

                }
            }
        }
    }


}
