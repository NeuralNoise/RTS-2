using UnityEngine;

public static class ResourcesWrapper
{
    public static GameObject LoadBlocs(int bloc, int type)
    {
        GameObject result = null;
        string firstPart = string.Empty;
        string secondPart = string.Empty;
        switch(bloc)
        {
            case 1: firstPart = "Blocs/Grass" ; break;
            default: return result;
        }
        switch(type)
        {
            case 0: secondPart = "Top"; break;
            case 1: secondPart = "Left"; break;
            case 2: secondPart = "Right"; break;
            case 3: secondPart = "Front"; break;
            case 4: secondPart = "Back"; break;
            case 5: secondPart = "TopLeft"; break;
            case 6: secondPart = "TopRight"; break;
            case 7: secondPart = "TopFront"; break;
            case 8: secondPart = "TopBack"; break;
            case 9: secondPart = "LeftFront"; break;
            case 10: secondPart = "LeftBack"; break;
            case 11: secondPart = "RightFront"; break;
            case 12: secondPart = "RightBack"; break;
            case 13: secondPart = "TopLeftFront"; break;
            case 14: secondPart = "TopLeftBack"; break;
            case 15: secondPart = "TopRightFront"; break;
            case 16: secondPart = "TopRightBack"; break;
        }
        return Resources.Load(firstPart + secondPart) as GameObject;
    }
}
