using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharPosLoader : MonoBehaviour
{
    public Transform parentGameObject;
    public string path;
    public RectTransform position;
    private GameObject prefabObject;


    //[SerializeField] private AssetReferenceGameObject karlPosReference;

    public async void LoadPositionPrefab()
    {
        if (prefabObject == null)
        {
            Debug.Log(path);

            GameObject prefab = await Addressables.InstantiateAsync(path, parentGameObject).Task;
            //handle.Completed += OnKarlPosLoaded;

            //karlPosReference.InstantiateAsync();

            prefabObject = prefab;

            position = prefabObject.GetComponent<RectTransform>();

            Debug.Log("I think it worked?");

            Debug.Log(position);

            //position = handle.Result.GetComponent<RectTransform>();



        }
        else
        {
            Addressables.ReleaseInstance(prefabObject);
            prefabObject = null;
        }

    }
    //private void OnKarlPosLoaded(AsyncOperationHandle<GameObject> handle)
    //{
    //    if (handle.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        //Instantiate(handle.Result);
    //        prefabObject = handle.Result;
    //        Instantiate(prefabObject);
    //        position = handle.Result.GetComponent<RectTransform>();
    //        Debug.Log(position);
    //        // You can now use karlPosInstance as needed
    //    }
    //    else
    //    {
    //        Debug.LogError("Failed to load KarlPos.");
    //    }
    //}

}
