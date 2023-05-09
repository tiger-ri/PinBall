using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコア計算用変数
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; //初期スコアを代入

        //シーン中のScoreTextオブジェクトを取得
        scoreText = GameObject.Find("ScoreText");
    }


    //ボールがオブジェクトに衝突した時の加算されるスコア
    void OnCollisionEnter(Collision collision)
    {
       
        string Tag = collision.gameObject.tag;

        if (Tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (Tag == "LargeStarTag")
        {
            score += 30;
        }
        else if (Tag == "SmallCloudTag")
        {
            score += 20;
        }
        else if (Tag == "LargeCluodTag")
        {
            score += 40;
        }
        else
        {
            score += 0;
        }

        //ScoreTexeにスコアを表示
        scoreText.GetComponent<Text>().text = "スコア" + score;
    }

   
}