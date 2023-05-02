using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour
{
    public GameObject startOver;
    // Start is called before the first frame update
    void Start()
    {
        startOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowButton()
    {
        startOver.SetActive(true);
    }
    
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
