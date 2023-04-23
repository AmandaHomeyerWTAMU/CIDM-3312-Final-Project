namespace Yarn.Models
{
    public class Yarn
    {
        public int YarnId {get;set;} //primary key
        public string Brand {get;set;} = string.Empty;
        public string Name {get;set;} = string.Empty;
        public string Weight {get;set;} = string.Empty;
        public int Yardage {get;set;}
        public string Fiber {get;set;} = string.Empty;
    }
}