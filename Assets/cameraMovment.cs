using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovment : MonoBehaviour {

    public int Boundary = 50;
    public float speed = 5;

    int screenWidth = Screen.width;
    int screenHeight = Screen.height;
    Camera FOV;
    Vector3 camPos;

    private void Awake()
    {
        FOV = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update ()
    {
        camPos = transform.position;

        if (!Input.GetMouseButton(2))
        {
            if (Input.mousePosition.x > screenWidth - Boundary && transform.position.x < 25f)
                camPos.x += speed * Time.deltaTime;
            else if (Input.mousePosition.x < Boundary && transform.position.x > -25f)
                camPos.x -= speed * Time.deltaTime;

            if (Input.mousePosition.y > screenHeight - Boundary && transform.position.y < 25f)
                camPos.z += speed * Time.deltaTime;
            else if (Input.mousePosition.y < Boundary && transform.position.y > -25f)
                camPos.z -= speed * Time.deltaTime;
        }

        if(Input.GetMouseButton(2))
        {
            mousemove();
        }

        transform.position = camPos;

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && transform.position.y > 5)
        {
            //FOV.fieldOfView -= 5;
            transform.position = new Vector3(transform.position.x, transform.position.y + -1f, transform.position.z);
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0 && transform.position.y < 40)
        {
            //FOV.fieldOfView += 5;
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }
    }

    void mousemove()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");
        camPos += transform.right * (x * -1) * Time.deltaTime * speed * 2;
        camPos += transform.up * (y * -1) * Time.deltaTime * speed * 2;
    }
}
