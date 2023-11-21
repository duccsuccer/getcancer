using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone
{
    internal class Phone
    {
        private string phoneNum;
        public string PhoneNum
        { 
            get { return phoneNum; } 
            set {  phoneNum = value; }
        }
        private int usage;
        public int Usage
        {
            get { return usage; }
            set { usage = value; }
        }
        public string planType;
        public string PlanType
        { 
            get { return planType; } 
            set {  planType = value; } 
        }

        public Phone(string phoneNum,int usage, string planType)
        {
            PhoneNum = phoneNum;
            Usage = usage;
            PlanType = planType;
        }

        public double CalculateCharge()
        {
            double totalCharge;
            if (PlanType is "A")
            {
                totalCharge = Usage * 0.5 / 100;
            }
            else if(PlanType is "B") 
            {
                if (Usage > 1000)
                {
                    totalCharge = (Usage - 1000) * 0.2 / 100;
                }
                else totalCharge = 0;
            }
            else
            {
                if (Usage > 5000)
                {
                    totalCharge = (Usage - 5000) * 0.1 / 100;
                }
                else totalCharge = 0;
            }
            return totalCharge;
        }
        public override string ToString()
        {
            return $"Phone number: {PhoneNum}, Usage: {Usage} seconds, Plan Type: {PlanType}";
        }
    }
}
