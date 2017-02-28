using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 6.0F;
    public bool sprint = false;
    public Collider other;
    public string playerNumber;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical" + playerNumber) * speed;
        float horizontalMovement = Input.GetAxis("Horizontal" + playerNumber) * speed;
        //transform.Translate(horizontalMovement, 0, verticalMovement);
        Vector3 movement = new Vector3(horizontalMovement,0,verticalMovement);
        transform.Translate(movement * speed * Time.deltaTime);
        //if (movement.magnitude > 0.05f)
        //{
        //    transform.LookAt(transform.position + movement);
        //}

        //ROTATION
        /*float xLook = Input.GetAxis("RightStickX");
        float yLook = Input.GetAxis("RightStickY");

        float heading = Mathf.Atan2(xLook, yLook);
        GetComponent<Transform>().eulerAngles = new Vector3(0, heading*Mathf.Rad2Deg, 0);
        Quaternion eulerRot = Quaternion.Euler(0.0f, heading*Mathf.Rad2Deg, 0.0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, eulerRot, Time.deltaTime * 100);
        */

        //Lock the cursor
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

