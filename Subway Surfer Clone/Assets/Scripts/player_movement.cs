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

    private bool movingLeft = false;
    private bool movingRight = false;
    void Start()
    {
        player.transform.position = new Vector3(0, 1, 0);
        Debug.Log("Start");
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
            //player.transform.position += new Vector3(-5, 0, 0);
            Debug.Log("move left");
        }
        if(Input.GetKeyDown(rightKey) && player.transform.position.x < 4)
        {
            //player.transform.position += new Vector3(5, 0, 0);
            player.transform.position = Vector3.Lerp (player.transform.position, new Vector3(player.transform.position.x + 5, player.transform.position.y, player.transform.position.z), 1f);
            Debug.Log("move right");
        }
        /*while(player.transform.position.x != 5f && movingLeft)
        {
            Debug.Log("moving automatically");
            player.transform.position = Vector3.Lerp (player.transform.position, new Vector3(-5, player.transform.position.y, player.transform.position.z), 0.1f);
        }*/

    }
}
