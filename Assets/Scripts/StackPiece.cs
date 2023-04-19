/* Created by and for usage of FF Studios (2021). */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackPiece : MonoBehaviour
{
#region Fields
    public GameSettings game_settings;
    public EventListenerDelegateResponse event_listener_testStack;

  [ Header( "Components" ) ]
    public MeshRenderer meshRenderer;
	public TextMeshProUGUI textRenderer_left;
	public TextMeshProUGUI textRenderer_right;
	public Rigidbody rigidBody;
	public Collider collider;

	StackInfo stack_info;
#endregion

#region Properties
#endregion

#region Unity API
    private void OnDisable()
    {
		event_listener_testStack.OnDisable();
	}
#endregion

#region API
    public void Spawn( Transform parent, Vector3 position, Vector3 rotation, StackInfo stackInfo )
    {
		transform.parent        = parent;
		transform.localPosition = position;
		transform.eulerAngles   = rotation;

		event_listener_testStack.OnEnable();
		event_listener_testStack.response = OnTestMyStackModeResponse;

		stack_info = stackInfo;

        switch( stack_info.mastery )
        {
            case 0: SpawnAsGlass();
				break;
            case 1: SpawnAsWood();
				break;
            case 2: SpawnAsStone();
				break;
		}
	}

    public void OnTestMyStackModeResponse()
    {
        if( stack_info.mastery == 0 )
        {
			gameObject.SetActive( false );
		}
        else
        {
			rigidBody.isKinematic = false;
			rigidBody.useGravity  = true;
		}
    }
#endregion

#region Implementation
    void SpawnAsGlass()
    {
		meshRenderer.sharedMaterial = game_settings.stack_piece_glass_material;
		textRenderer_left.text      = game_settings.stack_piece_glass_text;
		textRenderer_right.text     = game_settings.stack_piece_glass_text;
		textRenderer_left.color     = game_settings.stack_piece_glass_text_color;
		textRenderer_right.color    = game_settings.stack_piece_glass_text_color;
		collider.sharedMaterial     = game_settings.stack_piece_glass_physicMaterial;
		rigidBody.mass              = game_settings.stack_piece_glass_mass;
	}

    void SpawnAsWood()
    {
		meshRenderer.sharedMaterial = game_settings.stack_piece_wood_material;
		textRenderer_left.text      = game_settings.stack_piece_wood_text;
		textRenderer_right.text     = game_settings.stack_piece_wood_text;
		textRenderer_left.color     = game_settings.stack_piece_wood_text_color;
		textRenderer_right.color    = game_settings.stack_piece_wood_text_color;
		collider.sharedMaterial     = game_settings.stack_piece_wood_physicMaterial;
		rigidBody.mass              = game_settings.stack_piece_wood_mass;    
    }

    void SpawnAsStone()
    {
		meshRenderer.sharedMaterial = game_settings.stack_piece_stone_material;
		textRenderer_left.text      = game_settings.stack_piece_stone_text;
		textRenderer_right.text     = game_settings.stack_piece_stone_text;
		textRenderer_left.color     = game_settings.stack_piece_stone_text_color;
		textRenderer_right.color    = game_settings.stack_piece_stone_text_color;
		collider.sharedMaterial     = game_settings.stack_piece_stone_physicMaterial;
		rigidBody.mass              = game_settings.stack_piece_stone_mass;    
    }
#endregion

#region Editor Only
#if UNITY_EDITOR
#endif
#endregion
}