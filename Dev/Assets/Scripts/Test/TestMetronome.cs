using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMetronome : MonoBehaviour
{
    public float speed;
    public Button btnMusicStart;
    public GameObject bgm;

    public GameObject dim;

    private float i;

    void Awake()
    {
        Debug.Log("씬시작");

        //this.dim.SetActive(true);
        FadeIn();
    }

    void Start()
    {
        Debug.Log("메트로놈 테스트");

        this.btnMusicStart.onClick.AddListener(()=> 
        {
            this.bgm.SetActive(true);
            InvokeRepeating("Metronome", 0, speed);
        });
        

    }

    private void Metronome()
    {
        #region 테스트 파트(나중에 지울것)
        this.i += speed;
        Debug.LogFormat("쿵짝 : {0}", i);
        #endregion

       
    }


    public IEnumerator FadeOut()
    {
        var color = this.dim.GetComponent<Image>().color;
        float alpha = color.a;

        while (true)
        {
            alpha -= 0.016f;
            color.a = alpha;
            this.dim.GetComponent<Image>().color = color;

            if (alpha <= 0)
            {
                alpha = 0;
                break;
            }
            yield return null;
        }
        //this.OnFadeOutComplete();
    }

    public IEnumerator FadeIn()
    {
        var color = this.dim.GetComponent<Image>().color;
        float alpha = color.a;

        while (true)
        {
            alpha += 0.016f;
            color.a = alpha;
            this.dim.GetComponent<Image>().color = color;

            if (alpha >= 1)
            {
                alpha = 1;
                break;
            }
            yield return null;
        }
        //this.OnFadeInComplete();
    }
}
