using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "stack_creator", menuName = "ScriptableObjects/Stack Creator" )]
public class StackCreator : ScriptableObject 
{
    public GameSettings game_settings;
    public StackInfoLoader stack_info_loader;
    public Stack stack_prefab;

    List< Stack > stack_list;

	public int StackCount => stack_list.Count;

	public void CreateStacks()
    {
		var stackInfoDictionary = stack_info_loader.StackInfoDictionary;

        stack_list = new List< Stack >( stackInfoDictionary.Keys.Count );

        foreach( var stackInfoPair in stackInfoDictionary )
        {
			var stack = GameObject.Instantiate( stack_prefab );
			stack.CreateTheStack( stackInfoPair.Value );

			stack_list.Add( stack );
		}

		PositionStacks();
	}

    public void PositionStacks()
    {
		var startingPoint = Vector3.left * ( stack_list.Count - 1 ) / 2f * game_settings.stack_offset;

        for( var i = 0; i < stack_list.Count; i++ )
        {
			stack_list[ i ].transform.position = startingPoint + game_settings.stack_offset * Vector3.right * i;
		}
	}

	public Vector3 GetStackPosition( int index )
	{
		int safeIndex = index % stack_list.Count;
		return stack_list[ safeIndex ].transform.position;
	}
}