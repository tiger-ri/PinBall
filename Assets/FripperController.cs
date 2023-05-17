using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // �L�[�{�[�h����i���E���L�[��A�ED�L�[�j�̏���
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

        //S�L�[�܂��͉����L�[�����������ɓ����ɍ��E�̃t���b�p�[�𓮂���
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if (tag == "LeftFripperTag" || tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
        }
        //S�L�[�܂��͉����L�[�����������ɓ����ɍ��E�̃t���b�p�[�����ɖ߂�
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
        {
            if (tag == "LeftFripperTag" || tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }

        // �^�b�`����̏���
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // ��ʂ̍������^�b�`�����ꍇ���t���b�p�[�𓮂���
                if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                // ��ʂ̉E�����^�b�`�����ꍇ�E�t���b�p�[�𓮂���
                else if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // �^�b�`���I�������ꍇ�t���b�p�[�����ɖ߂�
                if ((touch.position.x < Screen.width / 2 && tag == "LeftFripperTag") ||
                    (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag"))
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
