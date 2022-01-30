using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    private Camera m_levelCamera;
    // Start is called before the first frame update
    void Start() {
        m_levelCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.LookAt(m_levelCamera.transform);
    }
}
