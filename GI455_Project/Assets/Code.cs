using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{

    [SerializeField] string[] animeName;
   
 

    public void ButtonControls()
    {
        GameObject Search = GameObject.Find("SearchField");
        InputField animeNameSearch = Search.GetComponent<InputField>();
        string PlayerSearch = animeNameSearch.text;

        GameObject found = GameObject.Find("Check");
       


        for (int i = 0;i < animeName.Length;i++)
        {
            if (animeName[i] == PlayerSearch)
            {
                found.GetComponent<Text>().text = PlayerSearch + " Found";
                found.GetComponent<Text>().color = Color.green;
                break;
            }
            
            else
            {
                found.GetComponent<Text>().text = PlayerSearch +" not Found";
                found.GetComponent<Text>().color = Color.red;
            }

        }
    }

}
