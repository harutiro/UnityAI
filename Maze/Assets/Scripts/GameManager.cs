using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] stages; // ステージの配列

    private void Start()
    {
        EnableRandomStage();
    }

    // ランダムにステージを選んで有効化するメソッド
    private void EnableRandomStage()
    {
        if (stages.Length == 0)
        {
            Debug.LogError("ステージが設定されていません。");
            return;
        }

        int randomIndex = Random.Range(0, stages.Length);
        GameObject selectedStage = stages[randomIndex];

        // 全てのステージを非アクティブにする
        foreach (GameObject stage in stages)
        {
            stage.gameObject.SetActive(false);
        }

        // 選択したステージをアクティブにする
        selectedStage.gameObject.SetActive(true);
        Debug.Log("選ばれたステージ: " + selectedStage.name);
    }
}
