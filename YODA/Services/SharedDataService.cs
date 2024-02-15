using YODA.Repos.Models;

namespace YODA.Services
{
    public class SharedDataService
    {
        public int UserID { get; set; }
        public string UserName { get; set;}
        public string Password { get; set;}
        public int BusinessUnitID { get; set; }
        public int AccessTypeID { get; set; }
        public string capexid { get; set; }
        public int EmployeeID { get; set; }
        public int UserEmployeeID { get; set; }

        public List<EmployeeWorkRecord> EmployeeWorkRecords = new List<EmployeeWorkRecord>();
        public List<AccessLinking> accessLinkings = new List<AccessLinking>();

        public short? newUser { get; set; }

        public int disciplineNoteNum { get; set; }

    }
}
