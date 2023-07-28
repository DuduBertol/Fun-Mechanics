using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]

    [SerializeField] private int digAmount; //quantidade de "escavação"
    [SerializeField] private float waterAmount; // total de agua para nacer uma cenoura 
    [SerializeField] private bool detecting;
    private bool isPlayer; // fica verdadeiro quando o player está encostando
    
    private int incialDigAmount;
    private float currentWater;

    private bool dugHole;
    private bool plantedCarrot;

    PlayerItems playerItems;

    private void Start() 
    {
        incialDigAmount = digAmount;
        playerItems = FindObjectOfType<PlayerItems>();
    }

    private void Update() 
    {
        if(dugHole)
        {
            if(detecting)
            {
                currentWater += 0.01f;
            }

            //encheu o total de agua necessario
            if(currentWater >= waterAmount && !plantedCarrot)
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRenderer.sprite = carrot;

                plantedCarrot = true;
            }

            if(Input.GetKeyDown(KeyCode.E) && plantedCarrot && isPlayer)
                {
                    audioSource.PlayOneShot(carrotSFX);
                    spriteRenderer.sprite = hole;
                    playerItems.carrots++;
                    currentWater = 0f;
                }
        }
    }


    public void OnHit()
    {
        digAmount--;

        if(digAmount <= incialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }
        

        //if(digAmount <= 0)
        //{
        //    //plantar cenoura
        //    
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Dig"))
        {
            OnHit();
        }

        if(collision.CompareTag("Water"))
        {
            detecting = true;
        }

        if(collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Water"))
        {
            detecting = false;
        }

        if(collision.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
