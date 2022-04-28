using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed;
    public float rotate_speed;
    public bool IsMoving;
    public bool IsRotating;
    public Rigidbody OurBody;
    public float distance;
    public float endgoal;
    public float rotategoal;
    public float rotate_direction;
    public int new_direction;
    public bool noMove;

    private void Awake()
    {
        speed = 2;
        rotate_speed = 200;
        IsMoving = false;
        IsRotating = false;
        OurBody = this.GetComponent<Rigidbody>();
        distance = 5;
        noMove = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && !IsMoving && !noMove && !IsRotating)
        {
            IsMoving = true;

            if (this.transform.eulerAngles.y == 0)
            {
                endgoal = OurBody.transform.position.x - distance;
                new_direction = 0;
            }

            if (this.transform.eulerAngles.y == 90)
            {
                endgoal = OurBody.transform.position.z + distance;
                new_direction = 90;
            }

            if (this.transform.eulerAngles.y == 180)
            {
                endgoal = OurBody.transform.position.x + distance;
                new_direction = 180;
            }

            if (this.transform.eulerAngles.y == 270)
            {
                endgoal = OurBody.transform.position.z - distance;
                new_direction = 270;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !IsRotating && !IsMoving)
        {
            if (this.transform.eulerAngles.y == 0)
            {
                new_direction = -90;
            }

            if (this.transform.eulerAngles.y == -90)
            {
                new_direction = -180;
            }

            if (this.transform.eulerAngles.y == -180)
            {
                new_direction = -270;
            }

            if (this.transform.eulerAngles.y == -270)
            {
                new_direction = -0;
            }

            rotategoal = 0;
            rotate_direction = -1;
            IsRotating = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && !IsRotating && !IsMoving)
        {
            if (this.transform.eulerAngles.y == 0)
            {
                new_direction = 90;
            }

            if (this.transform.eulerAngles.y == 90)
            {
                new_direction = 180;
            }

            if (this.transform.eulerAngles.y == 180)
            {
                new_direction = 270;
            }

            if (this.transform.eulerAngles.y == 270)
            {
                new_direction = 0;
            }

            rotategoal = 0;
            rotate_direction = 1;
            IsRotating = true;
        }

        if (IsMoving)
        {
            if (this.transform.eulerAngles.y == 0 && OurBody.transform.position.x >= endgoal)
            {
                OurBody.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);

                if (OurBody.transform.position.x < endgoal)
                {
                    OurBody.transform.position = new Vector3(endgoal, OurBody.transform.position.y, OurBody.transform.position.z);
                    IsMoving = false;
                }
            }

            if (this.transform.eulerAngles.y == 90 && OurBody.transform.position.z <= endgoal)
            {
                OurBody.transform.position += new Vector3(0, 0, 1 * speed * Time.deltaTime);

                if (OurBody.transform.position.z > endgoal)
                {
                    OurBody.transform.position = new Vector3(OurBody.transform.position.x, OurBody.transform.position.y, endgoal);
                    IsMoving = false;
                }
            }

            if (this.transform.eulerAngles.y == 180 && OurBody.transform.position.x <= endgoal)
            {
                OurBody.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);

                if (OurBody.transform.position.x > endgoal)
                {
                    OurBody.transform.position = new Vector3(endgoal, OurBody.transform.position.y, OurBody.transform.position.z);
                    IsMoving = false;
                }
            }

            if (this.transform.eulerAngles.y == 270 && OurBody.transform.position.z >= endgoal)
            {
                OurBody.transform.position += new Vector3(0, 0, -1 * speed * Time.deltaTime);

                if (OurBody.transform.position.z < endgoal)
                {
                    OurBody.transform.position = new Vector3(OurBody.transform.position.x, OurBody.transform.position.y, endgoal);
                    IsMoving = false;
                }
            }
        }

        if (IsRotating)
        {
            if (rotategoal < 90)
            {
                this.transform.Rotate(0, rotate_direction, 0);
                rotategoal += 1;
            }
            else if (rotategoal >= 90)
            {
                IsRotating = false;

                if (new_direction == 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (new_direction == 90)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else if (new_direction == 180)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (new_direction == 270)
                {
                    transform.rotation = Quaternion.Euler(0, 270, 0);
                }
            }
        }
    }
}
