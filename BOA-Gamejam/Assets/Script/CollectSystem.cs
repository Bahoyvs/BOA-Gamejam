using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    [SerializeField] private CursorManager.CursorType cursorType;
    bool Pressed = false;

    private GameObject player;
    private float emptyChance;
    private Animator anim;
    private PlayerStats playerStats;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        this.player = GameObject.FindWithTag("Player");
    }

    private void OnMouseDown()
    {
        Pressed = true;
        emptyChance = Random.Range(0.0f, 1.0f);
        anim.SetTrigger("Oppen");
        playerStats.eggCnt++;
    }

    private void OnMouseUp()
    {
        Pressed = false;
    }

    private void OnMouseEnter()
    {
        CursorManager.Instance.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Aim);
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

    }

    private void DestroyEgg()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Aim);
        if (emptyChance < 0.1f)
        {
            anim.SetBool("isEmpty", true);
        }
        else
        {
            anim.SetBool("isEmpty", false);
            player.GetComponent<PlayerStats>().HealCharacter(50);

        }
        Destroy(gameObject);
    }
}
