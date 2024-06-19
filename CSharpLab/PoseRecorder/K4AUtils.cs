using System.Numerics;
using Microsoft.Azure.Kinect.BodyTracking;

public static class K4AUtils
{
    public static IEnumerable<Vector3> GetJointNormalizedVectors(Skeleton bodySkelton)
    {
        var jointPositions = from jointIndex in Enumerable.Range(0, (int)JointId.Count - 1)
                             let joint = bodySkelton.GetJoint(jointIndex)
                             select joint.Position;

        var jointPositionArray = jointPositions.ToArray();
        var jointPositionOrigin = jointPositionArray[(int)JointId.Pelvis];
        var jointVectorFactorBase = jointPositionArray[(int)JointId.Neck];
        var jointVectorFactor = 1 / (jointPositionOrigin - jointVectorFactorBase).Length();

        var jointNormalizedVectors = from jointPosition in jointPositionArray
                                     let jointVector = jointPosition - jointPositionOrigin
                                     select jointVector * jointVectorFactor;

        return jointNormalizedVectors;
    }
}
