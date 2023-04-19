using System;

[ System.Serializable ]
public class StackInfo : IComparable
{
	public int id;
	public string subject;
	public string grade;
	public int mastery;
	public string domainid;
	public string domain;
	public string cluster;
	public string standardid;
	public string standarddescription;

	public int CompareTo( object obj )
	{
		var target = obj as StackInfo;
		int result = string.Compare( domain, target.domain );

		if( result == 0 )
        {
			result = string.Compare( cluster, target.cluster );

			if( result == 0 )
            {
			    result = string.Compare( standardid, target.standardid );
            }
        }

		return result;
	}

    public override string ToString()
    {
		return "Grade: " + grade + " - Domain: " + domain + " - Cluster: " + cluster + " - StandardId: " + standardid;
	}
}