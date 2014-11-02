namespace Blacksun.XamForms.Sample.Core.Model
{
    public class Customer
    {

        public Customer()
        {
            
        }

        public Customer(int id,string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }

        public string Name { get; set; }

    }
}
