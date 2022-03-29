namespace HIS.Routes
{
    public static class ApiRoutes
    {
        public const string Domain = "api";


        public static class OrderHub
        {
            public const string Dept2 = Domain + "/OrderHub/GetDept";
            public const string Doctor = Domain + "/OrderHub/GetDoctor";
            public const string Schedule = Domain + "/OrderHub/Schedule";
            public const string Source = Domain + "/OrderHub/Source";
            public const string QueryCard = Domain + "/OrderHub/QueryCard";
            public const string BuildCard = Domain + "/OrderHub/BuildCard";
            public const string AddOrder = Domain + "/OrderHubAddOrder";
            public const string CancelOrder = Domain + "/OrderHub/CancelOrder";
            public const string PayAmt = Domain + "/OrderHub/PayAmt";
            public const string RefundAmt = Domain + "/OrderHub/RefundAmt";
        }
        public static class Manager
        {
            public const string SetSchedule = Domain + "/Manager/SetSchedule";
        }
        public static class Update
        {
            public const string Client = Domain + "/Update/Client";
        }
    }
}
