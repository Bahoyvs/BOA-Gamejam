using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trigger2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if(condition)
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(6.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}