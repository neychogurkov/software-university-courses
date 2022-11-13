namespace StreamProgress
{
    public interface IFile
    {
        public int Length { get; }

        public int BytesSent { get; }
    }
}
