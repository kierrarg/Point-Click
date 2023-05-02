using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullseye : MonoBehaviour
{
    public GameManager g;
    // Start is called before the first frame update
    void Start()
    {
        // finding object and getting it's attached script
        g = GameObject.Find("GameManager").GetComponent<GameManager>();
        // destroy if not clicked
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // destroy object once clicked
    void OnMouseDown()
    {
        g.IncreaseScore();
        Destroy(gameObject);
    }
}
