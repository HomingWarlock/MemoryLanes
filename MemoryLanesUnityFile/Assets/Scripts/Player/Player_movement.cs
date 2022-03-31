using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed;
    public bool IsMoving;
    public Rigidbody OurBody;
    public float distance;
    public float endgoal;
    public bool noMove;

    private void Awake()
    {
        speed = 2;
        IsMoving = false;
        OurBody = this.GetComponent<Rigidbody>();
        distance = 5;
        noMove = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && !IsMoving && !noMove)
        {
            IsMoving = true;

            if (this.transform.eulerAngles.y == 0)
            {
                endgoal = OurBody.transform.position.x - distance;
            }
            
            if (this.transform.eulerAngles.y == 90)
            {
                endgoal = OurBody.transform.position.z + distance;
            }
            
            if (this.transform.eulerAngles.y == 180)
            {
                endgoal = OurBody.transform.position.x + distance;
            }
            
            if (this.transform.eulerAngles.y == 270)
            {
                endgoal = OurBody.transform.position.z - distance;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !IsMoving)
        {
            transform.Rotate(0, -90, 0);
        }

        if (Input.GetKeyDown(KeyCode.D) && !IsMoving)
        {
            transform.Rotate(0, 90, 0);
        }

        if (IsMoving)
        {
            if (this.transform.eulerAngles.y == 0 && OurBody.transform.position.x >= endgoal)
            {
                OurBody.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);

                if (OurBody.transform.position.x <= endgoal)
                {
                    IsMoving = false;
                }
            }
            
            if (this.transform.eulerAngles.y == 90 && OurBody.transform.position.z <= endgoal)
            {
                OurBody.transform.position += new Vector3(0, 0, 1 * speed * Time.deltaTime);
                
                if (OurBody.transform.position.z >= endgoal)
                {
                    IsMoving = false;
                }
            }
            
            if (this.transform.eulerAngles.y == 180 && OurBody.transform.position.x <= endgoal)
            {
                OurBody.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);

                if (OurBody.transform.position.x >= endgoal)
                {
                    IsMoving = false;
                }
            }
            
            if (this.transform.eulerAngles.y == 270 && OurBody.transform.position.z >= endgoal)
            {
                OurBody.transform.position += new Vector3(0, 0, -1 * speed * Time.deltaTime);

                if (OurBody.transform.position.z <= endgoal)
                {
                    IsMoving = false;
                }
            }
        }
    }
        
}
