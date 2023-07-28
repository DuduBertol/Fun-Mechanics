using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIbar;
    [SerializeField] private Image woodUIbar;
    [SerializeField] private Image carrotUIbar;
    [SerializeField] private Image fishUIbar;

    [Header("Tools")]
    //  [SerializeField] private Image axeUI;
    // [SerializeField] private Image shovelUI;
    // [SerializeField] private Image bucketUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectcolor;
    [SerializeField] private Color alphacolor;

    private PlayerItems playerItems;
    private Player player;

    private void Awake() 
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIbar.fillAmount = 0f;
        woodUIbar.fillAmount = 0f;
        carrotUIbar.fillAmount = 0f;
        fishUIbar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIbar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodUIbar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotUIbar.fillAmount = playerItems.carrots / playerItems.carrotsLimit;
        fishUIbar.fillAmount = playerItems.fishes / playerItems.fishesLimit;

       // toolsUI[player.handlingObj].color = selectcolor;

        for(int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectcolor;
            }
            else
            {
                toolsUI[i].color = alphacolor;
            }
        }
    }
}
