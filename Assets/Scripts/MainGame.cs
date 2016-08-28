using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour
{
    private List<ComparedObject> objects = new List<ComparedObject>();
    private int score;

    public Camera gamecam;

    private static MainGame instance;

    public static MainGame Instance
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

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = gamecam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                
            }
        }
	}
}
