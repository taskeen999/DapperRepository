namespace DapperRepository.BusinessLayer.Entities
{
    public class DtoResponse
    {
        public bool status{ get;set; }  
        public string Message{ get;set; }
        public string ErrorMessage { get; set; }
        public  object data{ get;set; }

    }
}
