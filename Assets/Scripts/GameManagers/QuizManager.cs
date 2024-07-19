using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{

    // Start is called before the first frame update
    private GameManagerScript gameManagerScript;
    private TextBehaviourScript textBehaviourScript;
    private List<int> list = new List<int>();
    
    void Start()
    {
        gameManagerScript = GetComponent<GameManagerScript>();
        textBehaviourScript = GetComponent<TextBehaviourScript>();
        list.Add(-1);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.probprocess == true){
            var categoryKey = "kanji";

            if(TitleBehaviourScript.cnt == 3){
                categoryKey = "history";
            }

            if(TitleBehaviourScript.cnt == 4){
                categoryKey = "english";
            }

            if(TitleBehaviourScript.cnt == 5){
                int tmp = Random.Range(3, 5);
                if(tmp == 3){
                    categoryKey = "kanji";
                }else if(tmp == 4){
                    categoryKey = "history";
                }else if(tmp == 5){
                    categoryKey = "english";
                }
            }

            var categoryAsset = Resources.Load<TextAsset>($"Quizzes/{categoryKey}");
            var category = JsonUtility.FromJson<Category>(categoryAsset.text);
            int num = -1;

            if(TitleBehaviourScript.cnt >= 2 && TitleBehaviourScript.cnt <= 4){
                if(gameManagerScript.CharaCnt == 1){
                    while(list.Contains(num)){
                        num = Random.Range(0, 9);
                    }

                    list.Add(num);
                    gameManagerScript.prob = category.Problems[num].Body;

                }else if(gameManagerScript.CharaCnt == 2){
                    while(list.Contains(num)){
                        num = Random.Range(10, 19);
                    }

                    list.Add(num);
                    gameManagerScript.prob = category.Problems[num].Body;

                }else{
                    while(list.Contains(num)){
                        num = Random.Range(20, 30);
                    }

                    list.Add(num);
                    gameManagerScript.prob = category.Problems[num].Body;
                }
            }else{
                while(list.Contains(num)){
                    num = Random.Range(20, 30);
                }

                list.Add(num);
                gameManagerScript.prob = category.Problems[num].Body;
            }

            textBehaviourScript.op1 = category.Problems[num].Options[0].Body;
            textBehaviourScript.op2 = category.Problems[num].Options[1].Body;
            textBehaviourScript.op3 = category.Problems[num].Options[2].Body;
            textBehaviourScript.op4 = category.Problems[num].Options[3].Body;

            for(int i = 0; i < 4; i++){
                if(category.Problems[num].Options[i].IsCorrect){
                    gameManagerScript.ans = i+1;
                    gameManagerScript.ansprob = category.Problems[num].Options[i].Body;
                }
            }
            
            gameManagerScript.probprocess = false;
        }
    }
}
