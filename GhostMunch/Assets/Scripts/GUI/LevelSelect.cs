using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelSelect : MonoBehaviour
{
    public Text textSceneName;
    private int numOfScenes;
    public string subFolder;

    private string selectedString;
    private int selectionNumber = 0;
  //  private string[] scenes = new string[sceneCount];

    private List<string> sceneList = new List<string>();
    // Use this for initialization
    void Awake()
    {

        // string[] GUID = AssetDatabase.FindAssets("Scene", new[] { "Assets/Scenes/"+subFolder });
        // for (int i = 0; i < GUID.Length; i++)
        // {
        //     greyboxList.Add(AssetDatabase.GUIDToAssetPath(GUID[i]));
        //     greyboxList[i] = greyboxList[i].Replace("Assets/Scenes/"+subFolder+"/", "");
        //     greyboxList[i] = greyboxList[i].Replace(".unity", "");
        // }
        //
        // selectedString = greyboxList[selectionNumber];
        // textSceneName.text = greyboxList[selectionNumber];


        numOfScenes = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
       

        for (int i = 0; i < numOfScenes; i++)
        {
            sceneList.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        textSceneName.text = sceneList[selectionNumber];
        selectedString = sceneList[selectionNumber];
    }

    public void LeftButton()
    {
        if(selectionNumber == 0)
        {
            selectionNumber = numOfScenes -1;
        }
        else
        {
            selectionNumber -= 1;
        }
    }

    public void RightButton()
    {
        if (selectionNumber == numOfScenes -1)
        {
            selectionNumber = 0;
        }
        else
        {
            selectionNumber += 1;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(selectedString);
        Time.timeScale = 1.0f;
    }

}
