using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    //Rotation
    private Vector3 currentRotation;
    private Vector3 TargetRotation;

    //Hipfire Recoil
    [SerializeField] private float RecoilX;
    [SerializeField] private float RecoilY; 
    [SerializeField] private float RecoilZ;

    //Setting
    [SerializeField] private float Snappiness;
    [SerializeField] private float ReturnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetRotation = Vector3.Lerp(TargetRotation, Vector3.zero, ReturnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, TargetRotation, Snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        TargetRotation += new Vector3(RecoilX, Random.Range(-RecoilY, RecoilY), Random.Range(-RecoilZ, RecoilZ));
    }
}
