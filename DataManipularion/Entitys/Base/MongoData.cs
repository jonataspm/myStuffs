using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace DataManipularion.Entitys.Base
{
    public class MongoData
    {
        public IMongoDatabase database { get; }

        public MongoData(IConfiguration configuration) 
        {
            try
            {
                var settigns = MongoClientSettings.FromUrl(new MongoUrl(configuration["MongoConnectionString"]));
                var client = new MongoClient(settigns);
                database = client.GetDatabase(configuration["BaseName"]);
                
                MapEntities<Tasks>();
            }
            catch (Exception ex) 
            {
                throw new Exception("Mongo was not connected");
            }
        }

        private void MapEntities<T>() 
        {
            var convetionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", convetionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(T))) 
            {
                BsonClassMap.RegisterClassMap<T>(i =>
                    {
                        i.AutoMap();
                        i.SetIgnoreExtraElements(true);
                    }
                );
            }
        }
    }
}
