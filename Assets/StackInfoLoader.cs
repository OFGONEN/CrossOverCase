using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

[ CreateAssetMenu( fileName = "stack_info_loader", menuName = "ScriptableObjects/StackInfoLoader" )]
public class StackInfoLoader : ScriptableObject
{
	Dictionary< string, List< StackInfo > > stack_info_dictionary;

	public Dictionary< string, List< StackInfo > > StackInfoDictionary => stack_info_dictionary; 

	public void LoadStackInformations()
    {
		// Get the Stack Info using the given API
		HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create
( string.Format( "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack" ) );
		webRequest.Method = "GET";

		HttpWebResponse webResponse  = ( HttpWebResponse )webRequest.GetResponse();
		Stream          webAnswer    = webResponse.GetResponseStream();
		StreamReader    streamReader = new StreamReader( webAnswer );

		// Desereleiaze the Json string to a wrapper object
		var stackInfoWrapper = JsonUtility.FromJson< StackInfoWrapper >( "{\"stack_info_array\":" + streamReader.ReadToEnd() + "}" );

		InitializeStackInfoDictionary( stackInfoWrapper );
		SortStackInfoDictionary();
	}

	// Sort stack informations into grades
	public void InitializeStackInfoDictionary( StackInfoWrapper stackInfoWrapper )
	{
		stack_info_dictionary = new Dictionary< string, List< StackInfo > >();

		for( var i = 0; i < stackInfoWrapper.stack_info_array.Length; i++ )
		{
			List< StackInfo > stackInfoList;
			StackInfo stackInfo = stackInfoWrapper.stack_info_array[ i ];

			if( stack_info_dictionary.TryGetValue( stackInfo.grade, out stackInfoList ) )
			{
				stackInfoList.Add( stackInfoWrapper.stack_info_array[ i ] );
			}
			else
			{
				stackInfoList = new List< StackInfo >();
				stackInfoList.Add( stackInfoWrapper.stack_info_array[ i ] );
				stack_info_dictionary.Add( stackInfo.grade, stackInfoList );
			}
		}
	}

	// Sort stack informations in a grade
	public void SortStackInfoDictionary()
	{
		foreach( var stackInfoPair in stack_info_dictionary )
		{
			var stackInfoList = stackInfoPair.Value;
			stackInfoList.Sort();
		}
	}
}

[ System.Serializable ]
public class StackInfoWrapper
{
	public StackInfo[] stack_info_array;
}