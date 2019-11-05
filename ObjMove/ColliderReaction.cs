using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exploder.Utils;
using System; // Actionに必要

public class ColliderReaction : MonoBehaviour
{
    [SerializeField] private float delay = 0f;
    [SerializeField] private bool reactionOnce = true; //一度だけか
    private bool onceCheck = false; //一度実行したか
    [SerializeField] private bool isTrigger = false;

    [SerializeField]
    private enum ReactionType
    {
        smoke,
        bomb,
        exploder,
        exploder_bomb,
        exploder_bomb_big_addforce,
        hidden_element,
        clear_trigger,

    }
    [SerializeField] ReactionType reactionType = ReactionType.smoke;

    void Start()
    {

    }

    void Reaction(GameObject target)
    {



        // すでに実行中か
        if(onceCheck == true){
            return;    
        }

        if (reactionType == ReactionType.smoke)
        {

            // 噴煙エフェクト
            GameObject prefab = (GameObject)Resources.Load("Prefabs/Effects/Vendors/Puff_Mobile_mini"); //as GameObject;
            GameObject instance = (GameObject)GameObject.Instantiate(prefab, target.transform.position, Quaternion.Euler(0.0f, 0f, 0.0f));
            // instance.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            Destroy(instance, 3f);


        }
        else if (reactionType == ReactionType.exploder)
        {

            // NOTE:3Dモデルによっては破裂しない
            ExploderSingleton.Instance.ExplodeObject(target);

        }
        else if (reactionType == ReactionType.exploder_bomb_big_addforce)
        {
            // 破裂
            ExploderSingleton.Instance.ExplodeObject(target);


            // 爆発エフェクト
            // GameObject prefab = (GameObject)Resources.Load("Prefabs/Effects/Vendors/Explosion01_Mobile"); //as GameObject;

            GameObject prefab = (GameObject)Resources.Load("Prefabs/Effects/Vendors/Explosion_Small_FX_CustomBig"); //as GameObject;
            GameObject instance = (GameObject)GameObject.Instantiate(prefab, target.transform.position, Quaternion.Euler(0.0f, 0f, 0.0f));
            instance.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            Destroy(instance, 3f);


            // 爆風物理処理
            float radius = 5.0F;
            float power = 700000.0F; // ちょっと強すぎる

            Vector3 explosionPos = target.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                // Debug.LogError("hit:" + hit.gameObject.name);
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {

                    // ExploderSingleton.Instance.ExplodeObject(rb.gameObject); //連鎖的に破裂させる場合

                    rb.AddExplosionForce(power, explosionPos, radius, 10.0F);
                }
            }
        }
        else if (reactionType == ReactionType.clear_trigger)
        {   // 何かをトリガーにクリアさせる場合 ※未使用
            {
                // Time.timeScale = 0.5f;
                // // 一定時間たったら
                // StartCoroutine(DelayMethod(1f, () =>
                // {
                //     Time.timeScale = 1f;

                //     handObj.GetComponent<HandController>().ScoreUpdate(2, Constant.TrickType.Landing, this.gameObject);
                //     MMVibrationManager.Haptic(HapticTypes.Success);

                // }));

            }

        }

        // 一度だけ実装する用
        if (reactionOnce)
        {
            if (onceCheck == false)
            {
                onceCheck = true;
            }
        }
    }



    void OnTriggerEnter(Collider col)
    {
        // Debug.LogError("col.gameObject.tag:" + col.gameObject.tag.ToString() + "  name:" + col.gameObject.name);

        if (isTrigger == false)
        {
            return;
        }
        if (col.gameObject.tag == Constant.Tag_PlayerBottle)
        {

            // 一定時間たったら
            StartCoroutine(DelayMethod(delay, () =>
            {
                Reaction(col.gameObject);
            }));
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == Constant.Tag_PlayerBottle)
        {

            // 一定時間たったら
            StartCoroutine(DelayMethod(delay, () =>
            {
                Reaction(col.gameObject);
            }));
        }

    }

    /// <summary>
    /// 渡された処理を指定時間後に実行する
    /// </summary>
    /// <param name="waitTime">遅延時間[ミリ秒]</param>
    /// <param name="action">実行したい処理</param>
    /// <returns></returns>
    IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }



}

