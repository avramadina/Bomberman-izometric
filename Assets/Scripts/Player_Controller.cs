
using UnityEngine;
using System.Collections;
using System;

public class Player_Controller : Controller
{

    private string FireAxis = "Fire 1";

    public bool canDropBombs = true;
    
    public bool canMove = true;

    public GameObject bombPrefab;

    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;
    private Player player;
    private bool mobile;


  
    void Start ()
    {
	     if (Application.CanStreamedLevelBeLoaded("Game"))
     {
		mobile = false;
	 } else {
		mobile = true;
	
	 }

        player = GetComponent<Player>();
     
        rigidBody = GetComponent<Rigidbody> ();
        myTransform = transform;
        animator = myTransform.Find ("PlayerModel").GetComponent<Animator> ();
    }

  
    void Update ()
    {
        UpdateMovement ();
    }

    
    private void UpdateMovement ()
    {
        animator.SetBool ("Walking", false);
        UpdatePlayer2Movement ();
    }

   
    private void UpdatePlayer2Movement ()
    {
    
    if (Input.GetButton("Up"))
       
        { //Up
     
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, player.moveSpeed);
            myTransform.rotation = Quaternion.Euler (0, 0, 0);
            animator.SetBool ("Walking", true);
        }

        if (Input.GetButton("Left"))
        { //Left
            rigidBody.velocity = new Vector3 (-player.moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler (0, 270, 0);
            animator.SetBool ("Walking", true);
        }

        if (Input.GetButton("Down"))
        { //Down 
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -player.moveSpeed);
            myTransform.rotation = Quaternion.Euler (0, 180, 0);
            animator.SetBool ("Walking", true);
        }

        if (Input.GetButton("Right"))
        { //Right
            rigidBody.velocity = new Vector3 (player.moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler (0, 90, 0);
            animator.SetBool ("Walking", true);
        }

        if(mobile){
        Vector3 vel = new Vector3 (Input.GetAxis("Horizontal")*player.moveSpeed, rigidBody.velocity.y, Input.GetAxis("Vertical")*player.moveSpeed);
        if(vel != rigidBody.velocity){
        rigidBody.velocity = vel;
         myTransform.rotation = Quaternion.Euler (0, FindDegree(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical")), 0);
            animator.SetBool ("Walking", true);
        }
        }
        
        
      
        
        

        if (canDropBombs && (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return) || Input.GetButtonDown("Submit")))
        { 
            DropBomb ();
        }
    }

     public static float FindDegree(float x, float y){
     float value = (float)((Mathf.Atan2(x, y) / Math.PI) * 180f);
     if(value < 0) value += 360f;
 
     return value;
 }


    public void DropBomb ()
    {
         if(player.bombs != 0){

           player.bombs--;

        if (bombPrefab)
        { 
       GameObject go = Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x), 
        bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)),
        bombPrefab.transform.rotation);

        go.GetComponent<Bomb>().explode_size = player.explosion_power;
        go.GetComponent<Bomb>().player = player;
        if(player.canKick){
        go.GetComponent<Rigidbody>().isKinematic = false; // make bomb kickable
        }
        }
        }
    }
}
