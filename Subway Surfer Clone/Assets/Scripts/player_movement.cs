using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player = null;
    public int speed = 10;
    public KeyCode leftKey;
    public KeyCode rightKey;
    void Start()
    {
        player.transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
        moveLateral();
    }
    void moveForward()
    {
        player.transform.position += new Vector3(0, 0, speed*Time.deltaTime);
        //Debug.Log("moving Forward");
    }
    void moveLateral()
    {
        if(Input.GetKeyDown(leftKey) && player.transform.position.x > -4) 
        // for future reference, if we add smooth transition change these values
        {
            player.transform.position += new Vector3(-5, 0, 0);
            Debug.Log("move left");
        }
        if(Input.GetKeyDown(rightKey) && player.transform.position.x < 4)
        {
            player.transform.position += new Vector3(5, 0, 0);
            Debug.Log("move right");
        }
    }
}
