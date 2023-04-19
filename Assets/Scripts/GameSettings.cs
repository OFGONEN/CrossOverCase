using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "game_settings", menuName = "ScriptableObjects/Game Settings" )]
public class GameSettings : ScriptableObject
{
  [ Header( "Stack Settings" ) ]
    public float stack_offset;

  [ Header( "Stack Piece Settings" ) ]
    public float stack_piece_offset_vertical;
    public float stack_piece_offset_horizontal;
    public int stack_piece_placement_mod;
}