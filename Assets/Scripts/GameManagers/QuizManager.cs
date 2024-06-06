using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // var categoryKey = GameParameters.Instance.Category;
        var categoryKey = "sample";

        var categoryAsset = Resources.Load<TextAsset>($"Quizzes/{categoryKey}");
        var category = JsonUtility.FromJson<Category>(categoryAsset.text);

        foreach (var problem in category.Problems)
        {
            Debug.Log($"問題文: {problem.DifficultyLevel}|{problem.Body}");
            foreach (var option in problem.Options)
            {
                var mark = option.IsCorrect ? "◯" : "×";
                Debug.Log($"  {mark}選択肢: {option.Body}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
