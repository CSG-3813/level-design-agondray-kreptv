using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public GameManager gm;

    public GameObject door;
    public bool isOpening = false; public bool isClosing = false;

    public float speed = 6;

    public Vector3 orig; public Vector3 neww;

    public int reqKey;

    void Start() {
      gm = GameObject.Find("Main Camera").GetComponent<GameManager>();
      door = this.gameObject;
      orig = door.transform.position;
      neww = new Vector3 (door.transform.position.x, -3.95f, door.transform.position.z);
    }

    void Update(){
        if (gm.currKey >= reqKey){
          door.transform.GetChild(0).gameObject.SetActive(false);
          if (isOpening){
            door.transform.position = Vector3.MoveTowards(door.transform.position, neww, speed * Time.deltaTime);
          }
          if (isClosing){
            StartCoroutine(DoorClose());
            if (door.transform.position == orig){
              isClosing = false;
            } //
          }
        }
    }

    void OnTriggerEnter(Collider cube)
    {
        // whenever anything enters the trigger, open the door
        isOpening = true;
    }

    void OnTriggerExit(Collider cube){
        // whenever anything exits the trigger, close the door.
        isOpening = false;
        isClosing = true;
    }

    IEnumerator DoorClose()
    {
      yield return new WaitForSeconds(2f);
      door.transform.position = Vector3.MoveTowards(door.transform.position, orig, speed * Time.deltaTime);
    }



}
