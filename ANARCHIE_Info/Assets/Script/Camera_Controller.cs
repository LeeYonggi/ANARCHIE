using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    public float smoothness;

    private GameObject player;

	void Start () {
        player = GameObject.Find("Player");
    }
	
	void LateUpdate () {
        float Xdist = player.transform.position.x - transform.position.x;
        float Ydist = player.transform.position.y - transform.position.y;
        
        transform.Translate(new Vector2(Xdist / smoothness, Ydist / smoothness));
	}
}
