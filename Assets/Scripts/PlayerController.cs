using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    //left is false right is true
    private bool move = false;

    private Rigidbody2D rb;
    public bool isGround = false;
    public float maxFallSpeed = -15.0f;

    public float jumpPower = 5f;

    public float jumpGravity = 2.0f;

    public float enemyPower = 1.0f;

    private float enemyHitTimer = 0.6f;
    private float count = -1;

    private float hp = 5;

    public bool doubleJump = false;
    private int jumpCount = 0;
    public GameObject[] heart;

    public Sprite heartSpr;

    public GameObject destroyParticle;

    private AudioSource audioSource;
    public AudioClip hitEnemy;
    public AudioClip jumpOn;
    public AudioClip save;
    public AudioClip getShoes;

    private GameObject SaveText;

    private GameObject MainCamera;

    public GameObject gameOverMenu;

    private bool gameOver = false;

    public GameObject shoesImage;

    public GameObject shoesCollider;

    private bool canEatApple = false;

    private GameObject appleBowl;
    // Start is called before the first frame update
    void Start()
    {
        SaveText = GameObject.Find("SaveText");
        MainCamera = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody2D>();
        audioSource = this.GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        
        if(canEatApple && Input.GetKeyDown(KeyCode.K))
        {
            appleBowl.GetComponent<EatAppleManager>().eatApple();
        }
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (gameOver) return;
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(maxFallSpeed, rb.velocity.y));
        if (((jumpCount == 1 && doubleJump) || isGround) && Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;
            isGround = false;

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (!isGround && rb.velocity.y > 0.0f && Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = jumpGravity / 2;
        }
        else
        {
            rb.gravityScale = jumpGravity;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameOver) return;
        if (count >= 0 && count <= enemyHitTimer)
        {
            
            count += Time.deltaTime;
            if(count > enemyHitTimer)
            {
                var c = this.GetComponent<SpriteRenderer>().color;
                c.a = 1.0f;
                this.GetComponent<SpriteRenderer>().color = c;
            }
            return;
        }



        //vertical movement
        if (Input.GetKey(KeyCode.A))
        {
            if (move)
            {
                move = false;
                this.transform.localScale = new Vector3(1,1,1);
            }
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        }else if (Input.GetKey(KeyCode.D))
        {
            if (!move)
            {
                move = true;
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

    }

    public void touchGround()
    {
        jumpCount = 0;
        isGround = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "eatApple")
        {
            appleBowl = collision.gameObject;
            canEatApple = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "eatApple")
        {
            canEatApple = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameOver) return;

        if(collision.tag == "shoes")
        {
            doubleJump = true;
            shoesImage.SetActive(true);
            Destroy(collision.gameObject.transform.parent.gameObject);
            audioSource.PlayOneShot(getShoes);
           
        }
        if(collision.tag == "savePoint")
        {
            audioSource.PlayOneShot(save);
            SaveText.GetComponent<SaveTextManager>().startSaveText();
        }else if(collision.tag == "jumpOn")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower*1.3f);
            //play particle

            destroyParticle.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, destroyParticle.transform.position.z);
            destroyParticle.GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(jumpOn);

        }
        else if(collision.tag == "damage")
        {
            if (count >= 0 && count <= enemyHitTimer) return;
            if (collision.gameObject.transform.parent.transform.position.x > this.transform.position.x)
            {
                count = 0;
                rb.AddForce(enemyPower * Vector2.left, ForceMode2D.Impulse);
            }
            else
            {
                count = 0;   
                rb.AddForce(enemyPower * Vector2.right, ForceMode2D.Impulse);
            }
            hp  -= 0.5f;
            int index = (int)(hp/1);

            if (hp - index > 0.1f) heart[index].GetComponent<SpriteRenderer>().sprite = heartSpr;
            else heart[index].GetComponent<SpriteRenderer>().sprite = null;

            audioSource.PlayOneShot(hitEnemy);
            var c = this.GetComponent<SpriteRenderer>().color;
            c.a = 0.5f;
            this.GetComponent<SpriteRenderer>().color = c;
            

            if (hp == 0)
            {
                MainCamera.GetComponent<CameraManager>().stopCameraMovement();
                gameOverMenu.SetActive(true);
                gameOver = true;
                destroyParticle.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, destroyParticle.transform.position.z);
                destroyParticle.GetComponent<ParticleSystem>().Play();
                this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
        }
    }

}
