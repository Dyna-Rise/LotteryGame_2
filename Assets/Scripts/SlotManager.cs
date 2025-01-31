using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.NetworkInformation;

public class SlotManager : MonoBehaviour
{
    public GameObject[] reels; // リールオブジェクトの配列
    public float spinSpeed = 1000.0f; // リールの回転速度
    public float stopDelay = 0.5f; // リール停止の遅延時間
    public int localResultIndex = 0; // 仮の結果インデックス（後で結果が決定される）
    bool[] isPersonSpinning = { false, false, false }; // 各リールの回転状態を管理
    public OptionData optionData; // 選択肢データを保持するオブジェクト


    private void Update()
    {
        // スロットが回転中の場合、各リールを回転させる
        if (GameManager.isSpinning)
        {
            for(int i = 0; i < reels.Length; i++)
            {
                if (isPersonSpinning[i])
                {
                    reels[i].transform.Rotate(-spinSpeed * Time.deltaTime, 0, 0);
                }
            }
        }
    }

    public void StartSlot()
    {
        // スロットがすでに回転中でなければ、回転を開始
        if (GameManager.isSpinning == false)
        {
            GameManager.result = null; // 結果をリセット
            GameManager.isSpinning = true; // スロットの回転フラグをオン

            // 全てのリールを回転状態にする
            for (int i = 0; i < isPersonSpinning.Length; i++)
            {
                isPersonSpinning[i] = true;
            }
            // リールを順番に停止させるコルーチンを開始
            StartCoroutine(StopReelsSequentially());
        }
    }

    
     IEnumerator StopReelsSequentially()
    {
        yield return new WaitForSeconds(3.0f);
        yield return new WaitUntil(() => GameManager.isResult);

        for (int i = 0; i < reels.Length; i++)
        {
            float targetAngle = GameManager.resultIndex * (360f / optionData.option.prizeName.Length + 1); // 対応する角度を計算
            //float targetAngle = localResultIndex * (360f / optionData.option.prizeName.Length + 1); //仮値
            targetAngle -= 360.0f;
            isPersonSpinning[i] = false;

            yield return StartCoroutine(SlowStop(reels[i], targetAngle));
        }

        // 回転フラグをオフ
        GameManager.isSpinning = false;

        GameManager.isLottery = false;

        // resultに結果を格納
        GameManager.result = optionData.option.prizeName[GameManager.resultIndex];
        //GameManager.result = optionData.option.prizeName[localResultIndex]; //仮値

    }


     IEnumerator SlowStop(GameObject reel, float targetAngle)
    {
        float currentAngle = reel.transform.rotation.eulerAngles.x;
        float difference = Mathf.DeltaAngle(currentAngle, targetAngle);

        // ゆっくり止める
        while (Mathf.Abs(difference) > 0.1f)
        {
            currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * 5f);
            reel.transform.rotation = Quaternion.Euler(currentAngle, 0, 0);
            difference = Mathf.DeltaAngle(currentAngle, targetAngle);
            yield return null;
        }

        // 最終位置をスナップ
        reel.transform.rotation = Quaternion.Euler(targetAngle, 0, 0);
    }
}
