using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : MonoBehaviour
{
    public bool halfOfTheLevel { get; private set; }
    public bool halfOfTimeReached { get; private set; }
    public void setHalfOfTheLevel(bool value) {
        halfOfTheLevel = value;
    }
    public void setHalfOfTime(bool value) {
        halfOfTimeReached = value; 
    }
}
