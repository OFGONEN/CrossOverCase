using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "game_settings", menuName = "ScriptableObjects/Game Settings" )]
public class GameSettings : ScriptableObject
{
  [ Header( "Stack Settings" ) ]
    public float stack_offset;
}