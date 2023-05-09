using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;

    //�X�R�A�v�Z�p�ϐ�
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; //�����X�R�A����

        //�V�[������ScoreText�I�u�W�F�N�g���擾
        scoreText = GameObject.Find("ScoreText");
    }


    //�{�[�����I�u�W�F�N�g�ɏՓ˂������̉��Z�����X�R�A
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

        //ScoreTexe�ɃX�R�A��\��
        scoreText.GetComponent<Text>().text = "�X�R�A" + score;
    }

   
}