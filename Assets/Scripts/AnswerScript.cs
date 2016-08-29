using UnityEngine;
using System.Collections;

public class AnswerScript : MonoBehaviour
{
    public tk2dClippedSprite sprite;

    public float size;
    public bool answer;
    public int series;

	// Use this for initialization
	void Start () {
        Bounds bounds = sprite.GetUntrimmedBounds();
        size = bounds.max.y - bounds.min.y;
        //Debug.Log("size: " + size);

        sprite.gameObject.SetActive(true);

        //MainGameScript.Instance.RegisterAnswer(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Register(bool left)
    {
        Vector3 position = new Vector3(2, (float)-0.9, 0);
        if (left) { position = new Vector3(-2, (float)-0.9, 0); } 
        MainGameScript.Instance.RegisterAnswer(this);
        sprite.transform.localPosition = position;
    }

    public void Remove()
    {
        Vector3 position = new Vector3(20, 0, 0);
        sprite.transform.localPosition = position;
    }

    public bool SelectAnswer()
    {
        return answer;
    }
}
