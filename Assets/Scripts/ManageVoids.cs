using System.Collections.Generic;
using UnityEngine;

public class ManageVoids : MonoBehaviour
{
    #region Private Variables/Fields

    private const int lowerLeftLimit= 21;    

    private const int upperRightLimit = 379;

    private const int upLimit = 61;

    private const int downLimit = 338;

    private List<int> numbers = new List<int>();

    [SerializeField]
    private int numberOfVoids = 20;

    private Limits limits;    

    #endregion

    private void Awake()
    {
        limits = new Limits();

        int randomNumber = Random.Range(lowerLeftLimit, upperRightLimit);

        int numOne = DestroyFirstCube(randomNumber);

        while (numbers.Count < numberOfVoids)
        {
            int randonDestroy = Random.Range(0, 4);

            switch (randonDestroy)
            {
                case 0:
                    numOne = DestroyUp(numOne);
                    break;
                case 1:
                    numOne = DestroyDown(numOne);
                    break;
                case 2:
                    numOne = DestroyRight(numOne);
                    break;
                case 3:
                    numOne = DestroyLeft(numOne);
                    break;
                default:
                    Debug.Log("Out of bounds");
                    break;
            }
        }           
    }

    #region Destroy cubes

    // Delete a first cube.
    private int DestroyFirstCube(int number)
    {
        if (number >= lowerLeftLimit && number < upperRightLimit && number > limits.PutLeftLimit(number) && number < limits.PutRightLimit(number) && IsActive(number))
        {
            GameObject childCubes = gameObject.transform.GetChild(number).gameObject;
            AddToList(number);
            DestroyCube(childCubes);
        }

        return number;
    }    

    // Delete a cube based on the above method. Forward(3D)/Up(2D).
    private int DestroyUp(int number)
    {
        int subtractionResult;

        if (number >= lowerLeftLimit && number < upperRightLimit && number > limits.PutLeftLimit(number) && number < limits.PutRightLimit(number) && number >= upLimit)
        {
            subtractionResult = number - 40;

            if (!numbers.Contains(subtractionResult))
            {
                GameObject childCubes = gameObject.transform.GetChild(subtractionResult).gameObject;

                if (childCubes.activeInHierarchy && IsActive(subtractionResult))
                {
                    AddToList(subtractionResult);
                    DestroyCube(childCubes);
                }                
            }            
        }
        else
        {
            subtractionResult = number;
        }
        
        return subtractionResult;
    }

    // Delete a cube based on the DestroyFirstCube method. Back(3D)/Down(2D).
    private int DestroyDown(int number)
    {
        int sumResult;

        if (number >= lowerLeftLimit && number < upperRightLimit && number > limits.PutLeftLimit(number) && number < limits.PutRightLimit(number) && number <= downLimit)
        {
            sumResult = number + 40;

            if (!numbers.Contains(sumResult))
            {
                GameObject childCubes = gameObject.transform.GetChild(sumResult).gameObject;

                if (childCubes.activeInHierarchy && IsActive(sumResult))
                {
                    AddToList(sumResult);
                    DestroyCube(childCubes);
                }               
            }           
        }
        else
        {
            sumResult = number;
        }
        
        return sumResult;
    }

    // Delete a cube based on the DestroyFirstCube method. Left.
    private int DestroyLeft(int number)
    {
        int subtractionResult;

        if (number >= lowerLeftLimit && number <= upperRightLimit && number - 2 > limits.PutLeftLimit(number) && number - 2 < limits.PutRightLimit(number))
        {
            subtractionResult = number - 2;

            if(!numbers.Contains(subtractionResult))
            {
                GameObject childCubes = gameObject.transform.GetChild(subtractionResult).gameObject;

                if (childCubes.activeInHierarchy && IsActive(subtractionResult))
                {
                    AddToList(subtractionResult);
                    DestroyCube(childCubes);
                }                
            }            
        }
        else
        {
            subtractionResult = number;
        }

        return subtractionResult;
    }

    // Delete a cube based on the DestroyFirstCube method. Right.
    private int DestroyRight(int number)
    {
        int sumResult;

        if (number >= lowerLeftLimit - 1 && number <= upperRightLimit && number + 2 > limits.PutLeftLimit(number) && number + 2 < limits.PutRightLimit(number))
        {
            sumResult = number + 2;

            if (!numbers.Contains(sumResult))
            {
                GameObject childCubes = gameObject.transform.GetChild(sumResult).gameObject;

                if (childCubes.activeInHierarchy && IsActive(sumResult))
                {
                    AddToList(sumResult);
                    DestroyCube(childCubes);
                }                
            }            
        }
        else
        {
            sumResult = number;
        }

        return sumResult;
    }

    private void DestroyCube(GameObject cube)
    {
        Destroy(cube);
    }

    #endregion

    #region Positon numbers 

    // Add  deleted positions numbers to the list.
    private void AddToList(int value)
    {
        if (numbers.Count == 0)
        {
            numbers.Add(value);
        }
        else if (!numbers.Contains(value))
        {
            numbers.Add(value);
        }
    }

    #endregion

    // Check if there is a deleted cube in nearby areas (forward, backward, right and left).
    private bool IsActive(int num)
    {
        bool isAct;

        GameObject testOne = gameObject.transform.GetChild(num + 20).gameObject;
        GameObject testTwo = gameObject.transform.GetChild(num - 20).gameObject;
        GameObject testThree = gameObject.transform.GetChild(num + 1).gameObject;
        GameObject testFour = gameObject.transform.GetChild(num - 1).gameObject;

        if (testOne.activeInHierarchy && testTwo.activeInHierarchy && testThree.activeInHierarchy && testFour.activeInHierarchy)
        {
            isAct = true;
        }
        else
        {
            isAct = false;
        }

        return isAct;
    }   


    // Send numbers of deleted positions. 
    public List<int> SendDeleteValues()
    {
        numbers.Add(389);
        
        return numbers;
    }
}
