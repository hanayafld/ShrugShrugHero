using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestYeah : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("메트로놈 테스트");
        InvokeRepeating("Test", 0, 0.25f);
    }

    public void TestMetronome(float speed)
    {
        speed += 0.25f;
        Debug.LogFormat("쿵짝 : {0}", this.speed);
    }
}