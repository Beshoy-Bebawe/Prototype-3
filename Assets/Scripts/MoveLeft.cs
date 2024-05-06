using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float speed = 20;
    private float dashSpeed =40;
    private float leftBound = -15;
    // Declarration of leftBound Postition for if statment to destroy gameobject out of bounds
    // Start is called before the first frame update
    void Start()
    {
        
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            if (playerControllerScript.OnDash == true)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * dashSpeed);
                }else {
                     transform.Translate(Vector3.left * Time.deltaTime * speed);
                }

           


                

        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        //if the place of the object is greater then the left bound delcared and the object's tag is an obstacle then
        //destory game object 
        {

            Destroy(gameObject);
        }
    }
}
