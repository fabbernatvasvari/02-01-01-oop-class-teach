
namespace SchoolClassManagmentProject.Models
{
    [Serializable]
    internal class LastGradeModificationErrorException : Exception
    {
        private string v1;
        private string v2;
        private object value;

        public LastGradeModificationErrorException()
        {
        }

        public LastGradeModificationErrorException(string? message) : base(message)
        {
        }

        public LastGradeModificationErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public LastGradeModificationErrorException(string v1, string v2, object value)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.value = value;
        }
    }
}