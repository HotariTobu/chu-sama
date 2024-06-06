using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var quizzesIndexAsset = Resources.Load<TextAsset>("Quizzes/index");
        var quizzesIndex = JsonUtility.FromJson<QuizzesIndex>(quizzesIndexAsset.text);

        foreach (var categoryIndex in quizzesIndex.Categories)
        {
            Debug.Log($"カテゴリ: {categoryIndex.Key} - {categoryIndex.Label}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
