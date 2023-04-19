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

  [ Header( "Stack Piece Glass Settings" ) ]
    public Material stack_piece_glass_material;
    public PhysicMaterial stack_piece_glass_physicMaterial;
    public float stack_piece_glass_mass;
    public string stack_piece_glass_text;

  [ Header( "Stack Piece Wood Settings" ) ]
    public Material stack_piece_wood_material;
    public PhysicMaterial stack_piece_wood_physicMaterial;
    public float stack_piece_wood_mass;
    public string stack_piece_wood_text;

  [ Header( "Stack Piece Stone Settings" ) ]
    public Material stack_piece_stone_material;
    public PhysicMaterial stack_piece_stone_physicMaterial;
    public float stack_piece_stone_mass;
    public string stack_piece_stone_text;
}