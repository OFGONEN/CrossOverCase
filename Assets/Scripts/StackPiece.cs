using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackPiece : MonoBehaviour
{
    public GameSettings game_settings;
    public EventListenerDelegateResponse event_listener_testStack;
    public BlockInfoGameEvent gameEvent_blockInfo;

  [ Header( "Components" ) ]
    public MeshRenderer meshRenderer;
	public TextMeshProUGUI textRenderer_left;
	public TextMeshProUGUI textRenderer_right;
	public Rigidbody rigidBody;
	public Collider collider;

	StackInfo stack_info;

    private void OnDisable()
    {
		event_listener_testStack.OnDisable();
	}

    public void OnMouseDown()
    {
		gameEvent_blockInfo.Raise( stack_info.grade, stack_info.domain, stack_info.cluster, stack_info.standarddescription );
	}

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
}