using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGameScript : MonoBehaviour
{
    private AnswerScript[] answersq;
    private List<AnswerScript> answersbig = new List<AnswerScript>();
    private List<AnswerScript> answerssmall = new List<AnswerScript>();
    private List<AnswerScript> answers = new List<AnswerScript>();
    private ResetButtonScript[] resetButtonList;
    private ResetButtonScript resetButton;
    private int score;
    private int counter;
    private int total;
    private bool type;
    private bool position;
    public AudioClip correctans;
    public AudioClip wrongans;

    public Camera gamecam;

    private static MainGameScript instance;

    public static MainGameScript Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("MainGame instance does not exist");
            }
            return instance;
        }
    }

    public void RegisterAnswer(AnswerScript who)
    {
        answers.Add(who);
        //Debug.Log("New Answer Added!");
    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Initialising");
        resetButtonList = FindObjectsOfType(typeof(ResetButtonScript)) as ResetButtonScript[];
        resetButton = resetButtonList[0];
        resetButton.Remove();

        answersq = FindObjectsOfType(typeof(AnswerScript)) as AnswerScript[];
        total = answersq.Length;

        Debug.Log("Total no. of answers: " + total);
        
        //randomising the order
        for (int i = total - 1; i > 0; i--)
        {
            int j = Random.Range(0, i);
            AnswerScript temp = answersq[i];
            answersq[i] = answersq[j];
            answersq[j] = temp;
        }
        Debug.Log("Answers List randomised");

        for (int i = 0; i < total; i++)
        {
            if (answersq[i].answer)
            {
                answersbig.Add(answersq[i]);
            }
            else
            {
                answerssmall.Add(answersq[i]);
            }
        }

        counter = 0;
        total = total / 2;
        position = true;

        //randomising position
        if (Random.Range(0, 99) < 50) { position = !position;}
        answersbig[counter].Register(position);
        answerssmall[counter].Register(!position);
      
        if (Random.Range(0, 99) < 50) { type = true; InstructionScript.type = true; } else { type = false; InstructionScript.type = false; }
    }

    void Reset()
    {
        Debug.Log("Reseting");
        resetButton.Remove();

        ScoreScript.Score = 0;
        ScoreScript.gameOver = false;
        InstructionScript.gameOver = false;

        answersq = FindObjectsOfType(typeof(AnswerScript)) as AnswerScript[];
        total = answersq.Length;

        //randomising the order
        for (int i = total - 1; i > 0; i--)
        {
            int j = Random.Range(0, i);
            AnswerScript temp = answersq[i];
            answersq[i] = answersq[j];
            answersq[j] = temp;
        }
        Debug.Log("Answers List randomised");

        answersbig.Clear();
        answerssmall.Clear();

        for (int i = 0; i < total; i++)
        {
            if (answersq[i].answer)
            {
                answersbig.Add(answersq[i]);
            }
            else
            {
                answerssmall.Add(answersq[i]);
            }
        }

        counter = 0;
        total = total / 2;

        //randomising position
        if (Random.Range(0, 99) < 50) { position = !position; }
        answersbig[counter].Register(position);
        answerssmall[counter].Register(!position);

        if (Random.Range(0, 99) < 50) { type = true; InstructionScript.type = true; } else { type = false; InstructionScript.type = false; }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Click Registered");
            Ray ray = gamecam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Hit Registered");
                foreach (AnswerScript answer in answers)
                {
                    if(answer.sprite.transform == hit.transform) { 
                        if ((answer.SelectAnswer() && type) || (!answer.SelectAnswer() && !type))
                        {
                            AudioSource.PlayClipAtPoint(correctans, new Vector3());
                            //Debug.Log("Answer is correct!");
                            ScoreScript.Score += 1;
                        }
                        else
                        {
                            AudioSource.PlayClipAtPoint(wrongans, new Vector3());
                            //Debug.Log("Answer is wrong!");
                        }

                        if (counter < total - 1)
                        {
                            //removing current answers
                            answers.Clear();
                            answersbig[counter].Remove();
                            answerssmall[counter].Remove();
                            counter++;

                            //moving in new answers     
                            if (Random.Range(0, 9) < 5) { position = !position; }
                            answersbig[counter].Register(position);
                            answerssmall[counter].Register(!position);
                            //Debug.Log("New Answers moved in!");

                            if (Random.Range(0, 9) < 5) { type = true; InstructionScript.type = true; } else { type = false; InstructionScript.type = false; }
                        }
                        else
                        {
                            //removing current answers
                            answers.Clear();
                            answersbig[counter].Remove();
                            answerssmall[counter].Remove();
                            ScoreScript.gameOver = true;
                            InstructionScript.Score = ScoreScript.Score;
                            InstructionScript.totalScore = total;
                            InstructionScript.gameOver = true;
                            resetButton.Move();
                            Debug.Log("End of Quiz");
                        }
                        break;
                    }
                }
                Debug.Log((total - counter) + " more qns");

                if (resetButton.sprite.transform == hit.transform)
                {
                    Reset();
                }
            }
            else
            {
                //Debug.Log("Hit Not Registered!");
            }
        }
	}
}
