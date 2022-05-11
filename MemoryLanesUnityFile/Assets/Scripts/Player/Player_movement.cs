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
    public GameObject collide_check;
    public int current_tile;
    public bool puzzle_lock;

    private void Awake()
    {
        speed = 2;
        rotate_speed = 200;
        is_moving = false;
        is_rotating = false;
        our_body = this.GetComponent<Rigidbody>();
        distance = 5;
        no_move = false;
        collide_check = transform.Find("collide_check").gameObject;
        collide_check.SetActive(true);
        current_tile = 1;
        puzzle_lock = false;
    }

    private void Update()
    {
        if (!puzzle_lock)
        {
            if (Input.GetKey(KeyCode.W) && !is_moving && !no_move && !is_rotating)
            {
                is_moving = true;
                collide_check.SetActive(false);

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
                        collide_check.SetActive(true);
                    }
                }

                if (this.transform.eulerAngles.y == 90 && our_body.transform.position.z <= endgoal)
                {
                    our_body.transform.position += new Vector3(0, 0, 1 * speed * Time.deltaTime);

                    if (our_body.transform.position.z > endgoal)
                    {
                        our_body.transform.position = new Vector3(our_body.transform.position.x, our_body.transform.position.y, endgoal);
                        is_moving = false;
                        collide_check.SetActive(true);
                    }
                }

                if (this.transform.eulerAngles.y == 180 && our_body.transform.position.x <= endgoal)
                {
                    our_body.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);

                    if (our_body.transform.position.x > endgoal)
                    {
                        our_body.transform.position = new Vector3(endgoal, our_body.transform.position.y, our_body.transform.position.z);
                        is_moving = false;
                        collide_check.SetActive(true);
                    }
                }

                if (this.transform.eulerAngles.y == 270 && our_body.transform.position.z >= endgoal)
                {
                    our_body.transform.position += new Vector3(0, 0, -1 * speed * Time.deltaTime);

                    if (our_body.transform.position.z < endgoal)
                    {
                        our_body.transform.position = new Vector3(our_body.transform.position.x, our_body.transform.position.y, endgoal);
                        is_moving = false;
                        collide_check.SetActive(true);
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

                    if (rotate_direction == 1)
                    {
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
                    else if (rotate_direction == -1)
                    {
                        if (new_direction == 0)
                        {
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                        }
                        else if (new_direction == 90)
                        {
                            transform.rotation = Quaternion.Euler(0, -90, 0);
                        }
                        else if (new_direction == 180)
                        {
                            transform.rotation = Quaternion.Euler(0, -0, 0);
                        }
                        else if (new_direction == 270)
                        {
                            transform.rotation = Quaternion.Euler(0, -270, 0);
                        }

                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "FloorTile" && !collide_check.activeSelf)
        {
            current_tile = int.Parse(col.transform.name[10] + "");
        }
    }
}
