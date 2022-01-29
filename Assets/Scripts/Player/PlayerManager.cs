using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Positive;
    [SerializeField]
    private GameObject Negative;
    private GameObject m_currentPlayer;

    private

    // Start is called before the first frame update
    void Start() {
        m_currentPlayer = Positive.GetComponent<PlayerMovement>().Selected ? Positive : Negative;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Switch")) {
            m_currentPlayer.GetComponent<PlayerMovement>().Selected = false;
            m_currentPlayer = m_currentPlayer == Positive ? Negative : Positive;
            m_currentPlayer.GetComponent<PlayerMovement>().Selected = true;
        }
    }
}
