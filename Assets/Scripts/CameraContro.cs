using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContro : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float smoothed = 3f;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position + offset;

        transform.position = Vector3.Lerp(transform.position, target, smoothed * Time.deltaTime);
    }
}