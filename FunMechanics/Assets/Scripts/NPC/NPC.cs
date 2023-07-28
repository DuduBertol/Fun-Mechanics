using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private float inicialSpeed;
    private int index;
    private Animator anim;
    private Player player;

    public List<Transform> paths = new List<Transform>();

    private void Start()
    {
        inicialSpeed = speed;
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }
    void Update()
    {

        if(DialogueControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
            player.isPaused = true;
        }
        else
        {
            speed = inicialSpeed;
            anim.SetBool("isWalking", true);
            player.isPaused = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if(index < paths.Count - 1)
            {
                //index++;
                index = Random.Range(0, paths.Count - 1);
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;

        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
