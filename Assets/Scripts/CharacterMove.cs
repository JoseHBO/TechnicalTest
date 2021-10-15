using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    #region Private variables/fields

    [SerializeField]
    private float maxSpeed = 2.5f;

    [SerializeField]
    private float speed = 1.2f;

    [SerializeField]
    private float rotateSpeedModifier = -5f;

    private Rigidbody rigBod;

    private float horMovNeg;

    private float horMovPos;

    private float horMov;

    private float verMov;

    private float verMovNeg;

    private float verMovPos;   

    Vector3 initialPosition = new Vector3(9.5f, 0.7f, -19.5f);

    Vector3 position;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();

        transform.position = initialPosition;
    }

    private void Update()
    {
        Quaternion rotateY = Quaternion.Euler(0.0f, rotateSpeedModifier, 0f);

        transform.rotation = rotateY * transform.rotation;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            horMovNeg -= speed * Time.fixedDeltaTime; 

            horMov = Mathf.Clamp(horMovNeg, -maxSpeed, 0f); 

            verMov = 0;

            Move();
        }
        else
        {
            horMov = 0f;
        }
        if (Input.GetKey("d"))
        {
            horMovPos += speed * Time.fixedDeltaTime;

            horMov =  Mathf.Clamp(horMovPos, 0f, maxSpeed);

            verMov = 0;

            Move();
        }
        else
        {
            horMov = 0f;
        }
        if (Input.GetKey("w"))
        {
            verMovPos  += speed * Time.fixedDeltaTime;

            verMov = Mathf.Clamp(verMovPos, 0f, maxSpeed);

            horMov = 0;

            Move();
        }      
        if (Input.GetKey("s"))
        {
            verMovNeg -= speed * Time.fixedDeltaTime;

            verMov = Mathf.Clamp(verMovNeg, -maxSpeed, 0f);

            horMov = 0;

            Move();
        }
    }

    private void Move()
    {
        position = new Vector3(horMov, rigBod.velocity.y, verMov);

        rigBod.velocity = position;
    }

}
