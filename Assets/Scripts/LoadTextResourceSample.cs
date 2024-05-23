using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Logging;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // [Serializable]
    // record Categories
    // {
    //     public string[] categories = new string[0];
    // }
    class Categories : List<string> { }

    // Start is called before the first frame update
    void Start()
    {
        var categoriesAsset = Resources.Load<TextAsset>("Quizzes/categories");
        Log.Info(categoriesAsset);
        var categories = JsonUtility.FromJson<Categories>(categoriesAsset.text);
        // Log.Info(categories);
        // Log.Info(string.Join(", ", categories.categories));
        Log.Info(string.Join(", ", categories));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
