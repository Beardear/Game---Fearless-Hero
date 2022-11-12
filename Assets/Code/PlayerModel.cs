using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private static PlayerModel _Instance = new PlayerModel();

    public static PlayerModel Instance { get => _Instance; set => _Instance = value; }

    //KungfuEnableList
    public Dictionary<string, bool> KungfuEnableList;
    public int Lv;
    public int LvValue;

    PlayerModel()
    {
        //KungfuEnableList
        KungfuEnableList = new Dictionary<string, bool>();
        KungfuEnableList.Add("Jab", true);
        KungfuEnableList.Add("Kick", false);
        KungfuEnableList.Add("DiveKick", false);
        KungfuEnableList.Add("JumpKick", false);

        //Lv
        Lv = 1;
        LvValue = 0;
    }
    /// <summary>
    /// value: �����ľ���
    /// </summary>
    /// <param name="value"></param>
    public void addLvValue(int value)
    {
        LvValue += value;
        Lv = LvValue / 100 + 1;             //�ȼ���1��ʼ������Ҫ+1
        //print(LvValue);
    }
}
