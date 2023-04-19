using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "event_blockUI", menuName = "ScriptableObjects/Block UI Game Event" ) ]
public class BlockInfoGameEvent : GameEvent
{
	public string block_info_gradeLevel;
	public string block_info_domain;
	public string block_info_cluster;
	public string block_info_standartDescription;

    public void Raise( string gradeLevel, string domain, string infoCluster, string standartDescription )
    {
		block_info_gradeLevel          = gradeLevel;
		block_info_domain              = domain;
		block_info_cluster             = infoCluster;
		block_info_standartDescription = standartDescription;

		Raise();
	}
}