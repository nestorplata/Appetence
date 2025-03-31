using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer Cutscene;
    private IEnumerator coroutine;
    public float AdditionalTime= 0.0f;
    public LevelLoader LevelLoader;
    public string LevelToLoad = "Family";


    private void Start()
    {
        coroutine = ChangeScene((float)Cutscene.length+ AdditionalTime);
        StartCoroutine(coroutine);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {

        SceneManager.LoadScene(LevelToLoad);
    }

    private IEnumerator ChangeScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("Change Scene to "+ LevelToLoad);
        ChangeScene();

    }

}
