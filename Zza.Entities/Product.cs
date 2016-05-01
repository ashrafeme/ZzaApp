namespace Zza.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("product")]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
