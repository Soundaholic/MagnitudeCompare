using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
    static private tk2dTextMesh textMesh;
    static private int score;
    static public bool gameOver;

    static public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        gameOver = false;
        score = 0;
        textMesh = GetComponent<tk2dTextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textMesh.text = string.Format("Score: {0}", score);
            textMesh.Commit();
        }
        else
        {
            textMesh.text = string.Format("");
            textMesh.Commit();
        }
    }
}