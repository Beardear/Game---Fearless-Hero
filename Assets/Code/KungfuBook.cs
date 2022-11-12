using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KungfuBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            return;
        }

        Scene scene = SceneManager.GetActiveScene();        //��ǰ��������
        string newKungfu;

        switch (scene.name)
        {
            case "Level1":
                newKungfu = "Kick";
                break;
            case "Level2":
                newKungfu = "DiveKick";
                break;
            case "Level3":
                newKungfu = "JumpKick";
                break;
            case "Level4":
                newKungfu = "";             //���Ĺؽ����ˣ�����û���¼���
                break;
            default:
                newKungfu = "";
                break;
        }



        //InstanceManager.Instance.PlayerController.KungfuEnableList["DiveKick"] = true;
        if (newKungfu!=null&&newKungfu!="")
        {
            PlayerModel.Instance.KungfuEnableList[newKungfu] = true;
        }
        
        Destroy(this.gameObject);
        InstanceManager.Instance.gameController.showResult(true);
    }
}
