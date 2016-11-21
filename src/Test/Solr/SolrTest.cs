using SolrNet;
using Microsoft.Practices.ServiceLocation;

namespace Test.Solr
{
    public class SolrTest
    {
        static SolrTest()
        {
            Startup.Init<SolrOrder>("http://localhost:8080/solr/Order2");
        }

        public SolrTest() { }

        public void AddOrder() {

            ISolrOperations<SolrOrder> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SolrOrder>>();
            var order = new SolrOrder
            {
                Id = "123551",
                Name = "testtest",
                Price = 88m
            };
            solr.Add(order);
            solr.Commit();
        }

        public void DeleteOrder()
        {
            //Startup.Init<SolrOrder>("http://localhost:8080/solr/Order2");

            ISolrOperations<SolrOrder> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SolrOrder>>();
            var order = new SolrOrder
            {
                Id = "123459"
            };
            solr.Delete(order);
            solr.Commit();
        }
    }
}
