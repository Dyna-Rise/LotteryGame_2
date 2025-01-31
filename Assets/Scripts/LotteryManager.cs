using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotteryManager : MonoBehaviour
{
    public OptionData optionData;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isSpinning == true)
        {
            if (GameManager.isLottery == false)
            {
                GameManager.isLottery = true;
                GameManager.isResult = false;
                StartLottery();
            }
        }
    }


    public void StartLottery()
    {
        GameManager.resultIndex = Random.Range(0, optionData.option.prizeName.Length);
        Debug.Log("抽選番号結果 : " + GameManager.resultIndex);
        GameManager.isResult = true;
    }

}   
