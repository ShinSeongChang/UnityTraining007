using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance; // 싱글톤이 할당될 static 변수
    public static ResourceManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }


    private static string zombieDataPath = default;

    public ZombieData[] zombieData_default = default;

    // Resources 폴더 내부에 있는 파일을 저장할 변수 ==> 변수 = Resources 폴더에서 읽어들일 파일 이름
    private static string csvFile = "ZombieDatas";


    private void Awake()
    {
        //dataPath = Application.dataPath;
        //zombieDataPath = "Scriptables";
        //zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");
        //zombieData_default = Resources.Load<ZombieData>(zombieDataPath);

        //  Resources 폴더에 있는 csv 파일을 TextAsset 형태로 변형하여 불러들일 변수 textasset
        //                                                          ZombieSurvival Datas는 csvFile 변수 하위에 있는 파일이기에 "/파일이름"                   
        TextAsset textAsset = Resources.Load<TextAsset>(csvFile + "/ZombieSurvival Datas");

        // csv파일의 텍스트를 모두 읽어들인다.
        Debug.Log(textAsset);

        // csv파일의 텍스트를 행별로 잘라주고 배열에 담는다. => text.Spilt("\n")
        // Trim()은 빈공간을 제거 해주는 것.
        string[] result = textAsset.text.Trim().Split("\n");

        // 새로 생성되는 좀비 데이터
        zombieData_default = new ZombieData[result.Length-1];

        for (int i = 0; i < zombieData_default.Length; i++)
        {
            Debug.Log(i+") 생성");
            Debug.Log(result[i+1]+"1단계");

            zombieData_default[i] = new ZombieData();

            string[] result2 = result[i+1].Split(",");

            zombieData_default[i].health = float.Parse(result2[1].ToString());
            zombieData_default[i].damage = float.Parse(result2[2].ToString());
            zombieData_default[i].speed = float.Parse(result2[3].ToString());
            //zombieData_default[i].skinColor = ColorUtility.TryParseHtmlString(result2[4], out color);
            ColorUtility.TryParseHtmlString(result2[4], out zombieData_default[i].skinColor);
        }

        //ZombieData zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);

        //Debug.LogFormat("Zombie data path : {0}", zombieDataPath);
        // Debug.LogFormat("zombie data : {0}, {1}, {2}", zombieData_default.health, zombieData_default.damage, zombieData_default.speed);

        //Debug.LogFormat("게임 save data를 여기에다가 저장하는 것이 상식이다 -> {0}", Application.persistentDataPath);

        // AES - 256 암호화는 현재 뚫을수 없는 암호화

    }

    // Start is called before the first frame update

}
