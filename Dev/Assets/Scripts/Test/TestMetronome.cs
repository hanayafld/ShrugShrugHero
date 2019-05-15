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

        this.dim.SetActive(true);
    }

    void Start()
    {
        Debug.Log("메트로놈 테스트");

        this.FadeIn(this.dim);

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

    private void FadeOut(GameObject fade)
    {
        StartCoroutine(this.FadeOutImpl(fade));
    }

    private IEnumerator FadeOutImpl(GameObject fade)
    {
        Debug.Log("페이드아웃");
        var color = fade.GetComponent<Image>().color;
        float alpha = color.a;

        while (true)
        {
            alpha -= 0.016f;
            color.a = alpha;
            fade.GetComponent<Image>().color = color;

            if (alpha <= 0)
            {
                alpha = 0;
                break;
            }
            yield return null;
        }
        //this.OnFadeOutComplete();
    }

    private void FadeIn(GameObject fade)
    {
        StartCoroutine(this.FadeInImpl(fade));
    }

    private IEnumerator FadeInImpl(GameObject fade)
    {
        Debug.Log("페이드인");
        var color = fade.GetComponent<Image>().color;
        float alpha = color.a;

        while (true)
        {
            alpha += 0.016f;
            color.a = alpha;
            fade.GetComponent<Image>().color = color;

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
