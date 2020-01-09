using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMan : MonoBehaviour
{
    private Animator animator;
    private bool clicked = false;
    [SerializeField]
    private CardBody cardBody;

    int bodyPartsVisible = 0;
    int animationIndex = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        Cursor.visible = false;
        cardBody.HideBody();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !clicked)
        {
            clicked = true;
            StartCoroutine(ResetClicking());
            Clicking();
        }
    }
    public void Clicking()
    {
        if (bodyPartsVisible < 6)
        {
            PlaceBodyParts();
        } else
        {
            NextAnimation();
        }
    }
    public void NextAnimation()
    {
        animationIndex++;
        animator.SetInteger("animationIndex", animationIndex);
    }
    public void PlaceBodyParts()
    {
        switch (bodyPartsVisible)
        {
            case 0:
                cardBody.torso.SetActive(true);
                break;
            case 1:
                cardBody.arm_l.SetActive(true);
                break;
            case 2:
                cardBody.arm_r.SetActive(true);
                break;
            case 3:
                cardBody.leg_l.SetActive(true);
                break;
            case 4:
                cardBody.leg_r.SetActive(true);
                break;
            case 5:
                cardBody.head.SetActive(true);
                cardBody.expression.gameObject.SetActive(true);
                break;
        }
        bodyPartsVisible++;
    }
    IEnumerator ResetClicking()
    {
        yield return new WaitForSeconds(0.5f);
        clicked = false;
    }
}

[System.Serializable]
public class CardBody
{
    public GameObject arm_l;
    public GameObject arm_r;
    public GameObject leg_l;
    public GameObject leg_r;
    public GameObject torso;
    public GameObject head;
    public SpriteRenderer expression;
    public void HideBody()
    {
        arm_l.SetActive(false);
        arm_r.SetActive(false);
        leg_l.SetActive(false);
        leg_r.SetActive(false);
        torso.SetActive(false);
        head.SetActive(false);
        expression.gameObject.SetActive(false);
    }
}
