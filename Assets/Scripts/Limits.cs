using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits 
{
    // Set limits so it doesn't erase edge cubes.
    public int PutLeftLimit(int value)
    {
        int lowerLimit;

        if (value < 100)
        {
            string valueTex = value.ToString();

            char firstValueCha = valueTex[0];

            lowerLimit = (int)char.GetNumericValue(firstValueCha);

            if (lowerLimit % 2 != 0)
            {
                lowerLimit -= 1;
            }

            lowerLimit *= 10;
        }

        else
        {
            string valueTex = value.ToString();

            char firstValueCha = valueTex[0];

            char secondValueCha = valueTex[1];

            string sumChar = firstValueCha.ToString() + secondValueCha;

            lowerLimit = int.Parse(sumChar);

            if (lowerLimit % 2 != 0)
            {
                lowerLimit -= 1;
            }

            lowerLimit *= 10;
        }

        return lowerLimit;
    }

    // Set limits so it doesn't erase edge cubes.
    public int PutRightLimit(int value)
    {
        int upperLim;

        upperLim = PutLeftLimit(value) + 19;

        return upperLim;
    }
}
