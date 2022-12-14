using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Sklepus : MonoBehaviour
{
    [SerializeField] private Transform[] DayOnePath;
    [SerializeField] private Transform[] DayTwoPath;

    [SerializeField] private GameObject objBloodPath;
    [SerializeField] private GameObject objBloodSpawnPoint;

    private GameObject _bloodParentAfterSpawn;
    private Transform[] _todayPath;

    private Boolean _emitBlood;
    private void EmitBlood()
    {
        if (!gameObject.activeSelf) return;
        _emitBlood = true;
        _bloodParentAfterSpawn = new GameObject();
        _bloodParentAfterSpawn.name = "Bloods";
        StartCoroutine(EmitBloodCor());
    }

    Single _timePassed = 0f;
    private IEnumerator EmitBloodCor()
    {
        Single addTime = 0.032f;
        _timePassed += _timePassed;
        yield return new WaitForSeconds(addTime);
        GameObject blood = Instantiate(objBloodPath);
        blood.transform.position = objBloodSpawnPoint.transform.position;
        blood.transform.SetParent(_bloodParentAfterSpawn.transform);
        blood.transform.forward = transform.forward;
        if (_emitBlood)
            StartCoroutine(EmitBloodCor());
        if (_timePassed > DayManager.DAY_TIME)
            _emitBlood = false;
    }

    public void PlayDaySequence(Int32 day)
    {
        if (!gameObject.activeSelf) return;

        if (day == 0)
        {
            _todayPath = DayOnePath;
            LeanTween.delayedCall(3.76f, () =>
            {
                LeanTween.rotateAroundLocal(gameObject, Vector3.up, 107f, 1f);
            });
            //EmitBlood();
        }
        else
        {
            _todayPath = DayTwoPath;
            EmitBlood();
        }

        LeanTween.delayedCall(5.2f, () =>
        {
            LTDescr lt = LeanTween.moveSpline(gameObject, _todayPath.Select(point => new Vector3(point.transform.position.x,
                transform.position.y, point.transform.position.z)).ToArray(), DayManager.DAY_TIME / 3f);
        });

    }

    // Start is called before the first frame update
    void Start()
    {
        _lastFrame = transform.position;
    }

    Vector3 _lastFrame;
    void Update()
    {
        Vector3 newForward = transform.position - _lastFrame;
        if (newForward != Vector3.zero)
        {
            transform.forward = newForward;
        }
        _lastFrame = transform.position;

    }
}
