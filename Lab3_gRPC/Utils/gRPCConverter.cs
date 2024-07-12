using Google.Protobuf.WellKnownTypes;

namespace Lab3_gRPC.Utils
{
    public class gRPCConverter
    {
        public static Protos.Status convertToProtoStatus(Models.Status status)
        {
            Protos.Status result;
            switch (status)
            {
                case Models.Status.Absent:
                    result = Protos.Status.Absent;
                    break;
                case Models.Status.Attended:
                    result = Protos.Status.Attended;
                    break;
                default:
                    result = Protos.Status.NotYet;
                    break;
            }
            return result;
        }
        public static Models.Status convertToModelStatus(Protos.Status status)
        {
            Models.Status result;
            switch (status)
            {
                case Protos.Status.Absent:
                    result = Models.Status.Absent;
                    break;
                case Protos.Status.Attended:
                    result = Models.Status.Attended;
                    break;
                default:
                    result = Models.Status.NotYet;
                    break;
            }
            return result;
        }
        public static Timestamp toTimestamp(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                dateTime = dateTime.ToUniversalTime();
            }

            return Timestamp.FromDateTime(dateTime);
        }
    }
}
