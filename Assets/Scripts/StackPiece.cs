/* Created by and for usage of FF Studios (2021). */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPiece : MonoBehaviour
{
#region Fields
  [ Header( "Components" ) ]
    public MeshRenderer mesh_renderer;

    StackInfo stack_info;
#endregion

#region Properties
#endregion

#region Unity API
#endregion

#region API
    public void Spawn( Transform parent, Vector3 position, Vector3 rotation, StackInfo stackInfo )
    {
		transform.parent        = parent;
		transform.localPosition = position;
		transform.eulerAngles   = rotation;

		stack_info = stackInfo;
	}
#endregion

#region Implementation
#endregion

#region Editor Only
#if UNITY_EDITOR
#endif
#endregion
}
