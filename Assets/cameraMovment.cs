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

        if (Input.mousePosition.x > screenWidth - Boundary)
            camPos.x += speed * Time.deltaTime;
        else if (Input.mousePosition.x < Boundary)
            camPos.x -= speed * Time.deltaTime;

        if (Input.mousePosition.y > screenHeight - Boundary)
            camPos.z += speed * Time.deltaTime;
        else if (Input.mousePosition.y < Boundary)
            camPos.z -= speed * Time.deltaTime;

        while(Input.GetMouseButtonDown(2))
        {
            float h = speed * Input.GetAxisRaw("Mouse Y");
            float V = speed * Input.GetAxisRaw("Mouse X");
            transform.Translate(V, h, 0);
        }

        transform.position = camPos;

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            //FOV.fieldOfView -= 5;
            transform.position = new Vector3(transform.position.x, transform.position.y + -1f, transform.position.z);
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            //FOV.fieldOfView += 5;
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }
    }
}
