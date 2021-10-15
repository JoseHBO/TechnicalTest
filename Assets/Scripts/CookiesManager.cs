using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookiesManager : MonoBehaviour
{
    #region Private variables/fields

    [SerializeField]
    private Text coolkieText;

    [SerializeField]
    private GameObject cookieGamObj;

    [SerializeField]
    private GameObject cubes;

    private List<GameObject> storedcookies = new List<GameObject>();

    private List<int> eliminatedPositions = new List<int>();

    private List<int> availablePositions = new List<int>();

    private List<int> newPositions = new List<int>();

    private ManageVoids manageVoids;

    private int numberOfCookies = 30;    

    private int cookies = 0;

    #endregion

    #region Private methods

    private void Start()
    {
        manageVoids = cubes.GetComponent<ManageVoids>();

        // Get a list with the deleted position cubes.
        eliminatedPositions = manageVoids.SendDeleteValues();

        SetAvailablePositions();

        AddCookies();       
    }

    // Update is called once per frame
    void Update()
    {
        coolkieText.text = "Cookies: " + cookies.ToString();

        ControlQuantityCookies();   
    }       

    // Fill list with deleted cube positions.
    private void SetAvailablePositions()
    {
        while (availablePositions.Count < numberOfCookies)
        {
            int randomNumber = Random.Range(0, cubes.transform.childCount);

            if (!eliminatedPositions.Contains(randomNumber))
            {
                availablePositions.Add(randomNumber);
            }
        }
    }

    // Instantiate and add cookies to a list in available positions.
    private void AddCookies()
    {
        for (int i = 0; i < availablePositions.Count; i++)
        {
            Transform cubePosition = cubes.transform.GetChild(availablePositions[i]).transform;

            Vector3 prefabPosition = new Vector3(cubePosition.position.x, cubePosition.position.y + 1, cubePosition.position.z);

            GameObject cookiePrefab = Instantiate(cookieGamObj, prefabPosition, Quaternion.identity);

            AddCookiesToList(cookiePrefab);
        }        
    }

    // Check if there are thirty cookies.
    private void ControlQuantityCookies()
    {
        if (storedcookies.Count < numberOfCookies)
        {
            int randomNumber = Random.Range(0, cubes.transform.childCount);

            if (!eliminatedPositions.Contains(randomNumber)  && !availablePositions.Contains(randomNumber) && !newPositions.Contains(randomNumber))
            {
                newPositions.Add(randomNumber);

                SpawnNewCookie();
            }           
        }
    }     
        
    // Cookie Instantiate in new positions.
    private void SpawnNewCookie()
    {
        Transform cubePosition = cubes.transform.GetChild(newPositions[newPositions.Count - 1]).transform;

        Vector3 prefabPosition = new Vector3(cubePosition.position.x, cubePosition.position.y + 1, cubePosition.position.z);

        GameObject cookiePrefab = Instantiate(cookieGamObj, prefabPosition, Quaternion.identity);        

        AddCookiesToList(cookiePrefab);
    }

    private void AddCookiesToList(GameObject cookies)
    {
        storedcookies.Add(cookies);
    }

    private void AddCook()
    {
        ++cookies;
    }

    private void OnEnable()
    {
        Cookie.addCookie += AddCook;
    }

    private void OnDisable()
    {
        Cookie.addCookie -= AddCook;
    }

    #endregion

    #region Public methods

    public void RemoveCookies()
    {
        storedcookies.RemoveAt(0);
    }

    public int Getcookies()
    {
        return cookies;
    }

    #endregion
}
