using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Onomatopeya : MonoBehaviour
{
    OnomatopeyaText onomaTex;

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        onomaTex = new OnomatopeyaText();

        text.text = onomaTex.Text;
    }  
}
