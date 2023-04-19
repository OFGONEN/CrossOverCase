using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stack : MonoBehaviour
{
	public GameSettings game_settings;
	public StackPiece stack_piece_prefab;
	public TextMeshProUGUI textRenderer;

	Vector3 stack_piece_placement_rotation;
	Vector3 stack_piece_placement_point;
	Vector3 stack_piece_placement_offset;

	delegate void ChangePlacement();
	ChangePlacement changePlacement;

	public void CreateTheStack( List< StackInfo > stackInfoList )
    {
		textRenderer.text = stackInfoList[ 0 ].grade;

		float stackPieceVerticalPosition = 0;

		stack_piece_placement_rotation = Vector3.zero;
		stack_piece_placement_point    = Vector3.left * ( game_settings.stack_piece_placement_mod - 1 ) / 2f * game_settings.stack_piece_offset_horizontal;
		stack_piece_placement_offset   = Vector3.right * game_settings.stack_piece_offset_horizontal;

		changePlacement = ChangePlacementToRight;

		for( var i = 0; i < stackInfoList.Count; i++ )
        {
			int mod = i % game_settings.stack_piece_placement_mod;

			var stackPiece    = GameObject.Instantiate( stack_piece_prefab );
			var stackPosition = stack_piece_placement_point + stack_piece_placement_offset * mod;

			stackPosition.y = stackPieceVerticalPosition;

			stackPiece.Spawn( transform, stackPosition, stack_piece_placement_rotation, stackInfoList[ i ] );

            if( ( mod + 1 ) % game_settings.stack_piece_placement_mod == 0 )
            {
				stackPieceVerticalPosition += game_settings.stack_piece_offset_vertical;
				changePlacement();
			}
		}
    }

    public void ChangePlacementToForward()
    {
		stack_piece_placement_rotation = Vector3.zero;
		stack_piece_placement_point    = Vector3.left * ( game_settings.stack_piece_placement_mod - 1 ) / 2f * game_settings.stack_piece_offset_horizontal;
		stack_piece_placement_offset   = Vector3.right * game_settings.stack_piece_offset_horizontal;

		changePlacement = ChangePlacementToRight;
	}

    public void ChangePlacementToRight()
    {
		stack_piece_placement_rotation = Vector3.up * 90f;
		stack_piece_placement_point    = Vector3.back * ( game_settings.stack_piece_placement_mod - 1 ) / 2f * game_settings.stack_piece_offset_horizontal;
		stack_piece_placement_offset   = Vector3.forward * game_settings.stack_piece_offset_horizontal;

		changePlacement = ChangePlacementToForward;
	}
}