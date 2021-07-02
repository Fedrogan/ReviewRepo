using UnityEngine;


[CreateAssetMenu(fileName = "New SymbolData", menuName = "Symbol Data", order = 51)]
public class SymbolData : ScriptableObject
{
    [SerializeField] private int symbolId;
    [SerializeField] private Sprite symbolImage;
 
    public int SymbolId => symbolId;
}
