using UnityEngine.SceneManagement;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{

    public EnemyController controller;
    public Animator animator;
    public float runSpeed = 30f;
    float horizontalMove = 0f;
    float move = 10;
   


    void Update()
    {
        horizontalMove = move * runSpeed * Time.fixedDeltaTime;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime);
    }

    public void OnLanding()
    {
        Debug.Log("OnLanding()");
        animator.SetBool("IsJumping", false);
    }



}