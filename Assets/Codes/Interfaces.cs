using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{

}

public interface ITouchable
{
    void touch(int type);
}

public interface ICheckpointable
{
    void check(int index);
}