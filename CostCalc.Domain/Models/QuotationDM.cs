using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;
using System.Net;

namespace CostCalc.Domain.Models
{
    public class QuotationDM : BaseDM<int>
    {
        public QuotationDM(GlobalErrors globalErrors) : base(globalErrors)
        {
            IP_Address = Get_IP();

        }
        public int ID { get; set; }
        public int FromLangID { get; set; }
        public int ToLangID { get; set; }
        public decimal WordCount { get; set; }
        public string IP_Address { get; set; }
        public bool? IsRush { get; set; }
        public DateTime RushDate { get; set; }
        public List<QuotaionDetailsDM> QuotaionDetailsList { get; set; }
        public SubjectDM Subject { get; set; }
        public List<CategoryDM> CategoryDMList { get; set; }


        public string Get_IP()
        {
            string ip = "";
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            ip = addr[1].ToString();
            return ip;
        }
    }
}
