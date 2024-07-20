using UnityEngine;

public class MotionController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Animatorコンポーネントの取得
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 入力の取得
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 入力があるかどうかを判断
        bool isMoving = moveHorizontal != 0 || moveVertical != 0;

        // Animatorの「Run」パラメータを設定
        animator.SetBool("Run", isMoving);
    }
}