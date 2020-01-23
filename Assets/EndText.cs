using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class EndText : MonoBehaviour
{

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetScore(int score)
    {
        if (this.score != score)
        {
            GetComponentInChildren<TextMesh>().text = "Rezultāts: " + score;
            this.score = score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
