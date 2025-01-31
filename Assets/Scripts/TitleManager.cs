using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject[] reels;
    public float reelSpeed = 50.0f;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i< reels.Length;i++)
        {
            reels[i].transform.Rotate(-reelSpeed*Time.deltaTime,0,0);
        }        
    }

    public void TitleChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
