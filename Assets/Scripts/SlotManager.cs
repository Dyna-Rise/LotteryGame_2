using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotManager : MonoBehaviour
{
 


    //StartSlotメソッドまで作成できたらコメントアウトを解除
    // IEnumerator StopReelsSequentially()
    // {
    //     yield return new WaitForSeconds(3.0f);
    //     yield return new WaitUntil(() => GameManager.isResult);

    //     for (int i = 0; i < reels.Length; i++)
    //     {
    //         //float targetAngle = GameManager.resultIndex * (360f / optionData.option.prizeName.Length + 1); // 対応する角度を計算
    //         float targetAngle = localResultIndex * (360f / optionData.option.prizeName.Length + 1); //仮値
    //         targetAngle -= 360.0f;
    //         isPersonSpinning[i] = false;

    //         yield return StartCoroutine(SlowStop(reels[i], targetAngle));
    //     }

    //     // 回転フラグをオフ
    //     GameManager.isSpinning = false;

    //     GameManager.isLottery = false;

    //     // resultに結果を格納
    //     //GameManager.result = optionData.option.prizeName[GameManager.resultIndex];
    //     GameManager.result = optionData.option.prizeName[localResultIndex]; //仮値

    // }

    //StartSlotメソッドまで作成できたらコメントアウトを解除
    // IEnumerator SlowStop(GameObject reel, float targetAngle)
    // {
    //     float currentAngle = reel.transform.rotation.eulerAngles.x;
    //     float difference = Mathf.DeltaAngle(currentAngle, targetAngle);

    //     // ゆっくり止める
    //     while (Mathf.Abs(difference) > 0.1f)
    //     {
    //         currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * 5f);
    //         reel.transform.rotation = Quaternion.Euler(currentAngle, 0, 0);
    //         difference = Mathf.DeltaAngle(currentAngle, targetAngle);
    //         yield return null;
    //     }

    //     // 最終位置をスナップ
    //     reel.transform.rotation = Quaternion.Euler(targetAngle, 0, 0);
    // }
}
