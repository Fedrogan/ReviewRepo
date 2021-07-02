using UnityEngine;

public class MovingSymbols : MonoBehaviour
{
    [SerializeField] private Symbol[] allSymbols;
    [SerializeField] private Sprite[] allSymbolImages;
    [SerializeField] private MovingReels allReels;
    [SerializeField] private FinalResult FinalResult;
    [SerializeField] private float symbolHeight;
    [SerializeField] private int symbolsCount;
    private readonly int exitPosition = 223;
    private bool slowDownIsActive;

    void Start()
    {
    }

    void ChangeSymbolAndSprite(bool slowDownIsActive)
    {
        if (!slowDownIsActive)
        {
            for (int i = 0; i < allSymbols.Length; i++)
            {
                var symbol = allSymbols[i];
                if (symbol.transform.position.y <= exitPosition)
                {
                    symbol.transform.position += Vector3.up * symbolHeight * symbolsCount;
                    symbol.SymbolImage.sprite = allSymbolImages[Random.Range(0, allSymbolImages.Length)];
                };
            }
        }
        if (slowDownIsActive)
        {
            for (int i = 0; i < allSymbols.Length; i++)
            {
                var symbol = allSymbols[i];
                int symbolId = allSymbols[i].SymbolData.SymbolId;
                int currentFinalScreen = FinalResult.CurrentFinalScreen;
                int finalImageId = FinalResult.GetFinalImageId(symbolId);
                if (symbol.transform.position.y <= exitPosition)
                {
                    symbol.transform.position += Vector3.up * symbolHeight * symbolsCount;
                    symbol.SymbolImage.sprite = allSymbolImages[finalImageId];
                };
            }
        }
    }
     
    void Update()
    {
        slowDownIsActive = allReels.SlowDownIsActive;
        ChangeSymbolAndSprite(slowDownIsActive);
    }
}
