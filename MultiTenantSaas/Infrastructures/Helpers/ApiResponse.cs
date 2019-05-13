namespace MultiTenantSaas.Infrastructures.Helpers
{
    internal class ApiResponse
    {
        public ApiResponse()
        {

        }

        public int Status { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}