using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public Button UpBtn;
    public Button AttackBtn;
    public Button BackBtn;




    private void Awake()
    {
        BackBtn.onClick.AddListener(BackMenu);
        UpBtn.onClick.AddListener(Jump);
        AttackBtn.onClick.AddListener(Attack);
    }
    private void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Attack()
    {
        Player.bAttack = true;
    }

    private void Jump()
    {
        Player.bJump = true;
    }

 
}
