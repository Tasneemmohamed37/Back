namespace Task1.Models
{
    public class ProductBL
    {
        List<Product> productSampledata;

        public ProductBL()
        {
            productSampledata = new List<Product>();
            productSampledata.Add(new Product {Id=1 , Name="laptop" , Description="llll" , Price= 200 , ImageURL="1.png" });
            productSampledata.Add(new Product {Id=2 , Name="Phone" , Description="ppp" , Price= 321 , ImageURL="2.png" });
            productSampledata.Add(new Product {Id=3 , Name="shoes" , Description="swedfe" , Price= 400 , ImageURL="3.png" });
            productSampledata.Add(new Product {Id=4 , Name="bag" , Description="gfde" , Price= 100 , ImageURL="4.png" });
        }

        public List<Product> GetAll()
        {
            return productSampledata;
        }

        public Product GetById(int _id)
        {
            return (Product)productSampledata.FirstOrDefault(p => p.Id == _id);
        }
    }
}
