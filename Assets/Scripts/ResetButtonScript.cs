using UnityEngine;
using System.Collections;

public class ResetButtonScript : MonoBehaviour
{
    public tk2dClippedSprite sprite;

    // Use this for initialization
    void Start()
    {
        sprite.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        Vector3 position = new Vector3(0, (float)-0.2, 0);
        sprite.transform.localPosition = position;
    }

    public void Remove()
    {
        Vector3 position = new Vector3(20, 0, 0);
        sprite.transform.localPosition = position;
    }
}
