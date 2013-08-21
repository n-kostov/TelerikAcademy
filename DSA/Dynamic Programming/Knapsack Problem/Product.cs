namespace Knapsack_Problem
{
    public class Product
    {
        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }        
        
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Product product = (Product)obj;
            return this.Name == product.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} kg for the price of {2}$", this.Name, this.Weight, this.Cost);
        }
    }
}
