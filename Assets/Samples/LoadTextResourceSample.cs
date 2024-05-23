using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Logging;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    // [Serializable]
    // record Categories
    // {
    //     public string[] categories = new string[0];
    // }
    // class Categories : List<string> { }

    [Serializable]
    record Category
    {
        public string Key = default!;
        public string Label = default!;
    }

    [Serializable]
    record QuizzesIndex
    {
        public Category[] Categories = default!;
    }

    // Start is called before the first frame update
    void Start()
    {
        var quizzesIndexAsset = Resources.Load<TextAsset>("Quizzes/index");
        Log.Info(quizzesIndexAsset);
        // var index = JsonUtility.FromJson<Categories>(quizzesIndexAsset.text);
        var index = JsonUtility.FromJson<QuizzesIndex>(quizzesIndexAsset.text);
        // Log.Info(index);
        // Log.Info(string.Join(", ", index.categories));
        // Log.Info(string.Join(", ", index));
        Log.Info(string.Join(", ", from category in index.Categories
                                   select $"{category.Key}: {category.Label}"
        ));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
