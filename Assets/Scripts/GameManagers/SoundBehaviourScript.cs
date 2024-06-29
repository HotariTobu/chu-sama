using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaviourScript : MonoBehaviour
{
    private GameManagerScript gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.SEprocess1 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.NomalEnter);
            gameManagerScript.SEprocess1 = false;
        }

        if(gameManagerScript.SEprocess2 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.question);
            gameManagerScript.SEprocess2 = false;
        }

        if(gameManagerScript.SEprocess3 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.correct);
            SoundManager.Instance.StopTIME(TIMESoundData.TIME.Time);
            gameManagerScript.SEprocess3 = false;
        }

        if(gameManagerScript.SEprocess4 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.cross);
            SoundManager.Instance.StopTIME(TIMESoundData.TIME.Time);
            gameManagerScript.SEprocess4 = false;
        }

        if(gameManagerScript.SEprocess5 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.NomalAttack);
            gameManagerScript.SEprocess5 = false;
        }

        if(gameManagerScript.SEprocess6 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.Damage);
            gameManagerScript.SEprocess6 = false;
        }

        if(gameManagerScript.SEprocess7 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.RockEnter);
            gameManagerScript.SEprocess7 = false;
        }

        if(gameManagerScript.SEprocess8 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.RockAttack1);
            gameManagerScript.SEprocess8 = false;
        }

        if(gameManagerScript.SEprocess9 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.RockAttack2);
            gameManagerScript.SEprocess9 = false;
        }

        if(gameManagerScript.SEprocess10 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.Damage);
            gameManagerScript.SEprocess10 = false;
        }

        if(gameManagerScript.SEprocess11 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.explosion);
            gameManagerScript.SEprocess11 = false;
        }

        if(gameManagerScript.SEprocess14 == true){
            SoundManager.Instance.PlayTIME(TIMESoundData.TIME.Enter);
            gameManagerScript.SEprocess14 = false;
        }

        if(gameManagerScript.SEprocess13 == true){
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.MuscleAttack);
            gameManagerScript.SEprocess13 = false;
        }

        if(gameManagerScript.SEprocess12 == true){
            SoundManager.Instance.StopTIME(TIMESoundData.TIME.Enter);
            SoundManager.Instance.PlaySE1(SESoundData1.SE1.MuscleEnter);
            gameManagerScript.SEprocess12 = false;
        }

        if(gameManagerScript.bgmprocess1 == true){
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.NomalBGM);
            gameManagerScript.bgmprocess1 = false;
        }

        if(gameManagerScript.Stopbgmprocess1 == true){
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.NomalBGM);
            gameManagerScript.Stopbgmprocess1 = false;
        }

        if(gameManagerScript.bgmprocess2 == true){
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.RockBGM);
            gameManagerScript.bgmprocess2 = false;
        }

        if(gameManagerScript.Stopbgmprocess2 == true){
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.RockBGM);
            gameManagerScript.Stopbgmprocess2 = false;
        }

        if(gameManagerScript.bgmprocess3 == true){
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.MuscleBGM);
            gameManagerScript.bgmprocess3 = false;
        }

        if(gameManagerScript.Stopbgmprocess3 == true){
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.MuscleBGM);
            gameManagerScript.Stopbgmprocess3 = false;
        }

        if(gameManagerScript.bgmprocess4 == true){
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.ClearBGM);
            gameManagerScript.bgmprocess4 = false;
        }
      
        if(gameManagerScript.timebgmprocess1 == true){
            SoundManager.Instance.PlayTIME(TIMESoundData.TIME.Time);
            gameManagerScript.timebgmprocess1 = false;
        }
    }
}
