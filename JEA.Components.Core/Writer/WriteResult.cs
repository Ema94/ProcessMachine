namespace JEA.Components.Core.Writer
{
    public class WriterResult<TObject>
    {
        public TObject Object { get; set; }
        public WriterTypes ActionType { get; set; }
        public bool Success { get; set; }
    }
}
