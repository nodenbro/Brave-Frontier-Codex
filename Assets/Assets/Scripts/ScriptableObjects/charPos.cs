using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Object/Character Data")]

public class charPos : ScriptableObject
{
    public Vector2 position;

    public Vector2 GetCharPos(int id)
    {
        switch (id)
        {
            case 03:
                return new Vector2(-58, 165);
            case 01:
                return new Vector2(80, 92);
            case 02:
                return new Vector2(100, 87);
            case 04:
                return new Vector2(-62, 57);
            case 05:
                return new Vector2(-70, 33);
            default:
                return Vector2.zero;

        }
    }
}
