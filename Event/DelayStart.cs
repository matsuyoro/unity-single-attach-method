using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Actionに必要

public class DelayStart : MonoBehaviour
{
    public float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // 一定時間たったら処理
        StartCoroutine(DelayMethod(delay, () =>
        {
            // なんらかの処理
        }));

    }

    /// <summary>
    /// 渡された処理を指定時間後に実行する
    /// </summary>
    /// <param name="waitTime">遅延時間[ミリ秒]</param>
    /// <param name="action">実行したい処理</param>
    /// <returns></returns>
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

  
}

