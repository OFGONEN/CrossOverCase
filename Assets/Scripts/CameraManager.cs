
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public StackCreator stack_creator;
	public GameSettings game_settings;

	public EventListenerDelegateResponse event_camera_track_next;
	public EventListenerDelegateResponse event_camera_track_prev;

	Vector3 track_position;
	int track_index;
	float track_rotate_delta;
	bool track_dragging;
	Vector3 track_drag_origin;

	private void OnDisable()
    {
		event_camera_track_next.OnDisable();
		event_camera_track_prev.OnDisable();
	}

	private void Start()
    {
		event_camera_track_next.OnEnable();
		event_camera_track_prev.OnEnable();

		event_camera_track_next.response = TrackNextStack;
		event_camera_track_prev.response = TrackPrevStack;

		//Track random stack on Start
		track_index = Random.Range( 0, stack_creator.StackCount );
		TrackStack( track_index );
	}

    private void Update()
    {
        if( Input.GetMouseButton( 0 ) )
        {
            if( track_dragging == false )
            {
				track_dragging    = true;
				track_drag_origin = Input.mousePosition;
			}
		}
        else 
        {
			track_dragging = false;
		}

        if( track_dragging )
        {
			var delta = Input.mousePosition - track_drag_origin;

			var rotateDelta = delta.x * Time.deltaTime * game_settings.camera_rotate_speed;

			if( Mathf.Abs( track_rotate_delta + rotateDelta ) < game_settings.camera_rotate_clamp )
            {
			    transform.RotateAround( track_position, Vector3.up, rotateDelta );
			    transform.LookAt( track_position, Vector3.up );

				track_rotate_delta += rotateDelta;
			}

			// Correct the rotation after look at
			var rotation = transform.eulerAngles;
			rotation.x = 0;
			rotation.z = 0;
			transform.eulerAngles = rotation;
		}
    }

    void TrackNextStack()
    {
		track_index = ( track_index + 1 ) % stack_creator.StackCount;
		TrackStack( track_index );
	}

	void TrackPrevStack()
	{
		track_index = ( track_index - 1 ) % stack_creator.StackCount;
		TrackStack( track_index );
	}

    void TrackStack( int index )
    {
		track_index        = index;
		track_position     = stack_creator.GetStackPosition( track_index );
		transform.position = track_position + game_settings.camera_offset;
		transform.rotation = Quaternion.identity;
		track_rotate_delta = 0;
	}
}