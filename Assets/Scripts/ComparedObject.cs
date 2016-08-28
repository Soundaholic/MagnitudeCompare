using UnityEngine;
using System.Collections;

public class ComparedObject : MonoBehaviour
{
    public tk2dSprite sprite;

    public float size;
    bool selected;

	// Use this for initialization
	void Start () {
        Bounds bounds = sprite.GetUntrimmedBounds();
        size = bounds.max.y - bounds.min.y;

        sprite.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float selectCompare()
    {
        return size;
    }
}
