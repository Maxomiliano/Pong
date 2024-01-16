using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOptions : MonoBehaviour
{
    [SerializeField] GameObject _player2;
    [SerializeField] Button _pvpButton;
    [SerializeField] Button _pvaiButton;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _pvpButton.onClick.AddListener(IsPVP);
        _pvpButton.onClick.AddListener(IsNotPVP);
    }

    public void IsPVP()
    {
        PlayerVersus.IsPVP = true;
    }
    public void IsNotPVP()
    {
        PlayerVersus.IsPVP = false;
    }



    //--------------------------------------------------------------------------//


    
    public void PlayerVersusPlayer()
    {
        if (PlayerVersus.IsPVP == true)
        {
            _player2.GetComponent<PlayerMovement>().enabled = true;
            _player2.GetComponent<TestAIMovement>().enabled = false;
        }
    }

    public void PlayerVersusAI()
    {
        if (PlayerVersus.IsPVP == false)
        {
            _player2.GetComponent<TestAIMovement>().enabled = true;
            _player2.GetComponent<PlayerMovement>().enabled = false;
        }
    }
    
}
