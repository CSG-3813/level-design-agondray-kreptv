using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameManager gm;
    public int keyNum = 0;

    // Start is called before the first frame update
    void Start()
    {
      gm = GameObject.Find("Main Camera").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider cube)
    {
        gm.currKey = keyNum;
        Destroy(this.gameObject);
    }

}
