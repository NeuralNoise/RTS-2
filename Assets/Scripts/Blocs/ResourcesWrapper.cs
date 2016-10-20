using UnityEngine;

public static class ResourcesWrapper
{
    static GameObject GrassTop = Resources.Load("Blocs/GrassTop") as GameObject;
    static GameObject GrassLeft = Resources.Load("Blocs/GrassLeft") as GameObject;
    static GameObject GrassRight = Resources.Load("Blocs/GrassRight") as GameObject;
    static GameObject GrassFront = Resources.Load("Blocs/GrassFront") as GameObject;
    static GameObject GrassBack = Resources.Load("Blocs/GrassBack") as GameObject;
    static GameObject GrassTopLeft = Resources.Load("Blocs/GrassTopLeft") as GameObject;
    static GameObject GrassTopRight = Resources.Load("Blocs/GrassTopRight") as GameObject;
    static GameObject GrassTopFront = Resources.Load("Blocs/GrassTopFront") as GameObject;
    static GameObject GrassTopBack = Resources.Load("Blocs/GrassTopBack") as GameObject;
    static GameObject GrassLeftFront = Resources.Load("Blocs/GrassLeftFront") as GameObject;
    static GameObject GrassLeftBack = Resources.Load("Blocs/GrassLeftBack") as GameObject;
    static GameObject GrassRightFront = Resources.Load("Blocs/GrassRightFront") as GameObject;
    static GameObject GrassRightBack = Resources.Load("Blocs/GrassRightBack") as GameObject;
    static GameObject GrassTopLeftFront = Resources.Load("Blocs/GrassTopLeftFront") as GameObject;
    static GameObject GrassTopLeftBack = Resources.Load("Blocs/GrassTopLeftBack") as GameObject;
    static GameObject GrassTopRightFront = Resources.Load("Blocs/GrassTopRightFront") as GameObject;
    static GameObject GrassTopRightBack = Resources.Load("Blocs/GrassTopRightBack") as GameObject;



    public static GameObject LoadBlocs(int bloc, int type)
    {
        if(bloc == 1)
        {
            switch(type)
            {
                case 0: return GrassTop;
                case 1: return GrassLeft;
                case 2: return GrassRight;
                case 3: return GrassFront;
                case 4: return GrassBack;
                case 5: return GrassTopLeft;
                case 6: return GrassTopRight; 
                case 7: return GrassTopFront;
                case 8: return GrassTopBack;
                case 9: return GrassLeftFront;
                case 10: return GrassLeftBack;
                case 11: return GrassRightFront;
                case 12: return GrassRightBack;
                case 13: return GrassTopLeftFront;
                case 14: return GrassTopLeftBack;
                case 15: return GrassTopRightFront;
                case 16: return GrassTopRightBack;
                default: return null;
            }
        }
        else
        {
            return null;
        }
    }
}
