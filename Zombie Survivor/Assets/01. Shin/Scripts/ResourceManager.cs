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
    public ZombieData zombieData_default = default;

    private void Awake()
    {
        //dataPath = Application.dataPath;
        zombieDataPath = "Scriptables";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");

        //ZombieData zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);
        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);

        //Debug.LogFormat("Zombie data path : {0}", zombieDataPath);
        Debug.LogFormat("zombie data : {0}, {1}, {2}", zombieData_default.health, zombieData_default.damage, zombieData_default.speed);

        Debug.LogFormat("게임 save data를 여기에다가 저장하는 것이 상식이다 -> {0}", Application.persistentDataPath);

        // AES - 256 암호화는 현재 뚫을수 없는 암호화

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
