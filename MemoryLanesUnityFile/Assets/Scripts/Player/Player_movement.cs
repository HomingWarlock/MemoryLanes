using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    public float rotate_speed;
    public bool is_moving;
    public bool is_rotating;
    public Rigidbody our_body;
    public float distance;
    public float endgoal;
    public float rotategoal;
    public float rotate_direction;
    public int new_direction;
    public bool no_move;

    private void Awake()
    {
        speed = 2;
        rotate_speed = 200;
        is_moving = false;
        is_rotating = false;
        our_body = this.GetComponent<Rigidbody>();
        distance = 5;
        no_move = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && !is_moving && !no_move && !is_rotating)
        {
            is_moving = true;

            if (this.transform.eulerAngles.y == 0)
            {
                endgoal = our_body.transform.position.x - distance;
                new_direction = 0;
            }

            if (this.transform.eulerAngles.y == 90)
            {
                endgoal = our_body.transform.position.z + distance;
                new_direction = 90;
            }

            if (this.transform.eulerAngles.y == 180)
            {
                endgoal = our_body.transform.position.x + distance;
                new_direction = 180;
            }

            if (this.transform.eulerAngles.y == 270)
            {
                endgoal = our_body.transform.position.z - distance;
                new_direction = 270;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !is_rotating && !is_moving)
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
            is_rotating = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && !is_rotating && !is_moving)
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
            is_rotating = true;
        }

        if (is_moving)
        {
            if (this.transform.eulerAngles.y == 0 && our_body.transform.position.x >= endgoal)
            {
                our_body.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);

                if (our_body.transform.position.x < endgoal)
                {
                    our_body.transform.position = new Vector3(endgoal, our_body.transform.position.y, our_body.transform.position.z);
                    is_moving = false;
                }
            }

            if (this.transform.eulerAngles.y == 90 && our_body.transform.position.z <= endgoal)
            {
                our_body.transform.position += new Vector3(0, 0, 1 * speed * Time.deltaTime);

                if (our_body.transform.position.z > endgoal)
                {
                    our_body.transform.position = new Vector3(our_body.transform.position.x, our_body.transform.position.y, endgoal);
                    is_moving = false;
                }
            }

            if (this.transform.eulerAngles.y == 180 && our_body.transform.position.x <= endgoal)
            {
                our_body.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);

                if (our_body.transform.position.x > endgoal)
                {
                    our_body.transform.position = new Vector3(endgoal, our_body.transform.position.y, our_body.transform.position.z);
                    is_moving = false;
                }
            }

            if (this.transform.eulerAngles.y == 270 && our_body.transform.position.z >= endgoal)
            {
                our_body.transform.position += new Vector3(0, 0, -1 * speed * Time.deltaTime);

                if (our_body.transform.position.z < endgoal)
                {
                    our_body.transform.position = new Vector3(our_body.transform.position.x, our_body.transform.position.y, endgoal);
                    is_moving = false;
                }
            }
        }

        if (is_rotating)
        {
            if (rotategoal < 90)
            {
                this.transform.Rotate(0, rotate_direction, 0);
                rotategoal += 1;
            }
            else if (rotategoal >= 90)
            {
                is_rotating = false;

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
