using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static bool isSpinning; // リールが回転中かどうか
    public static bool isLottery; //抽選計算中
    public static bool isResult; //結果が出た状態か
    public static int resultIndex; // 全リールの共通結果インデックス
    public static string result; //抽選結果を格納する文字

    // Start is called before the first frame update
    void Awake()
    {
        result = null;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
