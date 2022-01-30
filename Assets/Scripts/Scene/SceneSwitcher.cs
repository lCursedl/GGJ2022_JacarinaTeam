using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject DoorExit;
    private ExitDoor m_door;
    [SerializeField]
    private string NextSceneName;
    // Start is called before the first frame update
    void Start() {
        m_door = DoorExit.GetComponent<ExitDoor>();
    }

    // Update is called once per frame
    void Update() {
        if(m_door.m_levelClear) {
            SceneManager.LoadScene(NextSceneName);
        }
    }
}
