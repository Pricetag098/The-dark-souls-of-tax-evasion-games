using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public float followSpeed = 1, sensitivity = 1;
    
    public Vector3 offset;
    public Transform body;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, body.position + offset, followSpeed * Time.deltaTime);
        float angleY = -Input.GetAxisRaw("Mouse Y") * sensitivity;
        
        if (transform.rotation.eulerAngles.x + angleY > 90f && transform.rotation.eulerAngles.x + angleY < 180)
        {
            angleY = 90f - transform.rotation.eulerAngles.x;
        }
        

        if (transform.rotation.eulerAngles.x + angleY < 270 && transform.rotation.eulerAngles.x + angleY > 180)
        {
            angleY = 270 - transform.rotation.eulerAngles.x;
        }



        float angleX = Input.GetAxisRaw("Mouse X") * sensitivity;
        transform.rotation = Quaternion.Euler(angleY + transform.rotation.eulerAngles.x, angleX + transform.rotation.eulerAngles.y, 0);
    }
}
