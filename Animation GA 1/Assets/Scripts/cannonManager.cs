using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonManager : MonoBehaviour
{
    public GameObject[] cannonBall;
    public ParticleSystem particle;
    public int num = 0;
    public float shootforce = 0.0f;
    public GameObject cannonBoom;
    bool start;
    bool recoil;
    public Vector3 position;
    public Vector3 originalPosition;
    public Vector2 mouseRotation;
    public float sensitivity = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        recoil = false;
        originalPosition = this.transform.localPosition;
        position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z - 1f);
        mouseRotation.Set(0f, -60f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        mouseRotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        if (mouseRotation.y < -100f)
        {
            mouseRotation.y = -100f;
        }
        if (mouseRotation.y > -40f)
        {
            mouseRotation.y = -40f;
        }
        if (mouseRotation.x < -50f)
        {
            mouseRotation.x = -50f;
        }
        if (mouseRotation.x > 50f)
        {
            mouseRotation.x = 50f;
        }


        transform.localRotation = Quaternion.Euler(-mouseRotation.y, mouseRotation.x, 0);
        if (recoil)
        {
            position = new Vector3(position.x, position.y, position.z + 0.1f);
            this.transform.localPosition = position;
            if (this.transform.localPosition.z >= originalPosition.z)
            {
                position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z - 1f);
                recoil = false;
            }
        }
        else
        {
        }
        if (start)
        {
            float cannon = cannonBoom.transform.localPosition.y + 0.15f;
            //Debug.Log(cannon);
            cannonBoom.transform.localPosition = new Vector3(cannonBoom.transform.localPosition.x, cannon, cannonBoom.transform.localPosition.z);

            if (cannon > 1.0f)
            {
                particle.Play();
                GameObject ball = (GameObject)Instantiate(cannonBall[num], transform.position, transform.rotation);
                ball.GetComponent<Rigidbody>().AddForce(ball.transform.up * shootforce);
                cannon = -1f;
                cannonBoom.transform.localPosition = new Vector3(cannonBoom.transform.localPosition.x, cannon, cannonBoom.transform.localPosition.z);
                start = false;
                recoil = true;
                this.transform.localPosition = position;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
            {
                start = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
        {
            num++;
            if(num >= cannonBall.Length)
            {
                num = 0;
            }
        }
    }
}
