using Firebase.Unity.Editor;
using UnityEngine;
using Newtonsoft.Json;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;
using Firebase.Auth;
using System;
using UnityEditor;

public class DataSave : MonoBehaviour
{      
    FirebaseAuth firebaseAuth;
    FirebaseApp firebaseApp;
    DatabaseReference databaseReference;

    private void Awake()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance;
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        firebaseApp.SetEditorDatabaseUrl("https://pria-mainserver.firebaseio.com/");
        // FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("testrealtimedatebase-aae7a@appspot.gserviceaccount.com");        
        FirebaseApp.DefaultInstance.SetEditorP12FileName("pria-mainserver-750ca53b8350.p12");
        FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    /// <summary>
    /// Firebase 테이블
    /// </summary>

    public class JoinAccountDateSave
    {
        public string itemName;
        public string positionX;
        public string positionY;
        public string positionZ;
        public string rotationY;
        
        public JoinAccountDateSave(string localitemName, string localpositionX,
                                   string localpositionY, string localpositionZ,
                                   string rotationY)
        {
            this.itemName = localitemName;
            this.positionX = localpositionX;
            this.positionY = localpositionY;
            this.positionZ = localpositionZ;
            this.rotationY = rotationY;          
        }
    }

    /// <summary>
    /// Firebase에 저장할 오브젝터 데이터
    /// </summary>

    GameObject[] dataArray;
    string str;
    string a;
    string b;
    string c;
    string d;

    public void SendingData()
    {
        dataArray = GameObject.FindGameObjectsWithTag("Saveable");

        foreach (GameObject resource in dataArray)
        {
            //GameObject resource = dataArray;
            
            str = resource.name;
            str = str.Substring(0, str.Length - 7); // Hierarchy에 저장되어있어야한다.
            
            resource.transform.parent = gameObject.transform;
            a = $"{resource.transform.localPosition.x}";
            b = $"{resource.transform.localPosition.y}";
            c = $"{resource.transform.localPosition.z}";
            d = $"{resource.transform.eulerAngles.y}";

            Debug.Log("작동된다.");
            SaveData();
        }
    }

    /// <summary>
    /// Class에 만든 데이터 베이스 테이블 정보를 Firebase DB에 저장
    /// </summary>

    public void SaveData()
    {
        JoinAccountDateSave itemData = new JoinAccountDateSave(str, a, b, c, d);        
        string json = JsonConvert.SerializeObject(itemData);       
        databaseReference.Child("Prefab").Child("Saveable").SetRawJsonValueAsync(json);
    }
    
    /// <summary>
    /// Firebase RealtimeDB에 저장된 데이터 값을 찾고 불러오기
    /// </summary>
    public string snm;
    public string spx;
    public string spy;
    public string spz;
    public string sry;

    public float fpx;
    public float fpy;
    public float fpz;
    public float fry;
    
    public void SearchSaveData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Prefab").OrderByChild("low")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("실패하였습니다.");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    foreach (var item in snapshot.Children)
                    {                                                
                        snm = item.Child("itemName").Value.ToString();
                        Debug.Log(snm);
                        
                        spx = item.Child("positionX").Value.ToString();
                        Debug.Log(spx);
                        fpx = float.Parse(spx);                    

                        spy = item.Child("positionY").Value.ToString();
                        Debug.Log(spy);
                        fpy = float.Parse(spy);

                        spz = item.Child("positionZ").Value.ToString();
                        Debug.Log(spz);
                        fpz = float.Parse(spz);

                        sry = item.Child("rotationY").Value.ToString();
                        Debug.Log(sry);
                        fry = float.Parse(sry);
                    }
                }
            });    
    }

    /// <summary>
    /// Project의 Resources파일안에있는 Prefab들고오기
    /// </summary>
    public GameObject nowObject;
    public GameObject ndkObject;

    public void LoadData(string obejectName, float px, float py, float pz, float ry)
    {
        ndkObject = Resources.Load(obejectName,typeof(GameObject)) as GameObject;
        Instantiate<GameObject>(ndkObject, new Vector3(px, py, pz),
                         Quaternion.Euler(0, ry, 0));
        //Instantiate(Resources.Load("Cube") as GameObject);
    }

    /// <summary>
    /// LoadData 메서드 실행
    /// </summary>
    public void onCreateFromResouces()
    {
        LoadData(snm, fpx, fpy, fpz, fry);
    }

}
