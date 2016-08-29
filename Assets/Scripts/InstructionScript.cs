using UnityEngine;
using System.Collections;

public class InstructionScript : MonoBehaviour
{
    static private tk2dTextMesh iTextMesh;
    static private int score;
    static public int totalScore;
    static public bool type;
    static public bool gameOver;
    private string qntype;

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
        type = true;
        iTextMesh = GetComponent<tk2dTextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (type) { qntype = "bigger"; } else { qntype = "smaller"; }
            iTextMesh.text = "Click on the " + qntype + " animal to score a point!";
            iTextMesh.Commit();
        }
        else
        {
            iTextMesh.text = "Game Over! Final Score: " + score + "/" + totalScore;
            iTextMesh.Commit();
        }
    }
}