using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度

    void Update()
    {
        // 入力の取得
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 移動ベクトルの計算
        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);

        // 入力がある場合のみ移動と回転を行う
        if (moveDirection != Vector3.zero)
        {
            // プレイヤーの向きを移動方向に変更
            transform.forward = moveDirection;

            // プレイヤーを移動
            transform.Translate(moveDirection.normalized * (moveSpeed * Time.deltaTime), Space.World);
        }
    }
}