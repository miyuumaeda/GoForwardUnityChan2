using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //オーディオ
    public AudioClip bgm;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            this.aud.PlayOneShot(this.bgm);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //衝突
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("衝突" + other.gameObject.tag);

        //例えば、GroundTagやCubeTagの場合に効果音を鳴らす

        

        if (other.gameObject.tag == "cube")
        {
            //効果音を鳴らす関数
            GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.tag == "ground")
        {
            //効果音を鳴らす関数
            GetComponent<AudioSource>().Play();
        }

    }
}


