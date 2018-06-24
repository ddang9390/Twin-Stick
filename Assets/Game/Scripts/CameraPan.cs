using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("H: " + Input.GetAxis("RHorizontal"));
        Debug.Log("V: " + Input.GetAxis("RVertical"));
    }

    private void LateUpdate()
    {
        transform.LookAt(player.transform);
    }
}
