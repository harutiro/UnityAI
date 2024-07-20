using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject itemPrefab; // 生成するアイテムのPrefab
    public int itemCount = 4; // 生成するアイテムの数

    // 範囲指定
    public float xMin = -19f;
    public float xMax = 19f;
    public float zMin = -10f;
    public float zMax = 10f;
    public float yPosition = 1f; // Y座標

    void Start()
    {
        GenerateItems();
    }

    void GenerateItems()
    {
        for (int i = 0; i < itemCount; i++)
        {
            // ランダムな位置を計算
            float xPosition = Random.Range(xMin, xMax);
            float zPosition = Random.Range(zMin, zMax);
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);

            // アイテムの生成
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}