namespace Utilities
{  
    public class Param
    { 
        protected string param = "";
        protected string data = "";

        public string MbrParam
        {
            get { return param; }
            set { param = value; }
        }

        public string MbrData
        {
            get { return data; }
            set { data = value; }
        }
    }
}