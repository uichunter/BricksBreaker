using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted=false;
    private Vector3 paddleToBallVector;
    private GravityController gravityController;
	// Use this for initialization
	void Start () {
        
        paddle = GameObject.FindObjectOfType<Paddle>();
        gravityController = GameObject.FindObjectOfType<GravityController>();

	    paddleToBallVector = this.transform.position-paddle.transform.position;
        this.GetComponent<Rigidbody2D>().gravityScale = gravityController.gravitySender;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }

        if (Input.GetMouseButtonDown(0))
        {
            hasStarted=true;
            //Debug.Log(this.transform.position);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,18f);
        }

        if(hasStarted && Input.GetMouseButtonDown(1)){
            hasStarted = false;
        }

	}

    void OnCollisionEnter2D(Collision2D collisiion)
    {
        Vector2 tweak = new Vector2(Random.Range(0f,1f),Random.Range(0f,1f));

        if (hasStarted)
        {
            GetComponent<Rigidbody2D>().velocity +=tweak;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
