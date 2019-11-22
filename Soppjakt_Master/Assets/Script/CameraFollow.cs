using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform Player;
    public Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = distance + Player.transform.position;
    }
}