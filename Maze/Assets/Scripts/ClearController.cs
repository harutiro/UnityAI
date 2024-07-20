using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearController : MonoBehaviour
{
    private int itemCount = 0; // 取得したアイテムのカウント

    void OnCollisionEnter(Collision collision)
    {
        // Itemタグのオブジェクトに衝突した場合
        if (collision.gameObject.CompareTag("Item"))
        {
            itemCount++;
            Destroy(collision.gameObject); // アイテムを削除
        }
        
        // Goalタグのオブジェクトに衝突した場合
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (itemCount >= 4)
            {
                SceneManager.LoadScene("GameClear"); // "GameClear"シーンを読み込む
            }
        }
    }
}