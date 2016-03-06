using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
    public float mousePoInBlock;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector2 paddlePos = new Vector2(8f, 1.5f);
        mousePoInBlock = Input.mousePosition.x / Screen.width * 16;
 
        paddlePos.x = Mathf.Clamp(mousePoInBlock,1.665f,14.344f);
        this.transform.position = paddlePos;
	}
}
