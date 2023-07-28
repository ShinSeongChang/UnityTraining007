using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance; // �̱����� �Ҵ�� static ����
    public static ResourceManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }


    private static string zombieDataPath = default;

    public ZombieData[] zombieData_default = default;

    // Resources ���� ���ο� �ִ� ������ ������ ���� ==> ���� = Resources �������� �о���� ���� �̸�
    private static string csvFile = "ZombieDatas";


    private void Awake()
    {
        //dataPath = Application.dataPath;
        //zombieDataPath = "Scriptables";
        //zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");
        //zombieData_default = Resources.Load<ZombieData>(zombieDataPath);

        //  Resources ������ �ִ� csv ������ TextAsset ���·� �����Ͽ� �ҷ����� ���� textasset
        //                                                          ZombieSurvival Datas�� csvFile ���� ������ �ִ� �����̱⿡ "/�����̸�"                   
        TextAsset textAsset = Resources.Load<TextAsset>(csvFile + "/ZombieSurvival Datas");

        // csv������ �ؽ�Ʈ�� ��� �о���δ�.
        Debug.Log(textAsset);

        // csv������ �ؽ�Ʈ�� �ະ�� �߶��ְ� �迭�� ��´�. => text.Spilt("\n")
        // Trim()�� ������� ���� ���ִ� ��.
        string[] result = textAsset.text.Trim().Split("\n");

        // ���� �����Ǵ� ���� ������
        zombieData_default = new ZombieData[result.Length-1];

        for (int i = 0; i < zombieData_default.Length; i++)
        {
            Debug.Log(i+") ����");
            Debug.Log(result[i+1]+"1�ܰ�");

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

        //Debug.LogFormat("���� save data�� ���⿡�ٰ� �����ϴ� ���� ����̴� -> {0}", Application.persistentDataPath);

        // AES - 256 ��ȣȭ�� ���� ������ ���� ��ȣȭ

    }

    // Start is called before the first frame update

}
