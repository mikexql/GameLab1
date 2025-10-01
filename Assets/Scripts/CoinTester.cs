using UnityEngine;

public class CoinTester : MonoBehaviour
{
    public Coin coinToTest; // Drag the coin GameObject here in inspector
    
    void Update()
    {
        // Press 'C' key to test coin collection
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (coinToTest != null && !coinToTest.collected)
            {
                Debug.Log("Testing coin collection!");
                coinToTest.collected = true;
            }
        }
    }
}