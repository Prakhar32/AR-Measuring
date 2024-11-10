using TMPro;
using UnityEngine;

public class AssociatedPair : MonoBehaviour
{
    private Convertor _convertor;
    private LineRenderer _lineRendered;

    private GameObject _point1;
    private GameObject _point2;
    private Vector3 normal;
    private bool bothObjectsSet;
    private TextMeshPro _3DText;
    public void SetConvertor(Convertor convertor) {  _convertor = convertor; }

    public void FirstOfPairSet(GameObject point)
    {
        _point1 = point;
        _point1.transform.parent = gameObject.transform;  
    }

    public void SecondOfPairSet(GameObject point, Vector3 normal)
    {
        _point2 = point;
        _point2.transform.parent = gameObject.transform;
        bothObjectsSet = true;
        initialiseTextObject();
        this.normal = normal;
        _lineRendered.positionCount = 2;
        _lineRendered.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        _lineRendered.startWidth = 0.1f;
        _lineRendered.enabled = true;
    }

    void initialiseTextObject()
    {
        GameObject textObject = new GameObject();
        textObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        textObject.transform.parent = gameObject.transform;
        _3DText = textObject.AddComponent<TextMeshPro>();
        _3DText.alignment = TextAlignmentOptions.Center;
        //_3DText.material = new Material(Shader.Find("TextMeshPro/DistanceFieldOverlay"));
        _3DText.fontSize = 8;
    }

    void Start()
    {
        if(_convertor == null)
        {
            Destroy(gameObject);
            throw new MissingReferenceException("Convertor missing");
        }

        if(GetComponent<LineRenderer>() == null) 
            gameObject.AddComponent<LineRenderer>();
        _lineRendered = GetComponent<LineRenderer>();
        _lineRendered.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bothObjectsSet)
            return;
        Vector3 pointA = _point1.transform.position;
        Vector3 pointB = _point2.transform.position;
        _lineRendered.SetPosition(0, pointA);
        _lineRendered.SetPosition(1, pointB);
        float distance = Vector3.Distance(pointA, pointB);
        
        Vector3 directionVector = (pointB - pointA);
        Vector3 upDirection = Vector3.Cross(directionVector, normal).normalized;
        Quaternion rotation = Quaternion.LookRotation(-normal, upDirection);
        _3DText.transform.rotation = rotation;
        _3DText.transform.position = (pointA + directionVector * 0.5f) + upDirection * 0.008f;
        _3DText.text = _convertor.Convert(distance * 100f);
    }
}
