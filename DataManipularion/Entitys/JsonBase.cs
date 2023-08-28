namespace DataManipularion.Entitys
{
    public class JsonBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }


        public void SetError(string mensage) { 
            Success = false;
            Message = mensage;
        }
    }
}
