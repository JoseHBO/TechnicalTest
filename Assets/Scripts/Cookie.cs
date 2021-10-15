using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    [SerializeField]
    private GameObject onoma;

    private CookiesManager cookiesManager;    

    public delegate void AddCookie();

    public static event AddCookie addCookie;

    private void Start()
    {
        cookiesManager = GameObject.FindWithTag("CookiesManager").GetComponent<CookiesManager>();        

        Quaternion rotateY = Quaternion.Euler(0.0f, 0f, 90f);

        transform.rotation = rotateY * transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            if (addCookie != null)
            {
                addCookie();
            }

            GameObject onomaGameObj = Instantiate(onoma, transform.position, Quaternion.identity);

            cookiesManager.RemoveCookies();

            Destroy(gameObject);

            Destroy(onomaGameObj, 1f);
        }
        
    }    

    private void Update()
    {
        Quaternion rotateY = Quaternion.Euler(0.0f, 6f, 0f);

        transform.rotation = rotateY * transform.rotation;
    }   
}
