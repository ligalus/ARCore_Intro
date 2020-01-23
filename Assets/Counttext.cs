using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Counttext : MonoBehaviour
{
    private int score;

    public void SetScore(int score)
    {
        if (this.score != score)
        {
            GetComponentInChildren<TextMesh>().text = "Rezultāts: " + score;
            this.score = score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}