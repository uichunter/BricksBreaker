using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {
    private LvManager lvManager;

	void OnTriggerEnter2D (Collider2D collider){
		//print("Trigger activated");
        lvManager.LvLoader("Lose");

	}

	void OnCollisionEnter2D (Collision2D Collision){
		print("Collision activated");
	}

    void Start()
    {
        lvManager = GameObject.FindObjectOfType<LvManager>();
    }


}
