using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject redRain;

    void Start()
    {

        //Invoke("MakeItRainBlood", 5f);
        Instantiate(redRain);
        
    }

    //void MakeItRainBlood()
    //{

    //    Instantiate(redRain);
    //}


}
