using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // キーボード操作（左右矢印キーとA・Dキー）の処理
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            if (tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            if (tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }

        //Sキーまたは下矢印キーを押した時に同時に左右のフリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if (tag == "LeftFripperTag" || tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
        }
        //Sキーまたは下矢印キーを押した時に同時に左右のフリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
        {
            if (tag == "LeftFripperTag" || tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }

        // タッチ操作の処理
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // 画面の左側をタッチした場合左フリッパーを動かす
                if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                // 画面の右側をタッチした場合右フリッパーを動かす
                else if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // タッチが終了した場合フリッパーを元に戻す
                if ((touch.position.x < Screen.width / 2 && tag == "LeftFripperTag") ||
                    (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag"))
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
