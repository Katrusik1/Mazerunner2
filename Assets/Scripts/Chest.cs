using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Animator m_animator;
    private bool isopen;
    public List<GameObject> weapons;
    private int c =0;

    void Start()
    {
        if (isopen)
        {
            m_animator.SetBool("isopen", true);
        }
    }
    public string GetDiscription()
    {
        if (isopen) D();
        return "Открыть сундук";
    }

    public void Interact()
    {
        isopen = !isopen;
        if (isopen)
        {
            m_animator.SetBool("isopen", true);
        }
        else
        {
            m_animator.SetBool("isopen", false);
        }
    }

    public void Drop()
    {

    }

    private void D()
    {
        c += 1;
        if (c == 1)
        {
            Instantiate(weapons[0]);
        }
        Destroy(gameObject,2f);
    }
}
