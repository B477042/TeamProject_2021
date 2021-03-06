using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer m_SpriteRenderer;
    public float speed = 5;

    private Rigidbody2D m_rgPlayer;
    private Collider2D coll;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask ground;
    public Transform atcTra;
    public bool isGround, isJump;
    private float horizontalMove;

    bool jumpPress;

    public bool isFirePress;
    public bool isInIdleGun =false;
    public bool isInWalkGun = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rgPlayer = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        m_SpriteRenderer.flipX = false;
    }

    public static bool bJump;
    public static bool bRightMove;
    public static bool bLeftMove;
    public static bool bAttack;
    public ButtonExtension LeftBtn;
    public ButtonExtension RightBtn;
    private void Awake()
    {
        GunAudios = this.GetComponent<AudioSource>();
        LeftBtn.onPress.AddListener(LeftMove);
        RightBtn.onPress.AddListener(RightMove);
    }


    private void LeftMove()
    {
        anim.SetFloat("Speed", 1);
        this.transform.Translate(-Time.deltaTime*10, 0, 0);
        this.transform.localScale = new Vector3(-1, 1, 1);
    }
    private void RightMove()
    {
        anim.SetFloat("Speed", 1);
        this.transform.Translate(Time.deltaTime * 10, 0, 0);
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    void Update()
    {
        if (bJump)
        {
            jumpPress = true;
            bJump = false;
        }

        //if (bRightMove)
        //{
        //    m_rgPlayer.velocity = new Vector2(horizontalMove * speed, m_rgPlayer.velocity.y);
        //    bRightMove = false;
        //}
        //if (bLeftMove)
        //{
        //    bLeftMove = false;
        //}
        if (bAttack)
        {
            isFirePress = true;
            bAttack = false;
        }



    }
    public Image HPSlider;
    public Text ScoreText;
    public int hp = 5;
    public int CurHP = 5;
    // Update is called once per frame
    //void Update()
    //{
    //float h = Input.GetAxis("Horizontal");
    //if (Mathf.Abs(h) > 0.2f)
    //{
    //    anim.SetFloat("Speed",1);
    //}
    //else
    //{
    //    anim.SetFloat("Speed", 0);
    //}

    //if (h >= 0)
    //{
    //    m_SpriteRenderer.flipX = false;
    //}
    //else
    //{
    //    m_SpriteRenderer.flipX = true;
    //}

    //transform.Translate(new Vector2(h * speed * Time.deltaTime, 0));


    //if (Input.GetButtonDown("Jump") && isGround)
    //{
    //    jumpPress = true;
    //}
    //if (Input.GetButtonDown("Fire1"))
    //{
    //    isFirePress = true;
    //}
    //}
    public static int Score;
    private AudioSource GunAudios;
    private void FixedUpdate()
    {
        HPSlider.fillAmount = (float)CurHP / (float)hp;
        ScoreText.text = Score.ToString();
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        GroundMovement();
        Jump();
        SwitchAnim();
    }

    void GroundMovement()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal");//??????-1??0??1
        //m_rgPlayer.velocity = new Vector2(horizontalMove * speed, m_rgPlayer.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }

    }
    void Jump()
    {
        if (isGround)
        {
            isJump = false;
        }
        if (jumpPress && isGround)
        {
            //Debug.LogError("jump1");
            isJump = true;
            m_rgPlayer.velocity = new Vector2(m_rgPlayer.velocity.x, jumpForce);
            jumpPress = false;
        }
    }
    /// <summary>
    /// ????
    /// </summary>
    void SwitchAnim()
    {
        anim.SetFloat("Speed", Mathf.Abs(m_rgPlayer.velocity.x));
        if (isGround)
        {
            anim.SetBool("falling", false);
        }
        else if (!isGround && m_rgPlayer.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (m_rgPlayer.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }

        //????
        if (isFirePress)
        {
            anim.SetBool("idleGun", true);
            Fire(); isFirePress = false;
            //if (horizontalMove == 0 && !isInIdleGun)
            //{
            //    isFirePress = false;
            //    isInIdleGun = true;
            //    anim.SetBool("idleGun", true);
            //    Fire();
            //}
            //else if (horizontalMove != 0 && !isInWalkGun)
            //{
            //    isFirePress = false;
            //    isInWalkGun = true;
            //    anim.SetBool("walkGun", true);
            //    Fire();
            //}
        }

    }


    void Fire()
    {
        if (!isJump)
        {
            
            GameObject n = Instantiate(Resources.Load("Bullet"), atcTra.position, Quaternion.Euler(0, transform.localScale.x < 0 ? -180 : 0, 0)) as GameObject;
            n.name = "a1";
            GunAudios.Play();
            Destroy(n, 2);
        }
    }

    void IdleGunEnd()
    {
        isInIdleGun = false;
        isFirePress = false;
        //Debug.LogError("ddddddddd");
        anim.SetBool("idleGun", false);
    }
    void WalkGunEnd()
    {
        isInWalkGun = false;
        isFirePress = false;
        //Debug.LogError("ddddddddd");
        anim.SetBool("walkGun", false);
    }
}
