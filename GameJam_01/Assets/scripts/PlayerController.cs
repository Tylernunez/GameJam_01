using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 6.0F;
    public bool sprint = false;
    public Collider other;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical") * speed;
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        verticalMovement *= Time.deltaTime;
        horizontalMovement *= Time.deltaTime;

        float angleH = Input.GetAxis("RightH") * 10;
        transform.localEulerAngles = new Vector3(0, angleH, 0);

        transform.Translate(horizontalMovement, 0, verticalMovement);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        //Constantly checking if the collider is a player
        if(Input.GetButtonDown("Fire1"))
        {
            attack();
        } 
    }
    private void OnTriggerEnter(Collider col)
    {
        //Target is in range to be attacked
        other = col;
    }
    private void OnTriggerExit(Collider col)
    {
        //Target is not in range to be attacked
        other = null;
    }
    public void attack()
    {
        if (other != null)
        {
            if (other.transform.parent.tag != null)
            {
                if (other.transform.parent.tag == "Player")
                {
                    //Should check the collider tag to see if the collider is the armor or vulnerability
                    if (other.gameObject.tag == "Armor")
                    {
                        Debug.Log("You hit armor!");
                    }
                    if (other.gameObject.tag == "Weakness")
                    {
                        Debug.Log("You hit the weak point!");
                    }
                }
            }
            
        }
        
    }
    
      
    

}

