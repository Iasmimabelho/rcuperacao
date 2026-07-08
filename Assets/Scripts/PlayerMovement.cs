using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    [Header("Efeitos Visuais (Professor pediu)")]
    public GameObject particulaSaltoPrefab; // Arraste o Prefab da poeira para aqui no Unity

    // Update is called once per frame
    void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);

            // CRIA A POEIRA EXATAMENTE AO SALTAR
            if (particulaSaltoPrefab != null) {
                Instantiate(particulaSaltoPrefab, transform.position, Quaternion.identity);
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);

        // CRIA A POEIRA TAMBÉM AO ATERRAR (Fica ainda mais profissional!)
        if (particulaSaltoPrefab != null) {
            Instantiate(particulaSaltoPrefab, transform.position, Quaternion.identity);
        }
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}